    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MVC_PART1.Models;
    using MVC_PART1.Services;
    using System.Net.Http.Headers;
    using System.Net.Http;
    using System.Net.Http.Headers;


    using System.Net.Http;
    using System.Security.Claims;
    using System.Text.Json;
    using static MVC_PART1.Services.IAccountServices; 

    namespace MVC_PART1.Controllers
    {

      //  [LogActionFilter]
        public class AccountController : Controller
        {
            private readonly IAccountServices _accountService;
            private readonly JwtService _jwtService;

     

            public AccountController(IAccountServices accountService , JwtService jwtService,IHttpClientFactory httpClientFactory, IConfiguration configuration)
            {
                _accountService = accountService;
                _jwtService = jwtService;
           
            }



        /// THIS IS COOKIES AUTHENTICATION

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginRegisterWrapper wrapper, string actiontype)
        //{
        //    if (actiontype == "Login")
        //    {
        //        var user = _accountService.Login(wrapper.Login);






        //        if (user != null)
        //        {
        //            var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, user.UserName),
        //            new Claim(ClaimTypes.Role, user.Role)
        //        };

        //            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //            await HttpContext.SignOutAsync();
        //            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
        //                   new ClaimsPrincipal(identity));

        //            TempData["LoginMessage"] = "Successfully logged in!";
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            // ❌ Failure: wrong password or user
        //            ModelState.AddModelError("Login.Password", "Invalid username or password.");
        //            return View(wrapper);
        //        }


        //    }



        //    else if (actiontype == "Register")
        //    {
        //        var exists = _accountService.GetAllUsers().Any(u => u.UserName == wrapper.Register.UserName);
        //        if (exists)
        //        {
        //            ModelState.AddModelError("Register.UserName", "Username already exists.");

        //            return View(wrapper);
        //        }

        //        var user = new User
        //        {
        //            UserName = wrapper.Register.UserName,
        //            Password = wrapper.Register.Password,
        //            Name = wrapper.Register.Name,
        //            Email = wrapper.Register.Email,
        //            Role = wrapper.Register.Role
        //        };

        //        _accountService.Register(user);

        //        // Auto-login
        //        var claims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.Name, user.UserName),
        //    new Claim(ClaimTypes.Role, user.Role)
        //};

        //        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //        await HttpContext.SignOutAsync();
        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
        //            new ClaimsPrincipal(identity));

        //        TempData["RegisterSuccess"] = true;
        //        return RedirectToAction("Index", "Event");
        //    }

        //    return View(wrapper);

        //}




        ///THIS IS JWT AUTHENTICATION  with cookies

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginRegisterWrapper wrapper, string actiontype)
        //{
        //    if (actiontype == "Login")
        //    {
        //        var user = _accountService.Login(wrapper.Login);

        //        if (user != null)
        //        {
        //            //generate token
        //            var token = _jwtService.GenerateToken(user.UserName, user.Role);
        //            Console.WriteLine("Generated JWT Token: " + token);

        //            //// store in sesion
        //            //HttpContext.Session.SetString("JWTToken", token);

        //            //// store JWT IN COOKEIS
        //            //Response.Cookies.Append("AuthToken", token, new CookieOptions
        //            //{
        //            //    HttpOnly = true,
        //            //    Secure = true,
        //            //    Expires = DateTime.UtcNow.AddHours(1),
        //            //    SameSite = SameSiteMode.Strict

        //            //});

        //             token = HttpContext.Session.GetString("JWTToken");
        //            var client = _httpClientFactory.CreateClient();

        //            if (!string.IsNullOrEmpty(token))
        //            {
        //                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //            }

        //            try
        //            {


        //                var secureApiUrl = _configuration["SecureApiUrl"];
        //                var response = await client.GetAsync(secureApiUrl);


        //                if (response.IsSuccessStatusCode)
        //                {

        //                }
        //                else
        //                {
        //                    TempData["Loginmessage"] = "login success ,but secure api is failed";
        //                }



        //               }
        //            catch(HttpRequestException ex)
        //            {
        //                TempData["LoginMessage"] = "Login success,  but could not reach api";
        //                Console.WriteLine(" Http eror"+  ex.Message);

        //            }

        //            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
        //            {
        //                return Redirect(returnUrl);
        //            }



        //            TempData["LoginMessage"] = "Successfully Logged in !";
        //            return RedirectToAction("Index", "Home");
        //            //  return Content("Token: " + token);

        //        }
        //        else
        //        {
        //            //ModelState.AddModelError("wrapper.Password", "Invalid username or password");
        //            //return View(wrapper);

        //            TempData["LoginError"] = "Invalid username or pwd";
        //            return View("Login");
        //        }



        //    }






        //    else if (actiontype == "Register")
        //    {
        //        var exists = _accountService.GetAllUsers().Any(u => u.UserName == wrapper.Register.UserName);
        //        {
        //            if (exists)
        //            {
        //                ModelState.AddModelError("Register.UserName", "Username already exists");
        //                return View(wrapper);
        //            }
        //            var user = new User
        //            {
        //                UserName = wrapper.Register.UserName,
        //                Password = wrapper.Register.Password,
        //                Name = wrapper.Register.Name,
        //                Email = wrapper.Register.Email,
        //                Role = wrapper.Register.Role
        //            };

        //            _accountService.Register(user);


        //            TempData["RegisterSuccess"] = "Successfully Registred User";
        //            return RedirectToAction("Login");

        //        }



        //    }
        //    return View(wrapper);

        //}










        [HttpGet]
        public IActionResult Login() 
        {
            
            return View(new LoginRegisterWrapper());
        }



        ///    JWT AUTHENTICATION WITH SESSION

        [HttpPost]
            public async Task<IActionResult> Login( LoginRegisterWrapper wrapper ,string actiontype)

            {
                if (actiontype == "Login")
                {
                    var user = _accountService.Login(wrapper.Login);
                    if (user != null)
                    {
                        var token = _jwtService.GenerateToken(user.UserName,user.Password);
                        HttpContext.Session.SetString("JWTToken", token);
                        HttpContext.Session.SetString("Username", user.UserName);
                        HttpContext.Session.SetString("Role", user.Role);

                        TempData["LoginMessage"] = "Successfully Logged in!";
                        return RedirectToAction("Index", "Home");
                    }

                    TempData["LoginError"] = "Invalid username or password.";
                    return View("Login", new LoginRegisterWrapper());
                }


        






                else if (actiontype == "Register")
                {
                    var exists = _accountService.GetAllUsers().Any(u => u.UserName == wrapper.Register.UserName);
                    {
                        if (exists)
                        {
                            ModelState.AddModelError("Register.UserName", "Username already exists");
                            return View(wrapper);
                        }
                        var user = new User
                        {
                            UserName = wrapper.Register.UserName,
                            Password = wrapper.Register.Password,
                            Name = wrapper.Register.Name,
                            Email = wrapper.Register.Email,
                            Role = wrapper.Register.Role
                        };

                        _accountService.Register(user);


                        TempData["RegisterSuccess"] = "Successfully Registred User";
                        return RedirectToAction("Login");

                    }



                }
                return View(wrapper);

            }




            public async Task<IActionResult> Logout()
            {
                ///// THIS IS STAND FOR COOKIES AUTHENRICATION

                // await HttpContext.SignOutAsync(); // ✅ Clear auth cookie

                // return RedirectToAction("Login", "Account");



                // TTHIS IS STAND FOR JWT AUTHENTICATION

                // ✅ Remove the AuthToken cookie
                //   Response.Cookies.Delete("AuthToken");


                // ✅ Redirect to login or home

                HttpContext.Session.Clear(); 
                return RedirectToAction("Login", "Account");
            }


            private IActionResult RedirectToRoleBasedPage(User user)
            {
                if (user.Role == "Admin" || user.Role == "User")
                {
                    return RedirectToAction("Index", "Event");
                }

                return View("Login");
            }

        }
    }
