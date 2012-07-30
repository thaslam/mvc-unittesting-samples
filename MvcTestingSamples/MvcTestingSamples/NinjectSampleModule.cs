using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Modules;
using MvcTestingSamples.Repositories;

namespace MvcTestingSamples
{
    public class NinjectSampleModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISampleRepository>().To<SampleRepository>().InTransientScope();
        }
    }
}