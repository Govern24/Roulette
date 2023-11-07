using System;

namespace Roulette.Models
{
    /// <summary>
    /// Spin model to represent the outcome of a roulette spin
    /// </summary>
    public class Spin
    {
        public int SpinId { get; set; }
        public string Result { get; set; }
        public DateTime SpinTime { get; set; }
    }
}
