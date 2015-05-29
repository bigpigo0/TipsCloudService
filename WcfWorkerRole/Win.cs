using System.Xml.Serialization;

namespace WcfWorkerRole
{

        /// <remarks/>
        [XmlRoot("ROOT"), XmlType("ROOT")]
        public class Win
        {

            private ROOTWIN wINField;

            /// <remarks/>
            public ROOTWIN WIN
            {
                get
                {
                    return this.wINField;
                }
                set
                {
                    this.wINField = value;
                }
            }
        }

        /// <remarks/>
        [XmlType(AnonymousType = true)]
        public class ROOTWIN
        {

            private ROOTWINRACE rACEField;

            private string dATEField;

            private string vENUEField;

            private string updateDateField;

            private string updateTimeField;

            /// <remarks/>
            public ROOTWINRACE RACE
            {
                get
                {
                    return this.rACEField;
                }
                set
                {
                    this.rACEField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string DATE
            {
                get
                {
                    return this.dATEField;
                }
                set
                {
                    this.dATEField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string VENUE
            {
                get
                {
                    return this.vENUEField;
                }
                set
                {
                    this.vENUEField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string updateDate
            {
                get
                {
                    return this.updateDateField;
                }
                set
                {
                    this.updateDateField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string updateTime
            {
                get
                {
                    return this.updateTimeField;
                }
                set
                {
                    this.updateTimeField = value;
                }
            }
        }

        /// <remarks/>
        [XmlType(AnonymousType = true)]
        public class ROOTWINRACE
        {

            private ROOTWINRACEOUT[] oUTField;

            private string nUMField;

            private string tIMEField;

            private string fINAL_COLLATEField;

            private string idField;

            private string pIDField;

            /// <remarks/>
            [XmlElement("OUT")]
            public ROOTWINRACEOUT[] OUT
            {
                get
                {
                    return this.oUTField;
                }
                set
                {
                    this.oUTField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string NUM
            {
                get
                {
                    return this.nUMField;
                }
                set
                {
                    this.nUMField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string TIME
            {
                get
                {
                    return this.tIMEField;
                }
                set
                {
                    this.tIMEField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string FINAL_COLLATE
            {
                get
                {
                    return this.fINAL_COLLATEField;
                }
                set
                {
                    this.fINAL_COLLATEField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string ID
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string PID
            {
                get
                {
                    return this.pIDField;
                }
                set
                {
                    this.pIDField = value;
                }
            }
        }

        /// <remarks/>
        [XmlType(AnonymousType = true)]
        public class ROOTWINRACEOUT
        {

            private string tYPEField;

            private string nUMField;

            private string wILLPAYField;

            private string hfField;

            private string bIG_DROPField;

            private string oDDSDROPField;

            private string valueField;

            /// <remarks/>
            [XmlAttribute()]
            public string TYPE
            {
                get
                {
                    return this.tYPEField;
                }
                set
                {
                    this.tYPEField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string NUM
            {
                get
                {
                    return this.nUMField;
                }
                set
                {
                    this.nUMField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string WILLPAY
            {
                get
                {
                    return this.wILLPAYField;
                }
                set
                {
                    this.wILLPAYField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string HF
            {
                get
                {
                    return this.hfField;
                }
                set
                {
                    this.hfField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string BIG_DROP
            {
                get
                {
                    return this.bIG_DROPField;
                }
                set
                {
                    this.bIG_DROPField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string ODDSDROP
            {
                get
                {
                    return this.oDDSDROPField;
                }
                set
                {
                    this.oDDSDROPField = value;
                }
            }

            /// <remarks/>
            [XmlText()]
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

 
}