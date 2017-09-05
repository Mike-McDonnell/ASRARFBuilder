using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASRARFBuilder
{
    public interface IAssesmentResultRequest
    {
        string ACASXML { get; set; }

        string SecurityCenterAddress { get; set; }

        string DataPublisherVersion { get; set; }

        string DataPublisher { get; set; }

        string ASRReportType { get; set; }

    }

    public interface IAssesmentResult
    {
        string ASRXML { get; }

        string ARFXML { get; }

    }
}
