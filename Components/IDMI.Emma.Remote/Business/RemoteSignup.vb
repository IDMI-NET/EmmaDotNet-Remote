Imports IDMI.Core.Business
Imports IDMI.Emma.Remote.Enums
Imports System.Text

Namespace Business

    '   NAME         : RemoteSignup
    '   DATE CREATED : 08/01/11
    '   MOD HISTORY  : 06/05/12 - Added custom member field array.
    '                  11/22/11 - Additional member fields.
    ''' <summary>
    ''' </summary>
    ''' 
    <Obsolete("RemoteSignup API has been deprecated by MyEmma. See http://api.myemma.com/.")>
    Public Class RemoteSignup

#Region "Fields"

        Private myUserName As String
        Private myPassword As String
        Private myAccountId As String
        Private myGroupId As String
        Private myMemberFirstName As String = Nothing
        Private myMemberLastName As String = Nothing
        Private myMemberEmail As String
        Private myUri As String
        Private myResponseCode As RemoteSignupResponse

        Private myMemberAddress As String = Nothing
        Private myMemberCity As String = Nothing
        Private myMemberPostalCode As String = Nothing
        Private myMemberState As String = Nothing
        Private myMemberCustom As String() = Nothing

        Private myMemberCompany As String = Nothing
        Private myMemberCountry As String = Nothing
        Private myMemberPhone As String = Nothing
        Private myMemberFax As String = Nothing
        Private myMemberStateProvince As String = Nothing

#End Region

#Region "Properties"
        Public Property UserName As String
            Get
                Return myUserName
            End Get
            Set(value As String)
                myUserName = value.Trim()
            End Set
        End Property

        Public Property Password As String
            Get
                Return myPassword
            End Get
            Set(value As String)
                myPassword = value.Trim()
            End Set
        End Property

        Public Property AccountId As String
            Get
                Return myAccountId
            End Get
            Set(value As String)
                myAccountId = value.Trim()
            End Set
        End Property

        Public Property GroupId As String
            Get
                Return myGroupId
            End Get
            Set(value As String)
                myGroupId = value.Trim()
            End Set
        End Property

        Public Property MemberFirstName As String
            Get
                Return myMemberFirstName
            End Get
            Set(value As String)
                myMemberFirstName = value.Trim()
            End Set
        End Property

        Public Property MemberLastName As String
            Get
                Return myMemberLastName
            End Get
            Set(value As String)
                myMemberLastName = value.Trim()
            End Set
        End Property

        Public Property MemberEmail As String
            Get
                Return myMemberEmail
            End Get
            Set(value As String)
                myMemberEmail = value.Trim()
            End Set
        End Property

        Public Property Uri As String
            Get
                Return myUri
            End Get
            Set(value As String)
                myUri = value
            End Set
        End Property

        Public ReadOnly Property ResponseCode As RemoteSignupResponse
            Get
                Return myResponseCode
            End Get
        End Property

        Public Property MemberAddress As String
            Get
                Return myMemberAddress
            End Get
            Set(value As String)
                myMemberAddress = value.Trim()
            End Set
        End Property

        Public Property MemberCity As String
            Get
                Return myMemberCity
            End Get
            Set(value As String)
                myMemberCity = value.Trim()
            End Set
        End Property

        Public Property MemberPostalCode As String
            Get
                Return myMemberPostalCode
            End Get
            Set(value As String)
                myMemberPostalCode = value.Trim()
            End Set
        End Property

        Public Property MemberState As String
            Get
                Return myMemberState
            End Get
            Set(value As String)
                myMemberState = value.Trim()
            End Set
        End Property

        Public Property MemberCustom As String()
            Get
                Return myMemberCustom
            End Get
            Set(value As String())
                myMemberCustom = value
            End Set
        End Property

        Public Property MemberCompany As String
            Get
                Return myMemberCompany
            End Get
            Set(value As String)
                myMemberCompany = value.Trim()
            End Set
        End Property

        Public Property MemberCountry As String
            Get
                Return myMemberCountry
            End Get
            Set(value As String)
                myMemberCountry = value.Trim()
            End Set
        End Property

        Public Property MemberPhone As String
            Get
                Return myMemberPhone
            End Get
            Set(value As String)
                myMemberPhone = value.Trim()
            End Set
        End Property

        Public Property MemberFax As String
            Get
                Return myMemberFax
            End Get
            Set(value As String)
                myMemberFax = value.Trim()
            End Set
        End Property

        Public Property MemberStateProvince As String
            Get
                Return myMemberStateProvince
            End Get
            Set(value As String)
                myMemberStateProvince = value.Trim()
            End Set
        End Property
#End Region

#Region "Constructors"

        Public Sub New()
        End Sub

#End Region

#Region "Private Instance Methods"

        '   NAME         : Send
        '   DATE CREATED : 08/01/11
        '   MOD HISTORY  : 06/05/12 - Added fields for company, country, phone, and fax.
        ''' <summary>
        ''' Send RemoteSignup request.
        ''' </summary>
        ''' 
        Public Function Send() As RemoteSignupResponse
            Dim myHttpRequest As HttpRequest
            Dim myDataBuilder As New StringBuilder
            Dim myData As String
            Dim myHttpResponse As String

            With myDataBuilder
                .Append("signup_post=")
                .Append("&emma_account_id=" & myAccountId)
                .Append("&username=" & myUserName)
                .Append("&password=" & myPassword)
                .Append("&group[" & myGroupId & "]=1")
                .Append("&emma_member_email=" & myMemberEmail)

                If Not MemberFirstName Is Nothing Then _
                    .Append("&emma_member_name_first=" & myMemberFirstName)
                If Not MemberLastName Is Nothing Then _
                    .Append("&emma_member_name_last=" & myMemberLastName)
                If Not MemberAddress Is Nothing Then _
                    .Append("&emma_member_address=" & myMemberAddress)
                If Not MemberCity Is Nothing Then _
                    .Append("&emma_member_city=" & myMemberCity)
                If Not MemberPostalCode Is Nothing Then _
                    .Append("&emma_member_postal_code=" & myMemberPostalCode)
                If Not MemberState Is Nothing Then _
                    .Append("&emma_member_state=" & myMemberState)
                If Not MemberCompany Is Nothing Then _
                    .Append("&emma_member_company_name=" & myMemberCompany)
                If Not MemberCountry Is Nothing Then _
                    .Append("&emma_member_country=" & myMemberCountry)
                If Not MemberPhone Is Nothing Then _
                    .Append("&emma_member_phone=" & myMemberPhone)
                If Not MemberFax Is Nothing Then _
                    .Append("&emma_member_fax=" & myMemberFax)
                If Not MemberStateProvince Is Nothing Then _
                    .Append("&emma_member_state_province=" & myMemberStateProvince)

                'Custom fields.
                If Not myMemberCustom Is Nothing Then
                    For Each myString As String In myMemberCustom
                        .Append(myString)
                    Next
                End If
            End With

            myData = myDataBuilder.ToString()

            'Send request.
            myHttpRequest = New HttpRequest(myUri, myData)

            'Bet response.
            myHttpResponse = myHttpRequest.Send()
            myResponseCode = DirectCast(Integer.Parse(myHttpResponse), RemoteSignupResponse)

            Return myResponseCode

        End Function

#End Region

    End Class

End Namespace
