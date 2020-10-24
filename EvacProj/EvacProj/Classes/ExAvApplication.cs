using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvacProj
{
    public class ExAvApplication
    {
        public int ExAvId { get; set; }
        public string Description { get; set; }
        public string Month { get; set; }

        public ExAvApplication(int exAvId, string description, string month)
        {
            this.ExAvId = exAvId;
            this.Description = description;
            this.Month = month;

        }
    }
}