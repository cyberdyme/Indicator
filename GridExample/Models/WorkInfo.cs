using System;
using System.ComponentModel;
using GridExample.Validators;

namespace GridExample.Models
{
    public class WorkInfo : INotifyPropertyChanged, IDataErrorInfo
    {
        readonly WorkInfoPropertiesValidator _validator = new WorkInfoPropertiesValidator();
        private string _companyName;
        private DateTime _startDate;
        private WorkStatus _status;

        public WorkInfo(string companyName, DateTime startDate, WorkStatus status)
        {
            this.CompanyName = companyName;
            this.StartDate = startDate;
        }

        public string CompanyName
        {
            get => _companyName;
            set
            {
                _validator.IsCompanyNameValid(value, nameof(CompanyName));
                _companyName = value;
                RaisePropertyChanged(nameof(CompanyName));
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _validator.IsStartDateValid(value, nameof(StartDate));
                _startDate = value;
                RaisePropertyChanged(nameof(StartDate));
            }
        }

        public WorkStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region IDataErrorInfo members
        public string Error => _validator.DataError;

        public string this[string columnName] => 
            _validator.DataErrors.ContainsKey(columnName) ? _validator.DataErrors[columnName] : null;

        #endregion
    }
}