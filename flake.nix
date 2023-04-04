{
  description = "Reproducible developer environment for Terraria modding";
  inputs.nixpkgs.url = "nixpkgs/nixos-unstable";
  outputs = { self, nixpkgs }:
    let
      lastModifiedDate = self.lastModifiedDate or self.lastModified or "19700101";
      version = builtins.substring 0 8 lastModifiedDate;
      supportedSystems = [ "x86_64-linux" "x86_64-darwin" "aarch64-linux" "aarch64-darwin" ];
      forAllSystems = nixpkgs.lib.genAttrs supportedSystems;
      nixpkgsFor = forAllSystems (system: import nixpkgs { inherit system; });
    in
    {
      devShells = forAllSystems (system:
        let 
          pkgs = nixpkgsFor.${system};
        in
        {
          lsp = pkgs.mkShell {
            buildInputs = with pkgs; [
              omnisharp-roslyn
              dotnet-sdk # Should be, and is as of writing, .NET 6
            ];
          };

          default = self.devShells.${system}.lsp;
        });
    };
}
