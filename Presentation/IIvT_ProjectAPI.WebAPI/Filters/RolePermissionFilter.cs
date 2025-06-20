﻿using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace IIvT_ProjectAPI.API.Filters
{
    public class RolePermissionFilter : IAsyncActionFilter
    {
        readonly IUserService _userService;

        public RolePermissionFilter(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var name = context.HttpContext.User.Identity?.Name;

            if (!string.IsNullOrEmpty(name) && name != "superadmin")
            {
                var descriptor = context.ActionDescriptor as ControllerActionDescriptor;

                var allowAnonymous = descriptor?.MethodInfo.GetCustomAttribute(typeof(AllowAnonymousAttribute)) as AllowAnonymousAttribute;

                if (allowAnonymous != null)
                    await next();

                var attribute = descriptor?.MethodInfo.GetCustomAttribute(typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;

                var httpAttribute = descriptor?.MethodInfo.GetCustomAttribute(typeof(HttpMethodAttribute)) as HttpMethodAttribute;

                var code = $"{(httpAttribute != null ? httpAttribute.HttpMethods.First() : HttpMethods.Get)}.{attribute?.ActionType}.{attribute?.Definition.Replace(" ", "")}";

                var hasRole = await _userService.HasRolePermissionToEndpointAsync(name, code);

                if (!hasRole)
                    context.Result = new UnauthorizedResult();
                else
                    await next();
            }
            else
                await next();
        }
    }
}
