# Guía Rápida de Inicio

## 1. Compilar la solución

```bash
cd PruebasSonar
dotnet build
```

## 2. Ejecutar las pruebas

```bash
# Todos los tests
dotnet test

# Solo el proyecto de tests
dotnet test PruebasSonar.Tests/PruebasSonar.Tests.csproj
```

**Resultado esperado**: ✅ 8/8 tests pasando

## 3. Ejecutar la API

```bash
# Opción 1: Ejecutar directamente
dotnet run --project PruebasSonar/PruebasSonar.csproj

# Opción 2: Ejecutar el ejecutable
cd PruebasSonar/bin/Debug/net10.0
./PruebasSonar.exe

# Opción 3: Desde la carpeta raíz
dotnet run
```

La API estará disponible en:
- `https://localhost:5001/api/greeting/hello` (HTTPS)
- `http://localhost:5000/api/greeting/hello` (HTTP)

## 4. Probar el endpoint

### Usando curl:

```bash
# Request HTTP
curl http://localhost:5000/api/greeting/hello

# Request HTTPS
curl https://localhost:5001/api/greeting/hello -k

# Con headers adicionales
curl -H "Content-Type: application/json" http://localhost:5000/api/greeting/hello
```

### Respuesta esperada:

```json
{
  "message": "Hola desde PruebasSonar API"
}
```

### Usando PowerShell:

```powershell
# Ignorar certificados autofirmados
[System.Net.ServicePointManager]::ServerCertificateValidationCallback = { $true }
Invoke-WebRequest -Uri "https://localhost:5001/api/greeting/hello"
Invoke-RestMethod -Uri "https://localhost:5001/api/greeting/hello"
```

### Usando navegador:

1. Abrir navegador
2. Ir a: `https://localhost:5001/api/greeting/hello`
3. Aceptar el certificado autofirmado

## 5. Swagger/OpenAPI

Mientras la API está ejecutándose, ver documentación interactiva:

- `https://localhost:5001/openapi/v1.json`
- `https://localhost:5001/swagger/index.html` (requiere Swashbuckle configurado)

## 6. Análisis con SonarQube

```bash
# Instalar scanner (primera vez)
dotnet tool install --global dotnet-sonarscanner

# Ejecutar análisis
dotnet sonarscanner begin /k:"PruebasSonar" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="YOUR_SONAR_TOKEN"
dotnet build
dotnet test /p:CollectCoverageMetrics=true
dotnet sonarscanner end /d:sonar.login="YOUR_SONAR_TOKEN"
```

## 7. Estructura del Proyecto

```
├── PruebasSonar/                    # Proyecto API principal
│   ├── Program.cs                   # Punto de entrada y configuración
│   ├── PruebasSonar.csproj          # Archivo de proyecto
│   ├── appsettings.json             # Configuración de producción
│   └── appsettings.Development.json # Configuración de desarrollo
│
├── PruebasSonar.Tests/              # Proyecto de pruebas unitarias
│   ├── GreetingServiceTests.cs      # Tests para GreetingService
│   ├── GreetingResponseTests.cs     # Tests para GreetingResponse
│   └── PruebasSonar.Tests.csproj    # Archivo de proyecto de tests
│
├── PruebasSonar.sln                 # Archivo de solución
├── README.md                        # Documentación completa
├── QUICKSTART.md                    # Este archivo
├── sonar-project.properties         # Configuración para SonarQube
└── .gitignore                       # Archivos a ignorar en Git
```

## 8. Solucionar problemas

### Puerto en uso:

Si el puerto 5000/5001 está ocupado, especificar uno diferente:

```bash
dotnet run --project PruebasSonar/PruebasSonar.csproj -- --urls="http://localhost:8080"
```

### Error de certificado:

En Windows, aceptar el certificado autofirmado:

```bash
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

### Limpiar y reconstruir:

```bash
# Limpiar artifacts
dotnet clean

# Reconstruir desde cero
dotnet build

# Reinstalar dependencias
dotnet restore
```

## 9. Características del Proyecto

✅ **API REST** con un endpoint GET simple
✅ **Inyección de Dependencias** (IGreetingService)
✅ **Tests Unitarios** con xUnit (8 tests)
✅ **Cobertura de código** ~100%
✅ **Documentación OpenAPI** integrada
✅ **Configuración por ambiente** (Development/Production)
✅ **Preparado para SonarQube**
