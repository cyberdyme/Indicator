using System.Collections.ObjectModel;
using System.ComponentModel;
using GridExample.Validators;
using System.Runtime.CompilerServices;

namespace GridExample.Models
{
    public class Person : INotifyPropertyChanged, IDataErrorInfo {
        private string _firstName;
        private string _lastName;
        private int _age;
        private bool _isMarried;
        private int _height;
        private int _weight;

        readonly PersonPropertiesValidator _validator = new PersonPropertiesValidator();
        private ObservableCollection<WorkInfo> _workInfo = new ObservableCollection<WorkInfo>();

        public Person(string firstName, string lastName, int age, bool isMarried, int height, int weight) {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            IsMarried = isMarried;
            Weight = weight;
            Height = height;
        }

        public string FirstName {
            get => _firstName;
            set {
                _validator.IsNameValid(value);
                _firstName = value;
                RaisePropertyChanged();
            }
        }

        public string LastName {
            get => _lastName;
            set {
                _validator.IsNameValid(value);
                _lastName = value;
                RaisePropertyChanged();
            }
        }

        public int Age {
            get => _age;
            set {
                _validator.IsAgeValid(value);
                _age = value;
                RaisePropertyChanged();
            }
        }

        public bool IsMarried {
            get => _isMarried;
            set {
                _isMarried = value;
                RaisePropertyChanged();
            }
        }

        public int Height {
            get => _height;
            set {
                _height = value;
                RaisePropertyChanged();
            }
        }

        public int Weight {
            get => _weight;
            set {
                _weight = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<WorkInfo> WorkDetails
        {
            get => _workInfo;
            set
            {
                _workInfo = value;
                RaisePropertyChanged();
            }
        }


        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region IDataErrorInfo members
        public string Error => _validator.DataError;

        public string this[string columnName] {
            get {
                if (_validator.DataErrors.ContainsKey(columnName))
                    return _validator.DataErrors[columnName];
                else
                    return null;
            }
        }
        #endregion
    }
}