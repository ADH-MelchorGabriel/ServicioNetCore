using Microsoft.EntityFrameworkCore;
using ServicioNetCore.Web.Models;

namespace ServicioNetCore.Web.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<AlumnoEntity> Alumnos{ get; set; }
    }
}
