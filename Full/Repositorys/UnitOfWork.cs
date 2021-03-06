﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Context;
using Back.Models;
using Back.Repositorys.Interface;
using SharedAll.Models;

namespace Back.Repositorys
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext db;

        public UserManager<User> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public SignInManager<User> SignInManager { get; private set; }

        public UnitOfWork(ApplicationContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager
        )
        {
            db = context;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                }
                this.disposed = true;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
