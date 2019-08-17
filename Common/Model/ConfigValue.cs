using System;
using System.Xml.Serialization;

namespace Common
{
    public class ConfigValue
    {
        #region Fields and properties

        public bool IsFileConnection { get; set; }

        private string _configName;
        private string _domain;
        private string _username;
        private string _password;
        private string _endPointName;
        private string _endpointAddress;
        private BindingType _bindingType;
        private string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public string Domain
        {
            get
            {
                return this._domain;
            }
            set
            {
                this._domain = value;
            }
        }

        public string ConfigName
        {
            get
            {
                return this._configName;
            }
            set
            {
                this._configName = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public BindingType BindingType
        {
            get
            {
                return this._bindingType;
            }
            set
            {
                this._bindingType = value;
            }
        }

        public string EndpointAddress
        {
            get
            {
                return _endpointAddress;
            }
             set
            {
                _endpointAddress = value;
            }
        }

        [XmlIgnore]
        public Uri EndpointUri
        {
            get
            {
                if (String.IsNullOrEmpty(_endpointAddress))
                    return new Uri("http://localhost");
                return new Uri(this._endpointAddress);
            }
        }

        public string EndPointName
        {
            get
            {
                if (!string.IsNullOrEmpty(_endPointName))
                    return _endPointName;
                else
                    return "WSHttpBinding_IService";
            }
            set
            {
                _endPointName = value;
            }
        }

        public string DisplayValues
        {
            get
            {
                return string.Format("{0}({1}) : {2} --> {3}", (object)this._configName, (object)((object)this._bindingType).ToString(), (object)this._endpointAddress, (object)this._username);
            }
        }
        #endregion


        public ConfigValue(string configName, string domain, string userName, string password, Uri endpointAddress, BindingType bindingType)
        {
            _configName = configName;
            _domain = domain;
            _username = userName;
            _password = password;
            _endpointAddress = endpointAddress.OriginalString;
            _bindingType = bindingType;
            IsFileConnection = false;
        }

        public ConfigValue(string configName, string filePath)
        {
            _configName = configName;
            _filePath = filePath;
            IsFileConnection = true;
        }


        public ConfigValue()
        {
            //a parameterless constructor is required by the serializer.
            IsFileConnection = false;
        }

    }
}
