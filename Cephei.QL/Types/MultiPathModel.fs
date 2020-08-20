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
  MultiPath contains the list of paths for each asset, i.e., multipath[j] is the path followed by the j-th asset.  mcarlo

  </summary> *)
[<AutoSerializable(true)>]
type MultiPathModel
    ( nAsset                                       : ICell<int>
    , timeGrid                                     : ICell<TimeGrid>
    ) as this =

    inherit Model<MultiPath> ()
(*
    Parameters
*)
    let _nAsset                                    = nAsset
    let _timeGrid                                  = timeGrid
(*
    Functions
*)
    let _MultiPath                                 = cell (fun () -> new MultiPath (nAsset.Value, timeGrid.Value))
    let _assetNumber                               = cell (fun () -> _MultiPath.Value.assetNumber())
    let _Clone                                     = cell (fun () -> _MultiPath.Value.Clone())
    let _length                                    = cell (fun () -> _MultiPath.Value.length())
    let _pathSize                                  = cell (fun () -> _MultiPath.Value.pathSize())
    let _this                                      (j : ICell<int>)   
                                                   = cell (fun () -> _MultiPath.Value.[j.Value])
    do this.Bind(_MultiPath)

(* 
    Externally visible/bindable properties
*)
    member this.nAsset                             = _nAsset 
    member this.timeGrid                           = _timeGrid 
    member this.AssetNumber                        = _assetNumber
    member this.Clone                              = _Clone
    member this.Length                             = _length
    member this.PathSize                           = _pathSize
    member this.This                               j   
                                                   = _this j 
(* <summary>
  MultiPath contains the list of paths for each asset, i.e., multipath[j] is the path followed by the j-th asset.  mcarlo

  </summary> *)
[<AutoSerializable(true)>]
type MultiPathModel1
    () as this =
    inherit Model<MultiPath> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _MultiPath                                 = cell (fun () -> new MultiPath ())
    let _assetNumber                               = cell (fun () -> _MultiPath.Value.assetNumber())
    let _Clone                                     = cell (fun () -> _MultiPath.Value.Clone())
    let _length                                    = cell (fun () -> _MultiPath.Value.length())
    let _pathSize                                  = cell (fun () -> _MultiPath.Value.pathSize())
    let _this                                      (j : ICell<int>)   
                                                   = cell (fun () -> _MultiPath.Value.[j.Value])
    do this.Bind(_MultiPath)

(* 
    Externally visible/bindable properties
*)
    member this.AssetNumber                        = _assetNumber
    member this.Clone                              = _Clone
    member this.Length                             = _length
    member this.PathSize                           = _pathSize
    member this.This                               j   
                                                   = _this j 
(* <summary>
  MultiPath contains the list of paths for each asset, i.e., multipath[j] is the path followed by the j-th asset.  mcarlo

  </summary> *)
[<AutoSerializable(true)>]
type MultiPathModel2
    ( multiPath                                    : ICell<Generic.List<Path>>
    ) as this =

    inherit Model<MultiPath> ()
(*
    Parameters
*)
    let _multiPath                                 = multiPath
(*
    Functions
*)
    let _MultiPath                                 = cell (fun () -> new MultiPath (multiPath.Value))
    let _assetNumber                               = cell (fun () -> _MultiPath.Value.assetNumber())
    let _Clone                                     = cell (fun () -> _MultiPath.Value.Clone())
    let _length                                    = cell (fun () -> _MultiPath.Value.length())
    let _pathSize                                  = cell (fun () -> _MultiPath.Value.pathSize())
    let _this                                      (j : ICell<int>)   
                                                   = cell (fun () -> _MultiPath.Value.[j.Value])
    do this.Bind(_MultiPath)

(* 
    Externally visible/bindable properties
*)
    member this.multiPath                          = _multiPath 
    member this.AssetNumber                        = _assetNumber
    member this.Clone                              = _Clone
    member this.Length                             = _length
    member this.PathSize                           = _pathSize
    member this.This                               j   
                                                   = _this j 