(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

QLNet is a based on QuantLib, a free-software/open-source library
for financial quantitative analysts and developers - http://quantlib.org/
The QuantLib license is available online at http://quantlib.org/license.shtml.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>
  This class implements a discrete geometric average-strike Asian option, with European exercise.  The formula is from "Asian Option", E. Levy (1997) in "Exotic Options: The State of the Art", edited by L. Clewlow, C. Strickland, pag 65-97  - the correctness of the returned value is tested by reproducing known good results.  asianengines

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticDiscreteGeometricAverageStrikeAsianEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    ) as this =

    inherit Model<AnalyticDiscreteGeometricAverageStrikeAsianEngine> ()
(*
    Parameters
*)
    let _Process                                   = Process
(*
    Functions
*)
    let _AnalyticDiscreteGeometricAverageStrikeAsianEngine = cell (fun () -> new AnalyticDiscreteGeometricAverageStrikeAsianEngine (Process.Value))
    let _calculate                                 = cell (fun () -> _AnalyticDiscreteGeometricAverageStrikeAsianEngine.Value.calculate()
                                                                     _AnalyticDiscreteGeometricAverageStrikeAsianEngine.Value)
    do this.Bind(_AnalyticDiscreteGeometricAverageStrikeAsianEngine)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.Calculate                          = _calculate