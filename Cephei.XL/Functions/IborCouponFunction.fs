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
Coupon paying a Libor-type index
  </summary> *)
[<AutoSerializable(true)>]
module IborCouponFunction =

    (*
        Factory - for Leg generators
    *)
    [<ExcelFunction(Name="_IborCoupon_factory", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="paymentDate",Description = "Reference to paymentDate")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        ([<ExcelArgument(Name="endDate",Description = "Reference to endDate")>] 
         endDate : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="gearing",Description = "Reference to gearing")>] 
         gearing : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Reference to refPeriodStart")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Reference to refPeriodEnd")>] 
         refPeriodEnd : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="isInArrears",Description = "Reference to isInArrears")>] 
         isInArrears : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _index = Helper.toCell<InterestRateIndex> index "index" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _dayCounter = Helper.toDefault<DayCounter> dayCounter "dayCounter" null
                let _isInArrears = Helper.toDefault<bool> isInArrears "isInArrears" false
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Factory
                                                            _nominal.cell 
                                                            _paymentDate.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _fixingDays.cell 
                                                            _index.cell 
                                                            _gearing.cell 
                                                            _spread.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _dayCounter.cell 
                                                            _isInArrears.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_IborCoupon.source + ".Factory") 
                                               [| _IborCoupon.source
                                               ;  _nominal.source
                                               ;  _paymentDate.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _fixingDays.source
                                               ;  _index.source
                                               ;  _gearing.source
                                               ;  _spread.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               ;  _dayCounter.source
                                               ;  _isInArrears.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _nominal.cell
                                ;  _paymentDate.cell
                                ;  _startDate.cell
                                ;  _endDate.cell
                                ;  _fixingDays.cell
                                ;  _index.cell
                                ;  _gearing.cell
                                ;  _spread.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                ;  _dayCounter.cell
                                ;  _isInArrears.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborCoupon", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="paymentDate",Description = "Reference to paymentDate")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        ([<ExcelArgument(Name="endDate",Description = "Reference to endDate")>] 
         endDate : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "Reference to iborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="gearing",Description = "Reference to gearing")>] 
         gearing : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Reference to refPeriodStart")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Reference to refPeriodEnd")>] 
         refPeriodEnd : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="isInArrears",Description = "Reference to isInArrears")>] 
         isInArrears : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _dayCounter = Helper.toDefault<DayCounter> dayCounter "dayCounter" null
                let _isInArrears = Helper.toDefault<bool> isInArrears "isInArrears" false
                let builder () = withMnemonic mnemonic (Fun.IborCoupon 
                                                            _paymentDate.cell 
                                                            _nominal.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _fixingDays.cell 
                                                            _iborIndex.cell 
                                                            _gearing.cell 
                                                            _spread.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _dayCounter.cell 
                                                            _isInArrears.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborCoupon>) l

                let source = Helper.sourceFold "Fun.IborCoupon" 
                                               [| _paymentDate.source
                                               ;  _nominal.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _fixingDays.source
                                               ;  _iborIndex.source
                                               ;  _gearing.source
                                               ;  _spread.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               ;  _dayCounter.source
                                               ;  _isInArrears.source
                                               |]
                let hash = Helper.hashFold 
                                [| _paymentDate.cell
                                ;  _nominal.cell
                                ;  _startDate.cell
                                ;  _endDate.cell
                                ;  _fixingDays.cell
                                ;  _iborIndex.cell
                                ;  _gearing.cell
                                ;  _spread.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                ;  _dayCounter.cell
                                ;  _isInArrears.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborCoupon1", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.IborCoupon1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborCoupon>) l

                let source = Helper.sourceFold "Fun.IborCoupon1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_IborCoupon_iborIndex", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_IborCoupon.source + ".IborIndex") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! FloatingRateCoupon interface ! Implemented in order to manage the case of par coupon
    *)
    [<ExcelFunction(Name="_IborCoupon_indexFixing", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".IndexFixing") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
    [<ExcelFunction(Name="_IborCoupon_accruedAmount", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".AccruedAmount") 
                                               [| _IborCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _d.cell
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
        ! convexity-adjusted fixing
    *)
    [<ExcelFunction(Name="_IborCoupon_adjustedFixing", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".AdjustedFixing") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_IborCoupon_amount", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".Amount") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        ! convexity adjustment
    *)
    [<ExcelFunction(Name="_IborCoupon_convexityAdjustment", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".ConvexityAdjustment") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
    [<ExcelFunction(Name="_IborCoupon_dayCounter", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_IborCoupon.source + ".DayCounter") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! fixing days
    *)
    [<ExcelFunction(Name="_IborCoupon_fixingDate", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".FixingDate") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        ! floating index
    *)
    [<ExcelFunction(Name="_IborCoupon_fixingDays", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".FixingDays") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
    [<ExcelFunction(Name="_IborCoupon_gearing", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".Gearing") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        properties
    *)
    [<ExcelFunction(Name="_IborCoupon_index", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_IborCoupon.source + ".Index") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! whether or not the coupon fixes in arrears
    *)
    [<ExcelFunction(Name="_IborCoupon_isInArrears", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".IsInArrears") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        methods
    *)
    [<ExcelFunction(Name="_IborCoupon_price", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".Price") 
                                               [| _IborCoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _yts.cell
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
    [<ExcelFunction(Name="_IborCoupon_pricer", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source = Helper.sourceFold (_IborCoupon.source + ".Pricer") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Coupon interface
    *)
    [<ExcelFunction(Name="_IborCoupon_rate", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".Rate") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
    [<ExcelFunction(Name="_IborCoupon_setPricer", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : IborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".SetPricer") 
                                               [| _IborCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _pricer.cell
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
        ! index gearing, i.e. multiplicative coefficient for the index
    *)
    [<ExcelFunction(Name="_IborCoupon_spread", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".Spread") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_IborCoupon_update", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Update
                                                       ) :> ICell
                let format (o : IborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".Update") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        ! accrual period in days
    *)
    [<ExcelFunction(Name="_IborCoupon_accrualDays", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".AccrualDays") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        ! end of the accrual period
    *)
    [<ExcelFunction(Name="_IborCoupon_accrualEndDate", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".AccrualEndDate") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        ! accrual period as fraction of year
    *)
    [<ExcelFunction(Name="_IborCoupon_accrualPeriod", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".AccrualPeriod") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        ! start of the accrual period
    *)
    [<ExcelFunction(Name="_IborCoupon_accrualStartDate", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".AccrualStartDate") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        ! accrued days at the given date
    *)
    [<ExcelFunction(Name="_IborCoupon_accruedDays", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".AccruedDays") 
                                               [| _IborCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _d.cell
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
        ! accrued period as fraction of year at the given date
    *)
    [<ExcelFunction(Name="_IborCoupon_accruedPeriod", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".AccruedPeriod") 
                                               [| _IborCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _d.cell
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
        Event interface
    *)
    [<ExcelFunction(Name="_IborCoupon_date", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".Date") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_IborCoupon_exCouponDate", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".ExCouponDate") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_IborCoupon_nominal", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".Nominal") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        ! end date of the reference period
    *)
    [<ExcelFunction(Name="_IborCoupon_referencePeriodEnd", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".ReferencePeriodEnd") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
        ! start date of the reference period
    *)
    [<ExcelFunction(Name="_IborCoupon_referencePeriodStart", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".ReferencePeriodStart") 
                                               [| _IborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
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
    [<ExcelFunction(Name="_IborCoupon_CompareTo", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".CompareTo") 
                                               [| _IborCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_IborCoupon_Equals", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".Equals") 
                                               [| _IborCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_IborCoupon_hasOccurred", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".HasOccurred") 
                                               [| _IborCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _refDate.cell
                                ;  _includeRefDate.cell
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
        ! returns true if the cashflow is trading ex-coupon on the refDate
    *)
    [<ExcelFunction(Name="_IborCoupon_tradingExCoupon", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".TradingExCoupon") 
                                               [| _IborCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _refDate.cell
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
    [<ExcelFunction(Name="_IborCoupon_accept", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : IborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".Accept") 
                                               [| _IborCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_IborCoupon_registerWith", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : IborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".RegisterWith") 
                                               [| _IborCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_IborCoupon_unregisterWith", Description="Create a IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborCoupon",Description = "Reference to IborCoupon")>] 
         iborcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborCoupon = Helper.toCell<IborCoupon> iborcoupon "IborCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((IborCouponModel.Cast _IborCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : IborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborCoupon.source + ".UnregisterWith") 
                                               [| _IborCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborCoupon.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_IborCoupon_Range", Description="Create a range of IborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the IborCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IborCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<IborCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<IborCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<IborCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
