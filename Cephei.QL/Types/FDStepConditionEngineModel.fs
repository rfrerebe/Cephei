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
  Finite-differences pricing engine for American-style vanilla options
public FDStepConditionEngine(GeneralizedBlackScholesProcess process, int timeSteps, int gridPoints, bool timeDependent = false)
  </summary> *)
[<AutoSerializable(true)>]
type FDStepConditionEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<int>
    , gridPoints                                   : ICell<int>
    , timeDependent                                : ICell<bool>
    ) as this =

    inherit Model<FDStepConditionEngine> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _timeSteps                                 = timeSteps
    let _gridPoints                                = gridPoints
    let _timeDependent                             = timeDependent
(*
    Functions
*)
    let _FDStepConditionEngine                     = cell (fun () -> new FDStepConditionEngine (Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _calculate                                 (r : ICell<IPricingEngineResults>)   
                                                   = cell (fun () -> _FDStepConditionEngine.Value.calculate(r.Value)
                                                                     _FDStepConditionEngine.Value)
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = cell (fun () -> _FDStepConditionEngine.Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _setStepCondition                          (impl : ICell<Func<IStepCondition<Vector>>>)   
                                                   = cell (fun () -> _FDStepConditionEngine.Value.setStepCondition(impl.Value)
                                                                     _FDStepConditionEngine.Value)
    let _ensureStrikeInGrid                        = cell (fun () -> _FDStepConditionEngine.Value.ensureStrikeInGrid()
                                                                     _FDStepConditionEngine.Value)
    let _getResidualTime                           = cell (fun () -> _FDStepConditionEngine.Value.getResidualTime())
    let _grid                                      = cell (fun () -> _FDStepConditionEngine.Value.grid())
    let _intrinsicValues_                          = cell (fun () -> _FDStepConditionEngine.Value.intrinsicValues_)
    do this.Bind(_FDStepConditionEngine)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.timeSteps                          = _timeSteps 
    member this.gridPoints                         = _gridPoints 
    member this.timeDependent                      = _timeDependent 
    member this.Calculate                          r   
                                                   = _calculate r 
    member this.Factory                            Process timeSteps gridPoints timeDependent   
                                                   = _factory Process timeSteps gridPoints timeDependent 
    member this.SetStepCondition                   impl   
                                                   = _setStepCondition impl 
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_
(* <summary>
  Finite-differences pricing engine for American-style vanilla options
required for generics
  </summary> *)
[<AutoSerializable(true)>]
type FDStepConditionEngineModel1
    () as this =
    inherit Model<FDStepConditionEngine> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _FDStepConditionEngine                     = cell (fun () -> new FDStepConditionEngine ())
    let _calculate                                 (r : ICell<IPricingEngineResults>)   
                                                   = cell (fun () -> _FDStepConditionEngine.Value.calculate(r.Value)
                                                                     _FDStepConditionEngine.Value)
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = cell (fun () -> _FDStepConditionEngine.Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _setStepCondition                          (impl : ICell<Func<IStepCondition<Vector>>>)   
                                                   = cell (fun () -> _FDStepConditionEngine.Value.setStepCondition(impl.Value)
                                                                     _FDStepConditionEngine.Value)
    let _ensureStrikeInGrid                        = cell (fun () -> _FDStepConditionEngine.Value.ensureStrikeInGrid()
                                                                     _FDStepConditionEngine.Value)
    let _getResidualTime                           = cell (fun () -> _FDStepConditionEngine.Value.getResidualTime())
    let _grid                                      = cell (fun () -> _FDStepConditionEngine.Value.grid())
    let _intrinsicValues_                          = cell (fun () -> _FDStepConditionEngine.Value.intrinsicValues_)
    do this.Bind(_FDStepConditionEngine)

(* 
    Externally visible/bindable properties
*)
    member this.Calculate                          r   
                                                   = _calculate r 
    member this.Factory                            Process timeSteps gridPoints timeDependent   
                                                   = _factory Process timeSteps gridPoints timeDependent 
    member this.SetStepCondition                   impl   
                                                   = _setStepCondition impl 
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_