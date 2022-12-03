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

            int dropLetter = (int)Math.Ceiling(grades.Count * .2);

            if (averageGrade >= grades[grades.Count - dropLetter])
                return 'A';
            else if (averageGrade >= grades[grades.Count - (dropLetter * 2)])
                return 'B';
            else if (averageGrade >= grades[grades.Count - (dropLetter * 3)])
                return 'C';
            else if (averageGrade >= grades[grades.Count - (dropLetter * 4)])
                return 'D';
            else
                return 'F';
        }
    }
}
