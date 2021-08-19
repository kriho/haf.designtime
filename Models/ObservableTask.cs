using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAF.DesignTime.Models {
  public class ObservableTask: IObservableTask {
    public IObservableTaskPool Pool { get; set; }

    public IObservableTaskProgress Progress { get; set; }

    public bool IsCancelled { get; set; }

    public RelayCommand DoCancel { get; set; }

    public void Cancel() {
      throw new NotImplementedException();
    }

    public Task Run() {
      throw new NotImplementedException();
    }

    public Task Schedule() {
      throw new NotImplementedException();
    }

    public Task WaitForCompletion() {
      throw new NotImplementedException();
    }
  }
}
