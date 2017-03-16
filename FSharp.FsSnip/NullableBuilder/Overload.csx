
var a = new Nullable<int>();
var b = a + 100;
Console.WriteLine(b == null);

var x = new Nullable<int>();
var y = x + 100;
Console.WriteLine(y == null);
