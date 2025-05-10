using GISDevelopment.Abstractions;
using GISDevelopment.Data;
using GISDevelopment.Models.DTOs;

namespace GISDevelopment.Services;

public class MunicipalityService : IMunicipalityService
{
    private readonly DatabaseContext _context;
    
    public MunicipalityService(DatabaseContext context)
    {
        _context = context;
    }
    
    public void AddMunicipality(MunicipalityDTO municipalityDTO)
    {
        var municipality = municipalityDTO.ToEntity();
        _context.Municipalities.Add(municipality);
        Save();
    }

    public void UpdateMunicipality(MunicipalityDTO municipalityDTO)
    {
        var municipality = municipalityDTO.ToEntity();
        _context.Municipalities.Update(municipality);
        Save();
    }

    public bool DeleteMunicipality(int id)
    {
        var municipality = _context.Municipalities.Find(id);
        if (municipality == null) return false;
        _context.Municipalities.Remove(municipality);
        Save();
        return true;
    }

    public MunicipalityDTO? GetMunicipality(int id)
    {
        var municipality = _context.Municipalities.Find(id);
        return municipality == null ? null : new MunicipalityDTO(municipality);
    }

    public List<MunicipalityDTO> GetAllMunicipalities()
    {
        return _context.Municipalities.AsQueryable().Select(m => new MunicipalityDTO(m)).ToList();
    }

    public List<MunicipalityDTO> GetAllMunicipalities(int from, int num, out int totalCount)
    {
        var municipalities = _context.Municipalities.AsQueryable();
        totalCount = municipalities.Count();
        return municipalities.Skip(from).Take(num).Select(m => new MunicipalityDTO(m)).ToList();
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }
}