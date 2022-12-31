using Mentoria_STI3.ViewModel.Pedidos;
using MentoriaSTI3.Data.Context;
using MentoriaSTI3.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoria_STI3.Business
{
    public class PedidoBusiness
    {
        private readonly MentoriaDevSTI3Context _context;

        public PedidoBusiness()
        {
            _context = new MentoriaDevSTI3Context();
        }

        public void Adicionar(PedidoViewModel pedidoViewModel)
        {
            var pedido = new Pedido
            {
                ClienteId = pedidoViewModel.ClienteId,
                Valor = pedidoViewModel.Valor,
                FormaPagamento = pedidoViewModel.FormaPagamento,
                ItensPedido = pedidoViewModel.ItensPedido.Select(x => new ItemPedido
                {
                    ProdutoId = x.ProdutoId,
                    Quantidade = x.Quantidade,
                    Valor = x.Valor

                }).ToList()
               
            };

            _context.SaveChanges();
            
        }

       
    }
}
