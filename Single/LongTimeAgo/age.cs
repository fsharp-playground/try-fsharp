
using System;

public static class Int32Exptension
{
    static TimeSpan Months(this Int32 dt, int x)
    {
        return DateTime.Today.AddMonths(x) - DateTime.Today;
    }
    static TimeSpan Years(this Int32 dt, int x) {
        return DateTime.Today.AddYears(x) - DateTime.Today;
    }
}

public static class DoubleExtension
{
    public static TimeSpan Days(this DateTime dt, int x)
    {
        return DateTime.Today.AddDays(x) - DateTime.Today;
    }
}

public static class TimeSpanExtension {
  public static TimeSpan Ago(this DateTime x) {
      return DateTime.Now.Add(-x);
  }
}

public class Test {
    public void Go() {
        var rs = DateTime.Now - (10).Years();
    }
}
