using System;

namespace Dolar.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidDivisa(string? divisaName)
        {
            if (string.IsNullOrWhiteSpace(divisaName))
            {
                DialogsHelper.ShowWarningMessage("Advertencia", "El nombre de la divisa no puede estar vacío.");
                return false;
            }

            // Otras validaciones personalizadas
            return true;
        }
    }
}
