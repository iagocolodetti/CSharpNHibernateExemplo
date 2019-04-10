using System;

/* iagocolodetti */

namespace CSharpNHibernateExemplo
{
    [Serializable]
    class ContatoNaoExisteException : Exception
    {
        public ContatoNaoExisteException()
            : base("Contato não existe.")
        {

        }

        public ContatoNaoExisteException(string message)
            : base(message)
        {

        }
    }
}
