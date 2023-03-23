using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksBotProject.Communication.Interface
{
    internal interface IEventCommunicator
    {
        void CommunicateEvent(string eventText);
    }
}
