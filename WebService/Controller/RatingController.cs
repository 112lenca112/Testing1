using System.Collections.Generic;
using AutoMapper;
using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2_Group11.Model;

namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController :  ControllerBase
    {
        private readonly DataServiceFacade _dataService;
        private readonly IMapper _mapper;

        public RatingController(DataServiceFacade dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        public IActionResult GetRatingList()
        {
            var userNameRates = _dataService.RatingDS.GetRatingList();
            return Ok(_mapper.Map<IEnumerable<UserNameRateDto>>(userNameRates));
        }
        
        
        [HttpGet("{id}")]
        public IActionResult GetRating(int userId)
        {
            var userNameRates = _dataService.RatingDS.GetRating(userId);
            if (userNameRates == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookmarkPersonDto>(userNameRates));
        }

        
        [HttpPost]
        public IActionResult CreateBookmark(UserNameRateForCreationDto userNameRateForCreationDto)
        {
            var userNameRate = _mapper.Map<UserNameRate>(userNameRateForCreationDto);
            _dataService.RatingDS.CreateRating(userNameRate);
            return Created("", userNameRate);
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateRating(int userid)
        {
            var userNameRate = _mapper.Map<UserNameRate>(userid);
            if (_dataService.RatingDS.UpdateRating(userNameRate))
            {
                return NotFound();
            }
            return NoContent();
        }
        
        
        [HttpDelete("{id}")]
        public IActionResult DeleteRating(int userId)
        {
            var response = " rating not found";
            if (!_dataService.RatingDS.DeleteRating(userId))
            {
                return NotFound(response);
            }
            response = " rating deleted succesfully";
            return CreatedAtRoute(null, userId + response);
        }
    }
}