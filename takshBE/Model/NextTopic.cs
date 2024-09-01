using System.ComponentModel.DataAnnotations;

namespace takshBE.Model
{
    public class NextTopic
    {
        [Key]
        public int topicid {  get; set; }
        public string topicname { get; set; }
        public string subject { get; set; }
        public DateOnly classdate { get; set; }
        public int completion {  get; set; }
        public int stand {  get; set; }
    }
}
