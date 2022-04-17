namespace VuelingPractica.Application.Services.Contracts
{
    public interface IAdd<T>
    {
        T Add(T entity);
    }
}
