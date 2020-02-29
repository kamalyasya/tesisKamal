
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
'   Purpose     : SCT_InboxLine Business Facade.                      
'   Called By   :                                          
'															
'************************************************************

#End Region

#Region "History"

'************************************************************
'															
'   Created On  : 10/8/2018 - 10:40:14 AM                   
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
Imports System.Collections

#End Region

#Region "Custom Namespace Imports"

Imports IMFI.Framework.Persistance.Mapper
Imports IMFI.Framework.Persistance.DomainObjects.Core
Imports IMFI.Framework.Persistance.BusinessFacade
Imports IMFI.SCT.DomainObjects

#End Region

#End Region

Namespace IMFI.SCT.BusinessFacade

    Public Class SCT_InboxLineBusinessFacade
#Region "Private Variables"

        Private SCT_InboxLineMapper As IMapper2
        Private _Transaction As IDbTransaction

#End Region

#Region "Constructors/Destructors/Finalizers"

        Public Sub New()
            SCT_InboxLineMapper = MapperFactory2.GetInstance().GetMapper(GetType(SCT_InboxLine).ToString())
        End Sub
#End Region

#Region "Public Methods"

        Public Function Create(ByVal oObjectTransporter As IObjectTransporter) As Object
            Return SCT_InboxLineMapper.Insert(oObjectTransporter)
        End Function

        Public Function Retrieve(ByVal oObjectTransporter As IObjectTransporter) As SCT_InboxLine
            Return CType(SCT_InboxLineMapper.Retrieve(oObjectTransporter), SCT_InboxLine)
        End Function

        Public Function RetrieveListPaging(ByVal PageSize As Int32, ByVal CurrentPage As Int32, ByVal OrderBy As String, ByVal oObjectTransporter As IObjectTransporter, ByVal SearchCondition As String, ByRef RowCount As Int32) As ArrayList
            Return SCT_InboxLineMapper.RetrieveListPaging(PageSize, CurrentPage, OrderBy, oObjectTransporter, SearchCondition, RowCount)
        End Function

        Public Function RetrieveWithCondition(ByVal SearchCondition As String, ByVal OrderBy As String, ByVal oObjectTransporter As IObjectTransporter) As ArrayList
            Return SCT_InboxLineMapper.RetrieveWithCondition(SearchCondition, OrderBy, oObjectTransporter)
        End Function

        Public Function RetrieveList(ByVal oObjectTransporter As IObjectTransporter) As ArrayList
            Return SCT_InboxLineMapper.RetrieveList(oObjectTransporter)
        End Function

        Public Function Update(ByVal oObjectTransporter As IObjectTransporter) As Int32
            Return SCT_InboxLineMapper.Update(oObjectTransporter)
        End Function

        'public Function Delete(ByVal oObjectTransporter as IObjectTransporter) as Int32
        '	return SCT_InboxLineMapper.Delete(oObjectTransporter)
        'End Function

        Public Function Delete(ByVal oObjectTransporter As IObjectTransporter) As Result
            Dim oResult As Result

            Try
                oResult = New Result(SCT_InboxLineMapper.Delete(oObjectTransporter), "")
            Catch ex As Exception
                If ex.GetType().Name = "ConstraintException" Then
                    oResult = New Result(-1, "Data sudah digunakan.")
                Else
                    Throw ex
                End If
            End Try

            Return oResult
        End Function

        Public Sub UseTransaction(ByVal oTransaction As IDbTransaction)
            SCT_InboxLineMapper.UseTransaction(oTransaction)
            _Transaction = oTransaction
        End Sub

#End Region

    End Class

End Namespace
