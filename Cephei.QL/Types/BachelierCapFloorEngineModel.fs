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


  </summary> *)
[<AutoSerializable(true)>]
type BachelierCapFloorEngineModel
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , vol                                          : ICell<Handle<OptionletVolatilityStructure>>
    ) as this =

    inherit Model<BachelierCapFloorEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _vol                                       = vol
(*
    Functions
*)
    let _BachelierCapFloorEngine                   = cell (fun () -> new BachelierCapFloorEngine (discountCurve.Value, vol.Value))
    let _calculate                                 = cell (fun () -> _BachelierCapFloorEngine.Value.calculate()
                                                                     _BachelierCapFloorEngine.Value)
    let _termStructure                             = cell (fun () -> _BachelierCapFloorEngine.Value.termStructure())
    let _volatility                                = cell (fun () -> _BachelierCapFloorEngine.Value.volatility())
    do this.Bind(_BachelierCapFloorEngine)

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.vol                                = _vol 
    member this.Calculate                          = _calculate
    member this.TermStructure                      = _termStructure
    member this.Volatility                         = _volatility
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type BachelierCapFloorEngineModel1
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , vol                                          : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<BachelierCapFloorEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _vol                                       = vol
    let _dc                                        = dc
(*
    Functions
*)
    let _BachelierCapFloorEngine                   = cell (fun () -> new BachelierCapFloorEngine (discountCurve.Value, vol.Value, dc.Value))
    let _calculate                                 = cell (fun () -> _BachelierCapFloorEngine.Value.calculate()
                                                                     _BachelierCapFloorEngine.Value)
    let _termStructure                             = cell (fun () -> _BachelierCapFloorEngine.Value.termStructure())
    let _volatility                                = cell (fun () -> _BachelierCapFloorEngine.Value.volatility())
    do this.Bind(_BachelierCapFloorEngine)

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.Calculate                          = _calculate
    member this.TermStructure                      = _termStructure
    member this.Volatility                         = _volatility
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type BachelierCapFloorEngineModel2
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , vol                                          : ICell<double>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<BachelierCapFloorEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _vol                                       = vol
    let _dc                                        = dc
(*
    Functions
*)
    let _BachelierCapFloorEngine                   = cell (fun () -> new BachelierCapFloorEngine (discountCurve.Value, vol.Value, dc.Value))
    let _calculate                                 = cell (fun () -> _BachelierCapFloorEngine.Value.calculate()
                                                                     _BachelierCapFloorEngine.Value)
    let _termStructure                             = cell (fun () -> _BachelierCapFloorEngine.Value.termStructure())
    let _volatility                                = cell (fun () -> _BachelierCapFloorEngine.Value.volatility())
    do this.Bind(_BachelierCapFloorEngine)

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.Calculate                          = _calculate
    member this.TermStructure                      = _termStructure
    member this.Volatility                         = _volatility