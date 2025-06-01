namespace WebMessageApp.Models
{
    public class CountdownViewModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TimeRemaining { get; set; }
    }
}
