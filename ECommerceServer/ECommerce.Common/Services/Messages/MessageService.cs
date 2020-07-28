using ECommerce.Common.Data.Models;
using ECommerce.Common.Services.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Services.Messages
{
    public class MessageService : DataService<Message>, IMessageService
    {
        public MessageService(DbContext db) : base(db)
        {
        }

        public async Task<Data.Models.Message> GetByID(Guid id)
            => await this
                    .All()
                    .Where(d => d.ID == id)
                .FirstOrDefaultAsync();
    }
}
