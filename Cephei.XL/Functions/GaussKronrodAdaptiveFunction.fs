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
  Integral of a 1-dimensional function using the Gauss-Kronrod methods   This class provide an adaptive integration procedure using 15 points Gauss-Kronrod integration rule.  This is more robust in that it allows to integrate less smooth functions (though singular functions should be integrated using dedicated algorithms) but less efficient beacuse it does not reuse precedently computed points during computation steps.  References:  Gauss-Kronrod Integration
<http://mathcssun1.emporia.edu/~oneilcat/ExperimentApplet3/ExperimentApplet3.html>  NMS - Numerical Analysis Library
<http://www.math.iastate.edu/burkardt/f_src/nms/nms.html>  the correctness of the result is tested by checking it against known good values.
  </summary> *)
[<AutoSerializable(true)>]
module GaussKronrodAdaptiveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussKronrodAdaptive", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="absoluteAccuracy",Description = "Reference to absoluteAccuracy")>] 
         absoluteAccuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _absoluteAccuracy = Helper.toCell<double> absoluteAccuracy "absoluteAccuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic (Fun.GaussKronrodAdaptive 
                                                            _absoluteAccuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussKronrodAdaptive>) l

                let source = Helper.sourceFold "Fun.GaussKronrodAdaptive" 
                                               [| _absoluteAccuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _absoluteAccuracy.cell
                                ;  _maxEvaluations.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_GaussKronrodAdaptive_absoluteAccuracy", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_absoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "Reference to GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive" true 
                let builder () = withMnemonic mnemonic ((_GaussKronrodAdaptive.cell :?> GaussKronrodAdaptiveModel).AbsoluteAccuracy
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GaussKronrodAdaptive.source + ".AbsoluteAccuracy") 
                                               [| _GaussKronrodAdaptive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_absoluteError", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_absoluteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "Reference to GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive" true 
                let builder () = withMnemonic mnemonic ((_GaussKronrodAdaptive.cell :?> GaussKronrodAdaptiveModel).AbsoluteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussKronrodAdaptive.source + ".AbsoluteError") 
                                               [| _GaussKronrodAdaptive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_integrationSuccess", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_integrationSuccess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "Reference to GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive" true 
                let builder () = withMnemonic mnemonic ((_GaussKronrodAdaptive.cell :?> GaussKronrodAdaptiveModel).IntegrationSuccess
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GaussKronrodAdaptive.source + ".IntegrationSuccess") 
                                               [| _GaussKronrodAdaptive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_maxEvaluations", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_maxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "Reference to GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive" true 
                let builder () = withMnemonic mnemonic ((_GaussKronrodAdaptive.cell :?> GaussKronrodAdaptiveModel).MaxEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussKronrodAdaptive.source + ".MaxEvaluations") 
                                               [| _GaussKronrodAdaptive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_numberOfEvaluations", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "Reference to GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive" true 
                let builder () = withMnemonic mnemonic ((_GaussKronrodAdaptive.cell :?> GaussKronrodAdaptiveModel).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussKronrodAdaptive.source + ".NumberOfEvaluations") 
                                               [| _GaussKronrodAdaptive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
        Modifiers
    *)
    [<ExcelFunction(Name="_GaussKronrodAdaptive_setAbsoluteAccuracy", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_setAbsoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "Reference to GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive" true 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let builder () = withMnemonic mnemonic ((_GaussKronrodAdaptive.cell :?> GaussKronrodAdaptiveModel).SetAbsoluteAccuracy
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (o : GaussKronrodAdaptive) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GaussKronrodAdaptive.source + ".SetAbsoluteAccuracy") 
                                               [| _GaussKronrodAdaptive.source
                                               ;  _accuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
                                ;  _accuracy.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_setMaxEvaluations", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_setMaxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "Reference to GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive" true 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_GaussKronrodAdaptive.cell :?> GaussKronrodAdaptiveModel).SetMaxEvaluations
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : GaussKronrodAdaptive) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GaussKronrodAdaptive.source + ".SetMaxEvaluations") 
                                               [| _GaussKronrodAdaptive.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
                                ;  _maxEvaluations.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_value", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "Reference to GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive" true 
                let _f = Helper.toCell<Func<double,double>> f "f" true
                let _a = Helper.toCell<double> a "a" true
                let _b = Helper.toCell<double> b "b" true
                let builder () = withMnemonic mnemonic ((_GaussKronrodAdaptive.cell :?> GaussKronrodAdaptiveModel).Value
                                                            _f.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussKronrodAdaptive.source + ".Value") 
                                               [| _GaussKronrodAdaptive.source
                                               ;  _f.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
                                ;  _f.cell
                                ;  _a.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_Range", Description="Create a range of GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussKronrodAdaptive")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussKronrodAdaptive> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussKronrodAdaptive>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussKronrodAdaptive>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GaussKronrodAdaptive>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"