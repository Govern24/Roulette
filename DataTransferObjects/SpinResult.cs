using System;

namespace Roulette.DataTransferObjects
{
    /// <summary>
    /// Returns the outcome of a spin in a  http response
    /// </summary>
    public record SpinResult
    {
        public string Result { get; init; }
        public DateTime SpinTime { get; init; }
    }
}
