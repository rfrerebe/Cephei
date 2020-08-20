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
type MoneyModel
    () as this =
    inherit Model<Money> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Money                                     = cell (fun () -> new Money ())
    let _currency                                  = cell (fun () -> _Money.Value.currency)
    let _Equals                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _Money.Value.Equals(o.Value))
    let _rounded                                   = cell (fun () -> _Money.Value.rounded())
    let _ToString                                  = cell (fun () -> _Money.Value.ToString())
    let _value                                     = cell (fun () -> _Money.Value.value)
    do this.Bind(_Money)

(* 
    Externally visible/bindable properties
*)
    member this.Currency                           = _currency
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Rounded                            = _rounded
    member this.ToString                           = _ToString
    member this.Value                              = _value
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type MoneyModel1
    ( currency                                     : ICell<Currency>
    , value                                        : ICell<double>
    ) as this =

    inherit Model<Money> ()
(*
    Parameters
*)
    let _currency                                  = currency
    let _value                                     = value
(*
    Functions
*)
    let _Money                                     = cell (fun () -> new Money (currency.Value, value.Value))
    let _currency                                  = cell (fun () -> _Money.Value.currency)
    let _Equals                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _Money.Value.Equals(o.Value))
    let _rounded                                   = cell (fun () -> _Money.Value.rounded())
    let _ToString                                  = cell (fun () -> _Money.Value.ToString())
    let _value                                     = cell (fun () -> _Money.Value.value)
    do this.Bind(_Money)

(* 
    Externally visible/bindable properties
*)
    member this.currency                           = _currency 
    member this.value                              = _value 
    member this.Currency                           = _currency
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Rounded                            = _rounded
    member this.ToString                           = _ToString
    member this.Value                              = _value
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type MoneyModel2
    ( value                                        : ICell<double>
    , currency                                     : ICell<Currency>
    ) as this =

    inherit Model<Money> ()
(*
    Parameters
*)
    let _value                                     = value
    let _currency                                  = currency
(*
    Functions
*)
    let _Money                                     = cell (fun () -> new Money (value.Value, currency.Value))
    let _currency                                  = cell (fun () -> _Money.Value.currency)
    let _Equals                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _Money.Value.Equals(o.Value))
    let _rounded                                   = cell (fun () -> _Money.Value.rounded())
    let _ToString                                  = cell (fun () -> _Money.Value.ToString())
    let _value                                     = cell (fun () -> _Money.Value.value)
    do this.Bind(_Money)

(* 
    Externally visible/bindable properties
*)
    member this.value                              = _value 
    member this.currency                           = _currency 
    member this.Currency                           = _currency
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Rounded                            = _rounded
    member this.ToString                           = _ToString
    member this.Value                              = _value