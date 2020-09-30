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
  instruments
  </summary> *)
[<AutoSerializable(true)>]
module DividendBarrierOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DividendBarrierOption", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="barrierType",Description = "Reference to barrierType")>] 
         barrierType : obj)
        ([<ExcelArgument(Name="barrier",Description = "Reference to barrier")>] 
         barrier : obj)
        ([<ExcelArgument(Name="rebate",Description = "Reference to rebate")>] 
         rebate : obj)
        ([<ExcelArgument(Name="payoff",Description = "Reference to payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="exercise",Description = "Reference to exercise")>] 
         exercise : obj)
        ([<ExcelArgument(Name="dividendDates",Description = "Reference to dividendDates")>] 
         dividendDates : obj)
        ([<ExcelArgument(Name="dividends",Description = "Reference to dividends")>] 
         dividends : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _barrierType = Helper.toCell<Barrier.Type> barrierType "barrierType" true
                let _barrier = Helper.toCell<double> barrier "barrier" true
                let _rebate = Helper.toCell<double> rebate "rebate" true
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" true
                let _exercise = Helper.toCell<Exercise> exercise "exercise" true
                let _dividendDates = Helper.toCell<Generic.List<Date>> dividendDates "dividendDates" true
                let _dividends = Helper.toCell<Generic.List<double>> dividends "dividends" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.DividendBarrierOption 
                                                            _barrierType.cell 
                                                            _barrier.cell 
                                                            _rebate.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _dividendDates.cell 
                                                            _dividends.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DividendBarrierOption>) l

                let source = Helper.sourceFold "Fun.DividendBarrierOption" 
                                               [| _barrierType.source
                                               ;  _barrier.source
                                               ;  _rebate.source
                                               ;  _payoff.source
                                               ;  _exercise.source
                                               ;  _dividendDates.source
                                               ;  _dividends.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _barrierType.cell
                                ;  _barrier.cell
                                ;  _rebate.cell
                                ;  _payoff.cell
                                ;  _exercise.cell
                                ;  _dividendDates.cell
                                ;  _dividends.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
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
        ! \warning see VanillaOption for notes on implied-volatility calculation.
    *)
    [<ExcelFunction(Name="_DividendBarrierOption_impliedVolatility", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        ([<ExcelArgument(Name="targetValue",Description = "Reference to targetValue")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="minVol",Description = "Reference to minVol")>] 
         minVol : obj)
        ([<ExcelArgument(Name="maxVol",Description = "Reference to maxVol")>] 
         maxVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let _minVol = Helper.toCell<double> minVol "minVol" true
                let _maxVol = Helper.toCell<double> maxVol "maxVol" true
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _Process.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".ImpliedVolatility") 
                                               [| _DividendBarrierOption.source
                                               ;  _targetValue.source
                                               ;  _Process.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
                                ;  _targetValue.cell
                                ;  _Process.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                ;  _minVol.cell
                                ;  _maxVol.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_delta", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".Delta") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_deltaForward", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".DeltaForward") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_dividendRho", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".DividendRho") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_elasticity", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".Elasticity") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_gamma", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".Gamma") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_isExpired", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".IsExpired") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_itmCashProbability", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".ItmCashProbability") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_rho", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".Rho") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_strikeSensitivity", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".StrikeSensitivity") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_theta", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".Theta") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_thetaPerDay", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".ThetaPerDay") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_vega", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".Vega") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_exercise", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".Exercise") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_payoff", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".Payoff") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_CASH", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".CASH") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_errorEstimate", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".ErrorEstimate") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_NPV", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".NPV") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_DividendBarrierOption_result", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".Result") 
                                               [| _DividendBarrierOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_DividendBarrierOption_setPricingEngine", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : DividendBarrierOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".SetPricingEngine") 
                                               [| _DividendBarrierOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_DividendBarrierOption_valuationDate", Description="Create a DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendBarrierOption",Description = "Reference to DividendBarrierOption")>] 
         dividendbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendBarrierOption = Helper.toCell<DividendBarrierOption> dividendbarrieroption "DividendBarrierOption" true 
                let builder () = withMnemonic mnemonic ((_DividendBarrierOption.cell :?> DividendBarrierOptionModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DividendBarrierOption.source + ".ValuationDate") 
                                               [| _DividendBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendBarrierOption.cell
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
    [<ExcelFunction(Name="_DividendBarrierOption_Range", Description="Create a range of DividendBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendBarrierOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DividendBarrierOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DividendBarrierOption> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DividendBarrierOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DividendBarrierOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DividendBarrierOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"