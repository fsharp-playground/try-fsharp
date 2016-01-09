using System.Linq;
using System;
using System.Collections.Generic;

// dmcs Enumerable.cs

public class Test {
    public static void Main(String[] args) {

        Action<Object> write = (s) => Console.WriteLine(s.ToString());
        var a = Enumerable.Empty<string>();
        var b = Enumerable.Empty<string>();
        var c = Enumerable.Empty<string>();
        var d = Enumerable.Empty<int>();
        var e = Enumerable.Empty<byte>();

        var l1 = Enumerable.Empty<List<string>>();
        var l2 = Enumerable.Empty<List<int>>();

        write(a == b);      // true
        write(a == c);      // true
        write(a == d);      // false
        write(d == e);      // false
        write(l1 == l2);    // false
    }
}