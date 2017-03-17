// https://blogs.msdn.microsoft.com/wesdyer/2008/01/10/the-marvels-of-monads/

using System.Threading.Tasks;

var a = new Nullable<int>();
Func<int> b = () => 100;
var c = new Lazy<int>(() => 100);
var d = new Task<int>(() => 1);
var e = new [] { 1, 2 };

Console.WriteLine(c.Value);
