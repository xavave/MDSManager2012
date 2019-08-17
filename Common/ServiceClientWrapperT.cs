// Type: Common.ServiceClientWrapper`2
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;
using Common.Exceptions;
using Common.MDSService;

namespace Common
{


    class ServiceClientWrapper<TClient, IService> : IDisposable
        where TClient : ClientBase<IService>
        where IService : class
    {
        public const int maxStringContentLength = 2147483647;

        private readonly ConfigValue _config;
        private TClient _serviceClient;

        public ServiceClientWrapper()
        {

        }

        public ServiceClientWrapper(ConfigValue config)
        {
            _config = config;
        }

        public TClient CreateServiceClient()
        {
            if (_config == null)
                throw new ConfigurationException("No configuration value was informed.");

            if (_config.EndpointUri == null)
                throw new ConfigurationException("The remote service Uri was not present in the configuration provided.");

            DisposeExistingServiceClientIfRequired();

            ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)((obj, certificate, chain, errors) => true);
            EndpointAddress endpointAddress;

            if (_config.BindingType == BindingType.BasicHttpBinding)
            {

                //applying heuristics to identify the correct endpoint
                if (_config.EndpointUri.ToString().EndsWith(".svc"))
                    endpointAddress = new EndpointAddress(_config.EndpointUri + "/bhb");
                else
                    endpointAddress = new EndpointAddress(_config.EndpointUri);


                BasicHttpBinding basicHttpBinding1 = new BasicHttpBinding();
                basicHttpBinding1.MaxBufferPoolSize = int.MaxValue;
                basicHttpBinding1.MaxReceivedMessageSize = int.MaxValue;
                basicHttpBinding1.ReaderQuotas = new XmlDictionaryReaderQuotas()
                {
                    MaxArrayLength = int.MaxValue,
                    MaxBytesPerRead = int.MaxValue,
                    MaxDepth = 32,
                    MaxNameTableCharCount = int.MaxValue,
                    MaxStringContentLength = int.MaxValue
                };
                basicHttpBinding1.MaxBufferSize = int.MaxValue;
                basicHttpBinding1.UseDefaultWebProxy = true;
                basicHttpBinding1.OpenTimeout = TimeSpan.FromSeconds(100);
                basicHttpBinding1.ReceiveTimeout = TimeSpan.FromSeconds(100);
                basicHttpBinding1.SendTimeout = TimeSpan.FromSeconds(100);
                basicHttpBinding1.CloseTimeout = TimeSpan.FromSeconds(100);
                //Specifying Ntlm credential mode. Otherwise client will connect as Anonymous.
                basicHttpBinding1.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
                basicHttpBinding1.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
                basicHttpBinding1.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;



                _serviceClient = (TClient)Activator.CreateInstance(typeof(TClient), new object[] { basicHttpBinding1, endpointAddress });


            }
            if (_config.BindingType == BindingType.WSHttpBinding)
            {
                endpointAddress = new EndpointAddress(_config.EndpointUri);

                WSHttpBinding wsHttpBinding = new WSHttpBinding();
                wsHttpBinding.MaxBufferPoolSize = int.MaxValue;
                wsHttpBinding.MaxReceivedMessageSize = int.MaxValue;
                wsHttpBinding.OpenTimeout = TimeSpan.FromSeconds(100);
                wsHttpBinding.ReceiveTimeout = TimeSpan.FromSeconds(100);
                wsHttpBinding.SendTimeout = TimeSpan.FromSeconds(100);
                wsHttpBinding.CloseTimeout = TimeSpan.FromSeconds(100);
                wsHttpBinding.ReaderQuotas = new XmlDictionaryReaderQuotas()
                {
                    MaxArrayLength = int.MaxValue,
                    MaxBytesPerRead = int.MaxValue,
                    MaxDepth = 32,
                    MaxNameTableCharCount = int.MaxValue,
                    MaxStringContentLength = int.MaxValue
                };

                //Specifying Ntlm credential mode. Otherwise client will connect as Anonymous.
                wsHttpBinding.Security.Mode = SecurityMode.Message;
                wsHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
                wsHttpBinding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;

                _serviceClient = (TClient)Activator.CreateInstance(typeof(TClient), new object[] { wsHttpBinding, endpointAddress });

            }

            if (string.IsNullOrEmpty(_config.Password) || string.IsNullOrEmpty(_config.Domain) || string.IsNullOrEmpty(_config.UserName))
                throw new ArgumentException("Make sure the configuration provided contains Domain, Username and Password.");

            _serviceClient.ClientCredentials.Windows.ClientCredential = new NetworkCredential(_config.UserName, _config.Password, _config.Domain);


            //if (!string.IsNullOrEmpty(_config.EndPointName))
            //   _serviceClient.Endpoint.Name = _config.EndPointName;

            //if (!string.IsNullOrEmpty(_config.Domain))
            //    this._serviceClient.ClientCredentials.Windows.ClientCredential.Domain = _config.Domain;
            //if (!string.IsNullOrEmpty(_config.UserName))
            //{
            //this._serviceClient.ClientCredentials.Windows.ClientCredential.UserName = _config.UserName;
            //this._serviceClient.ClientCredentials.UserName.UserName = !string.IsNullOrEmpty(_config.Domain) ? _config.Domain + "\\" + _config.UserName : _config.UserName;
            //}

            //_serviceClient.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            //this._serviceClient.ClientCredentials.UserName.Password = _config.Password;

            foreach (OperationDescription operationDescription in _serviceClient.Endpoint.Contract.Operations)
                operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>().MaxItemsInObjectGraph = int.MaxValue;
            _serviceClient.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(100);
            return _serviceClient;
        }

        public void Dispose()
        {
            this.DisposeExistingServiceClientIfRequired();
        }

        private void DisposeExistingServiceClientIfRequired()
        {
            if ((object)this._serviceClient == null)
                return;
            try
            {
                if (this._serviceClient.State == CommunicationState.Faulted)
                    this._serviceClient.Abort();
                else
                    this._serviceClient.Close();
            }
            catch
            {
                this._serviceClient.Abort();
            }
            this._serviceClient = default(TClient);
        }
    }
}
