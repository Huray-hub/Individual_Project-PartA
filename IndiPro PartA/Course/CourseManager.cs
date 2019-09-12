using System;

namespace IndiPro_PartA
{
    public class CourseManager
    {
        public static void AddCourse()
        {
            Console.Clear();
            int id = Course.CoursesList.Count + 1;
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Stream: 1) Java 2) C#: ");
            bool result = int.TryParse(Console.ReadLine(), out int x);
            while (!result || (x != 1 && x != 2))
            {
                Console.Write("Wrong input! Please select using number 1 or 2\nStream: 1) Java 2) C#: ");
                result = int.TryParse(Console.ReadLine(), out x);
            }
            Stream stream = (Stream)x;
            Console.WriteLine("Type: 1) Part Time: 2) Full Time ");
            result = int.TryParse(Console.ReadLine(), out x);
            while (!result || (x != 1 && x != 2))
            {
                Console.WriteLine("Wrong input! Please select using number 1 or 2\nType: 1) Part Time 2) Full Time: ");
                result = int.TryParse(Console.ReadLine(), out x);
            }
            Type type = (Type)x;
            Console.Write("Starting Date: ");
            result = DateTime.TryParse(Console.ReadLine(), out DateTime startDate);
            while (!result || startDate < DateTime.Now)
            {
                Console.Write("Wrong input!\nStarting date has to be set as YYYY/MM/DD and cant be a past date\nStarting Date: ");
                result = DateTime.TryParse(Console.ReadLine(), out startDate);
            }
            Console.Write("Ending Date: ");
            result = DateTime.TryParse(Console.ReadLine(), out DateTime endDate);
            while (!result || endDate < startDate)
            {
                Console.Write("Wrong input!\nEnding date has to be set as YYYY/MM/DD and cant be earlier date than Starting date\nEnding Date: ");
                result = DateTime.TryParse(Console.ReadLine(), out endDate);
            }

            Console.WriteLine("");

            Course.CoursesList.Add(new Course(id, title, stream, type, startDate, endDate));

            Console.Clear();
        }
        
        public static void AddCourseToStudent(int studentID, int courseID)
        {
            StudentManager.AddStudentToCourse(courseID, studentID);
        }
    }
}
