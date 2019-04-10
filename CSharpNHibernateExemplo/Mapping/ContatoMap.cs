using FluentNHibernate.Mapping;
using CSharpNHibernateExemplo.Entities;

namespace CSharpNHibernateExemplo.Mapping
{
    class ContatoMap : ClassMap<Contato>
    {
        public ContatoMap() {
            Id(c => c.Id);
            Map(c => c.Nome);
            Map(c => c.Telefone);
            Map(c => c.Email);
            Table("Contato");
        }
    }
}
