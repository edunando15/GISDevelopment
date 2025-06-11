namespace GISDevelopment.Abstractions;

public interface IHasTags
{
    public Dictionary<string, string>? Tags { get; set; }
}