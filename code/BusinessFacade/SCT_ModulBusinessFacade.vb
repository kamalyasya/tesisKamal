
#Region "Header Info"

#Region "Code Disclaimer"

'************************************************************
'*															*
'*	             Copyright © IMFI                      *
'*															*
'************************************************************

#End Region

#Region "Summary"

'************************************************************
'*															*
'*   Author      : IMFI Development Team		            *
'*   Purpose     : SCT_Modul Business Facade.                      *
'*   Called By   :                                          *
'*															*
'************************************************************

#End Region

#Region "History"

'************************************************************
'*															*
'*   Created On  : 26/4/2017 - 3:16:30 PM                   *
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

    Public Class SCT_ModulBusinessFacade
#Region "Private Variables"

        Private SCT_ModulMapper As IMapper
        Private _Transaction As IDbTransaction

#End Region

#Region "Constructors/Destructors/Finalizers"

        Public Sub New()

            SCT_ModulMapper = MapperFactory.GetInstance().GetMapper(GetType(SCT_Modul).ToString())
        End Sub
#End Region

#Region "Public Methods"

        Public Function Retrieve(ByVal oObjectTransporter As IObjectTransporter) As SCT_Modul
            Return CType(SCT_ModulMapper.Retrieve(oObjectTransporter), SCT_Modul)
        End Function

        Public Function RetrieveListPaging(ByVal PageSize As Int32, ByVal CurrentPage As Int32, ByVal OrderBy As String, ByVal oObjectTransporter As IObjectTransporter, ByVal SearchCondition As String, ByRef RowCount As Int32) As ArrayList
            Return SCT_ModulMapper.RetrieveListPaging(PageSize, CurrentPage, OrderBy, oObjectTransporter, SearchCondition, RowCount)
        End Function


        Public Function RetrieveList(ByVal oObjectTransporter As IObjectTransporter) As ArrayList
            Return SCT_ModulMapper.RetrieveList(oObjectTransporter)
        End Function

        Public Function Create(ByVal oObjectTransporter As IObjectTransporter) As Object
            Return SCT_ModulMapper.Insert(oObjectTransporter)
        End Function

        Public Function Delete(ByVal oObjectTransporter As IObjectTransporter) As Int32
            Return SCT_ModulMapper.Delete(oObjectTransporter)
        End Function

        Public Function Update(ByVal oObjectTransporter As IObjectTransporter) As Int32
            Return SCT_ModulMapper.Update(oObjectTransporter)
        End Function

        Public Sub UseTransaction(ByVal oTransaction As IDbTransaction)
            SCT_ModulMapper.UseTransaction(oTransaction)
            _Transaction = oTransaction
        End Sub

#End Region
    End Class
End Namespace
