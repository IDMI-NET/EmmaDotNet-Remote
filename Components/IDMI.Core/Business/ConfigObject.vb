Imports System.Configuration
Imports System.Collections.Specialized

Namespace Business

    '   NAME         : Config 
    '   DATE CREATED : 03/02/11
    '   MOD HISTORY  : 
    ''' <summary>
    ''' Helper object for Web configuration data. Subclass of NameValueCollection.
    ''' </summary>
    ''' 
    Public Class ConfigObject
        Inherits NameValueCollection

#Region "Constructors"

        Public Sub New()
            LoadDetailsFromConfig()
        End Sub

#End Region

#Region "Private Instance Methods"

        '   NAME         : LoadDetailsFromConfig
        '   DATE CREATED : 03/02/11
        '   MOD HISTORY  : 
        ''' <summary>
        ''' Enumerate AppSettings collection, add key/value pairs to self.
        ''' </summary>

        Private Sub LoadDetailsFromConfig()
            Dim myAppSettings As NameValueCollection = New NameValueCollection()
            Dim myEnumerator As IEnumerator

            myAppSettings = ConfigurationManager.AppSettings
            myEnumerator = myAppSettings.GetEnumerator()

            Do While myEnumerator.MoveNext()
                Me.Add(myEnumerator.Current, myAppSettings(myEnumerator.Current))
            Loop
        End Sub

#End Region

    End Class
End Namespace
