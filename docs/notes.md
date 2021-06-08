# Notes

1. Check the commands in the ps1 files


dotnet build .\cangulo.build\cangulo.build.csproj /nodeReuse:false /p:UseSharedCompilation=false -nologo -clp:NoSummary --verbosity quiet

dotnet run --project .\cangulo.build\cangulo.build.csproj --no-build



dotnet publish  -r win-x64 .\cangulo.build\cangulo.build.csproj -c Release /p:PublishSingleFile=true --self-contained -o ./artifacts