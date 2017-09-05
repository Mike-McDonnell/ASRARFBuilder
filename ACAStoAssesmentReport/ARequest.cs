using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public string DataPublisher
        {
            get; set;
        }

        public string DataPublisherVersion
        {
            get; set;
        }

        public string SecurityCenterAddress
        {
            get; set;
        }
    }
}
