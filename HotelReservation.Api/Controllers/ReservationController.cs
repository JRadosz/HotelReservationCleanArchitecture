using Cortex.Mediator;
using ErrorOr;
using HotelReservation.Api.DTOs;
using HotelReservation.Application.HotelRooms.Commands.CreateHotelRoom;
using HotelReservation.Application.HotelRooms.Dtos;
using HotelReservation.Application.Reservations.Commands.CreateReservation;
using HotelReservation.Application.Reservations.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IMediator _mediator;

        public ReservationController(ILogger<ReservationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public bool Get()
        {
            return true;
        }

        // POST api/<ReservationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateReservationCommand requestBody)
        {
            var result = await _mediator.SendCommandAsync<CreateReservationCommand, ErrorOr<int>>(requestBody);

            var value = result.Value;

            if (result.IsError)
            {
                return BadRequest(result.Errors);
            }

            return Created("", value);
        }
    }
}
