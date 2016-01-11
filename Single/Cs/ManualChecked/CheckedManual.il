.assembly extern mscorlib
{
  .ver 4:0:0:0
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 ) // .z\V.4..
}
.assembly 'CheckedManual'
{
  .custom instance void class [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::'.ctor'() =  (
		01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
		63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01       ) // ceptionThrows.

  .hash algorithm 0x00008004
  .ver  0:0:0:0
}
.module CheckedManual.dll // GUID = {5D97BF7A-43DB-47EB-9A7E-A379D93C149E}


  .class public auto ansi beforefieldinit Test
  	extends [mscorlib]System.Object
  {

    // method line 1
    .method public hidebysig specialname rtspecialname 
           instance default void '.ctor' ()  cil managed 
    {
        // Method begins at RVA 0x2050
	// Code size 7 (0x7)
	.maxstack 8
	IL_0000:  ldarg.0 
	IL_0001:  call instance void object::'.ctor'()
	IL_0006:  ret 
    } // end of method Test::.ctor

    // method line 2
    .method public hidebysig 
           instance default void Checked1 ()  cil managed 
    {
        // Method begins at RVA 0x2058
	// Code size 11 (0xb)
	.maxstack 2
	.locals init (
		int32	V_0)
	IL_0000:  ldc.i4 2147483647
	IL_0005:  stloc.0 
	IL_0006:  ldloc.0 
	IL_0007:  ldc.i4.1 
	IL_0008:  add.ovf 
	IL_0009:  stloc.0 
	IL_000a:  ret 
    } // end of method Test::Checked1

    // method line 3
    .method public hidebysig 
           instance default void Checked2 ()  cil managed 
    {
        // Method begins at RVA 0x2070
	// Code size 11 (0xb)
	.maxstack 2
	.locals init (
		int32	V_0)
	IL_0000:  ldc.i4 2147483647
	IL_0005:  stloc.0 
	IL_0006:  ldloc.0 
	IL_0007:  ldc.i4.1 
	IL_0008:  add.ovf 
	IL_0009:  stloc.0 
	IL_000a:  ret 
    } // end of method Test::Checked2

    // method line 4
    .method public hidebysig 
           instance default void Unchecked ()  cil managed 
    {
        // Method begins at RVA 0x2088
	// Code size 11 (0xb)
	.maxstack 2
	.locals init (
		int32	V_0)
	IL_0000:  ldc.i4 2147483647
	IL_0005:  stloc.0 
	IL_0006:  ldloc.0 
	IL_0007:  ldc.i4.1 
	IL_0008:  add 
	IL_0009:  stloc.0 
	IL_000a:  ret 
    } // end of method Test::Unchecked

  } // end of class Test

