using Mentoria_STI3.Business;
using MentoriaSTI3.ViewModel.Produtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace MentoriaSTI3.View.UserControls
{
    /// <summary>
    /// Interação lógica para UcProdutos.xam
    /// </summary>
    public partial class UcProdutos : UserControl
    {
        private UcProdutoViewModel UcProdutoVM = new UcProdutoViewModel();

        public UcProdutos()
        {
            InitializeComponent();

            DataContext = UcProdutoVM;
            CarrregarRegistros();
         
        }

        private void BtnAdcionar_Click(object sender, RoutedEventArgs e)
        {
            if(!ValidarProduto())
                return;


            if (UcProdutoVM.Alteracao)
            {
                AlterarProduto();
            }
            else
            {

                AdicionarProduto();

            }

            LimparCampos();
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            var produto = (sender as Button).Tag as ProdutoViewModel;

            PreencherCampos(produto);
        }
     
        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {
            var produto = (sender as Button).Tag as ProdutoViewModel;
            RemoverProduto(produto.Id);
        }

        private void txt_Valor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void LimparCampos()
        {
            UcProdutoVM.Id = 0;
            UcProdutoVM.Nome = "";
            UcProdutoVM.Valor = 0;    
            UcProdutoVM.Alteracao = false;
        }

        private void PreencherCampos(ProdutoViewModel produto)
        {
            UcProdutoVM.Id = produto.Id;
            UcProdutoVM.Nome = produto.Nome;
            UcProdutoVM.Valor = produto.Valor;
            UcProdutoVM.Alteracao = true;
        }

        private void CarrregarRegistros()
        {
            UcProdutoVM.ProdutosAdicionados = new ObservableCollection<ProdutoViewModel>(new ProdutoBusiness().Listar());
        }
        private bool ValidarProduto()
        {
            if (string.IsNullOrEmpty(UcProdutoVM.Nome))
            {
                MessageBox.Show("O campo nome é obrigatório", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;

        }
        private void AdicionarProduto()
        {
            var novoProduto = new ProdutoViewModel
            {
                Nome = UcProdutoVM.Nome,
                Valor = UcProdutoVM.Valor
            };

            new ProdutoBusiness().Adicionar(novoProduto);
            CarrregarRegistros();
        }

        private void AlterarProduto()
        {
            var produtoAlteracao = new ProdutoViewModel
            {
                Id = UcProdutoVM.Id,
                Nome = UcProdutoVM.Nome,
                Valor = UcProdutoVM.Valor
            };
            new ProdutoBusiness().Alterar(produtoAlteracao);
            CarrregarRegistros();
        }

        private void RemoverProduto(long id)
        {
            var resultado = MessageBox.Show("Deseja remover o Produto?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (resultado == MessageBoxResult.Yes)
            {
                new ProdutoBusiness().Remover(id);
                CarrregarRegistros();
                LimparCampos();
            }
        }

       

       
    }

    

    
}
