using Mentoria_STI3.ViewModel.Clientes;
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


        private ObservableCollection<ClienteViewModel> _listaCliente;
        public ObservableCollection<ClienteViewModel> ListaCliente
        {
            get => _listaCliente;
            set
            {
                _listaCliente = value;
                OnPropertyChanged(nameof(ListaCliente));
            }
        }

        private ObservableCollection<ProdutoViewModel> _listaProduto;
        public ObservableCollection<ProdutoViewModel> ListaProduto
        {
            get => _listaProduto;
            set
            {
                _listaProduto = value;
                OnPropertyChanged(nameof(ListaProduto));
            }
        }
       

         private ObservableCollection<string> _listaPagamentos;
        public ObservableCollection<string> ListaPagamentos
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

        private decimal _valorTotal;
        public decimal ValorTotal
        {
            get => _valorTotal;
            set
            {
                _valorTotal = value;
                OnPropertyChanged(nameof(ValorTotal));
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
