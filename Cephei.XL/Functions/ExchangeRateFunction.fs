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

  </summary> *)
[<AutoSerializable(true)>]
module ExchangeRateFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ExchangeRate_exchange", Description="Create a ExchangeRate",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRate_exchange
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExchangeRate",Description = "Reference to ExchangeRate")>] 
         exchangerate : obj)
        ([<ExcelArgument(Name="amount",Description = "Reference to amount")>] 
         amount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExchangeRate = Helper.toCell<ExchangeRate> exchangerate "ExchangeRate" true 
                let _amount = Helper.toCell<Money> amount "amount" true
                let builder () = withMnemonic mnemonic ((_ExchangeRate.cell :?> ExchangeRateModel).Exchange
                                                            _amount.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Money>) l

                let source = Helper.sourceFold (_ExchangeRate.source + ".Exchange") 
                                               [| _ExchangeRate.source
                                               ;  _amount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExchangeRate.cell
                                ;  _amount.cell
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
    [<ExcelFunction(Name="_ExchangeRate", Description="Create a ExchangeRate",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRate_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _source = Helper.toCell<Currency> source "source" true
                let _target = Helper.toCell<Currency> target "target" true
                let _rate = Helper.toCell<double> rate "rate" true
                let builder () = withMnemonic mnemonic (Fun.ExchangeRate 
                                                            _source.cell 
                                                            _target.cell 
                                                            _rate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ExchangeRate>) l

                let source = Helper.sourceFold "Fun.ExchangeRate" 
                                               [| _source.source
                                               ;  _target.source
                                               ;  _rate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _source.cell
                                ;  _target.cell
                                ;  _rate.cell
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
    [<ExcelFunction(Name="_ExchangeRate1", Description="Create a ExchangeRate",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRate_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ExchangeRate1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ExchangeRate>) l

                let source = Helper.sourceFold "Fun.ExchangeRate1" 
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
        
    *)
    [<ExcelFunction(Name="_ExchangeRate_HasValue", Description="Create a ExchangeRate",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRate_HasValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExchangeRate",Description = "Reference to ExchangeRate")>] 
         exchangerate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExchangeRate = Helper.toCell<ExchangeRate> exchangerate "ExchangeRate" true 
                let builder () = withMnemonic mnemonic ((_ExchangeRate.cell :?> ExchangeRateModel).HasValue
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ExchangeRate.source + ".HasValue") 
                                               [| _ExchangeRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExchangeRate.cell
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
    [<ExcelFunction(Name="_ExchangeRate_rate", Description="Create a ExchangeRate",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRate_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExchangeRate",Description = "Reference to ExchangeRate")>] 
         exchangerate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExchangeRate = Helper.toCell<ExchangeRate> exchangerate "ExchangeRate" true 
                let builder () = withMnemonic mnemonic ((_ExchangeRate.cell :?> ExchangeRateModel).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ExchangeRate.source + ".Rate") 
                                               [| _ExchangeRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExchangeRate.cell
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
    [<ExcelFunction(Name="_ExchangeRate_source", Description="Create a ExchangeRate",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRate_source
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExchangeRate",Description = "Reference to ExchangeRate")>] 
         exchangerate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExchangeRate = Helper.toCell<ExchangeRate> exchangerate "ExchangeRate" true 
                let builder () = withMnemonic mnemonic ((_ExchangeRate.cell :?> ExchangeRateModel).Source
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_ExchangeRate.source + ".Source") 
                                               [| _ExchangeRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExchangeRate.cell
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
    [<ExcelFunction(Name="_ExchangeRate_target", Description="Create a ExchangeRate",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRate_target
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExchangeRate",Description = "Reference to ExchangeRate")>] 
         exchangerate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExchangeRate = Helper.toCell<ExchangeRate> exchangerate "ExchangeRate" true 
                let builder () = withMnemonic mnemonic ((_ExchangeRate.cell :?> ExchangeRateModel).Target
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_ExchangeRate.source + ".Target") 
                                               [| _ExchangeRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExchangeRate.cell
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
    [<ExcelFunction(Name="_ExchangeRate_type", Description="Create a ExchangeRate",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRate_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ExchangeRate",Description = "Reference to ExchangeRate")>] 
         exchangerate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ExchangeRate = Helper.toCell<ExchangeRate> exchangerate "ExchangeRate" true 
                let builder () = withMnemonic mnemonic ((_ExchangeRate.cell :?> ExchangeRateModel).Type
                                                       ) :> ICell
                let format (o : ExchangeRate.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ExchangeRate.source + ".TYPE") 
                                               [| _ExchangeRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ExchangeRate.cell
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
    [<ExcelFunction(Name="_ExchangeRate_Range", Description="Create a range of ExchangeRate",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ExchangeRate_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ExchangeRate")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ExchangeRate> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ExchangeRate>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ExchangeRate>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ExchangeRate>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"