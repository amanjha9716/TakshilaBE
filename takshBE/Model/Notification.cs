namespace takshBE.Model
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public int stan {  get; set; }
        public bool IsProcessed { get; set; }
    }
}
