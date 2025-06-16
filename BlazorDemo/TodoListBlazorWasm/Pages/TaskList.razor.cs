using Microsoft.AspNetCore.Components;
using TodoListBlazorWasm.Services;
using TodoListModel.Enums;
using TodoListModel;
using Microsoft.AspNetCore.Components.Forms;

namespace TodoListBlazorWasm.Pages
{

    public partial class TaskList
    {
        [Inject] private ITaskApiClient taskApi { get; set; }
        [Inject] private IUserApiClient userApi { get; set; }
        private List<TaskDto> tasks; // chức năng hiển thị 

        private TaskListSearch TaskListSearch = new TaskListSearch();
        private List<AssigneDto> assignes;
        protected override async Task OnInitializedAsync()
        {
            tasks = await taskApi.GetTaskList(TaskListSearch);
            assignes = await userApi.GetAssigne();
        }
       private async Task SearchForm(EditContext context)
        {
            tasks = await taskApi.GetTaskList(TaskListSearch);
        }

    }
    
}

