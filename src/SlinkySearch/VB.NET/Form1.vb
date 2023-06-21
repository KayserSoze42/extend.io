Public Class Form1

    Dim objReader As System.IO.StreamReader
    Dim objWriter As System.IO.StreamWriter

    Dim links As New List(Of String())()

    Private Function ReLoad(sender As Object, e As EventArgs)

        links.Clear()
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)

        If My.Settings.filePath = "" Then

            Me.Width = 474
            Me.Height = 185

            For i As Integer = Me.Controls.Count - 1 To 0 Step -1
                If TypeOf Me.Controls(i) Is TextBox Then
                    Dim textBoxControl As TextBox = TryCast(Me.Controls(i), TextBox)
                    If textBoxControl IsNot Nothing Then
                        textBoxControl.Enabled = False
                    End If
                    Me.Controls.RemoveAt(i)
                ElseIf TypeOf Me.Controls(i) Is Label And Me.Controls(i).Name <> infoLabel.Name Then
                    Me.Controls.RemoveAt(i)
                End If
            Next

            okSearchButton.Location = New Point(337, 101)
            OpenButton.Location = New Point(16, 101)

        End If

    End Function

    Private Function AddElement()

        If My.Settings.filePath = "" Then
            Return 0
        End If

        objWriter = New System.IO.StreamWriter(My.Settings.filePath, True)

        Dim newName, newUrlStart, newUrlEnd

        newName = InputBox("Enter the name of the new search", "New element")

        If newName <> "" Then

            newUrlStart = InputBox("Enter the start of the Url search pattern", "New element")

            If newUrlStart <> "" Then

                newUrlEnd = InputBox("Enter the end of the Url search pattern " & vbCrLf & " (optional, if N/A just leave empty)", "New element")

                If newUrlEnd <> "" Then
                    objWriter.WriteLine(newName + " <<>> " + newUrlStart + " <<>> " + newUrlEnd)
                Else
                    objWriter.WriteLine(newName + " <<>> " + newUrlStart)
                End If



            End If

        End If

        objWriter.Close()

        Return 1

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IO.File.Exists(My.Settings.filePath) And My.Settings.filePath <> "" Then

            My.Settings.filePath = ""
            My.Settings.Save()

            ReLoad(e, e)

        End If



        Dim TextLine As String

        If My.Settings.filePath = "" Then

        Else

            OpenButton.Visible = False
            OpenButton.Enabled = False

            NewButton.Visible = False
            NewButton.Enabled = False

            infoLabel.Text = ""
            okSearchButton.Text = "Search"

            Dim yPos As Integer
            yPos = 0

            Dim textFile As List(Of String) = System.IO.File.ReadAllLines(My.Settings.filePath).ToList

            Dim lineCount As Integer = 0

            For Each line As String In textFile

                lineCount += 1

                If line = "" Then
                    textFile.RemoveAt(lineCount)
                    lineCount -= 1
                End If

            Next

            System.IO.File.WriteAllLines(My.Settings.filePath, textFile)

            If textFile.Count = 0 Then

                My.Settings.filePath = ""
                My.Settings.Save()

                ReLoad(e, e)

                Return

            End If

            objReader = New System.IO.StreamReader(My.Settings.filePath)

            Me.Width = 250

            Dim arraySplitString As String()

            Dim rowNo As Integer

            Dim newArray() As String = {}

            Do While objReader.Peek() <> -1

                yPos += 50

                TextLine = objReader.ReadLine()

                If TextLine = "" Then
                    Continue Do
                End If

                arraySplitString = Split(TextLine, " <<>> ")

                If arraySplitString.Length < 2 Then

                    Dim message As String
                    Dim infoDialog

                    rowNo = yPos / 50
                    message = "Task failed successfully! Error on row " + rowNo.ToString()

                    infoDialog = MsgBox(message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Failed to read")

                    If infoDialog = vbOK Then

                        My.Settings.filePath = ""
                        My.Settings.Save()

                        ReLoad(e, e)

                    End If

                End If

                If arraySplitString.Length = 3 Then
                    newArray = {arraySplitString(1).Replace(" ", ""), arraySplitString(2).Replace(" ", "")}
                ElseIf arraySplitString.Length = 2 Then
                    newArray = {arraySplitString(1), New String("")}
                End If

                links.Add(newArray)

                okSearchButton.Location = New Point(50, yPos + 50)

                Me.Height += 40

                Dim newTextbox As New TextBox
                With newTextbox
                    .Size = New Size(190, 20)
                    .Location = New Point(20, yPos)
                End With
                Me.Controls.Add(newTextbox)

                Dim newLabel As New Label
                With newLabel
                    .Size = New Size(390, 30)
                    .Location = New Point(30, yPos - 20)
                    .Text = arraySplitString(0)
                    .Font = New Font("Comic Sans MS", 9, FontStyle.Bold)
                End With
                Me.Controls.Add(newLabel)

                Me.MainMenuStrip = MenuStrip1

                Dim newElement As New ToolStripMenuItem()

                rowNo = (yPos / 50) - 1

                With newElement
                    .Name = "item" + rowNo.ToString()
                    .Text = arraySplitString(0)
                    .Font = New Font("Segoe UI Semibold", 9, FontStyle.Italic)
                End With

                RemoveElements.DropDownItems.Add(newElement)
                AddHandler newElement.Click, AddressOf RemoveAllElementsToolStripMenuItem_Click

                newArray = {}
                arraySplitString = {}

            Loop

            objReader.Close()

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles okSearchButton.Click

        If My.Settings.filePath = "" Then

            Me.Close()

        Else

            Dim count As Integer = 0

            For Each c As TextBox In Me.Controls.OfType(Of TextBox)

                If c.Text <> "" And c.Enabled = True Then

                    Dim currentLink As String = links(count)(0) + c.Text.Replace(" ", "") + links(count)(1)

                    Try
                        Process.Start(My.Settings.browserPath, currentLink)
                    Catch ex As Exception
                        Dim infoBox
                        infoBox = MsgBox("Task failed successfully! Error with link / browser path", vbOKOnly, "Failed")

                        My.Settings.browserPath = "C:\Program Files\Mozilla Firefox\firefox.exe"
                        My.Settings.Save()
                    End Try



                End If

                count += 1

            Next

        End If

    End Sub

    Private Sub OpenButton_Click_1(sender As Object, e As EventArgs) Handles OpenButton.Click

        OpenFileDialog.ShowDialog()

        My.Settings.filePath = OpenFileDialog.FileName
        My.Settings.Save()

        ReLoad(e, e)

    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click

        Dim inputDialog
        inputDialog = InputBox("Enter Browser Path For Opening Links", "Path Change", My.Settings.browserPath)

        If inputDialog <> "" Then

            My.Settings.browserPath = inputDialog

        End If

    End Sub

    Private Sub ExitToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem2.Click
        Me.Close()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        OpenButton_Click_1(e, e)

    End Sub

    Private Sub ResetFieldsCTRLRDelToolStripMenuItem_Click(sender As Object, e As EventArgs)
        For i As Integer = Me.Controls.Count - 1 To 0 Step -1
            If TypeOf Me.Controls(i) Is TextBox Then
                Me.Controls(i).Text = ""
            End If
        Next
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.Control AndAlso e.KeyCode = Keys.R) Or e.KeyCode = Keys.Delete Then

            For i As Integer = Me.Controls.Count - 1 To 0 Step -1
                If TypeOf Me.Controls(i) Is TextBox Then
                    Me.Controls(i).Text = ""
                End If
            Next

        ElseIf e.KeyCode = Keys.Enter Then

            okSearchButton.PerformClick()

        End If
    End Sub

    Private Sub OpenNewFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenNewFileToolStripMenuItem.Click

        NewButton.PerformClick()

    End Sub

    Private Sub NewButton_Click(sender As Object, e As EventArgs) Handles NewButton.Click

        SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            My.Settings.filePath = SaveFileDialog1.FileName
            My.Settings.Save()

            Dim shouldAdd As Boolean
            shouldAdd = True

            Dim infoBox, addMoreBox
            infoBox = MsgBox("Enter the first element for the new file", vbOKOnly, "Init")

            While shouldAdd

                AddElement()

                addMoreBox = MsgBox("Do you want to add another element now?", vbYesNo, "Init")

                If addMoreBox = vbNo Then
                    shouldAdd = False
                End If

            End While

            ReLoad(e, e)
        End If

    End Sub

    Private Sub AddNewElementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewElementToolStripMenuItem.Click

        Dim shouldAdd As Boolean
        shouldAdd = True

        Dim addMoreBox, returnValue

        While shouldAdd

            returnValue = AddElement()

            If returnValue = 0 Then
                shouldAdd = False
                Exit While
            End If

            addMoreBox = MsgBox("Do you want to add another element now?", vbYesNo, "Init")

            If addMoreBox = vbNo Then
                shouldAdd = False
            End If

        End While

        ReLoad(e, e)

    End Sub

    Private Sub RemoveElements_Click(sender As Object, e As EventArgs) Handles RemoveElements.Click

    End Sub

    Private Sub RemoveAllElementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveAllElementsToolStripMenuItem.Click

        Dim clickedItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

        If clickedItem IsNot Nothing Then

            If clickedItem.Name = "RemoveAllElementsToolStripMenuItem" Then

                Dim confirmationBox, infoBox

                confirmationBox = MsgBox("Remove all elements?", vbYesNo, "Confirm")

                If confirmationBox = vbYes Then

                    infoBox = MsgBox("Enter new first element", vbOKOnly, "reInit")

                    System.IO.File.WriteAllText(My.Settings.filePath, "")

                    Dim shouldAdd As Boolean
                    shouldAdd = True

                    Dim addMoreBox

                    While shouldAdd

                        AddElement()

                        addMoreBox = MsgBox("Do you want to add another element now?", vbYesNo, "Init")

                        If addMoreBox = vbNo Then
                            shouldAdd = False
                        End If

                    End While

                    ReLoad(e, e)

                End If

            Else

                Dim fileLines As List(Of String) = System.IO.File.ReadAllLines(My.Settings.filePath).ToList

                fileLines.RemoveAt(Convert.ToInt32(Convert.ToDecimal(Mid(clickedItem.Name, 5))))

                System.IO.File.WriteAllLines(My.Settings.filePath, fileLines)

                ReLoad(e, e)

            End If

        End If

    End Sub
End Class
