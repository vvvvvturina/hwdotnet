namespace fcalcASP

module calculator =


 [<CLIMutable>]
 type Values=
    {
        var1 : decimal
        var2 : decimal
        operation : string
    }
    
 let Calculate var1 var2 operation =
        match operation with
        |"plus" -> Ok (var1 + var2)
        |"minus" -> Ok (var1 - var2)
        |"mult" -> Ok (var1 * var2)
        |"divide" ->
            if var2 = 0m then
                Error "can not divided by zero"
            else
                Ok (var1 / var2)
        | _ -> Error "Unknown operation"
 let Calculate_ (value: Values) =
     Calculate value.var1 value.var2 value.operation