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

        exception NotAnOperatorException of string
        exception CanNotDivideByZero of string

        let GetOperator (calculation : string) =
            if calculation = "+"
                then Calculation.Addition
            elif calculation = "-"
                then Calculation.Substraction
            elif calculation = "*"
                then Calculation.Multiply
            elif calculation = "/"
                then Calculation.Division
            else
                raise(NotAnOperatorException("This operator does not exist"))
                

        let Calculate (a:int) (b:int) (operator:Calculation) =
            match operator with
                | Calculation.Addition -> a + b
                | Calculation.Substraction -> a - b
                | Calculation.Division ->
                    if b=0
                        then raise(CanNotDivideByZero("Can not be divided by zero"))
                    else
                        a / b
                | Calculation.Multiply -> a * b
    
    module main_ =
        
        [<EntryPoint>]
        let main argv =
            let checkIfArgsEnough = parser.IsArgsEnough argv
            let arg1 = argv.[0]
            let arg2 = argv.[2]
            let checkIfArgsInt = (parser.IsInt(Int32.Parse(arg1)))&&(parser.IsInt(Int32.Parse(arg2)))
            let operation = calculations.GetOperator argv.[1]
            if checkIfArgsEnough&&checkIfArgsInt
            then
                let output = calculations.Calculate (Int32.Parse(argv.[0])) (Int32.Parse(argv.[2])) operation
                output
            else 0