
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
'*   Purpose     : SCT_LineUser Domain Object.              *
'*   Called By   :                                          *
'*															*
'************************************************************

#End Region

#Region "History"

'************************************************************
'*															*
'*   Created On  : 10/5/2018 - 1:17:33 PM    *
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
    Public Class SCT_LineUser
        Inherits AbstractDomainObject

#Region "Constructors/Destructors/Finalizers"
        Public Sub New()
        End Sub


        Public Sub New(LineUserID As Int32)

            _LineUserID = LineUserID
        End Sub
#End Region

#Region "Private Variables"
        Private _LineUserID As int32
        Private _LineID As String = String.Empty
        Private _NoHP As String = String.Empty
        Private _Status As int32
        Private _DialogFlow As Int32
        Private _OTP As String = String.Empty
        Private _DibuatOleh As String = String.Empty
        Private _WaktuDibuat As DateTime = CType(System.Data.SqlTypes.SqlDateTime.MinValue.Value, DateTime)
        Private _DiubahOleh As String = String.Empty
        Private _WaktuDiubah As DateTime = CType(System.Data.SqlTypes.SqlDateTime.MinValue.Value, DateTime)
#End Region

#Region "Public Properties"

        <Key()> _
        Public Property LineUserID As int32
            Get
                Return _LineUserID
            End Get
            Set(value As int32)
                _LineUserID = value
            End Set
        End Property



        Public Property LineID As String
            Get
                Return _LineID
            End Get
            Set(value As String)
                _LineID = value
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



        Public Property Status As int32
            Get
                Return _Status
            End Get
            Set(value As int32)
                _Status = value
            End Set
        End Property



        Public Property DialogFlow As int32
            Get
                Return _DialogFlow
            End Get
            Set(value As int32)
                _DialogFlow = value
            End Set
        End Property



        Public Property OTP As String
            Get
                Return _OTP
            End Get
            Set(value As String)
                _OTP = value
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
