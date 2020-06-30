using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Common.Services.Identity
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        bool IsAdministrator { get; }
    }
}
