using BaiTestPhuHung.Commands.UserCommand;
using BaiTestPhuHung.Data;
using BaiTestPhuHung.Models;
using BaiTestPhuHung.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.RegularExpressions;
using System.Text;

namespace BaiTestPhuHung.Handlers.UserAuth
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IRepository<User> _repository;

        public RegisterUserHandler(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Token = request.Token,
                UserName = request.UserName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            if (await _repository.CheckEmailExistAsync(user))
                return ("Email Already Exist");

            if (await _repository.CheckUserNameExistAsync(user))
                return ("Username Already Exist");

            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync(cancellationToken);

            return "User registered successfully";
        }

        private static string CheckPasswordStrength(string pass)
        {
            StringBuilder sb = new StringBuilder();
            if (pass.Length < 9)
                sb.Append("Minimum password length should be 8" + Environment.NewLine);
            if (!(Regex.IsMatch(pass, "[a-z]") && Regex.IsMatch(pass, "[A-Z]") && Regex.IsMatch(pass, "[0-9]")))
                sb.Append("Password should be AlphaNumeric" + Environment.NewLine);
            if (!Regex.IsMatch(pass, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
                sb.Append("Password should contain special charcter" + Environment.NewLine);
            return sb.ToString();
        }

    }
}
