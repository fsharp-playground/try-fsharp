
Task("Build-Readme").Does(() => {
    var links = new List<string>();
    
    var files = new System.IO.DirectoryInfo("./Single")
        .GetFiles("*.fsx", System.IO.SearchOption.AllDirectories)
        .GroupBy(x => x.Directory.FullName)
        .Select(x => x.FirstOrDefault())
        .ToList();

    files.ForEach(file => {
        Console.WriteLine(file.FullName);
        var text = System.IO.File.ReadAllText("T4/readme.template");
        var source = System.IO.File.ReadAllText(file.FullName);
        var name = file.Name;
        var newText = text
            .Replace("{{fileName}}", name)
            .Replace("{{source}}", source);

        var mdFile = System.IO.Path.Combine(file.Directory.FullName, "README.md");
        System.IO.File.WriteAllText(mdFile, newText);

        var dirName = file.Directory.Name;
        var link = $"- [{dirName}](Single/{dirName})";
        links.Add(link);
    });

    var mainTemplate = System.IO.File.ReadAllText("T4/main.template");
    var mainText = mainTemplate.Replace("{{links}}", String.Join("\n", links));
    System.IO.File.WriteAllText("README.md", mainText);
});

var target = Argument("target", "default");
RunTarget(target);