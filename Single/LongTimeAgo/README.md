## age.fsx

```fsharp
open System

type System.Int32 with
  member x.Months = DateTime.Today.AddMonths(x) - DateTime.Today
  member x.Years = DateTime.Today.AddYears(x) - DateTime.Today

type System.Double with
  member x.Days = DateTime.Today.AddDays(x) - DateTime.Today

type System.TimeSpan with
  member x.Ago = DateTime.Now.Add(-x)
  member x.FromNow = DateTime.Now.Add(x)
  member x.FromToday = DateTime.Today.Add(x)

let _20YearAgo = DateTime.Now - 20 .Years
let _50YearAgo = 50 .Years.Ago
let _100YearFromNow = DateTime.Now + 100 .Years

// val _20YearAgo : System.DateTime = 5/2/1996 5:39:27 PM
// val _50YearAgo : System.DateTime = 5/3/1966 5:39:27 PM
// val _100YearFromNow : System.DateTime = 5/2/2116 5:39:27 PM

type System.String with
    member x.Go = x + "go go go!"

"30803".Go
```