# Usage Guide

## Running ARP-Spoofer-MITM-Attack

```bash
dotnet run --project src/ARP-Spoofer-MITM-Attack/ARP-Spoofer-MITM-Attack.csproj
```

## CLI Arguments

| Argument | Description |
|----------|-------------|
| `--config` | Path to a custom appsettings file. |
| `--verbose` | Enable verbose logging. |

## Sample Data

The `data/samples.json` file contains realistic-looking simulated data for local testing.

## Extending

Add new providers by implementing the domain interfaces in `Core/Services` and registering them in `Program.cs`.
