namespace DelegatingController
{
    public interface IModelCommand<TInput>
    {
        void Execute(TInput command);
    }
}