using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Services;

public class UserLineService: IGenericService<UserLine, UserLineDTO>
{
    public UserLineService(DbContext context) : base(context) { }
}