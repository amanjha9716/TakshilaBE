using Microsoft.EntityFrameworkCore;

namespace takshBE.Model
{
    public class studentDbcontext:DbContext
    {
        public studentDbcontext(DbContextOptions<studentDbcontext> options):base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<studyMaterial> Materials { get; set; }
        public DbSet<NextTopic> NextTopics { get; set; }
       

    }
}
