using System.ComponentModel.DataAnnotations;

namespace Maui.Erweitert.Attribute
{
    /// <summary>
    /// Definiert ein Hilfs-Attribut mit Validiert werden kann ob der zugewiesene Wert größer als der übergebene Wert ist
    /// </summary>
    public sealed class GrößerAlsAttribute(string eigenschaftsname) : ValidationAttribute
    {

        /// <summary>
        /// Definiert den Eigenschaftsnamen
        /// </summary>
        private string EigenschaftsName { get; } = eigenschaftsname;

        /// <summary>
        /// Checkt ob die übergebene Eigenschaft zulässig ist
        /// </summary>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            object?
                instance = validationContext.ObjectInstance,
                otherValue = instance.GetType().GetProperty(EigenschaftsName)?.GetValue(instance);

            return (value as IComparable)?.CompareTo(otherValue) <= 0
                ? new("The current value is smaller than the other one")
                : ValidationResult.Success;
        }
    }
}
