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

! Constructor where the client code is responsible for providing a default curve and an interest rate curve compliant with the ISDA specifications.  To be precisely consistent with the ISDA specification QL_USE_INDEXED_COUPON must not be defined. This is not checked in order not to kill the engine completely in this case.  Furthermore, the ibor index in the swap rate helpers should not provide the evaluation date's fixing.
  </summary> *)
[<AutoSerializable(true)>]
type IsdaCdsEngineModel
    ( probability                                  : ICell<Handle<DefaultProbabilityTermStructure>>
    , recoveryRate                                 : ICell<double>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    , includeSettlementDateFlows                   : ICell<Nullable<bool>>
    , numericalFix                                 : ICell<IsdaCdsEngine.NumericalFix>
    , accrualBias                                  : ICell<IsdaCdsEngine.AccrualBias>
    , forwardsInCouponPeriod                       : ICell<IsdaCdsEngine.ForwardsInCouponPeriod>
    ) as this =

    inherit Model<IsdaCdsEngine> ()
(*
    Parameters
*)
    let _probability                               = probability
    let _recoveryRate                              = recoveryRate
    let _discountCurve                             = discountCurve
    let _includeSettlementDateFlows                = includeSettlementDateFlows
    let _numericalFix                              = numericalFix
    let _accrualBias                               = accrualBias
    let _forwardsInCouponPeriod                    = forwardsInCouponPeriod
(*
    Functions
*)
    let _IsdaCdsEngine                             = cell (fun () -> new IsdaCdsEngine (probability.Value, recoveryRate.Value, discountCurve.Value, includeSettlementDateFlows.Value, numericalFix.Value, accrualBias.Value, forwardsInCouponPeriod.Value))
    let _calculate                                 = cell (fun () -> _IsdaCdsEngine.Value.calculate()
                                                                     _IsdaCdsEngine.Value)
    let _isdaCreditCurve                           = cell (fun () -> _IsdaCdsEngine.Value.isdaCreditCurve())
    let _isdaRateCurve                             = cell (fun () -> _IsdaCdsEngine.Value.isdaRateCurve())
    do this.Bind(_IsdaCdsEngine)

(* 
    Externally visible/bindable properties
*)
    member this.probability                        = _probability 
    member this.recoveryRate                       = _recoveryRate 
    member this.discountCurve                      = _discountCurve 
    member this.includeSettlementDateFlows         = _includeSettlementDateFlows 
    member this.numericalFix                       = _numericalFix 
    member this.accrualBias                        = _accrualBias 
    member this.forwardsInCouponPeriod             = _forwardsInCouponPeriod 
    member this.Calculate                          = _calculate
    member this.IsdaCreditCurve                    = _isdaCreditCurve
    member this.IsdaRateCurve                      = _isdaRateCurve