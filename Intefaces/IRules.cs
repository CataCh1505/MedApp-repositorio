using MedApp_Api.DatabaseModels;
using MedApp_Api.Models;

namespace MedApp_Api.Intefaces;

public interface IRules
{
    public Task<ResponseModel> GetAllRules();
    public Task<ResponseModel> GetRuleById(string ruleId);
    public Task<ResponseModel> CreateRule(Rule rule);
    public Task<ResponseModel> UpdateRule(Rule rule);
    public Task<ResponseModel> DeleteRule(string ruleId);
}
