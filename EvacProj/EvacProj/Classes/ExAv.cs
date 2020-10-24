using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvacProj
{
    public class ExAv
    {
        public int ExAvId { get; set; }
        public string Description { get; set; }
        public int MaximumApplicants { get; set; }

        public ExAv(int exAvId, string description, int maximumApplicants)
        {
            this.ExAvId = exAvId;
            this.Description = description;
            this.MaximumApplicants = maximumApplicants;

        }
    }
}