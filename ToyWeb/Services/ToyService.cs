using System;
using System.Linq;
using ToyData.Data;
using ToyData.Models;
using ToyData.Repositories;
using ToyWeb.Models;

namespace ToyWeb.Services
{
    public interface IToyService
    {
        public PagedResult<Toy> GetToyPage(int currentPage);
    }

    public class ToyService : GenericService, IToyService
    {
        private IToyRepository toyRepository;
        public ToyService(IToyRepository toyRepository, ToyUniverseContext context)
        {
            this.toyRepository = toyRepository;
        }
        public PagedResult<Toy> GetToyPage(int currentPage)
        {
            return GetPaged<Toy>(toyRepository.Context.Toys, currentPage, 7);
        }
    }
}
