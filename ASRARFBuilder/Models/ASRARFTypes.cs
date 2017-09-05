using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASRARFBuilder.Models
{
    public class ASRARFTypes
    {
        public class ARF
        {
            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wsn/b-2")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2", IsNullable = false)]
            public partial class Notify
            {

                private NotifyNotificationMessage notificationMessageField;

                /// <remarks/>
                public NotifyNotificationMessage NotificationMessage
                {
                    get
                    {
                        return this.notificationMessageField;
                    }
                    set
                    {
                        this.notificationMessageField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wsn/b-2")]
            public partial class NotifyNotificationMessage
            {

                private NotifyNotificationMessageTopic topicField;

                private NotifyNotificationMessageProducerReference producerReferenceField;

                private NotifyNotificationMessageMessage messageField;

                /// <remarks/>
                public NotifyNotificationMessageTopic Topic
                {
                    get
                    {
                        return this.topicField;
                    }
                    set
                    {
                        this.topicField = value;
                    }
                }

                /// <remarks/>
                public NotifyNotificationMessageProducerReference ProducerReference
                {
                    get
                    {
                        return this.producerReferenceField;
                    }
                    set
                    {
                        this.producerReferenceField = value;
                    }
                }

                /// <remarks/>
                public NotifyNotificationMessageMessage Message
                {
                    get
                    {
                        return this.messageField;
                    }
                    set
                    {
                        this.messageField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wsn/b-2")]
            public partial class NotifyNotificationMessageTopic
            {

                private string dialectField;

                private string valueField;

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string Dialect
                {
                    get
                    {
                        return this.dialectField;
                    }
                    set
                    {
                        this.dialectField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlTextAttribute()]
                public string Value
                {
                    get
                    {
                        return this.valueField;
                    }
                    set
                    {
                        this.valueField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wsn/b-2")]
            public partial class NotifyNotificationMessageProducerReference
            {

                private string addressField;

                private Metadata metadataField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
                public string Address
                {
                    get
                    {
                        return this.addressField;
                    }
                    set
                    {
                        this.addressField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
                public Metadata Metadata
                {
                    get
                    {
                        return this.metadataField;
                    }
                    set
                    {
                        this.metadataField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/08/addressing")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
            public partial class Metadata
            {

                private string messageIDField;

                private taggedString taggedStringField;

                /// <remarks/>
                public string MessageID
                {
                    get
                    {
                        return this.messageIDField;
                    }
                    set
                    {
                        this.messageIDField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/tagged_value/0.41")]
                public taggedString taggedString
                {
                    get
                    {
                        return this.taggedStringField;
                    }
                    set
                    {
                        this.taggedStringField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/tagged_value/0.41")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/tagged_value/0.41", IsNullable = false)]
            public partial class taggedString
            {

                private string valueField;

                private string nameField;

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string value
                {
                    get
                    {
                        return this.valueField;
                    }
                    set
                    {
                        this.valueField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string name
                {
                    get
                    {
                        return this.nameField;
                    }
                    set
                    {
                        this.nameField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wsn/b-2")]
            public partial class NotifyNotificationMessageMessage
            {

                private AssessmentReportReportObject[] assessmentReportField;

                /// <remarks/>
                [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/assessment_report/0.41")]
                [System.Xml.Serialization.XmlArrayItemAttribute("reportObject", IsNullable = false)]
                public AssessmentReportReportObject[] AssessmentReport
                {
                    get
                    {
                        return this.assessmentReportField;
                    }
                    set
                    {
                        this.assessmentReportField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/assessment_report/0.41")]
            public partial class AssessmentReportReportObject
            {

                private AssessmentReportReportObjectDevice deviceField;

                /// <remarks/>
                public AssessmentReportReportObjectDevice device
                {
                    get
                    {
                        return this.deviceField;
                    }
                    set
                    {
                        this.deviceField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/assessment_report/0.41")]
            public partial class AssessmentReportReportObjectDevice
            {

                private device_ID device_IDField;

                private identifiersFQDN[] identifiersField;

                private operational_attributes operational_attributesField;

                private configuration configurationField;

                private taggedString[] taggedStringField;

                private System.DateTime timestampField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
                public device_ID device_ID
                {
                    get
                    {
                        return this.device_IDField;
                    }
                    set
                    {
                        this.device_IDField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
                [System.Xml.Serialization.XmlArrayItemAttribute("FQDN", IsNullable = false)]
                public identifiersFQDN[] identifiers
                {
                    get
                    {
                        return this.identifiersField;
                    }
                    set
                    {
                        this.identifiersField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
                public operational_attributes operational_attributes
                {
                    get
                    {
                        return this.operational_attributesField;
                    }
                    set
                    {
                        this.operational_attributesField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
                public configuration configuration
                {
                    get
                    {
                        return this.configurationField;
                    }
                    set
                    {
                        this.configurationField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute("taggedString", Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/tagged_value/0.41")]
                public taggedString[] taggedString
                {
                    get
                    {
                        return this.taggedStringField;
                    }
                    set
                    {
                        this.taggedStringField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public System.DateTime timestamp
                {
                    get
                    {
                        return this.timestampField;
                    }
                    set
                    {
                        this.timestampField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41", IsNullable = false)]
            public partial class device_ID
            {

                private string resourceField;

                private string record_identifierField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/cnd-core/0.41")]
                public string resource
                {
                    get
                    {
                        return this.resourceField;
                    }
                    set
                    {
                        this.resourceField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/cnd-core/0.41")]
                public string record_identifier
                {
                    get
                    {
                        return this.record_identifierField;
                    }
                    set
                    {
                        this.record_identifierField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
            public partial class identifiersFQDN
            {

                private string realmField;

                private string host_nameField;

                private string sourceField;

                /// <remarks/>
                public string realm
                {
                    get
                    {
                        return this.realmField;
                    }
                    set
                    {
                        this.realmField = value;
                    }
                }

                /// <remarks/>
                public string host_name
                {
                    get
                    {
                        return this.host_nameField;
                    }
                    set
                    {
                        this.host_nameField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string source
                {
                    get
                    {
                        return this.sourceField;
                    }
                    set
                    {
                        this.sourceField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41", IsNullable = false)]
            public partial class operational_attributes
            {

                private string resourceField;

                private string record_identifierField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/cnd-core/0.41")]
                public string resource
                {
                    get
                    {
                        return this.resourceField;
                    }
                    set
                    {
                        this.resourceField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/cnd-core/0.41")]
                public string record_identifier
                {
                    get
                    {
                        return this.record_identifierField;
                    }
                    set
                    {
                        this.record_identifierField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41", IsNullable = false)]
            public partial class configuration
            {

                private configurationNetwork_configuration network_configurationField;

                private configurationCpe_inventory cpe_inventoryField;

                /// <remarks/>
                public configurationNetwork_configuration network_configuration
                {
                    get
                    {
                        return this.network_configurationField;
                    }
                    set
                    {
                        this.network_configurationField = value;
                    }
                }

                /// <remarks/>
                public configurationCpe_inventory cpe_inventory
                {
                    get
                    {
                        return this.cpe_inventoryField;
                    }
                    set
                    {
                        this.cpe_inventoryField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
            public partial class configurationNetwork_configuration
            {

                private string network_interface_IDField;

                private configurationNetwork_configurationHost_network_data host_network_dataField;

                /// <remarks/>
                public string network_interface_ID
                {
                    get
                    {
                        return this.network_interface_IDField;
                    }
                    set
                    {
                        this.network_interface_IDField = value;
                    }
                }

                /// <remarks/>
                public configurationNetwork_configurationHost_network_data host_network_data
                {
                    get
                    {
                        return this.host_network_dataField;
                    }
                    set
                    {
                        this.host_network_dataField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
            public partial class configurationNetwork_configurationHost_network_data
            {

                private string connection_mac_addressField;

                private configurationNetwork_configurationHost_network_dataConnection_ip connection_ipField;

                /// <remarks/>
                public string connection_mac_address
                {
                    get
                    {
                        return this.connection_mac_addressField;
                    }
                    set
                    {
                        this.connection_mac_addressField = value;
                    }
                }

                /// <remarks/>
                public configurationNetwork_configurationHost_network_dataConnection_ip connection_ip
                {
                    get
                    {
                        return this.connection_ipField;
                    }
                    set
                    {
                        this.connection_ipField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
            public partial class configurationNetwork_configurationHost_network_dataConnection_ip
            {

                private string iPv4Field;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/cnd-core/0.41")]
                public string IPv4
                {
                    get
                    {
                        return this.iPv4Field;
                    }
                    set
                    {
                        this.iPv4Field = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
            public partial class configurationCpe_inventory
            {

                private configurationCpe_inventoryCpe_record cpe_recordField;

                /// <remarks/>
                public configurationCpe_inventoryCpe_record cpe_record
                {
                    get
                    {
                        return this.cpe_recordField;
                    }
                    set
                    {
                        this.cpe_recordField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
            public partial class configurationCpe_inventoryCpe_record
            {

                private platformName platformNameField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://scap.nist.gov/schema/cpe-record/0.1")]
                public platformName platformName
                {
                    get
                    {
                        return this.platformNameField;
                    }
                    set
                    {
                        this.platformNameField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://scap.nist.gov/schema/cpe-record/0.1")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://scap.nist.gov/schema/cpe-record/0.1", IsNullable = false)]
            public partial class platformName
            {

                private platformNameAssessedName assessedNameField;

                /// <remarks/>
                public platformNameAssessedName assessedName
                {
                    get
                    {
                        return this.assessedNameField;
                    }
                    set
                    {
                        this.assessedNameField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://scap.nist.gov/schema/cpe-record/0.1")]
            public partial class platformNameAssessedName
            {

                private string nameField;

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string name
                {
                    get
                    {
                        return this.nameField;
                    }
                    set
                    {
                        this.nameField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/assessment_report/0.41")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/assessment_report/0.41", IsNullable = false)]
            public partial class AssessmentReport
            {

                private AssessmentReportReportObject[] reportObjectField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute("reportObject")]
                public AssessmentReportReportObject[] reportObject
                {
                    get
                    {
                        return this.reportObjectField;
                    }
                    set
                    {
                        this.reportObjectField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/device/0.41", IsNullable = false)]
            public partial class identifiers
            {

                private identifiersFQDN[] fQDNField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute("FQDN")]
                public identifiersFQDN[] FQDN
                {
                    get
                    {
                        return this.fQDNField;
                    }
                    set
                    {
                        this.fQDNField = value;
                    }
                }
            }

        }

        public class ASR
        {
            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wsn/b-2")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2", IsNullable = false)]
            public partial class Notify
            {

                private NotifyNotificationMessage notificationMessageField;

                /// <remarks/>
                public NotifyNotificationMessage NotificationMessage
                {
                    get
                    {
                        return this.notificationMessageField;
                    }
                    set
                    {
                        this.notificationMessageField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wsn/b-2")]
            public partial class NotifyNotificationMessage
            {

                private NotifyNotificationMessageTopic topicField;

                private NotifyNotificationMessageProducerReference producerReferenceField;

                private NotifyNotificationMessageMessage messageField;

                /// <remarks/>
                public NotifyNotificationMessageTopic Topic
                {
                    get
                    {
                        return this.topicField;
                    }
                    set
                    {
                        this.topicField = value;
                    }
                }

                /// <remarks/>
                public NotifyNotificationMessageProducerReference ProducerReference
                {
                    get
                    {
                        return this.producerReferenceField;
                    }
                    set
                    {
                        this.producerReferenceField = value;
                    }
                }

                /// <remarks/>
                public NotifyNotificationMessageMessage Message
                {
                    get
                    {
                        return this.messageField;
                    }
                    set
                    {
                        this.messageField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wsn/b-2")]
            public partial class NotifyNotificationMessageTopic
            {

                private string dialectField;

                private string valueField;

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string Dialect
                {
                    get
                    {
                        return this.dialectField;
                    }
                    set
                    {
                        this.dialectField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlTextAttribute()]
                public string Value
                {
                    get
                    {
                        return this.valueField;
                    }
                    set
                    {
                        this.valueField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wsn/b-2")]
            public partial class NotifyNotificationMessageProducerReference
            {

                private string addressField;

                private Metadata metadataField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
                public string Address
                {
                    get
                    {
                        return this.addressField;
                    }
                    set
                    {
                        this.addressField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
                public Metadata Metadata
                {
                    get
                    {
                        return this.metadataField;
                    }
                    set
                    {
                        this.metadataField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/08/addressing")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
            public partial class Metadata
            {

                private string messageIDField;

                private taggedString taggedStringField;

                /// <remarks/>
                public string MessageID
                {
                    get
                    {
                        return this.messageIDField;
                    }
                    set
                    {
                        this.messageIDField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/tagged_value/0.41")]
                public taggedString taggedString
                {
                    get
                    {
                        return this.taggedStringField;
                    }
                    set
                    {
                        this.taggedStringField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/tagged_value/0.41")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/shared_data/tagged_value/0.41", IsNullable = false)]
            public partial class taggedString
            {

                private string valueField;

                private string nameField;

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string value
                {
                    get
                    {
                        return this.valueField;
                    }
                    set
                    {
                        this.valueField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string name
                {
                    get
                    {
                        return this.nameField;
                    }
                    set
                    {
                        this.nameField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wsn/b-2")]
            public partial class NotifyNotificationMessageMessage
            {

                private ResultsPackage resultsPackageField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/summary_res/0.41")]
                public ResultsPackage ResultsPackage
                {
                    get
                    {
                        return this.resultsPackageField;
                    }
                    set
                    {
                        this.resultsPackageField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/summary_res/0.41")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/summary_res/0.41", IsNullable = false)]
            public partial class ResultsPackage
            {

                private ResultsPackagePopulationCharacteristics populationCharacteristicsField;

                private ResultsPackageBenchmark benchmarkField;

                /// <remarks/>
                public ResultsPackagePopulationCharacteristics PopulationCharacteristics
                {
                    get
                    {
                        return this.populationCharacteristicsField;
                    }
                    set
                    {
                        this.populationCharacteristicsField = value;
                    }
                }

                /// <remarks/>
                public ResultsPackageBenchmark benchmark
                {
                    get
                    {
                        return this.benchmarkField;
                    }
                    set
                    {
                        this.benchmarkField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/summary_res/0.41")]
            public partial class ResultsPackagePopulationCharacteristics
            {

                private string resourceField;

                private byte populationSizeField;

                /// <remarks/>
                public string resource
                {
                    get
                    {
                        return this.resourceField;
                    }
                    set
                    {
                        this.resourceField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public byte populationSize
                {
                    get
                    {
                        return this.populationSizeField;
                    }
                    set
                    {
                        this.populationSizeField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/summary_res/0.41")]
            public partial class ResultsPackageBenchmark
            {

                private ResultsPackageBenchmarkBenchMarkID benchMarkIDField;

                private ResultsPackageBenchmarkRuleResult[] ruleResultField;

                /// <remarks/>
                public ResultsPackageBenchmarkBenchMarkID benchMarkID
                {
                    get
                    {
                        return this.benchMarkIDField;
                    }
                    set
                    {
                        this.benchMarkIDField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute("ruleResult")]
                public ResultsPackageBenchmarkRuleResult[] ruleResult
                {
                    get
                    {
                        return this.ruleResultField;
                    }
                    set
                    {
                        this.ruleResultField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/summary_res/0.41")]
            public partial class ResultsPackageBenchmarkBenchMarkID
            {

                private string resourceField;

                private string record_identifierField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/cnd-core/0.41")]
                public string resource
                {
                    get
                    {
                        return this.resourceField;
                    }
                    set
                    {
                        this.resourceField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/cnd-core/0.41")]
                public string record_identifier
                {
                    get
                    {
                        return this.record_identifierField;
                    }
                    set
                    {
                        this.record_identifierField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/summary_res/0.41")]
            public partial class ResultsPackageBenchmarkRuleResult
            {

                private uint identField;

                private ResultsPackageBenchmarkRuleResultRuleComplianceItem ruleComplianceItemField;

                private uint ruleIDField;

                /// <remarks/>
                public uint ident
                {
                    get
                    {
                        return this.identField;
                    }
                    set
                    {
                        this.identField = value;
                    }
                }

                /// <remarks/>
                public ResultsPackageBenchmarkRuleResultRuleComplianceItem ruleComplianceItem
                {
                    get
                    {
                        return this.ruleComplianceItemField;
                    }
                    set
                    {
                        this.ruleComplianceItemField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public uint ruleID
                {
                    get
                    {
                        return this.ruleIDField;
                    }
                    set
                    {
                        this.ruleIDField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/summary_res/0.41")]
            public partial class ResultsPackageBenchmarkRuleResultRuleComplianceItem
            {

                private ResultsPackageBenchmarkRuleResultRuleComplianceItemResult resultField;

                private string ruleResultField;

                /// <remarks/>
                public ResultsPackageBenchmarkRuleResultRuleComplianceItemResult result
                {
                    get
                    {
                        return this.resultField;
                    }
                    set
                    {
                        this.resultField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string ruleResult
                {
                    get
                    {
                        return this.ruleResultField;
                    }
                    set
                    {
                        this.ruleResultField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/summary_res/0.41")]
            public partial class ResultsPackageBenchmarkRuleResultRuleComplianceItemResult
            {

                private ResultsPackageBenchmarkRuleResultRuleComplianceItemResultDeviceRecord[] deviceRecordField;

                private byte countField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute("deviceRecord")]
                public ResultsPackageBenchmarkRuleResultRuleComplianceItemResultDeviceRecord[] deviceRecord
                {
                    get
                    {
                        return this.deviceRecordField;
                    }
                    set
                    {
                        this.deviceRecordField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public byte count
                {
                    get
                    {
                        return this.countField;
                    }
                    set
                    {
                        this.countField = value;
                    }
                }
            }

            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://metadata.dod.mil/mdr/ns/netops/net_defense/summary_res/0.41")]
            public partial class ResultsPackageBenchmarkRuleResultRuleComplianceItemResultDeviceRecord
            {

                private string record_identifierField;

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string record_identifier
                {
                    get
                    {
                        return this.record_identifierField;
                    }
                    set
                    {
                        this.record_identifierField = value;
                    }
                }
            }
        }
    }
}
