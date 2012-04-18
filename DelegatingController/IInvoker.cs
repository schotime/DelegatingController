namespace DelegatingController
{
    public interface IInvoker
    {
        TOutput Execute <TInput, TOutput>(TInput inputmodel);
        TOutput Execute<TOutput>();
        void Execute<TInput>(TInput command);
    }
}