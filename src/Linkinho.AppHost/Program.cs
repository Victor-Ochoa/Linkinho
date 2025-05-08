var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Linkinho_Api>("linkinho-api");

builder.Build().Run();
