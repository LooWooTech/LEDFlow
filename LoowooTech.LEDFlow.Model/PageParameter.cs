using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    public class PageParameter
    {
        public PageParameter(int page = 1, int limit = 20)
        {
            CurrentPage = page;
            PageSize = limit;
        }

        public int RecordCount { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int PageCount
        {
            get
            {
                return RecordCount / PageSize + (RecordCount % PageSize) > 0 ? 1 : 0;
            }
        }
    }
}
