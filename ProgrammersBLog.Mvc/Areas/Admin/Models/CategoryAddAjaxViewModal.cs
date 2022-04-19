using ProgrammersBLog.Entities.Dtos;

namespace ProgrammersBLog.Mvc.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModal
    {
        public CategoryAddDto categoryAddDto { get; set; }  
        public string CategoryAddPartial { get; set; }
        public CategoryDto categoryDto { get; set; }
    }
}
