﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.MiddleTier.Interface;
using Back.Models;
using Back.Repositorys.Interface;
using Microsoft.AspNetCore.Identity;
using SharedAll.Models;
using SharedAll.Models.Result;

namespace Back.MiddleTier
{
    public class LoginServices: ILoginServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginServices(
          IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthenticationResult> RegisterAsync(string email, string password)
        {
            
            var existingUser = await _unitOfWork.UserManager.FindByEmailAsync(email);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Result = "User with this email address already exists"
                };
            }

            var newUserId = Guid.NewGuid();
            var newUser = new User
            {
                Id = newUserId.ToString(),
                Email = email,
                UserName = email
            };
            
            var createdUser = await _unitOfWork.UserManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Result = "Errors"
                };
            }
            
            return new AuthenticationResult
            {
                Result = "Success"
            };
        }

        public async Task<SignInResult> Login(LoginViewModel model)
        {
            var result =
                await _unitOfWork.SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            return result;
        }




    }
}
