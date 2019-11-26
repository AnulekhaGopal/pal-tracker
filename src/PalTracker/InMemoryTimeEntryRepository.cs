
using System.Collections.Generic;

namespace PalTracker
{
    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {        
        public List<TimeEntry> TimeEntryList = new List<TimeEntry>();

        public TimeEntry Create(TimeEntry entry)
        {            
            entry.Id = TimeEntryList.Count+1;
            TimeEntryList.Add(item: entry);
            return entry;
        }
        public bool Contains(long id)
        {
           var timeEntry = TimeEntryList.Find(x=>x.Id == id);            
           return timeEntry == null ? false : true;
        }

        public TimeEntry Update(long id, TimeEntry entry)
        {
           var timeEntry = TimeEntryList.Find(x=>x.Id == id);  

           if(timeEntry != null)          
           {
               timeEntry.ProjectId = entry.ProjectId;
               timeEntry.UserId = entry.UserId;
               timeEntry.Hours = entry.Hours;
               timeEntry.Date = entry.Date;               
           }    

           return  timeEntry;   
        }

        public TimeEntry Find(long id)
        {
             var timeEntry = TimeEntryList.Find(x=>x.Id == id);  
             return timeEntry == null ? null : timeEntry;
        }

        public List<TimeEntry> List()
        {
            return TimeEntryList;            
        }

        public bool Delete(long id)
        {

          var timeEntry = TimeEntryList.Find(x=>x.Id == id);

            if (timeEntry == null)
            {
                return false;
            }
            else
            {
                TimeEntryList.Remove(timeEntry);
                return true;
            }
        }
    }
}