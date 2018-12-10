using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;

namespace FoodFinder.Models
{
    public class CurrentUser
    {
        public CurrentUser(string id, bool isAuthenticated)
        {
            Id = id;
            IsAuthenticated = isAuthenticated;
        }
        public CurrentUser(IIdentity identity)
        {
            Id = identity.GetUserId();
            IsAuthenticated = identity.IsAuthenticated;
        }
        public string Id { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}