using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.Validaciones
{
    public class TipoArchivoValidacion: ValidationAttribute
    {
        private readonly string[] tiposValidos;

        public TipoArchivoValidacion(string[] tiposValidos)
        {
            this.tiposValidos = tiposValidos;
        }

        public TipoArchivoValidacion(GrupoTipoArchivo grupoTipoArchivo) 
        {
            if (grupoTipoArchivo == GrupoTipoArchivo.Imagen)
            {
                tiposValidos = new string[] { "image/png", "image/jpeg", "image/jpg", "image/gif" };
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (!tiposValidos.Contains(formFile.ContentType))
            {
                return new ValidationResult($"el tipo de archivo debe ser uno de los siguientes: {string.Join(", ", tiposValidos)}");
            }

            return ValidationResult.Success;
        }
    }
}
