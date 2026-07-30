using Microsoft.AspNetCore.Authorization;

namespace FAATPRO.Application.Common.Authorization;

public class HasPermissionAttribute 
    : AuthorizeAttribute
{

    public HasPermissionAttribute(
        string permission)
    {
        Policy = $"Permission:{permission}";
    }

}