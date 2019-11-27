namespace PalTracker
{
    public static class MappingExtensions
    {
        public static TimeEntry ToEntity(this TimeEntryRecord record)
        {
            if (record != null)
            {
                return new TimeEntry()
                {
                    Id = record.Id,
                    ProjectId = record.ProjectId,
                    UserId = record.UserId,
                    Date = record.Date,
                    Hours = record.Hours
                };
            }
            else return null;
        }

        public static TimeEntryRecord ToRecord(this TimeEntry entity)
        {
            if (entity != null)
            {
                return new TimeEntryRecord()
                {
                    Id = entity.Id,
                    ProjectId = entity.ProjectId,
                    UserId = entity.UserId,
                    Date = entity.Date,
                    Hours = entity.Hours
                };

            }
            else return null;
        } 
   }
}