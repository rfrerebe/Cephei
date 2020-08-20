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
  helper class building a sequence of range-accrual floating-rate coupons

  </summary> *)
[<AutoSerializable(true)>]
type RangeAccrualLegModel
    ( schedule                                     : ICell<Schedule>
    , index                                        : ICell<IborIndex>
    ) as this =

    inherit Model<RangeAccrualLeg> ()
(*
    Parameters
*)
    let _schedule                                  = schedule
    let _index                                     = index
(*
    Functions
*)
    let _RangeAccrualLeg                           = cell (fun () -> new RangeAccrualLeg (schedule.Value, index.Value))
    let _Leg                                       = cell (fun () -> _RangeAccrualLeg.Value.Leg())
    let _withFixingDays                            (fixingDays : ICell<int>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withFixingDays(fixingDays.Value))
    let _withFixingDays1                           (fixingDays : ICell<Generic.List<int>>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withFixingDays(fixingDays.Value))
    let _withGearings                              (gearings : ICell<Generic.List<double>>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withGearings(gearings.Value))
    let _withGearings1                             (gearing : ICell<double>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withGearings(gearing.Value))
    let _withLowerTriggers                         (triggers : ICell<Generic.List<double>>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withLowerTriggers(triggers.Value))
    let _withLowerTriggers1                        (trigger : ICell<double>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withLowerTriggers(trigger.Value))
    let _withNotionals                             (notional : ICell<double>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withNotionals(notional.Value))
    let _withNotionals1                            (notionals : ICell<Generic.List<double>>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withNotionals(notionals.Value))
    let _withObservationConvention                 (convention : ICell<BusinessDayConvention>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withObservationConvention(convention.Value))
    let _withObservationTenor                      (tenor : ICell<Period>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withObservationTenor(tenor.Value))
    let _withPaymentAdjustment                     (convention : ICell<BusinessDayConvention>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withPaymentAdjustment(convention.Value))
    let _withPaymentDayCounter                     (dayCounter : ICell<DayCounter>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withPaymentDayCounter(dayCounter.Value))
    let _withSpreads                               (spreads : ICell<Generic.List<double>>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withSpreads(spreads.Value))
    let _withSpreads1                              (spread : ICell<double>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withSpreads(spread.Value))
    let _withUpperTriggers                         (trigger : ICell<double>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withUpperTriggers(trigger.Value))
    let _withUpperTriggers1                        (triggers : ICell<Generic.List<double>>)   
                                                   = cell (fun () -> _RangeAccrualLeg.Value.withUpperTriggers(triggers.Value))
    do this.Bind(_RangeAccrualLeg)

(* 
    Externally visible/bindable properties
*)
    member this.schedule                           = _schedule 
    member this.index                              = _index 
    member this.Leg                                = _Leg
    member this.WithFixingDays                     fixingDays   
                                                   = _withFixingDays fixingDays 
    member this.WithFixingDays1                    fixingDays   
                                                   = _withFixingDays1 fixingDays 
    member this.WithGearings                       gearings   
                                                   = _withGearings gearings 
    member this.WithGearings1                      gearing   
                                                   = _withGearings1 gearing 
    member this.WithLowerTriggers                  triggers   
                                                   = _withLowerTriggers triggers 
    member this.WithLowerTriggers1                 trigger   
                                                   = _withLowerTriggers1 trigger 
    member this.WithNotionals                      notional   
                                                   = _withNotionals notional 
    member this.WithNotionals1                     notionals   
                                                   = _withNotionals1 notionals 
    member this.WithObservationConvention          convention   
                                                   = _withObservationConvention convention 
    member this.WithObservationTenor               tenor   
                                                   = _withObservationTenor tenor 
    member this.WithPaymentAdjustment              convention   
                                                   = _withPaymentAdjustment convention 
    member this.WithPaymentDayCounter              dayCounter   
                                                   = _withPaymentDayCounter dayCounter 
    member this.WithSpreads                        spreads   
                                                   = _withSpreads spreads 
    member this.WithSpreads1                       spread   
                                                   = _withSpreads1 spread 
    member this.WithUpperTriggers                  trigger   
                                                   = _withUpperTriggers trigger 
    member this.WithUpperTriggers1                 triggers   
                                                   = _withUpperTriggers1 triggers 