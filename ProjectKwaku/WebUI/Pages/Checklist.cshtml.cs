using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages
{
    public class TasksModel : PageModel
    {
        public string TaskCategory { get; set; }

        public void OnGet(string taskCategory)
        {
            TaskCategory = taskCategory;
        }
    }
}