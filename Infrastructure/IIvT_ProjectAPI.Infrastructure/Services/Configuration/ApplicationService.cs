using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Security;
using IIvT_ProjectAPI.Application.DTOs.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace IIvT_ProjectAPI.Infrastructure.Services.Configuration
{
    public class ApplicationService : IApplicationService
    {
        public List<MenuDto> GetAuthorizeDefinitionEndpoints()
        {
            var assembly = Assembly.GetEntryAssembly();
            if (assembly == null)
                return new();

            var controllers = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(ControllerBase)))
                .ToList();

            var menus = new List<MenuDto>();

            foreach (var controller in controllers)
            {
                var methods = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(m => m.GetCustomAttributes(typeof(AuthorizeDefinitionAttribute), false).Any());

                foreach (var method in methods)
                {
                    var attr = (AuthorizeDefinitionAttribute)method
                        .GetCustomAttributes(typeof(AuthorizeDefinitionAttribute), false).First();

                    var httpAttr = method.GetCustomAttributes()
                        .FirstOrDefault(a => a is HttpMethodAttribute) as HttpMethodAttribute;

                    string httpMethod = httpAttr != null
                        ? httpAttr.HttpMethods.First()
                        : "GET";

                    var code = $"{httpMethod}.{attr.ActionType}.{attr.Definition.Replace(" ", "")}";

                    var menuDto = menus.FirstOrDefault(m => m.MenuName == attr.Menu);

                    if(menuDto == null)
                    {
                        menuDto = new MenuDto { MenuName = attr.Menu };
                        menus.Add(menuDto);
                    }

                    menuDto.Actions.Add(new ActionDto
                    {
                        Code = code,
                        HttpType = httpMethod,
                        ActionType = attr.ActionType.ToString(),
                        Definition = attr.Definition,
                    });
                }
            }

            return menus;
        }
    }
}
