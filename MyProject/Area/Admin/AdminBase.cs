using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Area.Admin
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminBase : Controller
    {

    }
}
