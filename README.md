# ARP-Spoofer-MITM-Attack

<p align="center">
  <img src="https://img.shields.io/badge/C%23-10.0-239120?style=for-the-badge&logo=csharp" alt="C# 10.0">
  <img src="https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet" alt=".NET 10">
  <img src="https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS-0078D4?style=for-the-badge" alt="Platform">
</p>

<p align="center">
  <img src="https://img.shields.io/badge/build-passing-brightgreen?style=flat-square" alt="Build">
  <img src="https://img.shields.io/badge/tests-xUnit-6C4AB6?style=flat-square" alt="Tests">
  <img src="https://img.shields.io/badge/CI-GitHub%20Actions-2088FF?style=flat-square&logo=githubactions" alt="CI">
  <img src="https://img.shields.io/badge/license-MIT-green?style=flat-square" alt="License">
</p>

<h2 align="center">A modular console ARP table monitor and alert tool</h2>

<p align="center">
  <strong>ARP-Spoofer-MITM-Attack</strong> is a research-oriented, educational console module designed for developers, analysts, and security enthusiasts who need a structured, extensible foundation for exploring scanner concepts in authorized lab environments, CTF exercises, and defensive testing scenarios.
</p>

---

> This project is intended for authorized testing, CTF exercises, and educational labs only. It does not perform real attacks against systems without explicit permission.

## Why ARP-Spoofer-MITM-Attack?

Most tools in the scanner space are either monolithic, closed-source, or unstructured scripts. ARP-Spoofer-MITM-Attack bridges the gap by offering:

- A **clean, layered architecture** inspired by enterprise .NET applications.
- **Dependency injection**, structured logging, and configuration-driven behavior.
- **Comprehensive separation of concerns**: domain logic lives in `Core`, while logging, configuration, and UI live in `Infrastructure`.
- **A built-in test suite** covering providers, simulation engines, and orchestration.
- **CI/CD pipeline** ready to run on every push and pull request.

## Features

| Feature | Description |
|---------|-------------|
| **Simulation engine** | Run deterministic or randomized scanner simulations. |
| **Data providers** | Fetch simulated data from local or lab endpoints. |
| **In-memory repository** | Thread-safe storage for scan results and snapshots. |
| **Configuration-driven** | JSON and environment-variable configuration support. |
| **Structured logging** | Color-coded console logs with Microsoft.Extensions.Logging. |
| **xUnit test suite** | Unit tests covering services and providers. |
| **GitHub Actions CI** | Automated build and test pipeline on Windows runners. |

## Architecture

```
ARP-Spoofer-MITM-Attack
├── src/ARP-Spoofer-MITM-Attack
│   ├── Core
│   │   ├── Configuration       # LabOptions
│   │   ├── Models              # LabResult, LabSnapshot
│   │   ├── Services            # ILabTool, IDataProvider, IRepository
│   │   ├── Utils               # ValidationUtils, ArgumentParser
│   │   └── Exceptions          # LabToolException hierarchy
│   └── Infrastructure
│       ├── Configuration       # ConfigurationLoader
│       ├── ConsoleUi           # MenuRenderer
│       └── Logging             # ConsoleLogger
├── tests/ARP-Spoofer-MITM-Attack.Tests          # xUnit tests
├── config                      # appsettings.json
├── docs                        # architecture, security, api, development
└── scripts                     # build.ps1, run.ps1
```

## Quick Start

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later

### Installation

```bash
# Clone the repository
git clone https://github.com/yourusername/ARP-Spoofer-MITM-Attack.git
cd ARP-Spoofer-MITM-Attack

# Restore and build
dotnet restore ARP-Spoofer-MITM-Attack.sln
dotnet build ARP-Spoofer-MITM-Attack.sln

# Run tests
dotnet test ARP-Spoofer-MITM-Attack.sln
```

### Interactive Usage

```bash
# Run in interactive mode
dotnet run --project src/ARP-Spoofer-MITM-Attack/ARP-Spoofer-MITM-Attack.csproj

# Or use the provided helper
scripts/run.ps1
```

### Example Session

```
  ╔══════════════════════════════════════════════════════════╗
  ║              ARP-Spoofer-MITM-Attack - Lab Tool Module                    ║
  ║        Educational simulation for scanner research    ║
  ╚══════════════════════════════════════════════════════════╝

Select an option:
  1. Run simulation
  2. Show last snapshot
  3. Add input parameter
  4. Export results
  5. Exit
> 1
[2026-08-24 22:00:00] [Information] Simulation completed for scanner target
```

## Configuration

Edit `config/appsettings.json`:

```json
{
  "Lab": {
    "RefreshIntervalMs": 30000,
    "DataEndpoint": "https://lab.example.com/scanner",
    "LogLevel": "Information"
  }
}
```

Environment variables prefixed with `LAB_` are also supported.

## Roadmap

- [ ] Persistent storage adapter (SQLite)
- [ ] Historical data export to CSV/JSON
- [ ] Webhook notification provider
- [ ] Multi-target support
- [ ] Plugin system for custom providers

## Documentation

- [Architecture](docs/architecture.md)
- [Security & Threat Model](docs/security.md)
- [Development Guide](docs/development.md)
- [API Reference](docs/api.md)

## Contributing

We welcome contributions. Please read [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines, code style, and the pull-request process.

## Support

If you find this project useful, consider giving it a star on GitHub. For questions and discussions, open an issue or start a discussion thread.

## License

ARP-Spoofer-MITM-Attack is released under the MIT License. See [LICENSE](LICENSE) for details.

---

<p align="center">
  Built with .NET 10 for researchers, developers, and security enthusiasts.
</p>


## Performance & Extensibility

ARP-Spoofer-MITM-Attack is built for clarity and extension:

- **No real network calls** by default — all simulations run locally.
- **Provider pattern** makes swapping in real adapters straightforward.
- **JSON persistence** layer for caching simulated results.
- **Metrics publisher** ready for console, Prometheus, or cloud sinks.
- **Background service** template for periodic polling tasks.
- **Domain events** and **pipeline behaviors** for cross-cutting concerns.
- **xUnit test suite** with core and additional integration-style tests.

## Sample Data

A sample dataset is included in `data/samples.json` to demonstrate the expected input/output shape for the domain workflows.

## FAQ

See [docs/faq.md](docs/faq.md) for common questions.

## Usage

See [docs/usage.md](docs/usage.md) for detailed usage instructions.
