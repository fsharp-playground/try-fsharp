using System;
using Xunit;

public class M6 {
    Lazy<T> CreateM<T>(T value) => new Lazy<T>(() => value);

    Lazy<R> ApplyFunction<A, R>(Lazy<A> lazy, Func<A,R> function) {
        return new Lazy<R>(() => {
            var unwraped = lazy.Value;
            var result = function(unwraped);
            return result;
        });
    }

    Lazy<R> ApplySpecialFunction<A, R>(Lazy<A> lazy, Func<A, Lazy<R>> function) {
        return new Lazy<R>(() => {
            var unwraped = lazy.Value;
            var result = function(unwraped);
            return result.Value;
        });
    }

    Lazy<R> ApplyFunctionX<A,R>(Lazy<A> wraped, Func<A, R> function) {
        return ApplySpecialFunction<A,R>(wraped, (a) => CreateM<R>(function(a)));
    }

    [Fact]
    public void Test(){ 
        var lazy = new Lazy<int>(() => 1);
        var result = ApplySpecialFunction(lazy, CreateM);
    }
}