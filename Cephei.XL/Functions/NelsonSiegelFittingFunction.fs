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
  Fits a discount function to the form d(t) = t}, where the zero rate is defined as r c_0 + (c_0 + c_1)*(1 - exp^{ t) - c_2 exp^{ - t}. See: Nelson, C. and A. Siegel (1985): "Parsimonious modeling of yield curves for US Treasury bills." NBER Working Paper Series, no 1594.
  </summary> *)
[<AutoSerializable(true)>]
module NelsonSiegelFittingFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NelsonSiegelFitting_clone", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "Reference to NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toCell<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting" true 
                let builder () = withMnemonic mnemonic ((_NelsonSiegelFitting.cell :?> NelsonSiegelFittingModel).Clone
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FittedBondDiscountCurve.FittingMethod>) l

                let source = Helper.sourceFold (_NelsonSiegelFitting.source + ".Clone") 
                                               [| _NelsonSiegelFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
    [<ExcelFunction(Name="_NelsonSiegelFitting", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="weights",Description = "Reference to weights")>] 
         weights : obj)
        ([<ExcelArgument(Name="optimizationMethod",Description = "Reference to optimizationMethod")>] 
         optimizationMethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _weights = Helper.toCell<Vector> weights "weights" true
                let _optimizationMethod = Helper.toCell<OptimizationMethod> optimizationMethod "optimizationMethod" true
                let builder () = withMnemonic mnemonic (Fun.NelsonSiegelFitting 
                                                            _weights.cell 
                                                            _optimizationMethod.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NelsonSiegelFitting>) l

                let source = Helper.sourceFold "Fun.NelsonSiegelFitting" 
                                               [| _weights.source
                                               ;  _optimizationMethod.source
                                               |]
                let hash = Helper.hashFold 
                                [| _weights.cell
                                ;  _optimizationMethod.cell
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
    [<ExcelFunction(Name="_NelsonSiegelFitting_size", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "Reference to NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toCell<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting" true 
                let builder () = withMnemonic mnemonic ((_NelsonSiegelFitting.cell :?> NelsonSiegelFittingModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_NelsonSiegelFitting.source + ".Size") 
                                               [| _NelsonSiegelFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
        ! return whether there is a constraint at zero
    *)
    [<ExcelFunction(Name="_NelsonSiegelFitting_constrainAtZero", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_constrainAtZero
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "Reference to NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toCell<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting" true 
                let builder () = withMnemonic mnemonic ((_NelsonSiegelFitting.cell :?> NelsonSiegelFittingModel).ConstrainAtZero
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NelsonSiegelFitting.source + ".ConstrainAtZero") 
                                               [| _NelsonSiegelFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
        ! open discountFunction to public
    *)
    [<ExcelFunction(Name="_NelsonSiegelFitting_discount", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "Reference to NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toCell<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting" true 
                let _x = Helper.toCell<Vector> x "x" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_NelsonSiegelFitting.cell :?> NelsonSiegelFittingModel).Discount
                                                            _x.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NelsonSiegelFitting.source + ".Discount") 
                                               [| _NelsonSiegelFitting.source
                                               ;  _x.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
                                ;  _x.cell
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
        ! final value of cost function after optimization
    *)
    [<ExcelFunction(Name="_NelsonSiegelFitting_minimumCostValue", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_minimumCostValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "Reference to NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toCell<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting" true 
                let builder () = withMnemonic mnemonic ((_NelsonSiegelFitting.cell :?> NelsonSiegelFittingModel).MinimumCostValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NelsonSiegelFitting.source + ".MinimumCostValue") 
                                               [| _NelsonSiegelFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
        ! final number of iterations used in the optimization problem
    *)
    [<ExcelFunction(Name="_NelsonSiegelFitting_numberOfIterations", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_numberOfIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "Reference to NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toCell<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting" true 
                let builder () = withMnemonic mnemonic ((_NelsonSiegelFitting.cell :?> NelsonSiegelFittingModel).NumberOfIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_NelsonSiegelFitting.source + ".NumberOfIterations") 
                                               [| _NelsonSiegelFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
        ! return optimization method being used
    *)
    [<ExcelFunction(Name="_NelsonSiegelFitting_optimizationMethod", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_optimizationMethod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "Reference to NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toCell<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting" true 
                let builder () = withMnemonic mnemonic ((_NelsonSiegelFitting.cell :?> NelsonSiegelFittingModel).OptimizationMethod
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OptimizationMethod>) l

                let source = Helper.sourceFold (_NelsonSiegelFitting.source + ".OptimizationMethod") 
                                               [| _NelsonSiegelFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
        ! output array of results of optimization problem
    *)
    [<ExcelFunction(Name="_NelsonSiegelFitting_solution", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_solution
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "Reference to NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toCell<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting" true 
                let builder () = withMnemonic mnemonic ((_NelsonSiegelFitting.cell :?> NelsonSiegelFittingModel).Solution
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_NelsonSiegelFitting.source + ".Solution") 
                                               [| _NelsonSiegelFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
        ! return weights being used
    *)
    [<ExcelFunction(Name="_NelsonSiegelFitting_weights", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "Reference to NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toCell<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting" true 
                let builder () = withMnemonic mnemonic ((_NelsonSiegelFitting.cell :?> NelsonSiegelFittingModel).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_NelsonSiegelFitting.source + ".Weights") 
                                               [| _NelsonSiegelFitting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
    [<ExcelFunction(Name="_NelsonSiegelFitting_Range", Description="Create a range of NelsonSiegelFitting",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NelsonSiegelFitting")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NelsonSiegelFitting> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NelsonSiegelFitting>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NelsonSiegelFitting>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NelsonSiegelFitting>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"