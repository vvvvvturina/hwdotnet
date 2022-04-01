namespace fcalcASP

open System
open fCalc
open calculator
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Giraffe
open Microsoft.Extensions.Logging
open calculatorHandler
 
module Startup_ =
    let webApp =
        choose [
            route "/"   >=> text "pong"
            route "/Calculate"       >=> CalculatorHandler ]
open Startup_
type Startup() =
    member _.ConfigureServices (services : IServiceCollection) =
        // Register default Giraffe dependencies
        services.AddGiraffe() |> ignore

    member _.Configure (app : IApplicationBuilder)
                        (env : IHostEnvironment)
                        (loggerFactory : ILoggerFactory) =
        // Add Giraffe to the ASP.NET Core pipeline
        app.UseGiraffe webApp
        