using System.ComponentModel.DataAnnotations;
using TicketSystem.DTOs; 


namespace TicketSystem.Validations
{
    public class PasswordNotContainsUsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value, 
            ValidationContext validationContext 
        )
        {
            //Obtener el usuario (validar) 
            var usuario = (Usuario) validationContext.ObjectInstance; 

            //Obtener la contraseña
            string? password = value?.ToString();

            if ( string.IsNullOrEmpty(password) ||
                 string.IsNullOrEmpty(usuario.nombre_usuario)
            )
            {
                return ValidationResult.Success;
            }

            if (password.Contains(usuario.nombre_usuario, StringComparison.OrdinalIgnoreCase)){
                return new ValidationResult(
                        "La contraseña no puede contener el nombre de usuario"
                    );
            }

            return ValidationResult.Success;
            
        }
    }
}
