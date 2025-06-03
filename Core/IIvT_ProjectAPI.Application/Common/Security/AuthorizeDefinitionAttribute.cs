using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Common.Security
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeDefinitionAttribute : Attribute
    {
        public string Menu { get; }
        public string Definition { get; }
        public ActionType ActionType { get; }

        public AuthorizeDefinitionAttribute(string menu, ActionType actionType, string definition)
        {
            Menu = menu;
            Definition = definition;
            ActionType = actionType;
        }
    }

    public enum ActionType
    {
        Reading,
        Writing,
        Updating,
        Deleting
    }
}
