using System;

namespace IndiPro_PartA
{
    public class TrainerManager
    {        
        public static void AddTrainer()
        {
            Console.Clear();
            int id = Trainer.TrainersList.Count + 1;
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Subject: ");
            string subject = Console.ReadLine();

            Trainer.TrainersList.Add(new Trainer(id , firstName, lastName, subject));

            Console.WriteLine("");
            Console.Clear();
        }  
        
        public static void AddTrainerToCourse(int id, int trainerID)
        {
            Console.Clear();
            Course.CoursesList[id].TrainersInThisCourse.Add(Trainer.TrainersList[trainerID]);
        }
    }
}
