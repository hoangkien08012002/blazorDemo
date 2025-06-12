using Microsoft.AspNetCore.Components;
using TodoListModel;
using TodoListBlazorWasm.Services;

namespace TodoListBlazorWasm.Pages
{
    public partial class TaskDetails
    {
        [Parameter]
        public string TaskId { get; set; }
        [Inject] private ITaskApiClient taskApi { get; set; }
        private TaskDto taskDetail;

        protected override async Task OnInitializedAsync()
        {
            taskDetail = await taskApi.GetTaskById(TaskId);
        }
    }
}
