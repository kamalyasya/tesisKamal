
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
'*   Author      : IMFI Development Team		            *
'*   Purpose     : SCT_Modul Objects Mapper.                      *
'*   Called By   :                                          *
'*															*
'************************************************************

#End Region

#Region "History"

'************************************************************
'*															*
'*   Created On  : 26/4/2017 - 3:16:06 PM                   *
'*															*
'*   Modify By   : {Name} - {Date}                          *
'*       - {Description Here}                               *
'*															*
'************************************************************/

#End Region

#End Region

#Region "Namespace Imports"

#Region ".NET Base Class Namespace Imports"

Imports System
Imports System.Data
Imports System.Collections

#End Region

#Region "Custom Namespace Imports"

Imports Microsoft.Practices.EnterpriseLibrary.Data
'Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
'Imports Microsoft.Practices.EnterpriseLibrary.Logging

Imports IMFI.Framework.Persistance.DomainObjects.Core
Imports IMFI.Framework.Persistance.Mapper
Imports IMFI.SCT.DomainObjects

#End Region

#End Region

Namespace IMFI.SCT.DataMapper
    Public Class SCT_ModulMapper
        Inherits AbstractMapper

#Region "Constructors/Destructors/Finalizers"

        Public Sub New()
            Db = DatabaseFactory.CreateDatabase()
        End Sub

#End Region

#Region "Private Variables"

        Private m_InsertStatement As String = "USP_SCT_ModulInsert"
        Private m_UpdateStatement As String = "USP_SCT_ModulUpdate"
        Private m_RetrieveStatement As String = "USP_SCT_ModulRetrieve"
        Private m_RetrieveListStatement As String = "USP_SCT_ModulRetrieveList"
        Private m_DeleteStatement As String = "USP_SCT_ModulDelete"
        Private m_RetrieveListPagingStatement As String = "USP_SCT_ModulRetrievePagingList"
        Private m_RetrieveListPagingRowCountStatement As String = "USP_SCT_ModulRetrievePagingRowCount"

#End Region

#Region "Protected Methods"

        Protected Overrides Function GetNewID(ByVal oDBCommandWrapper As System.Data.Common.DbCommand) As Object
            Return Db.GetParameterValue(DBCommand, "@NoDataModul")
        End Function

        Protected Overrides Function GetInsertParameter(ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand

            Dim oUserCredential As IUserCredential = CType(oObjectTransporter, IObjectTransporter).UserCredential
            Dim oSCT_Modul As SCT_Modul = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_Modul)

            DBCommand = Db.GetStoredProcCommand(Me.m_InsertStatement)



            Db.AddInParameter(DBCommand, "@NoDataModul", DbType.Int32, oSCT_Modul.NoDataModul)

            Db.AddInParameter(DBCommand, "@KodeModul", DbType.AnsiString, oSCT_Modul.KodeModul)

            Db.AddInParameter(DBCommand, "@Keterangan", DbType.AnsiString, oSCT_Modul.Keterangan)

            Db.AddInParameter(DBCommand, "@SPName", DbType.AnsiString, oSCT_Modul.SPName)

            Db.AddInParameter(DBCommand, "@SPLine", DbType.AnsiString, oSCT_Modul.SPLine)

            Db.AddInParameter(DBCommand, "@JumlahParameter", DbType.Int32, oSCT_Modul.JumlahParameter)

            Db.AddInParameter(DBCommand, "@Parameter", DbType.AnsiString, oSCT_Modul.Parameter)

            Db.AddInParameter(DBCommand, "@SMSTemplate", DbType.AnsiString, oSCT_Modul.SMSTemplate)

            Return DBCommand
        End Function

        Protected Overrides Function GetUpdateParameter(ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim objUserCredential As IUserCredential = CType(oObjectTransporter, IObjectTransporter).UserCredential
            Dim oSCT_Modul As SCT_Modul = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_Modul)

            DBCommand = Db.GetStoredProcCommand(Me.m_UpdateStatement)
            Db.AddInParameter(DBCommand, "@NoDataModul", DbType.Int32, oSCT_Modul.NoDataModul)
            Db.AddInParameter(DBCommand, "@KodeModul", DbType.AnsiString, oSCT_Modul.KodeModul)
            Db.AddInParameter(DBCommand, "@Keterangan", DbType.AnsiString, oSCT_Modul.Keterangan)
            Db.AddInParameter(DBCommand, "@SPName", DbType.AnsiString, oSCT_Modul.SPName)
            Db.AddInParameter(DBCommand, "@SPLine", DbType.AnsiString, oSCT_Modul.SPLine)
            Db.AddInParameter(DBCommand, "@JumlahParameter", DbType.Int32, oSCT_Modul.JumlahParameter)
            Db.AddInParameter(DBCommand, "@Parameter", DbType.AnsiString, oSCT_Modul.Parameter)
            Db.AddInParameter(DBCommand, "@SMSTemplate", DbType.AnsiString, oSCT_Modul.SMSTemplate)



            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveParameter(ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand

            Dim oSCT_Modul As SCT_Modul
            If Not IsNothing(oObjectTransporter) Then
                oSCT_Modul = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_Modul)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveStatement)

            Db.AddInParameter(DBCommand, "@NoDataModul", DbType.Int32, oSCT_Modul.NoDataModul)

            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveListParameter(ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim oSCT_Modul As SCT_Modul
            If Not IsNothing(oObjectTransporter) Then
                oSCT_Modul = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_Modul)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveListStatement)
            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveListPagingParameter(ByVal PageSize As Integer, ByVal CurrentPage As Integer, ByVal OrderBy As String, ByVal oObjectTransporter As IObjectTransporter, ByVal SearchCondition As String) As System.Data.Common.DbCommand
            Dim oSCT_Modul As SCT_Modul
            If Not IsNothing(oObjectTransporter) Then
                oSCT_Modul = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_Modul)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveListPagingStatement)

            Db.AddInParameter(DBCommand, "@PageSize", DbType.Int32, PageSize)
            Db.AddInParameter(DBCommand, "@CurrentPage", DbType.Int32, CurrentPage)
            Db.AddInParameter(DBCommand, "@OrderBy", DbType.String, OrderBy.Split(" "c)(0))
            Db.AddInParameter(DBCommand, "@Order", DbType.String, OrderBy.Split(" "c)(1))
            Db.AddInParameter(DBCommand, "@SearchCondition", DbType.String, IIf(IsNothing(SearchCondition), "", SearchCondition))

            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveListPagingRowCountParameter(ByVal oObjectTransporter As IObjectTransporter, ByVal SearchCondition As String) As System.Data.Common.DbCommand
            Dim oSCT_Modul As SCT_Modul
            If Not IsNothing(oObjectTransporter) Then
                oSCT_Modul = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_Modul)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveListPagingRowCountStatement)

            Db.AddInParameter(DBCommand, "@SearchCondition", DbType.String, IIf(IsNothing(SearchCondition), "", SearchCondition))

            Return DBCommand
        End Function

        Protected Overrides Function GetDeleteParameter(oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim oUserCredential As IUserCredential = CType(oObjectTransporter, IObjectTransporter).UserCredential
            Dim oSCT_Modul As SCT_Modul = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_Modul)
            DBCommand = Db.GetStoredProcCommand(Me.m_DeleteStatement)


            Db.AddInParameter(DBCommand, "@NoDataModul", DbType.Int32, oSCT_Modul.NoDataModul)
            Return DBCommand
        End Function

        Protected Overrides Function DoRetrieve(ByVal dr As IDataReader) As Object
            Dim oSCT_Modul As SCT_Modul = Nothing
            While (dr.Read())

                oSCT_Modul = Me.CreateObject(dr)
            End While

            Return oSCT_Modul
        End Function

        Protected Overrides Function DoRetrieveList(ByVal dr As IDataReader) As ArrayList
            Dim oSCT_ModulList As ArrayList = New ArrayList()
            While (dr.Read())

                Dim oSCT_Modul As SCT_Modul = Me.CreateObject(dr)
                oSCT_ModulList.Add(oSCT_Modul)
            End While

            Return oSCT_ModulList
        End Function

#End Region

#Region "Private Methods"

        Private Function CreateObject(ByVal dr As IDataReader) As SCT_Modul
            Dim oSCT_Modul As SCT_Modul = New SCT_Modul()

            oSCT_Modul.NoDataModul = CType(dr("NoDataModul"), int32)
            If (Not dr.IsDBNull(dr.GetOrdinal("KodeModul"))) Then oSCT_Modul.KodeModul = dr("KodeModul").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("Keterangan"))) Then oSCT_Modul.Keterangan = dr("Keterangan").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("SPName"))) Then oSCT_Modul.SPName = dr("SPName").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("SPLine"))) Then oSCT_Modul.SPLine = dr("SPLine").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("JumlahParameter"))) Then oSCT_Modul.JumlahParameter = CType(dr("JumlahParameter"), int32)
            If (Not dr.IsDBNull(dr.GetOrdinal("Parameter"))) Then oSCT_Modul.Parameter = dr("Parameter").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("SMSTemplate"))) Then oSCT_Modul.SMSTemplate = dr("SMSTemplate").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("DibuatOleh"))) Then oSCT_Modul.DibuatOleh = dr("DibuatOleh").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("WaktuDibuat"))) Then oSCT_Modul.WaktuDibuat = CType(dr("WaktuDibuat"), DateTime)
            If (Not dr.IsDBNull(dr.GetOrdinal("DiubahOleh"))) Then oSCT_Modul.DiubahOleh = dr("DiubahOleh").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("WaktuDiubah"))) Then oSCT_Modul.WaktuDiubah = CType(dr("WaktuDiubah"), DateTime)

            Return oSCT_Modul
        End Function

#End Region
    End Class
End Namespace
