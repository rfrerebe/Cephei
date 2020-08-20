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
type VannaVolgaBarrierEngineModel
    ( atmVol                                       : ICell<Handle<DeltaVolQuote>>
    , vol25Put                                     : ICell<Handle<DeltaVolQuote>>
    , vol25Call                                    : ICell<Handle<DeltaVolQuote>>
    , spotFX                                       : ICell<Handle<Quote>>
    , domesticTS                                   : ICell<Handle<YieldTermStructure>>
    , foreignTS                                    : ICell<Handle<YieldTermStructure>>
    , adaptVanDelta                                : ICell<bool>
    , bsPriceWithSmile                             : ICell<double>
    ) as this =

    inherit Model<VannaVolgaBarrierEngine> ()
(*
    Parameters
*)
    let _atmVol                                    = atmVol
    let _vol25Put                                  = vol25Put
    let _vol25Call                                 = vol25Call
    let _spotFX                                    = spotFX
    let _domesticTS                                = domesticTS
    let _foreignTS                                 = foreignTS
    let _adaptVanDelta                             = adaptVanDelta
    let _bsPriceWithSmile                          = bsPriceWithSmile
(*
    Functions
*)
    let _VannaVolgaBarrierEngine                   = cell (fun () -> new VannaVolgaBarrierEngine (atmVol.Value, vol25Put.Value, vol25Call.Value, spotFX.Value, domesticTS.Value, foreignTS.Value, adaptVanDelta.Value, bsPriceWithSmile.Value))
    let _calculate                                 = cell (fun () -> _VannaVolgaBarrierEngine.Value.calculate()
                                                                     _VannaVolgaBarrierEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _VannaVolgaBarrierEngine.Value.registerWith(handler.Value)
                                                                     _VannaVolgaBarrierEngine.Value)
    let _reset                                     = cell (fun () -> _VannaVolgaBarrierEngine.Value.reset()
                                                                     _VannaVolgaBarrierEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _VannaVolgaBarrierEngine.Value.unregisterWith(handler.Value)
                                                                     _VannaVolgaBarrierEngine.Value)
    let _update                                    = cell (fun () -> _VannaVolgaBarrierEngine.Value.update()
                                                                     _VannaVolgaBarrierEngine.Value)
    do this.Bind(_VannaVolgaBarrierEngine)

(* 
    Externally visible/bindable properties
*)
    member this.atmVol                             = _atmVol 
    member this.vol25Put                           = _vol25Put 
    member this.vol25Call                          = _vol25Call 
    member this.spotFX                             = _spotFX 
    member this.domesticTS                         = _domesticTS 
    member this.foreignTS                          = _foreignTS 
    member this.adaptVanDelta                      = _adaptVanDelta 
    member this.bsPriceWithSmile                   = _bsPriceWithSmile 
    member this.Calculate                          = _calculate
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update