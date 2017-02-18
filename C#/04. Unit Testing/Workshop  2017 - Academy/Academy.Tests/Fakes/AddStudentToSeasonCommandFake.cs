using Academy.Commands.Adding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Core.Contracts;

namespace Academy.Tests.Fakes
{
    internal class AddStudentToSeasonCommandFake : AddStudentToSeasonCommand
    {
        public AddStudentToSeasonCommandFake(IAcademyFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public IAcademyFactory ExposeFactoty
        {
            get
            {
                return this.factory;
            }
        }


        public IEngine ExposeEngine
        {
            get
            {
                return this.engine;
            }
        }
    }
}
