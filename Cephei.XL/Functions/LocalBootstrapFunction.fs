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
  This algorithm enables a localised fitting for non-local interpolation methods.  As in the similar class (IterativeBootstrap) the input term structure is solved on a number of market instruments which are passed as a vector of handles to BootstrapHelper instances. Their maturities mark the boundaries of the interpolated segments.  Unlike the IterativeBootstrap class, the solution for each interpolated segment is derived using a local approximation. This restricts the risk profile s.t.  the risk is localised. Therefore, we obtain a local IR risk profile whilst using a smoother interpolation method. Particularly good for the convex-monotone spline method.
  </summary> *)
[<AutoSerializable(true)>]
module LocalBootstrapFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_LocalBootstrap", Description="Create a LocalBootstrap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalBootstrap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="localisation",Description = "Reference to localisation")>] 
         localisation : obj)
        ([<ExcelArgument(Name="forcePositive",Description = "Reference to forcePositive")>] 
         forcePositive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _localisation = Helper.toCell<int> localisation "localisation" true
                let _forcePositive = Helper.toCell<bool> forcePositive "forcePositive" true
                let builder () = withMnemonic mnemonic (Fun.LocalBootstrap 
                                                            _localisation.cell 
                                                            _forcePositive.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LocalBootstrap>) l

                let source = Helper.sourceFold "Fun.LocalBootstrap" 
                                               [| _localisation.source
                                               ;  _forcePositive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _localisation.cell
                                ;  _forcePositive.cell
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
    [<ExcelFunction(Name="_LocalBootstrap1", Description="Create a LocalBootstrap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalBootstrap_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.LocalBootstrap1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LocalBootstrap>) l

                let source = Helper.sourceFold "Fun.LocalBootstrap1" 
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
    [<ExcelFunction(Name="_LocalBootstrap_setup", Description="Create a LocalBootstrap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalBootstrap_setup
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalBootstrap",Description = "Reference to LocalBootstrap")>] 
         localbootstrap : obj)
        ([<ExcelArgument(Name="ts",Description = "Reference to ts")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalBootstrap = Helper.toCell<LocalBootstrap> localbootstrap "LocalBootstrap" true 
                let _ts = Helper.toCell<'T> ts "ts" true
                let builder () = withMnemonic mnemonic ((_LocalBootstrap.cell :?> LocalBootstrapModel).Setup
                                                            _ts.cell 
                                                       ) :> ICell
                let format (o : LocalBootstrap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalBootstrap.source + ".Setup") 
                                               [| _LocalBootstrap.source
                                               ;  _ts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalBootstrap.cell
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
    [<ExcelFunction(Name="_LocalBootstrap_Range", Description="Create a range of LocalBootstrap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalBootstrap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LocalBootstrap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LocalBootstrap> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LocalBootstrap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LocalBootstrap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LocalBootstrap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)