
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

    public NotifyCollection<IObservableTask> ActiveTasks { get; set; } = new();
    IReadOnlyNotifyCollection<IObservableTask> IObservableTaskPool.ActiveTasks => this.ActiveTasks;

    public NotifyCollection<IObservableTask> RegisteredTasks { get; set; } = new();
    IReadOnlyNotifyCollection<IObservableTask> IObservableTaskPool.RegisteredTasks => this.RegisteredTasks;
  }
}
