using GradeBook.Enums;
using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires a minimum of 5 students");

            List<double> grades = new List<double>();

            foreach(var student in Students)
                grades.Add(student.AverageGrade);

            grades.Sort();

            if (averageGrade >= grades[grades.Count - ((int)Math.Ceiling(grades.Count * .2))])
                return 'A';
            else if (averageGrade >= grades[grades.Count - ((int)Math.Ceiling(grades.Count * .4))])
                return 'B';
            else if (averageGrade >= grades[grades.Count - ((int)Math.Ceiling(grades.Count * .6))])
                return 'C';
            else if (averageGrade >= grades[grades.Count - ((int)Math.Ceiling(grades.Count * .8))])
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a studnent's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
