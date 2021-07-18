
let myOne = 1
let y : double = 2.3

let mutable isEnabled = true

isEnabled <- false

//let add x y = x + y
let add (x:int) (y:int) : int = x + y

let add' = fun x y -> x + y

let add'' x = fun y -> x + y

let add5' x = add 5 x

let add3' = (+) 3 

let times2' = (*) 2

let pow2 number = number ** 2

let operator' number = 
    number
    |> add3'
    |> times2'
    |> pow2

//let (>>) f g =
//    fun x ->
//        x
//        |> f
//        |> g

let operation'' = 
    add3' 
    >> times2' 
    >> pow2