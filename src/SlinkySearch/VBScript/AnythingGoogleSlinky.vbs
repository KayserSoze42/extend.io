Dim urlStart
Dim urlEnd
Dim fullUrl
Dim objShell
Dim searchItem
Dim searchName
urlStart = "https://www.google.com/search?q="
urlEnd = ""
searchItem = "Anything"
searchName = "Google"
search = InputBox("Search for " & searchItem & " on " & searchName, "Slinky Search")
fullUrl = urlStart & search & urlEnd
Set objShell = CreateObject("Shell.Application")
objShell.ShellExecute "firefox.exe", fullUrl, "", "", 1
Set objShell = Nothing


