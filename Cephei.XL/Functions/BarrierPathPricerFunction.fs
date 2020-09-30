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
module BarrierPathPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BarrierPathPricer", Description="Create a BarrierPathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierPathPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="barrierType",Description = "Reference to barrierType")>] 
         barrierType : obj)
        ([<ExcelArgument(Name="barrier",Description = "Reference to barrier")>] 
         barrier : obj)
        ([<ExcelArgument(Name="rebate",Description = "Reference to rebate")>] 
         rebate : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discounts",Description = "Reference to discounts")>] 
         discounts : obj)
        ([<ExcelArgument(Name="diffProcess",Description = "Reference to diffProcess")>] 
         diffProcess : obj)
        ([<ExcelArgument(Name="sequenceGen",Description = "Reference to sequenceGen")>] 
         sequenceGen : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _barrierType = Helper.toCell<Barrier.Type> barrierType "barrierType" true
                let _barrier = Helper.toNullable<double> barrier "barrier"
                let _rebate = Helper.toNullable<double> rebate "rebate"
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _discounts = Helper.toCell<Generic.List<double>> discounts "discounts" true
                let _diffProcess = Helper.toCell<StochasticProcess1D> diffProcess "diffProcess" true
                let _sequenceGen = Helper.toCell<IRNG> sequenceGen "sequenceGen" true
                let builder () = withMnemonic mnemonic (Fun.BarrierPathPricer 
                                                            _barrierType.cell 
                                                            _barrier.cell 
                                                            _rebate.cell 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _discounts.cell 
                                                            _diffProcess.cell 
                                                            _sequenceGen.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BarrierPathPricer>) l

                let source = Helper.sourceFold "Fun.BarrierPathPricer" 
                                               [| _barrierType.source
                                               ;  _barrier.source
                                               ;  _rebate.source
                                               ;  _Type.source
                                               ;  _strike.source
                                               ;  _discounts.source
                                               ;  _diffProcess.source
                                               ;  _sequenceGen.source
                                               |]
                let hash = Helper.hashFold 
                                [| _barrierType.cell
                                ;  _barrier.cell
                                ;  _rebate.cell
                                ;  _Type.cell
                                ;  _strike.cell
                                ;  _discounts.cell
                                ;  _diffProcess.cell
                                ;  _sequenceGen.cell
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
    [<ExcelFunction(Name="_BarrierPathPricer_value", Description="Create a BarrierPathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierPathPricer_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierPathPricer",Description = "Reference to BarrierPathPricer")>] 
         barrierpathpricer : obj)
        ([<ExcelArgument(Name="path",Description = "Reference to path")>] 
         path : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierPathPricer = Helper.toCell<BarrierPathPricer> barrierpathpricer "BarrierPathPricer" true 
                let _path = Helper.toCell<IPath> path "path" true
                let builder () = withMnemonic mnemonic ((_BarrierPathPricer.cell :?> BarrierPathPricerModel).Value
                                                            _path.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierPathPricer.source + ".Value") 
                                               [| _BarrierPathPricer.source
                                               ;  _path.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierPathPricer.cell
                                ;  _path.cell
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
    [<ExcelFunction(Name="_BarrierPathPricer_Range", Description="Create a range of BarrierPathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierPathPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BarrierPathPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BarrierPathPricer> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BarrierPathPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BarrierPathPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BarrierPathPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"