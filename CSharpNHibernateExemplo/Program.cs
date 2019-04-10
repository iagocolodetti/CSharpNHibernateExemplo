using System;
using System.Collections.Generic;
using CSharpNHibernateExemplo.Entities;

/* iagocolodetti */

namespace CSharpNHibernateExemplo
{
    class Program
    {
        private static ContatoDAOImpl contatoDAO = null;

        static void Main(string[] args)
        {
            contatoDAO = new ContatoDAOImpl();

            int opcao;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("..C# NHibernate Opções..");
                Console.WriteLine("1 -> Adicionar");
                Console.WriteLine("2 -> Buscar Por ID");
                Console.WriteLine("3 -> Buscar Por Nome");
                Console.WriteLine("4 -> Buscar Por Telefone");
                Console.WriteLine("5 -> Buscar Por E-mail");
                Console.WriteLine("6 -> Buscar Todos");
                Console.WriteLine("7 -> Alterar");
                Console.WriteLine("8 -> Deletar");
                Console.WriteLine("0 -> Encerrar");
                Console.Write("Opção..: ");
                TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine();
                        Encerrar();
                        break;
                    case 1:
                        Console.WriteLine();
                        Adicionar();
                        break;
                    case 2:
                        Console.WriteLine();
                        Buscar();
                        break;
                    case 3:
                        Console.WriteLine();
                        BuscarPorNome();
                        break;
                    case 4:
                        Console.WriteLine();
                        BuscarPorTelefone();
                        break;
                    case 5:
                        Console.WriteLine();
                        BuscarPorEmail();
                        break;
                    case 6:
                        Console.WriteLine();
                        BuscarTodos();
                        break;
                    case 7:
                        Console.WriteLine();
                        Alterar();
                        break;
                    case 8:
                        Console.WriteLine();
                        Deletar();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Opção Incorreta.");
                        break;
                }
            }
        }

        private static void Encerrar()
        {
            Console.WriteLine("Encerrado.");
            Console.Read();
            Environment.Exit(0);
        }

        private static void Adicionar()
        {
            Contato c = new Contato();
            Console.WriteLine("------------- [ADICIONAR] -------------");
            Console.Write("Nome: ");
            c.Nome = Console.ReadLine();
            Console.Write("Telefone: ");
            c.Telefone = Console.ReadLine();
            Console.Write("E-mail: ");
            c.Email = Console.ReadLine();
            try
            {
                contatoDAO.Add(c);
                Console.WriteLine("Contato \"" + c.Nome + " | " + c.Telefone + " | " + c.Email + "\" adicionado.");
            }
            catch (SessionException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------");
        }

        private static void Buscar()
        {
            Console.WriteLine("------------ [BUSCAR (ID)] ------------");
            Console.Write("ID: ");
            try
            {
                TryParse(Console.ReadLine(), out int id);
                Contato c = contatoDAO.GetContato(id);
                Console.WriteLine("Contato: (ID: " + c.Id + ") " + c.Nome + " | " + c.Telefone + " | " + c.Email);
            }
            catch (ContatoNaoExisteException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SessionException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------");
        }

        private static void BuscarPorNome()
        {
            Console.WriteLine("----------- [BUSCAR (NOME)] -----------");
            Console.Write("Nome: ");
            try
            {
                List<Contato> contatos = contatoDAO.GetContatosPorNome(Console.ReadLine());
                foreach (Contato c in contatos)
                {
                    Console.WriteLine("Contato: (ID: " + c.Id + ") " + c.Nome + " | " + c.Telefone + " | " + c.Email);
                }
            }
            catch (ContatoNaoExisteException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SessionException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------");
        }

        private static void BuscarPorTelefone()
        {
            Console.WriteLine("---------- [BUSCAR (TELEFONE)] ----------");
            Console.Write("Telefone: ");
            try
            {
                List<Contato> contatos = contatoDAO.GetContatosPorTelefone(Console.ReadLine());
                foreach (Contato c in contatos)
                {
                    Console.WriteLine("Contato: (ID: " + c.Id + ") " + c.Nome + " | " + c.Telefone + " | " + c.Email);
                }
            }
            catch (ContatoNaoExisteException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SessionException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------");
        }

        private static void BuscarPorEmail()
        {
            Console.WriteLine("---------- [BUSCAR (E-MAIL)] ----------");
            Console.Write("E-mail: ");
            try
            {
                List<Contato> contatos = contatoDAO.GetContatosPorEmail(Console.ReadLine());
                foreach (Contato c in contatos)
                {
                    Console.WriteLine("Contato: (ID: " + c.Id + ") " + c.Nome + " | " + c.Telefone + " | " + c.Email);
                }
            }
            catch (ContatoNaoExisteException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SessionException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------");
        }

        private static void BuscarTodos()
        {
            Console.WriteLine("----------- [BUSCAR (TODOS)] -----------");
            try
            {
                List<Contato> contatos = contatoDAO.GetContatos();
                foreach (Contato c in contatos)
                {
                    Console.WriteLine("Contato: (ID: " + c.Id + ") " + c.Nome + " | " + c.Telefone + " | " + c.Email);
                }
            }
            catch (ContatoNaoExisteException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SessionException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------");
        }

        private static void Alterar()
        {
            Contato c = new Contato();
            Console.WriteLine("-------------- [ALTERAR] --------------");
            Console.Write("ID: ");
            TryParse(Console.ReadLine(), out int id);
            c.Id = id;
            Console.Write("Novo nome: ");
            c.Nome = Console.ReadLine();
            Console.Write("Novo telefone: ");
            c.Telefone = Console.ReadLine();
            Console.Write("Novo e-mail: ");
            c.Email = Console.ReadLine();
            try
            {
                contatoDAO.Update(c);
                Console.WriteLine("Contato alterado com sucesso.");
            }
            catch (ContatoNaoExisteException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SessionException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------");
        }

        private static void Deletar()
        {
            Console.WriteLine("-------------- [DELETAR] --------------");
            Console.Write("ID: ");
            try
            {
                TryParse(Console.ReadLine(), out int id);
                contatoDAO.Delete(id);
                Console.WriteLine("Contato deletado com sucesso.");
            }
            catch (ContatoNaoExisteException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SessionException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------");
        }

        private static void TryParse(string s, out int n)
        {
            try
            {
                n = int.Parse(s);
            }
            catch (FormatException)
            {
                n = -1;
            }
        }
    }
}
