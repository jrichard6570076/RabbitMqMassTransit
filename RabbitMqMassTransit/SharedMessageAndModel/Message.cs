using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMessageAndModel
{
    public class Message
    {
        DateTime NotificationDate { get; }
        string Message { get; }
        EnumMessageType NotificationType { get; }
    }
}
