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
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>
  Fake year-on-year AUCPI (i.e. a ratio)
  </summary> *)
[<AutoSerializable(true)>]
module YYAUCPIrFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPIr", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="revised",Description = "Reference to revised")>] 
         revised : obj)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _revised = Helper.toCell<bool> revised "revised" true
                let _interpolated = Helper.toCell<bool> interpolated "interpolated" true
                let builder () = withMnemonic mnemonic (Fun.YYAUCPIr 
                                                            _frequency.cell 
                                                            _revised.cell 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYAUCPIr>) l

                let source = Helper.sourceFold "Fun.YYAUCPIr" 
                                               [| _frequency.source
                                               ;  _revised.source
                                               ;  _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _frequency.cell
                                ;  _revised.cell
                                ;  _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPIr1", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="revised",Description = "Reference to revised")>] 
         revised : obj)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        ([<ExcelArgument(Name="ts",Description = "Reference to ts")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _revised = Helper.toCell<bool> revised "revised" true
                let _interpolated = Helper.toCell<bool> interpolated "interpolated" true
                let _ts = Helper.toHandle<YoYInflationTermStructure> ts "ts" 
                let builder () = withMnemonic mnemonic (Fun.YYAUCPIr1 
                                                            _frequency.cell 
                                                            _revised.cell 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYAUCPIr>) l

                let source = Helper.sourceFold "Fun.YYAUCPIr1" 
                                               [| _frequency.source
                                               ;  _revised.source
                                               ;  _interpolated.source
                                               ;  _ts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _frequency.cell
                                ;  _revised.cell
                                ;  _interpolated.cell
                                ;  _ts.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPIr_clone", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_YYAUCPIr.source + ".Clone") 
                                               [| _YYAUCPIr.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Index interface The forecastTodaysFixing parameter (required by the Index interface) is currently ignored.
    *)
    [<ExcelFunction(Name="_YYAUCPIr_fixing", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".Fixing") 
                                               [| _YYAUCPIr.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Other methods
    *)
    [<ExcelFunction(Name="_YYAUCPIr_ratio", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".Ratio") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPIr_yoyInflationTermStructure", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source = Helper.sourceFold (_YYAUCPIr.source + ".YoyInflationTermStructure") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! this method creates all the "fixings" for the relevant period of the index.  E.g. for monthly indices it will put the same value in every calendar day in the month.
    *)
    [<ExcelFunction(Name="_YYAUCPIr_addFixing", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _fixing = Helper.toCell<double> fixing "fixing" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYAUCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".AddFixing") 
                                               [| _YYAUCPIr.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                ;  _fixingDate.cell
                                ;  _fixing.cell
                                ;  _forceOverwrite.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The availability lag describes when the index is
<i>available</i>, not how it is used.  Specifically the fixing for, say, January, may only be available in April but the index will always return the index value applicable for January as its January fixing (independent of the lag in availability).
    *)
    [<ExcelFunction(Name="_YYAUCPIr_availabilityLag", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_YYAUCPIr.source + ".AvailabilityLag") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPIr_currency", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_YYAUCPIr.source + ".Currency") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_YYAUCPIr_familyName", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".FamilyName") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Inflation indices do not have fixing calendars.  An inflation index value is valid for every day (including weekends) of a calendar period.  I.e. it uses the NullCalendar as its fixing calendar.
    *)
    [<ExcelFunction(Name="_YYAUCPIr_fixingCalendar", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_YYAUCPIr.source + ".FixingCalendar") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPIr_frequency", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".Frequency") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Forecasting index values using an inflation term structure uses the interpolation of the inflation term structure unless interpolation is set to false.  In this case the extrapolated values are constant within each period taking the mid-period extrapolated value.
    *)
    [<ExcelFunction(Name="_YYAUCPIr_interpolated", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".Interpolated") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPIr_isValidFixingDate", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".IsValidFixingDate") 
                                               [| _YYAUCPIr.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Index interface
    *)
    [<ExcelFunction(Name="_YYAUCPIr_name", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".Name") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPIr_region", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source = Helper.sourceFold (_YYAUCPIr.source + ".Region") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPIr_revised", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".Revised") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Observer interface
    *)
    [<ExcelFunction(Name="_YYAUCPIr_update", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).Update
                                                       ) :> ICell
                let format (o : YYAUCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".Update") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_YYAUCPIr_addFixings", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYAUCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".AddFixings") 
                                               [| _YYAUCPIr.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_YYAUCPIr_addFixings1", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYAUCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".AddFixings1") 
                                               [| _YYAUCPIr.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_YYAUCPIr_allowsNativeFixings", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".AllowsNativeFixings") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_YYAUCPIr_clearFixings", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).ClearFixings
                                                       ) :> ICell
                let format (o : YYAUCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".ClearFixings") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPIr_registerWith", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYAUCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".RegisterWith") 
                                               [| _YYAUCPIr.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                ;  _handler.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_YYAUCPIr_timeSeries", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".TimeSeries") 
                                               [| _YYAUCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPIr_unregisterWith", Description="Create a YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPIr",Description = "Reference to YYAUCPIr")>] 
         yyaucpir : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPIr = Helper.toCell<YYAUCPIr> yyaucpir "YYAUCPIr" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_YYAUCPIr.cell :?> YYAUCPIrModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYAUCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPIr.source + ".UnregisterWith") 
                                               [| _YYAUCPIr.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPIr.cell
                                ;  _handler.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_YYAUCPIr_Range", Description="Create a range of YYAUCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPIr_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YYAUCPIr")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYAUCPIr> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YYAUCPIr>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YYAUCPIr>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YYAUCPIr>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"