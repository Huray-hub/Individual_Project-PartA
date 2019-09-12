using System;

namespace IndiPro_PartA
{
    public class Menu
    {
        public static void MainMenu()
        {
            Console.Write("Before we start: Would you like to run with Synthetic Data for test mode or run normal mode?\n  1) Test Mode 2) Normal Mode ");
            bool result = int.TryParse(Console.ReadLine(), out int choice);
            while (!result || (choice != 1 && choice != 2))
            {
                Console.Write("Wrong input! Please select using number 1 or 2\n 1) Test Mode 2) Normal Mode ");
                result = int.TryParse(Console.ReadLine(), out choice);
            }

            if (choice == 1)  SyntheticData.Generate(); 

            while (true)
            {
                Console.WriteLine("   | School Menu |");
                Console.WriteLine("  1. Add a Student\n  2. See all Students\n  3. Create a Trainer\n  4. See all Trainers ");
                Console.WriteLine("  5. Create an Assignment\n  6. See all Assignments\n  7. Create a Course\n  8. See all Courses");
                Console.WriteLine("  9. Add a student to a Course\n 10. Add a Trainer to a Course");
                Console.WriteLine(" 11. Add an Assignment for a Course\n 12. See all Students,Trainers or Assignments per Course ");
                Console.WriteLine(" 13. See all Assignments per Student\n 14. See student being in 2 or more Courses ");
                Console.WriteLine(" 15. See current student's pending Assignments' submisions for a specific week");
                Console.WriteLine("  0. Exit");

                result = int.TryParse(Console.ReadLine(), out choice);
                while (!result || (choice < 0 && choice > 14))
                {
                    Console.Write("Wrong input! Please select using number 1 or 2\n 1) Test Mode 2) Normal Mode ");
                    result = int.TryParse(Console.ReadLine(), out choice);
                }
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        StudentManager.AddStudent();
                        break;
                    case 2:
                        ShowLists.ShowList(Student.StudentsList, "Students"); 
                        break;
                    case 3:
                        TrainerManager.AddTrainer();
                        break;
                    case 4:
                        ShowLists.ShowList(Trainer.TrainersList, "Trainers");
                        break;
                    case 5:
                        AssignmentManager.AddAssignment();
                        break;
                    case 6:
                        ShowLists.ShowList(Assignment.AssignmentList, "Assignments");
                        break;
                    case 7:
                        CourseManager.AddCourse();
                        break;
                    case 8:
                        ShowLists.ShowList(Course.CoursesList, "Courses");
                        break;
                    case 9:
                        ShowLists.AddFromListsToCourses(Student.StudentsList, "Students", "student");
                        break;
                    case 10:
                        ShowLists.AddFromListsToCourses(Trainer.TrainersList, "Trainers", "trainer");
                        break;
                    case 11:
                        ShowLists.AddFromListsToCourses(Assignment.AssignmentList, "Assignments", "assignment");
                        break;
                    case 12:
                        ShowLists.ShowListInCourse(); 
                        break;
                    case 13:
                        ShowLists.ShowAssignmentsPerStudent(); 
                        break;
                    case 14:
                        ShowLists.ShowStudentsListWithTwoCoursesPlus();
                        break;
                    case 15:
                        ShowLists.ShowPendingAssignments();
                        break;
                    case 0:
                        Environment.Exit(0); 
                        break;
                }
            }
        }
    }
}
