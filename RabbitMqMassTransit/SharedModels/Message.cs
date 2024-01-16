using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace SharedModels
{
    public class Message: IMessage
    {
        public DateTime MessageDate { get; set; }
        public string MessageContent { get; set; }
        public EnumMessageType MessageType { get; set; }
    }

    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageDate).NotNull();
            RuleFor(x => x.MessageContent).Length(0, 10);
            RuleFor(x => x.MessageType).NotNull();
        }
    }
}
