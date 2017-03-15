
class C {
    public static int operator +(C c, int i) => c + i;
    public static int operator +(int i, C c) => c + i;
    public static implicit operator int(C c) => 1;
    public static implicit operator C(int i) => new C();
}

Console.WriteLine(new C() + 100);
Console.WriteLine(100 + new C());

