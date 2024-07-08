ECHO OFF
CLS
ECHO DO NOT CLOSE THIS WINDOW EZ FILE ENCRYPT IS UPDATING!!
TIMEOUT 5 >NUL
TASKKILL /IM "EzFileEncrypt.exe" /T /F
del /F /Q "EzFileEncrypt.exe"
ren "EzFileEncrypt_Update.tmp" "EzFileEncrypt.exe"
powershell -Command & "C:\Users\denve\OneDrive\Documents\GitHub\EzFileEncrypt\EzFileEncrypt\bin\Release\net8.0-windows\publish\win-x64\EzFileEncrypt.exe"