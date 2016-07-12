///////////////////////////////////////////////////////////
//  RotatingMachine.cs
//  Implementation of the Class RotatingMachine
//  Generated by Enterprise Architect
//  Created on:      10-Jul-2016 2:00:05 PM
//  Original author: tsaxton
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using CIM.IEC61970.Base.Core;
namespace CIM.IEC61970.Base.Wires {
	/// <summary>
	/// A rotating machine which may be used as a generator or motor.
	/// </summary>
	public class RotatingMachine : ConductingEquipment {

		/// <summary>
		/// Power factor (nameplate data). It is primarily used for short circuit data
		/// exchange according to IEC 60909.
		/// </summary>
		public float ratedPowerFactor;
		/// <summary>
		/// Nameplate apparent power rating for the unit.
		/// </summary>
		public float ratedS;
		/// <summary>
		/// Rated voltage (nameplate data, Ur in IEC 60909-0). It is primarily used for
		/// short circuit data exchange according to IEC 60909.
		/// </summary>
		public float ratedU;

		public RotatingMachine(){

		}

		~RotatingMachine(){

		}

	}//end RotatingMachine

}//end namespace Wires