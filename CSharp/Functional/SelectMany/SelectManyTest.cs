// http://joashc.github.io/posts/2016-03-17-select-many-weird.html

using Xunit;
using System.Collections.Generic;
using System.Linq;

public class SelectManyTest {
    [Fact]
    public void MoreThanOwo() {

        var itemList = new [] { new { Name = "Hello "}};
        var widgetList = new [] { new { Id = 100 }};
        var query = 
                    from number in new List<int>{1,2,3}
                    from letter in new List<char>{'a','b','c'}
                    from item in itemList
                    from widget in widgetList
                    select $"({number}, {letter}, {item.Name}, {widget.Id})";

        var q2 = new List<int>{1,2,3}
                .SelectMany( number => new List<char>{'a','b','c'}, (number, letter) => new { number, letter })
                .SelectMany( ti1 => itemList, (ti1, item) => new { ti1, item })
                .SelectMany( ti2 => widgetList, (ti2, widget) => $"({ti2.ti1.number}, {ti2.ti1.letter}, {ti2.item.Name}, {widget.Id})");

        Assert.Equal(query.ToArray(), q2.ToArray());
    }

    [Fact]
    public void SugarDesugar() {
        var query = 
            from number in new List<int> { 1 }
            from letter in new List<char> { 'a', 'b', 'c' }
            select $"{number}-{letter}";

        var expect = new [] { "1-a", "1-b", "1-c" };

        Assert.Equal(query.ToArray(), expect);

        var q2 = new List<int> { 1 }
            .SelectMany(number => new List<char> { 'a', 'b', 'c'}
                .Select(letter => $"{number}-{letter}"));

        Assert.Equal(q2.ToArray(), expect);

    }
}