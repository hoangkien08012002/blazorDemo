﻿
using Microsoft.AspNetCore.Components;
using TodoListModel;
using TodoListModel.Enums;
using TodoListBlazorWasm.Services;

namespace TodoListBlazorWasm.Pages
{
    public partial class TodoList
    {
        [Inject] private ITaskApiClient taskApi {  get; set; }
        private List<TaskDto> tasks; // chức năng hiển thị 

        private TaskListSearch TaskListSearch = new TaskListSearch();
        private List<AssigneDto> assignes;
        protected override async Task OnInitializedAsync()
        {
            tasks = await taskApi.GetTaskList();
        }
        

    }
    public class TaskListSearch
    {
        public string Name { get; set; }
        public Guid AssigneId { get; set; }
        public Priority Priority { get; set; }
    }
}
 