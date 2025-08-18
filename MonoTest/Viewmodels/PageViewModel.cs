using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoTest.ViewModels
{
    public class PageViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}