Imports System.Net
Imports System.IO
Imports System.Text

Namespace Business

    '   NAME         : HttpRequest
    '   DATE CREATED : 08/01/11
    '   MOD HISTORY  : 
    ''' <summary>
    ''' HttpRequest helper class.
    ''' </summary>
    ''' 
    Public Class HttpRequest

#Region "Fields"

        Private myUri As String = String.Empty
        Private myMethod As String = "POST"
        Private myContentType As String = "application/x-www-form-urlencoded"
        Private myContentLength As Long = 0
        Private myData As String = String.Empty
        Private myWebRequest As WebRequest
        Private myWebResponse As WebResponse

#End Region

#Region "Properites"

        Public Property Uri As String
            Get
                Return myUri
            End Get
            Set(value As String)
                myUri = value
            End Set
        End Property

        Public Property Method As String
            Get
                Return myMethod
            End Get
            Set(value As String)
                myMethod = value
            End Set
        End Property

        Public Property ContentType As String
            Get
                Return myContentType
            End Get
            Set(value As String)
                myContentType = value
            End Set
        End Property

        Public ReadOnly Property ContentLength As Long
            Get
                Return myContentLength
            End Get
        End Property

        Public Property Data As String
            Get
                Return myData
            End Get
            Set(value As String)
                myData = value
            End Set
        End Property

        Public ReadOnly Property WebRequest As WebRequest
            Get
                Return myWebRequest
            End Get
        End Property

        Public ReadOnly Property WebResponse As WebResponse
            Get
                Return myWebResponse
            End Get
        End Property

#End Region

#Region "Constructors"

        Public Sub New(ByVal currentUri As String, ByVal currentData As String)
            myUri = currentUri
            myData = currentData
        End Sub

        Public Sub New(ByVal currentUri As String, ByVal currentData As String, ByVal currentMethod As String, _
                       ByVal currentContentType As String, ByVal currentContentLength As Integer)
            myUri = currentUri
            myData = currentData
            myMethod = currentMethod
            myContentType = currentContentType
            myContentLength = currentContentLength
        End Sub

#End Region

#Region "Public Instance Methods"

        '   NAME         : Send 
        '   DATE CREATED : 08/01/11
        '   MOD HISTORY  : 
        ''' <summary>
        ''' Send request; returns response as string.
        ''' </summary>
        ''' <returns>string</returns>
        ''' <remarks></remarks>
        ''' 
        Public Function Send() As String
            Dim myEncoding As New ASCIIEncoding
            Dim myByte() As Byte
            Dim myStream As Stream
            Dim myStreamReader As StreamReader

            'Create request.
            myWebRequest = System.Net.WebRequest.Create(myUri)

            'Set request properties.
            myByte = myEncoding.GetBytes(myData)
            myContentLength = myByte.Length
            myWebRequest.Method = myMethod

            'Write request data.
            If myWebRequest.Method.ToLower = "post" Then
                myWebRequest.ContentType = myContentType
                myWebRequest.ContentLength = myContentLength
                myStream = myWebRequest.GetRequestStream()
                myStream.Write(myByte, 0, myByte.Length)
                myStream.Close()
            End If

            'Make request.
            myWebResponse = myWebRequest.GetResponse()
            myStreamReader = New StreamReader(myWebResponse.GetResponseStream())

            Return myStreamReader.ReadToEnd()
        End Function

#End Region

    End Class

End Namespace
