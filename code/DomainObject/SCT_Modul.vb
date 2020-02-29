
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
'*   Purpose     : SCT_Modul Domain Object.              *
'*   Called By   :                                          *
'*															*
'************************************************************

#End Region

#Region "History"

'************************************************************
'*															*
'*   Created On  : 26/4/2017 - 3:15:44 PM    *
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

#End Region

#Region "Custom Namespace Imports"

Imports IMFI.Framework.Persistance.DomainObjects

#End Region

#End Region

Namespace IMFI.SCT.DomainObjects
    <Serializable()> _
    Public Class SCT_Modul
        Inherits AbstractDomainObject

#Region "Constructors/Destructors/Finalizers"
        Public Sub New()
        End Sub


        Public Sub New(NoDataModul As Int32)

            _NoDataModul = NoDataModul
        End Sub
#End Region

#Region "Private Variables"
        Private _NoDataModul As int32
        Private _KodeModul As String = String.Empty
        Private _Keterangan As String = String.Empty
        Private _SPName As String = String.Empty
        Private _SPLine As String = String.Empty
        Private _JumlahParameter As int32
        Private _Parameter As String = String.Empty
        Private _SMSTemplate As String = String.Empty
        Private _DibuatOleh As String = String.Empty
        Private _WaktuDibuat As DateTime = CType(System.Data.SqlTypes.SqlDateTime.MinValue.Value, DateTime)
        Private _DiubahOleh As String = String.Empty
        Private _WaktuDiubah As DateTime = CType(System.Data.SqlTypes.SqlDateTime.MinValue.Value, DateTime)
#End Region

#Region "Public Properties"
        Public Property NoDataModul As int32
            Get
                Return _NoDataModul
            End Get
            Set(value As int32)
                _NoDataModul = value
            End Set
        End Property


        Public Property KodeModul As String
            Get
                Return _KodeModul
            End Get
            Set(value As String)
                _KodeModul = value
            End Set
        End Property


        Public Property Keterangan As String
            Get
                Return _Keterangan
            End Get
            Set(value As String)
                _Keterangan = value
            End Set
        End Property


        Public Property SPName As String
            Get
                Return _SPName
            End Get
            Set(value As String)
                _SPName = value
            End Set
        End Property



        Public Property SPLine As String
            Get
                Return _SPLine
            End Get
            Set(value As String)
                _SPLine = value
            End Set
        End Property


        Public Property JumlahParameter As int32
            Get
                Return _JumlahParameter
            End Get
            Set(value As int32)
                _JumlahParameter = value
            End Set
        End Property


        Public Property Parameter As String
            Get
                Return _Parameter
            End Get
            Set(value As String)
                _Parameter = value
            End Set
        End Property


        Public Property SMSTemplate As String
            Get
                Return _SMSTemplate
            End Get
            Set(value As String)
                _SMSTemplate = value
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
