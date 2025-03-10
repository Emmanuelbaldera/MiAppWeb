using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

public class AccountController : Controller
{
    // Acción GET: Muestra el formulario de inicio de sesión
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // Acción POST: Procesa el inicio de sesión
    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        // Simular la autenticación (Reemplazar con lógica de base de datos)
        if (username == "admin" && password == "1234")
        {
            // Crear los "claims" (datos de identidad del usuario)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

            // Crear la identidad y el principal (usuario autenticado)
            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);

            // Autenticar al usuario usando cookies
            await HttpContext.SignInAsync("CookieAuth", principal);

            // Redirigir a la página principal
            return RedirectToAction("Index", "Usuario");
        }

        // Si las credenciales son incorrectas, mostrar un error
        ViewBag.Error = "Usuario o contraseña incorrectos";
        return View();
    }

    // Acción: Cerrar sesión
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("CookieAuth");
        return RedirectToAction("Login");
    }

    // Acción protegida (requiere autenticación)
    [Authorize]
    public IActionResult Dashboard()
    {
        return View();
    }
}
