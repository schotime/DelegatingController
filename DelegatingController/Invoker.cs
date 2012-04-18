using System;

namespace DelegatingController
{
    public class Invoker : IInvoker
    {
        private readonly Func<Type, object> _resolver;

        public Invoker(Func<Type, object> resolver)
        {
            _resolver = resolver;
        }

        public TOutput Execute <TInput, TOutput>(TInput inputmodel)
        {
            var type = typeof(IModelBuilder<,>).MakeGenericType(typeof(TInput), typeof(TOutput));
            var thandler = (IModelBuilder<TInput, TOutput>)_resolver(type);
            var result = thandler.Build(inputmodel);
            return result;
        }

        public TOutput Execute <TOutput>()
        {
            var type = typeof(IModelBuilder<>).MakeGenericType(typeof(TOutput));
            var thandler = (IModelBuilder<TOutput>)_resolver(type);
            var result = thandler.Build();
            return result;
        }

        public void Execute <TInput>(TInput command)
        {
            //Could be made asynchronus
            var type = typeof(IModelCommand<>).MakeGenericType(typeof(TInput));
            var thandler = (IModelCommand<TInput>)_resolver(type);
            thandler.Execute(command);
        }
    }
}