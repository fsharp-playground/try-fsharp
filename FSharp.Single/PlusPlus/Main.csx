
using System.Diagnostics;

var sw = Stopwatch.StartNew();

var count = 0;
for (int i = 0; i < 200000000; i ++) {
    count += 1;
}

Console.WriteLine($"Count = {count}, Time = {sw.ElapsedMilliseconds} ms");