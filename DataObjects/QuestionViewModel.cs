using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class QuestionViewModel
    {
        public int QxnNo { get; set; }

        public string QuestionText { get; set; }

        public string Option1 { get; set; }

        public bool chkOption1 { get; set; }

        public string Option2 { get; set; }

        public bool chkOption2 { get; set; }

        public string Option3 { get; set; }

        public bool chkOption3 { get; set; }

        public string Option4 { get; set; }

        public bool chkOption4 { get; set; }
    }
}
