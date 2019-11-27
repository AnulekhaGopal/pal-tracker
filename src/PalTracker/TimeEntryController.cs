using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace PalTracker
{
   [Route("/time-entries")]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryRepository _timeEntryRepository;
        private readonly IOperationCounter<TimeEntry> _operationCounter;

        public TimeEntryController(ITimeEntryRepository timeEntryRepository, IOperationCounter<TimeEntry> operationCounter)
        {
            _timeEntryRepository = timeEntryRepository;
            _operationCounter =operationCounter;
        }
       
        [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult Read(long id)
        {
             _operationCounter.Increment(TrackedOperation.Read);
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
            _operationCounter.Increment(TrackedOperation.Create);

            TimeEntry timeEntry1 = _timeEntryRepository.Create(timeEntry);

            return CreatedAtRoute("GetTimeEntry",new {id = timeEntry1.Id},  timeEntry1);
        }

        [HttpGet]
        public IActionResult List()
        {
             _operationCounter.Increment(TrackedOperation.List);
            System.Collections.Generic.List<TimeEntry> list = _timeEntryRepository.List().ToList();

            return Ok(list);
        }

[HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TimeEntry timeEntry)
        {
             _operationCounter.Increment(TrackedOperation.Update);
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
             _operationCounter.Increment(TrackedOperation.Delete);
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