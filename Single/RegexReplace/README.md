## Main.csx

```fsharp
using System.Text.RegularExpressions;
using System.Linq;

var pattern = @"_x003(\d)_";
var input = "_x0031_23456789123/_x0030_1 Application/_x0031_2340830380-01.pdf";

var regex = new Regex(pattern);
var rs = regex.Matches(input).Cast<Match>().Select(x => new { x.Value, Num = x.Groups[1]} );
foreach (var item in rs)
{
    Console.WriteLine(item);
}




```