using Xunit;
using System;

public class M62 {

    static Func<T> CreateSimpleOnDemand<T>(T t)
    {
        return () => t;
    }
    static Func<R> ApplySpecialFunction<A, R>( Func<A> onDemand, Func<A, Func<R>> function)
    {
        return () => function(onDemand())();
    }

    [Fact]
    public void Identity() {
        //Func<int> original = () => DateTime.Now.Millisecond;
        Func<int> original = () => 100;
        Func<int> v1 = ApplySpecialFunction(original, CreateSimpleOnDemand);
        Func<int> v2 = ApplySpecialFunction(original, CreateSimpleOnDemand);

        Assert.True(original() == v1());
    }

    [Fact]
    public void Identify2() {
        // ApplySpecialFunction(CreateSimpleM(someValue), someFunction)
        // someFunction(someValue)

        Func<int, Func<double>> x = (input) => {
            return () => input + 1; 
        };

        var someValue = 100;
        var v1 = ApplySpecialFunction<int, double>(CreateSimpleOnDemand(someValue), x);
        var v2 = x(someValue);

        Assert.True(v1() == v2());
    }
}