using System;

namespace Roulette.Models
{
    /// <summary>
    /// Bet model to represent a bet made by a user
    /// </summary>
    public class Bet
    {
        public int BetId { get; set; }
        public int UserId { get; set; }
        public BetType Type { get; set; }
        public decimal Amount { get; set; }
        public bool Processed { get; set; }
        public DateTime CreatedAt { get; set; } 

    }
    public enum BetType
    {
        Red,
        Black,
        Even,
        Odd,
        First12,  
        Second12, 
        Third12,  
        Number,  
                  
    }
}
