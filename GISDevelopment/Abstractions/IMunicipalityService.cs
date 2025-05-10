using GISDevelopment.Models.DTOs;

namespace GISDevelopment.Abstractions;

public interface IMunicipalityService
{
    
    /// <summary>
    /// Method used to add a Municipality to the database.
    /// </summary>
    /// <param name="municipality"> The Municipality to add. </param>
    void AddMunicipality(MunicipalityDTO municipalityDTO);
    
    /// <summary>
    /// Method used to update a Municipality in the database.
    /// </summary>
    /// <param name="municipality"> The already modified municipality. </param>
    void UpdateMunicipality(MunicipalityDTO municipalityDTO);
    
    /// <summary>
    /// Method used to delete a Municipality from the database.
    /// </summary>
    /// <param name="id"> The id of the Municipality to delete. </param>
    /// <returns> True if the Municipality was deleted, false otherwise. </returns>
    bool DeleteMunicipality(int id);
    
    /// <summary>
    /// Method used to get a Municipality from the database.
    /// </summary>
    /// <param name="id"> The id of the requested Municipality. </param>
    /// <returns> The requested Municipality if it exists, null otherwise. </returns>
    MunicipalityDTO? GetMunicipality(int id);
    
    /// <summary>
    /// Method used to get all the Municipalities from the database.
    /// </summary>
    /// <returns> A List containing all the Municipalities in the database. </returns>
    List<MunicipalityDTO> GetAllMunicipalities();
    
    /// <summary>
    /// Method used to get all the municipalities from the database,
    /// satisfying the search criteria.
    /// </summary>
    /// <param name="from"> Indicates the starting point of the result. </param>
    /// <param name="num"> Indicates the number of elements in the result. </param>
    /// <param name="totalCount"> Denotes the total count of Municipalities. </param>
    /// <returns> A List containing all the Municipalities satisfying the given criteria. </returns>
    List<MunicipalityDTO> GetAllMunicipalities(int from, int num, out int totalCount);
}