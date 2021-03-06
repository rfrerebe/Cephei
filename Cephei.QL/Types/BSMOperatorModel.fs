﻿(*
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
  findiff

  </summary> *)
[<AutoSerializable(true)>]
type BSMOperatorModel
    ( size                                         : ICell<int>
    , dx                                           : ICell<double>
    , r                                            : ICell<double>
    , q                                            : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<BSMOperator> ()
(*
    Parameters
*)
    let _size                                      = size
    let _dx                                        = dx
    let _r                                         = r
    let _q                                         = q
    let _sigma                                     = sigma
(*
    Functions
*)
    let mutable
        _BSMOperator                               = cell (fun () -> new BSMOperator (size.Value, dx.Value, r.Value, q.Value, sigma.Value))
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _BSMOperator.Value.add(A.Value, B.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = triv (fun () -> _BSMOperator.Value.applyTo(v.Value))
    let _Clone                                     = triv (fun () -> _BSMOperator.Value.Clone())
    let _diagonal                                  = triv (fun () -> _BSMOperator.Value.diagonal())
    let _identity                                  (size : ICell<int>)   
                                                   = triv (fun () -> _BSMOperator.Value.identity(size.Value))
    let _isTimeDependent                           = triv (fun () -> _BSMOperator.Value.isTimeDependent())
    let _lowerDiagonal                             = triv (fun () -> _BSMOperator.Value.lowerDiagonal())
    let _multiply                                  (a : ICell<double>) (o : ICell<IOperator>)   
                                                   = triv (fun () -> _BSMOperator.Value.multiply(a.Value, o.Value))
    let _setFirstRow                               (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setFirstRow(valB.Value, valC.Value)
                                                                     _BSMOperator.Value)
    let _setLastRow                                (valA : ICell<double>) (valB : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setLastRow(valA.Value, valB.Value)
                                                                     _BSMOperator.Value)
    let _setMidRow                                 (i : ICell<int>) (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setMidRow(i.Value, valA.Value, valB.Value, valC.Value)
                                                                     _BSMOperator.Value)
    let _setMidRows                                (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setMidRows(valA.Value, valB.Value, valC.Value)
                                                                     _BSMOperator.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setTime(t.Value)
                                                                     _BSMOperator.Value)
    let _size                                      = triv (fun () -> _BSMOperator.Value.size())
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = triv (fun () -> _BSMOperator.Value.solveFor(rhs.Value))
    let _SOR                                       (rhs : ICell<Vector>) (tol : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.SOR(rhs.Value, tol.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _BSMOperator.Value.subtract(A.Value, B.Value))
    let _upperDiagonal                             = triv (fun () -> _BSMOperator.Value.upperDiagonal())
    do this.Bind(_BSMOperator)
(* 
    casting 
*)
    internal new () = new BSMOperatorModel(null,null,null,null,null)
    member internal this.Inject v = _BSMOperator <- v
    static member Cast (p : ICell<BSMOperator>) = 
        if p :? BSMOperatorModel then 
            p :?> BSMOperatorModel
        else
            let o = new BSMOperatorModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.dx                                 = _dx 
    member this.r                                  = _r 
    member this.q                                  = _q 
    member this.sigma                              = _sigma 
    member this.Add                                A B   
                                                   = _add A B 
    member this.ApplyTo                            v   
                                                   = _applyTo v 
    member this.Clone                              = _Clone
    member this.Diagonal                           = _diagonal
    member this.Identity                           size   
                                                   = _identity size 
    member this.IsTimeDependent                    = _isTimeDependent
    member this.LowerDiagonal                      = _lowerDiagonal
    member this.Multiply                           a o   
                                                   = _multiply a o 
    member this.SetFirstRow                        valB valC   
                                                   = _setFirstRow valB valC 
    member this.SetLastRow                         valA valB   
                                                   = _setLastRow valA valB 
    member this.SetMidRow                          i valA valB valC   
                                                   = _setMidRow i valA valB valC 
    member this.SetMidRows                         valA valB valC   
                                                   = _setMidRows valA valB valC 
    member this.SetTime                            t   
                                                   = _setTime t 
    member this.Size                               = _size
    member this.SolveFor                           rhs   
                                                   = _solveFor rhs 
    member this.SOR                                rhs tol   
                                                   = _SOR rhs tol 
    member this.Subtract                           A B   
                                                   = _subtract A B 
    member this.UpperDiagonal                      = _upperDiagonal
(* <summary>
  findiff

  </summary> *)
[<AutoSerializable(true)>]
type BSMOperatorModel1
    ( grid                                         : ICell<Vector>
    , Process                                      : ICell<GeneralizedBlackScholesProcess>
    , residualTime                                 : ICell<double>
    ) as this =

    inherit Model<BSMOperator> ()
(*
    Parameters
*)
    let _grid                                      = grid
    let _Process                                   = Process
    let _residualTime                              = residualTime
(*
    Functions
*)
    let mutable
        _BSMOperator                               = cell (fun () -> new BSMOperator (grid.Value, Process.Value, residualTime.Value))
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _BSMOperator.Value.add(A.Value, B.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = triv (fun () -> _BSMOperator.Value.applyTo(v.Value))
    let _Clone                                     = triv (fun () -> _BSMOperator.Value.Clone())
    let _diagonal                                  = triv (fun () -> _BSMOperator.Value.diagonal())
    let _identity                                  (size : ICell<int>)   
                                                   = triv (fun () -> _BSMOperator.Value.identity(size.Value))
    let _isTimeDependent                           = triv (fun () -> _BSMOperator.Value.isTimeDependent())
    let _lowerDiagonal                             = triv (fun () -> _BSMOperator.Value.lowerDiagonal())
    let _multiply                                  (a : ICell<double>) (o : ICell<IOperator>)   
                                                   = triv (fun () -> _BSMOperator.Value.multiply(a.Value, o.Value))
    let _setFirstRow                               (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setFirstRow(valB.Value, valC.Value)
                                                                     _BSMOperator.Value)
    let _setLastRow                                (valA : ICell<double>) (valB : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setLastRow(valA.Value, valB.Value)
                                                                     _BSMOperator.Value)
    let _setMidRow                                 (i : ICell<int>) (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setMidRow(i.Value, valA.Value, valB.Value, valC.Value)
                                                                     _BSMOperator.Value)
    let _setMidRows                                (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setMidRows(valA.Value, valB.Value, valC.Value)
                                                                     _BSMOperator.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setTime(t.Value)
                                                                     _BSMOperator.Value)
    let _size                                      = triv (fun () -> _BSMOperator.Value.size())
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = triv (fun () -> _BSMOperator.Value.solveFor(rhs.Value))
    let _SOR                                       (rhs : ICell<Vector>) (tol : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.SOR(rhs.Value, tol.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _BSMOperator.Value.subtract(A.Value, B.Value))
    let _upperDiagonal                             = triv (fun () -> _BSMOperator.Value.upperDiagonal())
    do this.Bind(_BSMOperator)
(* 
    casting 
*)
    internal new () = new BSMOperatorModel1(null,null,null)
    member internal this.Inject v = _BSMOperator <- v
    static member Cast (p : ICell<BSMOperator>) = 
        if p :? BSMOperatorModel1 then 
            p :?> BSMOperatorModel1
        else
            let o = new BSMOperatorModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.grid                               = _grid 
    member this.Process                            = _Process 
    member this.residualTime                       = _residualTime 
    member this.Add                                A B   
                                                   = _add A B 
    member this.ApplyTo                            v   
                                                   = _applyTo v 
    member this.Clone                              = _Clone
    member this.Diagonal                           = _diagonal
    member this.Identity                           size   
                                                   = _identity size 
    member this.IsTimeDependent                    = _isTimeDependent
    member this.LowerDiagonal                      = _lowerDiagonal
    member this.Multiply                           a o   
                                                   = _multiply a o 
    member this.SetFirstRow                        valB valC   
                                                   = _setFirstRow valB valC 
    member this.SetLastRow                         valA valB   
                                                   = _setLastRow valA valB 
    member this.SetMidRow                          i valA valB valC   
                                                   = _setMidRow i valA valB valC 
    member this.SetMidRows                         valA valB valC   
                                                   = _setMidRows valA valB valC 
    member this.SetTime                            t   
                                                   = _setTime t 
    member this.Size                               = _size
    member this.SolveFor                           rhs   
                                                   = _solveFor rhs 
    member this.SOR                                rhs tol   
                                                   = _SOR rhs tol 
    member this.Subtract                           A B   
                                                   = _subtract A B 
    member this.UpperDiagonal                      = _upperDiagonal
(* <summary>
  findiff

  </summary> *)
[<AutoSerializable(true)>]
type BSMOperatorModel2
    () as this =
    inherit Model<BSMOperator> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _BSMOperator                               = cell (fun () -> new BSMOperator ())
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _BSMOperator.Value.add(A.Value, B.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = triv (fun () -> _BSMOperator.Value.applyTo(v.Value))
    let _Clone                                     = triv (fun () -> _BSMOperator.Value.Clone())
    let _diagonal                                  = triv (fun () -> _BSMOperator.Value.diagonal())
    let _identity                                  (size : ICell<int>)   
                                                   = triv (fun () -> _BSMOperator.Value.identity(size.Value))
    let _isTimeDependent                           = triv (fun () -> _BSMOperator.Value.isTimeDependent())
    let _lowerDiagonal                             = triv (fun () -> _BSMOperator.Value.lowerDiagonal())
    let _multiply                                  (a : ICell<double>) (o : ICell<IOperator>)   
                                                   = triv (fun () -> _BSMOperator.Value.multiply(a.Value, o.Value))
    let _setFirstRow                               (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setFirstRow(valB.Value, valC.Value)
                                                                     _BSMOperator.Value)
    let _setLastRow                                (valA : ICell<double>) (valB : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setLastRow(valA.Value, valB.Value)
                                                                     _BSMOperator.Value)
    let _setMidRow                                 (i : ICell<int>) (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setMidRow(i.Value, valA.Value, valB.Value, valC.Value)
                                                                     _BSMOperator.Value)
    let _setMidRows                                (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setMidRows(valA.Value, valB.Value, valC.Value)
                                                                     _BSMOperator.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.setTime(t.Value)
                                                                     _BSMOperator.Value)
    let _size                                      = triv (fun () -> _BSMOperator.Value.size())
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = triv (fun () -> _BSMOperator.Value.solveFor(rhs.Value))
    let _SOR                                       (rhs : ICell<Vector>) (tol : ICell<double>)   
                                                   = triv (fun () -> _BSMOperator.Value.SOR(rhs.Value, tol.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _BSMOperator.Value.subtract(A.Value, B.Value))
    let _upperDiagonal                             = triv (fun () -> _BSMOperator.Value.upperDiagonal())
    do this.Bind(_BSMOperator)
(* 
    casting 
*)
    
    member internal this.Inject v = _BSMOperator <- v
    static member Cast (p : ICell<BSMOperator>) = 
        if p :? BSMOperatorModel2 then 
            p :?> BSMOperatorModel2
        else
            let o = new BSMOperatorModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Add                                A B   
                                                   = _add A B 
    member this.ApplyTo                            v   
                                                   = _applyTo v 
    member this.Clone                              = _Clone
    member this.Diagonal                           = _diagonal
    member this.Identity                           size   
                                                   = _identity size 
    member this.IsTimeDependent                    = _isTimeDependent
    member this.LowerDiagonal                      = _lowerDiagonal
    member this.Multiply                           a o   
                                                   = _multiply a o 
    member this.SetFirstRow                        valB valC   
                                                   = _setFirstRow valB valC 
    member this.SetLastRow                         valA valB   
                                                   = _setLastRow valA valB 
    member this.SetMidRow                          i valA valB valC   
                                                   = _setMidRow i valA valB valC 
    member this.SetMidRows                         valA valB valC   
                                                   = _setMidRows valA valB valC 
    member this.SetTime                            t   
                                                   = _setTime t 
    member this.Size                               = _size
    member this.SolveFor                           rhs   
                                                   = _solveFor rhs 
    member this.SOR                                rhs tol   
                                                   = _SOR rhs tol 
    member this.Subtract                           A B   
                                                   = _subtract A B 
    member this.UpperDiagonal                      = _upperDiagonal
