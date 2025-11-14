using Cortex.Mediator;
using ErrorOr;
using HotelReservation.Api.DTOs;
using HotelReservation.Application.Customers.Commands.CreateCustomer;
using HotelReservation.Application.HotelRooms.Commands.CreateHotelRoom;
using HotelReservation.Application.HotelRooms.Dtos;
using HotelReservation.Application.HotelRooms.Queries.GetAllHotelRooms;
using HotelReservation.Application.HotelRooms.Queries.GetHotelRoom;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelRoomsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<HotelRoomsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var cmd = new GetAllHotelRoomsQuery();

            var temp = await _mediator.SendQueryAsync<GetAllHotelRoomsQuery, ErrorOr<IEnumerable<HotelRoomDto>>>(cmd);

            var value = temp.Value;

            return Ok(value);
        }

        // GET api/<HotelRoomsController>/5
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAllHotelRooms(Guid id)
        {

            var cmd = new GetHotelRoomQuery()
            {
                HotelRoomId = id,
            };

            var temp = await _mediator.SendQueryAsync<GetHotelRoomQuery, ErrorOr<HotelRoomDto>>(cmd);

            var value = temp.Value;

            return Ok(value);
        }

        // POST api/<HotelRoomsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HotelRoomRequest requestBody)
        {
            var cmd = new CreateHotelRoomCommand()
            {
                Name = requestBody.Name,
                Area = requestBody.Area,
                GuestCapacity = requestBody.GuestCapacity,
                RoomNumber = requestBody.RoomNumber
            };

            var temp = await _mediator.SendCommandAsync<CreateHotelRoomCommand, ErrorOr<HotelRoomDto>>(cmd);

            var value = temp.Value;

            return Created("", value);
        }

        // PUT api/<HotelRoomsController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] HotelRoomRequest requestBody)
        {
            var cmd = new UpdateHotelRoomCommand()
            {
                Id = id,
                Name = requestBody.Name,
                Area = requestBody.Area,
                GuestCapacity = requestBody.GuestCapacity,
                RoomNumber = requestBody.RoomNumber
            };

            var temp = await _mediator.SendCommandAsync<UpdateHotelRoomCommand, ErrorOr<HotelRoomDto>>(cmd);

            var value = temp.Value;

            return Ok(value);
        }

        // DELETE api/<HotelRoomsController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var cmd = new DeleteHotelRoomCommand()
            {
                Id = id
            };

            var temp = await _mediator.SendCommandAsync<DeleteHotelRoomCommand, ErrorOr<bool>>(cmd);

            if (temp.IsError)
                return NotFound(temp.Errors);

            var value = temp.Value;

            return Ok(value);
        }
    }
}
