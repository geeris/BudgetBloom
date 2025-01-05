﻿using BudgetBloom.Application.Interfaces;
using BudgetBloom.DataAccess;
using BudgetBloom.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetBloom.Implementation.Services
{
    public class UserService(BudgetBloomContext db, IPasswordHasherService passwordService) : IUserService
    {
        public async Task<bool> UserExistsAsync(string email) // Not in use ATM
        {
            return await db.Users.AnyAsync(x => x.Email == email); // Users must have unique email
        }

        public async Task<bool> IsValidUserCredentialsAsync(string email, string password)
        {
            return await db.Users.AnyAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await db.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task RegisterUserAsync(User user)
        {
            user.Password = passwordService.HashPassword(user.Password);

            db.Users.Add(user);
            await db.SaveChangesAsync();
        }
    }
}