using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;

namespace HAF {

  [Export(typeof(ITasksService)), PartCreationPolicy(CreationPolicy.Shared)]
  public class TasksService: Service, ITasksService {

    private readonly ObservableCollection<IObservableTaskPool> taskPools = new ObservableCollection<IObservableTaskPool>();
    IReadOnlyObservableCollection<IObservableTaskPool> ITasksService.TaskPools => this.taskPools;

    public IObservableTaskPool this[string name] {
      get { return this.taskPools.FirstOrDefault(t => t.Name == name); }
    }

    public TasksService() {
      for (var x = 0; x < Faker.RandomNumber.Next(3, 10); x++) {
        var pool = new DesignTime.Models.ObservableTaskPool() {
          Name = Faker.Company.CatchPhrase(),
          AllowParallelExecution = Faker.RandomNumber.Next(0, 1) == 0,
        };
        for (var y = 0; y < Faker.RandomNumber.Next(0, 5); y++) {
          pool.ActiveTasks.Add(new DesignTime.Models.ObservableTask() {
            Progress = new DesignTime.Models.ObservableTaskProgress() {
              Description = Faker.Lorem.Sentence(5),
              IsIndeterminate = Faker.RandomNumber.Next(0, 5) == 0,
              Maximum = Faker.RandomNumber.Next(50, 100),
              Value = Faker.RandomNumber.Next(0, 50),
            }
          });
        }
        this.taskPools.Add(pool);
      }
    }
    
    public IObservableTaskPool AddTaskPool(string name, bool allowParallelExecution) {
        throw new NotImplementedException();
    }
  }
}
