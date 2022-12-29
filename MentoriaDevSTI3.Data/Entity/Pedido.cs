using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoriaDevSTI3.Data.Entity
{
    public class Pedido
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public string FormaPagamento { get; set; }  
        public decimal Valor { get; set; }  
        public Cliente Cliente { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
    }
}
