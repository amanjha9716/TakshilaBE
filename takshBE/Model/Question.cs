using System.ComponentModel.DataAnnotations;

namespace takshBE.Model
{
    public class Question
    {
        [Key]
        public Guid quesid {  get; set; }
        public string subject { get; set; }
        public int standard {  get; set; }

        public string statement {  get; set; }
        public List<string> options { get; set; }
        public string answer { get; set; }

    }
}
