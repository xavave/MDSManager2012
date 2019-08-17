using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.MDSService;

namespace Common
{
    class ServiceClientWrapper : ServiceClientWrapper<ServiceClient, IService>
    {
        public ServiceClientWrapper(ConfigValue config) : base(config)
        {
        }
    }
}
