using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name) : base(name) // this makes standardgradebook execute basegradebook constructor before executing its own
        {
            Type = GradeBookType.Standard;
        }
    }
}
