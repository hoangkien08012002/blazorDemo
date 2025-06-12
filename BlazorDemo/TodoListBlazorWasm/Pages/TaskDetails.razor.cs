using Microsoft.AspNetCore.Components;
using TodoListBlazorWasm.Services;
using TodoListModel;

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
