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
  Most methods inherited from Bond (such as yield or the yield-based dirtyPrice and cleanPrice) refer to the underlying plain-vanilla bond and do not take convertibility and callability into account.

  </summary> *)
[<AutoSerializable(true)>]
type ConvertibleFloatingRateBondModel
    ( exercise                                     : ICell<Exercise>
    , conversionRatio                              : ICell<double>
    , dividends                                    : ICell<DividendSchedule>
    , callability                                  : ICell<CallabilitySchedule>
    , creditSpread                                 : ICell<Handle<Quote>>
    , issueDate                                    : ICell<Date>
    , settlementDays                               : ICell<int>
    , index                                        : ICell<IborIndex>
    , fixingDays                                   : ICell<int>
    , spreads                                      : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , schedule                                     : ICell<Schedule>
    , redemption                                   : ICell<double>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ConvertibleFloatingRateBond> ()
(*
    Parameters
*)
    let _exercise                                  = exercise
    let _conversionRatio                           = conversionRatio
    let _dividends                                 = dividends
    let _callability                               = callability
    let _creditSpread                              = creditSpread
    let _issueDate                                 = issueDate
    let _settlementDays                            = settlementDays
    let _index                                     = index
    let _fixingDays                                = fixingDays
    let _spreads                                   = spreads
    let _dayCounter                                = dayCounter
    let _schedule                                  = schedule
    let _redemption                                = redemption
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _ConvertibleFloatingRateBond               = cell (fun () -> withEngine _pricingEngine.Value (new ConvertibleFloatingRateBond (exercise.Value, conversionRatio.Value, dividends.Value, callability.Value, creditSpread.Value, issueDate.Value, settlementDays.Value, index.Value, fixingDays.Value, spreads.Value, dayCounter.Value, schedule.Value, redemption.Value)))
    let _callability                               = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).callability())
    let _conversionRatio                           = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).conversionRatio())
    let _creditSpread                              = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).creditSpread())
    let _dividends                                 = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).dividends())
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).accruedAmount(settlement.Value))
    let _calendar                                  = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).calendar())
    let _cashflows                                 = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).isExpired())
    let _issueDate                                 = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).isTradable(d.Value))
    let _maturityDate                              = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).notional(d.Value))
    let _notionals                                 = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).previousCouponRate(settlement.Value))
    let _redemption                                = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).redemption())
    let _redemptions                               = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).settlementDate(date.Value))
    let _settlementDays                            = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).settlementValue())
    let _startDate                                 = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).CASH())
    let _errorEstimate                             = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).setPricingEngine(e.Value)
                                                                     _ConvertibleFloatingRateBond.Value)
    let _valuationDate                             = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFloatingRateBond).valuationDate())
    do this.Bind(_ConvertibleFloatingRateBond)

(* 
    Externally visible/bindable properties
*)
    member this.exercise                           = _exercise 
    member this.conversionRatio                    = _conversionRatio 
    member this.dividends                          = _dividends 
    member this.callability                        = _callability 
    member this.creditSpread                       = _creditSpread 
    member this.issueDate                          = _issueDate 
    member this.settlementDays                     = _settlementDays 
    member this.index                              = _index 
    member this.fixingDays                         = _fixingDays 
    member this.spreads                            = _spreads 
    member this.dayCounter                         = _dayCounter 
    member this.schedule                           = _schedule 
    member this.redemption                         = _redemption 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.Callability                        = _callability
    member this.ConversionRatio                    = _conversionRatio
    member this.CreditSpread                       = _creditSpread
    member this.Dividends                          = _dividends
    member this.AccruedAmount                      settlement   
                                                   = _accruedAmount settlement 
    member this.Calendar                           = _calendar
    member this.Cashflows                          = _cashflows
    member this.CleanPrice                         = _cleanPrice
    member this.CleanPrice1                        Yield dc comp freq settlement   
                                                   = _cleanPrice1 Yield dc comp freq settlement 
    member this.DirtyPrice                         = _dirtyPrice
    member this.DirtyPrice1                        Yield dc comp freq settlement   
                                                   = _dirtyPrice1 Yield dc comp freq settlement 
    member this.IsExpired                          = _isExpired
    member this.IssueDate                          = _issueDate
    member this.IsTradable                         d   
                                                   = _isTradable d 
    member this.MaturityDate                       = _maturityDate
    member this.NextCashFlowDate                   settlement   
                                                   = _nextCashFlowDate settlement 
    member this.NextCouponRate                     settlement   
                                                   = _nextCouponRate settlement 
    member this.Notional                           d   
                                                   = _notional d 
    member this.Notionals                          = _notionals
    member this.PreviousCashFlowDate               settlement   
                                                   = _previousCashFlowDate settlement 
    member this.PreviousCouponRate                 settlement   
                                                   = _previousCouponRate settlement 
    member this.Redemption                         = _redemption
    member this.Redemptions                        = _redemptions
    member this.SettlementDate                     date   
                                                   = _settlementDate date 
    member this.SettlementDays                     = _settlementDays
    member this.SettlementValue                    cleanPrice   
                                                   = _settlementValue cleanPrice 
    member this.SettlementValue1                   = _settlementValue1
    member this.StartDate                          = _startDate
    member this.Yield                              dc comp freq accuracy maxEvaluations   
                                                   = _yield dc comp freq accuracy maxEvaluations 
    member this.Yield1                             cleanPrice dc comp freq settlement accuracy maxEvaluations   
                                                   = _yield1 cleanPrice dc comp freq settlement accuracy maxEvaluations 
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate