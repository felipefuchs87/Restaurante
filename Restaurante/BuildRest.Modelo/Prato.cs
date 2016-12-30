using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;


namespace BuildRest.Modelo
{
  public  class Prato
    {
        public int PratoId { get; set; }

        public string PratoNome { get; set; }

        public int RestauranteId { get; set; }
        public virtual Restaurante Restaurante { get; set; }
     
    }
}
