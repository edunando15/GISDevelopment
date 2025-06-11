using NetTopologySuite.Geometries;

namespace GISDevelopment.Abstractions;

/// <summary>
/// Interface used to represent a generic DTO.
/// </summary>
/// <typeparam name="T"> The real entity. </typeparam>
/// <typeparam name="TDTO"> The DTO entity. </typeparam>
public interface IGenericDTO<T, TDTO>
    where T : class
    where TDTO : IGenericDTO<T, TDTO>
{
    /// <summary>
    /// Virtual property representing the geometry of the entity.
    /// In Java, it would be equal to defining 2 methods getGeometry() and setGeometry(Geometry geometry).
    /// </summary>
    Geometry Geometry
    {
        get;
        set;
    }
    
    Dictionary<string, string>? Tags
    {
        get;
        set;
    }

    /// <summary>
    /// Virtual property representing the id of the entity.
    /// </summary>
    long? Id
    {
        get;
        set;
    }
    
    /// <summary>
    /// Virtual property representing the name of the entity.
    /// </summary>
    string? Name
    {
        get;
        set;
    }
    T ToEntity();
    
    static abstract TDTO FromEntity(T entity);
}