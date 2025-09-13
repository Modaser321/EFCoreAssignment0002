using EFCoreAssignment002.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using static EFCoreAssignment002.Model001.ITI;
namespace EFCoreAssignment002;

class Program
{
    public static void Main()
    {
        using (var context = new ITIDbContext())
        {
            
            var student = new Student { Fname = "Ali", Lname = "Hassan", Address = "Cairo", Age = 22, Dep_Id = 1 };
            context.Students.Add(student);

            var department = new Department { Name = "CS", HiringDate = DateTime.Now };
            context.Departments.Add(department);

            var instructor = new Instructor { Name = "Dr. Ahmed", Salary = 10000, Bouns = 500, Adress = "Giza", HourRate = 200, Dept_ID = 1 };
            context.Instructors.Add(instructor);

            var topic = new Topic { Name = "Programming" };
            context.Topics.Add(topic);

            var course = new Course { Name = "C# Basics", Duration = 30, Description = "Intro to C#", Top_ID = 1 };
            context.Courses.Add(course);

            var studCourse = new Stud_Course { stud_ID = 1, Course_ID = 1, Grade = "A" };
            context.StudCourses.Add(studCourse);

            var courseInst = new Course_Inst { inst_ID = 1, Course_ID = 1, evaluate = "Excellent" };
            context.CourseInsts.Add(courseInst);

            context.SaveChanges();
            Console.WriteLine(" Data Added!");


           
            var students = context.Students.ToList();
            foreach (var s in students)
                Console.WriteLine($"{s.Id} - {s.Fname} {s.Lname}");


            
            var std = context.Students.FirstOrDefault(s => s.Fname == "Ali");
            if (std != null)
            {
                std.Address = "Alexandria";
                context.SaveChanges();
                Console.WriteLine(" Student Updated!");
            }


            
            var stdToDelete = context.Students.FirstOrDefault(s => s.Fname == "Ali");
            if (stdToDelete != null)
            {
                context.Students.Remove(stdToDelete);
                context.SaveChanges();
                Console.WriteLine(" Student Deleted!");
            }

        }
    }

}