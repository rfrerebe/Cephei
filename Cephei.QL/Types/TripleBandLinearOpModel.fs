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
type TripleBandLinearOpModel
    ( m                                            : ICell<TripleBandLinearOp>
    ) as this =

    inherit Model<TripleBandLinearOp> ()
(*
    Parameters
*)
    let _m                                         = m
(*
    Functions
*)
    let _TripleBandLinearOp                        = cell (fun () -> new TripleBandLinearOp (m.Value))
    let _add                                       (m : ICell<TripleBandLinearOp>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.add(m.Value))
    let _add1                                      (u : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.add(u.Value))
    let _add2                                      (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.add(A.Value, B.Value))
    let _apply                                     (r : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.apply(r.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.applyTo(v.Value))
    let _axpyb                                     (a : ICell<Vector>) (x : ICell<TripleBandLinearOp>) (y : ICell<TripleBandLinearOp>) (b : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.axpyb(a.Value, x.Value, y.Value, b.Value)
                                                                     _TripleBandLinearOp.Value)
    let _Clone                                     = cell (fun () -> _TripleBandLinearOp.Value.Clone())
    let _identity                                  (size : ICell<int>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.identity(size.Value))
    let _isTimeDependent                           = cell (fun () -> _TripleBandLinearOp.Value.isTimeDependent())
    let _mult                                      (u : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.mult(u.Value))
    let _multiply                                  (a : ICell<double>) (D : ICell<IOperator>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.multiply(a.Value, D.Value))
    let _multR                                     (u : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.multR(u.Value))
    let _setTime                                   (t : ICell<double>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.setTime(t.Value)
                                                                     _TripleBandLinearOp.Value)
    let _size                                      = cell (fun () -> _TripleBandLinearOp.Value.size())
    let _solve_splitting                           (r : ICell<Vector>) (a : ICell<double>) (b : ICell<double>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.solve_splitting(r.Value, a.Value, b.Value))
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.solveFor(rhs.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.subtract(A.Value, B.Value))
    let _swap                                      (m : ICell<TripleBandLinearOp>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.swap(m.Value)
                                                                     _TripleBandLinearOp.Value)
    let _toMatrix                                  = cell (fun () -> _TripleBandLinearOp.Value.toMatrix())
    do this.Bind(_TripleBandLinearOp)

(* 
    Externally visible/bindable properties
*)
    member this.m                                  = _m 
    member this.Add                                m   
                                                   = _add m 
    member this.Add1                               u   
                                                   = _add1 u 
    member this.Add2                               A B   
                                                   = _add2 A B 
    member this.Apply                              r   
                                                   = _apply r 
    member this.ApplyTo                            v   
                                                   = _applyTo v 
    member this.Axpyb                              a x y b   
                                                   = _axpyb a x y b 
    member this.Clone                              = _Clone
    member this.Identity                           size   
                                                   = _identity size 
    member this.IsTimeDependent                    = _isTimeDependent
    member this.Mult                               u   
                                                   = _mult u 
    member this.Multiply                           a D   
                                                   = _multiply a D 
    member this.MultR                              u   
                                                   = _multR u 
    member this.SetTime                            t   
                                                   = _setTime t 
    member this.Size                               = _size
    member this.Solve_splitting                    r a b   
                                                   = _solve_splitting r a b 
    member this.SolveFor                           rhs   
                                                   = _solveFor rhs 
    member this.Subtract                           A B   
                                                   = _subtract A B 
    member this.Swap                               m   
                                                   = _swap m 
    member this.ToMatrix                           = _toMatrix
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type TripleBandLinearOpModel1
    ( direction                                    : ICell<int>
    , mesher                                       : ICell<FdmMesher>
    ) as this =

    inherit Model<TripleBandLinearOp> ()
(*
    Parameters
*)
    let _direction                                 = direction
    let _mesher                                    = mesher
(*
    Functions
*)
    let _TripleBandLinearOp                        = cell (fun () -> new TripleBandLinearOp (direction.Value, mesher.Value))
    let _add                                       (m : ICell<TripleBandLinearOp>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.add(m.Value))
    let _add1                                      (u : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.add(u.Value))
    let _add2                                      (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.add(A.Value, B.Value))
    let _apply                                     (r : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.apply(r.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.applyTo(v.Value))
    let _axpyb                                     (a : ICell<Vector>) (x : ICell<TripleBandLinearOp>) (y : ICell<TripleBandLinearOp>) (b : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.axpyb(a.Value, x.Value, y.Value, b.Value)
                                                                     _TripleBandLinearOp.Value)
    let _Clone                                     = cell (fun () -> _TripleBandLinearOp.Value.Clone())
    let _identity                                  (size : ICell<int>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.identity(size.Value))
    let _isTimeDependent                           = cell (fun () -> _TripleBandLinearOp.Value.isTimeDependent())
    let _mult                                      (u : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.mult(u.Value))
    let _multiply                                  (a : ICell<double>) (D : ICell<IOperator>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.multiply(a.Value, D.Value))
    let _multR                                     (u : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.multR(u.Value))
    let _setTime                                   (t : ICell<double>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.setTime(t.Value)
                                                                     _TripleBandLinearOp.Value)
    let _size                                      = cell (fun () -> _TripleBandLinearOp.Value.size())
    let _solve_splitting                           (r : ICell<Vector>) (a : ICell<double>) (b : ICell<double>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.solve_splitting(r.Value, a.Value, b.Value))
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.solveFor(rhs.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.subtract(A.Value, B.Value))
    let _swap                                      (m : ICell<TripleBandLinearOp>)   
                                                   = cell (fun () -> _TripleBandLinearOp.Value.swap(m.Value)
                                                                     _TripleBandLinearOp.Value)
    let _toMatrix                                  = cell (fun () -> _TripleBandLinearOp.Value.toMatrix())
    do this.Bind(_TripleBandLinearOp)

(* 
    Externally visible/bindable properties
*)
    member this.direction                          = _direction 
    member this.mesher                             = _mesher 
    member this.Add                                m   
                                                   = _add m 
    member this.Add1                               u   
                                                   = _add1 u 
    member this.Add2                               A B   
                                                   = _add2 A B 
    member this.Apply                              r   
                                                   = _apply r 
    member this.ApplyTo                            v   
                                                   = _applyTo v 
    member this.Axpyb                              a x y b   
                                                   = _axpyb a x y b 
    member this.Clone                              = _Clone
    member this.Identity                           size   
                                                   = _identity size 
    member this.IsTimeDependent                    = _isTimeDependent
    member this.Mult                               u   
                                                   = _mult u 
    member this.Multiply                           a D   
                                                   = _multiply a D 
    member this.MultR                              u   
                                                   = _multR u 
    member this.SetTime                            t   
                                                   = _setTime t 
    member this.Size                               = _size
    member this.Solve_splitting                    r a b   
                                                   = _solve_splitting r a b 
    member this.SolveFor                           rhs   
                                                   = _solveFor rhs 
    member this.Subtract                           A B   
                                                   = _subtract A B 
    member this.Swap                               m   
                                                   = _swap m 
    member this.ToMatrix                           = _toMatrix