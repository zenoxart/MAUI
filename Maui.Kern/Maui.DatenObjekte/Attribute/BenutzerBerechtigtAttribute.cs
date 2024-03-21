using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maui.DatenObjekte.Benutzer;

namespace Maui.DatenObjekte.Attribute
{
    /// <summary>
    /// Definiert ein Attribut zum Validieren, ob der Benutzer mit seiner aktuellen Rolle zugriff auf das verwiesene Element hat
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class BenutzerBerechtigttAttribute : System.Attribute
    {
       

        // Override the constructor to check role immediately upon attribute creation
        public BenutzerBerechtigttAttribute(BenutzerRollen requiredRole, BenutzerRollen userRole)
        {
            if (!IsRoleSatisfied(requiredRole,userRole))
            {
                throw new UnauthorizedAccessException($"User role '{userRole}' does not satisfy the required role '{requiredRole}'.");
            }
        }

        private static bool IsRoleSatisfied(BenutzerRollen requiredRole, BenutzerRollen userRole)
        {
            return userRole == requiredRole;
        }
    }
}
