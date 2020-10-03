﻿(*
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
  Euro O/N LIBOR fixed by ICE. It can be also used for T/N and S/N indexes, even if such indexes do not have ICE fixing.  See <https://www.theice.com/marketdata/reports/170>.  This is the rate fixed in London by ICE. Use Eonia if you're interested in the fixing by the ECB.
  </summary> *)
[<AutoSerializable(true)>]
module DailyTenorEURLiborFunction =

    (*
        http://www.bba.org.uk/bba/jsp/polopoly.jsp?d=225&a=1412 : no o/n or s/n fixings (as the case may be) will take place when the principal centre of the currency concerned is closed but London is open on the fixing day.
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor2", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let builder () = withMnemonic mnemonic (Fun.DailyTenorEURLibor2 
                                                            _settlementDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorEURLibor>) l

                let source = Helper.sourceFold "Fun.DailyTenorEURLibor2" 
                                               [| _settlementDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorEURLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.DailyTenorEURLibor
                                                            _settlementDays.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorEURLibor>) l

                let source = Helper.sourceFold "Fun.DailyTenorEURLibor" 
                                               [| _settlementDays.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorEURLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor1", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.DailyTenorEURLibor1()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorEURLibor>) l

                let source = Helper.sourceFold "Fun.DailyTenorEURLibor1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorEURLibor> format
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_businessDayConvention", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".BusinessDayConvention") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor_clone", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".Clone") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorEURLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor_endOfMonth", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".EndOfMonth") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_forecastFixing1", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".ForecastFixing1") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_forecastFixing", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".ForecastFixing") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
        the curve used to forecast fixings
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor_forwardingTermStructure", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".ForwardingTermStructure") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorEURLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor_maturityDate", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".MaturityDate") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_currency", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".Currency") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorEURLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor_dayCounter", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".DayCounter") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorEURLibor> format
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_familyName", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".FamilyName") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_fixing", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".Fixing") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
        
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor_fixingCalendar", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".FixingCalendar") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorEURLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor_fixingDate", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".FixingDate") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_fixingDays", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".FixingDays") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_isValidFixingDate", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".IsValidFixingDate") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_name", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".Name") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_pastFixing", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".PastFixing") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
        
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor_tenor", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".Tenor") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorEURLibor> format
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_update", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).Update
                                                       ) :> ICell
                let format (o : DailyTenorEURLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".Update") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor_valueDate", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".ValueDate") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor_addFixing", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorEURLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".AddFixing") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_DailyTenorEURLibor_addFixings", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorEURLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".AddFixings") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_addFixings1", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorEURLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".AddFixings1") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_allowsNativeFixings", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".AllowsNativeFixings") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_clearFixings", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).ClearFixings
                                                       ) :> ICell
                let format (o : DailyTenorEURLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".ClearFixings") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_registerWith", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorEURLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".RegisterWith") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_timeSeries", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".TimeSeries") 
                                               [| _DailyTenorEURLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_unregisterWith", Description="Create a DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorEURLibor",Description = "Reference to DailyTenorEURLibor")>] 
         dailytenoreurlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorEURLibor = Helper.toCell<DailyTenorEURLibor> dailytenoreurlibor "DailyTenorEURLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((DailyTenorEURLiborModel.Cast _DailyTenorEURLibor.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorEURLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorEURLibor.source + ".UnregisterWith") 
                                               [| _DailyTenorEURLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorEURLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorEURLibor_Range", Description="Create a range of DailyTenorEURLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorEURLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DailyTenorEURLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DailyTenorEURLibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DailyTenorEURLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DailyTenorEURLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DailyTenorEURLibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
