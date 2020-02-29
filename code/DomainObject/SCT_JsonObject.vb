Public Class SCT_JsonObject
    Public Property events() As Events()

End Class

Public Class Events
    Public type As String
    Public replyToken As String
    Public source As Source
    Public timestamp As String
    Public message As Message
End Class

Public Class Source
    Public userID As String
    Public type As String
End Class

Public Class Message
    Public type As String
    Public id As String
    Public text As String
End Class


Public Class SCT_JsonObjectLocationLine
    Public Property events() As EventsLocation()

End Class

Public Class EventsLocation
    Public type As String
    Public replyToken As String
    Public source As SourceLocation
    Public timestamp As String
    Public message As MessageLocation
End Class

Public Class SourceLocation
    Public userID As String
    Public type As String
End Class

Public Class MessageLocation
    Public type As String
    Public title As String
    Public address As String
    Public latitude As String
    Public longitude As String
End Class


Public Class SCT_JsonObjectPostbackLine
    Public Property events() As EventsPostback()

End Class

Public Class EventsPostback
    Public type As String
    Public replyToken As String
    Public source As SourcePostback
    Public timestamp As String
    Public postback As Postback
End Class

Public Class SourcePostback
    Public userID As String
    Public type As String
End Class

Public Class Postback
    Public data As String
End Class



Public Class SCT_JsonObjectTelegram
    Public Property update_id As String
    Public Property message As Messages

End Class

Public Class Messages
    Public message_id As String
    Public from As From
    Public chat As Chat
    Public date_chat As DateTime
    Public text As String
End Class

Public Class From
    Public id As String
    Public is_Bot As Boolean
    Public first_name As String
    Public last_name As String
    Public language_code As String
End Class

Public Class Chat
    Public id As String
    Public first_name As String
    Public last_name As String
    Public type As String
End Class

