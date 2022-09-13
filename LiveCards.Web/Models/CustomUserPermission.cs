
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Models
{
    public class CustomUserPermission
    {



        public static bool isAuthorized(AllPermissions permissionId)
        {
            //var UserManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var userid = HttpContext.Current.User.Identity.GetUserId();
            //if (userid == null)
            //{
            //    return false;
            //}

            //var userRoles = UserManager.GetRoles(userid);

            //if (userRoles.Contains("Admin"))
            //{
            //    return true;
            //}
             
            //var db = new Entities();
            //var permission = db.Permissions.Find((int)permissionId);
            ////  اذا كان الرابط المطلوب موجود بالصلاحيات
            //if (permission != null)
            //{
            //    //ال  user اللي فايت
            //    // var user = db.AspNetUsers.Where(x => x.Email == httpContext.User.Identity.Name).Single();

            //    var permissionRoles = permission.AspNetRoles.Select(x => x.Name);
            //    var isInRole = userRoles.Contains("Admin") || permissionRoles.Intersect(userRoles).Count() > 0;

            //    //رجع انه يملك او لا
            //    return isInRole;
            //}
            //    return false;
        
 return true;
        }


    }
}