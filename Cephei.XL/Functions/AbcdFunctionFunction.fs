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
  f(T-t) = [ a + b(T-t) ] e^{-c(T-t)} + d following Rebonato's notation.
  </summary> *)
[<AutoSerializable(true)>]
module AbcdFunctionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AbcdFunction", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _a = Helper.toCell<double> a "a" true
                let _b = Helper.toCell<double> b "b" true
                let _c = Helper.toCell<double> c "c" true
                let _d = Helper.toCell<double> d "d" true
                let builder () = withMnemonic mnemonic (Fun.AbcdFunction 
                                                            _a.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AbcdFunction>) l

                let source = Helper.sourceFold "Fun.AbcdFunction" 
                                               [| _a.source
                                               ;  _b.source
                                               ;  _c.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _a.cell
                                ;  _b.cell
                                ;  _c.cell
                                ;  _d.cell
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
        ! integral of the instantaneous covariance function between time t1 and t2 for T-fixing and S-fixing rates \f[ \int_{t1}^{t2} f(T-t)f(S-t)dt \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_covariance1", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_covariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="t1",Description = "Reference to t1")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "Reference to t2")>] 
         t2 : obj)
        ([<ExcelArgument(Name="T",Description = "Reference to T")>] 
         T : obj)
        ([<ExcelArgument(Name="S",Description = "Reference to S")>] 
         S : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _t1 = Helper.toCell<double> t1 "t1" true
                let _t2 = Helper.toCell<double> t2 "t2" true
                let _T = Helper.toCell<double> T "T" true
                let _S = Helper.toCell<double> S "S" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).Covariance1
                                                            _t1.cell 
                                                            _t2.cell 
                                                            _T.cell 
                                                            _S.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".Covariance1") 
                                               [| _AbcdFunction.source
                                               ;  _t1.source
                                               ;  _t2.source
                                               ;  _T.source
                                               ;  _S.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
                                ;  _t1.cell
                                ;  _t2.cell
                                ;  _T.cell
                                ;  _S.cell
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
        ! instantaneous covariance function at time t between T-fixing and S-fixing rates \f[ f(T-t)f(S-t) \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_covariance", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="T2",Description = "Reference to T2")>] 
         T2 : obj)
        ([<ExcelArgument(Name="S",Description = "Reference to S")>] 
         S : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _t = Helper.toCell<double> t "t" true
                let _T2 = Helper.toCell<double> T2 "T2" true
                let _S = Helper.toCell<double> S "S" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).Covariance
                                                            _t.cell 
                                                            _T2.cell 
                                                            _S.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".Covariance") 
                                               [| _AbcdFunction.source
                                               ;  _t.source
                                               ;  _T2.source
                                               ;  _S.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
                                ;  _t.cell
                                ;  _T2.cell
                                ;  _S.cell
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
        ! instantaneous covariance at time t between T and S fixing rates: \f[ f(T-u)f(S-u) \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_instantaneousCovariance", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_instantaneousCovariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="u",Description = "Reference to u")>] 
         u : obj)
        ([<ExcelArgument(Name="T",Description = "Reference to T")>] 
         T : obj)
        ([<ExcelArgument(Name="S",Description = "Reference to S")>] 
         S : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _u = Helper.toCell<double> u "u" true
                let _T = Helper.toCell<double> T "T" true
                let _S = Helper.toCell<double> S "S" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).InstantaneousCovariance
                                                            _u.cell 
                                                            _T.cell 
                                                            _S.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".InstantaneousCovariance") 
                                               [| _AbcdFunction.source
                                               ;  _u.source
                                               ;  _T.source
                                               ;  _S.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
                                ;  _u.cell
                                ;  _T.cell
                                ;  _S.cell
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
        ! instantaneous variance at time t of T-fixing rate: \f[ f(T-t)f(T-t) \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_instantaneousVariance", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_instantaneousVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="u",Description = "Reference to u")>] 
         u : obj)
        ([<ExcelArgument(Name="T",Description = "Reference to T")>] 
         T : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _u = Helper.toCell<double> u "u" true
                let _T = Helper.toCell<double> T "T" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).InstantaneousVariance
                                                            _u.cell 
                                                            _T.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".InstantaneousVariance") 
                                               [| _AbcdFunction.source
                                               ;  _u.source
                                               ;  _T.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
                                ;  _u.cell
                                ;  _T.cell
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
        ! instantaneous volatility at time t of the T-fixing rate: \f[ f(T-t) \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_instantaneousVolatility", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_instantaneousVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="u",Description = "Reference to u")>] 
         u : obj)
        ([<ExcelArgument(Name="T",Description = "Reference to T")>] 
         T : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _u = Helper.toCell<double> u "u" true
                let _T = Helper.toCell<double> T "T" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).InstantaneousVolatility
                                                            _u.cell 
                                                            _T.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".InstantaneousVolatility") 
                                               [| _AbcdFunction.source
                                               ;  _u.source
                                               ;  _T.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
                                ;  _u.cell
                                ;  _T.cell
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
        ! volatility function value at time +inf: \f[ f(\inf) \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_longTermVolatility", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_longTermVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).LongTermVolatility
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".LongTermVolatility") 
                                               [| _AbcdFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
        ! maximum value of the volatility function
    *)
    [<ExcelFunction(Name="_AbcdFunction_maximumVolatility", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_maximumVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).MaximumVolatility
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".MaximumVolatility") 
                                               [| _AbcdFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
        ! indefinite integral of the instantaneous covariance function at time t between T-fixing and S-fixing rates \f[ \int f(T-t)f(S-t)dt \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_primitive", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="T2",Description = "Reference to T2")>] 
         T2 : obj)
        ([<ExcelArgument(Name="S",Description = "Reference to S")>] 
         S : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _t = Helper.toCell<double> t "t" true
                let _T2 = Helper.toCell<double> T2 "T2" true
                let _S = Helper.toCell<double> S "S" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).Primitive
                                                            _t.cell 
                                                            _T2.cell 
                                                            _S.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".Primitive") 
                                               [| _AbcdFunction.source
                                               ;  _t.source
                                               ;  _T2.source
                                               ;  _S.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
                                ;  _t.cell
                                ;  _T2.cell
                                ;  _S.cell
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
        ! volatility function value at time 0: \f[ f(0) \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_shortTermVolatility", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_shortTermVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).ShortTermVolatility
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".ShortTermVolatility") 
                                               [| _AbcdFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
        ! variance between tMin and tMax of T-fixing rate: \f[ \frac{\int_{tMin}^{tMax} f^2(T-u)du}{tMax-tMin} \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_variance", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="tMin",Description = "Reference to tMin")>] 
         tMin : obj)
        ([<ExcelArgument(Name="tMax",Description = "Reference to tMax")>] 
         tMax : obj)
        ([<ExcelArgument(Name="T",Description = "Reference to T")>] 
         T : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _tMin = Helper.toCell<double> tMin "tMin" true
                let _tMax = Helper.toCell<double> tMax "tMax" true
                let _T = Helper.toCell<double> T "T" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).Variance
                                                            _tMin.cell 
                                                            _tMax.cell 
                                                            _T.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".Variance") 
                                               [| _AbcdFunction.source
                                               ;  _tMin.source
                                               ;  _tMax.source
                                               ;  _T.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
                                ;  _tMin.cell
                                ;  _tMax.cell
                                ;  _T.cell
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
        ! average volatility in [tMin,tMax] of T-fixing rate: \f[ \sqrt{ \frac{\int_{tMin}^{tMax} f^2(T-u)du}{tMax-tMin} } \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_volatility", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="tMin",Description = "Reference to tMin")>] 
         tMin : obj)
        ([<ExcelArgument(Name="tMax",Description = "Reference to tMax")>] 
         tMax : obj)
        ([<ExcelArgument(Name="T",Description = "Reference to T")>] 
         T : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _tMin = Helper.toCell<double> tMin "tMin" true
                let _tMax = Helper.toCell<double> tMax "tMax" true
                let _T = Helper.toCell<double> T "T" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).Volatility
                                                            _tMin.cell 
                                                            _tMax.cell 
                                                            _T.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".Volatility") 
                                               [| _AbcdFunction.source
                                               ;  _tMin.source
                                               ;  _tMax.source
                                               ;  _T.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
                                ;  _tMin.cell
                                ;  _tMax.cell
                                ;  _T.cell
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
        ! Inspectors
    *)
    [<ExcelFunction(Name="_AbcdFunction_a", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".A") 
                                               [| _AbcdFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
    [<ExcelFunction(Name="_AbcdFunction_b", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_b
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).B
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".B") 
                                               [| _AbcdFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
    [<ExcelFunction(Name="_AbcdFunction_c", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_c
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).C
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".C") 
                                               [| _AbcdFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
    [<ExcelFunction(Name="_AbcdFunction_coefficients", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_coefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).Coefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_AbcdFunction.source + ".Coefficients") 
                                               [| _AbcdFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
    [<ExcelFunction(Name="_AbcdFunction_d", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_d
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).D
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".D") 
                                               [| _AbcdFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
        ! coefficients of a AbcdMathFunction defined as definite derivative on a rolling window of length tau, with tau = t2-t
    *)
    [<ExcelFunction(Name="_AbcdFunction_definiteDerivativeCoefficients", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_definiteDerivativeCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="t2",Description = "Reference to t2")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _t = Helper.toCell<double> t "t" true
                let _t2 = Helper.toCell<double> t2 "t2" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).DefiniteDerivativeCoefficients
                                                            _t.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_AbcdFunction.source + ".DefiniteDerivativeCoefficients") 
                                               [| _AbcdFunction.source
                                               ;  _t.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
                                ;  _t.cell
                                ;  _t2.cell
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
        ! definite integral of the function between t1 and t2 \f[ \int_{t1}^{t2} f(t)dt \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_definiteIntegral", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_definiteIntegral
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="t1",Description = "Reference to t1")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "Reference to t2")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _t1 = Helper.toCell<double> t1 "t1" true
                let _t2 = Helper.toCell<double> t2 "t2" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).DefiniteIntegral
                                                            _t1.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".DefiniteIntegral") 
                                               [| _AbcdFunction.source
                                               ;  _t1.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
                                ;  _t1.cell
                                ;  _t2.cell
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
        ! coefficients of a AbcdMathFunction defined as definite integral on a rolling window of length tau, with tau = t2-t
    *)
    [<ExcelFunction(Name="_AbcdFunction_definiteIntegralCoefficients", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_definiteIntegralCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="t2",Description = "Reference to t2")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _t = Helper.toCell<double> t "t" true
                let _t2 = Helper.toCell<double> t2 "t2" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).DefiniteIntegralCoefficients
                                                            _t.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_AbcdFunction.source + ".DefiniteIntegralCoefficients") 
                                               [| _AbcdFunction.source
                                               ;  _t.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
                                ;  _t.cell
                                ;  _t2.cell
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
        ! first derivative of the function at time t \f[ f'(t) = [ (b-c*a) + (-c*b)*t) ] e^{-c*t} \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_derivative", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).Derivative
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".Derivative") 
                                               [| _AbcdFunction.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
    [<ExcelFunction(Name="_AbcdFunction_derivativeCoefficients", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_derivativeCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).DerivativeCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_AbcdFunction.source + ".DerivativeCoefficients") 
                                               [| _AbcdFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
        ! function value at time +inf: \f[ f(\inf) \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_longTermValue", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_longTermValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).LongTermValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".LongTermValue") 
                                               [| _AbcdFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
        ! time at which the function reaches maximum (if any)
    *)
    [<ExcelFunction(Name="_AbcdFunction_maximumLocation", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_maximumLocation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).MaximumLocation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".MaximumLocation") 
                                               [| _AbcdFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
        ! maximum value of the function
    *)
    [<ExcelFunction(Name="_AbcdFunction_maximumValue", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_maximumValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).MaximumValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".MaximumValue") 
                                               [| _AbcdFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
        ! function value at time t: \f[ f(t) \f]
    *)
    [<ExcelFunction(Name="_AbcdFunction_value", Description="Create a AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdFunction",Description = "Reference to AbcdFunction")>] 
         abcdfunction : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdFunction = Helper.toCell<AbcdFunction> abcdfunction "AbcdFunction" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_AbcdFunction.cell :?> AbcdFunctionModel).Value
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdFunction.source + ".Value") 
                                               [| _AbcdFunction.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdFunction.cell
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
    [<ExcelFunction(Name="_AbcdFunction_Range", Description="Create a range of AbcdFunction",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdFunction_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AbcdFunction")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AbcdFunction> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AbcdFunction>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AbcdFunction>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AbcdFunction>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"