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
  Unit Displaced Black-formula inflation cap/floor engine (standalone, i.e. no coupon pricer)

  </summary> *)
[<AutoSerializable(true)>]
type YoYInflationUnitDisplacedBlackCapFloorEngineModel
    ( index                                        : ICell<YoYInflationIndex>
    , vol                                          : ICell<Handle<YoYOptionletVolatilitySurface>>
    ) as this =

    inherit Model<YoYInflationUnitDisplacedBlackCapFloorEngine> ()
(*
    Parameters
*)
    let _index                                     = index
    let _vol                                       = vol
(*
    Functions
*)
    let _YoYInflationUnitDisplacedBlackCapFloorEngine = cell (fun () -> new YoYInflationUnitDisplacedBlackCapFloorEngine (index.Value, vol.Value))
    let _calculate                                 = cell (fun () -> _YoYInflationUnitDisplacedBlackCapFloorEngine.Value.calculate()
                                                                     _YoYInflationUnitDisplacedBlackCapFloorEngine.Value)
    let _index                                     = cell (fun () -> _YoYInflationUnitDisplacedBlackCapFloorEngine.Value.index())
    let _setVolatility                             (vol : ICell<Handle<YoYOptionletVolatilitySurface>>)   
                                                   = cell (fun () -> _YoYInflationUnitDisplacedBlackCapFloorEngine.Value.setVolatility(vol.Value)
                                                                     _YoYInflationUnitDisplacedBlackCapFloorEngine.Value)
    let _volatility                                = cell (fun () -> _YoYInflationUnitDisplacedBlackCapFloorEngine.Value.volatility())
    do this.Bind(_YoYInflationUnitDisplacedBlackCapFloorEngine)

(* 
    Externally visible/bindable properties
*)
    member this.index                              = _index 
    member this.vol                                = _vol 
    member this.Calculate                          = _calculate
    member this.Index                              = _index
    member this.SetVolatility                      vol   
                                                   = _setVolatility vol 
    member this.Volatility                         = _volatility