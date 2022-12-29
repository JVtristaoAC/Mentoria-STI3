using MentoriaSTI3.View.UserControls;
using MentoriaSTI3.Data.Context;
using System.Windows;
using System.Windows.Controls;

namespace MentoriaSTI3.View
{
    /// <summary>
    /// Lógica interna para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
            //Apenas para Desenvolvimento (Lentidão)
            AplicarMigracoes();


        }

        public void AplicarMigracoes()
        {
            using var context = new MentoriaDevSTI3Context();
            context.AplicarMigracoes();
        }
        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            InicializarUc(sender);
        }


        private void InicializarUc(object sender)
        {
            if(sender is Button btn)
            {
                switch (btn.Name)
                {
                    case nameof(BtnProdutos):
                        Conteudo.Content = new UcProdutos();
                        break;

                    case nameof(BtnClientes):
                        Conteudo.Content = new UcClientes();
                        break;

                    case nameof(BtnPedidos):
                        Conteudo.Content = new UcPedidos();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
