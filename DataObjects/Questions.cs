using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Questions
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string CategoryId { get; set; }

        public List<Options> Options { get; set; }
    }
}
