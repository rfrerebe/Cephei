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


  </summary> *)
[<AutoSerializable(true)>]
type FdmMesherIntegralModel
    ( mesher                                       : ICell<FdmMesherComposite>
    , integrator1d                                 : ICell<Func<Vector,Vector,double>>
    ) as this =

    inherit Model<FdmMesherIntegral> ()
(*
    Parameters
*)
    let _mesher                                    = mesher
    let _integrator1d                              = integrator1d
(*
    Functions
*)
    let _FdmMesherIntegral                         = cell (fun () -> new FdmMesherIntegral (mesher.Value, integrator1d.Value))
    let _integrate                                 (f : ICell<Vector>)   
                                                   = triv (fun () -> _FdmMesherIntegral.Value.integrate(f.Value))
    do this.Bind(_FdmMesherIntegral)

(* 
    Externally visible/bindable properties
*)
    member this.mesher                             = _mesher 
    member this.integrator1d                       = _integrator1d 
    member this.Integrate                          f   
                                                   = _integrate f 
