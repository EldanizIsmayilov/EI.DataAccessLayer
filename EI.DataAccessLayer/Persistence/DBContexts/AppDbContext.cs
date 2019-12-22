using EI.DataAccessLayer.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EI.DataAccessLayer.Persistence.DBContexts
{
    public class AppDbContext : DbContext
    {
        private readonly Dictionary<Type, object> _dbSets;

        public AppDbContext() : base("name = AppDbContext")
        {
            _dbSets = new Dictionary<Type, object>();
#if DEBUG
            Database.Log = Log;
#endif
            Database.SetInitializer<AppDbContext>(null);
        }


        public void Log(string query)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Query.txt"), query);
        }

        public void ExecuteSqlCommand(string sql, params object[] parameters)
        {
            string command = $"BEGIN {sql}; END;";
            this.Database.ExecuteSqlCommand(command, parameters);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            IEnumerable<Type> mappingClasses = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => !x.IsAbstract && !x.IsInterface && typeof(IEntityConfiguration).IsAssignableFrom(x));


            foreach (Type mappingClass in mappingClasses)
            {
                dynamic mappingInstance = Activator.CreateInstance(mappingClass);
                modelBuilder.Configurations.Add(mappingInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
