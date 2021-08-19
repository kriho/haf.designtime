using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAF.DesignTime.Models {
  public class ObservableTaskProgress: IObservableTaskProgress {
    public int Maximum { get; set; }

    public int Value { get; set; }

    public bool IsRunning { get; set; }

    public bool IsIndeterminate { get; set; }

    public string Description { get; set; }

    public int? Normalizer { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public void NormalizeProgress(int? normalizer) {
      throw new NotImplementedException();
    }

    public void Report(int value) {
      throw new NotImplementedException();
    }

    public void ReportIndeterminate(string description = null) {
      throw new NotImplementedException();
    }

    public void ReportProgress(int? value = null) {
      throw new NotImplementedException();
    }

    public void ReportProgress(string description) {
      throw new NotImplementedException();
    }

    public void ReportProgress(int value, string description) {
      throw new NotImplementedException();
    }

    public void ReportProgress(int value, int maximum, string description = "", int? normalizer = null) {
      throw new NotImplementedException();
    }
  }
}
