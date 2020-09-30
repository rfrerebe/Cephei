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
module NLGCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NLGCurrency", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.NLGCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NLGCurrency>) l

                let source = Helper.sourceFold "Fun.NLGCurrency" 
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
    [<ExcelFunction(Name="_NLGCurrency_code", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "Reference to NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toCell<NLGCurrency> nlgcurrency "NLGCurrency" true 
                let builder () = withMnemonic mnemonic ((_NLGCurrency.cell :?> NLGCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NLGCurrency.source + ".Code") 
                                               [| _NLGCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_empty", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "Reference to NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toCell<NLGCurrency> nlgcurrency "NLGCurrency" true 
                let builder () = withMnemonic mnemonic ((_NLGCurrency.cell :?> NLGCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NLGCurrency.source + ".Empty") 
                                               [| _NLGCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_Equals", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "Reference to NLGCurrency")>] 
         nlgcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toCell<NLGCurrency> nlgcurrency "NLGCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_NLGCurrency.cell :?> NLGCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NLGCurrency.source + ".Equals") 
                                               [| _NLGCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_format", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "Reference to NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toCell<NLGCurrency> nlgcurrency "NLGCurrency" true 
                let builder () = withMnemonic mnemonic ((_NLGCurrency.cell :?> NLGCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NLGCurrency.source + ".Format") 
                                               [| _NLGCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_fractionsPerUnit", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "Reference to NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toCell<NLGCurrency> nlgcurrency "NLGCurrency" true 
                let builder () = withMnemonic mnemonic ((_NLGCurrency.cell :?> NLGCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_NLGCurrency.source + ".FractionsPerUnit") 
                                               [| _NLGCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_fractionSymbol", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "Reference to NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toCell<NLGCurrency> nlgcurrency "NLGCurrency" true 
                let builder () = withMnemonic mnemonic ((_NLGCurrency.cell :?> NLGCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NLGCurrency.source + ".FractionSymbol") 
                                               [| _NLGCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_name", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "Reference to NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toCell<NLGCurrency> nlgcurrency "NLGCurrency" true 
                let builder () = withMnemonic mnemonic ((_NLGCurrency.cell :?> NLGCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NLGCurrency.source + ".Name") 
                                               [| _NLGCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_numericCode", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "Reference to NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toCell<NLGCurrency> nlgcurrency "NLGCurrency" true 
                let builder () = withMnemonic mnemonic ((_NLGCurrency.cell :?> NLGCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_NLGCurrency.source + ".NumericCode") 
                                               [| _NLGCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_rounding", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "Reference to NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toCell<NLGCurrency> nlgcurrency "NLGCurrency" true 
                let builder () = withMnemonic mnemonic ((_NLGCurrency.cell :?> NLGCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_NLGCurrency.source + ".Rounding") 
                                               [| _NLGCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_symbol", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "Reference to NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toCell<NLGCurrency> nlgcurrency "NLGCurrency" true 
                let builder () = withMnemonic mnemonic ((_NLGCurrency.cell :?> NLGCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NLGCurrency.source + ".Symbol") 
                                               [| _NLGCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_ToString", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "Reference to NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toCell<NLGCurrency> nlgcurrency "NLGCurrency" true 
                let builder () = withMnemonic mnemonic ((_NLGCurrency.cell :?> NLGCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NLGCurrency.source + ".ToString") 
                                               [| _NLGCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_triangulationCurrency", Description="Create a NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NLGCurrency",Description = "Reference to NLGCurrency")>] 
         nlgcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NLGCurrency = Helper.toCell<NLGCurrency> nlgcurrency "NLGCurrency" true 
                let builder () = withMnemonic mnemonic ((_NLGCurrency.cell :?> NLGCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_NLGCurrency.source + ".TriangulationCurrency") 
                                               [| _NLGCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NLGCurrency.cell
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
    [<ExcelFunction(Name="_NLGCurrency_Range", Description="Create a range of NLGCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NLGCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NLGCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NLGCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NLGCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NLGCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NLGCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"