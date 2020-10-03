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
Rate helper for bootstrapping over deposit rates
  </summary> *)
[<AutoSerializable(true)>]
module DepositRateHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DepositRateHelper", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toHandle<Quote> rate "rate" 
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder () = withMnemonic mnemonic (Fun.DepositRateHelper 
                                                            _rate.cell 
                                                            _tenor.cell 
                                                            _fixingDays.cell 
                                                            _calendar.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DepositRateHelper>) l

                let source = Helper.sourceFold "Fun.DepositRateHelper" 
                                               [| _rate.source
                                               ;  _tenor.source
                                               ;  _fixingDays.source
                                               ;  _calendar.source
                                               ;  _convention.source
                                               ;  _endOfMonth.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _tenor.cell
                                ;  _fixingDays.cell
                                ;  _calendar.cell
                                ;  _convention.cell
                                ;  _endOfMonth.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DepositRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DepositRateHelper1", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" 
                let _i = Helper.toCell<IborIndex> i "i" 
                let builder () = withMnemonic mnemonic (Fun.DepositRateHelper1 
                                                            _rate.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DepositRateHelper>) l

                let source = Helper.sourceFold "Fun.DepositRateHelper1" 
                                               [| _rate.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DepositRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DepositRateHelper2", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toHandle<Quote> rate "rate" 
                let _i = Helper.toCell<IborIndex> i "i" 
                let builder () = withMnemonic mnemonic (Fun.DepositRateHelper2 
                                                            _rate.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DepositRateHelper>) l

                let source = Helper.sourceFold "Fun.DepositRateHelper2" 
                                               [| _rate.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DepositRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DepositRateHelper3", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" 
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder () = withMnemonic mnemonic (Fun.DepositRateHelper3 
                                                            _rate.cell 
                                                            _tenor.cell 
                                                            _fixingDays.cell 
                                                            _calendar.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DepositRateHelper>) l

                let source = Helper.sourceFold "Fun.DepositRateHelper3" 
                                               [| _rate.source
                                               ;  _tenor.source
                                               ;  _fixingDays.source
                                               ;  _calendar.source
                                               ;  _convention.source
                                               ;  _endOfMonth.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _tenor.cell
                                ;  _fixingDays.cell
                                ;  _calendar.cell
                                ;  _convention.cell
                                ;  _endOfMonth.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DepositRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! RateHelper interface
    *)
    [<ExcelFunction(Name="_DepositRateHelper_impliedQuote", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".ImpliedQuote") 
                                               [| _DepositRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
    [<ExcelFunction(Name="_DepositRateHelper_setTermStructure", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let _t = Helper.toCell<YieldTermStructure> t "t" 
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DepositRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".SetTermStructure") 
                                               [| _DepositRateHelper.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
        ! Observer interface
    *)
    [<ExcelFunction(Name="_DepositRateHelper_update", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).Update
                                                       ) :> ICell
                let format (o : DepositRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".Update") 
                                               [| _DepositRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
        earliest relevant date The earliest date at which discounts are needed by the helper in order to provide a quote.
    *)
    [<ExcelFunction(Name="_DepositRateHelper_earliestDate", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".EarliestDate") 
                                               [| _DepositRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
        The latest date at which discounts are needed by the helper in order to provide a quote. It does not necessarily equal the maturity of the underlying instrument.
    *)
    [<ExcelFunction(Name="_DepositRateHelper_latestDate", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".LatestDate") 
                                               [| _DepositRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
        ! The latest date at which data are needed by the helper in order to provide a quote. It does not necessarily equal the maturity of the underlying instrument.
    *)
    [<ExcelFunction(Name="_DepositRateHelper_latestRelevantDate", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".LatestRelevantDate") 
                                               [| _DepositRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
        ! instrument's maturity date
    *)
    [<ExcelFunction(Name="_DepositRateHelper_maturityDate", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".MaturityDate") 
                                               [| _DepositRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
        ! pillar date
    *)
    [<ExcelFunction(Name="_DepositRateHelper_pillarDate", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".PillarDate") 
                                               [| _DepositRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
        ! BootstrapHelper interface
    *)
    [<ExcelFunction(Name="_DepositRateHelper_quote", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_DepositRateHelper.source + ".Quote") 
                                               [| _DepositRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DepositRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DepositRateHelper_quoteError", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".QuoteError") 
                                               [| _DepositRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
    [<ExcelFunction(Name="_DepositRateHelper_quoteIsValid", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".QuoteIsValid") 
                                               [| _DepositRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
    [<ExcelFunction(Name="_DepositRateHelper_quoteValue", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".QuoteValue") 
                                               [| _DepositRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
    [<ExcelFunction(Name="_DepositRateHelper_registerWith", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DepositRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".RegisterWith") 
                                               [| _DepositRateHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
        
    *)
    [<ExcelFunction(Name="_DepositRateHelper_unregisterWith", Description="Create a DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DepositRateHelper",Description = "Reference to DepositRateHelper")>] 
         depositratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DepositRateHelper = Helper.toCell<DepositRateHelper> depositratehelper "DepositRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((DepositRateHelperModel.Cast _DepositRateHelper.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DepositRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DepositRateHelper.source + ".UnregisterWith") 
                                               [| _DepositRateHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DepositRateHelper.cell
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
    [<ExcelFunction(Name="_DepositRateHelper_Range", Description="Create a range of DepositRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DepositRateHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DepositRateHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DepositRateHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DepositRateHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DepositRateHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DepositRateHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
