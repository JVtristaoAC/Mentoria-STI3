using Mentoria_STI3.ViewModel.Clientes;
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
    /// Interação lógica para UcClientes.xam
    /// </summary>
    public partial class UcClientes : UserControl
    {
        private UcClienteViewModel UcClienteVm = new UcClienteViewModel();

        public UcClientes()
        {
            InitializeComponent();

            DataContext = UcClienteVm;
            UcClienteVm.ClientesAdicionados = new ObservableCollection<ClienteViewModel>();
            UcClienteVm.DataNascimento = new DateTime(1990, 1, 1);
        }

        private void BtnAdcionar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCliente())
                return;


            if (UcClienteVm.Alteracao)
            {
                AlterarProduto();
            }
            else
            {

                AdicionarCliente();

            }

            LimparCampos();

        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = (sender as Button).Tag as ClienteViewModel;

            PreencherCampos(cliente);
        }

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {

        }
        private void LimparCampos()
        {
            UcClienteVm.Nome = "";
            UcClienteVm.DataNascimento = new DateTime(1990, 1, 1);
            UcClienteVm.Cep = 0;
            UcClienteVm.Endereco = "";
            UcClienteVm.Cidade = "";
            UcClienteVm.Alteracao = false;
        }

        private void PreencherCampos(ClienteViewModel cliente)
        {
            UcClienteVm.Nome = cliente.Nome;
            UcClienteVm.Cep = cliente.Cep;
            UcClienteVm.Endereco = cliente.Endereco;
            UcClienteVm.Cidade = cliente.Cidade;
            UcClienteVm.DataNascimento = cliente.DataNascimento;
            UcClienteVm.Alteracao = true;
        }

        private void AdicionarCliente()
        {
            var novoCliente = new ClienteViewModel
            {
                Nome = UcClienteVm.Nome,
                Cep = UcClienteVm.Cep,                
                Endereco = UcClienteVm.Endereco,
                Cidade = UcClienteVm.Cidade,
                DataNascimento = UcClienteVm.DataNascimento
            };
            UcClienteVm.ClientesAdicionados.Add(novoCliente);
        }

        private void AlterarProduto()
        {
            //Aula banco de dados
        }

        private bool ValidarCliente()
        {
            if (string.IsNullOrEmpty(UcClienteVm.Nome))
            {
                MessageBox.Show("O campo nome é obrigatório", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
