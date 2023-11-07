using Microsoft.EntityFrameworkCore;
using Roulette.Configuration;
using Roulette.DataTransferObjects;
using Roulette.Interfaces;
using Roulette.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.Services
{
    public class RouletteService : IRouletteService
    {
        private readonly RouletteDbContext _dbContext;

        public RouletteService(RouletteDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<SpinResult>> GetPreviousSpinsAsync()
        {

            var latestSpin = _dbContext.Spins.OrderByDescending(s => s.SpinTime).FirstOrDefault();
            var unprocessedBets = await _dbContext.Bets.Where(bet => !bet.Processed).ToListAsync();

            var latestSpinResult = new SpinResult
            {
                Result = latestSpin.Result,
                SpinTime = latestSpin.SpinTime
              
            };

            List<SpinResult> spinResults = new List<SpinResult>();

            foreach (var bet in unprocessedBets)
            {
                // Calculate and update user balances based on the bet type and the spin result.

                bool isWinner = IsBetWinner(bet, latestSpinResult);
                if (isWinner)
                {
                    // Update the user's balance based on the payout.
                    UpdateUserBalance(bet.UserId, CalculatePayout(bet, latestSpinResult));
                }

                // Mark the bet as processed.
                bet.Processed = true;

                spinResults.Add(latestSpinResult);
            }

            await _dbContext.SaveChangesAsync();
            return spinResults;
        }

        public async Task PlaceBetAsync(BetRequest bet)
        {
            var _bet = new Bet
            {
                UserId = bet.UserId,
                Type = bet.Type,
                Amount = bet.Amount
            };

            _dbContext.Bets.Add(_bet);
            await _dbContext.SaveChangesAsync();
        }

        public Task ProcessPayoutsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<SpinResult> SpinAsync()
        {         
            int winningNumber = new Random().Next(0, 37);

            var spinResult = new SpinResult
            {
                Result = winningNumber.ToString(),
                SpinTime = DateTime.UtcNow
            };

            var spin = new Spin
            {
                Result = spinResult.Result,
                SpinTime = spinResult.SpinTime,

            };

            _dbContext.Spins.Add(spin);
            await _dbContext.SaveChangesAsync();
            return spinResult;
        }

        private bool IsBetWinner(Bet bet, SpinResult spinResult)
        {
            if (Enum.TryParse<BetType>(spinResult.Result, out var spinResultType))
            {
                if (bet.Type == spinResultType)
                {
                    return true; // The bet is a winner if it matches the winning outcome.
                }
            }

            return false;
        }


        private decimal CalculatePayout(Bet bet, SpinResult latestSpinResult)
        {
          
            if (bet.Processed)
            {
                return 0; // The bet has already been processed, no payout.
            }

            if (IsBetWinner(bet, latestSpinResult))
            {
                return bet.Amount * 2; // Payout is double the bet amount for a winning bet.
            }

            return 0; // No payout for losing bets.
        }


        private void UpdateUserBalance(int userId, decimal payout)
        {
           
                var user = _dbContext.Users.SingleOrDefault(u => u.UserId == userId);

                if (user != null)
                {
                    user.Balance += payout; // Update the user's balance by adding the payout.

              
                _dbContext.SaveChanges();
                }
               
            
        }

    }
}
