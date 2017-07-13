using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GridExample.Validators {
    public class PersonPropertiesValidator {
        readonly Dictionary<string, string> _dataErrors = new Dictionary<string, string>();

        public bool IsNameValid(string value, [CallerMemberName] string propertyName = "") {
            if (string.IsNullOrEmpty(value)) {
                _dataErrors[propertyName] = "Full name is required.";
                return false;
            } else {
                ClearPropertyErrors(propertyName);
                return true;
            }
        }

        public bool IsAgeValid(int value, [CallerMemberName] string propertyName = "") {
            if (value <= 0) {
                _dataErrors[propertyName] = "Age validation failed.";
                return false;
            } else {
                ClearPropertyErrors(propertyName);
                return true;
            }
        }

        public string DataError { get; } = "";

        public Dictionary<string, string> DataErrors => _dataErrors;

        void ClearPropertyErrors(string propertyName) {
            if (_dataErrors.ContainsKey(propertyName))
                _dataErrors.Remove(propertyName);
        }
    }
}
