///////////////////////////////////////////////////////////
//  PhaseCode.cs
//  Implementation of the Enumeration PhaseCode
//  Generated by Enterprise Architect
//  Created on:      10-Jul-2016 2:00:04 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace CIM.IEC61970.Base.Core {
	/// <summary>
	/// Enumeration of phase identifiers. Allows designation of phases for both
	/// transmission and distribution equipment, circuits and loads.
	/// Residential and small commercial loads are often served from single-phase, or
	/// split-phase, secondary circuits. For example of s12N, phases 1 and 2 refer to
	/// hot wires that are 180 degrees out of phase, while N refers to the neutral wire.
	/// Through single-phase transformer connections, these secondary circuits may be
	/// served from one or two of the primary phases A, B, and C. For three-phase loads,
	/// use the A, B, C phase codes instead of s12N.
	/// </summary>
	public enum PhaseCode : int {

		/// <summary>
		/// Phases A, B, C, and N.
		/// </summary>
		ABCN,
		/// <summary>
		/// Phases A, B, and C.
		/// </summary>
		ABC,
		/// <summary>
		/// Phases A, B, and neutral.
		/// </summary>
		ABN,
		/// <summary>
		/// Phases A, C and neutral.
		/// </summary>
		ACN,
		/// <summary>
		/// Phases B, C, and neutral.
		/// </summary>
		BCN,
		/// <summary>
		/// Phases A and B.
		/// </summary>
		AB,
		/// <summary>
		/// Phases A and C.
		/// </summary>
		AC,
		/// <summary>
		/// Phases B and C.
		/// </summary>
		BC,
		/// <summary>
		/// Phases A and neutral.
		/// </summary>
		AN,
		/// <summary>
		/// Phases B and neutral.
		/// </summary>
		BN,
		/// <summary>
		/// Phases C and neutral.
		/// </summary>
		CN,
		/// <summary>
		/// Phase A.
		/// </summary>
		A,
		/// <summary>
		/// Phase B.
		/// </summary>
		B,
		/// <summary>
		/// Phase C.
		/// </summary>
		C,
		/// <summary>
		/// Neutral phase.
		/// </summary>
		N,
		/// <summary>
		/// Secondary phase 1 and neutral.
		/// </summary>
		s1N,
		/// <summary>
		/// Secondary phase 2 and neutral.
		/// </summary>
		s2N,
		/// <summary>
		/// Secondary phases 1, 2, and neutral.
		/// </summary>
		s12N,
		/// <summary>
		/// Secondary phase 1.
		/// </summary>
		s1,
		/// <summary>
		/// Secondary phase 2.
		/// </summary>
		s2,
		/// <summary>
		/// Secondary phase 1 and 2.
		/// </summary>
		s12

	}//end PhaseCode

}//end namespace Core