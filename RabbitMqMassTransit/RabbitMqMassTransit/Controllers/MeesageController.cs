using FluentValidation;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using System;
namespace RabbitMqMassTransit.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        public readonly IPublishEndpoint publishEndpoint;
        public readonly IValidator<Message> _validator;

        public NotificationController(IPublishEndpoint publishEndpoint, IValidator<Message> validator)
        {
            this.publishEndpoint = publishEndpoint;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Notify(Message Message)
        {
            var result = await _validator.ValidateAsync(Message);
            if (result.IsValid)
            {
                await publishEndpoint.Publish<IMessage>(Message);
            }
            return Ok();
        }
    }
}
