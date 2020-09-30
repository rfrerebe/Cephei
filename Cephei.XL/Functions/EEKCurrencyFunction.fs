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
module EEKCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EEKCurrency", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.EEKCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EEKCurrency>) l

                let source = Helper.sourceFold "Fun.EEKCurrency" 
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
        ! currency name, e.g, "U.S. Dollar"
    *)
    [<ExcelFunction(Name="_EEKCurrency_code", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "Reference to EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency" true 
                let builder () = withMnemonic mnemonic ((_EEKCurrency.cell :?> EEKCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EEKCurrency.source + ".Code") 
                                               [| _EEKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
        ! Other information ! is this a usable instance?
    *)
    [<ExcelFunction(Name="_EEKCurrency_empty", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "Reference to EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency" true 
                let builder () = withMnemonic mnemonic ((_EEKCurrency.cell :?> EEKCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EEKCurrency.source + ".Empty") 
                                               [| _EEKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_Equals", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "Reference to EEKCurrency")>] 
         eekcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_EEKCurrency.cell :?> EEKCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EEKCurrency.source + ".Equals") 
                                               [| _EEKCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
                                ;  _o.cell
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
        ! currency used for triangulated exchange when required output format The format will be fed three positional parameters, namely, value, code, and symbol, in this order.
    *)
    [<ExcelFunction(Name="_EEKCurrency_format", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "Reference to EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency" true 
                let builder () = withMnemonic mnemonic ((_EEKCurrency.cell :?> EEKCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EEKCurrency.source + ".Format") 
                                               [| _EEKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
        ! fraction symbol, e.g, "Â¢"
    *)
    [<ExcelFunction(Name="_EEKCurrency_fractionsPerUnit", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "Reference to EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency" true 
                let builder () = withMnemonic mnemonic ((_EEKCurrency.cell :?> EEKCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EEKCurrency.source + ".FractionsPerUnit") 
                                               [| _EEKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
        ! symbol, e.g, "$"
    *)
    [<ExcelFunction(Name="_EEKCurrency_fractionSymbol", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "Reference to EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency" true 
                let builder () = withMnemonic mnemonic ((_EEKCurrency.cell :?> EEKCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EEKCurrency.source + ".FractionSymbol") 
                                               [| _EEKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_name", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "Reference to EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency" true 
                let builder () = withMnemonic mnemonic ((_EEKCurrency.cell :?> EEKCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EEKCurrency.source + ".Name") 
                                               [| _EEKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
        ! ISO 4217 three-letter code, e.g, "USD"
    *)
    [<ExcelFunction(Name="_EEKCurrency_numericCode", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "Reference to EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency" true 
                let builder () = withMnemonic mnemonic ((_EEKCurrency.cell :?> EEKCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EEKCurrency.source + ".NumericCode") 
                                               [| _EEKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
        ! number of fractionary parts in a unit, e.g, 100
    *)
    [<ExcelFunction(Name="_EEKCurrency_rounding", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "Reference to EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency" true 
                let builder () = withMnemonic mnemonic ((_EEKCurrency.cell :?> EEKCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_EEKCurrency.source + ".Rounding") 
                                               [| _EEKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
        ! ISO 4217 numeric code, e.g, "840"
    *)
    [<ExcelFunction(Name="_EEKCurrency_symbol", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "Reference to EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency" true 
                let builder () = withMnemonic mnemonic ((_EEKCurrency.cell :?> EEKCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EEKCurrency.source + ".Symbol") 
                                               [| _EEKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_ToString", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "Reference to EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency" true 
                let builder () = withMnemonic mnemonic ((_EEKCurrency.cell :?> EEKCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EEKCurrency.source + ".ToString") 
                                               [| _EEKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
        ! rounding convention
    *)
    [<ExcelFunction(Name="_EEKCurrency_triangulationCurrency", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "Reference to EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency" true 
                let builder () = withMnemonic mnemonic ((_EEKCurrency.cell :?> EEKCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EEKCurrency.source + ".TriangulationCurrency") 
                                               [| _EEKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_Range", Description="Create a range of EEKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EEKCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EEKCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EEKCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EEKCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EEKCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EEKCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"