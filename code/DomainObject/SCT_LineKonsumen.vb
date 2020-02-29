
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
'*   Purpose     : SCT_LineKonsumen Domain Object.              *
'*   Called By   :                                          *
'*															*
'************************************************************

#End Region

#Region "History"

'************************************************************
'*															*
'*   Created On  : 12/14/2018 - 1:29:07 PM    *
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
    Public Class SCT_LineKonsumen
        Inherits AbstractDomainObject

#Region "Constructors/Destructors/Finalizers"
        Public Sub New()
        End Sub


        Public Sub New(NoDataLine As Int32)

            _NoDataLine = NoDataLine
        End Sub
#End Region

#Region "Private Variables"
        Private _NoDataLine As int32
        Private _IDLine As String = String.Empty
        Private _IsKonsumen As Boolean
        Private _NoPJJ As String = String.Empty
        Private _NamaPJJ As String = String.Empty
        Private _NamaIbuKandung As String = String.Empty
        Private _DibuatOleh As String = String.Empty
        Private _WaktuDibuat As DateTime = CType(System.Data.SqlTypes.SqlDateTime.MinValue.Value, DateTime)
        Private _DiubahOleh As String = String.Empty
        Private _WaktuDiubah As DateTime = CType(System.Data.SqlTypes.SqlDateTime.MinValue.Value, DateTime)
#End Region

#Region "Public Properties"

        Public Property NoDataLine As Int32
            Get
                Return _NoDataLine
            End Get
            Set(value As Int32)
                _NoDataLine = value
            End Set
        End Property



        Public Property IDLine As String
            Get
                Return _IDLine
            End Get
            Set(value As String)
                _IDLine = value
            End Set
        End Property



        Public Property IsKonsumen As Boolean
            Get
                Return _IsKonsumen
            End Get
            Set(value As Boolean)
                _IsKonsumen = value
            End Set
        End Property



        Public Property NoPJJ As String
            Get
                Return _NoPJJ
            End Get
            Set(value As String)
                _NoPJJ = value
            End Set
        End Property



        Public Property NamaPJJ As String
            Get
                Return _NamaPJJ
            End Get
            Set(value As String)
                _NamaPJJ = value
            End Set
        End Property



        Public Property NamaIbuKandung As String
            Get
                Return _NamaIbuKandung
            End Get
            Set(value As String)
                _NamaIbuKandung = value
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
