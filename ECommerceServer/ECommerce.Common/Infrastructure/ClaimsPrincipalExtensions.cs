using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Common.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdministrator(this ClaimsPrincipal user)
            => user.IsInRole(Constants.AdministratorRoleName);

    }
}
