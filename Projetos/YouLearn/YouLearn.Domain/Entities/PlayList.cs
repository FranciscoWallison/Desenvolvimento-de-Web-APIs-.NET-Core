using System;

namespace YouLearn.Domain.Entities
{
    public class PlayList
    {
        public Guid Id { get; set; }
        public User User { get; set; }       
        //Em Analise, Aprovado ou Recusado
        public string Status { get; set; }
    }
}