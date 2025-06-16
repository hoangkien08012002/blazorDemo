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
    public partial class TaskCreate
    {
        [Inject] private ITaskApiClient taskApi { get; set; }
        [Inject] NavigationManager navigationManager { get; set; }
        [Inject] IToastService toastService { get; set; }
        private TaskCreateRequest task = new TaskCreateRequest();

        private async Task CreateTask(EditContext editContext)
        {
            var create = await taskApi.Create(task);
            if (create)
            {
                toastService.ShowSuccess($"{task.Name} has been created.");
                navigationManager.NavigateTo("taskList");
            }
            else
            {
                toastService.ShowError("An error occurred in progress");
            }
        }
    }
}
