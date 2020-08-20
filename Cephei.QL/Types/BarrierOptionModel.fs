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
  %Barrier option on a single asset.   The analytic pricing Engine will be used if none if passed.  instruments

  </summary> *)
[<AutoSerializable(true)>]
type BarrierOptionModel
    ( barrierType                                  : ICell<Barrier.Type>
    , barrier                                      : ICell<double>
    , rebate                                       : ICell<double>
    , payoff                                       : ICell<StrikedTypePayoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BarrierOption> ()
(*
    Parameters
*)
    let _barrierType                               = barrierType
    let _barrier                                   = barrier
    let _rebate                                    = rebate
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _BarrierOption                             = cell (fun () -> withEngine _pricingEngine.Value (new BarrierOption (barrierType.Value, barrier.Value, rebate.Value, payoff.Value, exercise.Value)))
    let _impliedVolatility                         (targetValue : ICell<double>) (Process : ICell<GeneralizedBlackScholesProcess>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).impliedVolatility(targetValue.Value, Process.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _delta                                     = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).delta())
    let _deltaForward                              = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).deltaForward())
    let _dividendRho                               = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).dividendRho())
    let _elasticity                                = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).elasticity())
    let _gamma                                     = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).gamma())
    let _isExpired                                 = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).isExpired())
    let _itmCashProbability                        = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).itmCashProbability())
    let _rho                                       = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).rho())
    let _strikeSensitivity                         = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).strikeSensitivity())
    let _theta                                     = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).theta())
    let _thetaPerDay                               = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).thetaPerDay())
    let _vega                                      = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).vega())
    let _exercise                                  = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).exercise())
    let _payoff                                    = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).payoff())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).CASH())
    let _errorEstimate                             = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).setPricingEngine(e.Value)
                                                                     _BarrierOption.Value)
    let _valuationDate                             = cell (fun () -> (withEvaluationDate _evaluationDate _BarrierOption).valuationDate())
    do this.Bind(_BarrierOption)

(* 
    Externally visible/bindable properties
*)
    member this.barrierType                        = _barrierType 
    member this.barrier                            = _barrier 
    member this.rebate                             = _rebate 
    member this.payoff                             = _payoff 
    member this.exercise                           = _exercise 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.ImpliedVolatility                  targetValue Process accuracy maxEvaluations minVol maxVol   
                                                   = _impliedVolatility targetValue Process accuracy maxEvaluations minVol maxVol 
    member this.Delta                              = _delta
    member this.DeltaForward                       = _deltaForward
    member this.DividendRho                        = _dividendRho
    member this.Elasticity                         = _elasticity
    member this.Gamma                              = _gamma
    member this.IsExpired                          = _isExpired
    member this.ItmCashProbability                 = _itmCashProbability
    member this.Rho                                = _rho
    member this.StrikeSensitivity                  = _strikeSensitivity
    member this.Theta                              = _theta
    member this.ThetaPerDay                        = _thetaPerDay
    member this.Vega                               = _vega
    member this.Exercise                           = _exercise
    member this.Payoff                             = _payoff
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate