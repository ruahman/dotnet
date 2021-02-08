Config = {
    
    "network" => "tool-box",
    
    "dotnet" => {
        "image" => "mcr.microsoft.com/dotnet/sdk:5.0-alpine",
        "ports" => [5000, 5000],
        "expose" => 5000,
        "cmd" => "sh"
    },

    "nodejs" => {
        "image" => "node:latest",
        "ports" => [3000, 3000],
        "expose" => 3000,
        "env" => ['HOST=0.0.0.0']
    },

    "python" => {
        "image" => "python:latest",
        "ports" => [8000, 8000],
        "expose" => 8000
    },

    "mssql" => {
        "name" => "mssql",
        "image" => "mcr.microsoft.com/mssql/server:latest", 
        "password" => "RuahMan2398!",
        "volumeName" => "sqlvolume"
    }
}

