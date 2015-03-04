Imports System.IO

Namespace Utility

    '   NAME         : Utility.Stream 
    '   DATE CREATED : 07/01/11
    '   MOD HISTORY  : 

    Public Class Stream

#Region "Public Static Methods"

        '   NAME         : SplitOnChar
        '   DATE CREATED : 07/01/11
        '   MOD HISTORY  : 
        ''' <summary>
        ''' Split an input stream on a given charcter.
        ''' </summary>
        ''' 
        Public Shared Function SplitOnChar(ByVal currentStream As System.IO.Stream, ByVal currentSplitChar As Char) As String()
            Dim myStreamReader As StreamReader
            Dim myStream As String = String.Empty
            Dim myStringArray As String() = Nothing

            myStreamReader = New StreamReader(currentStream)
            myStream = myStreamReader.ReadToEnd()

            If myStream.Length > 0 Then
                myStringArray = myStream.Split(currentSplitChar)
            End If

            myStreamReader.Close()
            myStreamReader.Dispose()

            Return myStringArray
        End Function

#End Region

    End Class
End Namespace
