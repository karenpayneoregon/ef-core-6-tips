namespace GetWeekendDatesCorrectlyAppCore7.Classes;

internal static class DateTimeExtensions
{
    public static bool IsWeekend(this DateTime self) 
        => self.DayOfWeek is DayOfWeek.Sunday or DayOfWeek.Saturday;

    public static bool IsWeekDay(this DateTime self)
        => !self.IsWeekend();

    public static bool IsWeekDay(this DayOfWeek self) 
        => self is DayOfWeek.Monday or 
            DayOfWeek.Tuesday or 
            DayOfWeek.Wednesday or 
            DayOfWeek.Thursday or 
            DayOfWeek.Friday;

    public static bool IsWeekend(this DayOfWeek self) => !self.IsWeekDay();
}