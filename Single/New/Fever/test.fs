type Temperature =
    | Celsius of double
    | Fahrenheit of double

let hasFever temp  =
    match temp with
    | Celsius value -> (value > 37.5)
    | Fahrenheit value -> (value > 99.0)

hasFever (Celsius 10.5)
hasFever (Fahrenheit 115.5)
