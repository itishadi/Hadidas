namespace Hadidas.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public string MyShift { get; set; } = null!;
        public string DayOfWeek { get; set; } = null!;
        public string WeekOfYear { get; set; } = null!;
        public string Month { get; set; } = null!;
        public string Year { get; set; } = null!;
        public DateTime DateTime { get; set; }

    }
}
