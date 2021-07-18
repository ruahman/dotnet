namespace Test
module Test2 = 
    open System

    //let hello() =
    //    printf "Enter your name : "

    //    let name = Console.ReadLine()

    //    printfn "Hello %s" name

    //hello()

    //Console.ReadKey() |> ignore


    let bind_stuff() =
        let mutable weight = 175
        weight <- 170

        let change_me = ref 10
        change_me := 50

        printfn "Change : %i" ! change_me

    //let do_funcs() =
    //    let get_sum(x:int, y:int) : int = x + y
    //    printfn "5 + 7 = %i" (get_sum(5,7))

    //let do_funcs() = 
    //    let rec factorial x =
    //        if x < 1 then 1
    //        else x * factorial (x - 1)

    //    printfn "Factorial 4 : %i" (factorial 4)

    let do_funcs() = 
        let rand_list = [1;2;3]
        let rand_list2 = List.map (fun x -> x * 2) rand_list

        printfn "Double List : %A" rand_list2

        [5;6;7;8]
        |> List.filter (fun v -> (v % 2) = 0)
        |> List.map (fun x -> x * 2)
        |> printfn "Even Doubles : %A"

        let mult_num x = x * 3
        let add_num y = y + 5

        let mult_add = mult_num >> add_num
        let add_mult = mult_num << add_num

        printfn "mult_add : %i" (mult_add 10)
        printfn "add_mult : %i" (add_mult 10)


    let string_stuff() = 
        let str1 = @"I ignore \\"
        printfn "%s" (str1.[0..3])
            

    //string_stuff()


    let loop_stuff() = 
        //let magic_num = "7"
        //let mutable guess = ""

        //while not (magic_num.Equals(guess)) do
        //    printf "Guess the Number : "
        //    guess <- Console.ReadLine()

        //printfn "You Guessed the number"

        for i = 1 to 10 do 
            printfn "%i" i

        for i in [1..10] do 
            printfn "%i" i

        [1..10] |> List.iter (printfn "Num : %i")

        let sum = List.reduce (+) [1..10]
        printfn "%i" sum

    //loop_stuff()

    let cond_stuff() =
        let age = 7
        let grade2: string = 
            match age with
            | age when age < 5 -> "Preschool"
            | 5 -> "Kindergarten"
            | _ -> "College"
        printfn "%s "grade2

    cond_stuff()
    

    let list_stuff() = 
        let list1 = [1;2;3;4]

        list1 |> List.iter (printfn "Num : %i")

        printfn "%A" list1

        let list2 = 5::6::7::[]

        printfn "%A" list2

        let list3 = [1..5]

        let list6 = [for a in 1..5 do yield (a * a)]

        let list7 = [for a in 1..20 do if a % 2 = 0 then yield a]

        let list8 = [for a in 1..3 do yield! [a..a+2]]

        printfn "%A" list8

        printfn "Head : %i" list6.Head
        printfn "Tail : %A" list8.Tail

        let list9 = list8 |> List.filter (fun x -> x % 2 = 0)
        let list10 = list8 |> List.map (fun x -> (x * x))

        printfn "%A" list9
        printfn "%A" list10

    list_stuff()

    type emotion = 
    | joy = 0
    | fear = 1
    | anger = 2

    let enum_stuff(my_feeling) = 
        match my_feeling with
        | joy -> printfn "I'm joyful"
        | fear -> printfn "I'm fearful"
        | anger -> printfn "I am angree"

    enum_stuff(emotion.fear)


    let option_stuff() =
        let divide x y = 
            match y with
            | 0 -> None 
            | _ -> Some(x/y)

        if (divide 5 0).IsSome then
            printfn "%i" (divide 5 0).Value
        if (divide 5 0).IsNone then
            printfn "can divide by zero"
        
    let tuple_stuff() =
        let my_data = ("Derek", 42, 6.25)
        let (name, age, _) = my_data
        printfn "Name : %s" name

    type customer = 
        { Name : string;
        Balance : float}

    let record_stuff() = 
        let bob = { Name = "Bod Smith"; Balance = 101.50 }
        printfn "%s" bob.Name

    let seq_stuff() = 
        let seq1 = seq { 1..100 }
        printfn "%A" seq1


    let add_stuff<'T> x y = 
        printfn "%A" (x + y)

    let generic_stuff() = 
        add_stuff<float> 5.5 2.4

    type Rectangle = struct 
        val Length : float
        val Width : float

        new (length, width) = 
            {Length = length; Width = width}
    end

    let struct_stuff() = 
        let area(shape: Rectangle) = 
            shape.Length * shape.Width
        let rect = new Rectangle(5.5, 5.4)
        area(rect)

    

    type Animal = class
        val Name : string
        val Height : float
        val Weight : float

        new (name, height, weight) = 
            { Name = name; Height = height; Weight = weight }

        member x.Run =
            printfn "%s Runs" x.Name
    end

    type Dog(name, height, weight) = 
        inherit Animal(name, height, weight)

        member x.Bark = 
            printfn "bark"


    let class_stuff() = 
        let spot = new Animal("Spot", 20.5, 40.5)
        spot.Run

        let bowser = new Dog("Bowser", 20.5, 45.5)
        bowser.Bark

    class_stuff()
    

    Console.ReadKey() |> ignore