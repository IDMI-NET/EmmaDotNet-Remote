Imports System.Web
Imports System.Web.UI
Imports System.Text

Namespace Utility

#Region "Controls"

    '   NAME         : Controls
    '   DATE CREATED : 01/10/11
    '   MOD HISTORY  : 
    ''' <summary>
    ''' Controls utility class.
    ''' </summary>

    Public Class Controls

#Region "Public Static Methods"

        '   NAME         : FindControlRecursive
        '   DATE CREATED : 01/19/11
        '   MOD HISTORY  : 	
        ''' <summary>
        ''' Recursive FindControl method, not using Generics.
        ''' </summary>
        ''' <param name="currentParentControl">The parent control to recurse through.</param>
        ''' <param name="currentId">The ID to search for.</param>
        ''' <returns>Control</returns>
        ''' 
        Public Shared Function FindControlRecursive(ByVal currentParentControl As System.Web.UI.Control, ByVal currentId As String) As System.Web.UI.Control
            If currentParentControl.ID = currentId Then
                Return currentParentControl
            End If

            For Each myControl As System.Web.UI.Control In currentParentControl.Controls
                Dim myFoundControl As System.Web.UI.Control = FindControlRecursive(myControl, currentId)

                If Not myFoundControl Is Nothing Then
                    Return myFoundControl
                End If
            Next

            Return Nothing
        End Function

        '   NAME         : FindControlRecursive(Of T)
        '   DATE CREATED : 01/19/11
        '   MOD HISTORY  : 
        ''' <summary>
        ''' Recursive FindControl method using Generics.
        ''' </summary>
        ''' <typeparam name="T">Generic type.</typeparam>
        ''' <param name="currentParentControl">The parent control to recurse through.</param>
        ''' <param name="currentId">The ID to search for.</param>
        ''' <returns>Control of T</returns>
        ''' 
        Public Shared Function FindControlRecursive(Of T As System.Web.UI.Control) _
            (ByVal currentParentControl As System.Web.UI.Control, ByVal currentId As String) As T

            Dim myFoundControl As T = CType(Nothing, T)
            Dim myControlCount As Integer = currentParentControl.Controls.Count

            If (myControlCount > 0) Then
                Dim myCount As Integer = 0

                Do While (myCount < myControlCount)
                    Dim myControl As System.Web.UI.Control = currentParentControl.Controls.Item(myCount)
                    If TypeOf myControl Is T Then
                        myFoundControl = TryCast(currentParentControl.Controls.Item(myCount), T)
                        If (String.Compare(currentId, myFoundControl.ID, True) = 0) Then
                            Return myFoundControl
                        End If
                        myFoundControl = CType(Nothing, T)
                    Else
                        myFoundControl = FindControlRecursive(Of T)(myControl, currentId)
                        If (Not myFoundControl Is Nothing) Then
                            Return myFoundControl
                        End If
                    End If
                    myCount += 1
                Loop
            End If

            Return myFoundControl
        End Function

        '   NAME         : FindControlRecursiveByType
        '   DATE CREATED : 01/19/11
        '   MOD HISTORY  : 
        ''' <summary>
        ''' Recursive FindControl method to search for controls by type.
        ''' </summary>
        ''' <param name="currentType">Type to search for.</param>
        ''' <param name="currentParentControl">Parent control to recurse through.</param>
        ''' <returns>List(Of Control)</returns>
        ''' 
        Public Shared Function FindControlRecursiveByType(ByVal currentType As Type, ByVal currentParentControl As System.Web.UI.Control) As List(Of System.Web.UI.Control)
            Dim myControlList As New List(Of System.Web.UI.Control)

            FindControlRecursiveByType(myControlList, currentType, currentParentControl)

            Return myControlList
        End Function

        ''' <summary>
        ''' Recursive FindControl method to search for controls by type. Returns a list of control objects.
        ''' </summary>
        ''' <param name="currentControlList">List of controls.</param>
        ''' <param name="currentType">Type to search for.</param>
        ''' <param name="currentParentControl">Parent control to recurse through.</param>
        ''' <returns>List(Of Control)</returns>
        ''' 
        Public Shared Function FindControlRecursiveByType _
            (ByRef currentControlList As List(Of System.Web.UI.Control), ByVal currentType As Type, ByVal currentParentControl As System.Web.UI.Control) As List(Of System.Web.UI.Control)

            For Each myControl As System.Web.UI.Control In currentParentControl.Controls
                'If the control type matches the search, add to the list.
                If myControl.GetType() = currentType Then
                    currentControlList.Add(myControl)
                End If

                'If the control is the parent of child controls, recurse through the child controls.
                If myControl.HasControls Then
                    currentControlList = FindControlRecursiveByType(currentControlList, currentType, myControl)
                End If
            Next

            Return currentControlList
        End Function

        '   NAME         : ToggleVisibilityByType 
        '   DATE CREATED : 01/19/11
        '   MOD HISTORY  : 
        ''' <summary>
        ''' Toggle the visibility of controls by type. Takes third parameter as the Visible setting.
        ''' </summary>
        ''' <param name="currentType">Type to search for.</param>
        ''' <param name="currentParentControl">Parent control to recurse through.</param>
        ''' <param name="currentIsVisible">Value to set each control's Visible property to.</param>
        ''' <remarks>Avoids uncovering controls that are hidden by default.</remarks>
        ''' 
        Public Shared Sub ToggleVisibilityByType(ByVal currentType As Type, ByVal currentParentControl As System.Web.UI.Control, ByVal currentIsVisible As Boolean)
            Dim myControlList As New List(Of System.Web.UI.Control)

            myControlList = FindControlRecursiveByType(currentType, currentParentControl)

            If myControlList.Count > 0 Then
                For Each myControl As System.Web.UI.Control In myControlList
                    myControl.Visible = currentIsVisible
                Next
            End If
        End Sub

#End Region

    End Class
#End Region

End Namespace
