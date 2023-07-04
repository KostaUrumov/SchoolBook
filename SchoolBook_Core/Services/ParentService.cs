﻿using Microsoft.AspNetCore.Identity;
using SchoolBook_Core.Models.Teacher;
using SchoolBook_Core.Models.UserModels;
using SchoolBook_Structure.Data;
using SchoolBook_Structure.Entities;

namespace SchoolBook_Core.Services
{
    public class ParentService
    {
        private readonly SchoolBookDb data;
        UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;


        public ParentService(SchoolBookDb _data, UserManager<User> _userManager, SignInManager<User> _signInManager)
        {
            data = _data;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public List<ParentViewModel> GetAllParents()
        {
            List<ParentViewModel> models = data
                .Parents
                .Select(p => new ParentViewModel
                {
                    FirstName = p.User.FirstName,
                    LastName = p.User.LastName
                })
                .ToList();
            return models;
        }

        public async Task AddParent(RegisterParentModel model)
        {
            User user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                UserName = model.Username,
                PasswordHash = model.Password.ToString(),
                NormalizedUserName = model.Username.ToUpper()
            };
            await userManager.CreateAsync(user);
            Parent parent = new Parent()
            {
                Id = user.Id,

                MyKids = new List<Student>()
            };
            await data.Parents.AddAsync(parent);
            await data.SaveChangesAsync();
        }
    }
}