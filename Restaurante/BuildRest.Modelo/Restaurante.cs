using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildRest.Modelo
{
    public class Restaurante
    {
        public Restaurante()
            {
                //Pratos = new List<Prato>();
                Pratos = new HashSet<Prato>();
            }
        public int RestauranteId { get; set; }

        public string RestauranteNome { get; set; }

        public virtual ICollection<Prato> Pratos { get; set; }



    }
}
