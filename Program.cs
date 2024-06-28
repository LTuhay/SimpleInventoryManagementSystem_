using Microsoft.Extensions.DependencyInjection;
using SimpleInventoryManagementSystem.DataBase;
using SimpleInventoryManagementSystem.ProductManagement.Entity;
using SimpleInventoryManagementSystem.ProductManagement.Repository;
using SimpleInventoryManagementSystem.Utilities;

String connectionString = "Server=DESKTOP-4J9GHFA;Database=SimpleInventoryManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;";

var serviceProvider = new ServiceCollection()
    .AddSingleton<DatabaseInitializer>(sp => new DatabaseInitializer(connectionString))
    .AddSingleton<IProductRepository>(sp => new ProductRepository(connectionString))
    .AddSingleton<Inventory>()
    .AddSingleton<Utilities>()
    .BuildServiceProvider();
var dataBaseInitializer = serviceProvider.GetService<DatabaseInitializer>();
dataBaseInitializer.Initialize();
var utilities = serviceProvider.GetService<Utilities>();
utilities.ShowMainMenu();

