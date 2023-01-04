using Microsoft.AspNetCore.Mvc;
using Model.Common;

namespace OHSApi.Configuration.Filters.Auth
{
    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute(PermissionEnum permission) : base(typeof(PermissionFilter))
        {
            Arguments = new object[] { permission };
        }
    }
}
