using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoriaSTI3.ViewModel.Pedido
{
    public class UcPedidoItemViewModel
    {
        public string Nome { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnit { get; set; }
        public decimal ValorTotalItem { get; set; }
        public decimal ValorTotalPedido { get; set; }
    }
}
