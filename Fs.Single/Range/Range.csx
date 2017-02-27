class Range {
    public int Start { set; get;}
    public int End { set; get;}
}

var thaiRange = new Range { Start = 10, End = 20 };
var koreanRange = new Range { Start = 30, End = 40 };

class Test {
    bool IsInRange(int v, Range range) => v >= range.Start && v <= range.End;
    public bool IsThai(int v) => IsInRange(v, thaiRange);
    public bool IsKorean(int v) => IsInRange(v, koreanRange);
}

var test = new Test()
test.IsThai(10);
test.IsKorean(30);

