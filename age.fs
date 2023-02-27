// Version: 1.0
// This F# version of the program uses functional programming concepts to make the code more concise and readable.
// The program is divided into several functions that each perform a specific task.
// The inputBirthdate function reads user input from the console, and the parseBirthdate function converts the input string to a DateTime object.
// The getAge function calculates the age of the user based on the birthdate, and the getDaysUntilNextBirthday function calculates the number of days until the user's next birthday.
// Finally, the main function calls each of these functions and prints the results to the console.

open System
open System.Globalization

let inputBirthdate () =
    printf "Enter your birthdate (MM/DD/YYYY): "
    Console.ReadLine()

let parseBirthdate (birthdateString : string) =
    let formatter = DateTimeFormatInfo.InvariantInfo
    DateTime.ParseExact(birthdateString, "MM/dd/yyyy", formatter)

let getAge (birthdate : DateTime) =
    let today = DateTime.Today
    let age = today.Year - birthdate.Year
    if today < birthdate.AddYears(age) then age - 1 else age

let getDaysUntilNextBirthday (birthdate : DateTime) =
    let age = getAge birthdate
    let nextBirthday = birthdate.AddYears(age + 1)
    (nextBirthday - DateTime.Today).Days

let main () =
    let birthdateString = inputBirthdate()
    let birthdate = parseBirthdate birthdateString
    let daysUntilNextBirthday = getDaysUntilNextBirthday birthdate

    printfn "You were born on %s, which was a %s" (birthdate.ToString("MM/dd/yyyy")) (birthdate.DayOfWeek)
    printfn "You are currently %d years old." (getAge birthdate)
    printfn "Your next birthday is in %d days." daysUntilNextBirthday

main()


// Version: 1.0.2
// An optimized version of the previous F# code:
// In this version, the DateTimeFormatInfo.InvariantInfo parameter in the DateTime.ParseExact method call has been replaced with null, which allows the method to use the default culture.
// This simplifies the code and makes it more efficient.
// Additionally, the getDaysUntilNextBirthday function has been optimized to use a single line of code to calculate the number of days until the user's next birthday.
// This eliminates the need for the nextBirthday variable and makes the code more concise.
// Overall, these changes should result in faster and more efficient code.

open System
open System.Globalization

let inputBirthdate () =
    printf "Enter your birthdate (MM/DD/YYYY): "
    Console.ReadLine()

let parseBirthdate (birthdateString : string) =
    DateTime.ParseExact(birthdateString, "MM/dd/yyyy", null)

let getAge (birthdate : DateTime) =
    let today = DateTime.Today
    let age = today.Year - birthdate.Year
    if today < birthdate.AddYears(age) then age - 1 else age

let getDaysUntilNextBirthday (birthdate : DateTime) =
    (birthdate.AddYears(getAge birthdate + 1) - DateTime.Today).Days

let main () =
    let birthdateString = inputBirthdate()
    let birthdate = parseBirthdate birthdateString
    let daysUntilNextBirthday = getDaysUntilNextBirthday birthdate

    printfn "You were born on %s, which was a %s" (birthdate.ToString("MM/dd/yyyy")) (birthdate.DayOfWeek)
    printfn "You are currently %d years old." (getAge birthdate)
    printfn "Your next birthday is in %d days." daysUntilNextBirthday

main()
