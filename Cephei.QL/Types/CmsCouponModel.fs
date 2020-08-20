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
  CMS coupon class   This class does not perform any date adjustment, i.e., the start and end date passed upon construction should be already rolled to a business day.
need by CashFlowVectors
  </summary> *)
[<AutoSerializable(true)>]
type CmsCouponModel
    () as this =
    inherit Model<CmsCoupon> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _CmsCoupon                                 = cell (fun () -> new CmsCoupon ())
    let _factory                                   (nominal : ICell<double>) (paymentDate : ICell<Date>) (startDate : ICell<Date>) (endDate : ICell<Date>) (fixingDays : ICell<int>) (index : ICell<InterestRateIndex>) (gearing : ICell<double>) (spread : ICell<double>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>) (dayCounter : ICell<DayCounter>) (isInArrears : ICell<bool>)   
                                                   = cell (fun () -> _CmsCoupon.Value.factory(nominal.Value, paymentDate.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value, isInArrears.Value))
    let _swapIndex                                 = cell (fun () -> _CmsCoupon.Value.swapIndex())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = cell (fun () -> _CmsCoupon.Value.accruedAmount(d.Value))
    let _adjustedFixing                            = cell (fun () -> _CmsCoupon.Value.adjustedFixing)
    let _amount                                    = cell (fun () -> _CmsCoupon.Value.amount())
    let _convexityAdjustment                       = cell (fun () -> _CmsCoupon.Value.convexityAdjustment())
    let _dayCounter                                = cell (fun () -> _CmsCoupon.Value.dayCounter())
    let _fixingDate                                = cell (fun () -> _CmsCoupon.Value.fixingDate())
    let _fixingDays                                = cell (fun () -> _CmsCoupon.Value.fixingDays)
    let _gearing                                   = cell (fun () -> _CmsCoupon.Value.gearing())
    let _index                                     = cell (fun () -> _CmsCoupon.Value.index())
    let _indexFixing                               = cell (fun () -> _CmsCoupon.Value.indexFixing())
    let _isInArrears                               = cell (fun () -> _CmsCoupon.Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = cell (fun () -> _CmsCoupon.Value.price(yts.Value))
    let _pricer                                    = cell (fun () -> _CmsCoupon.Value.pricer())
    let _rate                                      = cell (fun () -> _CmsCoupon.Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = cell (fun () -> _CmsCoupon.Value.setPricer(pricer.Value)
                                                                     _CmsCoupon.Value)
    let _spread                                    = cell (fun () -> _CmsCoupon.Value.spread())
    let _update                                    = cell (fun () -> _CmsCoupon.Value.update()
                                                                     _CmsCoupon.Value)
    let _accrualDays                               = cell (fun () -> _CmsCoupon.Value.accrualDays())
    let _accrualEndDate                            = cell (fun () -> _CmsCoupon.Value.accrualEndDate())
    let _accrualPeriod                             = cell (fun () -> _CmsCoupon.Value.accrualPeriod())
    let _accrualStartDate                          = cell (fun () -> _CmsCoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = cell (fun () -> _CmsCoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = cell (fun () -> _CmsCoupon.Value.accruedPeriod(d.Value))
    let _date                                      = cell (fun () -> _CmsCoupon.Value.date())
    let _exCouponDate                              = cell (fun () -> _CmsCoupon.Value.exCouponDate())
    let _nominal                                   = cell (fun () -> _CmsCoupon.Value.nominal())
    let _referencePeriodEnd                        = cell (fun () -> _CmsCoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = cell (fun () -> _CmsCoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = cell (fun () -> _CmsCoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = cell (fun () -> _CmsCoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = cell (fun () -> _CmsCoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = cell (fun () -> _CmsCoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = cell (fun () -> _CmsCoupon.Value.accept(v.Value)
                                                                     _CmsCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _CmsCoupon.Value.registerWith(handler.Value)
                                                                     _CmsCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _CmsCoupon.Value.unregisterWith(handler.Value)
                                                                     _CmsCoupon.Value)
    do this.Bind(_CmsCoupon)

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears   
                                                   = _factory nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears 
    member this.SwapIndex                          = _swapIndex
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Gearing                            = _gearing
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.IsInArrears                        = _isInArrears
    member this.Price                              yts   
                                                   = _price yts 
    member this.Pricer                             = _pricer
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
    member this.Spread                             = _spread
    member this.Update                             = _update
    member this.AccrualDays                        = _accrualDays
    member this.AccrualEndDate                     = _accrualEndDate
    member this.AccrualPeriod                      = _accrualPeriod
    member this.AccrualStartDate                   = _accrualStartDate
    member this.AccruedDays                        d   
                                                   = _accruedDays d 
    member this.AccruedPeriod                      d   
                                                   = _accruedPeriod d 
    member this.Date                               = _date
    member this.ExCouponDate                       = _exCouponDate
    member this.Nominal                            = _nominal
    member this.ReferencePeriodEnd                 = _referencePeriodEnd
    member this.ReferencePeriodStart               = _referencePeriodStart
    member this.CompareTo                          cf   
                                                   = _CompareTo cf 
    member this.Equals                             cf   
                                                   = _Equals cf 
    member this.HasOccurred                        refDate includeRefDate   
                                                   = _hasOccurred refDate includeRefDate 
    member this.TradingExCoupon                    refDate   
                                                   = _tradingExCoupon refDate 
    member this.Accept                             v   
                                                   = _accept v 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  CMS coupon class   This class does not perform any date adjustment, i.e., the start and end date passed upon construction should be already rolled to a business day.

  </summary> *)
[<AutoSerializable(true)>]
type CmsCouponModel1
    ( nominal                                      : ICell<double>
    , paymentDate                                  : ICell<Date>
    , startDate                                    : ICell<Date>
    , endDate                                      : ICell<Date>
    , fixingDays                                   : ICell<int>
    , swapIndex                                    : ICell<SwapIndex>
    , gearing                                      : ICell<double>
    , spread                                       : ICell<double>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    , isInArrears                                  : ICell<bool>
    ) as this =

    inherit Model<CmsCoupon> ()
(*
    Parameters
*)
    let _nominal                                   = nominal
    let _paymentDate                               = paymentDate
    let _startDate                                 = startDate
    let _endDate                                   = endDate
    let _fixingDays                                = fixingDays
    let _swapIndex                                 = swapIndex
    let _gearing                                   = gearing
    let _spread                                    = spread
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
    let _dayCounter                                = dayCounter
    let _isInArrears                               = isInArrears
(*
    Functions
*)
    let _CmsCoupon                                 = cell (fun () -> new CmsCoupon (nominal.Value, paymentDate.Value, startDate.Value, endDate.Value, fixingDays.Value, swapIndex.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value, isInArrears.Value))
    let _factory                                   (nominal : ICell<double>) (paymentDate : ICell<Date>) (startDate : ICell<Date>) (endDate : ICell<Date>) (fixingDays : ICell<int>) (index : ICell<InterestRateIndex>) (gearing : ICell<double>) (spread : ICell<double>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>) (dayCounter : ICell<DayCounter>) (isInArrears : ICell<bool>)   
                                                   = cell (fun () -> _CmsCoupon.Value.factory(nominal.Value, paymentDate.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value, isInArrears.Value))
    let _swapIndex                                 = cell (fun () -> _CmsCoupon.Value.swapIndex())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = cell (fun () -> _CmsCoupon.Value.accruedAmount(d.Value))
    let _adjustedFixing                            = cell (fun () -> _CmsCoupon.Value.adjustedFixing)
    let _amount                                    = cell (fun () -> _CmsCoupon.Value.amount())
    let _convexityAdjustment                       = cell (fun () -> _CmsCoupon.Value.convexityAdjustment())
    let _dayCounter                                = cell (fun () -> _CmsCoupon.Value.dayCounter())
    let _fixingDate                                = cell (fun () -> _CmsCoupon.Value.fixingDate())
    let _fixingDays                                = cell (fun () -> _CmsCoupon.Value.fixingDays)
    let _gearing                                   = cell (fun () -> _CmsCoupon.Value.gearing())
    let _index                                     = cell (fun () -> _CmsCoupon.Value.index())
    let _indexFixing                               = cell (fun () -> _CmsCoupon.Value.indexFixing())
    let _isInArrears                               = cell (fun () -> _CmsCoupon.Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = cell (fun () -> _CmsCoupon.Value.price(yts.Value))
    let _pricer                                    = cell (fun () -> _CmsCoupon.Value.pricer())
    let _rate                                      = cell (fun () -> _CmsCoupon.Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = cell (fun () -> _CmsCoupon.Value.setPricer(pricer.Value)
                                                                     _CmsCoupon.Value)
    let _spread                                    = cell (fun () -> _CmsCoupon.Value.spread())
    let _update                                    = cell (fun () -> _CmsCoupon.Value.update()
                                                                     _CmsCoupon.Value)
    let _accrualDays                               = cell (fun () -> _CmsCoupon.Value.accrualDays())
    let _accrualEndDate                            = cell (fun () -> _CmsCoupon.Value.accrualEndDate())
    let _accrualPeriod                             = cell (fun () -> _CmsCoupon.Value.accrualPeriod())
    let _accrualStartDate                          = cell (fun () -> _CmsCoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = cell (fun () -> _CmsCoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = cell (fun () -> _CmsCoupon.Value.accruedPeriod(d.Value))
    let _date                                      = cell (fun () -> _CmsCoupon.Value.date())
    let _exCouponDate                              = cell (fun () -> _CmsCoupon.Value.exCouponDate())
    let _nominal                                   = cell (fun () -> _CmsCoupon.Value.nominal())
    let _referencePeriodEnd                        = cell (fun () -> _CmsCoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = cell (fun () -> _CmsCoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = cell (fun () -> _CmsCoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = cell (fun () -> _CmsCoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = cell (fun () -> _CmsCoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = cell (fun () -> _CmsCoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = cell (fun () -> _CmsCoupon.Value.accept(v.Value)
                                                                     _CmsCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _CmsCoupon.Value.registerWith(handler.Value)
                                                                     _CmsCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _CmsCoupon.Value.unregisterWith(handler.Value)
                                                                     _CmsCoupon.Value)
    do this.Bind(_CmsCoupon)

(* 
    Externally visible/bindable properties
*)
    member this.nominal                            = _nominal 
    member this.paymentDate                        = _paymentDate 
    member this.startDate                          = _startDate 
    member this.endDate                            = _endDate 
    member this.fixingDays                         = _fixingDays 
    member this.swapIndex                          = _swapIndex 
    member this.gearing                            = _gearing 
    member this.spread                             = _spread 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.dayCounter                         = _dayCounter 
    member this.isInArrears                        = _isInArrears 
    member this.Factory                            nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears   
                                                   = _factory nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears 
    member this.SwapIndex                          = _swapIndex
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Gearing                            = _gearing
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.IsInArrears                        = _isInArrears
    member this.Price                              yts   
                                                   = _price yts 
    member this.Pricer                             = _pricer
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
    member this.Spread                             = _spread
    member this.Update                             = _update
    member this.AccrualDays                        = _accrualDays
    member this.AccrualEndDate                     = _accrualEndDate
    member this.AccrualPeriod                      = _accrualPeriod
    member this.AccrualStartDate                   = _accrualStartDate
    member this.AccruedDays                        d   
                                                   = _accruedDays d 
    member this.AccruedPeriod                      d   
                                                   = _accruedPeriod d 
    member this.Date                               = _date
    member this.ExCouponDate                       = _exCouponDate
    member this.Nominal                            = _nominal
    member this.ReferencePeriodEnd                 = _referencePeriodEnd
    member this.ReferencePeriodStart               = _referencePeriodStart
    member this.CompareTo                          cf   
                                                   = _CompareTo cf 
    member this.Equals                             cf   
                                                   = _Equals cf 
    member this.HasOccurred                        refDate includeRefDate   
                                                   = _hasOccurred refDate includeRefDate 
    member this.TradingExCoupon                    refDate   
                                                   = _tradingExCoupon refDate 
    member this.Accept                             v   
                                                   = _accept v 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 