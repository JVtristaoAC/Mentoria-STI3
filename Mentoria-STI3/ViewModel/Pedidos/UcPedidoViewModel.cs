using Mentoria_STI3.ViewModel.Clientes;
using Mentoria_STI3.ViewModel.Pagamentos;
using Mentoria_STI3.ViewModel.Produtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoria_STI3.ViewModel.Pedido
{
    public class UcPedidoViewModel : PropertyChange
    {


        private ObservableCollection<ClienteViewModel> _listaClientes;
        public ObservableCollection<ClienteViewModel> ListaClientes
        {
            get => _listaClientes;
            set
            {
                _listaClientes = value;
                OnPropertyChanged(nameof(ListaClientes));
            }
        }

        private ObservableCollection<ProdutoViewModel> _listaProdutos;
        public ObservableCollection<ProdutoViewModel> ListaProdutos
        {
            get => _listaProdutos;
            set
            {
                _listaProdutos = value;
                OnPropertyChanged(nameof(ListaProdutos));
            }
        }
       

         private ObservableCollection<PagamentoViewModel> _listaPagamentos;
        public ObservableCollection<PagamentoViewModel> ListaPagamentos
        {
            get => _listaPagamentos;
            set
            {
                _listaPagamentos = value;
                OnPropertyChanged(nameof(ListaPagamentos));
            }
        }

        private decimal _quantidade;
        public decimal Quantidade
        {
            get => _quantidade;
            set
            {
                _quantidade = value;
                OnPropertyChanged(nameof(Quantidade));
            }
        }

        private decimal _valorUnit;
        public decimal ValorUnit
        {
            get => _valorUnit;
            set
            {
                _valorUnit = value;
                OnPropertyChanged(nameof(ValorUnit));
            }
        }

        

        private decimal _valorTotalPedido;
        public decimal ValorTotalPedido
        {
            get => _valorTotalPedido;
            set
            {
                _valorTotalPedido = value;
                OnPropertyChanged(nameof(ValorTotalPedido));
            }
        }


        private ObservableCollection<UcPedidoItemViewModel> _itensAdicionados;
        public ObservableCollection<UcPedidoItemViewModel> ItensAdicionados
        {
            get => _itensAdicionados;
            set
            {
                _itensAdicionados = value;
                OnPropertyChanged(nameof(ItensAdicionados));

            }
        }
    }
}
