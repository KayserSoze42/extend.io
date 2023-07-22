Function isPrimo(agen)

	If agen / 2 = 1 Then
		isPrimo = True
		Exit Function
	End If
	
	If agen Mod 2 = 0 Then
		isPrimo = False
		Exit Function
	End If
	
	For i = 3 To agen / 2

		If agen Mod i = 0 Then

			isPrimo = False
			Exit Function
		End If
	Next
	
	isPrimo = True

End Function

Dim startRange: startRange = InputBox("Enter the lower limit for the range:", "Primo")
startRange = CInt(startRange)

Dim endRange: endRange = InputBox("Enter the higher limit for the range:", "Primo")
endRange = CInt(endRange)

Dim excelApp: excelApp = CreateObject("Excel.Application")
excelApp.visible=True
Dim excelWorkbook: excelWorkbook = excelApp.Workbooks.Add()
Dim eSheet: eSheet = excelWorkbook.ActiveSheet

eSheet.Cells(1,1).Value = "Number"
eSheet.Cells(1,2).Value = "isPrimo"

For i = startRange To endRange
	eSheet.Cells(i+1, 1).Value = i
	eSheet.Cells(i+1, 2).Value = isPrimo(i)

Next

Set excelApp = Nothing
Set excelWorkbook = Nothing
Set eSheet = Nothing
