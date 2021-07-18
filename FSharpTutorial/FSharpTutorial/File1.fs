// namespaces contain classes and modules
namespace FSharpBasics

// grouping of code, kinda like a staick class
module Arithmetic = 
    module Addition = 
        let add x y = x + y


module Other = 
    //open Arithmetic
    let program = 
        Arithmetic.Addition.add 5 3