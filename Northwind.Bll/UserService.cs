using Northwind.Bll.Base;
using Northwind.Dal.Abstract;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entity.Base;
using Microsoft.AspNetCore.Http;
using Northwind.Entity.IBase;
using Microsoft.Extensions.Configuration;

namespace Northwind.Bll
{
    public class UserService : BllBase<User, DtoUser>, IUserService
    {
        private readonly IUserRepository _userRepository;
        IConfiguration _configuration;

        public UserService(IServiceProvider serviceProvider, IConfiguration configuration) : base(serviceProvider)
        {
            _userRepository = serviceProvider.GetService<IUserRepository>();
            _configuration = configuration;
        }

        public IResponse<DtoUserToken> Login(DtoLogin loginUser)
        {
            loginUser.Password = loginUser.Password.Md5();

            var user = _userRepository.Login(ObjectMapper.Mapper.Map<User>(loginUser));

            if (user != null)
            {
                var dtoUser = ObjectMapper.Mapper.Map<DtoUser>(user);

                if (dtoUser != null)
                {
                    var token = new TokenService(_configuration).CreateAccessToken(dtoUser);

                    var userToken = new DtoUserToken()
                    {
                        DtoUser = dtoUser,
                        AccessToken = token
                    };

                    return new Response<DtoUserToken>
                    {
                        Data = userToken,
                        Message = "Token is success ",
                        StatusCode = StatusCodes.Status200OK
                    };
                }
            }

            return new Response<DtoUserToken>
            {
                Data = null,
                Message = "UserCode or Password wrong !",
                StatusCode = StatusCodes.Status406NotAcceptable
            };
        }

        public IResponse<DtoUser> Register(DtoRegister registerUser)
        {
            if (registerUser == null)
            {
                return new Response<DtoUser>
                {
                    Data = null,
                    Message = "Register user cannot be null.",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            var existsUser = Any(a => a.UserCode == registerUser.UserCode);
            if (existsUser)
            {
                return new Response<DtoUser>
                {
                    Data = null,
                    Message = "User code already exists.",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            if (string.IsNullOrEmpty(registerUser.UserCode) || string.IsNullOrEmpty(registerUser.Password))
            {
                return new Response<DtoUser>
                {
                    Data = null,
                    Message = "User code or password cannot be null.",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            if (registerUser.Password != registerUser.RePassword)
            {
                return new Response<DtoUser>
                {
                    Data = null,
                    Message = "Password and RePassword must be the same.",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            registerUser.Password = registerUser.Password.Md5();

            var dtoUser = new DtoUser()
            {
                Password = registerUser.Password,
                UserCode = registerUser.UserCode,
                UserLastName = registerUser.UserLastName,
                UserName = registerUser.UserName
            };

            return Add(dtoUser);
        }
    }
}
