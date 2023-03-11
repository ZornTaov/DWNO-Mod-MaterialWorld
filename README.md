# DWNO MaterialWorld Mod

Trainer mod for Builder Materials.

## Documentation

While in the Bulder Material window (Talk to Veemon, press Triangle), you can Increase/decrease the materials you have for the builder using the Right Stick Up/Down. Start shows all hidden materials, Select hides any material type you have 0 of.

## Installation

1. Install [BepInEx](https://github.com/BepInEx/BepInEx) ([Tutorial by Yasha-jin](https://github.com/Yasha-jin/DWNOModdingGuides/blob/main/Guides/HowToInstallBepInExForDWNO.md))
2. Download the latest release from the [Releases Tab](https://github.com/ZornTaov/DWNO-Mod-MaterialWorld/releases)
3. Copy the `MaterialWorld.dll` into the `plugins` folder of BepinEx
4. Start the game and enjoy :)

## Building

In order to build the plugin yourself you have to

1. Install BepInEx (see instructions above)
2. clone the project
3. copy the `interop` folder into the project
4. run `dotnet build -c Release` inside the folder (or open the .csproj with Visual Studio)

The `MaterialWorld.dll` should now be in `bin/Release/net6.0`.

You'll have to have .Net 6.0 or higher installed.

## Contact
* Discord: ZornTaov in either the [Digimon Modding Community](https://discord.gg/cb5AuxU6su) or [Digimon Discord Community](https://discord.gg/0VODO3ww0zghqOCO)