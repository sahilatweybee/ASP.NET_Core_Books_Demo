using ASPNET_Core_Books_Demo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPNET_Core_Books_Demo.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}