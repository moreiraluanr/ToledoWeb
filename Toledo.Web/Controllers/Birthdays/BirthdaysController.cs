using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Toledo.Aplication.Model;
using Toledo.Aplication.UseCase;

namespace Toledo.Web.Controllers.Birthdays
{
    public class BirthdaysController : Controller
    {
        private readonly IUseCase<GetBirthdaysRequest, IEnumerable<GetBirthdaysResponse>> _get;

        public BirthdaysController(IUseCase<GetBirthdaysRequest, IEnumerable<GetBirthdaysResponse>> get)
        {
            _get = get;
        }

        public IActionResult GetBirthday()
        {
            var birthdays = _get.Execute(new GetBirthdaysRequest() { Month = DateTime.Now.Month });
            return View(birthdays);
        }
    }
}
