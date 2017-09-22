using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASRARFBuilder.Models;

namespace ASRARFBuilder
{
    public class Converter
    {
        private string DataPublisher;
        private string DataPublisherVer;
        private string ReportType;
        private string SecurityCenterAddress;

        private Models.ACASType.NessusClientData_v2 ACASResults;
       
        public IAssesmentResult ProcessAssesmentRequest(IAssesmentResultRequest request)
        {
            this.DataPublisher = request.DataPublisher;
            this.DataPublisherVer = request.DataPublisherVersion;
            this.ReportType = request.ASRReportType;
            this.SecurityCenterAddress = request.SecurityCenterAddress;

            try
            {
                this.ACASResults = ParseACASXML(request.ACASXML);
                return this.BuildReport(); 

            }
            catch(Exception ex)
            {
                throw new Exception("Failed to Generate Assessment Request", ex);
            }
        }

        public Task<IAssesmentResult> ProcessAssesmentRequestAsync(IAssesmentResultRequest request)
        {
           var task = Task.Run<IAssesmentResult>(() => {

                return this.ProcessAssesmentRequest(request);
            } );

            return task;
        }

        private IAssesmentResult BuildReport()
        {
            var ARF = GenerateARF(new Models.ASRARFTypes.ARF.Notify());

            var ASR = GenerateASR(new Models.ASRARFTypes.ASR.Notify());

            return new AssesmentReport(ARF, ASR);
        }

        private ASRARFTypes.ASR.Notify GenerateASR(ASRARFTypes.ASR.Notify ASR)
        {
            ASR.NotificationMessage = new ASRARFTypes.ASR.NotifyNotificationMessage();
            ASR.NotificationMessage.Topic = new ASRARFTypes.ASR.NotifyNotificationMessageTopic() { Dialect = ACASConstants.Topic_Dialect };
            ASR.NotificationMessage.ProducerReference = new ASRARFTypes.ASR.NotifyNotificationMessageProducerReference();
            ASR.NotificationMessage.ProducerReference.Address = this.SecurityCenterAddress;
            ASR.NotificationMessage.ProducerReference.Metadata = new ASRARFTypes.ASR.Metadata() { MessageID = this.SecurityCenterAddress };
            ASR.NotificationMessage.ProducerReference.Metadata.taggedString = new ASRARFTypes.ASR.taggedString() { name = this.DataPublisher , value = this.DataPublisherVer};
            ASR.NotificationMessage.Message = new ASRARFTypes.ASR.NotifyNotificationMessageMessage();
            ASR.NotificationMessage.Message.ResultsPackage = new ASRARFTypes.ASR.ResultsPackage();
            ASR.NotificationMessage.Message.ResultsPackage.PopulationCharacteristics = new ASRARFTypes.ASR.ResultsPackagePopulationCharacteristics();
            ASR.NotificationMessage.Message.ResultsPackage.PopulationCharacteristics.populationSize = (byte)this.ACASResults.Report.ReportHost.Length;
            ASR.NotificationMessage.Message.ResultsPackage.PopulationCharacteristics.resource = this.SecurityCenterAddress;

            ASR.NotificationMessage.Message.ResultsPackage.benchmark = new ASRARFTypes.ASR.ResultsPackageBenchmark();
            ASR.NotificationMessage.Message.ResultsPackage.benchmark.benchMarkID = new ASRARFTypes.ASR.ResultsPackageBenchmarkBenchMarkID();
            ASR.NotificationMessage.Message.ResultsPackage.benchmark.benchMarkID.resource = this.SecurityCenterAddress;
            ASR.NotificationMessage.Message.ResultsPackage.benchmark.benchMarkID.record_identifier = "acas.plugin.results";

            var RuleResultList = new List<ASRARFTypes.ASR.ResultsPackageBenchmarkRuleResult>();

            var plugin_set_Preferences = this.ACASResults.Policy.Preferences.ServerPreferences.FirstOrDefault(p => p.name == "plugin_set");

            if(plugin_set_Preferences == null)
            {
                throw new Exception("ACAS scan is missing plugin set infomation");
            }

            var plugin_set = plugin_set_Preferences.value.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();

            foreach(var plugin in plugin_set)
            {
                var pluginResult = this.ACASResults.Report.ReportHost.SelectMany(h=> h.ReportItem, (host, reportItem) => new { host, reportItem.severity, reportItem.pluginID }).Where(h => h.pluginID == plugin).Distinct().ToArray();
                if (pluginResult.Length > 0)
                {

                    var RuleResult = new ASRARFTypes.ASR.ResultsPackageBenchmarkRuleResult() { ident = pluginResult[0].pluginID, ruleID = pluginResult[0].pluginID };
                    RuleResult.ruleComplianceItem = new ASRARFTypes.ASR.ResultsPackageBenchmarkRuleResultRuleComplianceItem();
                    RuleResult.ruleComplianceItem.ruleResult = pluginResult[0].severity == 0 ? "informational" : "fail";
                    RuleResult.ruleComplianceItem.result = new ASRARFTypes.ASR.ResultsPackageBenchmarkRuleResultRuleComplianceItemResult() { count = (byte)pluginResult.Length };
                  
                    var deviceRecordList = new List<ASRARFTypes.ASR.ResultsPackageBenchmarkRuleResultRuleComplianceItemResultDeviceRecord>();

                    foreach(var device in pluginResult)
                    {
                        var deviceRecord = new ASRARFTypes.ASR.ResultsPackageBenchmarkRuleResultRuleComplianceItemResultDeviceRecord() { record_identifier = device.host.name };

                        var hostname = GetRecordIdentifier(device.host);
                        deviceRecord = new ASRARFTypes.ASR.ResultsPackageBenchmarkRuleResultRuleComplianceItemResultDeviceRecord() { record_identifier = hostname };

                        deviceRecordList.Add(deviceRecord);
                    }

                    RuleResult.ruleComplianceItem.result.deviceRecord = deviceRecordList.ToArray();

                    RuleResultList.Add(RuleResult);
                }

            }
            ASR.NotificationMessage.Message.ResultsPackage.benchmark.ruleResult = RuleResultList.ToArray();

            return ASR;
        }

        private ASRARFTypes.ARF.Notify GenerateARF(ASRARFTypes.ARF.Notify ARF)
        {
            ARF.NotificationMessage = new ASRARFTypes.ARF.NotifyNotificationMessage();
            ARF.NotificationMessage.Topic = new ASRARFTypes.ARF.NotifyNotificationMessageTopic();
            ARF.NotificationMessage.Topic.Value = ACASConstants.ARFTopic;
            ARF.NotificationMessage.Topic.Dialect = ACASConstants.Topic_Dialect;

            ARF.NotificationMessage.ProducerReference = new ASRARFTypes.ARF.NotifyNotificationMessageProducerReference();
            ARF.NotificationMessage.ProducerReference.Address = this.SecurityCenterAddress;

            ARF.NotificationMessage.ProducerReference.Metadata = new ASRARFTypes.ARF.Metadata();
            ARF.NotificationMessage.ProducerReference.Metadata.MessageID = this.SecurityCenterAddress;

            ARF.NotificationMessage.ProducerReference.Metadata.taggedString = new ASRARFTypes.ARF.taggedString();
            ARF.NotificationMessage.ProducerReference.Metadata.taggedString.name = this.DataPublisher;
            ARF.NotificationMessage.ProducerReference.Metadata.taggedString.value = this.DataPublisherVer;

            ARF.NotificationMessage.Message = new ASRARFTypes.ARF.NotifyNotificationMessageMessage();
            ARF.NotificationMessage.Message.AssessmentReport = new ASRARFTypes.ARF.AssessmentReportReportObject[this.ACASResults.Report.ReportHost.Length];
            
            for(var x =0; x < this.ACASResults.Report.ReportHost.Length; x++)
            {
                ARF.NotificationMessage.Message.AssessmentReport[x] = new ASRARFTypes.ARF.AssessmentReportReportObject();
                ARF.NotificationMessage.Message.AssessmentReport[x].device = new ASRARFTypes.ARF.AssessmentReportReportObjectDevice();
                ARF.NotificationMessage.Message.AssessmentReport[x].device.timestamp = DateTime.Now;

                ARF.NotificationMessage.Message.AssessmentReport[x].device.device_ID = new ASRARFTypes.ARF.device_ID();
                ARF.NotificationMessage.Message.AssessmentReport[x].device.device_ID.resource = this.SecurityCenterAddress;


                var fqdn_Properties = this.ACASResults.Report.ReportHost[x].HostProperties.FirstOrDefault(hp => hp.name == "host-fqdn");
                var netBiosname = this.ACASResults.Report.ReportHost[x].HostProperties.FirstOrDefault(hp => hp.name == "netbios-name");
                var DNSname = this.ACASResults.Report.ReportHost[x].HostProperties.FirstOrDefault(hp => hp.name == "hostname");

                ARF.NotificationMessage.Message.AssessmentReport[x].device.device_ID.record_identifier = GetRecordIdentifier(this.ACASResults.Report.ReportHost[x]);

                ARF.NotificationMessage.Message.AssessmentReport[x].device.identifiers = new ASRARFTypes.ARF.identifiersFQDN[2];
                if(netBiosname != null)
                    ARF.NotificationMessage.Message.AssessmentReport[x].device.identifiers[0] = new ASRARFTypes.ARF.identifiersFQDN() { host_name = netBiosname.Value, source = "NetBIOS", realm = "" };

                if(DNSname != null)
                    ARF.NotificationMessage.Message.AssessmentReport[x].device.identifiers[1] = new ASRARFTypes.ARF.identifiersFQDN() { host_name = DNSname.Value, source = "DNS", realm = "" };

                ARF.NotificationMessage.Message.AssessmentReport[x].device.operational_attributes = new ASRARFTypes.ARF.operational_attributes();
                ARF.NotificationMessage.Message.AssessmentReport[x].device.operational_attributes.resource = this.SecurityCenterAddress;
                ARF.NotificationMessage.Message.AssessmentReport[x].device.operational_attributes.record_identifier = "";

                ARF.NotificationMessage.Message.AssessmentReport[x].device.configuration = new ASRARFTypes.ARF.configuration();
                ARF.NotificationMessage.Message.AssessmentReport[x].device.configuration.network_configuration = new ASRARFTypes.ARF.configurationNetwork_configuration();
                var hostIp = this.ACASResults.Report.ReportHost[x].HostProperties.FirstOrDefault(hp => hp.name == "host-ip");

                ARF.NotificationMessage.Message.AssessmentReport[x].device.configuration.network_configuration.network_interface_ID = hostIp != null ? hostIp.Value : null;

                ARF.NotificationMessage.Message.AssessmentReport[x].device.configuration.network_configuration.host_network_data = new ASRARFTypes.ARF.configurationNetwork_configurationHost_network_data();
                ARF.NotificationMessage.Message.AssessmentReport[x].device.configuration.network_configuration.host_network_data.connection_ip = new ASRARFTypes.ARF.configurationNetwork_configurationHost_network_dataConnection_ip();
                ARF.NotificationMessage.Message.AssessmentReport[x].device.configuration.network_configuration.host_network_data.connection_ip.IPv4 = hostIp != null ? hostIp.Value : null;

                var macaddress = this.ACASResults.Report.ReportHost[x].HostProperties.FirstOrDefault(hp => hp.name == "mac-address");
                ARF.NotificationMessage.Message.AssessmentReport[x].device.configuration.network_configuration.host_network_data.connection_mac_address = macaddress != null ? macaddress.Value : null;

                ARF.NotificationMessage.Message.AssessmentReport[x].device.configuration.cpe_inventory = new ASRARFTypes.ARF.configurationCpe_inventory();
                ARF.NotificationMessage.Message.AssessmentReport[x].device.configuration.cpe_inventory.cpe_record = new ASRARFTypes.ARF.configurationCpe_inventoryCpe_record();
                ARF.NotificationMessage.Message.AssessmentReport[x].device.configuration.cpe_inventory.cpe_record.platformName = new ASRARFTypes.ARF.platformName();
                ARF.NotificationMessage.Message.AssessmentReport[x].device.configuration.cpe_inventory.cpe_record.platformName.assessedName = new ASRARFTypes.ARF.platformNameAssessedName();

                var cpe0 = this.ACASResults.Report.ReportHost[x].HostProperties.FirstOrDefault(hp => hp.name == "cpe-0");
                ARF.NotificationMessage.Message.AssessmentReport[x].device.configuration.cpe_inventory.cpe_record.platformName.assessedName.name = cpe0 != null ? cpe0.Value : null;

                ARF.NotificationMessage.Message.AssessmentReport[x].device.taggedString = new ASRARFTypes.ARF.taggedString[5];

                var plugin_output_scan = this.ACASResults.Report.ReportHost[x].ReportItem.FirstOrDefault(ri => ri.pluginID == 19506);

                if (plugin_output_scan != null)
                {
   
                    for(var opi = 0; opi < plugin_output_scan.ItemsElementName.Length; opi++)
                    {
                        if(plugin_output_scan.ItemsElementName[opi] == ACASType.ItemsChoiceType.plugin_output)
                        {
                            ARF.NotificationMessage.Message.AssessmentReport[x].device.taggedString[0] = new ASRARFTypes.ARF.taggedString() { name = "LastCredScanPluginVers", value = ExtractPluginValue(plugin_output_scan.Items[opi], "Plugin feed version") };

                        }
                    }
                }

                var lastscandate = FindLastScanDate(this.ACASResults.Report.ReportHost[x].HostProperties);
                if(lastscandate != null)
                    ARF.NotificationMessage.Message.AssessmentReport[x].device.taggedString[2] = new ASRARFTypes.ARF.taggedString() { name = "LastCredScan", value = lastscandate };

                ARF.NotificationMessage.Message.AssessmentReport[x].device.taggedString[1] = new ASRARFTypes.ARF.taggedString() { name = "ScanPolicy", value = this.ACASResults.Report.ReportHost[x].HostProperties.FirstOrDefault(hp => hp.name == "policy-used").Value };

                var biosuuid = this.ACASResults.Report.ReportHost[x].HostProperties.FirstOrDefault(hp => hp.name == "bios-uuid");
                if(biosuuid != null)
                    ARF.NotificationMessage.Message.AssessmentReport[x].device.taggedString[3] = new ASRARFTypes.ARF.taggedString() { name = "BIOSGUID", value = biosuuid.Value };

                var mcafeeAgentGUID = this.ACASResults.Report.ReportHost[x].HostProperties.FirstOrDefault(hp => hp.name == "mcafee-epo-guid");
                if(mcafeeAgentGUID != null)
                    ARF.NotificationMessage.Message.AssessmentReport[x].device.taggedString[4] = new ASRARFTypes.ARF.taggedString() { name = "McAfeeAgentGUID", value = mcafeeAgentGUID.Value };

            }
            
            return ARF; 
        }

        private string FindLastScanDate(ACASType.NessusClientData_v2ReportReportHostTag[] hostProperties)
        {
            var lastcredscandate = hostProperties.FirstOrDefault(hp => hp.name == "LastAuthenticatedResults");
            var lastuncredscandate = hostProperties.FirstOrDefault(hp => hp.name == "LastUnauthenticatedResults");

            if (lastcredscandate != null)
            {
                return CalculateISO8601SFromJavaSeconds(lastcredscandate.Value);

            }
            else if (lastuncredscandate != null)
            {
                return null;
                //Future update write to report of converstion status : unauthernticatedresults
            }

            return null;
        }

        private string GetRecordIdentifier(ACASType.NessusClientData_v2ReportReportHost host)
        {
            var fqdn_Properties = host.HostProperties.FirstOrDefault(hp => hp.name == "host-fqdn");
            var netBiosname = host.HostProperties.FirstOrDefault(hp => hp.name == "netbios-name");
            var DNSname = host.HostProperties.FirstOrDefault(hp => hp.name == "hostname");

            if (fqdn_Properties != null)
            {
                return fqdn_Properties.Value;
            }
            else if (DNSname != null)
            {
                return DNSname.Value;
            }
            else if (netBiosname != null)
            {
                return netBiosname.Value;
            }
            else
                return host.name;
        }

        private string CalculateISO8601SFromJavaSeconds(string seconds)
        {

            DateTimeOffset startDate = new DateTimeOffset(1970, 1, 1, 00, 00, 00, DateTimeOffset.Now.Offset);

            var OffestCorrectedDate = startDate.Add(DateTimeOffset.Now.Offset);

            Double dSeconds;

            if(Double.TryParse(seconds , out dSeconds))
            {
                OffestCorrectedDate = OffestCorrectedDate.AddSeconds(dSeconds);
            }

            return OffestCorrectedDate.ToString("yyyy-MM-dd'T'HH:mm:ssK");
        }

        private string ExtractPluginValue(object plugin_output, string pField)
        {
            string returnVal = string.Empty;

            if (plugin_output != null)
            {
                var lines = plugin_output.ToString().Split(new char[] { '\n'}, StringSplitOptions.RemoveEmptyEntries);
                var fieldLine = lines.FirstOrDefault(x => x.Contains(pField));
                if(fieldLine != null)
                {
                    returnVal = fieldLine.Split(':')[1].Trim();
                }
            }

            return returnVal;
        }

        private ACASType.NessusClientData_v2 ParseACASXML(string ACASXML)
        {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ACASType.NessusClientData_v2));

                using (System.IO.StringReader stringreader = new System.IO.StringReader(ACASXML))
                {
                    return (ACASType.NessusClientData_v2)serializer.Deserialize(stringreader);
                }
        }
    }
}
