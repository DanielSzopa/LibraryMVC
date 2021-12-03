using System.Collections.Generic;

namespace LibraryMVC.Application
{
    public interface IPaginationService
    {
        List<T> ReturnRecordsToShow<T>(int pageNumber, int pageSize, List<T> list);
        int GetExcludeRecordsToPagination(int pageNumber, int pageSize);
    }
}
