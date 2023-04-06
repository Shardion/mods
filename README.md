# Shardion's mods monorepo
This repository contains the source code for every single Terraria mod I've made.

## Building
All mods in this repository require Rejuvena.Collate to build, and as such cannot be built in-game (for now).
To build these mods, you must first download Collate (`dotnet restore` if using the .NET CLI), and then you can build the mods with your IDE of choice (`dotnet build` for CLI).

## Overview
The many project names may feel confusing, but trust me, it's more annoying to refer to them by their full names.
A quick overview is as follows:

- `Shardion.Magician`: A mod which attempts to remove or optimize as many sources of client-side lag as possible.
- `Shardion.Ether`: A mod containing a single, Mutant-style bossfight, intended to be the highest quality fight I can make.
- `Shardion.Zephyros`: A mod which adds quality-of-life changes that let players focus on the gameplay, instead of removing it.
- `Shardion.Resistance`: A mod which adds mechanics expanding every area of the game *except* combat and boss-fighting. No weapons included!
- `Shardion.Limbo`: A mod containing a port of DOOM... to Terraria? <!-- The funny codename was reassigned to a file compressor. This is the best ending. -->
- `Shardion.Identic`: A class library which adds `ModConfig` widgets to view a mod's source code and license

## Contributing
Contributions are welcome and greatly appreciated! Just remember these two guidelines:

- Please format your code!
  There should be a menu option in your IDE of choice (or you can run `dotnet format`). It helps me and other contributors read your code, so we can get it merged sooner.
- If you don't understand something, ask!
  I will gladly walk you through the code of my mods ([make an issue](https://github.com/shardion/mods/issues/new) or ask in [my Discord server](https://discord.gg/PRYhCSeCNu)), and you can always ask the [tModLoader discord](https://discord.gg/tmodloader) and read the [tModLoader documentation](https://tmodloader.github.io/tModLoader/docs/1.4-stable/) for help with general tModLoader topics.
