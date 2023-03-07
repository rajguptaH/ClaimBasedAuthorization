# Role Based Authorization in asp dot net core Mvc
- You Have To Tell In The Startup You Are going to use authentication write below code in start.cs and this says you are adding the authentication service in your application using a cookies
```c#
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
```
- after that you have to tell the application to add authentication and authorization
```c#
app.UseAuthentication();
app.UseAuthorization();
```
- After that you have to create a simple AccountController With Login Get Post Methods and Logout Method With Simple View Then You Have To Add a attribute Called [AllowAnonymous] This will keep this method accessable for anyone without login see below 
```c#
[AllowAnonymous]
[HttpGet]
public IActionResult Login()
{
    return View();
}
```
- And Put a [Authorize] attribute where you want only authorization person can use this method
```c#
[Authorize]
public IActionResult Index()
{
   return View();
}
```
- Then You Have Login Users Using based on their credentials and after that you have use a method SignInAsyncs Login User With given identity claim and roles after that you can compare roles of user when you are authorizing method or controllers like see next point 
```c#
[HttpPost]
public IActionResult Login(string username,string password)
  {
            if(username=="admin" && password == "dotnet")
            {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Role, "Admin"), new        
                Claim(ClaimTypes.Role, "SU") }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principle = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                return RedirectToAction("Index", "Home");
            }
            
            if(username=="user" && password == "user")
            {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Role, "user") },   
                CookieAuthenticationDefaults.AuthenticationScheme);
                var principle = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                return RedirectToAction("Index", "Home");
            }
            return View();
  }
```
- now you have to use role base authorization for a method or a controller so you can simply provide a parameter called role to the Authorize attribute Like this [Authorize(Role = "Admin")]
```c#
[Authorize(Roles ="Admin")] 
public IActionResult Privacy()
{
  return View();
}
```
- Now This Method Will only accessible to The User Whose Role is Admin That It 
## Thanks
- Visit To The Repository Where Role Based Authorization Has been implemented 
- [RoleBaseAuthorization](https://github.com/rajguptaH/RoleBaseAuthorizationAspCore)
