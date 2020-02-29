Imports System.Web
Imports System.Web.Services
Imports System.IO
Imports System.Net
Imports IMFI.SCT.Presentation.Web
Imports IMFI.SCT.DomainObjects
Imports IMFI.SCT.BusinessFacade
Imports IMFI.SCT.DataMapper
Imports IMFI.Framework.Persistance.DomainObjects.Core
Imports System.Reflection
Imports System.Data.SqlClient
Imports IMFI.SCT.Common

Public Class LineChatbotCollector_GetInfo
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        IMFI.SCT.BusinessFacade.FrameworkConfigurationWrapper.Configure()

        'Mengambil kiriman dari LINE
        Dim oJSONTextFormat As String = New StreamReader(context.Request.InputStream).ReadToEnd
        Dim oJsonResult As SCT_LineMessage = ConvertToJSONFormat.ConvertToString(oJSONTextFormat)
        Dim LineID = oJsonResult.LineID
        Dim incomingmessage = oJsonResult.Message

        'Melakukan pengecekan apakah LineID pengirim sudah ada di database
        Dim oArLineUser As ArrayList = New WSFunction().CekLineUserByID(LineID)
        Dim message = ""
        Dim oSCT_LineUser = New SCT_LineUser
        Dim LineUserID As Int64

        If (oArLineUser.Count = 0) Then
            'Jika LineID belum ada di database
            oSCT_LineUser.LineID = LineID
            oSCT_LineUser.Status = 0
            oSCT_LineUser.DialogFlow = 1

            LineUserID = New WSFunction().CreateLineUser(oSCT_LineUser)
            oSCT_LineUser.LineUserID = LineUserID
            'oSCT_LineUser = New WSFunction().CekLineUserByNoData(LineUserID)
        Else
            oSCT_LineUser = CType(oArLineUser(0), SCT_LineUser)
        End If


        If oSCT_LineUser.Status = 0 Then
            'Status = 0 -> user belum melakukan registrasi
            message = New WSFunction().PendaftaranLineUser(oSCT_LineUser, incomingmessage)

        ElseIf oSCT_LineUser.Status = 1 Then
            'Status = 1 -> user sudah melakuan registrasi
            message = New WSFunction().GetInfo(LineID, incomingmessage)
        End If

        Dim replyLineBot As String = ConvertToJSONFormat.ConvertToJSON(oJsonResult.ReplyToken, message)

        context.Response.ContentType = "application/json"
        context.Response.Write(replyLineBot)
    End Sub

    Private Function SendPOST(_URL As String, _JSONFormat As String)
        Try
            Dim oHttpWebRequest As HttpWebRequest = DirectCast(WebRequest.Create(_URL), HttpWebRequest)
            oHttpWebRequest.ContentType = "application/json"
            oHttpWebRequest.Method = "POST"

            Dim oStreamWriter As StreamWriter = New StreamWriter(oHttpWebRequest.GetRequestStream())
            oStreamWriter.Write(_JSONFormat)
            oStreamWriter.Flush()
            oStreamWriter.Close()

            Dim oHttpResponse As HttpWebResponse = oHttpWebRequest.GetResponse()
            Dim oStreamReader As StreamReader = New StreamReader(oHttpResponse.GetResponseStream())
            Dim oResult = oStreamReader.ReadToEnd()

            Return oResult.ToString
        Catch ex As WebException
            Return ex.Message
        End Try
    End Function

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class