﻿using JetstreamService.Services;
using Microsoft.AspNetCore.Mvc;
using JetstreamService.Models; // Stelle sicher, dass LoginModel hier importiert wird.

namespace JetstreamService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly IUserService _userService; // Service zur Benutzerüberprüfung

        public LoginController(JwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Überprüfen der Benutzeranmeldedaten
            var user = _userService.ValidateUser(model.Username, model.Password);

            if (user == null)
            {
                return Unauthorized("Ungültiger Benutzername oder Passwort");
            }

            // JWT-Token generieren
            var token = _jwtService.GenerateJwtToken(user.Username);
            return Ok(new { Token = token });
        }
    }
}
