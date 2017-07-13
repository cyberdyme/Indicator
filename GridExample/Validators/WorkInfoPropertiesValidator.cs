using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GridExample.Validators
{
    public class WorkInfoPropertiesValidator
    {
        string dataError = "";
        Dictionary<string, string> dataErrors = new Dictionary<string, string>();

        public bool IsCompanyNameValid(string value, [CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrEmpty(value))
            {
                dataErrors[propertyName] = "Full name is required.";
                return false;
            }
            else
            {
                ClearPropertyErrors(propertyName);
                return true;
            }
        }
        internal bool IsStartDateValid(DateTime value, [CallerMemberName] string propertyName = "")
        {
            ClearPropertyErrors(propertyName);
            return true;
        }


        public string DataError => dataError;

        public Dictionary<string, string> DataErrors => dataErrors;

        void ClearPropertyErrors(string propertyName)
        {
            if (dataErrors.ContainsKey(propertyName))
                dataErrors.Remove(propertyName);
        }
    }
}