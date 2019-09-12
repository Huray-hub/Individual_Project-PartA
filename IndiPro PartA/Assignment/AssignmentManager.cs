using System;

namespace IndiPro_PartA
{
    public class AssignmentManager
    {
        public static void AddAssignment()
        {
            Console.Clear();
            int id = Assignment.AssignmentList.Count + 1;
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Submission Date: ");
            bool result = DateTime.TryParse(Console.ReadLine(), out DateTime subDateTime);
            while (!result || subDateTime < DateTime.Now || subDateTime.DayOfWeek == DayOfWeek.Saturday || subDateTime.DayOfWeek == DayOfWeek.Sunday )
            {
                Console.Write("Wrong input!\nSubmission Date has to be set as YYYY/MM/DD, can't be in the past and has to be set between Monday and Friday \nSubmission Date: ");
                result = DateTime.TryParse(Console.ReadLine(), out subDateTime);
            }
            Console.WriteLine("Oral Mark: ");
            result = double.TryParse(Console.ReadLine(), out double oralMark);
            while (!result || oralMark < 0 || oralMark > 101)
            {
                Console.Write("Wrong input!\nOral Mark must be from 1 to 100: \nOral Mark:");
                result = double.TryParse(Console.ReadLine(), out oralMark);
            }            
            Console.WriteLine("Total Mark: ");
            result = double.TryParse(Console.ReadLine(), out double totalMark);
            while (!result || totalMark < 0 || totalMark > 101)
            {
                Console.Write("Wrong input!\nTotal Mark must be from 1 to 100: \nTotal Mark:");
                result = double.TryParse(Console.ReadLine(), out totalMark);
            }            
            Console.WriteLine("");

            Assignment.AssignmentList.Add(new Assignment(id, title, description, subDateTime, oralMark, totalMark));
            Console.Clear();
        }

        public static void AddAssignmentToCourse(int id, int AssignmentID)
        {
            Console.Clear();
            Course.CoursesList[id].AssignmentsInThisCourse.Add(Assignment.AssignmentList[AssignmentID]);
        }

        public static void AddAssignmentToStudent(int id, int StudentID, int AssignmentID)
        {
            Console.Clear();
            Course.CoursesList[id].StudentsInThisCourse[StudentID].AssignmentsToThisStudent.Add(Course.CoursesList[id].AssignmentsInThisCourse[AssignmentID]);
        }
    }
}
