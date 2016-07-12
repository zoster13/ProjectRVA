///////////////////////////////////////////////////////////
//  Substation.cs
//  Implementation of the Class Substation
//  Generated by Enterprise Architect
//  Created on:      08-Jul-2016 7:31:32 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using CIM.IEC61970.Base.Core;
using System.Xml.Serialization;
using System.ComponentModel;

namespace CIM.IEC61970.Base.Core {
	/// <summary>
	/// A collection of equipment for purposes other than generation or utilization,
	/// through which electric energy in bulk is passed for the purposes of switching
	/// or modifying its characteristics.
	/// </summary>
	public class Substation : EquipmentContainer {

        /// <summary>
        /// The voltage levels within this substation.
        /// </summary>
        public List<VoltageLevel> VoltageLevels;
        /// <summary>
        /// Bays contained in the substation.
        /// </summary>
        public List<Bay> Bays;

        private double x;
        private double y;

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public Substation(){
            VoltageLevels = new List<VoltageLevel>();
            Bays = new List<Bay>();
            ConnectivityNodes = new List<ConnectivityNode>();
            X = -1;
            Y = -1;
		}

		~Substation(){

		}
        
    }//end Substation

}//end namespace Core