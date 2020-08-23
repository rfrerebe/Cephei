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
  This engine only adds timing functionality (e.g. different lag)   w.r.t. an existing interpolated price surface.

  </summary> *)
[<AutoSerializable(true)>]
type InterpolatingCPICapFloorEngineModel
    ( priceSurf                                    : ICell<Handle<CPICapFloorTermPriceSurface>>
    ) as this =

    inherit Model<InterpolatingCPICapFloorEngine> ()
(*
    Parameters
*)
    let _priceSurf                                 = priceSurf
(*
    Functions
*)
    let _InterpolatingCPICapFloorEngine            = cell (fun () -> new InterpolatingCPICapFloorEngine (priceSurf.Value))
    let _name                                      = triv (fun () -> _InterpolatingCPICapFloorEngine.Value.name())
    do this.Bind(_InterpolatingCPICapFloorEngine)

(* 
    Externally visible/bindable properties
*)
    member this.priceSurf                          = _priceSurf 
    member this.Name                               = _name
