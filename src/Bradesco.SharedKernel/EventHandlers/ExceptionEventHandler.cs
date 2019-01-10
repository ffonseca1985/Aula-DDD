using SharedKernel.DomainModel.Events;
using SharedKernel.InfraEstructure.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedKernel.EventHandlers
{
    public class ExceptionEventHandler
        : HandlerBase, 
        IHandlerMessage<ExceptionEvent>
        
    {
        private List<ExceptionEvent> Errors { get; set; }

        public bool HasError()
        {
            return this.Errors != null && this.Errors.Count > 0;
        }
        public List<ExceptionEvent> Get()
        {
            return Errors;
        }

        public void Handle(ExceptionEvent message)
        {

            if (this.Errors == null || this.Errors.Count == 0)
                this.Errors = new List<ExceptionEvent>();

            Errors.Add(new ExceptionEvent(message.Key, message.Value));
            
        }
    }
}
