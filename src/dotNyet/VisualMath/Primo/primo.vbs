Dim excelWorkbook
Dim excelApp
Dim eSheet
Dim result

Function isPrimo(ByVal agen)

	If agen / 2 = 1 Then
		isPrimo = True
		Exit Function
	End If

	If agen Mod 2 = 0 Then
		isPrimo = False
		Exit Function
	End If

	halfagen = CInt(agen / 2)

	For i = 3 to halfagen
		If agen Mod i = 0 Then
			isPrimo = False
			Exit Function
		End If 
	Next

	isPrimo = True
	Exit Function

End Function

startRange = InputBox("Enter the lower limit for the range:", "Primo")
startRange = CInt(startRange)

endRange = InputBox("Enter the higher limit for the range:", "Primo")
endRange = CInt(endRange)

Set excelApp = CreateObject("Excel.Application")
excelApp.visible=True
Set excelWorkbook = excelApp.Workbooks.Add()
Set eSheet = excelWorkbook.ActiveSheet

eSheet.Cells(1,1).Value = "Number"
eSheet.Cells(1,2).Value = "isPrimo"

For i = startRange To endRange

	result = isPrimo(i)
	eSheet.Cells(i+1, 1).Value = i
	eSheet.Cells(i+1, 2).Value = result

Next

Set excelApp = Nothing
Set excelWorkbook = Nothing
Set eSheet = Nothing
