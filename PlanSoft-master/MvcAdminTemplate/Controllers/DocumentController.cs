using MvcAdminTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAdminTemplate.Controllers
{
    public class DocumentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Models.Document model = new Models.Document();

            using (var context = new Models.DBModelEntities())
            {
                // leaving for now.  this will find a list of the plan names possible
                //IList<ElementVariable> VarList = context.ElementVariables.ToList();
                //List<String> _plans = VarList.Where(x=>x.Element.Name.Equals("Plan")).Select(x=>x.Name).ToList();

                var _plans = (from e in context.Elements
                              join a in context.Attributes on e.Code equals a.ECode
                              join p in context.Processes on a.Code equals p.ACode
                              join pl in context.Plans on p.ID equals pl.ProcessID
                              select pl.PlanName
                              ).Distinct().OrderBy(s => s).ToList();

                model.selectedplan = _plans[0];

                List<String> _templates = new List<String>() { "Template 1", "Template 2", "Template 3" };
                model.selectedtemplate = _templates[0];

                model.plans = _plans;
                model.templates = _templates;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Models.Document model)
        {
            using (var context = new Models.DBModelEntities())
            {
                var _plans = (from e in context.Elements
                              join a in context.Attributes on e.Code equals a.ECode
                              join p in context.Processes on a.Code equals p.ACode
                              join pl in context.Plans on p.ID equals pl.ProcessID
                              select pl.PlanName
                                  ).Distinct().OrderBy(s => s).ToList();

                List<String> _templates = new List<String>() { "Template 1", "Template 2", "Template 3" };

                model.plans = _plans;
                model.templates = _templates;


                model.planDetails = (from e in context.Elements
                                    join o in context.Organizations on e.OrgID equals o.ID
                                    join a in context.Attributes on e.Code equals a.ECode
                                    join p in context.Processes on a.Code equals p.ACode
                                    join pl in context.Plans on p.ID equals pl.ProcessID
                                    where pl.PlanName == model.selectedplan
                                    select new Models.PlanDetails
                                    {
                                        elementName = e.Name,
                                        creationDate = e.CreatedOn,
                                        orgName = o.Name,
                                        Address = o.Address,
                                        City = o.City,
                                        State = o.State,
                                        Attribute = a.Name,
                                        AttributeSelection = pl.Selected,
                                        PlanName = pl.PlanName

                                    }).ToList();
            }
            return View(model);
        }
    }
}

