using System.Configuration;
using Bookwarm.Models;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;

namespace Bookwarm.Infrastructure
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var autoMap = AutoMap.AssemblyOf<Entity>().Where(t => typeof (Entity).IsAssignableFrom(t));

                    _sessionFactory = Fluently.Configure()
                        .Database(
                            MsSqlConfiguration.MsSql2008.ConnectionString(
                                ConfigurationManager.ConnectionStrings["context"].ConnectionString))
                        .Mappings(m => m.AutoMappings.Add(autoMap))
                        .ExposeConfiguration(TreatConfiguration)
                        .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        private static void TreatConfiguration(Configuration configuration)
        {
            var update = new SchemaUpdate(configuration);
            update.Execute(false, true);
        }
    }
}