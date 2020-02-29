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
'   Purpose     : SCT_LineUser Objects Mapper.                      
'   Called By   :                                          
'															
'************************************************************

#End Region

#Region "History"

'************************************************************
'															
'   Created On  : 10/5/2018 - 1:17:51 PM                   
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
    Public Class SCT_LineUserMapper
        Inherits AbstractMapper2

#Region "Constructors/Destructors/Finalizers"

        Public Sub New()
            Db = DatabaseFactory.CreateDatabase()
        End Sub

#End Region

#Region "Private Variables"

        Private m_InsertStatement As String = "USP_SCT_LineUserInsert"
        Private m_UpdateStatement As String = "USP_SCT_LineUserUpdate"
        Private m_RetrieveStatement As String = "USP_SCT_LineUserRetrieve"
        Private m_RetrieveListStatement As String = "USP_SCT_LineUserRetrieveList"
        Private m_DeleteStatement As String = "USP_SCT_LineUserDelete"
        Private m_RetrieveListPagingStatement As String = "USP_SCT_LineUserRetrievePagingList"
        Private m_RetrieveWithConditionStatement As String = "USP_SCT_LineUserRetrieveWithCondition"
        Private m_RetrieveListPagingRowCountStatement As String = "USP_SCT_LineUserRetrievePagingRowCount"

#End Region

#Region "Protected Methods"

        Protected Overrides Function GetNewID(ByVal oDBCommandWrapper As System.Data.Common.DbCommand) As Object
            Return Db.GetParameterValue(DBCommand, "@LineUserID")
        End Function

        Protected Overrides Function GetInsertParameter(ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim oUserCredential As IUserCredential = CType(oObjectTransporter, IObjectTransporter).UserCredential
            Dim oSCT_LineUser As SCT_LineUser = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_LineUser)

            DBCommand = Db.GetStoredProcCommand(Me.m_InsertStatement)



            Db.AddInParameter(DBCommand, "@LineUserID", DbType.Int32, oSCT_LineUser.LineUserID)

            Db.AddInParameter(DBCommand, "@LineID", DbType.AnsiString, oSCT_LineUser.LineID)

            Db.AddInParameter(DBCommand, "@NoHP", DbType.AnsiString, oSCT_LineUser.NoHP)

            Db.AddInParameter(DBCommand, "@Status", DbType.Int32, oSCT_LineUser.Status)

            Db.AddInParameter(DBCommand, "@DialogFlow", DbType.Int32, oSCT_LineUser.DialogFlow)

            Db.AddInParameter(DBCommand, "@OTP", DbType.AnsiString, oSCT_LineUser.OTP)

            Return DBCommand
        End Function

        Protected Overrides Function GetUpdateParameter(ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim objUserCredential As IUserCredential = CType(oObjectTransporter, IObjectTransporter).UserCredential
            Dim oSCT_LineUser As SCT_LineUser = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_LineUser)

            DBCommand = Db.GetStoredProcCommand(Me.m_UpdateStatement)
            Db.AddInParameter(DBCommand, "@LineUserID", DbType.Int32, oSCT_LineUser.LineUserID)
            Db.AddInParameter(DBCommand, "@LineID", DbType.AnsiString, oSCT_LineUser.LineID)
            Db.AddInParameter(DBCommand, "@NoHP", DbType.AnsiString, oSCT_LineUser.NoHP)
            Db.AddInParameter(DBCommand, "@Status", DbType.Int32, oSCT_LineUser.Status)
            Db.AddInParameter(DBCommand, "@DialogFlow", DbType.Int32, oSCT_LineUser.DialogFlow)
            Db.AddInParameter(DBCommand, "@OTP", DbType.AnsiString, oSCT_LineUser.OTP)



            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveParameter(ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim oSCT_LineUser As SCT_LineUser

            If Not IsNothing(oObjectTransporter) Then
                oSCT_LineUser = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_LineUser)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveStatement)

            Db.AddInParameter(DBCommand, "@LineUserID", DbType.Int32, oSCT_LineUser.LineUserID)

            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveListParameter(ByVal oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim oSCT_LineUser As SCT_LineUser

            If Not IsNothing(oObjectTransporter) Then
                oSCT_LineUser = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_LineUser)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveListStatement)

            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveListPagingParameter(ByVal PageSize As Integer, ByVal CurrentPage As Integer, ByVal OrderBy As String, ByVal oObjectTransporter As IObjectTransporter, ByVal SearchCondition As String) As System.Data.Common.DbCommand
            Dim oSCT_LineUser As SCT_LineUser

            If Not IsNothing(oObjectTransporter) Then
                oSCT_LineUser = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_LineUser)
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
            Dim oSCT_LineUser As SCT_LineUser

            If Not IsNothing(oObjectTransporter) Then
                oSCT_LineUser = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_LineUser)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveWithConditionStatement)

            Db.AddInParameter(DBCommand, "@OrderBy", DbType.String, OrderBy)
            Db.AddInParameter(DBCommand, "@SearchCondition", DbType.String, IIf(IsNothing(SearchCondition), "", SearchCondition))

            Return DBCommand
        End Function

        Protected Overrides Function GetRetrieveListPagingRowCountParameter(ByVal oObjectTransporter As IObjectTransporter, ByVal SearchCondition As String) As System.Data.Common.DbCommand
            Dim oSCT_LineUser As SCT_LineUser

            If Not IsNothing(oObjectTransporter) Then
                oSCT_LineUser = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_LineUser)
            End If
            DBCommand = Db.GetStoredProcCommand(Me.m_RetrieveListPagingRowCountStatement)

            Db.AddInParameter(DBCommand, "@SearchCondition", DbType.String, IIf(IsNothing(SearchCondition), "", SearchCondition))

            Return DBCommand
        End Function

        Protected Overrides Function GetDeleteParameter(oObjectTransporter As IObjectTransporter) As System.Data.Common.DbCommand
            Dim oUserCredential As IUserCredential = CType(oObjectTransporter, IObjectTransporter).UserCredential
            Dim oSCT_LineUser As SCT_LineUser = CType(CType(oObjectTransporter, IObjectTransporter).DomainObject, SCT_LineUser)
            DBCommand = Db.GetStoredProcCommand(Me.m_DeleteStatement)

            Db.AddInParameter(DBCommand, "@LineUserID", DbType.Int32, oSCT_LineUser.LineUserID)

            Return DBCommand
        End Function

        Protected Overrides Function DoRetrieve(ByVal dr As IDataReader) As Object
            Dim oSCT_LineUser As SCT_LineUser = Nothing

            While (dr.Read())

                oSCT_LineUser = Me.CreateObject(dr)
            End While

            Return oSCT_LineUser
        End Function

        Protected Overrides Function DoRetrieveList(ByVal dr As IDataReader) As ArrayList
            Dim oSCT_LineUserList As ArrayList = New ArrayList()

            While (dr.Read())

                Dim oSCT_LineUser As SCT_LineUser = Me.CreateObject(dr)
                oSCT_LineUserList.Add(oSCT_LineUser)
            End While

            Return oSCT_LineUserList
        End Function

        Protected Overrides Function DoRetrieveWithCondition(ByVal dr As IDataReader) As ArrayList
            Dim oSCT_LineUserList As ArrayList = New ArrayList()

            While (dr.Read())

                Dim oSCT_LineUser As SCT_LineUser = Me.CreateObject(dr)
                oSCT_LineUserList.Add(oSCT_LineUser)
            End While

            Return oSCT_LineUserList
        End Function

#End Region

#Region "Private Methods"

        Private Function CreateObject(ByVal dr As IDataReader) As SCT_LineUser
            Dim oSCT_LineUser As SCT_LineUser = New SCT_LineUser()

            oSCT_LineUser.LineUserID = CType(dr("LineUserID"), int32)
            If (Not dr.IsDBNull(dr.GetOrdinal("LineID"))) Then oSCT_LineUser.LineID = dr("LineID").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("NoHP"))) Then oSCT_LineUser.NoHP = dr("NoHP").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("Status"))) Then oSCT_LineUser.Status = CType(dr("Status"), int32)
            If (Not dr.IsDBNull(dr.GetOrdinal("DialogFlow"))) Then oSCT_LineUser.DialogFlow = CType(dr("DialogFlow"), Int32)
            If (Not dr.IsDBNull(dr.GetOrdinal("OTP"))) Then oSCT_LineUser.OTP = dr("OTP").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("DibuatOleh"))) Then oSCT_LineUser.DibuatOleh = dr("DibuatOleh").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("WaktuDibuat"))) Then oSCT_LineUser.WaktuDibuat = CType(dr("WaktuDibuat"), DateTime)
            If (Not dr.IsDBNull(dr.GetOrdinal("DiubahOleh"))) Then oSCT_LineUser.DiubahOleh = dr("DiubahOleh").ToString()
            If (Not dr.IsDBNull(dr.GetOrdinal("WaktuDiubah"))) Then oSCT_LineUser.WaktuDiubah = CType(dr("WaktuDiubah"), DateTime)

            Return oSCT_LineUser
        End Function

#End Region
    End Class
End Namespace
