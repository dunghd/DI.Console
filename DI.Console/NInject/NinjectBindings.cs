using DI.Console.DAL;
using DI.Console.Interface;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Console.NInject
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            // Bind (Declares a binding for the specified service)

            // Here We are Binding services to Inject
            // In this we will inject DL using Interface IBook
            Bind<IBook>().To<DL>();
        }
    }
}
