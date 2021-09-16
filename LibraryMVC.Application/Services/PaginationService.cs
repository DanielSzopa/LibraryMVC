using System.Collections.Generic;
using System.Linq;

namespace LibraryMVC.Application
{
    public class PaginationService : IPaginationService
    {
        public List<T> ReturnRecordsToShow<T>(int pageNumber, int pageSize, List<T> list)
        {
            var excludeRecords = GetExcludeRecordsToPagination(pageNumber, pageSize);
            var records = list.
                Skip(excludeRecords)
                .Take(pageSize)
                .ToList();
            return records;
        }

        public int GetExcludeRecordsToPagination(int pageNumber, int pageSize)
        {
            var excludeRecords = (pageSize * pageNumber) - pageSize;
            return excludeRecords;
        }
    }
}
