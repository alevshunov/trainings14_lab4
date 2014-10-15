using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DatabaseDemo.Domain;
using DatabaseDemo.Domain.Model;
using DatabaseDemo.Helper;
using DatabaseDemo.Models;

namespace DatabaseDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(bool preventCookies)
        {
            ViewBag.MainMenu = MainMenuItems.Home;
            var viewModel = new HomeIndexViewModel();

            if (!preventCookies)
            {
                var clientStorage = new ClientStorage(HttpContext);
                viewModel.A = clientStorage.A;
                viewModel.B = clientStorage.B;
                viewModel.Operator = clientStorage.Operator;
            }

            return View(viewName:"Index", model:viewModel);
        }

        public ActionResult Calculate(double? a, double? b, Operator? @operator)
        {
            ViewBag.MainMenu = MainMenuItems.None;

            if (a == null || b == null || @operator == null)
            {
                var viewModel = new HomeIndexViewModel(a, b, @operator);
                return View(viewName: "Index", model: viewModel);
            }
            else
            {
                new HistoryProvider().AddHistoryEntry((double)a, (double)b, (Operator)@operator, Request.ServerVariables["REMOTE_ADDR"]);
                new ClientStorage(HttpContext).SetState(a, b, @operator);

                var result = new Calculator().Calculate((double)a, (double)b, (Operator)@operator);

                var viewModel = new HomeCalculateViewModel((double)a, (double)b, (Operator)@operator, result);
                return View(viewModel);
            }
        }

        public ActionResult History()
        {
            ViewBag.MainMenu = MainMenuItems.History;

            var history = new HistoryProvider().GetHistory();

            return View(history);
        }
    }
}
