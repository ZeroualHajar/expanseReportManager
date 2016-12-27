using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Models
{
    public abstract class CustomBaseViewPage<T>
        : WebViewPage<T> where T : class
    {
        public bool IsManager(string userId)
        {
            EmployeeService service = new EmployeeService(new NotesDeFraisEntities());
            return service.IsManager(userId);
        }
    }

}