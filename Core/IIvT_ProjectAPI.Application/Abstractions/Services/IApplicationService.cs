﻿using IIvT_ProjectAPI.Application.DTOs.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface IApplicationService
    {
        List<MenuDto> GetAuthorizeDefinitionEndpoints();
    }
}
