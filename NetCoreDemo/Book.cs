using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreDemo
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public double Price { get; set; }
    }
}
