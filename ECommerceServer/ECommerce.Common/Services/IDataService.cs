using ECommerce.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Services
{
    interface IDataService<in TEntity>
        where TEntity : class
    {
        Task Save(TEntity entity, params Message[] messages);

    }
}
