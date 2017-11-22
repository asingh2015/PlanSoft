using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdminTemplate.Models
{
    public class Document
    {
        public List<String> plans { get; set; }
        public List<String> templates { get; set; }
        public string selectedplan { get; set; }
        public string selectedtemplate { get; set; }
        public List<PlanDetails> planDetails { get; set; }
    }

    public class PlanDetails
    {
        public string elementName { get; set; }
        public DateTime creationDate { get; set; }
        public string orgName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Attribute { get; set; }
        public string AttributeSelection { get; set; }
        public string PlanName { get; set; }
    }
}