using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioNetCore.Web.Models
{
    [Table("Alumno")]
    public class AlumnoEntity
    {
        [Key]
        public int NumeroCuenta { get; set; }
        public string Nip { get; set;}
        public int Grado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

    }
}
