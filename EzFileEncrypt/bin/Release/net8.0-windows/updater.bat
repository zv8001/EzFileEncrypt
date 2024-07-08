ECHO OFF
CLS
ECHO DO NOT CLOSE THIS WINDOW EZ FILE ENCRYPT IS UPDATING!!
TIMEOUT 5 >NUL
TASKKILL /IM EzFileEncrypt.exe /T /F
del /F /Q EzFileEncrypt.exe
ren "EzFileEncrypt_Update.tmp" "EzFileEncrypt.exe"
START EzFileEncrypt.exe