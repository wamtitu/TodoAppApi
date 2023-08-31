using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.Responses
{
    public class Pagination
    {
        public int TotalItemCount { get; set; }
        public int PageCount { get; set;}
        public int PageSize { get; set;}
        public int CurrentPage { get; set; }
        public Pagination(int totalItemCount, int pageSize, int currentPage){
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            PageCount = (int)Math.Ceiling(totalItemCount/ (double)pageSize);
        }
    }

}