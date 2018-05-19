﻿using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterDll
{
   public class UserOperation
    {
        private GlitterdbEntities glitteDb = new GlitterdbEntities();

        /// <summary>
        /// Signups the specified new user.
        /// </summary>
        /// <param name="newUser">The new user.</param>
        /// <returns></returns>
        public bool Signup(SignupDto newUser) {
            User user = new User();

            var checkUser = glitteDb.Users.Where(i => i.Email == newUser.Email).Single();

            if (checkUser == null)
            {

                user.Firstname = newUser.Firstname;
                user.Lastname = newUser.Lastname;
                user.Image = newUser.Image;
                user.Country_id = newUser.Country_id;
                user.Email = newUser.Email;
                user.Password = newUser.Password;

                glitteDb.Users.Add(user);
                glitteDb.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Signins the specified user request.
        /// </summary>
        /// <param name="userRequest">The user request.</param>
        /// <returns></returns>
        public int Signin(LoginDto userRequest) {

            var user = glitteDb.Users.Where(i => i.Email == userRequest.Email).Single();

            if (user != null) {

                if (user.Password == userRequest.Password)
                {
                    return user.id;
                }
                else {
                    return 0;
                }
            }
            return 0;
        } 

    }
}
