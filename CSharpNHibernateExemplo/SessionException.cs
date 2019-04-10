using System;

namespace CSharpNHibernateExemplo
{
    [Serializable]
    class SessionException : Exception
    {
        public SessionException()
            : base("Não foi possível criar ou abrir a sessão.")
        {

        }

        public SessionException(string message)
            : base(message)
        {

        }
    }
}
