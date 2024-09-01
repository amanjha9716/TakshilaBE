using System.ComponentModel.DataAnnotations;

namespace takshBE.Model
{
    public class Assessment
    {
        [Key]
        public Guid assesid { get; set; }
        public string assessename { get; set;}
        public string subject { get; set;}
        public DateOnly? expirydate { get; set;}
        public int stan {  get; set;}
        public int totalstud { get; set;}
        public List<Guid> questions { get; set;}

    }
}
