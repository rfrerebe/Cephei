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

Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type FdmSolverDescModel
    () as this =
    inherit Model<FdmSolverDesc> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _FdmSolverDesc                             = cell (fun () -> new FdmSolverDesc ())
    let _bcSet                                     = cell (fun () -> _FdmSolverDesc.Value.bcSet)
    let _calculator                                = cell (fun () -> _FdmSolverDesc.Value.calculator)
    let _condition                                 = cell (fun () -> _FdmSolverDesc.Value.condition)
    let _dampingSteps                              = cell (fun () -> _FdmSolverDesc.Value.dampingSteps)
    let _maturity                                  = cell (fun () -> _FdmSolverDesc.Value.maturity)
    let _mesher                                    = cell (fun () -> _FdmSolverDesc.Value.mesher)
    let _timeSteps                                 = cell (fun () -> _FdmSolverDesc.Value.timeSteps)
    do this.Bind(_FdmSolverDesc)

(* 
    Externally visible/bindable properties
*)
    member this.BcSet                              = _bcSet
    member this.Calculator                         = _calculator
    member this.Condition                          = _condition
    member this.DampingSteps                       = _dampingSteps
    member this.Maturity                           = _maturity
    member this.Mesher                             = _mesher
    member this.TimeSteps                          = _timeSteps