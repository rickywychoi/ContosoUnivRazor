using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    // Indexing prevents duplicate data with different PK in this particular table and allows more efficient data search.
    [Index(nameof(CourseID), nameof(StudentID), IsUnique = true)]
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        //// Foreign key: https://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx
        //[ForeignKey("Course")]
        public int CourseID { get; set; }

        //[ForeignKey("Student")]
        public int StudentID { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
