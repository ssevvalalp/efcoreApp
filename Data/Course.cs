using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string? CourseTitle { get; set; }
    }
}
