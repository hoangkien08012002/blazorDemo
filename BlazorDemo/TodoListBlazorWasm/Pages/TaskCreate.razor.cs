using System.Net.NetworkInformation;
using System;
using TodoListModel;
using TodoListModel.Enums;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using TodoListBlazorWasm.Services;
namespace TodoListBlazorWasm.Pages
{
    public partial class TaskCreate
    {
        [Inject] private ITaskApiClient taskApi { get; set; }
        [Inject] NavigationManager navigationManager { get; set; }
        private TaskCreateRequest task = new TaskCreateRequest();

        private async Task CreateTask(EditContext editContext)
        {
            var create = await taskApi.Create(task);
            if (create)
            {
                navigationManager.NavigateTo("taskList");
            }
            else
            {

            }
        }
    }
}
