using DI.Console.Interface;
using DI.Console.Services;
using Ninject.Modules;

namespace DI.Console.NInject
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            // Bind (Declares a binding for the specified service)

            // Here We are Binding services to Inject
            // In this we will inject DL using Interface IBook
            Bind<IBookService>().To<BookService>();
        }
    }
}
