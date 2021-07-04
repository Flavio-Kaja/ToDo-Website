using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ToDoList.Utilities
{
    public class CurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(IHttpContextAccessor iHttpContextAccessor)
        {
            _httpContextAccessor = iHttpContextAccessor;
        }
        public void YourMethodName()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        //i rlly hope it works 
        //but it propably wont works since i dont want to play her e
    }
}
