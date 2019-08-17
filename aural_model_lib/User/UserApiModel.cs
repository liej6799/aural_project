using aural_lib.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace aural_model_lib.User
{
    public class UserApiModel
    {
        public class UserApiRegisterModel
        {
            // Id is not required as it will be
            // generated automatically
            public string Id { get; set; }
            [Required]
            public string Username { get; set; }
            [Required]
            public string Password { get; set; }

            public void Validation()
            {
                // Validate the data provided earlier
                
            }
        }

        // Second Validatiion
        public class UserApiRegisterModelValidation : AbstractValidator<UserApiRegisterModel>
        {
            public UserApiRegisterModelValidation()
            {
                RuleFor(username => username.Username).NotNull();
                RuleFor(password => password.Password).NotNull()
                    .MinimumLength(8).WithErrorCode(Properties.Resources.user_api_password_less_character)
                    .Matches(GlobalRegex.PasswordRegex).WithErrorCode(Properties.Resources.user_api_password_not_strong);
            }
        }
    }
}
