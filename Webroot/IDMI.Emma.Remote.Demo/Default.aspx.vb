Imports IDMI.Core.Utility
Imports IDMI.Emma.Remote.Enums

'   NAME         : EmmaDotNet-Remote Demo
'   DATE CREATED : 03/04/15
'   MOD HISTORY  : 
''' <summary>
''' Demo page for EmmaDotNet-Remote library.
''' </summary>

Partial Class _Default
    Inherits System.Web.UI.Page

#Region "Handlers"

    Protected Sub btnSubmitForm_Click(sender As Object, e As EventArgs) Handles btnSubmitForm.Click
        If Page.IsValid() Then Signup()
    End Sub

#End Region

#Region "Private Methods"

    '   NAME         : Signup
    '   DATE CREATED : 03/04/15
    '   MOD HISTORY  : 	
    ''' <summary>
    ''' Send signup request to remote signup API method.
    ''' </summary>

    Private Sub Signup()
        Dim myRemoteSignupRequest As New IDMI.Emma.Remote.Business.RemoteSignup()
        Dim myResponseCode As Integer = 0

        With myRemoteSignupRequest

            Dim myConfig As New IDMI.Core.Business.ConfigObject()

            .Uri = myConfig("MyEmma_Uri")
            .UserName = myConfig("MyEmma_UserName")
            .Password = myConfig("MyEmma_Password")
            .AccountId = myConfig("MyEmma_AccountId")
            .GroupId = myConfig("MyEmma_GroupId")

            .MemberEmail = EmailAddress.Text.Trim()
            .MemberFirstName = FirstName.Text.Trim()
            .MemberLastName = LastName.Text.Trim()

            myRemoteSignupRequest.Send()
        End With

        Select Case myRemoteSignupRequest.Send()
            Case RemoteSignupResponse.AddedAMember
            Case RemoteSignupResponse.UpdatedAMember
                Response.Redirect("ThankYou.aspx", False)
            Case RemoteSignupResponse.MemberExists
                Pages.AddValidationError(Me, "You are already subscribed to this mailing list!")
            Case Else
                Pages.AddValidationError(Me, "An error has occured. Please contact the administrator for support.")
        End Select

    End Sub

#End Region

End Class
