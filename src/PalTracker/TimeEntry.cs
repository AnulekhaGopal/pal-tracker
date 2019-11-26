using System;
using PalTracker;

namespace PalTracker
{
    public class TimeEntry
    {
        public long? Id  { get; set; }
        public long ProjectId { get; set; }

        public long UserId  { get; set; }
        public DateTime Date { get; set; }
        public  int Hours { get; set; }
        
        public TimeEntry(long? id, long projectId, long userId, DateTime date ,  int hours  )
        { 
            this.Id = id;
            this.ProjectId = projectId;
            this.UserId = userId;
            this.Date = date;
            this.Hours = hours;
        }        

        public TimeEntry(long projectId, long userId, DateTime date ,  int hours  )
        {         
            this.Id = null;
            this.ProjectId = projectId;
            this.UserId = userId;
            this.Date = date;
            this.Hours = hours;
        }

        public override bool Equals(Object obj)
    {
      //Check for null and compare run-time types.
      if ((obj == null) || ! this.GetType().Equals(obj.GetType())) 
      {
         return false;
      }
      else { 
         TimeEntry timeEntry = (TimeEntry) obj; 
         return (Id == timeEntry.Id) && (UserId == timeEntry.UserId) && (ProjectId == timeEntry.ProjectId);
      }   
   }

   
    }
}