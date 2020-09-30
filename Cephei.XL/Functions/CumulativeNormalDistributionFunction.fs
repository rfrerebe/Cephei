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
  Given x it provides an approximation to the integral of the gaussian normal distribution: formula here ...  For this implementation see M. Abramowitz and I. Stegun, Handbook of Mathematical Functions, Dover Publications, New York (1972)
  </summary> *)
[<AutoSerializable(true)>]
module CumulativeNormalDistributionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CumulativeNormalDistribution1", Description="Create a CumulativeNormalDistribution",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CumulativeNormalDistribution_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="average",Description = "Reference to average")>] 
         average : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _average = Helper.toCell<double> average "average" true
                let _sigma = Helper.toCell<double> sigma "sigma" true
                let builder () = withMnemonic mnemonic (Fun.CumulativeNormalDistribution1 
                                                            _average.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CumulativeNormalDistribution>) l

                let source = Helper.sourceFold "Fun.CumulativeNormalDistribution1" 
                                               [| _average.source
                                               ;  _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _average.cell
                                ;  _sigma.cell
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
    [<ExcelFunction(Name="_CumulativeNormalDistribution", Description="Create a CumulativeNormalDistribution",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CumulativeNormalDistribution_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.CumulativeNormalDistribution ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CumulativeNormalDistribution>) l

                let source = Helper.sourceFold "Fun.CumulativeNormalDistribution1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
    [<ExcelFunction(Name="_CumulativeNormalDistribution_derivative", Description="Create a CumulativeNormalDistribution",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CumulativeNormalDistribution_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CumulativeNormalDistribution",Description = "Reference to CumulativeNormalDistribution")>] 
         cumulativenormaldistribution : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CumulativeNormalDistribution = Helper.toCell<CumulativeNormalDistribution> cumulativenormaldistribution "CumulativeNormalDistribution" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_CumulativeNormalDistribution.cell :?> CumulativeNormalDistributionModel).Derivative
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CumulativeNormalDistribution.source + ".Derivative") 
                                               [| _CumulativeNormalDistribution.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CumulativeNormalDistribution.cell
                                ;  _x.cell
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
        function
    *)
    [<ExcelFunction(Name="_CumulativeNormalDistribution_value", Description="Create a CumulativeNormalDistribution",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CumulativeNormalDistribution_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CumulativeNormalDistribution",Description = "Reference to CumulativeNormalDistribution")>] 
         cumulativenormaldistribution : obj)
        ([<ExcelArgument(Name="z",Description = "Reference to z")>] 
         z : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CumulativeNormalDistribution = Helper.toCell<CumulativeNormalDistribution> cumulativenormaldistribution "CumulativeNormalDistribution" true 
                let _z = Helper.toCell<double> z "z" true
                let builder () = withMnemonic mnemonic ((_CumulativeNormalDistribution.cell :?> CumulativeNormalDistributionModel).Value
                                                            _z.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CumulativeNormalDistribution.source + ".Value") 
                                               [| _CumulativeNormalDistribution.source
                                               ;  _z.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CumulativeNormalDistribution.cell
                                ;  _z.cell
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
    [<ExcelFunction(Name="_CumulativeNormalDistribution_Range", Description="Create a range of CumulativeNormalDistribution",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CumulativeNormalDistribution_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CumulativeNormalDistribution")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CumulativeNormalDistribution> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CumulativeNormalDistribution>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CumulativeNormalDistribution>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CumulativeNormalDistribution>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"