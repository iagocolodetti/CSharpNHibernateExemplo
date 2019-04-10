using System;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace CSharpNHibernateExemplo
{
    class NHibernateUtil
    {
        private const string SERVER = "localhost",
                             PORT = "3306",
                             DATABASE = "contatodb",
                             UID = "root",
                             PWD = "root";

        private static ISessionFactory SESSION_FACTORY;

        static NHibernateUtil()
        {
            try
            {
                IPersistenceConfigurer dbConfig = MySQLConfiguration.Standard.ConnectionString("SERVER=" + SERVER + ";PORT=" + PORT + ";DATABASE=" + DATABASE + ";UID=" + UID + ";PWD=" + PWD + ";");

                var mapConfig = Fluently.Configure().Database(dbConfig).Mappings(c => c.FluentMappings.AddFromAssemblyOf<Mapping.ContatoMap>());

                SESSION_FACTORY = mapConfig.BuildSessionFactory();
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#endif
            }
        }
        
        public static ISession GetOpenSession()
        {
            ISession session = null;
            try
            {
                session = SESSION_FACTORY.OpenSession();
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#endif
            }
            return session;
        }

        public static bool IsOpenSession(ISession session)
        {
            return session != null && session.IsOpen;
        }

        public static void CloseSession(ISession session)
        {
            try
            {
                if (session != null)
                {
                    session.Close();
                }
            }
            catch (HibernateException e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#endif
            }
        }
    }
}
