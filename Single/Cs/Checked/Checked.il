.assembly extern mscorlib
{
  .ver 4:0:0:0
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 ) // .z\V.4..
}
.assembly 'Checked'
{
  .custom instance void class [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::'.ctor'() =  (
		01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
		63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01       ) // ceptionThrows.

  .hash algorithm 0x00008004
  .ver  0:0:0:0
}
.module Checked.exe // GUID = {1C62A449-91EB-4A6C-8418-29E470C8D7D4}


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
    .method public static hidebysig 
           default void Main (string[] args)  cil managed 
    {
        // Method begins at RVA 0x2058
	.entrypoint
	// Code size 24 (0x18)
	.maxstack 2
	.locals init (
		int32	V_0)
	IL_0000:  ldc.i4 2147483647
	IL_0005:  ldstr "1"
	IL_000a:  call int32 int32::Parse(string)
	IL_000f:  add.ovf 
	IL_0010:  stloc.0 
	IL_0011:  ldloc.0 
	IL_0012:  call void class [mscorlib]System.Console::WriteLine(int32)
	IL_0017:  ret 
    } // end of method Test::Main

  } // end of class Test

