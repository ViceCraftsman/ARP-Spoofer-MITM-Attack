# Architecture

ARP-Spoofer-MITM-Attack is a modular console lab tool for scanner. It separates concerns into distinct layers:

- **Core**: domain models, service interfaces, validation, and exceptions.
- **Infrastructure**: logging, configuration loading, and external endpoint communication.
- **Entry Point**: `Program.cs` wires dependencies and starts the application.

## Layers

```
Program
  |
  +-- LabTool
        |
        +-- DataProvider
        +-- Repository
        +-- Configuration
```

## Key Components

| Component | Responsibility |
|-----------|---------------|
| `ILabTool` | Orchestrates simulation and analysis logic. |
| `IDataProvider` | Fetches simulated scanner data. |
| `IRepository` | Persists snapshots and results in memory. |
| `IConfigurationLoader` | Loads settings from `appsettings.json` and environment variables. |
| `ILogger` | Writes structured log output to the console. |

## Data Flow

1. Application loads configuration.
2. User selects a target or parameter.
3. `DataProvider` produces a simulated result.
4. `LabTool` persists the result in the in-memory repository.
5. `MenuRenderer` displays the snapshot to the user.
