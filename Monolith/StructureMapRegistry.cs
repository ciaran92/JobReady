using Monolith.Core.Services.Course;
using Monolith.Domain.Interfaces;
using StructureMap;
using StructureMap.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolith
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            For<ICourseService>().LifecycleIs(Lifecycles.Container).Use<CourseService>();
        }


        
    }
}
