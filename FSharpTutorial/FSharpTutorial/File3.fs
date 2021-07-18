namespace FSharpBasics
// algebraic type system
// record type
// tuple
// anonymous record
module Types =

    // product types
    type Date = {Day: int; Month: int}
    type Person = {Name: string; Age: int}

    let ben = { Name = "Ben"; Age = 26 }
    let alex = { Name = "Alex"; Age = 40 }
    ben.Name |> ignore

    let incrementAge person =
        { person with Age = person.Age + 1 }

    incrementAge ben |> ignore

    // this is how you define a tuple
    type DuoTuple' = Person * Person

    // annon record
    let duo = {|Person1 = ben; Person2 = alex|}

    //let Duotup = (person1,person2)

    // sum types

    type Suit = 
        | Hearts
        | Clubs
        | Spades
        | Diamonds

    type Rectangle = {Base: double; Height: double}

    let area {Base = b; Height = h} =
        b * h

    type Shape =
        | Rectangle of Rectangle
        | Triangle of height:double * _base:double
        | Circle of radius:double
        | Dot

    //let yesOrNo bool =
    //    match bool with
    //    | true -> "Yes"
    //    | false -> "No"

    // dont need paramiter for function
    let yesOrNo' = function
        | true -> "Yes"
        | false -> "No"

    let isOdd = function
        | x when x % 2 = 0 -> false
        | _ -> false

    let circle = Circle 1.
    let triangle = Triangle (2.14, 4.)

    module Shape = 
        let area shape = 
            match shape with
            | Rectangle {Base = b; Height = h} -> b * h
            | Triangle (height, _base) -> height * _base / 2.
            | Circle radius -> radius ** 2. * System.Math.PI
            | Dot -> 1.

    Shape.area circle |> printfn "%f"
    Shape.area triangle |> ignore

    type OrderId = OrderId of int 

    let incrementOrderId (OrderId id) =
        id + 1
        |> OrderId

    type Option<'a> =
        | Some of 'a
        | None

    let translateFizzBuzz = function
        | "Fizz" -> Some 3
        | "Buzz" -> Some 5
        | "FizzBuzz" -> Some 15
        | _ -> None

    let hasValue = function
        | Some _ -> true
        | None -> false

    let array = [|1;2;3;4;5|]
    array.[0] <- 5

    let list = [1;2;3;4;5]

    let getFirstItem = function
        | x::_ -> Some x
        | _ -> None

    let rec printEveryItem = function
        | x::xs ->
            printfn "%o" x
            printEveryItem xs
        | [] -> ()

    printEveryItem [1;2;3;4]

    let rec doWithEveryItem f = function
        | x::xs ->
            f x
            doWithEveryItem f xs
        | [] -> ()

    let printEveryItem' list = 
        doWithEveryItem (printfn "%O") list

    let printEveryItem'' list =
        List.iter (printfn "%O") list

    let stringifyList list =
        List.map string list

    [1;2;3;4;5]
    |> stringifyList |> ignore