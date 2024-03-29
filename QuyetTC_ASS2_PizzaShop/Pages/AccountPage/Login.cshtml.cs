﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuyetTC_ASS2_Repository.Implementations;
using QuyetTC_ASS2_Repository.Models;
using QuyetTC_ASS2_Repository.Repository;
using System.ComponentModel.DataAnnotations;

namespace QuyetTC_ASS2_PizzaShop.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }

        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        public void OnGet()
        {
            //this.Credential = new Credential { Username = "tranquyet" };
        }

        public IActionResult OnPost() {
            bool isAuthenticated = unitOfWork.AccountRepository.Find(a => a.UserName == Credential.Username && a.Password == Credential.Password).Any();

            if (isAuthenticated)
            {
                HttpContext.Session.SetString("UserId", Credential.Username.ToString());
                HttpContext.Session.SetString("UserName", Credential.Password.ToString());
                return RedirectToPage("/Index"); // Chuyển hướng đến trang chính sau khi đăng nhập thành công
            }
            else { 
            
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return Page(); // Trở lại trang đăng nhập
            }
        }

        
    }

    public class Credential
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }

    }
}
