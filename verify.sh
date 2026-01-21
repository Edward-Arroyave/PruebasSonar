#!/bin/bash
# Script de verificación del proyecto PruebasSonar

echo "======================================"
echo "  Verificación del Proyecto PruebasSonar"
echo "======================================"
echo ""

echo "1. Compilando proyecto..."
dotnet build --no-restore
if [ $? -ne 0 ]; then
    echo "❌ Error en compilación"
    exit 1
fi
echo "✅ Compilación exitosa"
echo ""

echo "2. Ejecutando pruebas unitarias..."
dotnet test PruebasSonar.Tests/PruebasSonar.Tests.csproj --no-build --logger "console;verbosity=minimal"
if [ $? -ne 0 ]; then
    echo "❌ Fallos en pruebas"
    exit 1
fi
echo "✅ Todas las pruebas pasaron"
echo ""

echo "3. Verificando estructura de archivos..."
files_to_check=(
    "PruebasSonar/Program.cs"
    "PruebasSonar/PruebasSonar.csproj"
    "PruebasSonar/appsettings.json"
    "PruebasSonar/appsettings.Development.json"
    "PruebasSonar.Tests/GreetingServiceTests.cs"
    "PruebasSonar.Tests/GreetingResponseTests.cs"
    "PruebasSonar.Tests/PruebasSonar.Tests.csproj"
    "PruebasSonar.sln"
    "README.md"
    "QUICKSTART.md"
    "sonar-project.properties"
)

missing_files=0
for file in "${files_to_check[@]}"; do
    if [ ! -f "$file" ]; then
        echo "❌ Archivo faltante: $file"
        missing_files=$((missing_files + 1))
    else
        echo "✅ $file"
    fi
done

if [ $missing_files -gt 0 ]; then
    echo ""
    echo "❌ Hay $missing_files archivos faltantes"
    exit 1
fi
echo ""
echo "✅ Todos los archivos presentes"
echo ""

echo "======================================"
echo "  ✅ VERIFICACIÓN COMPLETADA EXITOSAMENTE"
echo "======================================"
echo ""
echo "El proyecto está listo para:"
echo "  1. Ejecutar: dotnet run --project PruebasSonar/PruebasSonar.csproj"
echo "  2. Probar: https://localhost:5001/api/greeting/hello"
echo "  3. Analizar con SonarQube"
