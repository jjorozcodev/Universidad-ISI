using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;

namespace Universidad_ISI.Datos
{
    public class ConfiguracionUniversidad : DbConfiguration
    {
        public ConfiguracionUniversidad()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());

            DbInterception.Add(new UniversidadInterceptorTransientErrors());
            DbInterception.Add(new UniversidadInterceptorLogging());
    }
    }
}