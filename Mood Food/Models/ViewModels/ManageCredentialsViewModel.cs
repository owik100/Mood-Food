using Mood_Food.Controllers;

namespace Mood_Food.Models.ViewModels
{
    internal class ManageCredentialsViewModel
    {
        public ManageController.ManageMessageId? Message { get; set; }
        public object DaneUzytkownika { get; set; }
    }
}