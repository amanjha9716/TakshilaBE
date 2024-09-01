using System.ComponentModel.DataAnnotations;

namespace takshBE.Model
{
    public class studyMaterial
    {
        [Key]
        public Guid pdfid { get; set; }
        public string pdfname { get; set; }
        public string subjectname { get; set; }
        public int standard { get; set; }
        public byte[] pdfcontent { get; set; }
    }
}
