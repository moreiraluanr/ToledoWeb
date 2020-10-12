using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Toledo.Aplication.Model;
using Toledo.Aplication.UseCase;

namespace Toledo.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUseCase<InsertEmployeeRequest> _insert;
        private readonly IUseCase<AlterEmployeeRequest> _alter;
        private readonly IUseCase<GetEmployeeRequest, GetEmployeeResponse> _get;
        private readonly IUseCase<ListEmployeeRequest, IEnumerable<ListEmployeeResponse>> _list;
        private readonly IUseCase<RemoveEmployeeRequest> _remove;

        public EmployeeController(
            IUseCase<InsertEmployeeRequest> insert, 
            IUseCase<AlterEmployeeRequest> alter, 
            IUseCase<GetEmployeeRequest, GetEmployeeResponse> get, 
            IUseCase<ListEmployeeRequest, IEnumerable<ListEmployeeResponse>> list, 
            IUseCase<RemoveEmployeeRequest> remove)
        {
            _insert = insert;
            _alter = alter;
            _get = get;
            _list = list;
            _remove = remove;
        }

        #region Filter
        public IActionResult Filter()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Filter", ex.Message);
                return RedirectToAction("Filter");
            }
        }
        #endregion

        #region Insert
        public IActionResult PageInsert()
        {
            return View();
        }

        public IActionResult Insert(InsertEmployeeRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                    _insert.Execute(request);

                return View("Filter");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Insert", ex.Message);
                return RedirectToAction("Filter");
            }
            
        }
        #endregion

        #region Alter
        public IActionResult PageAlter()
        {
            return View();
        }

        public IActionResult Alter(AlterEmployeeRequest request)
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
                return RedirectToAction("Filter");
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
            var employee = _get.Execute(new GetEmployeeRequest() { Id = id });
            if (employee == null)
                return Json(null);

            return Json(employee);
        }
        #endregion

        #region List
        public IActionResult ListPage(ListEmployeeRequest request)
        {
            try
            {
                var employers = _list.Execute(request);
                return View(employers);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ListPage", ex.Message);
                return RedirectToAction("Filter");
            }
        }
        #endregion

        #region Remove
        public IActionResult PageRemove()
        {
            return View();
        }

        public IActionResult Remove(RemoveEmployeeRequest request)
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
                return RedirectToAction("Filter");
            }
        }
        #endregion
    }
}
