using Repository.Repo;
using SchoolWeb.Data.Model;
using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers
{
    [Authorize]
    public class NavController : Controller
    {
        //private readonly IUnitOfWork uow = null;
        //private readonly IRepository<SchoolApp.Domain.menucontrol> repoMenu = null;
        //private readonly IRepository<SchoolApp.Domain.roleAssignment> repoRoleAssig = null;
        //private readonly IRepository<SchoolApp.Domain.state> repoState = null;

        private readonly IGenericRepository<AspNetUser> _repoUser = null;
        private readonly IGenericRepository<ParentMenu> _repoMenuPar = null;
        private readonly IGenericRepository<ChildMenu> _repoMenuchild = null;
        //private int menuid;
        int roleid;

        public NavController()
        {
            _repoUser = new GenericRepository<AspNetUser>();
            _repoMenuPar = new GenericRepository<ParentMenu>();
            _repoMenuchild = new GenericRepository<ChildMenu>();
        }
        //
        // GET: /Nav/

        public PartialViewResult Menu()
        {
            MenuViewModel mnv = new MenuViewModel();
            var user = new UserDataSettings().GetUserData();
            if (user != null)
            {
                roleid = user.UserRole; // short.Parse(new ProfileHelper().GetProfile(User.Identity.Name, "roleid").ToString());
                var rec = _repoMenuPar.LoadViaStockProc("Exec proc_parentMenu '" + roleid + "'", null).ToList();
                var parMenu = rec;
                //  ViewBag.ParentMenu = parMenu;
                var rec2 = _repoMenuchild.LoadViaStockProc("Exec proc_childMenu '" + roleid + "'", null).ToList();
                var childMenu =  rec2;

                List<ChildMenu> mn = new List<ChildMenu>();
                foreach (var d in parMenu)
                {
                    var t = childMenu.Where(e => e.ParentId == d.ParentId).ToList();
                    if (t.Count > 0)
                    {
                        mn.AddRange(t);
                    }

                    // ViewBag.ChildMenu = mn;

                }
                
                mnv.ParNode = parMenu;
                mnv.ChildNode = mn;
            }
            //parentRepeater.DataSource = rst;
            //parentRepeater.DataBind();

            return PartialView(mnv);
        }

        public PartialViewResult UserDetail()
        {

            var user = new UserDataSettings().GetUserData();
            if (user == null)
            {
                user = new UserDataObj();
            }
            //parentRepeater.DataSource = rst;
            //parentRepeater.DataBind();

            return PartialView(user);
        }

        //public PartialViewResult ApprovalRoute(int m, decimal? AuthId, short action, string cola = "col-md-2", string colb = "col-md-4")
        //{
        //    ViewBag.ColA = cola;
        //    ViewBag.ColB = colb;
        //    var d = _repoMenu.GetApprovalRoutePage(m, User.Identity.Name, action, AuthId);
        //    ViewBag.ApproverList = new SelectList(d, "StaffId", "StaffName");
        //    return PartialView("ApprovalRoutePartial");
        //}

        //public async Task<PartialViewResult> ApprovalRouteLine(decimal id)
        //{

        //    var model = await _repoUser.GetApprovalListForRequestAsync(id);
        //    //ViewBag.ApproverList = new SelectList(d, "StaffId", "StaffName");
        //    return PartialView("_ApprovalLinePartial", model);
        //}
    }
}