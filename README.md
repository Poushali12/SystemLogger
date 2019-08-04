# SystemLogger

Whenever the system is being locked-unlocked, the duration will be recorded in a local file.

## How to Use ##


Dowload the source code. Run command prompt as Administartor. Go to 'v4.0.30319' folder. In most of the case the full path is C:\Windows\Microsoft.NET\Framework\v4.0.30319. In command promt execute the following command:


### Install ###

InstallUtil.exe "path to serivce.exe" + <<service name>> + ".exe"

In my local system the path is

"C:\Users\Poushali\Desktop\practice\SystemLogger\SystemLoggerService\bin\Release"

Hence my command will look like

InstallUtil.exe C:\Users\Poushali\Desktop\practice\SystemLogger\SystemLoggerService\bin\Release\SystemLoggerService.exe


### Start/Stop Service ###

Open the Run (Ctrl + R)

Type sevice.msc

Find your Service

Right click on it to Start or Stop the Service.

markdown
### Uninstall ###


InstallUtil.exe-u "path to serivce.exe" + <<service name>> + ".exe"

In my local system the path is

"C:\Users\Poushali\Desktop\practice\SystemLogger\SystemLoggerService\bin\Release"

Hence my command will look like

InstallUtil.exe-u C:\Users\Poushali\Desktop\practice\SystemLogger\SystemLoggerService\bin\Release\SystemLoggerService.exe


### Output ###


The default Output path is "C:\Windows". A text file will be created in this path, name of the file is  "SystemTimeLogger.txt"

### Change Output File PAth ###

If you want to change the path of the output file open the solution. Go to Service.cs file. Right click -> View Code.

Go to ~OnSessionChange~  method. Change the file path. After this Rebuild and re install.


### License ###


his is under free license.

