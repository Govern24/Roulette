using Roulette.Models;

namespace Roulette.DataTransferObjects
{
    /// <summary>
    /// Receives a bet data in a request
    /// </summary>
    public class BetRequest
    {
        public int UserId { get; init; }
        public BetType Type { get; init; }
        public decimal Amount { get; init; }
    }
}
