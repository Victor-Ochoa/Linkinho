var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql-server-db-omg")
                 .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("database", "linkinho");

builder.AddProject<Projects.Linkinho_Api>("linkinho-api")
    .WithReference(db)
    .WaitFor(db)
    .WithExternalHttpEndpoints();

builder.Build().Run();
