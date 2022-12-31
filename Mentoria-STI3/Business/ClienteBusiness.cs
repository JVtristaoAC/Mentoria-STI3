using MentoriaSTI3.Data.Context;
using MentoriaSTI3.Data.Entity;
using MentoriaSTI3.ViewModel.Clientes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Mentoria_STI3.Business
{
    public class ClienteBusiness
    {
        private readonly MentoriaDevSTI3Context _context;

        public ClienteBusiness()
        {
            _context = new MentoriaDevSTI3Context();
        }

        public void Adicionar(ClienteViewModel clienteViewModel)
        {
            _context.Clientes.Add( new Cliente
            {
                Nome = clienteViewModel.Nome,
                DataNascimento = clienteViewModel.DataNascimento,
                Cep = clienteViewModel.Cep,
                Endereco = clienteViewModel.Endereco,
                Cidade = clienteViewModel.Cidade


            });
            _context.SaveChanges();

        }

        public void Alterar(ClienteViewModel clienteViewModel)
        {
            var cliente = _context.Clientes.Find(clienteViewModel.Id);

           
            cliente.Nome = clienteViewModel.Nome;
            cliente.DataNascimento = clienteViewModel.DataNascimento;
            cliente.Cep = clienteViewModel.Cep;
            cliente.Endereco = clienteViewModel.Endereco;
            cliente.Cidade = clienteViewModel.Cidade;
 
            _context.SaveChanges();
        }

        public void Remover(long id)
        {

            var cliente = _context.Clientes.First(x => x.Id == id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public List<ClienteViewModel> Listar()
        {
            return _context.Clientes.AsNoTracking()
                    .Select(x => new ClienteViewModel
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        DataNascimento = x.DataNascimento,
                        Cep = x.Cep,
                        Endereco = x.Endereco,
                        Cidade = x.Cidade


                    }).ToList()
                    .OrderBy(x => x.Nome).ToList();

        }
    }
}
