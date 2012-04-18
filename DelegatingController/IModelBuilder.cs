namespace DelegatingController
{
    public interface IModelBuilder<TInput, TOutput>
    {
        TOutput Build(TInput model);
    }

    public interface IModelBuilder<TOutput>
    {
        TOutput Build();
    }
}