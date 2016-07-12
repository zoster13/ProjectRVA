///////////////////////////////////////////////////////////
//  PowerTransformerEnd.cs
//  Implementation of the Class PowerTransformerEnd
//  Generated by Enterprise Architect
//  Created on:      10-Jul-2016 2:00:05 PM
//  Original author: T. Kostic
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using CIM.IEC61970.Base.Wires;
namespace CIM.IEC61970.Base.Wires {
	/// <summary>
	/// A PowerTransformerEnd is associated with each Terminal of a PowerTransformer.
	/// The impedance values r, r0, x, and x0 of a PowerTransformerEnd represents a
	/// star equivalent as follows
	/// 1) for a two Terminal PowerTransformer the high voltage PowerTransformerEnd has
	/// non zero values on r, r0, x, and x0 while the low voltage PowerTransformerEnd
	/// has zero values for r, r0, x, and x0.
	/// 2) for a three Terminal PowerTransformer the three PowerTransformerEnds
	/// represents a star equivalent with each leg in the star represented by r, r0, x,
	/// and x0 values.
	/// 3) for a PowerTransformer with more than three Terminals the
	/// PowerTransformerEnd impedance values cannot be used. Instead use the
	/// TransformerMeshImpedance or split the transformer into multiple
	/// PowerTransformers.
	/// </summary>
	public class PowerTransformerEnd : TransformerEnd {

		/// <summary>
		/// Magnetizing branch susceptance (B mag).  The value can be positive or negative.
		/// 
		/// </summary>
		public float b;
		/// <summary>
		/// Kind of connection.
		/// </summary>
		public WindingConnection connectionKind;
		/// <summary>
		/// Magnetizing branch conductance.
		/// </summary>
		public float g;
		/// <summary>
		/// Terminal voltage phase angle displacement where 360 degrees are represented
		/// with clock hours. The valid values are 0 to 11. For example, for the secondary
		/// side end of a transformer with vector group code of 'Dyn11', specify the
		/// connection kind as wye with neutral and specify the phase angle of the clock as
		/// 11.  The clock value of the transformer end number specified as 1, is assumed
		/// to be zero.  Note the transformer end number is not assumed to be the same as
		/// the terminal sequence number.
		/// </summary>
		public int phaseAngleClock;
		/// <summary>
		/// Resistance (star-model) of the transformer end.
		/// The attribute shall be equal or greater than zero for non-equivalent
		/// transformers.
		/// </summary>
		public float r;
		/// <summary>
		/// Normal apparent power rating.
		/// The attribute shall be a positive value. For a two-winding transformer the
		/// values for the high and low voltage sides shall be identical.
		/// </summary>
		public float ratedS;
		/// <summary>
		/// Rated voltage: phase-phase for three-phase windings, and either phase-phase or
		/// phase-neutral for single-phase windings.
		/// A high voltage side, as given by TransformerEnd.endNumber, shall have a ratedU
		/// that is greater or equal than ratedU for the lower voltage sides.
		/// </summary>
		public float ratedU;
		/// <summary>
		/// Positive sequence series reactance (star-model) of the transformer end.
		/// </summary>
		public float x;

		public PowerTransformerEnd(){

		}

		~PowerTransformerEnd(){

		}

	}//end PowerTransformerEnd

}//end namespace Wires