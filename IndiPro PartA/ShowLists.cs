using System;
using System.Collections.Generic;

namespace IndiPro_PartA
{
    public class ShowLists
    {
        public static void ShowList<T>(List<T> list, string description)
        {
            Console.Clear();
            int listCounter = 0;
            Console.WriteLine($"   | {description} |");
            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"{listCounter + 1}. {item}");
                    listCounter++;
                }
            }
            else
            {
                Console.WriteLine($"There are no {description.ToLower()} yet\n");
            }
        }

        public static void ShowListInCourse()
        {
            Console.Clear();
            if (Course.CoursesList.Count != 0)
            {
                Console.WriteLine("Please select a course by using its number on the list: \n");
                ShowList(Course.CoursesList, "Courses");

                bool result = int.TryParse(Console.ReadLine(), out int courseID);
                while (!result || (courseID < 1 || courseID > Course.CoursesList.Count))
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {Course.CoursesList.Count} ");
                    result = int.TryParse(Console.ReadLine(), out courseID);
                }
                Console.Clear();

                Console.WriteLine($"What would you like to see about Course: {Course.CoursesList[courseID].Title}?\n 1) Students\n 2) Trainers\n 3) Assignments");
                result = int.TryParse(Console.ReadLine(), out int courselist);
                while (!result || (courselist < 1 || courselist > 3))
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to 3");
                    result = int.TryParse(Console.ReadLine(), out courseID);
                }
                Console.Clear();

                switch (courselist)
                {
                    case 1:
                        ShowList(Course.CoursesList[courseID - 1].StudentsInThisCourse, $"Students enrolled to Course: {Course.CoursesList[courseID - 1].Title}");
                        break;
                    case 2:
                        ShowList(Course.CoursesList[courseID - 1].TrainersInThisCourse, $"Trainers added to Course: {Course.CoursesList[courseID - 1].Title}");
                        break;
                    case 3:
                        ShowList(Course.CoursesList[courseID - 1].AssignmentsInThisCourse, $"Assignments added to Course: {Course.CoursesList[courseID - 1].Title}");
                        break;
                }
            }
        }

        public static void AddFromListsToCourses<T>(List<T> list, string description, string desc)
        {
            Console.Clear();
            if (Course.CoursesList.Count != 0 && list.Count != 0)
            {
                Console.WriteLine("Please select a course by using its number on the list: \n");
                ShowList(Course.CoursesList, "Courses");

                bool result = int.TryParse(Console.ReadLine(), out int courseID);
                while (!result || (courseID < 1 || courseID > Course.CoursesList.Count))
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {Course.CoursesList.Count} ");
                    result = int.TryParse(Console.ReadLine(), out courseID);
                }

                Console.Clear();
                Console.WriteLine($"Good! Now select a {desc} to add in Course: {Course.CoursesList[courseID - 1].Title}\n");
                ShowList(list, description);

                result = int.TryParse(Console.ReadLine(), out int ID);
                if (desc == "student")
                {
                    while (!result || ID < 1 || ID > list.Count || Course.CoursesList[courseID - 1].StudentsInThisCourse.Contains(Student.StudentsList[ID - 1]))
                    {
                        Console.Write($"Wrong input! Please select using numbers from 1 to {list.Count}\n  NOTE: You can't add a {desc} twice ");
                        result = int.TryParse(Console.ReadLine(), out ID);
                    }
                    StudentManager.AddStudentToCourse(courseID - 1, ID - 1);
                }
                else if (desc == "assignment")
                {
                    while (!result || ID < 1 || ID > list.Count || Course.CoursesList[courseID - 1].TrainersInThisCourse.Contains(Trainer.TrainersList[ID - 1]))
                    {
                        Console.Write($"Wrong input! Please select using numbers from 1 to {list.Count}\n  NOTE: You can't add a {desc} twice ");
                        result = int.TryParse(Console.ReadLine(), out ID);                        
                    }
                    AssignmentManager.AddAssignmentToCourse(courseID - 1, ID - 1); 
                }
                else
                {
                    while (!result || ID < 1 || ID > list.Count || Course.CoursesList[courseID - 1].AssignmentsInThisCourse.Contains(Assignment.AssignmentList[ID - 1]))
                    {
                        Console.Write($"Wrong input! Please select using numbers from 1 to {list.Count}\n  NOTE: You can't add a {desc} twice ");
                        result = int.TryParse(Console.ReadLine(), out ID);                       
                    }
                    TrainerManager.AddTrainerToCourse(courseID - 1, ID - 1);
                }

                Console.WriteLine($"You have successfully added a {desc} to Course: {Course.CoursesList[courseID - 1].Title}");
            }
            else            
                Console.WriteLine($"There are neither {description} nor Courses yet");
            
        }

        public static void ShowAssignmentsPerStudent()
        {
            Console.Clear();
            if (Student.StudentsList.Count != 0 && Assignment.AssignmentList.Count != 0)
            {
                Console.WriteLine($"Please select a Student to get an Assignment: \n");
                ShowList(Student.StudentsList, "Students");

                bool result = int.TryParse(Console.ReadLine(), out int studentID);
                while (!result || studentID < 1 || studentID > Student.StudentsList.Count)
                {
                    Console.Write($"Wrong input! Please select using numbers from 1 to {Student.StudentsList.Count}\n");
                    result = int.TryParse(Console.ReadLine(), out studentID);
                }
                ShowList(Student.StudentsList[studentID].AssignmentsToThisStudent, "Assignments");               
            }
            else Console.WriteLine($"There are neither Students nor Assignments yet");           
        }

        public static void ShowStudentsListWithTwoCoursesPlus()
        {
            Console.Clear();            
            Console.WriteLine($"   | Students belonging to more than one Courses |");
            if (Student.StudentsList.Count != 0 && Course.CoursesList.Count !=0)
            {
                for (int j = 0; j < Course.CoursesList.Count; j++)
                {
                    if (Course.CoursesList[j].StudentsInThisCourse.Count >= 2)
                    {
                        Console.WriteLine($"{j + 1}. {Student.StudentsList[j]}");                        
                    }                    
                }
            }
            else Console.WriteLine($"There are no Students or Courses yet\n");            
        }

        public static void ShowPendingAssignments()
        {
            Console.Write("Date: ");
            bool result = DateTime.TryParse(Console.ReadLine(), out DateTime pendingDate);
            while (!result || pendingDate < DateTime.Now)
            {
                Console.Write("Wrong input!\nSubmission Date has to be set as YYYY/MM/DD and can't be in the past\nDate : ");
                result = DateTime.TryParse(Console.ReadLine(), out pendingDate);
            }
            DateTime monday = pendingDate.AddDays(-(int)pendingDate.DayOfWeek + (int)DayOfWeek.Monday +1);
            DateTime friday = pendingDate.AddDays(-(int)pendingDate.DayOfWeek + (int)DayOfWeek.Friday +1);
            DateTime sunday = pendingDate.AddDays(-(int)pendingDate.DayOfWeek + 7 + 1);
            Console.WriteLine(sunday);
            Console.WriteLine($" Students and their pending Assignments' submissions for Monday {monday.ToShortDateString()} to Friday {friday.ToShortDateString()}:");
            for (int i = 0; i < Student.StudentsList.Count; i++)
            {
                for (int j = 0; j < Student.StudentsList[i].AssignmentsToThisStudent.Count; j++)
                {
                    if (Student.StudentsList[i].AssignmentsToThisStudent[j].SubDateTime.CompareTo(monday) >= 0 && Student.StudentsList[i].AssignmentsToThisStudent[j].SubDateTime.CompareTo(sunday) <=0)                   
                        Console.WriteLine($" {Student.StudentsList[i].FirstName} {Student.StudentsList[i].LastName}: {Student.StudentsList[i].AssignmentsToThisStudent[j].Title} ");                  
                }
            }            
        }
    }
}