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
  8-months %EUR %Libor index
  </summary> *)
[<AutoSerializable(true)>]
module EURLibor8MFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor8M1", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.EURLibor8M1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor8M>) l

                let source = Helper.sourceFold "Fun.EURLibor8M1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor8M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor8M", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.EURLibor8M
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor8M>) l

                let source = Helper.sourceFold "Fun.EURLibor8M" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor8M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor8M_maturityDate", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".MaturityDate") 
                                               [| _EURLibor8M.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
        Date calculations  See <https://www.theice.com/marketdata/reports/170>.
    *)
    [<ExcelFunction(Name="_EURLibor8M_valueDate", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".ValueDate") 
                                               [| _EURLibor8M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_EURLibor8M_businessDayConvention", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".BusinessDayConvention") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_clone", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EURLibor8M.source + ".Clone") 
                                               [| _EURLibor8M.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor8M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor8M_endOfMonth", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".EndOfMonth") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_forecastFixing1", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".ForecastFixing1") 
                                               [| _EURLibor8M.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_forecastFixing", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".ForecastFixing") 
                                               [| _EURLibor8M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_forwardingTermStructure", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EURLibor8M.source + ".ForwardingTermStructure") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor8M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor8M_currency", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EURLibor8M.source + ".Currency") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor8M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor8M_dayCounter", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EURLibor8M.source + ".DayCounter") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor8M> format
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
    [<ExcelFunction(Name="_EURLibor8M_familyName", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".FamilyName") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_fixing", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".Fixing") 
                                               [| _EURLibor8M.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_fixingCalendar", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EURLibor8M.source + ".FixingCalendar") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor8M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor8M_fixingDate", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".FixingDate") 
                                               [| _EURLibor8M.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_fixingDays", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".FixingDays") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_isValidFixingDate", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".IsValidFixingDate") 
                                               [| _EURLibor8M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_name", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".Name") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_pastFixing", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".PastFixing") 
                                               [| _EURLibor8M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_tenor", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EURLibor8M.source + ".Tenor") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor8M> format
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
    [<ExcelFunction(Name="_EURLibor8M_update", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).Update
                                                       ) :> ICell
                let format (o : EURLibor8M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".Update") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_addFixing", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor8M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".AddFixing") 
                                               [| _EURLibor8M.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_addFixings", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor8M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".AddFixings") 
                                               [| _EURLibor8M.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_addFixings1", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor8M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".AddFixings1") 
                                               [| _EURLibor8M.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_allowsNativeFixings", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".AllowsNativeFixings") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_clearFixings", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).ClearFixings
                                                       ) :> ICell
                let format (o : EURLibor8M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".ClearFixings") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_registerWith", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor8M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".RegisterWith") 
                                               [| _EURLibor8M.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_timeSeries", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".TimeSeries") 
                                               [| _EURLibor8M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_unregisterWith", Description="Create a EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor8M",Description = "Reference to EURLibor8M")>] 
         eurlibor8m : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor8M = Helper.toCell<EURLibor8M> eurlibor8m "EURLibor8M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((EURLibor8MModel.Cast _EURLibor8M.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor8M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor8M.source + ".UnregisterWith") 
                                               [| _EURLibor8M.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor8M.cell
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
    [<ExcelFunction(Name="_EURLibor8M_Range", Description="Create a range of EURLibor8M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor8M_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EURLibor8M")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EURLibor8M> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EURLibor8M>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EURLibor8M>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EURLibor8M>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
