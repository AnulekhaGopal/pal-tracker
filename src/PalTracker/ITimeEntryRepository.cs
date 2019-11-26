using System;
using System.Collections.Generic;
using System.Linq;
using PalTracker;

namespace PalTracker
{
    public interface ITimeEntryRepository
    {
        TimeEntry Create(TimeEntry entry);
        TimeEntry Find(long id);

        bool Contains(long id);

        List<TimeEntry> List();

        TimeEntry Update(long id, TimeEntry entry);

        bool Delete(long id);
    } 
}