using Mentoria_STI3.Business;
using Mentoria_STI3.ViewModel.Clientes;
using MentoriaSTI3.ViewModel.Clientes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
    /// Interação lógica para UcClientes.xam
    /// </summary>
    public partial class UcClientes : UserControl
    {
        private UcClienteViewModel UcClienteVM = new UcClienteViewModel();

        public UcClientes()
        {
            InitializeComponent();

            DataContext = UcClienteVM;
            UcClienteVM.DataNascimento = new DateTime(1990, 1, 1);
            CarrregarRegistros();
           
        }

        private void BtnAdcionar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCliente())
                return;


            if (UcClienteVM.Alteracao)
            {
                AlterarCliente();
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
            var cliente = (sender as Button).Tag as ClienteViewModel;
            RemoverCliente(cliente.Id);
    
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void TxtCep_LostFocus(object sender, RoutedEventArgs e)
        {
            BuscarCep((sender as TextBox).Text);
        }
        private void BuscarCep(string cep)
        {
            //https://viacep.com.br/ws/01001000/json/
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://viacep.com.br/")
            };

            var response = client.GetAsync($"ws/{cep}/json/").Result;
            if (response.IsSuccessStatusCode)
            {
                var enderecoCompleto = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<EnderecoViewModel>(enderecoCompleto);

                if (obj.Erro)
                {
                    MessageBox.Show("O CEP não existe.", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    LimparEndereco();
                }
                else
                {
                    UcClienteVM.Endereco = $"{obj.Localidade} - {obj.Bairro}";
                    UcClienteVM.Cidade = $"{obj.Localidade}/{obj.Uf}";
                }
                
            }
            else
            {
                MessageBox.Show("O CEP é inválido.", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimparEndereco();
            }
        }

        private void LimparEndereco()
        {
            UcClienteVM.Endereco = "";
            UcClienteVM.Cidade = "";
            UcClienteVM.Cep = "";
        }
        private void CarrregarRegistros()
        {
            UcClienteVM.ClientesAdicionados = new ObservableCollection<ClienteViewModel>(new ClienteBusiness().Listar());
        }
        private void LimparCampos()
        {
            UcClienteVM.Id = 0;
            UcClienteVM.Nome = "";
            UcClienteVM.DataNascimento = new DateTime(1990, 1, 1);
            UcClienteVM.Cep = "";
            UcClienteVM.Endereco = "";
            UcClienteVM.Cidade = "";
            UcClienteVM.Alteracao = false;
        }

        private void PreencherCampos(ClienteViewModel cliente)
        {
            UcClienteVM.Id = cliente.Id;
            UcClienteVM.Nome = cliente.Nome;
            UcClienteVM.Cep = cliente.Cep;
            UcClienteVM.Endereco = cliente.Endereco;
            UcClienteVM.Cidade = cliente.Cidade;
            UcClienteVM.DataNascimento = cliente.DataNascimento;
            UcClienteVM.Alteracao = true;
        }

        private void AdicionarCliente()
        {
            var novoCliente = new ClienteViewModel
            {
                Nome = UcClienteVM.Nome,
                Cep = UcClienteVM.Cep,                
                Endereco = UcClienteVM.Endereco,
                Cidade = UcClienteVM.Cidade,
                DataNascimento = UcClienteVM.DataNascimento
            };
           
            new ClienteBusiness().Adicionar(novoCliente);
            CarrregarRegistros();
        }

        private void AlterarCliente()
        {
            var clienteAlteracao = new ClienteViewModel
            {
                Id = UcClienteVM.Id,
                Nome = UcClienteVM.Nome,
                Cep = UcClienteVM.Cep,
                Endereco = UcClienteVM.Endereco,
                Cidade = UcClienteVM.Cidade,
                DataNascimento = UcClienteVM.DataNascimento
            };
            new ClienteBusiness().Alterar(clienteAlteracao);
            CarrregarRegistros();
        }
        private void RemoverCliente(long id)
        {
            var resultado = MessageBox.Show("Deseja remover o Cliente?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (resultado == MessageBoxResult.Yes)
            {
                new ClienteBusiness().Remover(id);
                CarrregarRegistros();
                LimparCampos();
            }
        }
        private bool ValidarCliente()
        {
            if (string.IsNullOrEmpty(UcClienteVM.Nome))
            {
                MessageBox.Show("O campo nome é obrigatório", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;

        }

        
    }

   
}
