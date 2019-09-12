using System;
using System.Collections.Generic;

namespace IndiPro_PartA
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubDateTime { get; set; }
        public double OralMark { get; set; }
        public double TotalMark { get; set; }

        public Assignment(int id, string title, string description, DateTime subDateTime, double oralMark, double totalMark)
        {
            Id = id;
            Title = title;
            Description = description;
            SubDateTime = subDateTime;
            OralMark = oralMark;
            TotalMark = totalMark;
        }

        public static List<Assignment> AssignmentList = new List<Assignment>();

        public override string ToString()
        {
            return $"Title: {Title}\n   Desciption: {Description}\n   Submission Date and Time: {SubDateTime}\n   Oral Mark: {OralMark}\n   Total Mark: {TotalMark}\n";
        }

    }
}
