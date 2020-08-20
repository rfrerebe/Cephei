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
  US CPI index

  </summary> *)
[<AutoSerializable(true)>]
type USCPIModel
    ( interpolated                                 : ICell<bool>
    ) as this =

    inherit Model<USCPI> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
(*
    Functions
*)
    let _USCPI                                     = cell (fun () -> new USCPI (interpolated.Value))
    let _clone                                     (h : ICell<Handle<ZeroInflationTermStructure>>)   
                                                   = cell (fun () -> _USCPI.Value.clone(h.Value))
    let _fixing                                    (aFixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = cell (fun () -> _USCPI.Value.fixing(aFixingDate.Value, forecastTodaysFixing.Value))
    let _zeroInflationTermStructure                = cell (fun () -> _USCPI.Value.zeroInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _USCPI.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                     _USCPI.Value)
    let _availabilityLag                           = cell (fun () -> _USCPI.Value.availabilityLag())
    let _currency                                  = cell (fun () -> _USCPI.Value.currency())
    let _familyName                                = cell (fun () -> _USCPI.Value.familyName())
    let _fixingCalendar                            = cell (fun () -> _USCPI.Value.fixingCalendar())
    let _frequency                                 = cell (fun () -> _USCPI.Value.frequency())
    let _interpolated                              = cell (fun () -> _USCPI.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _USCPI.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = cell (fun () -> _USCPI.Value.name())
    let _region                                    = cell (fun () -> _USCPI.Value.region())
    let _revised                                   = cell (fun () -> _USCPI.Value.revised())
    let _update                                    = cell (fun () -> _USCPI.Value.update()
                                                                     _USCPI.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _USCPI.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _USCPI.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _USCPI.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _USCPI.Value)
    let _allowsNativeFixings                       = cell (fun () -> _USCPI.Value.allowsNativeFixings())
    let _clearFixings                              = cell (fun () -> _USCPI.Value.clearFixings()
                                                                     _USCPI.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _USCPI.Value.registerWith(handler.Value)
                                                                     _USCPI.Value)
    let _timeSeries                                = cell (fun () -> _USCPI.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _USCPI.Value.unregisterWith(handler.Value)
                                                                     _USCPI.Value)
    do this.Bind(_USCPI)

(* 
    Externally visible/bindable properties
*)
    member this.interpolated                       = _interpolated 
    member this.Clone                              h   
                                                   = _clone h 
    member this.Fixing                             aFixingDate forecastTodaysFixing   
                                                   = _fixing aFixingDate forecastTodaysFixing 
    member this.ZeroInflationTermStructure         = _zeroInflationTermStructure
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
  US CPI index

  </summary> *)
[<AutoSerializable(true)>]
type USCPIModel1
    ( interpolated                                 : ICell<bool>
    , ts                                           : ICell<Handle<ZeroInflationTermStructure>>
    ) as this =

    inherit Model<USCPI> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
    let _ts                                        = ts
(*
    Functions
*)
    let _USCPI                                     = cell (fun () -> new USCPI (interpolated.Value, ts.Value))
    let _clone                                     (h : ICell<Handle<ZeroInflationTermStructure>>)   
                                                   = cell (fun () -> _USCPI.Value.clone(h.Value))
    let _fixing                                    (aFixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = cell (fun () -> _USCPI.Value.fixing(aFixingDate.Value, forecastTodaysFixing.Value))
    let _zeroInflationTermStructure                = cell (fun () -> _USCPI.Value.zeroInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _USCPI.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                     _USCPI.Value)
    let _availabilityLag                           = cell (fun () -> _USCPI.Value.availabilityLag())
    let _currency                                  = cell (fun () -> _USCPI.Value.currency())
    let _familyName                                = cell (fun () -> _USCPI.Value.familyName())
    let _fixingCalendar                            = cell (fun () -> _USCPI.Value.fixingCalendar())
    let _frequency                                 = cell (fun () -> _USCPI.Value.frequency())
    let _interpolated                              = cell (fun () -> _USCPI.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _USCPI.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = cell (fun () -> _USCPI.Value.name())
    let _region                                    = cell (fun () -> _USCPI.Value.region())
    let _revised                                   = cell (fun () -> _USCPI.Value.revised())
    let _update                                    = cell (fun () -> _USCPI.Value.update()
                                                                     _USCPI.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _USCPI.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _USCPI.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _USCPI.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _USCPI.Value)
    let _allowsNativeFixings                       = cell (fun () -> _USCPI.Value.allowsNativeFixings())
    let _clearFixings                              = cell (fun () -> _USCPI.Value.clearFixings()
                                                                     _USCPI.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _USCPI.Value.registerWith(handler.Value)
                                                                     _USCPI.Value)
    let _timeSeries                                = cell (fun () -> _USCPI.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _USCPI.Value.unregisterWith(handler.Value)
                                                                     _USCPI.Value)
    do this.Bind(_USCPI)

(* 
    Externally visible/bindable properties
*)
    member this.interpolated                       = _interpolated 
    member this.ts                                 = _ts 
    member this.Clone                              h   
                                                   = _clone h 
    member this.Fixing                             aFixingDate forecastTodaysFixing   
                                                   = _fixing aFixingDate forecastTodaysFixing 
    member this.ZeroInflationTermStructure         = _zeroInflationTermStructure
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