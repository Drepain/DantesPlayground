dotnet publish -c Release -r linux-x64 /p:PublishReadyToRun=false /p:TieredCompilation=false --self-contained
cd bin/Release/net6.0/linux-x64/publish
./DantesPlayground
