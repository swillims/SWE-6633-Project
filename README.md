# Project Build & Publishing Guide

This document provides step-by-step instructions for building, running, and publishing this .NET 8 project across **Windows**, **Linux**, and **macOS** platforms.

---

## 📦 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) must be installed on your machine.
- Ensure the project is set up and ready for publication.

### Windows
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or Build Tools with MSBuild).
- No additional dependencies required for Avalonia.

### Linux
Install dependencies:
```sh
sudo apt update
sudo apt install -y libgtk-3-dev libwebkit2gtk-4.0-dev
```

### macOS
Install Xcode CLI tools and dependencies:
```sh
xcode-select --install
brew install gtk+3 webkit2gtk
```

---

## 📖 Documentation Reference

Microsoft official deployment documentation:  
👉 https://learn.microsoft.com/en-us/dotnet/core/deploying/

---

## 🚀 Build & Run (Development)

### Build (Debug)
```sh
dotnet build
```

### Build (Release)
```sh
dotnet build -c Release
```

### Run
```sh
dotnet run
```

Run specifying project:
```sh
dotnet run --project src/YourProject
```

---

## 📤 Publishing

Publishing creates standalone binaries you can distribute without requiring the .NET runtime (when `--self-contained true` is used).

### Linux (x64)
```sh
dotnet publish -c Release -f net8.0 -r linux-x64 --self-contained true -o ./publish/linux
```

### Windows (x64)
```sh
dotnet publish -c Release -f net8.0 -r win-x64 --self-contained true -o ./publish/windows
```

### macOS (Intel, x64)
```sh
dotnet publish -c Release -f net8.0 -r osx-x64 --self-contained true -o ./publish/macos-x64
```

### macOS (Apple Silicon, ARM64)
```sh
dotnet publish -c Release -f net8.0 -r osx-arm64 --self-contained true -o ./publish/macos-arm64
```

---

## ▶️ Running Published Apps

- **Windows:**
  ```powershell
  .\publish\windows\YourApp.exe
  ```

- **Linux/macOS:**
  ```sh
  chmod +x ./publish/<platform>/YourApp
  ./publish/<platform>/YourApp
  ```

Replace `<platform>` with `linux`, `macos-x64`, or `macos-arm64`.

---

## ⚙️ Advanced Options

- **Framework-dependent deployment** (smaller binaries, requires .NET runtime installed on target):
  ```sh
  dotnet publish -c Release -f net8.0 -r <RID> --self-contained false
  ```

- **Single-file executable**:
  ```sh
  dotnet publish -c Release -f net8.0 -r <RID> --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
  ```

Common runtime identifiers (RIDs):  
- `win-x64`  
- `linux-x64`  
- `osx-x64`  
- `osx-arm64`

---

## 📦 Packaging Notes

- **Windows:** Zip the publish folder or build an installer (Inno Setup, MSI).
- **Linux:** Package as `.deb` or `.rpm` for easier installation.
- **macOS:** Wrap in an `.app` bundle or package as a `.dmg` for distribution.

---

## 🛠 Automating Builds for All Platforms

You can automate publishing for all targets with a single script.

### Linux/macOS (bash)
```sh
#!/bin/bash
dotnet publish -c Release -f net8.0 -r win-x64 --self-contained true -o ./publish/windows
dotnet publish -c Release -f net8.0 -r linux-x64 --self-contained true -o ./publish/linux
dotnet publish -c Release -f net8.0 -r osx-x64 --self-contained true -o ./publish/macos-x64
dotnet publish -c Release -f net8.0 -r osx-arm64 --self-contained true -o ./publish/macos-arm64
```

### Windows (PowerShell)
```powershell
dotnet publish -c Release -f net8.0 -r win-x64 --self-contained true -o ./publish/windows
dotnet publish -c Release -f net8.0 -r linux-x64 --self-contained true -o ./publish/linux
dotnet publish -c Release -f net8.0 -r osx-x64 --self-contained true -o ./publish/macos-x64
dotnet publish -c Release -f net8.0 -r osx-arm64 --self-contained true -o ./publish/macos-arm64
```

---

## ✅ Summary

With these instructions you can:
- Build and run your project locally on any OS.
- Publish standalone binaries for Windows, Linux, and macOS (Intel + Apple Silicon).
- Package your application for distribution to end users.
