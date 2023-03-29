# Shardion's mods monorepo
This repository contains the source code for every single Terraria mod I've made.

## Building
All mods in this repository require Rejuvena.Collate to build, and as such cannot be built in-game (for now).
To build these mods, you must first download Collate (`dotnet restore` if using the .NET CLI), and then you can build the mods with your IDE of choice (`dotnet build` for CLI).

## Overview
The many project names may feel confusing, but trust me, it's more annoying to refer to them by their full names.
A quick overview is as follows:

- `Shardion.Ether`: A mod containing a single, Mutant-style bossfight, intended to be the highest quality fight I can make.
- `Shardion.Zephyros`: A mod for all of my random fixes and tweaks. Needs a rewrite.
- `Shardion.Limbo`: A mod containing a port of DOOM... to Terraria? <!-- The funny codename was reassigned to a file compressor. This is the best ending. -->
- `Shardion.Flashback`: A mod which adds a vanity item layering system. (Which hasn't been ported over from Zephyros yet...)
- `Shardion.Magician`: A mod which attempts to remove or optimize as many sources of client-side lag as possible.

## Contributing
Contributions are welcome! Just remember these two guidelines:

- Please format your code!
  There should be a menu option in your IDE of choice (or you can run `dotnet format`). It helps me and other contributors read your code, so we can get it merged sooner.
- If you don't understand something, ask!
  I will gladly walk you through the code of my mods ([make an issue](https://github.com/shardion/mods/issues/new) or ask in [my Discord server](https://discord.gg/PRYhCSeCNu)), and you can always ask the [tModLoader discord](https://discord.gg/tmodloader) and read the [tModLoader documentation](https://tmodloader.github.io/tModLoader/docs/1.4-stable/) for help with general tModLoader topics.
