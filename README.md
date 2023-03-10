# Claim Based Authorization in asp dot net core Mvc
- You Have To Tell In The Startup You Are going to use authentication write below code in start.cs and this says you are adding the authentication service in your application using a cookies
```c#
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
```
### Now You have To Add Policy in Startup
```c#
builder.Services.AddAuthorization(options =>
{
    //Claim is required for this policy is UserId if any user have Claim Named UserId and Value 1,2,3,4,5 then this will work otherwise this will not give you the access 
    options.AddPolicy("SuperUser", policy => policy.RequireClaim("UserId", "1", "2", "3", "4", "5"));
});
```
### Then you have add Singleton
```c#
builder.Services.AddSingleton<IAuthorizationHandler, SalaryHandler>();
```
### after that you have to tell the application to add authentication and authorization
```c#
app.UseAuthentication();
app.UseAuthorization();
```

### And Then You Have to authenticate user like this
```c#
if (username == "admin" && password == "dotnet")
            {
            //if i change the UserId to 6 it cann't access Privacy method Because we have registerd A Policy With a claim named UserId in Program/startup.cs
                var identity = new ClaimsIdentity(new[] { new Claim("UserId", "1") }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principle = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                return RedirectToAction("Index", "Home");
            }
```
### now you have to use Policy base authorization for a method or a controller so you can simply provide a parameter called Policy to the Authorize attribute Like this [Authorize(Policy = "SuperUser")]
```c#
[Authorize(Policy = "SuperUser")]
public IActionResult Privacy()
{
  return View();
}
```
- Now This Method Will only accessible to The User Whose Have Policy With Requirment Matchs That It 
## Thanks
- Visit To The Repository Where Role Based Authorization Has been implemented 
- [ClaimBasedAuthorization](https://github.com/rajguptaH/ClaimBasedAuthorization)
