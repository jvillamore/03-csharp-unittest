# Instalación Moq

dotnet add package Moq --version 4.20.70

# Instalación de Coverlet

dotnet add package coverlet.collector --version 6.0.2

dotnet add package coverlet.msbuild --version 6.0.2

dotnet tool install --global coverlet.console --version 6.0.2

# Ejecutar pruebas

dotnet test

# Ejecutar pruebas con convertura

dotnet test /p:CollectCoverage=true

# Pruebas con convertura excluyendo código con la etiqueta "ExcludeFromCodeCoverage"

dotnet test /p:CollectCoverage=true /p:ExcludeByAttribute="ExcludeFromCodeCoverage"

# Reporte de covertura en XML

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura

# Instalar Report generator

dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.3.8

# Ejecutar Reporte de covertura en HTML

reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:coverage-report" -reporttypes:html;
