using System.ComponentModel.DataAnnotations;

namespace SharedKernel.InfraEstructure.Messages
{
    public class Event : IEvent
    {
        public Event()
        {
            this.Action = this.GetType().Name;
        }

        public int Versao { get; set; }
        public string Action { get; private set; }

        public override string ToString()
        {
            //Vamos definir que o nome da ação é o nome da classe
            return this.GetType().Name;
        }
    }
}
