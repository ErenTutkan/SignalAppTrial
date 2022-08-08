using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalAppTrial.Model.Options
{
    public class AppConfig
    {
        public string GetCron { get; set; }
        public string CorsOrigins { get; set; }
        public string CorsOriginPolicyName { get; set; }
    }
}
