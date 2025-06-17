using System.Net.NetworkInformation;
using System;
using TodoListModel;
using TodoListModel.Enums;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using TodoListBlazorWasm.Services;
using Blazored.Toast.Services;
namespace TodoListBlazorWasm.Pages
{
    public partial class TaskEdit
    {
        [Inject] private ITaskApiClient taskApi { get; set; }
        [Inject] NavigationManager navigationManager { get; set; }
        [Inject] IToastService toastService { get; set; }
        [Parameter]
        public string TaskId { get; set; }

        private TaskUpdateRequest task = new TaskUpdateRequest() ;
        private TaskDto taskDetail;
       

        protected override async Task OnInitializedAsync()
        {
           var taskDto = await taskApi.GetTaskById(TaskId);
            task.Name = taskDto.Name;
            task.Priority = taskDto.Priority;

        }
        private async Task CreateTask(EditContext editContext)
        {
            var create = await taskApi.Update(Guid.Parse(TaskId),task);
            if (create)
            {
                toastService.ShowSuccess($"{task.Name} has been updated.");
                navigationManager.NavigateTo("/taskList");
            }
            else
            {
                toastService.ShowError("An error occurred in progress");
            }
        }
    }
}
