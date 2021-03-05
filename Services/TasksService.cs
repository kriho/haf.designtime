using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;

namespace HAF.Designtime {

  [Export(typeof(ITasksService)), PartCreationPolicy(CreationPolicy.Shared)]
  public class TasksService: Service, ITasksService {

    public NotifyCollection<ObservableTaskPool> TaskPools { get; set; } = new NotifyCollection<ObservableTaskPool>();

    public ObservableTaskPool this[string name] {
      get { return this.TaskPools.FirstOrDefault(t => t.Name == name); }
    }

    protected override void Initialize() {
      var pool = new ObservableTaskPool() {
        Name = "Fast tasks",
        AllowParallelExecution = true,
      };
      pool.Tasks.Add(new ObservableTask("make something good"));
      pool.Tasks.Add(new ObservableTask("make something bad"));
      pool.Tasks.Add(new ObservableTask("make something ugly"));
      this.TaskPools.Add(pool);
      pool = new ObservableTaskPool() {
        Name = "Long running tasks",
        AllowParallelExecution = false,
      };
      pool.Tasks.Add(new ObservableTask("build something great"));
      this.TaskPools.Add(pool);
    }
    
    public void AddTaskPool(string name, bool allowParallelExecution) {
    }
  }
}
