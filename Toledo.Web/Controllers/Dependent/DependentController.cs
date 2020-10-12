using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Toledo.Aplication.Model;
using Toledo.Aplication.Model.Dependent.Request;
using Toledo.Aplication.Model.Dependent.Response;
using Toledo.Aplication.UseCase;

namespace Toledo.Web.Controllers
{
    public class DependentController : Controller
    {
        private readonly IUseCase<InsertDependetRequest> _insert;
        private readonly IUseCase<AlterDependetRequest> _alter;
        private readonly IUseCase<GetDependentRequest, GetDependentResponse> _get;
        private readonly IUseCase<ListDependentRequest, IEnumerable<ListDependentResponse>> _list;
        private readonly IUseCase<RemoveDependetRequest> _remove;

        public DependentController(
            IUseCase<InsertDependetRequest> insert,
            IUseCase<AlterDependetRequest> alter,
            IUseCase<GetDependentRequest, GetDependentResponse> get,
            IUseCase<ListDependentRequest, IEnumerable<ListDependentResponse>> list,
            IUseCase<RemoveDependetRequest> remove)
        {
            _insert = insert;
            _alter = alter;
            _get = get;
            _list = list;
            _remove = remove;
        }

        #region Insert

        public IActionResult PageInsert()
        {
            return View();
        }


        public IActionResult Insert(InsertDependetRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                    _insert.Execute(request);

                return View("Filter");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Insert", ex.Message);
                return RedirectToAction("Filter", "Employee");
            }
        }
        #endregion

        #region Alter
        public IActionResult PageAlter()
        {
            return View();
        }

        public IActionResult Alter(AlterDependetRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                    _alter.Execute(request);

                return View("Filter");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Alter", ex.Message);
                return RedirectToAction("Filter", "Employee");
            }
        }
        #endregion

        #region Get
        public IActionResult PageGet()
        {
            return View();
        }

        public IActionResult Get(int id)
        {
            var dependet = _get.Execute(new GetDependentRequest() { Id = id });
            if (dependet == null)
                return Json(null);

            return Json(dependet);
        }
        #endregion

        #region List
        public IActionResult List()
        {
            var dependents = _list.Execute(new ListDependentRequest());
            return View(dependents);
        }
        #endregion

        #region Remove
        public IActionResult PageRemove()
        {
            return View();
        }

        public IActionResult Remove(RemoveDependetRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                    _remove.Execute(request);

                return View("Filter");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Remove", ex.Message);
                return RedirectToAction("Filter", "Employee");
            }
        }
        #endregion
    }
}
