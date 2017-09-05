using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASRARFBuilder.Models;

namespace ASRARFBuilder
{
    class AssesmentReport : IAssesmentResult
    {
        private ASRARFTypes.ARF.Notify ARF;
        private ASRARFTypes.ASR.Notify ASR;

        public AssesmentReport(ASRARFTypes.ARF.Notify ARF, ASRARFTypes.ASR.Notify ASR)
        {
            this.ARF = ARF;
            this.ASR = ASR;
        }

        public string ARFXML
        {
            get
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ASRARFTypes.ARF.Notify));

                using (UTF8StringWriter stringwriter = new UTF8StringWriter())
                {
                    serializer.Serialize(stringwriter, this.ARF);

                    return stringwriter.GetStringBuilder().ToString();
                }
            }
        }

        public string ASRXML
        {
            get
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ASRARFTypes.ASR.Notify));

                using (UTF8StringWriter stringwriter = new UTF8StringWriter())
                {

                    serializer.Serialize(stringwriter, this.ASR);

                    return stringwriter.GetStringBuilder().ToString();
                }
            }
        }
    }
}
