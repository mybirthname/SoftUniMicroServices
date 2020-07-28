using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Services.Messages
{
    public interface IMessageService
    {
        Task<Data.Models.Message> GetByID(Guid id);
        Task MarkMessageAsPublished(Guid id);

    }
}
