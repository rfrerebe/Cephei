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
===========================================================================// AnalyticHaganPricer                           // ===========================================================================
  </summary> *)
[<AutoSerializable(true)>]
module AnalyticHaganPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticHaganPricer", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swaptionVol",Description = "Reference to swaptionVol")>] 
         swaptionVol : obj)
        ([<ExcelArgument(Name="modelOfYieldCurve",Description = "Reference to modelOfYieldCurve")>] 
         modelOfYieldCurve : obj)
        ([<ExcelArgument(Name="meanReversion",Description = "Reference to meanReversion")>] 
         meanReversion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _swaptionVol = Helper.toHandle<SwaptionVolatilityStructure> swaptionVol "swaptionVol" 
                let _modelOfYieldCurve = Helper.toCell<GFunctionFactory.YieldCurveModel> modelOfYieldCurve "modelOfYieldCurve" true
                let _meanReversion = Helper.toHandle<Quote> meanReversion "meanReversion" 
                let builder () = withMnemonic mnemonic (Fun.AnalyticHaganPricer 
                                                            _swaptionVol.cell 
                                                            _modelOfYieldCurve.cell 
                                                            _meanReversion.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticHaganPricer>) l

                let source = Helper.sourceFold "Fun.AnalyticHaganPricer" 
                                               [| _swaptionVol.source
                                               ;  _modelOfYieldCurve.source
                                               ;  _meanReversion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _swaptionVol.cell
                                ;  _modelOfYieldCurve.cell
                                ;  _meanReversion.cell
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
        Hagan 3.4c
    *)
    [<ExcelFunction(Name="_AnalyticHaganPricer_swapletPrice", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".SwapletPrice") 
                                               [| _AnalyticHaganPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_capletPrice", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".CapletPrice") 
                                               [| _AnalyticHaganPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
                                ;  _effectiveCap.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_capletRate", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".CapletRate") 
                                               [| _AnalyticHaganPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
                                ;  _effectiveCap.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_floorletPrice", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".FloorletPrice") 
                                               [| _AnalyticHaganPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
                                ;  _effectiveFloor.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_floorletRate", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".FloorletRate") 
                                               [| _AnalyticHaganPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
                                ;  _effectiveFloor.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_initialize", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "Reference to coupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" true
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : AnalyticHaganPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".Initialize") 
                                               [| _AnalyticHaganPricer.source
                                               ;  _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
                                ;  _coupon.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_meanReversion", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_meanReversion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).MeanReversion
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".MeanReversion") 
                                               [| _AnalyticHaganPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_setMeanReversion", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_setMeanReversion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="meanReversion",Description = "Reference to meanReversion")>] 
         meanReversion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let _meanReversion = Helper.toHandle<Quote> meanReversion "meanReversion" 
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).SetMeanReversion
                                                            _meanReversion.cell 
                                                       ) :> ICell
                let format (o : AnalyticHaganPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".SetMeanReversion") 
                                               [| _AnalyticHaganPricer.source
                                               ;  _meanReversion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
                                ;  _meanReversion.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_swapletRate", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".SwapletRate") 
                                               [| _AnalyticHaganPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_setSwaptionVolatility", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_setSwaptionVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let _v = Helper.toHandle<SwaptionVolatilityStructure> v "v" 
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).SetSwaptionVolatility
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : AnalyticHaganPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".SetSwaptionVolatility") 
                                               [| _AnalyticHaganPricer.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_swaptionVolatility", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_swaptionVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).SwaptionVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<SwaptionVolatilityStructure>>) l

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".SwaptionVolatility") 
                                               [| _AnalyticHaganPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_registerWith", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticHaganPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".RegisterWith") 
                                               [| _AnalyticHaganPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_unregisterWith", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticHaganPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".UnregisterWith") 
                                               [| _AnalyticHaganPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_AnalyticHaganPricer_update", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "Reference to AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer" true 
                let builder () = withMnemonic mnemonic ((_AnalyticHaganPricer.cell :?> AnalyticHaganPricerModel).Update
                                                       ) :> ICell
                let format (o : AnalyticHaganPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHaganPricer.source + ".Update") 
                                               [| _AnalyticHaganPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_Range", Description="Create a range of AnalyticHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AnalyticHaganPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticHaganPricer> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AnalyticHaganPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AnalyticHaganPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AnalyticHaganPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"