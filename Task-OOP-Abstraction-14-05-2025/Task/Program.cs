using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Task;

class Instructor
{
    public int InstructorId;
    public string Name;
    public string Specialization;

    public string PrintDetails()
    {
        return "";
    }
}
class Course
{
    public int CourseId;
    public string Title;
    Instructor Instructor;

    //public string PrintDetails()
    //{

    //}
}
class Student
{
    public int StudentId;
    public string Name;
    public int Age;
    public List<Course> Courses=new List<Course>();

    //public Student(int studentId, string name, int age, List<Course> courses)
    //{
    //    this.StudentId = studentId;
    //    this.Name = name;
    //    this.Age = age;
    //    this.Courses = courses;

    //}


    public void PrintDetails()
    {

    }
}
    class StudentManager
    {
        int sID = 1;
        int cID = 1;
        int iID = 1;
        public List<Student> Students = new List<Student>();
        public List<Course> Courses = new List<Course>();
        public List<Instructor> Instructors = new List<Instructor>();
        public bool AddStudent()
        {
            Student student = new Student();
            student.StudentId = sID++;
            Console.Write("Please enter student name : ");
            student.Name = Console.ReadLine();
            Console.Write("Please enter student's age : ");
            student.Age = Convert.ToInt32(Console.ReadLine());
            Students.Add(student);
            return true;
        }
        public bool AddCourse()
        {
            Course course = new Course();
            course.CourseId = cID++;
            Console.Write("Please enter course name : ");
            course.Title = Console.ReadLine();
            Courses.Add(course);
            return true;
        }
        public void ShowAllCourses()
        {
            Console.WriteLine("-------------List of all courses-------------");
            if (Courses.Count == 0) 
            {
                Console.WriteLine("There is no courses");
            }
            else 
            {
                for (int i = 0; i < Courses.Count; i++)
                {
                    Console.WriteLine($"CourseId : {Courses[i].CourseId} course title : {Courses[i].Title}");
                    Console.WriteLine("-----------------------------");
                }
            }     
        }
    public void FindCourse(int courseID)
    {
        Course course = getCourse(courseID);
        if (course != null) {
            Console.WriteLine($"Course Id : {course.CourseId} ");
            Console.WriteLine($"Title : {course.Title} ");
        }
    }
        public Course getCourse(int courseID)
        {
        Course course = new();
            for (int i = 0; i < this.Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseID) course = this.Courses[i];
        }
        return course;
    }
        public bool AddInstructor()
        {
            Instructor instructor = new Instructor();
            instructor.InstructorId = iID++;
            Console.Write("Please enter student name : ");
            instructor.Name = Console.ReadLine();
            Console.Write("Please enter student's age : ");
            instructor.Specialization = Console.ReadLine();
            Instructors.Add(instructor);
            return true;
        }
    public void ShowAllStudents()
        {
            for (int i = 0; i < Students.Count; i++)
            {
                    Console.WriteLine($"Student Id :{Students[i].StudentId}");
                    Console.WriteLine($"Student Id :{Students[i].Name}");
                    Console.WriteLine($"Student Id :{Students[i].Age}");
                    Console.WriteLine("--------------------------------");
            }
        }
    public void ShowAllInstructors()
    {
        for (int i = 0; i < Instructors.Count; i++)
        {
            Console.WriteLine($"Student Id :{Instructors[i].InstructorId}");
            Console.WriteLine($"Student Id :{Instructors[i].Name}");
            Console.WriteLine($"Student Id :{Instructors[i].Specialization}");
            Console.WriteLine("--------------------------------");
        }
    }
    public void FindStudent(int studentId)
        {
            for (int i = 0; i < this.Students.Count; i++)
            {
                if (Students[i].StudentId == studentId)
                {
                    Console.WriteLine($"Found ");
                }
            }
        }
        public bool Enroll()
        {
            Console.Write("Please choose the student id: ");
            int student_ID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please choose the course id: ");
            int selectedCourse = Convert.ToInt32(Console.ReadLine());
           Course course = getCourse(selectedCourse);

            for (int i = 0; i < Students.Count; i++)
            {
                if (student_ID == Students[i].StudentId)
                {
                    Students[i].Courses.Add(course);
                   
                }
            }
        return true;
    }
        //Course FindCourse(int courseId)
        //{

        //}
        //Instructor FindInstructor(int instructorId)
        //{

        //}
        //bool EnrollStudentInCourse(int studentId, int courseId)
        //{
        //    return true;
        //}
    }
    internal class Program
    {
        public static void Main()
        {
            StudentManager studentManager = new();

            string selection;
            int iID = 1;
            int cID = 1;
            do
            {
                Console.WriteLine("-----Welcome to Student Management System------");

                Console.WriteLine("1.Add Student");
                Console.WriteLine("2.Add Instructor");
                Console.WriteLine("3.Add Course");
                Console.WriteLine("4.Enroll Student in Course");
                Console.WriteLine("5.Show All Students");
                Console.WriteLine("6.Show All Courses");
                Console.WriteLine("7.Show All Instructors");
                Console.WriteLine("8.Find the student by id or name");
                Console.WriteLine("9.Fine the course by id or name");
                Console.WriteLine("10.Exit");

                Console.Write("Please enter the number of your selection : ");
                selection = Console.ReadLine();

                if (selection == "1") //Add Student
                {
                    studentManager.AddStudent();
                }
                else if (selection == "2") //Add Instructor
                {
                    bool isAdded = studentManager.AddInstructor();
                    if (isAdded)
                    {
                        Console.WriteLine("Instructor added successfully");
                    }
                    else
                    {
                        Console.WriteLine("You entered invalid details");
                    }
                    
                }
                else if (selection == "3") //Add Course
                {
                    studentManager.AddCourse();
                }
                else if (selection == "4") //Enroll Student in Course
                {
                    studentManager.Enroll();
                }
                else if (selection == "5") //Show All Students
                {
                    studentManager.ShowAllStudents();
                }
                else if (selection == "6") //Show All Courses
                {
                    studentManager.ShowAllCourses();
                }
                else if (selection == "7") //Show All Instructors
                {
                    studentManager.ShowAllInstructors();
                }
                else if (selection == "8") //Find the student by id or name
                {
                    int id;
                    Console.Write("Please enter student id  : ");
                    id = Convert.ToInt32(Console.ReadLine());

                    studentManager.FindStudent(id);
                }
                else if (selection == "9") //Fine the course by id or name
                {
                Console.WriteLine("Please enter course id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                studentManager.FindCourse(id);
            }

            } while (selection != "10");

        }
    }
