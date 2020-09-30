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
(*!! omitted
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module IndexManagerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_IndexManager_clearHistories", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IndexManager_clearHistories
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "Reference to IndexManager")>] 
         indexmanager : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toCell<IndexManager> indexmanager "IndexManager" true 
                let builder () = withMnemonic mnemonic ((_IndexManager.cell :?> IndexManagerModel).ClearHistories
                                                       ) :> ICell
                let format (o : IndexManager) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IndexManager.source + ".ClearHistories") 
                                               [| _IndexManager.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
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
    [<ExcelFunction(Name="_IndexManager_clearHistory", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IndexManager_clearHistory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "Reference to IndexManager")>] 
         indexmanager : obj)
        ([<ExcelArgument(Name="name",Description = "Reference to name")>] 
         name : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toCell<IndexManager> indexmanager "IndexManager" true 
                let _name = Helper.toCell<string> name "name" true
                let builder () = withMnemonic mnemonic ((_IndexManager.cell :?> IndexManagerModel).ClearHistory
                                                            _name.cell 
                                                       ) :> ICell
                let format (o : IndexManager) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IndexManager.source + ".ClearHistory") 
                                               [| _IndexManager.source
                                               ;  _name.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                ;  _name.cell
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
    [<ExcelFunction(Name="_IndexManager_getHistory", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IndexManager_getHistory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "Reference to IndexManager")>] 
         indexmanager : obj)
        ([<ExcelArgument(Name="name",Description = "Reference to name")>] 
         name : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toCell<IndexManager> indexmanager "IndexManager" true 
                let _name = Helper.toCell<string> name "name" true
                let builder () = withMnemonic mnemonic ((_IndexManager.cell :?> IndexManagerModel).GetHistory
                                                            _name.cell 
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IndexManager.source + ".GetHistory") 
                                               [| _IndexManager.source
                                               ;  _name.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                ;  _name.cell
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
    [<ExcelFunction(Name="_IndexManager_hasHistory", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IndexManager_hasHistory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "Reference to IndexManager")>] 
         indexmanager : obj)
        ([<ExcelArgument(Name="name",Description = "Reference to name")>] 
         name : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toCell<IndexManager> indexmanager "IndexManager" true 
                let _name = Helper.toCell<string> name "name" true
                let builder () = withMnemonic mnemonic ((_IndexManager.cell :?> IndexManagerModel).HasHistory
                                                            _name.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IndexManager.source + ".HasHistory") 
                                               [| _IndexManager.source
                                               ;  _name.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                ;  _name.cell
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
    [<ExcelFunction(Name="_IndexManager_histories", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IndexManager_histories
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "Reference to IndexManager")>] 
         indexmanager : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toCell<IndexManager> indexmanager "IndexManager" true 
                let builder () = withMnemonic mnemonic ((_IndexManager.cell :?> IndexManagerModel).Histories
                                                       ) :> ICell
                let format (i : Generic.List<string>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_IndexManager.source + ".Histories") 
                                               [| _IndexManager.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IndexManager_notifier", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IndexManager_notifier
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "Reference to IndexManager")>] 
         indexmanager : obj)
        ([<ExcelArgument(Name="name",Description = "Reference to name")>] 
         name : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toCell<IndexManager> indexmanager "IndexManager" true 
                let _name = Helper.toCell<string> name "name" true
                let builder () = withMnemonic mnemonic ((_IndexManager.cell :?> IndexManagerModel).Notifier
                                                            _name.cell 
                                                       ) :> ICell
                let format (o : ObservableValue<TimeSeries<Nullable<double>>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IndexManager.source + ".Notifier") 
                                               [| _IndexManager.source
                                               ;  _name.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                ;  _name.cell
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
    [<ExcelFunction(Name="_IndexManager_setHistory", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IndexManager_setHistory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "Reference to IndexManager")>] 
         indexmanager : obj)
        ([<ExcelArgument(Name="name",Description = "Reference to name")>] 
         name : obj)
        ([<ExcelArgument(Name="history",Description = "Reference to history")>] 
         history : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toCell<IndexManager> indexmanager "IndexManager" true 
                let _name = Helper.toCell<string> name "name" true
                let _history = Helper.toCell<TimeSeries<Nullable<double>>> history "history" true
                let builder () = withMnemonic mnemonic ((_IndexManager.cell :?> IndexManagerModel).SetHistory
                                                            _name.cell 
                                                            _history.cell 
                                                       ) :> ICell
                let format (o : IndexManager) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IndexManager.source + ".SetHistory") 
                                               [| _IndexManager.source
                                               ;  _name.source
                                               ;  _history.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                ;  _name.cell
                                ;  _history.cell
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
    [<ExcelFunction(Name="_IndexManager_tryGetHistory", Description="Create a IndexManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IndexManager_tryGetHistory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexManager",Description = "Reference to IndexManager")>] 
         indexmanager : obj)
        ([<ExcelArgument(Name="name",Description = "Reference to name")>] 
         name : obj)
        ([<ExcelArgument(Name="history",Description = "Reference to history")>] 
         history : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexManager = Helper.toCell<IndexManager> indexmanager "IndexManager" true 
                let _name = Helper.toCell<string> name "name" true
                let _history = Helper.toCell<TimeSeries<Nullable<double>>> history "history" true
                let builder () = withMnemonic mnemonic ((_IndexManager.cell :?> IndexManagerModel).TryGetHistory
                                                            _name.cell 
                                                            _history.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IndexManager.source + ".TryGetHistory") 
                                               [| _IndexManager.source
                                               ;  _name.source
                                               ;  _history.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexManager.cell
                                ;  _name.cell
                                ;  _history.cell
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
    [<ExcelFunction(Name="_IndexManager_Range", Description="Create a range of IndexManager",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IndexManager_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the IndexManager")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IndexManager> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<IndexManager>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<IndexManager>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<IndexManager>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)