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
  Gauss-Chebyshev integration This class performs a 1-dimensional Gauss-Chebyshev integration.
  </summary> *)
[<AutoSerializable(true)>]
module GaussChebyshevIntegrationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussChebyshevIntegration", Description="Create a GaussChebyshevIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevIntegration_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _n = Helper.toCell<int> n "n" true
                let builder () = withMnemonic mnemonic (Fun.GaussChebyshevIntegration 
                                                            _n.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussChebyshevIntegration>) l

                let source = Helper.sourceFold "Fun.GaussChebyshevIntegration" 
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
    [<ExcelFunction(Name="_GaussChebyshevIntegration_order", Description="Create a GaussChebyshevIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevIntegration_order
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshevIntegration",Description = "Reference to GaussChebyshevIntegration")>] 
         gausschebyshevintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshevIntegration = Helper.toCell<GaussChebyshevIntegration> gausschebyshevintegration "GaussChebyshevIntegration" true 
                let builder () = withMnemonic mnemonic ((_GaussChebyshevIntegration.cell :?> GaussChebyshevIntegrationModel).Order
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussChebyshevIntegration.source + ".Order") 
                                               [| _GaussChebyshevIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshevIntegration.cell
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
    [<ExcelFunction(Name="_GaussChebyshevIntegration_value", Description="Create a GaussChebyshevIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevIntegration_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshevIntegration",Description = "Reference to GaussChebyshevIntegration")>] 
         gausschebyshevintegration : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshevIntegration = Helper.toCell<GaussChebyshevIntegration> gausschebyshevintegration "GaussChebyshevIntegration" true 
                let _f = Helper.toCell<Func<double,double>> f "f" true
                let builder () = withMnemonic mnemonic ((_GaussChebyshevIntegration.cell :?> GaussChebyshevIntegrationModel).Value
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussChebyshevIntegration.source + ".Value") 
                                               [| _GaussChebyshevIntegration.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshevIntegration.cell
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
    [<ExcelFunction(Name="_GaussChebyshevIntegration_weights", Description="Create a GaussChebyshevIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevIntegration_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshevIntegration",Description = "Reference to GaussChebyshevIntegration")>] 
         gausschebyshevintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshevIntegration = Helper.toCell<GaussChebyshevIntegration> gausschebyshevintegration "GaussChebyshevIntegration" true 
                let builder () = withMnemonic mnemonic ((_GaussChebyshevIntegration.cell :?> GaussChebyshevIntegrationModel).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GaussChebyshevIntegration.source + ".Weights") 
                                               [| _GaussChebyshevIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshevIntegration.cell
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
    [<ExcelFunction(Name="_GaussChebyshevIntegration_x", Description="Create a GaussChebyshevIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevIntegration_x
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshevIntegration",Description = "Reference to GaussChebyshevIntegration")>] 
         gausschebyshevintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshevIntegration = Helper.toCell<GaussChebyshevIntegration> gausschebyshevintegration "GaussChebyshevIntegration" true 
                let builder () = withMnemonic mnemonic ((_GaussChebyshevIntegration.cell :?> GaussChebyshevIntegrationModel).X
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GaussChebyshevIntegration.source + ".X") 
                                               [| _GaussChebyshevIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshevIntegration.cell
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
    [<ExcelFunction(Name="_GaussChebyshevIntegration_Range", Description="Create a range of GaussChebyshevIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevIntegration_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussChebyshevIntegration")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussChebyshevIntegration> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussChebyshevIntegration>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussChebyshevIntegration>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GaussChebyshevIntegration>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"