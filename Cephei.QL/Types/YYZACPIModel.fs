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
  Genuine year-on-year South African CPI (i.e. not a ratio of South African CPI)

  </summary> *)
[<AutoSerializable(true)>]
type YYZACPIModel
    ( interpolated                                 : ICell<bool>
    , ts                                           : ICell<Handle<YoYInflationTermStructure>>
    ) as this =

    inherit Model<YYZACPI> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
    let _ts                                        = ts
(*
    Functions
*)
    let _YYZACPI                                   = cell (fun () -> new YYZACPI (interpolated.Value, ts.Value))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = cell (fun () -> _YYZACPI.Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = cell (fun () -> _YYZACPI.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = cell (fun () -> _YYZACPI.Value.ratio())
    let _yoyInflationTermStructure                 = cell (fun () -> _YYZACPI.Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _YYZACPI.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                     _YYZACPI.Value)
    let _availabilityLag                           = cell (fun () -> _YYZACPI.Value.availabilityLag())
    let _currency                                  = cell (fun () -> _YYZACPI.Value.currency())
    let _familyName                                = cell (fun () -> _YYZACPI.Value.familyName())
    let _fixingCalendar                            = cell (fun () -> _YYZACPI.Value.fixingCalendar())
    let _frequency                                 = cell (fun () -> _YYZACPI.Value.frequency())
    let _interpolated                              = cell (fun () -> _YYZACPI.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _YYZACPI.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = cell (fun () -> _YYZACPI.Value.name())
    let _region                                    = cell (fun () -> _YYZACPI.Value.region())
    let _revised                                   = cell (fun () -> _YYZACPI.Value.revised())
    let _update                                    = cell (fun () -> _YYZACPI.Value.update()
                                                                     _YYZACPI.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _YYZACPI.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _YYZACPI.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _YYZACPI.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _YYZACPI.Value)
    let _allowsNativeFixings                       = cell (fun () -> _YYZACPI.Value.allowsNativeFixings())
    let _clearFixings                              = cell (fun () -> _YYZACPI.Value.clearFixings()
                                                                     _YYZACPI.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _YYZACPI.Value.registerWith(handler.Value)
                                                                     _YYZACPI.Value)
    let _timeSeries                                = cell (fun () -> _YYZACPI.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _YYZACPI.Value.unregisterWith(handler.Value)
                                                                     _YYZACPI.Value)
    do this.Bind(_YYZACPI)

(* 
    Externally visible/bindable properties
*)
    member this.interpolated                       = _interpolated 
    member this.ts                                 = _ts 
    member this.Clone                              h   
                                                   = _clone h 
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.Ratio                              = _ratio
    member this.YoyInflationTermStructure          = _yoyInflationTermStructure
    member this.AddFixing                          fixingDate fixing forceOverwrite   
                                                   = _addFixing fixingDate fixing forceOverwrite 
    member this.AvailabilityLag                    = _availabilityLag
    member this.Currency                           = _currency
    member this.FamilyName                         = _familyName
    member this.FixingCalendar                     = _fixingCalendar
    member this.Frequency                          = _frequency
    member this.Interpolated                       = _interpolated
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.Region                             = _region
    member this.Revised                            = _revised
    member this.Update                             = _update
    member this.AddFixings                         d v forceOverwrite   
                                                   = _addFixings d v forceOverwrite 
    member this.AddFixings1                        source forceOverwrite   
                                                   = _addFixings1 source forceOverwrite 
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  Genuine year-on-year South African CPI (i.e. not a ratio of South African CPI)

  </summary> *)
[<AutoSerializable(true)>]
type YYZACPIModel1
    ( interpolated                                 : ICell<bool>
    ) as this =

    inherit Model<YYZACPI> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
(*
    Functions
*)
    let _YYZACPI                                   = cell (fun () -> new YYZACPI (interpolated.Value))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = cell (fun () -> _YYZACPI.Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = cell (fun () -> _YYZACPI.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = cell (fun () -> _YYZACPI.Value.ratio())
    let _yoyInflationTermStructure                 = cell (fun () -> _YYZACPI.Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _YYZACPI.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                     _YYZACPI.Value)
    let _availabilityLag                           = cell (fun () -> _YYZACPI.Value.availabilityLag())
    let _currency                                  = cell (fun () -> _YYZACPI.Value.currency())
    let _familyName                                = cell (fun () -> _YYZACPI.Value.familyName())
    let _fixingCalendar                            = cell (fun () -> _YYZACPI.Value.fixingCalendar())
    let _frequency                                 = cell (fun () -> _YYZACPI.Value.frequency())
    let _interpolated                              = cell (fun () -> _YYZACPI.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _YYZACPI.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = cell (fun () -> _YYZACPI.Value.name())
    let _region                                    = cell (fun () -> _YYZACPI.Value.region())
    let _revised                                   = cell (fun () -> _YYZACPI.Value.revised())
    let _update                                    = cell (fun () -> _YYZACPI.Value.update()
                                                                     _YYZACPI.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _YYZACPI.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _YYZACPI.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _YYZACPI.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _YYZACPI.Value)
    let _allowsNativeFixings                       = cell (fun () -> _YYZACPI.Value.allowsNativeFixings())
    let _clearFixings                              = cell (fun () -> _YYZACPI.Value.clearFixings()
                                                                     _YYZACPI.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _YYZACPI.Value.registerWith(handler.Value)
                                                                     _YYZACPI.Value)
    let _timeSeries                                = cell (fun () -> _YYZACPI.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _YYZACPI.Value.unregisterWith(handler.Value)
                                                                     _YYZACPI.Value)
    do this.Bind(_YYZACPI)

(* 
    Externally visible/bindable properties
*)
    member this.interpolated                       = _interpolated 
    member this.Clone                              h   
                                                   = _clone h 
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.Ratio                              = _ratio
    member this.YoyInflationTermStructure          = _yoyInflationTermStructure
    member this.AddFixing                          fixingDate fixing forceOverwrite   
                                                   = _addFixing fixingDate fixing forceOverwrite 
    member this.AvailabilityLag                    = _availabilityLag
    member this.Currency                           = _currency
    member this.FamilyName                         = _familyName
    member this.FixingCalendar                     = _fixingCalendar
    member this.Frequency                          = _frequency
    member this.Interpolated                       = _interpolated
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.Region                             = _region
    member this.Revised                            = _revised
    member this.Update                             = _update
    member this.AddFixings                         d v forceOverwrite   
                                                   = _addFixings d v forceOverwrite 
    member this.AddFixings1                        source forceOverwrite   
                                                   = _addFixings1 source forceOverwrite 
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 