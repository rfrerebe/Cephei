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
  The main reason we can't use FloatingRateCouponPricer as the base is that it takes a FloatingRateCoupon which takes an InterestRateIndex and we need an inflation index (these are lagged).  The basic inflation-specific thing that the pricer has to do is deal with different lags in the index and the option e.g. the option could look 3 months back and the index 2.  We add the requirement that pricers do inverseCap/Floor-lets. These are cap/floor-lets as usually defined, i.e. pay out if underlying is above/below a strike.  The non-inverse (usual) versions are from a coupon point of view (a capped coupon has a maximum at the strike).  We add the inverse prices so that conventional caps can be priced simply.
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type InflationCouponPricerModel
    () as this =
    inherit Model<InflationCouponPricer> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _InflationCouponPricer                     = cell (fun () -> new InflationCouponPricer ())
    let _capletPrice                               (effectiveCap : ICell<double>)   
                                                   = cell (fun () -> _InflationCouponPricer.Value.capletPrice(effectiveCap.Value))
    let _capletRate                                (effectiveCap : ICell<double>)   
                                                   = cell (fun () -> _InflationCouponPricer.Value.capletRate(effectiveCap.Value))
    let _floorletPrice                             (effectiveFloor : ICell<double>)   
                                                   = cell (fun () -> _InflationCouponPricer.Value.floorletPrice(effectiveFloor.Value))
    let _floorletRate                              (effectiveFloor : ICell<double>)   
                                                   = cell (fun () -> _InflationCouponPricer.Value.floorletRate(effectiveFloor.Value))
    let _initialize                                (i : ICell<InflationCoupon>)   
                                                   = cell (fun () -> _InflationCouponPricer.Value.initialize(i.Value)
                                                                     _InflationCouponPricer.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _InflationCouponPricer.Value.registerWith(handler.Value)
                                                                     _InflationCouponPricer.Value)
    let _swapletPrice                              = cell (fun () -> _InflationCouponPricer.Value.swapletPrice())
    let _swapletRate                               = cell (fun () -> _InflationCouponPricer.Value.swapletRate())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _InflationCouponPricer.Value.unregisterWith(handler.Value)
                                                                     _InflationCouponPricer.Value)
    let _update                                    = cell (fun () -> _InflationCouponPricer.Value.update()
                                                                     _InflationCouponPricer.Value)
    do this.Bind(_InflationCouponPricer)

(* 
    Externally visible/bindable properties
*)
    member this.CapletPrice                        effectiveCap   
                                                   = _capletPrice effectiveCap 
    member this.CapletRate                         effectiveCap   
                                                   = _capletRate effectiveCap 
    member this.FloorletPrice                      effectiveFloor   
                                                   = _floorletPrice effectiveFloor 
    member this.FloorletRate                       effectiveFloor   
                                                   = _floorletRate effectiveFloor 
    member this.Initialize                         i   
                                                   = _initialize i 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.SwapletPrice                       = _swapletPrice
    member this.SwapletRate                        = _swapletRate
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update