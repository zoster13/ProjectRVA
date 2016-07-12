///////////////////////////////////////////////////////////
//  ACLineSegment.cs
//  Implementation of the Class ACLineSegment
//  Generated by Enterprise Architect
//  Created on:      10-Jul-2016 2:00:03 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using CIM.IEC61970.Base.Wires;
namespace CIM.IEC61970.Base.Wires {
	/// <summary>
	/// A wire or combination of wires, with consistent electrical characteristics,
	/// building a single electrical system, used to carry alternating current between
	/// points in the power system.
	/// For symmetrical, transposed 3ph lines, it is sufficient to use  attributes of
	/// the line segment, which describe impedances and admittances for the entire
	/// length of the segment.  Additionally impedances can be computed by using length
	/// and associated per length impedances.
	/// The BaseVoltage at the two ends of ACLineSegments in a Line shall have the same
	/// BaseVoltage.nominalVoltage. However, boundary lines  may have slightly
	/// different BaseVoltage.nominalVoltages and  variation is allowed. Larger voltage
	/// difference in general requires use of an equivalent branch.
	/// </summary>
	public class ACLineSegment : Conductor {

		/// <summary>
		/// Positive sequence shunt (charging) susceptance, uniformly distributed, of the
		/// entire line section.  This value represents the full charging over the full
		/// length of the line.
		/// </summary>
		public float bch;
		/// <summary>
		/// Positive sequence shunt (charging) conductance, uniformly distributed, of the
		/// entire line section.
		/// </summary>
		public float gch;
		/// <summary>
		/// Positive sequence series resistance of the entire line section.
		/// </summary>
		public float r;
		/// <summary>
		/// Positive sequence series reactance of the entire line section.
		/// </summary>
		public float x;

		public ACLineSegment(){

		}

		~ACLineSegment(){

		}

	}//end ACLineSegment

}//end namespace Wires