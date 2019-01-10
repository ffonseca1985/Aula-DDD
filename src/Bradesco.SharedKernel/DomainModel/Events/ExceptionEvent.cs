using SharedKernel.InfraEstructure.Messages;
using System;

namespace SharedKernel.DomainModel.Events
{
    public class ExceptionEvent : Event
    {
        public ExceptionEvent(string key, string value)
        {
            this.Key = key;
            this.Value = value;
            Data = DateTime.Now;
        }

        public DateTime Data { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
