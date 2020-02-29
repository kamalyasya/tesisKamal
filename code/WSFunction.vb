Imports System.Web
Imports System.Web.Services
Imports System.IO
Imports System.Net
Imports IMFI.SCT.Presentation.Web
Imports IMFI.SCT.DomainObjects
Imports IMFI.Framework.Persistance.DomainObjects.Core
Imports System.Reflection
Imports System.Data.SqlClient
Imports IMFI.SCT.Common
Imports System.Text.RegularExpressions

Public Class WSFunction

#Region "Custom Method"

    Public Function CekLineUserByID(ByRef LineID As String) As ArrayList
        Dim oSearchCondition As String = "LineID = '" + LineID + "'"
        Dim arLineUser As ArrayList = New LineUserMapper().RetrieveWithCondition(oSearchCondition, "LineUserID DESC")

        Return arLineUser
    End Function

    Public Function CekLineUserByNoData(ByRef LineUserID As Int64) As SCT_LineUser
        Return New LineUserMapper().Retrieve((New ObjectTransporter(New SCT_LineUser(LineUserID), (New UserIdentification).GetUserCredential)))
    End Function

    Public Function CreateLineUser(ByRef oLine As SCT_LineUser) As Int64
        Return New LineUserMapper().Insert(oLine)
    End Function

    Public Function CekLineKonsumen(ByRef LineID As String) As ArrayList
        Dim oSearchCondition As String = "IDLine = '" + LineID + "'"
        Dim arLineKonsumen As ArrayList = New LineKonsumenMapper().RetrieveWithCondition(oSearchCondition, "NoDataLine DESC")

        Return arLineKonsumen
    End Function

    Public Function CreateLineKonsumen(ByRef oLine2 As SCT_LineKonsumen) As SCT_LineKonsumen
        Dim oLineInsert = New LineKonsumenMapper().Insert(oLine2)

        Return oLineInsert
    End Function

    Public Function PendaftaranLineUser(ByRef oRowLine As SCT_LineUser, ByVal incomingmessage As String) As String
        Dim Message = ""

        If oRowLine.DialogFlow = 0 Then
            'DialogFlow = 0 -> user diminta memasukkan nomor HP ke SCT_LineUser
            Message = "Silahkan melakukan pendaftaran dengan mengetik DAFTAR[spasi]NomorHP"
            'update dialogflow
            oRowLine.DialogFlow = 1

			Dim LineUserUpdate As SCT_LineUser

            LineUserUpdate = (New LineUserMapper).Update(oRowLine)
            
        ElseIf oRowLine.DialogFlow = 1 Then
            'DialogFlow = 1 -> User memasukkan Nomor HP
            If incomingmessage.Length >= 5 Then
                Dim application = incomingmessage.Substring(0, 6)

                If (application.ToUpper = "DAFTAR") Then
                    'Mengubah format 0xxxxxx menjadi +62xxxsxx----------
                    Dim nomorHP = RemoveWhitespace(incomingmessage.Substring(6, incomingmessage.Length - 6))

                    If nomorHP.Substring(0, 1) = "+" Then
                    Else
                        nomorHP = nomorHP.Substring(1, nomorHP.Length - 1)
                        nomorHP = "+62" + nomorHP
                    End If

                    'Mengecek apakah nomor hp sesuai (semua harus integer)
                    If Regex.IsMatch(nomorHP.Substring(3, nomorHP.Length - 3), "^[0-9 ]+$") Then
                        'Mengecek apakah nomor HP sudah terdaftar dalam database
                        Dim SearchCondition = "noHP = '" + nomorHP + "'"
                        Dim arRegistrasiUserHdr As ArrayList = New RegistrasiUserHeaderMapper().RetrieveWithCondition(SearchCondition)

                        If (arRegistrasiUserHdr.Count > 0) Then
                            Dim arLineUser As ArrayList = New LineUserMapper().RetrieveWithCondition(SearchCondition, "LineUserID ASC")

                            If (arLineUser.Count > 0) Then
                                Message = "Nomor HP anda sudah terdaftar di akun yang berbeda silahkan masukkan nomor HP yang lain"
                            Else
                                'Memasukan nomor HP ke database LineUser dan generate OTP
                                oRowLine.OTP = GenerateOTP()
                                oRowLine.NoHP = nomorHP
                                oRowLine.DialogFlow = 2

                                Dim LineUserUpdate As SCT_LineUser = (New LineUserMapper).Update(oRowLine)

                                Message = "Silahkan masukkan kode OTP yang dikirimkan melalui SMS, atau batalkan pendaftaran nomor HP dengan mengetik BATAL"

                                '2018.12.05 - sidik - ini kodingan untuk kirim OTP via SMS
                                Dim connectionString As String = ConfigurationManager.ConnectionStrings("DBData").ConnectionString
                                Dim connection = New SqlConnection(connectionString)
                                Dim command As New SqlCommand

                                connection.Open()
                                command.Connection = connection
                                command.CommandType = CommandType.StoredProcedure

                                Dim cmd As SqlCommand = New SqlCommand("SP_Send_OTP", connection)

                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.Parameters.AddWithValue("@NoHP", oRowLine.NoHP)
                                cmd.Parameters.AddWithValue("@ReplyMessage", "Silahkan masukkan OTP : " + oRowLine.OTP)
                                cmd.Parameters.AddWithValue("@ApplicationFlag", "KOL")
                                cmd.Parameters.AddWithValue("@DeviceID", "3")
                                cmd.Parameters.AddWithValue("@IsRequestStatus", "1")

                                ' Ask the command to create an SqlDataReader on the result of the sproc'
                                Using r = cmd.ExecuteReader()

                                End Using
                                'Sampe sini kodingan untuk kirim OTP via SMS
                            End If

                        Else
                            Message = "Nomor anda Hp tidak terdaftar dalam database kami, silahkan hubungi ITHelpdesk Perusahaan Kami"
                        End If
                    Else
                        Message = "Format nomor HP salah. Silahkan masukkan nomor hp kembali"
                    End If
                Else
                    Message = "Silahkan melakukan pendaftaran dengan mengetik DAFTAR[spasi]NomorHP"
                End If
            Else
                Message = "Silahkan melakukan pendaftaran dengan mengetik DAFTAR[spasi]NomorHP"
            End If

        ElseIf oRowLine.DialogFlow = 2 Then
            'DialogFlow = 2 -> User memasukkan kode OTP
            Dim kodeOTP = incomingmessage

            If (kodeOTP = oRowLine.OTP) Then
                oRowLine.Status = 1
                oRowLine.DialogFlow = 0

                Dim LineUserUpdate As SCT_LineUser = (New LineUserMapper).Update(oRowLine)

                Message = "Pendaftaran Berhasil. Silahkan ketik MENU untuk melihat menu collection yg dapat Anda akses"

            ElseIf incomingmessage.ToUpper = "BATAL" Then
                oRowLine.Status = 0
                oRowLine.DialogFlow = 1

                Dim LineUserUpdate As SCT_LineUser = (New LineUserMapper).Update(oRowLine)

                Message = "Pendaftaran dibatalkan, silahkan melakukan pendaftaran kembali dengan mengetik DAFTAR[spasi]Nomor HP"
            Else
                Message = "Kode OTP salah, Silahkan masukkan kode OTP yang dikirimkan melalui SMS, atau batalkan pendaftaran nomor HP dengan mengetik BATAL"
            End If

        End If

        Return Message
    End Function

    Public Function GetInfo(ByRef LineID As String, ByVal incomingmessage As String) As String
        Dim message = ""
        Dim oResult As Object

        '2019.03.20 - sidik - ini deklarasi variabel untuk nyimpen hasil query
        Dim Nama As New List(Of String)
        Dim Modul As New List(Of String)
        Dim Template As New List(Of String)
        Dim Contoh As New List(Of String)

        '2019.03.20 - sidik - ini untuk konek ke database dan jalanin query
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DBData").ConnectionString
        Using connObj As New SqlClient.SqlConnection(connectionString)
            Using cmdObj As New SqlClient.SqlCommand(
                "SELECT slu.LineUserID, slu.LineID, slu.NoHP, srh.Nama, slu.Status AS isUserAktif,sm.Keterangan, sm.KodeModul, sm.KodeModul + '[spasi]' + replace(replace(sm.[Parameter],'@',''),',','[spasi]') AS Template,sm.SMSTemplate AS Contoh,srh.IsAktif AS isModulAktif FROM dbo.SCT_LineUser slu INNER JOIN dbo.SCT_Registrasi_Hdr srh ON srh.NoHP = slu.NoHP INNER JOIN dbo.SCT_Registrasi_Dtl srd ON srd.NoDataRegistrasiHdr = srh.NoDataRegistrasiHdr INNER JOIN dbo.SCT_Modul sm ON sm.NoDataModul = srd.NoDataModul WHERE slu.LineID ='" + LineID + "'",
                connObj)

                connObj.Open()
                Using readerObj As SqlClient.SqlDataReader = cmdObj.ExecuteReader
                    'This will loop through all returned records 
                    While readerObj.Read
                        Nama.Add(readerObj("Nama").ToString)
                        Modul.Add(readerObj("Keterangan").ToString)
                        Template.Add(readerObj("Template").ToString)
                        Contoh.Add(readerObj("Contoh").ToString)
                        'handle returned value before next loop here
                    End While
                End Using
                connObj.Close()
            End Using
        End Using
        'jalanin query selesai sampe disini

        '2019.03.20 - sidik - ngecek pesan yg masuk dari user lebih dari 3 karakter atau ngga
        If incomingmessage.Length > 3 Then
            Dim pesanMasuk = incomingmessage.Substring(0, 4)
            '2019.03.20 - sidik - ngecek apakah pesan yg masuk dari user termasuk ke kata kunci pengecekan KOLEKTOR
            If pesanMasuk.ToUpper = "KOL " Or pesanMasuk.ToUpper = "BLK " Or pesanMasuk.ToUpper = "MSN " Or pesanMasuk.ToUpper = "RNK " Then
                '2019.03.20 - sidik - ini untuk proses inserting ke SCT_InboxLine
                
                'mengambil data dari tabel SCT_LineUser
                Dim oLineNoHP As ArrayList = New LineUserMapper().RetrieveWithCondition("LineID = '" + LineID + "'", "LineID desc")

                'memasukkan data ke tabel SCT_InboxLineuser
                Dim dateToday As DateTime = DateTime.Today
                Dim oNewInboxLine = New SCT_InboxLine

                'oNewInboxLine.InboxLineID = nextID
                oNewInboxLine.SMSMessage = incomingmessage
                oNewInboxLine.NoHP = CType(oLineNoHP(0), SCT_LineUser).NoHP
                oNewInboxLine.WaktuSMS = dateToday

                If incomingmessage.Length > 3 Then
                    oNewInboxLine.ApplicationFlag = incomingmessage.Substring(0, 3).ToUpper
                Else
                    oNewInboxLine.ApplicationFlag = "Invalid"
                End If

                oResult = New InboxLineMapper().Insert(oNewInboxLine)

                'mengambil balasan dari sistem
                Dim oReplyInboxLine As SCT_InboxLine = New InboxLineMapper().Retrieve(oResult)

                If Not IsNothing(oReplyInboxLine) Then
                    message = oReplyInboxLine.ReplyMessage
                Else
                    message = "Reply tidak ditemukan"
                End If


                '2019.03.20 - sidik - ini untuk ngecek kalo pesan yg diinput user adalah HELP
            ElseIf pesanMasuk.ToUpper = "HELP" Then
                If Modul.Count <> 0 Then
                    message = "Untuk Template Modul, dapat diketik sebagai berikut : \n"

                    For Each templateModul As String In Template
                        message = message + "\n" _
                                & templateModul
                    Next

                    message = message + "\n\n" _
                                & "Untuk Contoh pengecekan Modul, dapat diketik sebagai berikut : \n"

                    For Each contohModul As String In Contoh
                        message = message + "\n" _
                                & contohModul
                    Next

                End If
            Else
                If Modul.Count <> 0 Then
                    message = "Hai, " + Nama.Item(0) + "\n" _
                                & "Menu yang dapat anda akses adalah : "

                    For Each isiModul As String In Modul
                        message = message + "\n" _
                                & isiModul
                    Next

                    message = message + "\n\n" _
                                & "Jika anda ingin mengetahui template pesan, silahkan ketik HELP"
                End If
            End If
        Else
            If Modul.Count <> 0 Then
                message = "Hai, " + Nama.Item(0) + "\n" _
                            & "Menu yang dapat anda akses adalah : "

                For Each isiModul As String In Modul
                    message = message + "\n" _
                            & isiModul
                Next

                message = message + "\n\n" _
                            & "Jika anda ingin mengetahui template pesan, silahkan ketik HELP"
            End If
        End If

        Return message
    End Function

    Protected Function GenerateOTP() As String
        Dim alphabets As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim small_alphabets As String = "abcdefghijklmnopqrstuvwxyz"
        Dim numbers As String = "1234567890"
        Dim characters As String = numbers
        Dim length As Integer = Integer.Parse(6)
        Dim otp As String = String.Empty

        For i As Integer = 0 To length - 1
            Dim character As String = String.Empty

            Do
                Dim index As Integer = New Random().Next(0, characters.Length)

                character = characters.ToCharArray()(index).ToString()
            Loop While otp.IndexOf(character) <> -1
            otp += character
        Next

        Return otp
    End Function

    Function RemoveWhitespace(fullString As String) As String
        Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
    End Function

#End Region
End Class
