
Task("Go").Does(() => {
    Console.WriteLine("Hello, world!");
});

var target = Argument("target", "default");
RunTarget(target);