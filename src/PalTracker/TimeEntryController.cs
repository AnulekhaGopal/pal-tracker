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
        public IActionResult Create(TimeEntry timeEntry)
        {
            TimeEntry timeEntry1 = _timeEntryRepository.Create(timeEntry);

            return CreatedAtAction("Create", timeEntry);
        }

 [HttpGet]
        public IActionResult List()
        {
            System.Collections.Generic.List<TimeEntry> list = _timeEntryRepository.List();

            return Ok(list);
        }

[HttpPut("{id}")]
        public IActionResult Update(long id, TimeEntry timeEntry)
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
            var result= _timeEntryRepository.Delete(id);
            
            if (!result)
            {
                return NotFound();

            }
            else
            {
                return NoContent();
            }
        }
    }
}