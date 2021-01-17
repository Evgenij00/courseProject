using courseProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace courseProject.Controllers
{
    public abstract class ApplicationController : Controller
    {

        private ApplicationDbContext _db; // объявление переменной, в которой будет находиться контекст данных

        public ApplicationDbContext DataContext // геттер для получения контекста данных из внешнего кода
        {
            get { return _db; }
        }
        public ApplicationController(ApplicationDbContext context) //конструктор, в котором получаем контекст данных
        {
            _db = context;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            ViewBag.Categories = DataContext.Categories;
        }

        [NonAction]
        protected async Task Authenticate(string userName)
        {
            // создаем один claim

            //Для правильного создания и настройки объекта ClaimsPrincipal вначале создается список claims - набор данных,
            //которые шифруются и добавляются в аутентификационные куки. Каждый такой claim принимает тип и значение.
            //В нашем случае у нас только один claim, который в качестве типа принимает константу ClaimsIdentity.DefaultNameClaimType,
            //а в качестве значения - email пользователя.
            var claims = new List<Claim>
            { 
                //Для создания claima ему в конструктор передается тип и значения.
                //Тип ClaimsIdentity.DefaultNameClaimType фактически представляет логин.
                //А userName, в данном случае будет представлять значение,
                //которое затем мы сможем получить через выражение User.Identity.Name
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            // создаем объект ClaimsIdentity

            //Далее создается объект ClaimsIdentity, который нужен для инициализации ClaimsPrincipal. В ClaimsIdentity передается:

            //Ранее созданный список claims

            //Тип аутентификации, в данном случае "ApplicationCookie"

            //Тип данных в списке claims, который преставляет логин пользователя.
            //То есть при добавлении claimа мы использовали в качестве типа ClaimsIdentity.DefaultNameClaimType,
            //поэтому и тут нам надо указать то же самое значение. Мы, конечно, можем указать и разные значения,
            //но тогда система не сможет связать различные claim с логином пользователя.

            //Тип данных в списке claims, который представляет роль пользователя.
            //Хотя у нас такого claim нет, который бы представлял роль пользователя,
            //но опционально мы можем указать константу ClaimsIdentity.DefaultRoleClaimType.
            //В данном случае она ни на что не влияет.

            //Для создания объекта ClaimsIdentity в его конструктор передается набор claim,
            //тип аутентификации (ApplicationCookie), тип для claima, представляющего логин, и тип для claima, представляющего роль.

            //Созданный объект ClaimsIdentity передается в конструктор ClaimsPrincipal.
            //И фактически этот объект ClaimsPrincipal и будет представлять то,
            //что мы потом в любом контроллере сможем получить через HttpContext.User.
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            //И после вызова метода расширения HttpContext.SignInAsync в ответ клиенту будут отправляться аутентификационные куки,
            //которые при последующих запросах будут передаваться обратно на сервер,
            //десериализоваться и использоваться для аутентификации пользователя.

            // установка аутентификационных куки

            //Для установки кук применяется асинхронный метод контекста HttpContext.SignInAsync().
            //В качестве параметра он принимает схему аутентификации,
            //которая была использована при установки middleware app.UseCookieAuthentication в классе Startup.
            //То есть в нашем случае это строка "Cookies".
            //А в качестве второго параметра передается объект ClaimsPrincipal, который представляет пользователя.
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}