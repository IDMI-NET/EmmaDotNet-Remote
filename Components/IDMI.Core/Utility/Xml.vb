Imports System.Xml

Namespace Utility

    '   NAME         : Xml 
    '   DATE CREATED : 03/11/11
    '   MOD HISTORY  : 
    ''' <summary>
    ''' Xml Utility class.
    ''' </summary>
    ''' 
    Public Class Xml

#Region "Public Static Methods"

        '   NAME         : XmlDocToString 
        '   DATE CREATED : 03/11/11
        '   MOD HISTORY  : 
        ''' <summary>
        ''' Convert XmlDocument to raw XML string.
        ''' </summary>
        ''' 
        Public Shared Function XmlDocToString(ByVal currentXmlDocument As XmlDocument) As String
            Dim myStringWriter As New System.IO.StringWriter
            Dim myXmlWriter As New System.Xml.XmlTextWriter(myStringWriter)

            currentXmlDocument.WriteTo(myXmlWriter)

            Return myStringWriter.ToString()
        End Function

#End Region

    End Class
End Namespace
