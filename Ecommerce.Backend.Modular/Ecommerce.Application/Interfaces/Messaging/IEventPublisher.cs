﻿using Ecommerce.Application.DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces.Messaging
{
    public interface IEventPublisher
    {
        Task PublishAsync(OrderCreated orderCreatedDto);
    }
}
