using Kamo.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kamo.Demo.Service.Demo
{
    public interface IDemoService : ITransientDependency
    {
        string TestDiMethod();
    }
}
