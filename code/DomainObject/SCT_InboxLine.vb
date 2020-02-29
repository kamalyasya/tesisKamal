
#Region "Header Info"

#Region "Code Disclaimer"

'************************************************************
'*															*
'*	             Copyright © 2006 IMFI                      *
'*															*
'************************************************************

#End Region

#Region "Summary"

'************************************************************
'*															*
'*   Author      : IMFI Development Team		                        *
'*   Purpose     : SCT_InboxLine Domain Object.              *
'*   Called By   :                                          *
'*															*
'************************************************************

#End Region

#Region "History"

'************************************************************
'*															*
'*   Created On  : 10/8/2018 - 10:39:11 AM    *
'*															*
'*   Modify By   : {Name} - {Date}                           *
'*       - {Description Here}                                *
'*															*
'************************************************************/

#End Region

#End Region

#Region "Namespace Imports"

#Region ".NET Base Class Namespace Imports"

Imports System
Imports System.ComponentModel.DataAnnotations

#End Region

#Region "Custom Namespace Imports"

Imports IMFI.Framework.Persistance.DomainObjects

#End Region

#End Region

Namespace IMFI.SCT.DomainObjects
    <Serializable()> _
    Public Class SCT_InboxLine
        Inherits AbstractDomainObject

#Region "Constructors/Destructors/Finalizers"
        Public Sub New()
        End Sub


        Public Sub New(InboxLineID As Int32)

            _InboxLineID = InboxLineID
        End Sub
#End Region

#Region "Private Variables"
        Private _InboxLineID As int32
        Private _NoHP As String = String.Empty
        Private _Register As Boolean
        Private _SMSMessage As String = String.Empty
        Private _WaktuSMS As DateTime = CType(System.Data.SqlTypes.SqlDateTime.MinValue.Value, DateTime)
        Private _Proses As Boolean
        Private _ReplyMessage As String = String.Empty
        Private _WaktuReply As DateTime = CType(System.Data.SqlTypes.SqlDateTime.MinValue.Value, DateTime)
        Private _ApplicationFlag As String = String.Empty
        Private _DibuatOleh As String = String.Empty
        Private _WaktuDibuat As DateTime = CType(System.Data.SqlTypes.SqlDateTime.MinValue.Value, DateTime)
        Private _DiubahOleh As String = String.Empty
        Private _WaktuDiubah As DateTime = CType(System.Data.SqlTypes.SqlDateTime.MinValue.Value, DateTime)
#End Region

#Region "Public Properties"

        '<Key()> _
        Public Property InboxLineID As Int32
            Get
                Return _InboxLineID
            End Get
            Set(value As Int32)
                _InboxLineID = value
            End Set
        End Property



        Public Property NoHP As String
            Get
                Return _NoHP
            End Get
            Set(value As String)
                _NoHP = value
            End Set
        End Property



        Public Property Register As Boolean
            Get
                Return _Register
            End Get
            Set(value As Boolean)
                _Register = value
            End Set
        End Property



        Public Property SMSMessage As String
            Get
                Return _SMSMessage
            End Get
            Set(value As String)
                _SMSMessage = value
            End Set
        End Property



        Public Property WaktuSMS As DateTime
            Get
                Return _WaktuSMS
            End Get
            Set(value As DateTime)
                _WaktuSMS = value
            End Set
        End Property



        Public Property Proses As Boolean
            Get
                Return _Proses
            End Get
            Set(value As Boolean)
                _Proses = value
            End Set
        End Property



        Public Property ReplyMessage As String
            Get
                Return _ReplyMessage
            End Get
            Set(value As String)
                _ReplyMessage = value
            End Set
        End Property



        Public Property WaktuReply As DateTime
            Get
                Return _WaktuReply
            End Get
            Set(value As DateTime)
                _WaktuReply = value
            End Set
        End Property



        Public Property ApplicationFlag As String
            Get
                Return _ApplicationFlag
            End Get
            Set(value As String)
                _ApplicationFlag = value
            End Set
        End Property



        Public Property DibuatOleh As String
            Get
                Return _DibuatOleh
            End Get
            Set(value As String)
                _DibuatOleh = value
            End Set
        End Property



        Public Property WaktuDibuat As DateTime
            Get
                Return _WaktuDibuat
            End Get
            Set(value As DateTime)
                _WaktuDibuat = value
            End Set
        End Property



        Public Property DiubahOleh As String
            Get
                Return _DiubahOleh
            End Get
            Set(value As String)
                _DiubahOleh = value
            End Set
        End Property



        Public Property WaktuDiubah As DateTime
            Get
                Return _WaktuDiubah
            End Get
            Set(value As DateTime)
                _WaktuDiubah = value
            End Set
        End Property

#End Region
    End Class
End Namespace
