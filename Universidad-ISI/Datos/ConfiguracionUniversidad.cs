using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Universidad_ISI.Datos
{
    public class ConfiguracionUniversidad : DbConfiguration
    {
        public ConfiguracionUniversidad()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());
        }
    }
}