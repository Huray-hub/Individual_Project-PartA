using System;
using System.Collections.Generic;

namespace IndiPro_PartA
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double TuitionFees { get; set; }

        public Student(int id, string firstName, string lastName, DateTime dateOfBirth, double tuitionFees)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            TuitionFees = tuitionFees;
        }
               
        public static List<Student> StudentsList = new List<Student>();

        public List<Assignment> AssignmentsToThisStudent = new List<Assignment>();
        public List<Course> CoursesToThisStudent = new List<Course>();
        
        public override string ToString()
        {
            return $"First Name: {FirstName}\n   Last Name: {LastName}\n   Date of Birth: {DateOfBirth.ToShortDateString()}\n   Tuition Fees: {TuitionFees}\n";
        }            
    }
}
