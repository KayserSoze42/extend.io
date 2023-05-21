Dim result
Dim reason
Dim fizz
Dim buzz
Dim excelApp
Dim excelWorkbook
Dim eSheet

Set excelApp = CreateObject("Excel.Application")
excelApp.visible=True
Set excelWorkbook = excelApp.Workbooks.Add()
Set eSheet = excelWorkbook.ActiveSheet

range = InputBox("Enter the range for the FizzBuzzer", "FizzBuzzer")
fizz = InputBox("Enter the fizz condition: i Mod x, x=", "FizzBuzzer")
buzz = InputBox("Enter the buzz condition: i Mod y, y=", "FizzBuzzer")

fizz = CInt(fizz)
buzz = CInt(buzz)

eSheet.Cells(1,1).Value = "Number"
eSheet.Cells(1,2).Value = "Result"
eSheet.Cells(1,3).Value = "Reason"

For i = 1 To CInt(range)
  result = ""
  reason = ""

  If i Mod fizz = 0 Then
    result = result & "Fizz"
  End If

  If i Mod buzz = 0 Then
    result = result & "Buzz"
  End If

  Select case result
    case "Fizz"
      reason = "Divisible by " & fizz
    case "Buzz"
      reason = "Divisible by " & buzz
    case "FizzBuzz"
      reason = "Divisible by both " & fizz & " and " & buzz
    case else
      reason = "N/a"

  End Select

  eSheet.Cells(i+1,1).Value = i
  eSheet.Cells(i+1,2).Value = result
  eSheet.Cells(i+1,3).Value = reason
  
Next
