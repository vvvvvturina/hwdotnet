module fcalc_ASP.calculatorHandler

 open fCalc
 open Giraffe
 open Giraffe.Core
 open Microsoft.Extensions.Logging
 open calculator


 let CalculatorHandler: HttpHandler =
    fun next ctx ->
        let values = ctx.TryBindQueryString<Values>()
        match values with
        |Ok v ->
            let result = Calculate_ v
            match result with
            |Ok result  -> (setStatusCode 200 >=> json result) next ctx
            |Error error -> (setStatusCode 400 >=> json error) next ctx
        |Error error -> (setStatusCode 400 >=> json error) next ctx
        
