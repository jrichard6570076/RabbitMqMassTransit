using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModels
{
    public interface IMessage
    {
        DateTime MessageDate { get; }
        string MessageContent { get; }
        EnumMessageType MessageType { get; }
    }
}
