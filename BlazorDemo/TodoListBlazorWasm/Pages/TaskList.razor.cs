using Microsoft.AspNetCore.Components;
using TodoListBlazorWasm.Services;
using TodoListModel.Enums;
using TodoListModel;
using Microsoft.AspNetCore.Components.Forms;
using TodoListBlazorWasm.Components;

namespace TodoListBlazorWasm.Pages
{

    public partial class TaskList
    {
        [Inject] private ITaskApiClient taskApi { get; set; }

        [Inject] private IUserApiClient userApi { get; set; }

        protected Confirmation DeleteConfirmation {  get; set; }
        private List<TaskDto> tasks; // chức năng hiển thị 

        private TaskListSearch TaskListSearch = new TaskListSearch();
        private List<AssigneDto> assignes;

        private Guid DeleteId {  get; set; }
        protected override async Task OnInitializedAsync()
        {
            tasks = await taskApi.GetTaskList(TaskListSearch);
        }
       private async Task SearchForm(EditContext context) // k cần method này
       {
            tasks = await taskApi.GetTaskList(TaskListSearch);
       }
        public async Task SearchTask(TaskListSearch taskListSearch)
        {
            TaskListSearch = taskListSearch;
            tasks = await taskApi.GetTaskList(TaskListSearch);
        }
         
        public void OnDeleteTask( Guid deleteid)
        {
            DeleteId = deleteid;
            DeleteConfirmation.Show();
        }
        public async Task OnConformDateleTask(bool deleteConfirmed)
        {
            if(deleteConfirmed)
            {
                await taskApi.Delete(DeleteId);
                tasks = await taskApi.GetTaskList(TaskListSearch);
            }
        }
    }
    
}

