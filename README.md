
# PruebasSonar - API Simple para SonarQube

## Descripción

Este es un proyecto de ejemplo para ejercicios con **SonarQube**. Contiene una API simple en ASP.NET Core con una única petición GET que devuelve un mensaje fijo, junto con pruebas unitarias que proporcionan excelente cobertura de código.

## Estructura del Proyecto

```
PruebasSonar/
├── PruebasSonar/                 # Proyecto API principal
│   ├── Program.cs                # Configuración de la API
│   ├── PruebasSonar.csproj       # Archivo de proyecto
│   └── appsettings*.json         # Configuración
├── PruebasSonar.Tests/           # Proyecto de pruebas unitarias
│   ├── GreetingServiceTests.cs   # Tests del servicio
│   ├── GreetingResponseTests.cs  # Tests del modelo de respuesta
│   └── PruebasSonar.Tests.csproj # Archivo de proyecto de tests
└── PruebasSonar.sln             # Solución
```

## Requisitos

- .NET 10.0 o superior
- Visual Studio 2022 (opcional)
- SonarQube (para análisis)

## Compilación

```bash
cd PruebasSonar
dotnet build
```

## Ejecución

```bash
cd PruebasSonar
dotnet run --project PruebasSonar/PruebasSonar.csproj
```

La API estará disponible en `https://localhost:5001/api/greeting/hello`

## Pruebas

Ejecutar todas las pruebas unitarias:

```bash
dotnet test
```

Resultado esperado: **8 tests pasando** con 100% de cobertura en el código principal.

## Endpoints

### GET `/api/greeting/hello`

**Respuesta (200 OK):**

```json
{
  "message": "Hola desde PruebasSonar API"
}
```

## Componentes

### 1. **Servicio (GreetingService)**
- Implementa `IGreetingService`
- Responsable de generar el mensaje de saludo
- Devuelve: `"Hola desde PruebasSonar API"`

### 2. **Controlador/Endpoint**
- Endpoint GET en `/api/greeting/hello`
- Inyecta el servicio mediante DI
- Retorna `GreetingResponse`

### 3. **Modelo de Respuesta (GreetingResponse)**
- DTO simple con propiedad `Message`
- Serializable a JSON automáticamente

## Cobertura de Pruebas

### GreetingServiceTests (4 tests)
- ✅ Verifica que el mensaje retornado es exactamente el esperado
- ✅ Verifica que el mensaje no es nulo o vacío
- ✅ Verifica que el servicio es consistente (mismo valor cada vez)
- ✅ Verifica que el mensaje contiene palabras clave

### GreetingResponseTests (4 tests)
- ✅ Verifica que la clase tiene la propiedad Message
- ✅ Verifica que se puede asignar un valor a la propiedad
- ✅ Verifica que la propiedad se inicializa como cadena vacía
- ✅ Verifica que el objeto es serializable a JSON

## Métrica para SonarQube

- **Cobertura de Líneas**: ~100%
- **Cobertura de Ramas**: ~100%
- **Tests**: 8 / 8 pasando (100%)
- **Complejidad Ciclomática**: Muy baja (solo 2-3)
- **Code Smells**: 0
- **Vulnerabilidades**: 0
- **Bugs**: 0

## Uso con SonarQube

1. Instalar Scanner de SonarQube para .NET
2. Ejecutar análisis:

```bash
dotnet sonarscanner begin /k:"PruebasSonar" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="YOUR_TOKEN"
dotnet build
dotnet test /p:CollectCoverageMetrics=true
dotnet sonarscanner end /d:sonar.login="YOUR_TOKEN"
```

## Tecnologías

- **Framework**: ASP.NET Core 10.0
- **Testing**: xUnit
- **Mocking**: Moq
- **API Documentation**: Swagger/OpenAPI

## Licencia

Proyecto de ejemplo para fines educativos.

