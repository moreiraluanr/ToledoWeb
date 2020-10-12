namespace Toledo.Aplication.UseCase
{
    public interface IUseCase<TRequest>
    {
        void Execute(TRequest request);
    }

    public interface IUseCase<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}
