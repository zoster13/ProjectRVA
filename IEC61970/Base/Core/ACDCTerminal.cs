///////////////////////////////////////////////////////////
//  ACDCTerminal.cs
//  Implementation of the Class ACDCTerminal
//  Generated by Enterprise Architect
//  Created on:      10-Jul-2016 2:00:03 PM
//  Original author: selaost1
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using CIM.IEC61970.Base.Core;
namespace CIM.IEC61970.Base.Core {
	/// <summary>
	/// An electrical connection point (AC or DC) to a piece of conducting equipment.
	/// Terminals are connected at physical connection points called connectivity nodes.
	/// 
	/// </summary>
	public class ACDCTerminal : IdentifiedObject {

		/// <summary>
		/// The connected status is related to a bus-branch model and the topological node
		/// to terminal relation.  True implies the terminal is connected to the related
		/// topological node and false implies it is not.
		/// In a bus-branch model, the connected status is used to tell if equipment is
		/// disconnected without having to change the connectivity described by the
		/// topological node to terminal relation. A valid case is that conducting
		/// equipment can be connected in one end and open in the other. In particular for
		/// an AC line segment, where the reactive line charging can be significant, this
		/// is a relevant case.
		/// </summary>
		public bool connected;
		/// <summary>
		/// The orientation of the terminal connections for a multiple terminal conducting
		/// equipment.  The sequence numbering starts with 1 and additional terminals
		/// should follow in increasing order.   The first terminal is the "starting point"
		/// for a two terminal branch.
		/// </summary>
		public int sequenceNumber;

		public ACDCTerminal(){

		}

		~ACDCTerminal(){

		}

	}//end ACDCTerminal

}//end namespace Core