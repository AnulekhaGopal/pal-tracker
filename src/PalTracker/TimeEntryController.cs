using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
   [Route("/time-entries")]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryRepository _timeEntryRepository;

        public TimeEntryController(ITimeEntryRepository timeEntryRepository)
        {
            _timeEntryRepository = timeEntryRepository;
        }
       
        [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult Read(long id)
        {
            TimeEntry timeEntry = _timeEntryRepository.Find(id);
             
            if (timeEntry == null)
            {
                return NotFound();
            }
            else{
                return Ok(timeEntry);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] TimeEntry timeEntry)
        {
            TimeEntry timeEntry1 = _timeEntryRepository.Create(timeEntry);

            return CreatedAtRoute("GetTimeEntry",new {id = timeEntry1.Id},  timeEntry1);
        }

        [HttpGet]
        public IActionResult List()
        {
            System.Collections.Generic.List<TimeEntry> list = _timeEntryRepository.List();

            return Ok(list);
        }

[HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TimeEntry timeEntry)
        {
           TimeEntry timeEntry1 = _timeEntryRepository.Update(id, timeEntry);

            if (timeEntry1 == null)
            {
                return NotFound();
            }
            else{
                return Ok(timeEntry1);
            }
        }

 [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
             if (!_timeEntryRepository.Contains(id))
            {
                return NotFound();
            }
            else{
                _timeEntryRepository.Delete(id);
            }
             return NoContent();         
        }
    }
}