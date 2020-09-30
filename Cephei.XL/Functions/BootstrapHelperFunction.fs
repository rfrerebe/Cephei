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
(*!!
(* <summary>
This class provides an abstraction for the instruments used to bootstrap a term structure. It is advised that a bootstrap helper for an instrument contains an instance of the actual instrument class to ensure consistancy between the algorithms used during bootstrapping and later instrument pricing. This is not yet fully enforced in the available rate helpers.
  </summary> *)
[<AutoSerializable(true)>]
module BootstrapHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BootstrapHelper", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="quote",Description = "Reference to quote")>] 
         quote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _quote = Helper.toCell<double> quote "quote" true
                let builder () = withMnemonic mnemonic (Fun.BootstrapHelper 
                                                            _quote.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BootstrapHelper>) l

                let source = Helper.sourceFold "Fun.BootstrapHelper" 
                                               [| _quote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _quote.cell
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
    [<ExcelFunction(Name="_BootstrapHelper1", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.BootstrapHelper1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BootstrapHelper>) l

                let source = Helper.sourceFold "Fun.BootstrapHelper1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
        required for generics
    *)
    [<ExcelFunction(Name="_BootstrapHelper2", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="quote",Description = "Reference to quote")>] 
         quote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _quote = Helper.toHandle<Quote> quote "quote" 
                let builder () = withMnemonic mnemonic (Fun.BootstrapHelper2 
                                                            _quote.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BootstrapHelper>) l

                let source = Helper.sourceFold "Fun.BootstrapHelper2" 
                                               [| _quote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _quote.cell
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
        earliest relevant date The earliest date at which discounts are needed by the helper in order to provide a quote.
    *)
    [<ExcelFunction(Name="_BootstrapHelper_earliestDate", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".EarliestDate") 
                                               [| _BootstrapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_impliedQuote", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".ImpliedQuote") 
                                               [| _BootstrapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_latestDate", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".LatestDate") 
                                               [| _BootstrapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_latestRelevantDate", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".LatestRelevantDate") 
                                               [| _BootstrapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_maturityDate", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".MaturityDate") 
                                               [| _BootstrapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_pillarDate", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".PillarDate") 
                                               [| _BootstrapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_quote", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_BootstrapHelper.source + ".Quote") 
                                               [| _BootstrapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_quoteError", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".QuoteError") 
                                               [| _BootstrapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_quoteIsValid", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".QuoteIsValid") 
                                               [| _BootstrapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_quoteValue", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".QuoteValue") 
                                               [| _BootstrapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_registerWith", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BootstrapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".RegisterWith") 
                                               [| _BootstrapHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
        ! \warning Being a pointer and not a shared_ptr, the term structure is not guaranteed to remain allocated for the whole life of the rate helper. It is responsibility of the programmer to ensure that the pointer remains valid. It is advised that this method is called only inside the term structure being bootstrapped, setting the pointer to <b>this</b>, i.e., the term structure itself.
    *)
    [<ExcelFunction(Name="_BootstrapHelper_setTermStructure", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        ([<ExcelArgument(Name="ts",Description = "Reference to ts")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let _ts = Helper.toCell<'TS> ts "ts" true
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).SetTermStructure
                                                            _ts.cell 
                                                       ) :> ICell
                let format (o : BootstrapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".SetTermStructure") 
                                               [| _BootstrapHelper.source
                                               ;  _ts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
                                ;  _ts.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_unregisterWith", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BootstrapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".UnregisterWith") 
                                               [| _BootstrapHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_update", Description="Create a BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapHelper",Description = "Reference to BootstrapHelper")>] 
         bootstraphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapHelper = Helper.toCell<BootstrapHelper> bootstraphelper "BootstrapHelper" true 
                let builder () = withMnemonic mnemonic ((_BootstrapHelper.cell :?> BootstrapHelperModel).Update
                                                       ) :> ICell
                let format (o : BootstrapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BootstrapHelper.source + ".Update") 
                                               [| _BootstrapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapHelper.cell
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
    [<ExcelFunction(Name="_BootstrapHelper_Range", Description="Create a range of BootstrapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BootstrapHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BootstrapHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BootstrapHelper> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BootstrapHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BootstrapHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BootstrapHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)