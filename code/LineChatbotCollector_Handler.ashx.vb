Imports System.Web
Imports System.Web.Services
Imports System.IO
Imports System.Net

Public Class LineChatbotCollector_Handler
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim oJSONTextFormat As String = New StreamReader(context.Request.InputStream).ReadToEnd
        Dim oURL As String = ConfigurationManager.AppSettings("URL_LINE_LOCAL")
        Dim oJSON As String = SendPOST(oURL, oJSONTextFormat)
        Dim sendLine As String = SendPOSTLine("https://api.line.me/v2/bot/message/reply", oJSON)

        context.Response.ContentType = "application/json"
        context.Response.Headers.Add("Authorization", "Bearer " + "rvOLmIA7Q+qAF3x3PaxtXgHm8KTruPFtVwz3p9lUQpy5gEEZTC3Ghgp2w0bodKEgepe5k/tHAJT3XLCLKUdYFnBNkabojCruaYJfcUx/fA2Lym6EB9/5yZlkfH7FkXTBZeY15VON/j2ITcZKkvjBwwdB04t89/1O/w1cDnyilFU=")
        context.Response.Write(oJSON)
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

    Private Function SendPOSTLine(_URL As String, _JSONFormat As String)
        Try
            Dim oHttpWebRequest As HttpWebRequest = DirectCast(WebRequest.Create(_URL), HttpWebRequest)

            oHttpWebRequest.ContentType = "application/json"
            oHttpWebRequest.Headers.Add("Authorization", "Bearer " + "rvOLmIA7Q+qAF3x3PaxtXgHm8KTruPFtVwz3p9lUQpy5gEEZTC3Ghgp2w0bodKEgepe5k/tHAJT3XLCLKUdYFnBNkabojCruaYJfcUx/fA2Lym6EB9/5yZlkfH7FkXTBZeY15VON/j2ITcZKkvjBwwdB04t89/1O/w1cDnyilFU=")
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