using System;
using System.IO;
using Microsoft.FSharp.Core;
using NUnit.Framework;

// Token: 0x02000002 RID: 2
[CompilationMapping(SourceConstructFlags.Module)]
public static class Program
{
    // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
    [EntryPoint]
    public static int Main(string[] argv)
    {
        PrintfFormat<FSharpFunc<string[], Unit>, TextWriter, Unit, Unit> format = new PrintfFormat<FSharpFunc<string[], Unit>, TextWriter, Unit, Unit, string[]>("%A");
        PrintfModule.PrintFormatLineToTextWriter<FSharpFunc<string[], Unit>>(Console.Out, format).Invoke(argv);
        return 0;
    }

}

public class ProgramSpec
{
    [Test]
    public void Start()
    {
        Program.Main(new string[] { "1", "2" });
    }
}
