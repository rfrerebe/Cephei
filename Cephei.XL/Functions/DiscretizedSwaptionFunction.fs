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
module DiscretizedSwaptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedSwaption", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="args",Description = "Reference to args")>] 
         args : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _args = Helper.toCell<Swaption.Arguments> args "args" true
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let builder () = withMnemonic mnemonic (Fun.DiscretizedSwaption 
                                                            _args.cell 
                                                            _referenceDate.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedSwaption>) l

                let source = Helper.sourceFold "Fun.DiscretizedSwaption" 
                                               [| _args.source
                                               ;  _referenceDate.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _args.cell
                                ;  _referenceDate.cell
                                ;  _dayCounter.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_reset", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let _size = Helper.toCell<int> size "size" true
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedSwaption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".Reset") 
                                               [| _DiscretizedSwaption.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
        
    *)
    [<ExcelFunction(Name="_DiscretizedSwaption_withinNextWeek", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_withinNextWeek
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).WithinNextWeek
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".WithinNextWeek") 
                                               [| _DiscretizedSwaption.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
                                ;  _d1.cell
                                ;  _d2.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_withinPreviousWeek", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_withinPreviousWeek
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).WithinPreviousWeek
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".WithinPreviousWeek") 
                                               [| _DiscretizedSwaption.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
                                ;  _d1.cell
                                ;  _d2.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_mandatoryTimes", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".MandatoryTimes") 
                                               [| _DiscretizedSwaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
        ! This method performs both pre- and post-adjustment
    *)
    [<ExcelFunction(Name="_DiscretizedSwaption_adjustValues", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedSwaption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".AdjustValues") 
                                               [| _DiscretizedSwaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_initialize", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let _Method = Helper.toCell<Lattice> Method "Method" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedSwaption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".Initialize") 
                                               [| _DiscretizedSwaption.source
                                               ;  _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_method", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".METHOD") 
                                               [| _DiscretizedSwaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_partialRollback", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let _To = Helper.toCell<double> To "To" true
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedSwaption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".PartialRollback") 
                                               [| _DiscretizedSwaption.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_postAdjustValues", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedSwaption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".PostAdjustValues") 
                                               [| _DiscretizedSwaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_preAdjustValues", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedSwaption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".PreAdjustValues") 
                                               [| _DiscretizedSwaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_presentValue", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".PresentValue") 
                                               [| _DiscretizedSwaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_rollback", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let _To = Helper.toCell<double> To "To" true
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedSwaption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".Rollback") 
                                               [| _DiscretizedSwaption.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_setTime", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedSwaption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".SetTime") 
                                               [| _DiscretizedSwaption.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_setValues", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let _v = Helper.toCell<Vector> v "v" true
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedSwaption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".SetValues") 
                                               [| _DiscretizedSwaption.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_time", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".Time") 
                                               [| _DiscretizedSwaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_values", Description="Create a DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwaption",Description = "Reference to DiscretizedSwaption")>] 
         discretizedswaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwaption = Helper.toCell<DiscretizedSwaption> discretizedswaption "DiscretizedSwaption" true 
                let builder () = withMnemonic mnemonic ((_DiscretizedSwaption.cell :?> DiscretizedSwaptionModel).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DiscretizedSwaption.source + ".Values") 
                                               [| _DiscretizedSwaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwaption.cell
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
    [<ExcelFunction(Name="_DiscretizedSwaption_Range", Description="Create a range of DiscretizedSwaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwaption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscretizedSwaption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedSwaption> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscretizedSwaption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscretizedSwaption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DiscretizedSwaption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"