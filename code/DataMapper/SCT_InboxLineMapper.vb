#Region "Header Info"

#Region "Code Disclaimer"

'************************************************************
'															
'	             Copyright © IMFI                      
'															
'************************************************************

#End Region

#Region "Summary"

'************************************************************
'															
'   Author      : IMFI IT Development Team		            
'   Purpose     : SCT_InboxLine Objects Mapper.                      
'   Called By   :                                          
'															
'************************************************************

#End Region

#Region "History"

'************************************************************
'															
'   Created On  : 10/8/2018 - 10:39:49 AM                   
'															
'   Modify By   : {Name} - {Date}                          
'       - {Description Here}                               
'															
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
    Public Class SCT_InboxLineMapper
        Inherits AbstractMapper2

#Region "Constructors/Destructors/Finalizers"

        Public Sub New()
            Db = DatabaseFactory.CreateDatabase()
        End Sub

#End Region

#Region "Private Variables"

        Private m_InsertStatement As String = "USP_SCT_InboxLineInsert"
        Private m_UpdateStatement As String = "USP_SCT_InboxLineUpdate"
        Private m_RetrieveStatement As String = "USP_SCT_InboxLineRetrieve"
        Private m_RetrieveListStatement As String = "USP_SCT_InboxLineRetrieveList"
        Private m_DeleteStatement As String = "USP_SCT_InboxLineDelete"
        Private m_RetrieveListPagingStatement As String = "USP_SCT_InboxLineRetrievePagingList"
        Private m_RetrieveWithConditionStatement As String = "USP_SCT_InboxLineRetrieveWithCondition"
        Private m_RetrieveListPagingRowCountStatement As String = "USP_SCT_InboxLineRetrievePagingRowCount"

#End Region

#Region "Protected Methods"

        Protected Overrides Function GetNewID(ByVal oDBCommandWrapper As System.Data.Common.DbCommand) As Object
            Return Db.GetParameterValue(DBCommand, "@InboxLineID")
        End Function

        Protected Overrides Function GetInsertParameter(ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim oUserCredential As IUserCredential = CType(oObjectTransporter, IObjectTransporter).UserCredential
            Dim oSCT_InboxLine As SCT_InboxLine = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_InboxLine)

            DBCommand = Db.GetStoredProcCommand(Me.m_InsertStatement)



            Db.AddInParameter(DBCommand, "@InboxLineID", DbType.Int32, oSCT_InboxLine.InboxLineID)

            Db.AddInParameter(DBCommand, "@NoHP", DbType.AnsiString, oSCT_InboxLine.NoHP)

            Db.AddInParameter(DBCommand, "@Register", DbType.Boolean, oSCT_InboxLine.Register)

            Db.AddInParameter(DBCommand, "@SMSMessage", DbType.AnsiString, oSCT_InboxLine.SMSMessage)

            Db.AddInParameter(DBCommand, "@WaktuSMS", DbType.DateTime, IIf(oSCT_InboxLine.WaktuSMS > #1/1/1753#, oSCT_InboxLine.WaktuSMS, System.DBNull.Value))

            Db.AddInParameter(DBCommand, "@Proses", DbType.Boolean, oSCT_InboxLine.Proses)

            Db.AddInParameter(DBCommand, "@ReplyMessage", DbType.AnsiString, oSCT_InboxLine.ReplyMessage)

            Db.AddInParameter(DBCommand, "@WaktuReply", DbType.DateTime, IIf(oSCT_InboxLine.WaktuReply > #1/1/1753#, oSCT_InboxLine.WaktuReply, System.DBNull.Value))

            Db.AddInParameter(DBCommand, "@ApplicationFlag", DbType.AnsiString, oSCT_InboxLine.ApplicationFlag)

            Return DBCommand
        End Function

        Protected Overrides Function GetUpdateParameter(ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim objUserCredential As IUserCredential = CType(oObjectTransporter, IObjectTransporter).UserCredential
            Dim oSCT_InboxLine As SCT_InboxLine = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_InboxLine)

            DBCommand = Db.GetStoredProcCommand(Me.m_UpdateStatement)
            Db.AddInParameter(DBCommand, "@InboxLineID", DbType.Int32, oSCT_InboxLine.InboxLineID)
            Db.AddInParameter(DBCommand, "@NoHP", DbType.AnsiString, oSCT_InboxLine.NoHP)
            Db.AddInParameter(DBCommand, "@Register", DbType.Boolean, oSCT_InboxLine.Register)
            Db.AddInParameter(DBCommand, "@SMSMessage", DbType.AnsiString, oSCT_InboxLine.SMSMessage)
            Db.AddInParameter(DBCommand, "@WaktuSMS", DbType.DateTime, IIf(oSCT_InboxLine.WaktuSMS > #1/1/1753#, oSCT_InboxLine.WaktuSMS, System.DBNull.Value))
            Db.AddInParameter(DBCommand, "@Proses", DbType.Boolean, oSCT_InboxLine.Proses)
            Db.AddInParameter(DBCommand, "@ReplyMessage", DbType.AnsiString, oSCT_InboxLine.ReplyMessage)
            Db.AddInParameter(DBCommand, "@WaktuReply", DbType.DateTime, IIf(oSCT_InboxLine.WaktuReply > #1/1/1753#, oSCT_InboxLine.WaktuReply, System.DBNull.Value))
            Db.AddInParameter(DBCommand, "@ApplicationFlag", DbType.AnsiString, oSCT_InboxLine.ApplicationFlag)



            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveParameter(ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim oSCT_InboxLine As SCT_InboxLine

            If Not IsNothing(oObjectTransporter) Then
                oSCT_InboxLine = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_InboxLine)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveStatement)

            Db.AddInParameter(DBCommand, "@InboxLineID", DbType.Int32, oSCT_InboxLine.InboxLineID)

            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveListParameter(ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim oSCT_InboxLine As SCT_InboxLine

            If Not IsNothing(oObjectTransporter) Then
                oSCT_InboxLine = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_InboxLine)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveListStatement)

            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveListPagingParameter(ByVal PageSize As Integer, ByVal CurrentPage As Integer, ByVal OrderBy As String, ByVal oObjectTransporter As IObjectTransporter, ByVal SearchCondition As String) As System.Data.Common.DbCommand
            Dim oSCT_InboxLine As SCT_InboxLine

            If Not IsNothing(oObjectTransporter) Then
                oSCT_InboxLine = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_InboxLine)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveListPagingStatement)

            Db.AddInParameter(DBCommand, "@PageSize", DbType.Int32, PageSize)
            Db.AddInParameter(DBCommand, "@CurrentPage", DbType.Int32, CurrentPage)
            Db.AddInParameter(DBCommand, "@OrderBy", DbType.String, OrderBy.Split(" "c)(0))
            Db.AddInParameter(DBCommand, "@Order", DbType.String, OrderBy.Split(" "c)(1))
            Db.AddInParameter(DBCommand, "@SearchCondition", DbType.String, IIf(IsNothing(SearchCondition), "", SearchCondition))

            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveWithConditionParameter(ByVal SearchCondition As String, ByVal OrderBy As String, ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim oSCT_InboxLine As SCT_InboxLine

            If Not IsNothing(oObjectTransporter) Then
                oSCT_InboxLine = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_InboxLine)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveWithConditionStatement)

            Db.AddInParameter(DBCommand, "@OrderBy", DbType.String, OrderBy)
            Db.AddInParameter(DBCommand, "@SearchCondition", DbType.String, IIf(IsNothing(SearchCondition), "", SearchCondition))

            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveListPagingRowCountParameter(ByVal oObjectTransporter As IObjectTransporter, ByVal SearchCondition As String) As System.Data.Common.DbCommand
            Dim oSCT_InboxLine As SCT_InboxLine

            If Not IsNothing(oObjectTransporter) Then
                oSCT_InboxLine = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_InboxLine)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveListPagingRowCountStatement)

            Db.AddInParameter(DBCommand, "@SearchCondition", DbType.String, IIf(IsNothing(SearchCondition), "", SearchCondition))

            Return DBCommand
        End Function

        Protected Overrides Function GetDeleteParameter(oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim oUserCredential As IUserCredential = CType(oObjectTransporter, IObjectTransporter).UserCredential
            Dim oSCT_InboxLine As SCT_InboxLine = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_InboxLine)
            DBCommand = Db.GetStoredProcCommand(Me.m_DeleteStatement)

            Db.AddInParameter(DBCommand, "@InboxLineID", DbType.Int32, oSCT_InboxLine.InboxLineID)

            Return DBCommand
        End Function

        Protected Overrides Function DoRetrieve(ByVal dr As IDataReader) As Object
            Dim oSCT_InboxLine As SCT_InboxLine = Nothing

            While (dr.Read())

                oSCT_InboxLine = Me.CreateObject(dr)
            End While

            Return oSCT_InboxLine
        End Function

        Protected Overrides Function DoRetrieveList(ByVal dr As IDataReader) As ArrayList
            Dim oSCT_InboxLineList As ArrayList = New ArrayList()

            While (dr.Read())

                Dim oSCT_InboxLine As SCT_InboxLine = Me.CreateObject(dr)
                oSCT_InboxLineList.Add(oSCT_InboxLine)
            End While

            Return oSCT_InboxLineList
        End Function

        Protected Overrides Function DoRetrieveWithCondition(ByVal dr As IDataReader) As ArrayList
            Dim oSCT_InboxLineList As ArrayList = New ArrayList()

            While (dr.Read())

                Dim oSCT_InboxLine As SCT_InboxLine = Me.CreateObject(dr)
                oSCT_InboxLineList.Add(oSCT_InboxLine)
            End While

            Return oSCT_InboxLineList
        End Function

#End Region

#Region "Private Methods"

        Private Function CreateObject(ByVal dr As IDataReader) As SCT_InboxLine
            Dim oSCT_InboxLine As SCT_InboxLine = New SCT_InboxLine()

            oSCT_InboxLine.InboxLineID = CType(dr("InboxLineID"), int32)
            If (Not dr.IsDBNull(dr.GetOrdinal("NoHP"))) Then oSCT_InboxLine.NoHP = dr("NoHP").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("Register"))) Then oSCT_InboxLine.Register = CType(dr("Register"), Boolean)
            If (Not dr.IsDBNull(dr.GetOrdinal("SMSMessage"))) Then oSCT_InboxLine.SMSMessage = dr("SMSMessage").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("WaktuSMS"))) Then oSCT_InboxLine.WaktuSMS = CType(dr("WaktuSMS"), DateTime)
            If (Not dr.IsDBNull(dr.GetOrdinal("Proses"))) Then oSCT_InboxLine.Proses = CType(dr("Proses"), Boolean)
            If (Not dr.IsDBNull(dr.GetOrdinal("ReplyMessage"))) Then oSCT_InboxLine.ReplyMessage = dr("ReplyMessage").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("WaktuReply"))) Then oSCT_InboxLine.WaktuReply = CType(dr("WaktuReply"), DateTime)
            If (Not dr.IsDBNull(dr.GetOrdinal("ApplicationFlag"))) Then oSCT_InboxLine.ApplicationFlag = dr("ApplicationFlag").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("DibuatOleh"))) Then oSCT_InboxLine.DibuatOleh = dr("DibuatOleh").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("WaktuDibuat"))) Then oSCT_InboxLine.WaktuDibuat = CType(dr("WaktuDibuat"), DateTime)
            If (Not dr.IsDBNull(dr.GetOrdinal("DiubahOleh"))) Then oSCT_InboxLine.DiubahOleh = dr("DiubahOleh").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("WaktuDiubah"))) Then oSCT_InboxLine.WaktuDiubah = CType(dr("WaktuDiubah"), DateTime)

            Return oSCT_InboxLine
        End Function

#End Region
    End Class
End Namespace
