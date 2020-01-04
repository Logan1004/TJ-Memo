using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TJ_Memo
{
    public class Event
    {
        public string userName;
        public DateTime date;
        public string note;
        public Event(string userName, DateTime date, string note)
        {
            this.userName=userName;
            this.date = date;
            this.note = note;

        }
    }
}
