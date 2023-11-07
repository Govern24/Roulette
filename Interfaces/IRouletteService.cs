using Roulette.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roulette.Interfaces
{
    public interface IRouletteService
    {
        Task PlaceBetAsync(BetRequest bet);
        Task<SpinResult> SpinAsync();
        Task ProcessPayoutsAsync();
        Task<List<SpinResult>> GetPreviousSpinsAsync();
    }
}
