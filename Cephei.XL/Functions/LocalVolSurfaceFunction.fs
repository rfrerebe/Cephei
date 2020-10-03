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
  For details about this implementation refer to "Stochastic Volatility and Local Volatility," in "Case Studies and Financial Modelling Course Notes," by Jim Gatheral, Fall Term, 2003  see www.math.nyu.edu/fellows_fin_math/gatheral/Lecture1_Fall02.pdf  this class is untested, probably unreliable.
  </summary> *)
[<AutoSerializable(true)>]
module LocalVolSurfaceFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LocalVolSurface_dayCounter", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_LocalVolSurface.source + ".DayCounter") 
                                               [| _LocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LocalVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LocalVolSurface1", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="blackTS",Description = "Reference to blackTS")>] 
         blackTS : obj)
        ([<ExcelArgument(Name="riskFreeTS",Description = "Reference to riskFreeTS")>] 
         riskFreeTS : obj)
        ([<ExcelArgument(Name="dividendTS",Description = "Reference to dividendTS")>] 
         dividendTS : obj)
        ([<ExcelArgument(Name="underlying",Description = "Reference to underlying")>] 
         underlying : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _blackTS = Helper.toHandle<BlackVolTermStructure> blackTS "blackTS" 
                let _riskFreeTS = Helper.toHandle<YieldTermStructure> riskFreeTS "riskFreeTS" 
                let _dividendTS = Helper.toHandle<YieldTermStructure> dividendTS "dividendTS" 
                let _underlying = Helper.toCell<double> underlying "underlying" 
                let builder () = withMnemonic mnemonic (Fun.LocalVolSurface1 
                                                            _blackTS.cell 
                                                            _riskFreeTS.cell 
                                                            _dividendTS.cell 
                                                            _underlying.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LocalVolSurface>) l

                let source = Helper.sourceFold "Fun.LocalVolSurface1" 
                                               [| _blackTS.source
                                               ;  _riskFreeTS.source
                                               ;  _dividendTS.source
                                               ;  _underlying.source
                                               |]
                let hash = Helper.hashFold 
                                [| _blackTS.cell
                                ;  _riskFreeTS.cell
                                ;  _dividendTS.cell
                                ;  _underlying.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LocalVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LocalVolSurface", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="blackTS",Description = "Reference to blackTS")>] 
         blackTS : obj)
        ([<ExcelArgument(Name="riskFreeTS",Description = "Reference to riskFreeTS")>] 
         riskFreeTS : obj)
        ([<ExcelArgument(Name="dividendTS",Description = "Reference to dividendTS")>] 
         dividendTS : obj)
        ([<ExcelArgument(Name="underlying",Description = "Reference to underlying")>] 
         underlying : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _blackTS = Helper.toHandle<BlackVolTermStructure> blackTS "blackTS" 
                let _riskFreeTS = Helper.toHandle<YieldTermStructure> riskFreeTS "riskFreeTS" 
                let _dividendTS = Helper.toHandle<YieldTermStructure> dividendTS "dividendTS" 
                let _underlying = Helper.toHandle<Quote> underlying "underlying" 
                let builder () = withMnemonic mnemonic (Fun.LocalVolSurface
                                                            _blackTS.cell 
                                                            _riskFreeTS.cell 
                                                            _dividendTS.cell 
                                                            _underlying.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LocalVolSurface>) l

                let source = Helper.sourceFold "Fun.LocalVolSurface" 
                                               [| _blackTS.source
                                               ;  _riskFreeTS.source
                                               ;  _dividendTS.source
                                               ;  _underlying.source
                                               |]
                let hash = Helper.hashFold 
                                [| _blackTS.cell
                                ;  _riskFreeTS.cell
                                ;  _dividendTS.cell
                                ;  _underlying.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LocalVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LocalVolSurface_maxDate", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".MaxDate") 
                                               [| _LocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
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
    [<ExcelFunction(Name="_LocalVolSurface_maxStrike", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".MaxStrike") 
                                               [| _LocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
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
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_LocalVolSurface_minStrike", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".MinStrike") 
                                               [| _LocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
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
        TermStructure interface
    *)
    [<ExcelFunction(Name="_LocalVolSurface_referenceDate", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".ReferenceDate") 
                                               [| _LocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
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
    [<ExcelFunction(Name="_LocalVolSurface_localVol", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_localVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="underlyingLevel",Description = "Reference to underlyingLevel")>] 
         underlyingLevel : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let _t = Helper.toCell<double> t "t" 
                let _underlyingLevel = Helper.toCell<double> underlyingLevel "underlyingLevel" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).LocalVol
                                                            _t.cell 
                                                            _underlyingLevel.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".LocalVol") 
                                               [| _LocalVolSurface.source
                                               ;  _t.source
                                               ;  _underlyingLevel.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
                                ;  _t.cell
                                ;  _underlyingLevel.cell
                                ;  _extrapolate.cell
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
    [<ExcelFunction(Name="_LocalVolSurface_localVol1", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_localVol1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="underlyingLevel",Description = "Reference to underlyingLevel")>] 
         underlyingLevel : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let _d = Helper.toCell<Date> d "d" 
                let _underlyingLevel = Helper.toCell<double> underlyingLevel "underlyingLevel" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).LocalVol1
                                                            _d.cell 
                                                            _underlyingLevel.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".LocalVol1") 
                                               [| _LocalVolSurface.source
                                               ;  _d.source
                                               ;  _underlyingLevel.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
                                ;  _d.cell
                                ;  _underlyingLevel.cell
                                ;  _extrapolate.cell
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_LocalVolSurface_businessDayConvention", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".BusinessDayConvention") 
                                               [| _LocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_LocalVolSurface_optionDateFromTenor", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let _p = Helper.toCell<Period> p "p" 
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".OptionDateFromTenor") 
                                               [| _LocalVolSurface.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
                                ;  _p.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_LocalVolSurface_calendar", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_LocalVolSurface.source + ".Calendar") 
                                               [| _LocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LocalVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_LocalVolSurface_maxTime", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".MaxTime") 
                                               [| _LocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_LocalVolSurface_settlementDays", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".SettlementDays") 
                                               [| _LocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_LocalVolSurface_timeFromReference", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".TimeFromReference") 
                                               [| _LocalVolSurface.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
                                ;  _date.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_LocalVolSurface_update", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).Update
                                                       ) :> ICell
                let format (o : LocalVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".Update") 
                                               [| _LocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_LocalVolSurface_allowsExtrapolation", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".AllowsExtrapolation") 
                                               [| _LocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_LocalVolSurface_disableExtrapolation", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : LocalVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".DisableExtrapolation") 
                                               [| _LocalVolSurface.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_LocalVolSurface_enableExtrapolation", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : LocalVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".EnableExtrapolation") 
                                               [| _LocalVolSurface.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_LocalVolSurface_extrapolate", Description="Create a LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolSurface",Description = "Reference to LocalVolSurface")>] 
         localvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolSurface = Helper.toCell<LocalVolSurface> localvolsurface "LocalVolSurface"  
                let builder () = withMnemonic mnemonic ((LocalVolSurfaceModel.Cast _LocalVolSurface.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalVolSurface.source + ".Extrapolate") 
                                               [| _LocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolSurface.cell
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
    [<ExcelFunction(Name="_LocalVolSurface_Range", Description="Create a range of LocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolSurface_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LocalVolSurface")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LocalVolSurface> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LocalVolSurface>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LocalVolSurface>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LocalVolSurface>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
