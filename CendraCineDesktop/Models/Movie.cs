using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CendraCineDesktop.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public string Trailer { get; set; }
        public string Cover { get; set; }
        public int RecommendedAge { get; set; } = 0;
        public float Rating { get; set; } = 0;

        public override string ToString()
        {
            return $"Nom: {Name} Trailer: {Trailer} Portada: {Cover} Rating: {Rating}";
        }
    }
}
