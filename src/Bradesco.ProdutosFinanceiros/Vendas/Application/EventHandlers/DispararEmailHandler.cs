using CQRSlite.Events;
using System;
using System.Threading.Tasks;
using Vendas.Events;

namespace Vendas.EventHandlers
{
    //Toda vez que criar um Cdb devo enviar um email para alguém!!
    public class DispararEmailHandler
        : IEventHandler<CDBCriadoEvent>,
          IEventHandler<CDBVendidoEvent>
    {
        public Task Handle(CDBCriadoEvent message)
        {
            return Task.Run(() => Console.WriteLine("CDB Criado => Email Event Handler"));
        }

        public Task Handle(CDBVendidoEvent message)
        {
            return Task.Run(() => Console.WriteLine("CDB Vendido => Email Event Handler"));
        }
    }
}
