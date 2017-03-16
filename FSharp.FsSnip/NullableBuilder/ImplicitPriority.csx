class C {
    public static int operator +(int i, C c) => c + i;
    public static int operator +(C c, int i) => c + i;
    
    public static implicit operator C(int i) => new C();
    public static implicit operator int(C c) => 1;
}

var x = 100 + new C(); // int
var y = new C() + 100; // int