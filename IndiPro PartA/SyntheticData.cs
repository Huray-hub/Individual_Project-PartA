using System;

namespace IndiPro_PartA
{
    public static class SyntheticData
    {
        public static void Generate()
        {
            Student.StudentsList.Add(new Student(1, "Panos", "Skiadas", new DateTime(196, 09, 12), 2500));
            Student.StudentsList.Add(new Student(2, "Michalis", "Skiadas", new DateTime(1998, 01, 08), 2400));
            Student.StudentsList.Add(new Student(3, "Helen", "Skiada", new DateTime(1994, 04, 16), 2000));
            Student.StudentsList.Add(new Student(4, "Apostolis", "Kapiniaris", new DateTime(2006, 06, 06), 2200));
            Student.StudentsList.Add(new Student(5, "Ifigeneia", "Adamaki", new DateTime(1977, 05, 16), 2500));
            Student.StudentsList.Add(new Student(6, "Antonia", "Mathioudaki", new DateTime(1996, 10, 16), 2300));
            Student.StudentsList.Add(new Student(7, "Konstaninos", "Tsiggenopoulos", new DateTime(1996, 01, 22), 2500));
            Student.StudentsList.Add(new Student(8, "Stelios", "Theofanidis", new DateTime(1996, 11, 09), 2500));

            Trainer.TrainersList.Add(new Trainer(1, "KwaiGon", "Jin", "How to be komparsos in your own movie"));
            Trainer.TrainersList.Add(new Trainer(2, "Anakin", "Skywalker", "Path to the Dark Side"));
            Trainer.TrainersList.Add(new Trainer(3, "Luke", "Skywalker", "How to react when you discover who is your real father"));
            Trainer.TrainersList.Add(new Trainer(4, "Darth", "Maul", "How to cut yourself in half"));
            Trainer.TrainersList.Add(new Trainer(5, "Kylo", "Ren", "How to wear a mask for no reason"));
            Trainer.TrainersList.Add(new Trainer(6, "Leia", "Organa", "How to be a princess"));
            Trainer.TrainersList.Add(new Trainer(7, "Han", "Solo", "Smuggling technique"));
            Trainer.TrainersList.Add(new Trainer(8, "JarJar", "Bings", "Grahgraghgrah"));

            Course.CoursesList.Add(new Course(1, "Speak Chewbakish now", Stream.Csharp, Type.FullTime, new DateTime(2019, 09, 13), new DateTime(2019, 11, 13)));
            Course.CoursesList.Add(new Course(2, "Escape with hyperspeed", Stream.Java, Type.PartTime, new DateTime(2020, 01, 12), new DateTime(2020, 2, 13)));
            Course.CoursesList.Add(new Course(3, "Lightsaber choreography", Stream.Csharp, Type.PartTime, new DateTime(2019, 08, 20), new DateTime(2019, 10, 07)));
            Course.CoursesList.Add(new Course(4, "Force basics", Stream.Java, Type.FullTime, new DateTime(2019, 12, 01), new DateTime(2020, 01, 09)));
            Course.CoursesList.Add(new Course(5, "Bring balance to the force today", Stream.Csharp, Type.FullTime, new DateTime(2019, 09, 02), new DateTime(2019, 11, 03)));
            Course.CoursesList.Add(new Course(6, "Psychic connection", Stream.Java, Type.PartTime, new DateTime(2019, 09, 02), new DateTime(2019, 11, 03)));
            Course.CoursesList.Add(new Course(7, "Laugh like Palpatine", Stream.Csharp, Type.PartTime, new DateTime(2019, 09, 02), new DateTime(2019, 11, 03)));
            Course.CoursesList.Add(new Course(8, "Even more Aerial Yoga", Stream.Java, Type.FullTime, new DateTime(2019, 09, 02), new DateTime(2019, 11, 03)));

            Assignment.AssignmentList.Add(new Assignment(1, "Phantom Menace", "Years ago, in a galaxy far far away...", new DateTime(2019, 10, 11), 100, 100));
            Assignment.AssignmentList.Add(new Assignment(2, "Attack of the Clones", "Episode II", new DateTime(2020, 01, 21), 100, 100));
            Assignment.AssignmentList.Add(new Assignment(3, "Revenge of the Sith", "Episode III", new DateTime(2019, 10, 08), 100, 100));
            Assignment.AssignmentList.Add(new Assignment(4, "A New Hope", "Episode IV", new DateTime(2020, 01, 03), 100, 100));
            Assignment.AssignmentList.Add(new Assignment(5, "Empire Strikes Back", "Episode V", new DateTime(2019, 10, 14), 100, 100));
            Assignment.AssignmentList.Add(new Assignment(6, "The Return of The Jedi", "Episode VI", new DateTime(2019, 10, 15), 100, 100));
            Assignment.AssignmentList.Add(new Assignment(7, "The Force Awakens", "Episode VII", new DateTime(2019, 10, 16), 100, 100));
            Assignment.AssignmentList.Add(new Assignment(8, "The Last Jedi", "Episode VIII", new DateTime(2019, 10, 17), 100, 100));
          
            for (int i = 0; i < Course.CoursesList.Count; i++)
            {
                for (int j = 0; j < Student.StudentsList.Count-1; j++)
                {
                    if (i < 4)
                    {
                        StudentManager.AddStudentToCourse(i, j);
                        CourseManager.AddCourseToStudent(j, i);
                    }
                    else if (i >= 4 && i <= 6 && j > 4)
                    {
                        StudentManager.AddStudentToCourse(i, j);
                        CourseManager.AddCourseToStudent(j, i);
                    }
                }
            }

            for (int i = 0; i < Course.CoursesList.Count; i++)
                Course.CoursesList[i].TrainersInThisCourse.Add(Trainer.TrainersList[i]);
            
            Course.CoursesList[0].TrainersInThisCourse.Add(Trainer.TrainersList[1]);

            for (int i = 0; i < Course.CoursesList.Count; i++)           
                AssignmentManager.AddAssignmentToCourse(i, i);
            
            for (int i = 0; i < Course.CoursesList.Count; i++)
            {
                for (int j = 0; j < Course.CoursesList[i].StudentsInThisCourse.Count; j++)
                {
                    for (int l = 0; l < Course.CoursesList[i].AssignmentsInThisCourse.Count; l++)
                        AssignmentManager.AddAssignmentToStudent(i, j, l);                   
                }
            }          
        }
    }
}
