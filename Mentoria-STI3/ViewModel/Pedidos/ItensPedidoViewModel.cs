using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoria_STI3.ViewModel.Pedidos
{
    public class ItensPedidoViewModel
    {
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }  
    }
}
