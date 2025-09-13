using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment002.Model001
{
    public class ITI
    {
        public ITI()
        {

        }
        [Table("Student")]
        public class Student
        {
            [Key]
            public int Id { get; set; }
            [Required, MaxLength(50)]
            public string Fname { get; set; }
            [Required, MaxLength(50)]
            public string Lname { get; set; }
            [MaxLength(200)]
            public string Address { get; set; }
            public int Age { get; set; }
            [ForeignKey("DepartmentId")]
            public int Dep_Id { get; set; }

            public Department Department { get; set; }
            public ICollection<Stud_Course> Stud_Courses { get; set; }

        }
        [Table("Department")]
        public class Department
        {
            [Key]
            public int ID { get; set; }

            [Required, MaxLength(100)]
            public string Name { get; set; }

            public int Ins_ID { get; set; }

            [Column(TypeName = "date")]
            public DateTime HiringDate { get; set; }
            public ICollection<Student> Students { get; set; }
            public ICollection<Instructor> Instructors { get; set; }

        }

        [Table("Instructor")]
        public class Instructor
        {
            [Key]
            public int ID { get; set; }

            [Required, MaxLength(100)]
            public string? Name { get; set; }

            public decimal Bouns { get; set; }

            public decimal Salary { get; set; }

            [MaxLength(200)]
            public string Adress { get; set; }

            public decimal HourRate { get; set; }

            [ForeignKey("DepartmentId")]
            public int Dept_ID { get; set; }
            public Department Department { get; set; }
            public ICollection<Course_Inst> Course_Insts { get; set; }

        }
        [Table("Course")]
        public class Course
        {
            [Key]
            public int ID { get; set; }

            public int Duration { get; set; }

            [Required, MaxLength(100)]
            public string Name { get; set; }

            [MaxLength(250)]
            public string Description { get; set; }

            [ForeignKey("TopicId")]
            public int Top_ID { get; set; }
            public Topic Topic { get; set; }
            public ICollection<Stud_Course> Stud_Courses { get; set; }
            public ICollection<Course_Inst> Course_Insts { get; set; }

        }

        [Table("Topic")]
        public class Topic
        {
            [Key]
            public int ID { get; set; }

            [Required, MaxLength(100)]
            public string Name { get; set; }
            public ICollection<Course> Courses { get; set; }

        }

        [Table("Stud_Course")]
        public class Stud_Course
        {
            [Key, Column(Order = 1)]
            public int stud_ID { get; set; }


            public int Course_ID { get; set; }

            [MaxLength(10)]
            public string Grade { get; set; }

            public Student Student { get; set; }
            public Course Course { get; set; }

        }

        [Table("Course_Inst")]
        public class Course_Inst
        {
            [Key, Column(Order = 1)]
            public int inst_ID { get; set; }


            public int Course_ID { get; set; }

            [MaxLength(100)]
            public string evaluate { get; set; }
            public Instructor Instructor { get; set; }
            public Course Course { get; set; }

        }

      


    }
}
