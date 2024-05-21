# SauniausiaKomandaBE

# Kaip pasileisti projektą lokaliai?

## 1. Nusiklonuoti repozitoriją

## 2. Parsisiųsti SQL serverį ir Microsoft SQL Server Management Studio. (Optional)

## 3. Užsidėti connection stringą.

### 1. appsettings.Development.json, jei norime duombazės lokaliai.

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=SK;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
  }
}
```

### 2. appsettings.Development.json, jei norime azure pahostintos duombazės.

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "<Paklausti Tedo arba Pauliaus, koks connection string>"
  }
}
```

## 4. Paleisti komandą `dotnet ef database update` iš vietos, kur yra Program.cs ir SaunausiaKomanda.API.csproj

## 5. Paleisti komandą `dotnet run` iš vietos, kur yra Program.cs ir SaunausiaKomanda.API.csproj

## 6. Turėtų būti message konsolėje : `Now listening on: http://localhost:5154`, tai naršyklėj įvest `http://localhost:5154/swagger/index.html`
