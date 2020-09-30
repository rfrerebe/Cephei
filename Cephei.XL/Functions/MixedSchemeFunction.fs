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
(*!! generic
(* <summary>
  In this implementation, the passed operator must be derived from either TimeConstantOperator or TimeDependentOperator.  findiff
  </summary> *)
[<AutoSerializable(true)>]
module MixedSchemeFunction =

    (*
        constructors
    *)
    [<ExcelFunction(Name="_MixedScheme", Description="Create a MixedScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedScheme_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.MixedScheme 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MixedScheme>) l

                let source = Helper.sourceFold "Fun.MixedScheme" 
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
    [<ExcelFunction(Name="_MixedScheme1", Description="Create a MixedScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedScheme_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        ([<ExcelArgument(Name="bcs",Description = "Reference to bcs")>] 
         bcs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _L = Helper.toCell<'Operator> L "L" true
                let _theta = Helper.toCell<double> theta "theta" true
                let _bcs = Helper.toCell<Generic.List<BoundaryCondition<IOperator>>> bcs "bcs" true
                let builder () = withMnemonic mnemonic (Fun.MixedScheme1 
                                                            _L.cell 
                                                            _theta.cell 
                                                            _bcs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MixedScheme>) l

                let source = Helper.sourceFold "Fun.MixedScheme1" 
                                               [| _L.source
                                               ;  _theta.source
                                               ;  _bcs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _L.cell
                                ;  _theta.cell
                                ;  _bcs.cell
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
    [<ExcelFunction(Name="_MixedScheme_setStep", Description="Create a MixedScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedScheme_setStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedScheme",Description = "Reference to MixedScheme")>] 
         mixedscheme : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedScheme = Helper.toCell<MixedScheme> mixedscheme "MixedScheme" true 
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_MixedScheme.cell :?> MixedSchemeModel).SetStep
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : MixedScheme) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedScheme.source + ".SetStep") 
                                               [| _MixedScheme.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedScheme.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_MixedScheme_step", Description="Create a MixedScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedScheme_step
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedScheme",Description = "Reference to MixedScheme")>] 
         mixedscheme : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedScheme = Helper.toCell<MixedScheme> mixedscheme "MixedScheme" true 
                let _o = Helper.toCell<Object> o "o" true
                let _t = Helper.toCell<double> t "t" true
                let _theta = Helper.toCell<double> theta "theta" true
                let builder () = withMnemonic mnemonic ((_MixedScheme.cell :?> MixedSchemeModel).Step
                                                            _o.cell 
                                                            _t.cell 
                                                            _theta.cell 
                                                       ) :> ICell
                let format (o : MixedScheme) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedScheme.source + ".Step") 
                                               [| _MixedScheme.source
                                               ;  _o.source
                                               ;  _t.source
                                               ;  _theta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedScheme.cell
                                ;  _o.cell
                                ;  _t.cell
                                ;  _theta.cell
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
    [<ExcelFunction(Name="_MixedScheme_Range", Description="Create a range of MixedScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedScheme_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MixedScheme")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MixedScheme> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MixedScheme>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MixedScheme>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MixedScheme>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)