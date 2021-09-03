
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAF.DesignTime.Models {
  public class ObservableTaskPool: IObservableTaskPool {
    public string Name { get; set; }

    public bool AllowParallelExecution { get; set; }

    public LinkedState IsIdle { get; set; }

    public ObservableCollection<IObservableTask> ActiveTasks { get; set; } = new ObservableCollection<IObservableTask>();
    IReadOnlyObservableCollection<IObservableTask> IObservableTaskPool.ActiveTasks => this.ActiveTasks;

    public Task ScheduleTask(IObservableTask task) {
      throw new NotImplementedException();
    }
  }
}
