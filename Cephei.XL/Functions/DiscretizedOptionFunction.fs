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
  it is advised that derived classes take care of creating and initializing themselves an instance of the underlying.
  </summary> *)
[<AutoSerializable(true)>]
module DiscretizedOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedOption", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="underlying",Description = "Reference to underlying")>] 
         underlying : obj)
        ([<ExcelArgument(Name="exerciseType",Description = "Reference to exerciseType")>] 
         exerciseType : obj)
        ([<ExcelArgument(Name="exerciseTimes",Description = "Reference to exerciseTimes")>] 
         exerciseTimes : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _underlying = Helper.toCell<DiscretizedAsset> underlying "underlying" true
                let _exerciseType = Helper.toCell<Exercise.Type> exerciseType "exerciseType" true
                let _exerciseTimes = Helper.toCell<Generic.List<double>> exerciseTimes "exerciseTimes" true
                let builder () = withMnemonic mnemonic (Fun.DiscretizedOption 
                                                            _underlying.cell 
                                                            _exerciseType.cell 
                                                            _exerciseTimes.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedOption>) l

                let source = Helper.sourceFold "Fun.DiscretizedOption" 
                                               [| _underlying.source
                                               ;  _exerciseType.source
                                               ;  _exerciseTimes.source
                                               |]
                let hash = Helper.hashFold 
                                [| _underlying.cell
                                ;  _exerciseType.cell
                                ;  _exerciseTimes.cell
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
    [<ExcelFunction(Name="_DiscretizedOption_mandatoryTimes", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscretizedOption.source + ".MandatoryTimes") 
                                               [| _DiscretizedOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedOption_reset", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let _size = Helper.toCell<int> size "size" true
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedOption.source + ".Reset") 
                                               [| _DiscretizedOption.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
                                ;  _size.cell
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
        ! This method performs both pre- and post-adjustment
    *)
    [<ExcelFunction(Name="_DiscretizedOption_adjustValues", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedOption.source + ".AdjustValues") 
                                               [| _DiscretizedOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
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
        High-level interface  Users of discretized assets should use these methods in order to initialize, evolve and take the present value of the assets.  They call the corresponding methods in the Lattice interface, to which we refer for documentation.
    *)
    [<ExcelFunction(Name="_DiscretizedOption_initialize", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let _Method = Helper.toCell<Lattice> Method "Method" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedOption.source + ".Initialize") 
                                               [| _DiscretizedOption.source
                                               ;  _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
                                ;  _Method.cell
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
        
    *)
    [<ExcelFunction(Name="_DiscretizedOption_method", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source = Helper.sourceFold (_DiscretizedOption.source + ".METHOD") 
                                               [| _DiscretizedOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
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
    [<ExcelFunction(Name="_DiscretizedOption_partialRollback", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let _To = Helper.toCell<double> To "To" true
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedOption.source + ".PartialRollback") 
                                               [| _DiscretizedOption.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
                                ;  _To.cell
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
        ! This method will be invoked after rollback and after any other asset had their chance to look at the values. For instance, payments happening at the present time (and therefore not included in an option to be exercised at this time) will be added here.  This method is not virtual; derived classes must override the protected postAdjustValuesImpl() method instead.
    *)
    [<ExcelFunction(Name="_DiscretizedOption_postAdjustValues", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedOption.source + ".PostAdjustValues") 
                                               [| _DiscretizedOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
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
        ! This method will be invoked after rollback and before any other asset (i.e., an option on this one) has any chance to look at the values. For instance, payments happening at times already spanned by the rollback will be added here.  This method is not virtual; derived classes must override the protected preAdjustValuesImpl() method instead.
    *)
    [<ExcelFunction(Name="_DiscretizedOption_preAdjustValues", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedOption.source + ".PreAdjustValues") 
                                               [| _DiscretizedOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
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
    [<ExcelFunction(Name="_DiscretizedOption_presentValue", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscretizedOption.source + ".PresentValue") 
                                               [| _DiscretizedOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
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
    [<ExcelFunction(Name="_DiscretizedOption_rollback", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let _To = Helper.toCell<double> To "To" true
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedOption.source + ".Rollback") 
                                               [| _DiscretizedOption.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
                                ;  _To.cell
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
        safe version of QL double* time()
    *)
    [<ExcelFunction(Name="_DiscretizedOption_setTime", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedOption.source + ".SetTime") 
                                               [| _DiscretizedOption.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
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
        safe version of QL Vector* values()
    *)
    [<ExcelFunction(Name="_DiscretizedOption_setValues", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let _v = Helper.toCell<Vector> v "v" true
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedOption.source + ".SetValues") 
                                               [| _DiscretizedOption.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
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
    [<ExcelFunction(Name="_DiscretizedOption_time", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscretizedOption.source + ".Time") 
                                               [| _DiscretizedOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
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
    [<ExcelFunction(Name="_DiscretizedOption_values", Description="Create a DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedOption",Description = "Reference to DiscretizedOption")>] 
         discretizedoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedOption = Helper.toCell<DiscretizedOption> discretizedoption "DiscretizedOption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedOption.cell :?> DiscretizedOptionModel).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DiscretizedOption.source + ".Values") 
                                               [| _DiscretizedOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedOption.cell
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
    [<ExcelFunction(Name="_DiscretizedOption_Range", Description="Create a range of DiscretizedOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscretizedOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedOption> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscretizedOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscretizedOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DiscretizedOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"