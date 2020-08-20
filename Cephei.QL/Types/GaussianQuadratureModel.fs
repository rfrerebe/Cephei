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
  References: Gauss quadratures and orthogonal polynomials  G.H. Gloub and J.H. Welsch: Calculation of Gauss quadrature rule. Math. Comput. 23 (1986), 221-230  "Numerical Recipes in C", 2nd edition, Press, Teukolsky, Vetterling, Flannery,  the correctness of the result is tested by checking it against known good values.

  </summary> *)
[<AutoSerializable(true)>]
type GaussianQuadratureModel
    ( n                                            : ICell<int>
    , orthPoly                                     : ICell<GaussianOrthogonalPolynomial>
    ) as this =

    inherit Model<GaussianQuadrature> ()
(*
    Parameters
*)
    let _n                                         = n
    let _orthPoly                                  = orthPoly
(*
    Functions
*)
    let _GaussianQuadrature                        = cell (fun () -> new GaussianQuadrature (n.Value, orthPoly.Value))
    let _order                                     = cell (fun () -> _GaussianQuadrature.Value.order())
    let _value                                     (f : ICell<Func<double,double>>)   
                                                   = cell (fun () -> _GaussianQuadrature.Value.value(f.Value))
    let _weights                                   = cell (fun () -> _GaussianQuadrature.Value.weights())
    let _x                                         = cell (fun () -> _GaussianQuadrature.Value.x())
    do this.Bind(_GaussianQuadrature)

(* 
    Externally visible/bindable properties
*)
    member this.n                                  = _n 
    member this.orthPoly                           = _orthPoly 
    member this.Order                              = _order
    member this.Value                              f   
                                                   = _value f 
    member this.Weights                            = _weights
    member this.X                                  = _x