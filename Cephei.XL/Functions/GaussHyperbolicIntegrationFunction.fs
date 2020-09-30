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
  Gauss-Hyperbolic integration This class performs a 1-dimensional Gauss-Hyperbolic integration.
  </summary> *)
[<AutoSerializable(true)>]
module GaussHyperbolicIntegrationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussHyperbolicIntegration", Description="Create a GaussHyperbolicIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicIntegration_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _n = Helper.toCell<int> n "n" true
                let builder () = withMnemonic mnemonic (Fun.GaussHyperbolicIntegration 
                                                            _n.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussHyperbolicIntegration>) l

                let source = Helper.sourceFold "Fun.GaussHyperbolicIntegration" 
                                               [| _n.source
                                               |]
                let hash = Helper.hashFold 
                                [| _n.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicIntegration_order", Description="Create a GaussHyperbolicIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicIntegration_order
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicIntegration",Description = "Reference to GaussHyperbolicIntegration")>] 
         gausshyperbolicintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicIntegration = Helper.toCell<GaussHyperbolicIntegration> gausshyperbolicintegration "GaussHyperbolicIntegration" true 
                let builder () = withMnemonic mnemonic ((_GaussHyperbolicIntegration.cell :?> GaussHyperbolicIntegrationModel).Order
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHyperbolicIntegration.source + ".Order") 
                                               [| _GaussHyperbolicIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicIntegration.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicIntegration_value", Description="Create a GaussHyperbolicIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicIntegration_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicIntegration",Description = "Reference to GaussHyperbolicIntegration")>] 
         gausshyperbolicintegration : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicIntegration = Helper.toCell<GaussHyperbolicIntegration> gausshyperbolicintegration "GaussHyperbolicIntegration" true 
                let _f = Helper.toCell<Func<double,double>> f "f" true
                let builder () = withMnemonic mnemonic ((_GaussHyperbolicIntegration.cell :?> GaussHyperbolicIntegrationModel).Value
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHyperbolicIntegration.source + ".Value") 
                                               [| _GaussHyperbolicIntegration.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicIntegration.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicIntegration_weights", Description="Create a GaussHyperbolicIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicIntegration_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicIntegration",Description = "Reference to GaussHyperbolicIntegration")>] 
         gausshyperbolicintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicIntegration = Helper.toCell<GaussHyperbolicIntegration> gausshyperbolicintegration "GaussHyperbolicIntegration" true 
                let builder () = withMnemonic mnemonic ((_GaussHyperbolicIntegration.cell :?> GaussHyperbolicIntegrationModel).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GaussHyperbolicIntegration.source + ".Weights") 
                                               [| _GaussHyperbolicIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicIntegration.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicIntegration_x", Description="Create a GaussHyperbolicIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicIntegration_x
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicIntegration",Description = "Reference to GaussHyperbolicIntegration")>] 
         gausshyperbolicintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicIntegration = Helper.toCell<GaussHyperbolicIntegration> gausshyperbolicintegration "GaussHyperbolicIntegration" true 
                let builder () = withMnemonic mnemonic ((_GaussHyperbolicIntegration.cell :?> GaussHyperbolicIntegrationModel).X
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GaussHyperbolicIntegration.source + ".X") 
                                               [| _GaussHyperbolicIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicIntegration.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicIntegration_Range", Description="Create a range of GaussHyperbolicIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicIntegration_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussHyperbolicIntegration")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussHyperbolicIntegration> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussHyperbolicIntegration>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussHyperbolicIntegration>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GaussHyperbolicIntegration>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"