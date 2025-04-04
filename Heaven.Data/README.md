
# Configure web.config
# Change package info from proyect properties in VS solution explorer or from nuspec file
# Pack proyect from VS solution explorer or from CLI
# Push package to nuget server from CLI

# with required-apikey = true
> dotnet nuget push C:\Dev\src\Heaven.Data\Heaven.Data\bin\Debug\Heaven.Data.1.0.0.nupkg -k codigosabroso -s http://190.104.243.20:8099/nuget
> dotnet nuget push Heaven.Data.1.0.0.nupkg -k codigosabroso -s http://190.104.243.20:8099/nuget

# with required-apikey = false
> dotnet nuget push C:\Dev\src\Heaven.Data\Heaven.Data\bin\Debug\Heaven.Data.1.0.0.nupkg -s http://190.104.243.20:8099/nuget
> dotnet nuget push Heaven.Data.1.0.0.nupkg -s http://190.104.243.20:8099/nuget