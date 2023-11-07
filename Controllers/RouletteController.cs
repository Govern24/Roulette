using Microsoft.AspNetCore.Mvc;
using Roulette.DataTransferObjects;
using Roulette.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Roulette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteService _rouletteService;
        public RouletteController(IRouletteService rouletteService)
        {
            _rouletteService = rouletteService;
        }

        [HttpPost("placebet")]
        public async Task<IActionResult> PlaceBet([FromBody] BetRequest bet)
        {
            try
            {
                await _rouletteService.PlaceBetAsync(bet);
                return Ok("Bet placed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to place bet: {ex.Message}");
            }
        }

        [HttpGet("spin")]
        public async Task<IActionResult> Spin()
        {
            try
            {
                SpinResult spinResult = await _rouletteService.SpinAsync();
                return Ok(spinResult);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to spin the roulette wheel: {ex.Message}");
            }
        }

        [HttpPost("payout")]
        public async Task<IActionResult> Payout()
        {
            try
            {
                await _rouletteService.ProcessPayoutsAsync();
                return Ok("Payouts processed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to process payouts: {ex.Message}");
            }
        }

       
        [HttpGet("previousSpins")]
        public async Task<IActionResult> GetPreviousSpins()
        {
            try
            {
                List<SpinResult> previousSpins = await _rouletteService.GetPreviousSpinsAsync();
                return Ok(previousSpins);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to retrieve previous spins: {ex.Message}");
            }
        }

    }
}
