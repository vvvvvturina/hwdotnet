namespace fCalc
open System
    
    module parser =

        exception NotEnoughArguments of string
        exception ArgsIsNotInt of string
        
        type ArgType =
            | Integer of int
            | NotInteger of ArgsIsNotInt
            
        let IsArgsEnough (strArr:string array) =
            if strArr.Length = 3
                then true
            else
                raise(NotEnoughArguments("Not enough arguments"))
                
        let IsInt (arg) =
            match arg with
            |int -> true
            
        let IsArgsInt arg1 arg2 =
            if IsInt(arg1)&&IsInt(arg2)
            then true
            else
                false
            
        
    module calculations =
        
        type Calculation =
            | Addition
            | Substraction
            | Multiply
            | Division
            | NotAnOperator
        
        type ResultBuilder(errorMes : string ) =
            new() = ResultBuilder("mes")
            member this.Zero() = Error errorMes
            member this.Bind(x, f) =
                match x with
                |Ok x -> f x
                |Error _ -> x
            member this.Combine(x, f) = f x
            member this.Return(x) = Ok x
        
        
        let GetOperator (oper : string) =
            match oper with
            | "+" -> Calculation.Addition
            | "/" -> Calculation.Division
            | "*" -> Calculation.Multiply
            | "-" -> Calculation.Substraction
            | _ -> Calculation.NotAnOperator
                
        let validateOperation oper =
            match oper with
            | NotAnOperator -> Error "not an operator"
            | _ -> Ok oper
            
        let validateDivision divider =
            match divider with
            |0 -> Error "can't divide by zero"
            |_ -> Ok divider
            
        
        let Calculate (a:Result<'T, string>) (b:Result<'T, string>) (operator:Calculation) =
            match validateOperation operator with
                |Ok operator->
                    ResultBuilder("can't divide by zero") {
                        let! v1 = a
                        let! v2 = b
                        match operator with
                        |Calculation.Addition -> return v1 + v2
                        |Calculation.Multiply -> return v1 * v2
                        |Calculation.Substraction -> return v1 - v2
                        |Calculation.Division ->
                            match validateDivision v2 with
                            |Ok v2 -> return v1 / v2
                            |Error "can't divide by zero" -> Error "can't divide by zero"
                    }
                |Error "not an operator" -> Error "not an operator"
                
                
    module main_ =
        [<EntryPoint>]
        let main argv =
            0