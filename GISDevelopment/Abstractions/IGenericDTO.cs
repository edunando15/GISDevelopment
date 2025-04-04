namespace GISDevelopment.Abstractions;

public interface IGenericDTO<T>
{
    T ToEntity();
}