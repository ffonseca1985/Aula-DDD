using MovimentacoesGerais.DomainModel.ContaCorrente.Events;
using MovimentacoesGerais.DomainModel.Events;
using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories.PersistModels;
using Newtonsoft.Json;
using SharedKernel.DomainModel;
using SharedKernel.InfraEstructure.Messages;
using System;
using System.Collections.Generic;

namespace MovimentacoesGerais.DomainModel.ContaCorrente
{
    //Tive que fazer esta Gambi para não dar merda no entity framework
    //e não sujar o meu dominio
    //uma outra forma é sempre criar um modelo de persistencia
    //diferente do modelo de negocio
    public class ContaCorrente : EventSource, AggregateRoot
    {
        //Dica: Quando usamos aggregate sempre tente se comunicar
        //via identificador
        public Guid IdCliente { get; private set; }
        public string NumeroConta { get; private set; }
        public string NumeroAgencia { get; private set; }
        public bool ContaEncerrada { get; private set; }

        public decimal Saldo { get; private set; }
        public Guid Id { get; private set; }

        //Para satisfazer a construção/build do stream de eventos (event sourcing)
        public ContaCorrente() {}

        public ContaCorrente(Guid idCliente, string numeroConta, string numeroAgencia)
        {
            //Que bugulho é esse??
            //Quando disparo um evento
            //Automaticamente minhas propriedades são mudadas a partir dos => aplicar
            //E ainda todo o que acontencer na minha classe fica guardada dentro de um log
            this.DispararEvento(new ContaCorrenteCriada(Guid.NewGuid(), idCliente, numeroConta, numeroAgencia));
        }

        #region Methods 

        //Estamos "buildando" o objeto!!!
        public void CarregarPorEventos(IEnumerable<Event> eventos)
        {
            //Build dos eventos
            foreach (var @evento in eventos)
            {
                this.VersaoInicial += 1;
                this.DispararEvento(@evento, false);
            }
        }

        public void Sacar(decimal valor)
        {
            this.DispararEvento(new SaqueRealizado(valor));
        }

        public void Depositar(decimal valor)
        {
            this.DispararEvento(new DepositoRealizado(valor));
        }

        public void ComprarCdb(Guid idProdutoFinanceiro, decimal valor)
        {
            this.DispararEvento(new CompraCdbRealizada(idProdutoFinanceiro, valor));
        }

        public void RealizarEmprestimo(Guid idEmprestimo, decimal valor)
        {
            this.DispararEvento(new EmprestimoRealizado(idEmprestimo, valor));
        }

        public void Encerrar(string motivo)
        {
            this.DispararEvento(new ContaEncerrada(motivo));
        }

        #endregion

        #region Eventos

        public void Aplicar(ContaCorrenteCriada evento)
        {
            this.Id = evento.IdContaCorrente;
            this.IdCliente = evento.IdCliente;
            this.NumeroConta = evento.NumeroConta;
            this.NumeroAgencia = evento.NumeroAgencia;
            this.ContaEncerrada = false;
        }

        public void Aplicar(SaqueRealizado evento)
        {
            this.Saldo -= evento.Valor;
        }

        public void Aplicar(DepositoRealizado evento)
        {
            this.Saldo += evento.Valor;
        }

        public void Aplicar(ContaEncerrada evento)
        {
            this.ContaEncerrada = true;
        }

        public void Aplicar(CompraCdbRealizada evento)
        {
            this.Saldo -= evento.Valor;
        }

        public void Aplicar(EmprestimoRealizado evento)
        {
            this.Saldo += evento.Valor;
        }
        #endregion

        #region snapshot

        public ContaCorrente(PosicaoAtualContaCorrente snapshot)
        {
            this.Id = snapshot.AggregateId;
            this.Saldo = snapshot.Saldo;
            this.ContaEncerrada = snapshot.Encerrada;
            //..
        }

        public void CarregarPorListaEvento(IEnumerable<DadosEvento> dados)
        {
            foreach (var dado in dados)
            {
                dynamic item = JsonConvert.DeserializeObject<dynamic>(dado.Eventos);

                switch (item[0].Action.ToString())
                {
                    case "ContaCorrenteCriada":
                        this.DispararEvento(new ContaCorrenteCriada(new Guid(item[0].IdContaCorrente.ToString()), new Guid(item[0].IdCliente.ToString()), item[0].NumeroConta.ToString(), item[0].NumeroAgencia.ToString()));
                        this.VersaoInicial++;
                        break;
                    case "DepositoRealizado":
                        this.DispararEvento(new DepositoRealizado(Convert.ToDecimal(item[0].Valor)));
                        this.VersaoInicial++;
                        break;
                    case "SaqueRealizado":
                        this.DispararEvento(new SaqueRealizado(Convert.ToDecimal(item[0].Valor)));
                        this.VersaoInicial++;
                        break;
                    case "EmprestimoRealizado":
                        this.DispararEvento(new EmprestimoRealizado(new Guid(item[0].IdEmprestimo.ToString()),Convert.ToDecimal(item[0].Valor)));
                        this.VersaoInicial++;
                        break;
                    default:
                        break;
                }
                
            }
        }

        #endregion
    }
}
