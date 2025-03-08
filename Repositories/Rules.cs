using MedApp_Api.DatabaseModels;
using MedApp_Api.Intefaces;
using MedApp_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedApp_Api.Repositories;

public class Rules : IRules
{
    private readonly DatabaseContext context;

    public Rules(DatabaseContext _context) => context = _context;

    public Task<ResponseModel> CreateRule(Rule rule)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel> DeleteRule(string ruleId)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseModel> GetAllRules()
    {
        try
        {
            var rules = await context.Rules.ToArrayAsync();
            return new()
            {
                Success = true,
                Message = "Rules retrieved successfully",
                Data = rules
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                Success = false,
                Handled = false,
                Message = ex.Message
            };
        }
    }

    public Task<ResponseModel> GetRuleById(string ruleId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel> UpdateRule(Rule rule)
    {
        throw new NotImplementedException();
    }
}
