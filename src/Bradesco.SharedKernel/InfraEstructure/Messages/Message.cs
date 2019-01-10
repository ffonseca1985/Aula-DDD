using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.InfraEstructure.Messages
{
    public interface IMessage
    {
        int Versao { get; set; }
    }
}
