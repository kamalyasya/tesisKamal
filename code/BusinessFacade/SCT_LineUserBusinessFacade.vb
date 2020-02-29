
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
'   Purpose     : SCT_LineUser Business Facade.                      
'   Called By   :                                          
'															
'************************************************************

#End Region

#Region "History"

'************************************************************
'															
'   Created On  : 10/5/2018 - 1:18:08 PM                   
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
Imports IMFI.SCT.Common
Imports System.Text.RegularExpressions

#End Region

#End Region

Namespace IMFI.SCT.BusinessFacade

    Public Class SCT_LineUserBusinessFacade
#Region "Private Variables"

        Private SCT_LineUserMapper As IMapper2
        Private _Transaction As IDbTransaction

#End Region

#Region "Constructors/Destructors/Finalizers"

        Public Sub New()
            SCT_LineUserMapper = MapperFactory2.GetInstance().GetMapper(GetType(SCT_LineUser).ToString())
        End Sub
#End Region

#Region "Public Methods"

        Public Function Create(ByVal oObjectTransporter As IObjectTransporter) As Object
            Return SCT_LineUserMapper.Insert(oObjectTransporter)
        End Function

        Public Function Retrieve(ByVal oObjectTransporter As IObjectTransporter) As SCT_LineUser
            Return CType(SCT_LineUserMapper.Retrieve(oObjectTransporter), SCT_LineUser)
        End Function

        Public Function RetrieveListPaging(ByVal PageSize As Int32, ByVal CurrentPage As Int32, ByVal OrderBy As String, ByVal oObjectTransporter As IObjectTransporter, ByVal SearchCondition As String, ByRef RowCount As Int32) As ArrayList
            Return SCT_LineUserMapper.RetrieveListPaging(PageSize, CurrentPage, OrderBy, oObjectTransporter, SearchCondition, RowCount)
        End Function

        Public Function RetrieveWithCondition(ByVal SearchCondition As String, ByVal OrderBy As String, ByVal oObjectTransporter As IObjectTransporter) As ArrayList
            Return SCT_LineUserMapper.RetrieveWithCondition(SearchCondition, OrderBy, oObjectTransporter)
        End Function

        Public Function RetrieveList(ByVal oObjectTransporter As IObjectTransporter) As ArrayList
            Return SCT_LineUserMapper.RetrieveList(oObjectTransporter)
        End Function

        Public Function Update(ByVal oObjectTransporter As IObjectTransporter) As Int32
            Return SCT_LineUserMapper.Update(oObjectTransporter)
        End Function

        'public Function Delete(ByVal oObjectTransporter as IObjectTransporter) as Int32
        '	return SCT_LineUserMapper.Delete(oObjectTransporter)
        'End Function

        Public Function Delete(ByVal oObjectTransporter As IObjectTransporter) As Result
            Dim oResult As Result

            Try
                oResult = New Result(SCT_LineUserMapper.Delete(oObjectTransporter), "")
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
            SCT_LineUserMapper.UseTransaction(oTransaction)
            _Transaction = oTransaction
        End Sub

#End Region
#Region "Custom Method"
        Public Function CekLineUser(ByRef LineID As String) As ArrayList

            Dim oSearchCondition As String = "LineID = '" + LineID + "'"
            Dim arLineUser As ArrayList = Me.RetrieveWithCondition(oSearchCondition, "LineUserID DESC", (New ObjectTransporter(New SCT_LineUser, Nothing)))

            Return arLineUser
        End Function

        Public Function CreateLineUser(ByRef oLine As SCT_LineUser) As SCT_LineUser

            Dim oLineInsert = Me.Create(New ObjectTransporter(oLine, (New UserIdentification).GetUserCredential))

            Return oLineInsert
        End Function

        Public Function PendaftaranLineUser(ByRef oRowLine As SCT_LineUser, ByVal incomingmessage As String) As String
            Dim Message = ""

            If oRowLine.DialogFlow = 0 Then
                'DialogFlow = 0 -> user belum memasukkan nomor HP ke SCT_LineUser

                Message = "Silahkan masukkan nomor telepon anda"

                'update dialogflow
                oRowLine.DialogFlow = 1
                Dim LineUserUpdate As Integer = (New SCT_LineUserBusinessFacade).Update(New ObjectTransporter(oRowLine, (New UserIdentification).GetUserCredential))

            ElseIf oRowLine.DialogFlow = 1 Then
                'DialogFlow = 1 -> User memasukkan Nomor HP

                Dim nomorHP = incomingmessage
                Dim tempNomorHP = nomorHP
                'Mengecek apakah format nomor hp sudah benar dan
                'Mengubah format 0xxxxxx menjadi +62xxxxx

                If nomorHP.Substring(0, 1) = "+" Then
                Else
                    nomorHP = nomorHP.Substring(1, nomorHP.Length - 1)
                    nomorHP = "+62" + nomorHP

                End If

                If Regex.IsMatch(nomorHP.Substring(3, nomorHP.Length - 3), "^[0-9 ]+$") Then
                    'Jika format benar
                    Message = " Apakah nomor " + nomorHP + " sudah benar? [ya/tidak]"

                    'Update nomor HP
                    oRowLine.NoHP = nomorHP
                    oRowLine.DialogFlow = 2
                    Dim LineUserUpdate As Integer = (New SCT_LineUserBusinessFacade).Update(New ObjectTransporter(oRowLine, (New UserIdentification).GetUserCredential))

                Else
                    Message = "Format nomor HP salah. Silahkan masukkan nomor hp kembali"

                End If

            ElseIf oRowLine.DialogFlow = 2 Then
                'DialogFlow = 2 -> Konfirmasi Nomor HP

                Dim konfirmasi = incomingmessage

                If konfirmasi.ToUpper = "YA" Then

                    'Cek apakah nomor HP sudah terdaftar
                    Dim nomorHP = oRowLine.NoHP

                    If (nomorHP.Substring(0, 1)) = "0" Then
                        nomorHP = nomorHP.Substring(1, oRowLine.NoHP.Length)
                        nomorHP = "+62" & nomorHP

                    End If

                    Dim condition = "NoHP = '" + nomorHP + "'"
                    Dim oRowRegistrasiHdr As ArrayList = New SCT_Registrasi_HdrBusinessFacade().RetrieveListPaging(-1, 0, "NoDataRegistrasiHdr ASC", (New ObjectTransporter(New SCT_Registrasi_Hdr, (New UserIdentification).GetUserCredential)), condition, 10)

                    If (oRowRegistrasiHdr.Count > 0) Then
                        Message = "Silahkan masukkan kode OTP yang dikirimkan melalui SMS"

                        oRowLine.OTP = GenerateOTP()
                        oRowLine.DialogFlow = 3
                        Dim LineUserUpdate As Integer = (New SCT_LineUserBusinessFacade).Update(New ObjectTransporter(oRowLine, (New UserIdentification).GetUserCredential))

                    Else
                        Message = "Nomor HP tidak terdaftar. Silahkan masukkan nomor HP lain"

                        oRowLine.DialogFlow = 1
                        Dim LineUserUpdate As Integer = (New SCT_LineUserBusinessFacade).Update(New ObjectTransporter(oRowLine, (New UserIdentification).GetUserCredential))

                    End If

                ElseIf konfirmasi.ToUpper = "TIDAK" Then
                    Message = "Silahkan masukkan nomor HP anda"

                    oRowLine.NoHP = ""
                    oRowLine.DialogFlow = 1
                    Dim LineUserUpdate As Integer = (New SCT_LineUserBusinessFacade).Update(New ObjectTransporter(oRowLine, (New UserIdentification).GetUserCredential))

                Else
                    Message = "Apakah nomor " + oRowLine.NoHP + " tersebut sudah benar? [ya/tidak]"

                End If

            ElseIf oRowLine.DialogFlow = 3 Then
                'DialogFlow = 3 -> User input kode OTP

                Dim kodeOTP = incomingmessage
                Message = "Kode OTP salah"

                If (kodeOTP = oRowLine.OTP) Then
                    Message = "Pendaftaran Berhasil"

                    oRowLine.Status = 1
                    oRowLine.DialogFlow = 0
                    Dim LineUserUpdate As Integer = (New SCT_LineUserBusinessFacade).Update(New ObjectTransporter(oRowLine, (New UserIdentification).GetUserCredential))

                Else
                    Message = "Kode OTP salah"

                End If
            End If
            Return Message
        End Function

        Public Function GetInfo(ByRef LineID As String, ByVal incomingmessage As String) As String

            Dim message = ""
            Dim oResult As Object

            'mengambil InboxLineID terakhir di tabel SCT_InboxLine
            Dim oInboxLine As ArrayList = New SCT_InboxLineBusinessFacade().RetrieveWithCondition("", "InboxLineID desc", New ObjectTransporter(New SCT_InboxLine, (New UserIdentification).GetUserCredential))
            Dim nextID = (CType(oInboxLine(0), SCT_InboxLine).InboxLineID + 1)

            'mengambil data dari tabel SCT_LineUser
            Dim oLineNoHP As ArrayList = Me.RetrieveWithCondition("LineID = '" + LineID + "'", "LineID desc", New ObjectTransporter(New SCT_LineUser, (New UserIdentification).GetUserCredential))

            Dim dateToday As DateTime = DateTime.Today

            Dim oNewInboxLine = New SCT_InboxLine

            'memasukkan data ke tabel SCT_InboxLineuser
            oNewInboxLine.InboxLineID = nextID
            oNewInboxLine.SMSMessage = incomingmessage
            oNewInboxLine.NoHP = CType(oLineNoHP(0), SCT_LineUser).NoHP
            oNewInboxLine.WaktuSMS = dateToday
            If incomingmessage.Length > 3 Then
                oNewInboxLine.ApplicationFlag = incomingmessage.Substring(0, 3).ToUpper
            Else
                oNewInboxLine.ApplicationFlag = "Invalid"
            End If
            oResult = New SCT_InboxLineBusinessFacade().Create(New ObjectTransporter(oNewInboxLine, New UserIdentification().GetUserCredential))

            'mengambil balasan dari sistem
            Dim oReplyInboxLine As SCT_InboxLine = New SCT_InboxLineBusinessFacade().Retrieve(New ObjectTransporter(New SCT_InboxLine(nextID), (New UserIdentification).GetUserCredential))

            message = oReplyInboxLine.ReplyMessage

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

#End Region

    End Class

End Namespace
