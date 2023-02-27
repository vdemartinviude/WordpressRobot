using JsonDocumentsManager;
using StateExecute;
using System.Reflection;
using TheRobot;
using TheStateMachine;
using TheStateMachine.Helpers;
using TheStateMachine.Model;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddSingleton<Robot>();
        services.AddSingleton<InputJsonDocument>();
        services.AddSingleton<ResultJsonDocument>();
        services.AddSingleton<MachineSpecification>(x => TheStateMachineHelpers.GetMachineSpecification(Assembly.Load("WordpressStatesAndGuards")));
        services.AddSingleton<TheMachine>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();