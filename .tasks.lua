return {
    ["Run"] = "dotnet run --project App",
    ["Build"] = "dotnet build",
    ["Loc"] = [[ find App ColorTransformer Gui -type f -name "*.cs" | xargs wc -l ]]
}
