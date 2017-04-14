REM due to changes in the location of MSBuild.exe in VS2017 we will add the MSBuild location to the PATH env. variable
@cls
@MSBuild Scripts\_release.msbuild /fileLogger %*