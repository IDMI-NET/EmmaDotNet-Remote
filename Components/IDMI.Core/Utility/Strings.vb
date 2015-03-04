Imports System.Text.RegularExpressions

Namespace Utility

    '   NAME         : Utility.Strings
    '   DATE CREATED : 06/24/11
    '   MOD HISTORY  : 
    ''' <summary>
    ''' String utility class.
    ''' </summary>
    ''' 
    Public Class Strings

#Region "Public Static Methods"

        '   NAME         : Scrub 
        '   DATE CREATED : 04/27/11
        '   MOD HISTORY  : 
        ''' <summary>
        ''' Scrub text input.
        ''' </summary>
        ''' 
        Public Shared Function Scrub(ByVal currentString As String) As String
            Dim myRegEx As New Regex("[^0-9a-zA-Z_\-{}()\[\]\.&, ]")
            currentString = currentString.Replace(vbNewLine, String.Empty)
            Return myRegEx.Replace(currentString.Trim(), String.Empty)
        End Function

#End Region

    End Class
End Namespace
