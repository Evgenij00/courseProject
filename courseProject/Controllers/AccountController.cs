using Microsoft.AspNetCore.Mvc;
using courseProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using сourseProject.ViewModels;

namespace courseProject.Controllers
{
    public class AccountController : ApplicationController
    {
        public AccountController(ApplicationDbContext context) : base(context) { }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //Метод Register сделан аналогично методу Login, только теперь мы получаем данные регистрации через объект RegisterModel
        //и перед аутентификацией сохраняем эти данные в базу данных.

        //Вначале смотрим, а есть ли с таким же email в базе данных какой-либо пользователь,
        //если такой пользователь имеется в БД, то выполняем аутентификацию и устанавливаем аутентификационные куки.
        //Чтобы не повторяться (в соответствии с принципом DRY), данный код вынесен в отдельный метод Authenticate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await DataContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    DataContext.Users.Add(new User { Email = model.Email, Password = model.Password });
                    await DataContext.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }

            }
            return View(model);
        }

        private async Task Authenticate(string userName)
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
