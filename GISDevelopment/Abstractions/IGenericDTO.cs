namespace GISDevelopment.Abstractions;

/// <summary>
/// Interface used to represent a generic DTO.
/// </summary>
/// <typeparam name="T"> The real entity. </typeparam>
/// <typeparam name="TDTO"> The DTO entity. </typeparam>
public interface IGenericDTO<T, TDTO>
    where TDTO : IGenericDTO<T, TDTO>
{
    T ToEntity();
    
    static abstract TDTO FromEntity(T entity);
}