public class BaseClass { }
public class SubClass1 : BaseClass { }
public class SubClass2 : BaseClass {
    public SubClass2(string p1) { }
}

public class IInterface { }
public class Implement : IInterface {}

public class Generic {
    public void Method1<T>(T t) where T : class {  }
    public void Method2<T>(T t) where T : struct {  }
    public void Method3<T>(T t) where T : new() { }
    public void Method4<T>(T t) where T :  BaseClass { }
    public void Method5<T>(T t) where T : IInterface { }
}



