using System.Collections.Generic;

namespace IndiPro_PartA
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public Trainer(int id,string firstName, string lastName, string subject)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }

        public static List<Trainer> TrainersList = new List<Trainer>();

        public override string ToString()
        {
            return $"First Name: {FirstName}\n   Last Name: {LastName}\n   Subject: {Subject}\n";
        }
    }
}
