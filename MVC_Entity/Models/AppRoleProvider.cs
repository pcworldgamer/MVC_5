using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MVC_Entity.Models {
    public class AppRoleProvider : RoleProvider {
        private MVC_EntityContext db = new MVC_EntityContext();
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames) {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName) {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch) {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles() {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username) {
            var user = db.Users.Where(u => u.nome == username).First();
            if (user.perfil == 0)
                return new string[] { "admin" };
            return new string[] { "user" };
        }

        public override string[] GetUsersInRole(string roleName) {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName) {
            var user = db.Users.Where(u => u.nome == username).First();
            if (user.perfil == 0 && roleName == "admin")
                return true;
            if (user.perfil == 1 && roleName == "user")
                return true;
            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName) {
            return roleName.Equals("admin") || roleName.Equals("user");
        }
    }
}