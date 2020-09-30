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
module BackwardflatLinearFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BackwardflatLinear_interpolate", Description="Create a BackwardflatLinear",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinear_interpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinear",Description = "Reference to BackwardflatLinear")>] 
         backwardflatlinear : obj)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xEnd",Description = "Reference to xEnd")>] 
         xEnd : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="yEnd",Description = "Reference to yEnd")>] 
         yEnd : obj)
        ([<ExcelArgument(Name="z",Description = "Reference to z")>] 
         z : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinear = Helper.toCell<BackwardflatLinear> backwardflatlinear "BackwardflatLinear" true 
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" true
                let _xEnd = Helper.toCell<int> xEnd "xEnd" true
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" true
                let _yEnd = Helper.toCell<int> yEnd "yEnd" true
                let _z = Helper.toCell<Matrix> z "z" true
                let builder () = withMnemonic mnemonic ((_BackwardflatLinear.cell :?> BackwardflatLinearModel).Interpolate
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                            _yEnd.cell 
                                                            _z.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation2D>) l

                let source = Helper.sourceFold (_BackwardflatLinear.source + ".Interpolate") 
                                               [| _BackwardflatLinear.source
                                               ;  _xBegin.source
                                               ;  _xEnd.source
                                               ;  _yBegin.source
                                               ;  _yEnd.source
                                               ;  _z.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinear.cell
                                ;  _xBegin.cell
                                ;  _xEnd.cell
                                ;  _yBegin.cell
                                ;  _yEnd.cell
                                ;  _z.cell
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
    [<ExcelFunction(Name="_BackwardflatLinear_Range", Description="Create a range of BackwardflatLinear",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinear_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BackwardflatLinear")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BackwardflatLinear> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BackwardflatLinear>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BackwardflatLinear>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BackwardflatLinear>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"