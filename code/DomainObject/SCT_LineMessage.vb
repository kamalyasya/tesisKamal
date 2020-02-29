
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
'*   Purpose     : SCT_LineMessage Domain Object.              *
'*   Called By   :                                          *
'*															*
'************************************************************

#End Region

#Region "History"

'************************************************************
'*															*
'*   Created On  : 10/8/2018 - 2:08:38 PM    *
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
    Public Class SCT_LineMessage
        Inherits AbstractDomainObject

#Region "Constructors/Destructors/Finalizers"
        Public Sub New()
        End Sub


        Public Sub New(NoDataID As Int32)

            _NoDataID = NoDataID
        End Sub
#End Region

#Region "Private Variables"
        Private _NoDataID As int32
        Private _LineID As String = String.Empty
        Private _Message As String = String.Empty
        Private _ReplyToken As String = String.Empty
#End Region

#Region "Public Properties"

        '<Key()> _
        Public Property NoDataID As Int32
            Get
                Return _NoDataID
            End Get
            Set(value As Int32)
                _NoDataID = value
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



        Public Property Message As String
            Get
                Return _Message
            End Get
            Set(value As String)
                _Message = value
            End Set
        End Property



        Public Property ReplyToken As String
            Get
                Return _ReplyToken
            End Get
            Set(value As String)
                _ReplyToken = value
            End Set
        End Property

#End Region
    End Class

    Public Class SCT_LineLocation
        Inherits AbstractDomainObject

#Region "Constructors/Destructors/Finalizers"
        Public Sub New()
        End Sub


        Public Sub New(NoDataID As Int32)

            _NoDataID = NoDataID
        End Sub
#End Region

#Region "Private Variables"
        Private _NoDataID As Int32
        Private _Type As String = String.Empty
        Private _Address As String = String.Empty
        Private _Latitude As String = String.Empty
        Private _Longtitude As String = String.Empty
        Private _ReplyToken As String = String.Empty
#End Region

#Region "Public Properties"

        '<Key()> _
        Public Property NoDataID As Int32
            Get
                Return _NoDataID
            End Get
            Set(value As Int32)
                _NoDataID = value
            End Set
        End Property



        Public Property Type As String
            Get
                Return _Type
            End Get
            Set(value As String)
                _Type = value
            End Set
        End Property

        Public Property Address As String
            Get
                Return _Address
            End Get
            Set(value As String)
                _Address = value
            End Set
        End Property


        Public Property Latitude As String
            Get
                Return _Latitude
            End Get
            Set(value As String)
                _Latitude = value
            End Set
        End Property



        Public Property Longtitude As String
            Get
                Return _Longtitude
            End Get
            Set(value As String)
                _Longtitude = value
            End Set
        End Property

        Public Property ReplyToken As String
            Get
                Return _ReplyToken
            End Get
            Set(value As String)
                _ReplyToken = value
            End Set
        End Property
#End Region
    End Class
End Namespace
