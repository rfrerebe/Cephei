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
module SecondDerivativeOpFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        ([<ExcelArgument(Name="mesher",Description = "Reference to mesher")>] 
         mesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _direction = Helper.toCell<int> direction "direction" true
                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" true
                let builder () = withMnemonic mnemonic (Fun.SecondDerivativeOp 
                                                            _direction.cell 
                                                            _mesher.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SecondDerivativeOp>) l

                let source = Helper.sourceFold "Fun.SecondDerivativeOp" 
                                               [| _direction.source
                                               ;  _mesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _direction.cell
                                ;  _mesher.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp1", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rhs = Helper.toCell<SecondDerivativeOp> rhs "rhs" true
                let builder () = withMnemonic mnemonic (Fun.SecondDerivativeOp1 
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SecondDerivativeOp>) l

                let source = Helper.sourceFold "Fun.SecondDerivativeOp1" 
                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rhs.cell
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
    (*!! duplicate Add function
    [<ExcelFunction(Name="_SecondDerivativeOp_add", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _A = Helper.toCell<IOperator> A "A" true
                let _B = Helper.toCell<IOperator> B "B" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Add") 
                                               [| _SecondDerivativeOp.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _A.cell
                                ;  _B.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_add", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="u",Description = "Reference to u")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _u = Helper.toCell<Vector> u "u" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Add1
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Add") 
                                               [| _SecondDerivativeOp.source
                                               ;  _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _u.cell
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
    (*!! duplicate ad functions 
    [<ExcelFunction(Name="_SecondDerivativeOp_add", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _m = Helper.toCell<TripleBandLinearOp> m "m" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Add2
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Add") 
                                               [| _SecondDerivativeOp.source
                                               ;  _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _m.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_apply", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _r = Helper.toCell<Vector> r "r" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Apply
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Apply") 
                                               [| _SecondDerivativeOp.source
                                               ;  _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _r.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_applyTo", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _v = Helper.toCell<Vector> v "v" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".ApplyTo") 
                                               [| _SecondDerivativeOp.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_axpyb", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_axpyb
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _a = Helper.toCell<Vector> a "a" true
                let _x = Helper.toCell<TripleBandLinearOp> x "x" true
                let _y = Helper.toCell<TripleBandLinearOp> y "y" true
                let _b = Helper.toCell<Vector> b "b" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Axpyb
                                                            _a.cell 
                                                            _x.cell 
                                                            _y.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SecondDerivativeOp) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Axpyb") 
                                               [| _SecondDerivativeOp.source
                                               ;  _a.source
                                               ;  _x.source
                                               ;  _y.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _a.cell
                                ;  _x.cell
                                ;  _y.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_Clone", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Clone") 
                                               [| _SecondDerivativeOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_identity", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _size = Helper.toCell<int> size "size" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Identity") 
                                               [| _SecondDerivativeOp.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _size.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_isTimeDependent", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".IsTimeDependent") 
                                               [| _SecondDerivativeOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_mult", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_mult
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="u",Description = "Reference to u")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _u = Helper.toCell<Vector> u "u" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Mult
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Mult") 
                                               [| _SecondDerivativeOp.source
                                               ;  _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _u.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_multiply", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="D",Description = "Reference to D")>] 
         D : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _a = Helper.toCell<double> a "a" true
                let _D = Helper.toCell<IOperator> D "D" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Multiply
                                                            _a.cell 
                                                            _D.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Multiply") 
                                               [| _SecondDerivativeOp.source
                                               ;  _a.source
                                               ;  _D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _a.cell
                                ;  _D.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_multR", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_multR
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="u",Description = "Reference to u")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _u = Helper.toCell<Vector> u "u" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).MultR
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".MultR") 
                                               [| _SecondDerivativeOp.source
                                               ;  _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _u.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_setTime", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : SecondDerivativeOp) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".SetTime") 
                                               [| _SecondDerivativeOp.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_size", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Size") 
                                               [| _SecondDerivativeOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_solve_splitting", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_solve_splitting
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _r = Helper.toCell<Vector> r "r" true
                let _a = Helper.toCell<double> a "a" true
                let _b = Helper.toCell<double> b "b" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Solve_splitting
                                                            _r.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Solve_splitting") 
                                               [| _SecondDerivativeOp.source
                                               ;  _r.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _r.cell
                                ;  _a.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_solveFor", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _rhs = Helper.toCell<Vector> rhs "rhs" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".SolveFor") 
                                               [| _SecondDerivativeOp.source
                                               ;  _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _rhs.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_subtract", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _A = Helper.toCell<IOperator> A "A" true
                let _B = Helper.toCell<IOperator> B "B" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Subtract") 
                                               [| _SecondDerivativeOp.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _A.cell
                                ;  _B.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_swap", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let _m = Helper.toCell<TripleBandLinearOp> m "m" true
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).Swap
                                                            _m.cell 
                                                       ) :> ICell
                let format (o : SecondDerivativeOp) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".Swap") 
                                               [| _SecondDerivativeOp.source
                                               ;  _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _m.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_toMatrix", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_toMatrix
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "Reference to SecondDerivativeOp")>] 
         secondderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp" true 
                let builder () = withMnemonic mnemonic ((_SecondDerivativeOp.cell :?> SecondDerivativeOpModel).ToMatrix
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SparseMatrix>) l

                let source = Helper.sourceFold (_SecondDerivativeOp.source + ".ToMatrix") 
                                               [| _SecondDerivativeOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_Range", Description="Create a range of SecondDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SecondDerivativeOp_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SecondDerivativeOp")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SecondDerivativeOp> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SecondDerivativeOp>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SecondDerivativeOp>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SecondDerivativeOp>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"