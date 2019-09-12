using System;

namespace IndiPro_PartA
{
    public class StudentManager
    {
        public static void AddStudent()
        {
            Console.Clear();
            int id = Student.StudentsList.Count + 1;
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Date of birth: ");
            bool result = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth);
            while (!result || dateOfBirth > DateTime.Now)
            {
                Console.Write("Wrong input!\nDate of birth has to be set as YYYY/MM/DD and can't be a future date \nDate of Birth: ");
                result = DateTime.TryParse(Console.ReadLine(), out dateOfBirth);
            }
            Console.Write("Tuition Fees: ");
            result = double.TryParse(Console.ReadLine(), out double tuitionFees);
            while (!result || tuitionFees < 0)
            {
                Console.Write("Wrong input!\n Tuition fees can't be a negative number \nTuition Fees: ");
                result = double.TryParse(Console.ReadLine(), out tuitionFees);
            }

            Student.StudentsList.Add(new Student(id, firstName, lastName, dateOfBirth, tuitionFees));

            Console.WriteLine("");
            Console.Clear();
        }

        public static void AddStudentToCourse(int courseID, int studentID)
        {
            Console.Clear();
            Course.CoursesList[courseID].StudentsInThisCourse.Add(Student.StudentsList[studentID]);
            Student.StudentsList[studentID].CoursesToThisStudent.Add(Course.CoursesList[courseID]);
        }         
    }
}
