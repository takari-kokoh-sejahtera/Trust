Public Class GeneralControl
    Public Shared Function ToBoolean(value As String) As Boolean
        Select Case (value.ToLower)
            Case "true"
                Return True
            Case "t"
                Return True
            Case "1"
                Return True
            Case "0"
                Return False
            Case "false"
                Return False
            Case "f"
                Return False
            Case Else
                Return Nothing
        End Select

    End Function


    Public Shared Function Selectval() As String
        Return "--Please Select--"
    End Function
    Public Shared Function RomawiMonth(no As Integer) As String
        Select Case (no)
            Case 1
                Return "I"
            Case 2
                Return "II"
            Case 3
                Return "III"
            Case 4
                Return "IV"
            Case 5
                Return "V"
            Case 6
                Return "VI"
            Case 7
                Return "VII"
            Case 8
                Return "VIII"
            Case 9
                Return "IX"
            Case 10
                Return "X"
            Case 11
                Return "XI"
            Case 12
                Return "XII"
        End Select
        Return ""
    End Function

End Class
