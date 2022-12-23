﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoria_STI3.ViewModel.Clientes
{
    public class UcClienteViewModel : PropertyChange
    {
        private string _nome;
        public string Nome
        {
            get => _nome;
            set
            {
                _nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }

        private DateTime _dataNascimento;
        public DateTime DataNascimento
        {
            get => _dataNascimento;
            set
            {
                _dataNascimento = value;
                OnPropertyChanged(nameof(DataNascimento));
            }
        }

        private int _cep;
        public int Cep
        {
            get => _cep;
            set
            {
                _cep = value;
                OnPropertyChanged(nameof(Cep));
            }
        }

        private string _endereco;
        public string Endereco
        {
            get => _endereco;
            set
            {
                _endereco = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }

        private string _cidade;
        public string Cidade
        {
            get => _cidade;
            set
            {
                _cidade = value;
                OnPropertyChanged(nameof(Cidade));
            }
        }

        private ObservableCollection<ClienteViewModel> _clientesAdicionados;
        public ObservableCollection<ClienteViewModel> ClientesAdicionados
        {
            get => _clientesAdicionados;
            set
            {
                _clientesAdicionados = value;
                OnPropertyChanged(nameof(ClientesAdicionados));
            }
        }

        private bool _alteracao;
        public bool Alteracao
        {
            get => _alteracao;
            set
            {
                _alteracao = value;
                OnPropertyChanged(nameof(Alteracao));
            }
        }
    }
}
