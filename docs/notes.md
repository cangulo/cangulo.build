# Notes

1. Check the commands in the ps1 files


dotnet build .\cangulo.build\cangulo.build.csproj /nodeReuse:false /p:UseSharedCompilation=false -nologo -clp:NoSummary --verbosity quiet

dotnet run --project .\cangulo.build\cangulo.build.csproj --no-build



dotnet publish  -r win-x64 .\cangulo.build\cangulo.build.csproj -c Release /p:PublishSingleFile=true --self-contained -o ./artifacts

# Run in other solutions

dotnet run --project .\nuke-runner\cangulo.build\cangulo.build.csproj --no-build --root . --target GenericRequestHandler --requestJSON '{ \"requestModel\": \"ExecuteAllUnitTestsInTheRepository\",\"originator\": \"originator\"}'

# Links
https://github.com/cangulo/cangulo.build
https://dotnetcoretutorials.com/2019/06/20/publishing-a-single-exe-file-in-net-core-3-0/
https://docs.microsoft.com/es-es/dotnet/core/tools/dotnet-publish
https://docs.microsoft.com/es-es/dotnet/core/deploying/deploy-with-cli
https://docs.microsoft.com/es-es/dotnet/core/rid-catalog
https://docs.microsoft.com/es-es/dotnet/core/tools/dotnet-run
https://github.com/cangulo/cangulo.common