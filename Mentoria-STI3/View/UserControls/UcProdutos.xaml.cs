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
            UcProdutoVM.ProdutosAdicionados = new ObservableCollection<ProdutoViewModel>();
            //Exemplo de Adicionar produtos
            //UcProdutoVM.ProdutosAdicionados = new ObservableCollection<ProdutoViewModel>
            //{
            //    new ProdutoViewModel {Nome = "Tênis", Valor = 70},
            //    new ProdutoViewModel {Nome = "Camiseta", Valor = 40},
            //    new ProdutoViewModel {Nome = "Shorts", Valor = 25}

            //};
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

        }

        private void txt_Valor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void LimparCampos()
        {
            UcProdutoVM.Nome = "";
            UcProdutoVM.Valor = 0;
            UcProdutoVM.Alteracao = false;
        }

        private void PreencherCampos(ProdutoViewModel produto)
        {
            UcProdutoVM.Nome = produto.Nome;
            UcProdutoVM.Valor = produto.Valor;
            UcProdutoVM.Alteracao = true;
        }

        private void AdicionarProduto()
        {
            var novoProduto = new ProdutoViewModel
            {
                Nome = UcProdutoVM.Nome,
                Valor = UcProdutoVM.Valor
            };
            UcProdutoVM.ProdutosAdicionados.Add(novoProduto);
        }

        private void AlterarProduto()
        {
            //Aula banco de dados
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

       
    }

    

    
}
