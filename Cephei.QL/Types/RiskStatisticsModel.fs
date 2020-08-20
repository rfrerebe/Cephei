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
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>
  the correctness of the returned values is tested by checking them against numerical calculations.
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type RiskStatisticsModel
    () as this =
    inherit Model<RiskStatistics> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _RiskStatistics                            = cell (fun () -> new RiskStatistics ())
    let _gaussianAverageShortfall                  (value : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.gaussianAverageShortfall(value.Value))
    let _gaussianDownsideVariance                  = cell (fun () -> _RiskStatistics.Value.gaussianDownsideVariance())
    let _gaussianExpectedShortfall                 (value : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.gaussianExpectedShortfall(value.Value))
    let _gaussianPercentile                        (value : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.gaussianPercentile(value.Value))
    let _gaussianPotentialUpside                   (value : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.gaussianPotentialUpside(value.Value))
    let _gaussianRegret                            (value : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.gaussianRegret(value.Value))
    let _gaussianShortfall                         (value : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.gaussianShortfall(value.Value))
    let _gaussianValueAtRisk                       (value : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.gaussianValueAtRisk(value.Value))
    let _add                                       (value : ICell<double>) (weight : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.add(value.Value, weight.Value)
                                                                     _RiskStatistics.Value)
    let _addSequence                               (data : ICell<Generic.List<double>>) (weight : ICell<Generic.List<double>>)   
                                                   = cell (fun () -> _RiskStatistics.Value.addSequence(data.Value, weight.Value)
                                                                     _RiskStatistics.Value)
    let _averageShortfall                          (target : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.averageShortfall(target.Value))
    let _downsideDeviation                         = cell (fun () -> _RiskStatistics.Value.downsideDeviation())
    let _downsideVariance                          = cell (fun () -> _RiskStatistics.Value.downsideVariance())
    let _errorEstimate                             = cell (fun () -> _RiskStatistics.Value.errorEstimate())
    let _expectationValue                          (f : ICell<Func<KeyValuePair<double,double>,double>>) (inRange : ICell<Func<KeyValuePair<double,double>,bool>>)   
                                                   = cell (fun () -> _RiskStatistics.Value.expectationValue(f.Value, inRange.Value))
    let _expectedShortfall                         (centile : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.expectedShortfall(centile.Value))
    let _kurtosis                                  = cell (fun () -> _RiskStatistics.Value.kurtosis())
    let _max                                       = cell (fun () -> _RiskStatistics.Value.max())
    let _mean                                      = cell (fun () -> _RiskStatistics.Value.mean())
    let _min                                       = cell (fun () -> _RiskStatistics.Value.min())
    let _percentile                                (percent : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.percentile(percent.Value))
    let _potentialUpside                           (centile : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.potentialUpside(centile.Value))
    let _regret                                    (target : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.regret(target.Value))
    let _reset                                     = cell (fun () -> _RiskStatistics.Value.reset()
                                                                     _RiskStatistics.Value)
    let _samples                                   = cell (fun () -> _RiskStatistics.Value.samples())
    let _semiDeviation                             = cell (fun () -> _RiskStatistics.Value.semiDeviation())
    let _semiVariance                              = cell (fun () -> _RiskStatistics.Value.semiVariance())
    let _shortfall                                 (target : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.shortfall(target.Value))
    let _skewness                                  = cell (fun () -> _RiskStatistics.Value.skewness())
    let _standardDeviation                         = cell (fun () -> _RiskStatistics.Value.standardDeviation())
    let _valueAtRisk                               (centile : ICell<double>)   
                                                   = cell (fun () -> _RiskStatistics.Value.valueAtRisk(centile.Value))
    let _variance                                  = cell (fun () -> _RiskStatistics.Value.variance())
    let _weightSum                                 = cell (fun () -> _RiskStatistics.Value.weightSum())
    do this.Bind(_RiskStatistics)

(* 
    Externally visible/bindable properties
*)
    member this.GaussianAverageShortfall           value   
                                                   = _gaussianAverageShortfall value 
    member this.GaussianDownsideVariance           = _gaussianDownsideVariance
    member this.GaussianExpectedShortfall          value   
                                                   = _gaussianExpectedShortfall value 
    member this.GaussianPercentile                 value   
                                                   = _gaussianPercentile value 
    member this.GaussianPotentialUpside            value   
                                                   = _gaussianPotentialUpside value 
    member this.GaussianRegret                     value   
                                                   = _gaussianRegret value 
    member this.GaussianShortfall                  value   
                                                   = _gaussianShortfall value 
    member this.GaussianValueAtRisk                value   
                                                   = _gaussianValueAtRisk value 
    member this.Add                                value weight   
                                                   = _add value weight 
    member this.AddSequence                        data weight   
                                                   = _addSequence data weight 
    member this.AverageShortfall                   target   
                                                   = _averageShortfall target 
    member this.DownsideDeviation                  = _downsideDeviation
    member this.DownsideVariance                   = _downsideVariance
    member this.ErrorEstimate                      = _errorEstimate
    member this.ExpectationValue                   f inRange   
                                                   = _expectationValue f inRange 
    member this.ExpectedShortfall                  centile   
                                                   = _expectedShortfall centile 
    member this.Kurtosis                           = _kurtosis
    member this.Max                                = _max
    member this.Mean                               = _mean
    member this.Min                                = _min
    member this.Percentile                         percent   
                                                   = _percentile percent 
    member this.PotentialUpside                    centile   
                                                   = _potentialUpside centile 
    member this.Regret                             target   
                                                   = _regret target 
    member this.Reset                              = _reset
    member this.Samples                            = _samples
    member this.SemiDeviation                      = _semiDeviation
    member this.SemiVariance                       = _semiVariance
    member this.Shortfall                          target   
                                                   = _shortfall target 
    member this.Skewness                           = _skewness
    member this.StandardDeviation                  = _standardDeviation
    member this.ValueAtRisk                        centile   
                                                   = _valueAtRisk centile 
    member this.Variance                           = _variance
    member this.WeightSum                          = _weightSum