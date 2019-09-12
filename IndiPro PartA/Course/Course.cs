using System;
using System.Collections.Generic;

namespace IndiPro_PartA
{
    public enum Stream { Java=1, Csharp }

    public enum Type { PartTime=1, FullTime }

    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Stream Stream { get; set; }
        public Type Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Course(int id, string title, Stream stream, Type type, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }
       
        public static List<Course> CoursesList = new List<Course>();

        public List<Student> StudentsInThisCourse = new List<Student>();
        public List<Trainer> TrainersInThisCourse = new List<Trainer>();
        public List<Assignment> AssignmentsInThisCourse = new List<Assignment>();

        public override string ToString()
        {
            return $"Title: {Title}\n   Stream: {Stream}\n   Type: {Type}\n   Starting Date: {StartDate.ToShortDateString()}\n   Ending Date: {EndDate.ToShortDateString()}\n";
        }
    }
}
