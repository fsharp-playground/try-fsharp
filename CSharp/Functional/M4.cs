using System;
using Xunit;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

public class C<T> where T: struct
{
    public delegate T OnDemand();

    public static Nullable<T> CreateSimleNullable(T item) 
    {
        return new Nullable<T>(item);
    }
    public static OnDemand CreateSimpleOnDemand(T item)
    {
        return () => item;
    }
    public static IEnumerable<T> CreateSimpleSequence(T item)
    {
        yield return item;
    }
}

public class Functions {

    public static Nullable<int> ApplyFunction(Nullable<int> nullable, Func<int, int> function) {
        if(nullable.HasValue) {
            var u = nullable.Value;
            var v = function(u);
            return new Nullable<int>(v);
        }else {
            return new Nullable<int>();
        }
    }

    public static Nullable<T> ApplytFunctionG<T>(Nullable<T> nullable, Func<T, T> function) where T: struct {
        if(nullable.HasValue) {
            var u = nullable.Value;
            var v = function(u);
            return new Nullable<T>(v);
        }else {
            return new Nullable<T>();
        }
    }

    public static IEnumerable<int> AddOne2(IEnumerable<int> sequence) => from item in sequence select item + 1;

    public static IEnumerable<int> AddOne(IEnumerable<int> sequence) {
        foreach(var u in sequence) {
            var v = u + 1;
            yield return v;
        }
    }

    public static C<int>.OnDemand AddOne(C<int>.OnDemand onDemand) {
        return () => {
            var unwrapped = onDemand();
            var result = unwrapped + 1;
            return result;
        };
    }

    public static Lazy<int> AddOne(Lazy<int> lazy) {
        return new Lazy<int>(() => {
            var u = lazy.Value;
            var v = u + 1;
            return v;
        });
    }

    public async Task<int> AddOne(Task<int> task){
        var u = await task;
        var v = u + 1;
        return v;
    }

    public static Nullable<int> AddOne(Nullable<int> nullable)
    {
        return ApplyFunction(nullable, (x) => x + 1);
    }
}

public class M4
{
    [Fact]
    public void Test1()
    {
        Assert.True(Functions.AddOne(100).Value == 101);
    }

    Nullable<R> ApplyFunction<A,R>(Nullable<A> nullable, Func<A, R> function)  
        where A : struct 
        where R : struct {

        if(nullable.HasValue) {
            A u = nullable.Value;
            R v = function(u);
            return new Nullable<R>(v);
        }else {
            return new Nullable<R>();
        }
    }

    Lazy<R> ApplyFunction<A, R>(Lazy<A> lazy, Func<A, R> function) {
        return new Lazy<R>(() => {
            var unwrap = lazy.Value;
            var result = function(unwrap);
            return result;
        });
    }

    [Fact]
    public void NullableIntToDouble() {
        var x = ApplyFunction<int, double>(10, (a) => a / 2.0);
        Assert.True(x.Value == 5.0);
    }

    [Fact]
    public void LazyIntToDouble() {
        var x = ApplyFunction<int, double>( new Lazy<int>(() => 100), (a) => a / 2.0);
        Assert.True(x.Value == 50.0);
    }
}
