namespace DelegatingController
{
    public interface IDelegateToHandlers
    {
        IInvoker Invoker { get; set; }
    }
}