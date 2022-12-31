using Mentoria_STI3.Business;
using Mentoria_STI3.ViewModel.Pedidos;
using MentoriaSTI3.ViewModel.Clientes;
using MentoriaSTI3.ViewModel.Pedido;
using MentoriaSTI3.ViewModel.Produtos;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MentoriaSTI3.View.UserControls
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

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnAdicionarItem_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarProduto())
                return;

            AdicionarItem();        
        }

        private void BtnFinalizarPedido_Click(object sender, RoutedEventArgs e)
        {
            FinalizarPedido();
        }

        private void InicializarOperacao()
        {
            DataContext = UcPedidoVM;

            UcPedidoVM.Quantidade = 1;

            UcPedidoVM.ItensAdicionados = new ObservableCollection<UcPedidoItemViewModel>();

            UcPedidoVM.ListaClientes = new ObservableCollection<ClienteViewModel>(new ClienteBusiness().Listar());

            UcPedidoVM.ListaProdutos = new ObservableCollection<ProdutoViewModel>(new ProdutoBusiness().Listar());

            UcPedidoVM.ListaPagamentos = new ObservableCollection<string>{
                "Dinheiro",
                "Boleto",
                "Cartão de Crédito",
                "Cartão de Débito",
                "Pix"
            };                         
        }

        private void AdicionarItem()
        {      
                var produtoSelecionado = CmbProduto.SelectedItem as ProdutoViewModel;
                var itemVM = new UcPedidoItemViewModel
                {
                    Nome = produtoSelecionado.Nome,
                    Quantidade = UcPedidoVM.Quantidade,
                    ValorUnit = UcPedidoVM.ValorUnit,
                    ValorTotalItem = UcPedidoVM.Quantidade * UcPedidoVM.ValorUnit,
                    ProdutoId = produtoSelecionado.Id
                    

                };
                UcPedidoVM.ItensAdicionados.Add(itemVM);
            UcPedidoVM.ValorTotalPedido = UcPedidoVM.ItensAdicionados.Sum(i => i.ValorTotalItem); LimparCamposProduto();
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
       
        private void FinalizarPedido()
        {
            var clienteSelecionado = CmbCliente.SelectedItem as ClienteViewModel;
            var PagamentoSelecionado = CmbPagamento.SelectedItem as string;
            var pedidoViewModel = new PedidoViewModel
            {
                ClienteId = clienteSelecionado.Id,
                FormaPagamento = PagamentoSelecionado,
                Valor = UcPedidoVM.ValorTotalPedido,
                ItensPedido = UcPedidoVM.ItensAdicionados.Select(x => new ItensPedidoViewModel
                {
                    ProdutoId = x.ProdutoId,
                    Quantidade = x.Quantidade,
                    Valor = x.ValorTotalItem
                }).ToList()
                 
            };
            new PedidoBusiness().Adicionar(pedidoViewModel);
            MessageBox.Show("Pedido Realizado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
            LimparTodosCampos();
        }

        private void LimparCamposProduto()
        {
            UcPedidoVM.Quantidade = 1;
            CmbProduto.SelectedItem = null;
            UcPedidoVM.ValorUnit = 0;
        }

        private void LimparTodosCampos()
        {
            UcPedidoVM.ItensAdicionados = new ObservableCollection<UcPedidoItemViewModel>();
            UcPedidoVM.ValorTotalPedido = 0;
            CmbCliente.SelectedItem = null;
            CmbPagamento.SelectedItem = null;
            LimparCamposProduto();
        }
    }
}
