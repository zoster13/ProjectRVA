using CIM.IEC61970.Base.Core;
using ProjectRVA.CommandPattern;
using ProjectRVA.Database;
using ProjectRVA.Prototype;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProjectRVA
{
    /// <summary>
    /// Interaction logic for Network.xaml
    /// </summary>
    public partial class Network : Window
    {
        //Command pattern
        Commander commander = new Commander();

        private Canvas draggedItem = null;
        private Substation draggedSubstation = null;
        Point p1;
        bool dragging = false;

        public Network()
        {
            InitializeComponent();
            DataContext = DataBase.Instance();
            addSubstationsOnGrid();
        }

        //CREATE
        private void Create_button(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow(commander);
            addWindow.ShowDialog();
            addWindow.Close();

            //Prikazi elemente na Canvasu
            addSubstationsOnGrid();
        }
        
        //DELETE
        private void Delete_button(object sender, RoutedEventArgs e)
        {
            //Delete Substation
            if (substation_datagrid.SelectedItem != null)
            {
                Substation sub = substation_datagrid.SelectedItem as Substation;

                Command deleteSubstation = new DeleteSubstationCommand(sub.mRID);
                commander.AddAndExecute(deleteSubstation);

                //Ponovo iscrtaj
                addSubstationsOnGrid();
            }

            //Delete ConectivityNode
            if (node_datagrid.SelectedItem != null)
            {
                ConnectivityNode sub = node_datagrid.SelectedItem as ConnectivityNode;

                Command deleteNode = new DeleteNodeCommand(sub.mRID);
                commander.AddAndExecute(deleteNode);

                //Ponovo iscrtaj
                addSubstationsOnGrid();
            }

        }

        //CLONE
        private void Clone_button(object sender, RoutedEventArgs e)
        {
            if (substation_datagrid.SelectedItem != null)
            {
                Substation sub = substation_datagrid.SelectedItem as Substation;

                Kloniraj.Clone(sub);

                //Ponovo iscrtaj
                addSubstationsOnGrid();
            }

            //Delete ConectivityNode
            if (node_datagrid.SelectedItem != null)
            {
                ConnectivityNode node = node_datagrid.SelectedItem as ConnectivityNode;

                Kloniraj.Clone(node);

                //Ponovo iscrtaj
                addSubstationsOnGrid();
            }
        }

        //UNDO
        private void Undo_button(object sender, RoutedEventArgs e)
        {
            commander.Undo();

            //Osvjezi prikaz
            addSubstationsOnGrid();
        }


        //Drag & Drop
        private void mouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point ClickedPoint = e.GetPosition(canvas_network);
            
            //Prolazimo kroz listu TS
            for (int i = 0; i < DataBase.Substations.Count; i++)
            {
                //Pitamo da li ima cvor koji se nalazi na kordinatama gde smo kliknuli misom
                if ((ClickedPoint.X >= Canvas.GetLeft(canvas_network.Children[i])) && (ClickedPoint.X <= Canvas.GetLeft(canvas_network.Children[i]) + 80)
                  && (ClickedPoint.Y >= Canvas.GetTop(canvas_network.Children[i]) && (ClickedPoint.Y <= Canvas.GetTop(canvas_network.Children[i]) + 95)))
                {
                    foreach (Substation sub in DataBase.Substations)
                    {
                        if (sub.X == Canvas.GetLeft(canvas_network.Children[i]) && sub.Y == Canvas.GetTop(canvas_network.Children[i]))
                        {
                            draggedSubstation = sub;
                            draggedItem = canvas_network.Children[i] as Canvas;
                            draggedItem.Opacity = 0.5; //smanjim mu vidljivost da onako izbledi
                            dragging = true;
                        }
                    }

                    //Zavrsavamo sa pretragom
                    break;
                }
            }
        }
        
        private void dragOver(object sender, DragEventArgs e)
        {
            if (dragging)
            {
                e.Effects = DragDropEffects.Move;

                Point p = e.GetPosition(canvas_network);

                Canvas.SetLeft(draggedItem, p.X);  //setujem poziciju kanvasa
                Canvas.SetTop(draggedItem, p.Y);

                //ukoliko dodjem do zida sledeca 4 ifa
                if (p.Y - p1.Y >= 215)
                {
                    Canvas.SetTop(draggedItem, 215);
                }

                if (p.Y - p1.Y <= 0)
                {
                    Canvas.SetTop(draggedItem, 0);
                }

                if (p.X - p1.X >= 445)
                {
                    Canvas.SetLeft(draggedItem, 445);
                }

                if (p.X - p1.X <= 0)
                {
                    Canvas.SetLeft(draggedItem, 0);
                }
            }
        }

        private void drop(object sender, DragEventArgs e)
        {
            
            Point p = e.GetPosition(canvas_network); // hvatam poziciju gde sam kliknuo na velikom kanvasu
            
            Canvas.SetLeft(draggedItem, p.X);  
            Canvas.SetTop(draggedItem, p.Y);
            
            Command commandMove = new DragAndDropCommand(p.X, p.Y, draggedSubstation);
            commander.AddAndExecute(commandMove);

            draggedItem.Opacity = 1;
            draggedItem = null;
            draggedSubstation = null;
            dragging = false;
        }

        private void network_mouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)        //item is selected
            {
                if(e.LeftButton == MouseButtonState.Pressed)
                {
                    DragDrop.DoDragDrop(this, draggedItem, DragDropEffects.All);
                }
            }
        }



        // SHOW -  UBACITI U OBSERVER(?)
        private void addSubstationsOnGrid()
        {
            //Za random dodeljivanje kordinata
            Random rnd = new Random();
            canvas_network.Children.Clear();

            for (int i = 0; i < DataBase.Substations.Count; i++)
            {
                //Pravimo objekat u kome cemo prikazati Trafostanicu, objekat je dim 50x50
                Canvas MiniCanvas = new Canvas();
                MiniCanvas.Height = 95;
                MiniCanvas.Width = 80;
                MiniCanvas.Background = new SolidColorBrush(Colors.LightBlue);

                //Pitamo da li je SUBSTATIONU vec dodeljena pozicija
                if (DataBase.Substations[i].X == -1 && DataBase.Substations[i].Y == -1)
                {
                    //Random odredjivanje kordinata BICE IZBACENO KAD UBACIMO DRAG&DROP
                    int x = rnd.Next(1, 445);
                    int y = rnd.Next(1, 200);

                    //Pamtimo poziciju elementa na kanvasu
                    DataBase.Substations[i].X = x;
                    DataBase.Substations[i].Y = y;
                }

                //ConnectivityNodes
                foreach (ConnectivityNode node in DataBase.Substations[i].ConnectivityNodes)
                {
                    if (node.X == -1 && node.Y == -1)
                    {
                        //Random odredjivanje kordinata BICE IZBACENO KAD UBACIMO DRAG&DROP
                        int x = rnd.Next(1, 70);
                        int y = rnd.Next(1, 70);

                        //Pamtimo poziciju elementa na kanvasu
                        node.X = x;
                        node.Y = y;
                    }

                    Canvas NodeCanvas = new Canvas();
                    NodeCanvas.Height = 10;
                    NodeCanvas.Width = 10;
                    NodeCanvas.Background = new SolidColorBrush(Colors.Black);
                    Canvas.SetLeft(NodeCanvas, node.X);
                    Canvas.SetTop(NodeCanvas, node.Y);

                    //Name of Node
                    TextBox nodeName = new TextBox();
                    nodeName.Text = node.name;
                    nodeName.IsEnabled = false;
                    nodeName.Height = 15;
                    nodeName.Width = 25;
                    Canvas.SetLeft(nodeName, node.X);
                    Canvas.SetTop(nodeName, node.Y + 11);
                    MiniCanvas.Children.Add(nodeName);

                    MiniCanvas.Children.Add(NodeCanvas);
                }

                //Dodajemo element na kanvas i na poziciju (x,y)
                Canvas.SetLeft(MiniCanvas, DataBase.Substations[i].X);
                Canvas.SetTop(MiniCanvas, DataBase.Substations[i].Y);
                canvas_network.Children.Add(MiniCanvas);

                TextBox text = new TextBox();
                text.Text = DataBase.Substations[i].name;
                text.IsEnabled = false;
                text.Height = 15;
                text.Width = 80;
                Canvas.SetLeft(text, 0);
                Canvas.SetTop(text, 80);
                MiniCanvas.Children.Add(text);
            }
        }

    }
}