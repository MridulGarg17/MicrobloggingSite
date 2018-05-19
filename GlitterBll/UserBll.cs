using DTOs;
using GlitterDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterBll
{
    public class UserBll
    {
        UserOperation operationOnUser;


        public void Signup(SignupDto newUser) {
            operationOnUser = new UserOperation();

            operationOnUser.Signup(newUser);


        }

        public UserDto Login(LoginDto User) {

            operationOnUser = new UserOperation();
           return (operationOnUser.Signin(User));
            
        }

    }
}
