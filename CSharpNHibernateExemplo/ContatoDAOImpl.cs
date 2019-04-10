using System;
using System.Linq;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using CSharpNHibernateExemplo.Entities;

/* iagocolodetti */

namespace CSharpNHibernateExemplo
{
    class ContatoDAOImpl : ContatoDAO
    {
        public void Add(Contato contato)
        {
            ISession session = null;
            ITransaction tx = null;
            try
            {
                session = NHibernateUtil.GetOpenSession();
                if (NHibernateUtil.IsOpenSession(session))
                {
                    tx = session.BeginTransaction();
                    session.Save(contato);
                    tx.Commit();
                    session.Flush();
                }
                else
                {
                    throw new SessionException();
                }
            }
            catch (HibernateException e)
            {
                if (tx != null && !tx.WasCommitted)
                {
                    tx.Rollback();
                }
#if DEBUG
                Console.WriteLine(e.ToString());
#else
                Console.WriteLine("Não foi possível adicionar o contato.");
#endif
            }
            finally
            {
                NHibernateUtil.CloseSession(session);
            }
        }

        public Contato GetContato(int id)
        {
            ISession session = null;
            Contato contato = null;
            try
            {
                session = NHibernateUtil.GetOpenSession();
                if (NHibernateUtil.IsOpenSession(session))
                {
                    contato = session.Get<Contato>(id);
                    if (contato == null)
                    {
                        throw new ContatoNaoExisteException("Não existe contato com esse ID.");
                    }
                }
                else
                {
                    throw new SessionException();
                }
            }
            catch (HibernateException e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#else
                Console.WriteLine("Não foi possível buscar o contato.");
#endif
            }
            finally
            {
                NHibernateUtil.CloseSession(session);
            }
            return contato;
        }

        public List<Contato> GetContatosPorNome(string nome)
        {
            ISession session = null;
            List<Contato> contatos = null;
            try
            {
                session = NHibernateUtil.GetOpenSession();
                if (NHibernateUtil.IsOpenSession(session))
                {
                    contatos = (from contato in session.Query<Contato>() where SqlMethods.Like(contato.Nome, "%" + nome + "%") select contato).ToList();
                    if (contatos.Count == 0)
                    {
                        throw new ContatoNaoExisteException("Não existem contatos com esse nome ou parte dele.");
                    }
                }
                else
                {
                    throw new SessionException();
                }
            }
            catch (HibernateException e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#else
                Console.WriteLine("Não foi possível buscar os contatos.");
#endif
            }
            finally
            {
                NHibernateUtil.CloseSession(session);
            }
            return contatos;
        }

        public List<Contato> GetContatosPorTelefone(string telefone)
        {
            ISession session = null;
            List<Contato> contatos = null;
            try
            {
                session = NHibernateUtil.GetOpenSession();
                if (NHibernateUtil.IsOpenSession(session))
                {
                    contatos = (from contato in session.Query<Contato>() where SqlMethods.Like(contato.Telefone, "%" + telefone + "%") select contato).ToList();
                    if (contatos.Count == 0)
                    {
                        throw new ContatoNaoExisteException("Não existem contatos com esse nome ou parte dele.");
                    }
                }
                else
                {
                    throw new SessionException();
                }
            }
            catch (HibernateException e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#else
                Console.WriteLine("Não foi possível buscar os contatos.");
#endif
            }
            finally
            {
                NHibernateUtil.CloseSession(session);
            }
            return contatos;
        }

        public List<Contato> GetContatosPorEmail(string email)
        {
            ISession session = null;
            List<Contato> contatos = null;
            try
            {
                session = NHibernateUtil.GetOpenSession();
                if (NHibernateUtil.IsOpenSession(session))
                {
                    contatos = (from contato in session.Query<Contato>() where SqlMethods.Like(contato.Email, "%" + email + "%") select contato).ToList();
                    if (contatos.Count == 0)
                    {
                        throw new ContatoNaoExisteException("Não existem contatos com esse nome ou parte dele.");
                    }
                }
                else
                {
                    throw new SessionException();
                }
            }
            catch (HibernateException e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#else
                Console.WriteLine("Não foi possível buscar os contatos.");
#endif
            }
            finally
            {
                NHibernateUtil.CloseSession(session);
            }
            return contatos;
        }
        
        public List<Contato> GetContatos()
        {
            ISession session = null;
            List<Contato> contatos = null;
            try
            {
                session = NHibernateUtil.GetOpenSession();
                if (NHibernateUtil.IsOpenSession(session))
                {
                    contatos = (from contato in session.Query<Contato>() select contato).ToList();
                    if (contatos.Count == 0)
                    {
                        throw new ContatoNaoExisteException("Não existem contatos.");
                    }
                }
                else
                {
                    throw new SessionException();
                }
            }
            catch (HibernateException e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#else
                Console.WriteLine("Não foi possível buscar os contatos.");
#endif
            }
            finally
            {
                NHibernateUtil.CloseSession(session);
            }
            return contatos;
        }

        public void Update(Contato contato)
        {
            ISession session = null;
            ITransaction tx = null;
            try
            {
                session = NHibernateUtil.GetOpenSession();
                if (NHibernateUtil.IsOpenSession(session))
                {
                    tx = session.BeginTransaction();
                    session.Update(contato);
                    tx.Commit();
                    session.Flush();
                }
                else
                {
                    throw new SessionException();
                }
            }
            catch (HibernateException e)
            {
                if (!tx.WasCommitted)
                {
                    tx.Rollback();
                }
#if DEBUG
                Console.WriteLine(e.ToString());
#else
                Console.WriteLine("Não foi possível atualizar o contato.");
#endif
            }
            finally
            {
                NHibernateUtil.CloseSession(session);
            }
        }
        
        public void Delete(int id)
        {
            ISession session = null;
            ITransaction tx = null;
            try
            {
                session = NHibernateUtil.GetOpenSession();
                if (NHibernateUtil.IsOpenSession(session))
                {
                    tx = session.BeginTransaction();
                    session.Delete(GetContato(id));
                    tx.Commit();
                    session.Flush();
                }
                else
                {
                    throw new SessionException();
                }
            }
            catch (HibernateException e)
            {
                if (!tx.WasCommitted)
                {
                    tx.Rollback();
                }
#if DEBUG
                Console.WriteLine(e.ToString());
#else
                Console.WriteLine("Não foi possível deletar o contato.");
#endif
            }
            finally
            {
                NHibernateUtil.CloseSession(session);
            }
        }
    }
}
