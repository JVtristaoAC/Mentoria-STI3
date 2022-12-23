using Mentoria_STI3.ViewModel.Clientes;
using Mentoria_STI3.ViewModel.Pagamentos;
using Mentoria_STI3.ViewModel.Pedido;
using Mentoria_STI3.ViewModel.Produtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mentoria_STI3.View.UserControls
{
    /// <summary>
    /// Interação lógica para UcPedido.xam
    /// </summary>
    public partial class UcPedidos : UserControl
    {
        private UcPedidoViewModel UcPedidoVM = new UcPedidoViewModel();

        public UcPedidos()
        {
            InitializeComponent();
            InicializarOperacao();
        }

        private void CmbProduto_DropDownClosed(object sender, EventArgs e)
        {
            if(sender is ComboBox cmb && cmb.SelectedItem is ProdutoViewModel produto)
            {
                UcPedidoVM.ValorUnit = produto.Valor;
            }
        }

        private void BtnAdicionarItem_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidarProduto())
                return;

            AdicionarItem();
            LimparCampos();
        }

        private void BtnFinalizarPedido_Click(object sender, RoutedEventArgs e)
        {
            LimparCampos();
        }

        private void InicializarOperacao()
        {
            DataContext = UcPedidoVM;
            UcPedidoVM.ListaClientes = new ObservableCollection<ClienteViewModel>
            {
                new ClienteViewModel{ Nome = "Cliente 1"},
                new ClienteViewModel{ Nome = "Cliente 2"}
            };

            UcPedidoVM.ListaProdutos = new ObservableCollection<ProdutoViewModel>
            {
                new ProdutoViewModel{ Nome = "Produto 1", Valor = 10},
                new ProdutoViewModel{ Nome = "Produto 2", Valor = 20}
            };

            UcPedidoVM.ListaPagamentos = new ObservableCollection<PagamentoViewModel>
            {
                new PagamentoViewModel{ Nome = "Dinheiro"},
                new PagamentoViewModel{ Nome = "Boleto"},
                new PagamentoViewModel{ Nome = "Cartão de Crédito"},
                new PagamentoViewModel{ Nome = "Cartão de Débito"},
                new PagamentoViewModel{ Nome = "Pix"}
            };

            UcPedidoVM.Quantidade = 1;
            UcPedidoVM.ItensAdicionados = new ObservableCollection<UcPedidoItemViewModel>();
        }

        private void AdicionarItem()
        {
            
                var produtoSelecionado = CmbProduto.SelectedItem as ProdutoViewModel;
                var itemVM = new UcPedidoItemViewModel
                {
                    Nome = produtoSelecionado.Nome,
                    Quantidade = UcPedidoVM.Quantidade,
                    ValorUnit = UcPedidoVM.ValorUnit,
                    ValorTotalItem = UcPedidoVM.Quantidade * UcPedidoVM.ValorUnit

                };
                UcPedidoVM.ItensAdicionados.Add(itemVM);
                UcPedidoVM.ValorTotalPedido = UcPedidoVM.ItensAdicionados.Sum(i => i.ValorTotalItem);
            
           

           
        }

        private bool ValidarProduto()
        {
            if (string.IsNullOrEmpty(CmbProduto.Text) || string.IsNullOrEmpty(CmbPagamento.Text))
            {
                MessageBox.Show("O campo Produto e Pagamento são obrigatórios", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;

        }
        private void LimparCampos()
        {
            UcPedidoVM.Quantidade = 1;
            CmbProduto.SelectedItem = null;
            CmbCliente.SelectedItem = null;
            CmbPagamento.SelectedItem = null;

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
