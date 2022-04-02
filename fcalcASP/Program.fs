module fcalcASP.Program


 open System.IO
 open Microsoft.AspNetCore.Hosting
 open Microsoft.Extensions.Hosting
 
 let contentRoot = Directory.GetCurrentDirectory()
 
 let CreateHostBuilder (_ : string array) =
                Host.CreateDefaultBuilder()
                    .ConfigureWebHostDefaults(fun webHostBuilder ->
                    webHostBuilder
                        .UseContentRoot(contentRoot)
                        .UseStartup<Startup>()
                    |> ignore)
 let CreateHistBuilder args =
     Host
         .CreateDefaultBuilder(args)
         .ConfigureWebHostDefaults(
             fun webBuilder ->
                 webBuilder.UseStartup<Startup>()
                 |> ignore)
         
         
 [<EntryPoint>]
 let main _ =
    Host
        .CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webBuilder ->
                 webBuilder.UseStartup<Startup>()
                 |> ignore)
        .Build()
        .Run()
    0