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
  See <http://en.wikipedia.org/wiki/BFGS_method>.  Adapted from Numerical Recipes in C, 2nd edition.  User has to provide line-search method and optimization end criteria.

  </summary> *)
[<AutoSerializable(true)>]
type BFGSModel
    ( lineSearch                                   : ICell<LineSearch>
    ) as this =

    inherit Model<BFGS> ()
(*
    Parameters
*)
    let _lineSearch                                = lineSearch
(*
    Functions
*)
    let _BFGS                                      = cell (fun () -> new BFGS (lineSearch.Value))
    let _minimize                                  (P : ICell<Problem>) (endCriteria : ICell<EndCriteria>)   
                                                   = triv (fun () -> _BFGS.Value.minimize(P.Value, endCriteria.Value))
    do this.Bind(_BFGS)

(* 
    Externally visible/bindable properties
*)
    member this.lineSearch                         = _lineSearch 
    member this.Minimize                           P endCriteria   
                                                   = _minimize P endCriteria 
