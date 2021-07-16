using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;

namespace HAF.Designtime {

  [Export(typeof(ITasksService)), PartCreationPolicy(CreationPolicy.Shared)]
  public class TasksService: Service, ITasksService {

    private NotifyCollection<ObservableTaskPool> taskPools = new NotifyCollection<ObservableTaskPool>();
    public IReadOnlyNotifyCollection<ObservableTaskPool> TaskPools => this.taskPools;

    public ObservableTaskPool this[string name] {
      get { return this.TaskPools.FirstOrDefault(t => t.Name == name); }
    }

    public TasksService() {
      var pool = new ObservableTaskPool("Fast tasks", true);
      pool.ScheduleTask(new ObservableTask("make something good"));
      pool.ScheduleTask(new ObservableTask("make something bad"));
      pool.ScheduleTask(new ObservableTask("make something ugly"));
      this.taskPools.Add(pool);
      pool = new ObservableTaskPool("Long running tasks", false);
      pool.ScheduleTask(new ObservableTask("build something great"));
      this.taskPools.Add(pool);
    }
    
    public void AddTaskPool(string name, bool allowParallelExecution) {
    }
  }
}
