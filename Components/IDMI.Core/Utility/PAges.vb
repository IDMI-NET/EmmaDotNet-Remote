Imports System.Web.UI.WebControls

Namespace Utility

    '   NAME         : Pages
    '   DATE CREATED : 03/04/15
    '   MOD HISTORY  : 
    ''' <summary>
    ''' Pages utility class.
    ''' </summary>

    Public Class Pages

#Region "Public Static Methods"

        '   NAME         : AddValidatonError
        '   DATE CREATED : 03/04/15
        '   MOD HISTORY  : 	
        ''' <summary>
        ''' Add error to validation summary.
        ''' </summary>

        Public Shared Sub AddValidationError(ByRef p As System.Web.UI.Page, ByVal errorMessage As String, ByVal validationGroup As String)
            Dim myError As New CustomValidator

            With myError
                .ValidationGroup = validationGroup
                .ErrorMessage = errorMessage
                .IsValid = False
            End With

            p.Validators.Add(myError)
        End Sub

        Public Shared Sub AddValidationError(ByRef p As System.Web.UI.Page, ByVal errorMessage As String)
            AddValidationError(p, errorMessage, String.Empty)
        End Sub

#End Region

    End Class
End Namespace