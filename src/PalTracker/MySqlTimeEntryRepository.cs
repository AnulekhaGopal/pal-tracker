using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PalTracker
{
    public class MySqlTimeEntryRepository : ITimeEntryRepository
    {
        private readonly TimeEntryContext _context;

        public MySqlTimeEntryRepository()
        {
        }

        public MySqlTimeEntryRepository(TimeEntryContext context)
        {
            _context = context;
        }

       public bool Contains(long id) =>
            _context.TimeEntryRecords.AsNoTracking().Any(t => t.Id == id);

        public TimeEntry Create(TimeEntry timeEntry)
        {
            var recordToCreate = timeEntry.ToRecord();

            _context.TimeEntryRecords.Add(recordToCreate);
            _context.SaveChanges();

            return Find(recordToCreate.Id.Value);
        }

        // public void Delete(long id)
        // {
        //     _context.TimeEntryRecords.Remove(FindRecord(id));
        //     _context.SaveChanges();
        // }

        public TimeEntry Find(long id) => FindRecord(id).ToEntity();

        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
            var recordToUpdate = timeEntry.ToRecord();
            recordToUpdate.Id = id;

            _context.Update(recordToUpdate);
            _context.SaveChanges();

            return Find(id);
        }

        public bool Delete(long id)
        {
            _context.TimeEntryRecords.Remove(FindRecord(id));
            _context.SaveChanges();
            return true;
        }

        private TimeEntryRecord FindRecord(long id) =>
            _context.TimeEntryRecords.AsNoTracking().FirstOrDefault(t => t.Id == id);

        public IEnumerable<TimeEntry> List()
        {
              return _context.TimeEntryRecords.AsNoTracking().Select(t => t.ToEntity());

        }
    }
 }