using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ACAStoAssesmentReport
{
    class ARequest : ASRARFBuilder.IAssesmentResultRequest
    {
        public string ACASXML
        {
            get; set;
        }

        public string ASRReportType
        {
            get; set;
        } = "acas.plugin.results";

        public string DataPublisher
        {
            get; set;
        } = "Assesment Report Publisher";

        public string DataPublisherVersion
        {
            get; set;
        } = "1.0";

        public string SecurityCenterAddress
        {
            get; set;
        } = "Generic.SecuritySystem.com";
    }
}
