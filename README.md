# MysterySpire

A Slay the Spire 2 mod that hides map room icons — all rooms show the unknown `?` icon until you visit them. The legend is also renamed to "Cheatsheet" as a reminder that you're playing without it.

Visual only. Does not affect gameplay or saves — safe to add or remove mid-campaign.

## Installation

1. Download `MysterySpire.dll` and `mod_manifest.json` from [Releases](../../releases)
2. Place both files into a `MysterySpire/` folder inside your STS2 mods directory:
   ```
   Steam/steamapps/common/Slay the Spire 2/mods/MysterySpire/
   ├── MysterySpire.dll
   └── mod_manifest.json
   ```
3. Launch the game — it will detect the mod automatically

**Linux only:** Add this to your Steam launch options (right-click STS2 → Properties → General):
```
LD_PRELOAD=/usr/lib/libgcc_s.so.1 %command%
```

## Building from source

**Prerequisites:**
- [.NET SDK 9+](https://dotnet.microsoft.com/download)
- Slay the Spire 2 installed via Steam

**Setup:**

Copy `local.props.example` to `local.props` and fill in your paths:
```xml
<Project>
  <PropertyGroup>
    <STS2GamePath>/path/to/Slay the Spire 2</STS2GamePath>
    <GodotExePath>/path/to/Godot_mono_executable</GodotExePath>
  </PropertyGroup>
</Project>
```

**Build:**
```bash
dotnet build MysterySpire.csproj
```

The DLL and manifest are automatically copied to your mods folder on build.

**To regenerate decompiled game source** (useful for finding new patch targets):
```bash
dotnet tool install ilspycmd -g --prerelease
ilspycmd "data_sts2_linuxbsd_x86_64/sts2.dll" --outputdir decompiled --project
```
