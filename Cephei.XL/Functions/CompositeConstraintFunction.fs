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
  %Constraint enforcing both given sub-constraints
  </summary> *)
[<AutoSerializable(true)>]
module CompositeConstraintFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CompositeConstraint", Description="Create a CompositeConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeConstraint_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c1",Description = "Reference to c1")>] 
         c1 : obj)
        ([<ExcelArgument(Name="c2",Description = "Reference to c2")>] 
         c2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c1 = Helper.toCell<Constraint> c1 "c1" true
                let _c2 = Helper.toCell<Constraint> c2 "c2" true
                let builder () = withMnemonic mnemonic (Fun.CompositeConstraint 
                                                            _c1.cell 
                                                            _c2.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CompositeConstraint>) l

                let source = Helper.sourceFold "Fun.CompositeConstraint" 
                                               [| _c1.source
                                               ;  _c2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c1.cell
                                ;  _c2.cell
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
    [<ExcelFunction(Name="_CompositeConstraint_empty", Description="Create a CompositeConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeConstraint_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeConstraint",Description = "Reference to CompositeConstraint")>] 
         compositeconstraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeConstraint = Helper.toCell<CompositeConstraint> compositeconstraint "CompositeConstraint" true 
                let builder () = withMnemonic mnemonic ((_CompositeConstraint.cell :?> CompositeConstraintModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CompositeConstraint.source + ".Empty") 
                                               [| _CompositeConstraint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeConstraint.cell
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
        ! Returns lower bound for given parameters
    *)
    [<ExcelFunction(Name="_CompositeConstraint_lowerBound", Description="Create a CompositeConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeConstraint_lowerBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeConstraint",Description = "Reference to CompositeConstraint")>] 
         compositeconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeConstraint = Helper.toCell<CompositeConstraint> compositeconstraint "CompositeConstraint" true 
                let _parameters = Helper.toCell<Vector> parameters "parameters" true
                let builder () = withMnemonic mnemonic ((_CompositeConstraint.cell :?> CompositeConstraintModel).LowerBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_CompositeConstraint.source + ".LowerBound") 
                                               [| _CompositeConstraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeConstraint.cell
                                ;  _parameters.cell
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
        ! Tests if params satisfy the constraint
    *)
    [<ExcelFunction(Name="_CompositeConstraint_test", Description="Create a CompositeConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeConstraint_test
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeConstraint",Description = "Reference to CompositeConstraint")>] 
         compositeconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeConstraint = Helper.toCell<CompositeConstraint> compositeconstraint "CompositeConstraint" true 
                let _p = Helper.toCell<Vector> p "p" true
                let builder () = withMnemonic mnemonic ((_CompositeConstraint.cell :?> CompositeConstraintModel).Test
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CompositeConstraint.source + ".Test") 
                                               [| _CompositeConstraint.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeConstraint.cell
                                ;  _p.cell
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
    [<ExcelFunction(Name="_CompositeConstraint_update", Description="Create a CompositeConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeConstraint_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeConstraint",Description = "Reference to CompositeConstraint")>] 
         compositeconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeConstraint = Helper.toCell<CompositeConstraint> compositeconstraint "CompositeConstraint" true 
                let _p = Helper.toCell<Vector> p "p" true
                let _direction = Helper.toCell<Vector> direction "direction" true
                let _beta = Helper.toCell<double> beta "beta" true
                let builder () = withMnemonic mnemonic ((_CompositeConstraint.cell :?> CompositeConstraintModel).Update
                                                            _p.cell 
                                                            _direction.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CompositeConstraint.source + ".Update") 
                                               [| _CompositeConstraint.source
                                               ;  _p.source
                                               ;  _direction.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeConstraint.cell
                                ;  _p.cell
                                ;  _direction.cell
                                ;  _beta.cell
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
        ! Returns upper bound for given parameters
    *)
    [<ExcelFunction(Name="_CompositeConstraint_upperBound", Description="Create a CompositeConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeConstraint_upperBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeConstraint",Description = "Reference to CompositeConstraint")>] 
         compositeconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeConstraint = Helper.toCell<CompositeConstraint> compositeconstraint "CompositeConstraint" true 
                let _parameters = Helper.toCell<Vector> parameters "parameters" true
                let builder () = withMnemonic mnemonic ((_CompositeConstraint.cell :?> CompositeConstraintModel).UpperBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_CompositeConstraint.source + ".UpperBound") 
                                               [| _CompositeConstraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeConstraint.cell
                                ;  _parameters.cell
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
    [<ExcelFunction(Name="_CompositeConstraint_Range", Description="Create a range of CompositeConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeConstraint_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CompositeConstraint")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CompositeConstraint> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CompositeConstraint>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CompositeConstraint>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CompositeConstraint>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"