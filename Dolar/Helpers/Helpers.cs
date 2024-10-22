using System;
using System.Threading.Tasks;

namespace Dolar.Helpers
{
    public static class DialogsHelper
    {
        public static void ShowLoadingMessage(string message)
        {
            Console.WriteLine($"[LOADING]: {message}");
            // Aquí podrías usar alguna librería de UI como un DialogService para mostrar mensajes
        }

        public static void HideLoadingMessage()
        {
            Console.WriteLine("[LOADING HIDE]");
            // Ocultar el mensaje de carga
        }

        public static async Task ShowSuccessMessage(string title, string message)
        {
            Console.WriteLine($"[SUCCESS]: {title} - {message}");
            await Task.CompletedTask;  // Simulación de operación async
        }

        public static async Task ShowErrorMessage(string title, string message)
        {
            Console.WriteLine($"[ERROR]: {title} - {message}");
            await Task.CompletedTask;
        }

        public static async Task ShowWarningMessage(string title, string message)
        {
            Console.WriteLine($"[WARNING]: {title} - {message}");
            await Task.CompletedTask;
        }
    }
}
