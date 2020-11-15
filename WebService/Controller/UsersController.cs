using AutoMapper;
using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2_Group11.Model;


namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DataServiceFacade _dataService;
        private readonly IMapper _mapper;

        public UsersController(DataServiceFacade dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

             [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _dataService.UsersDS.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UsersDto>(user));
        }

        
        [HttpPost("post")]
        public IActionResult CreateUsers(UsersForCreationDto usersForCreationDto)
        {
            var user = _mapper.Map<Users>(usersForCreationDto);
            _dataService.UsersDS.CreateUser(user);
            return Created("", user);
        }
        
        
        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId)
        {
            var user = _mapper.Map<Users>(userId);
            if (_dataService.UsersDS.UpdateUser(user))
            {
                return NotFound();
            }
            return NoContent();
        }
        

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var response = " user not found";
            if (!_dataService.UsersDS.DeleteUser(userId))
            {
                return NotFound(response);
            }
            response = " user deleted";
            return CreatedAtRoute(null, userId + response);
        }
    }
}