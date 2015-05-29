using System.Xml.Serialization;

namespace WcfWorkerRole
{

    /// <remarks/>
    [XmlRoot("ROOT"), XmlType("ROOT")]
    public partial class Place
    {

        private ROOTPLA pLAField;

        /// <remarks/>
        public ROOTPLA PLA
        {
            get
            {
                return this.pLAField;
            }
            set
            {
                this.pLAField = value;
            }
        }
    }

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class ROOTPLA
    {

        private ROOTPLARACE rACEField;

        private string dATEField;

        private string vENUEField;

        private string updateDateField;

        private string updateTimeField;

        /// <remarks/>
        public ROOTPLARACE RACE
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
    public partial class ROOTPLARACE
    {

        private ROOTPLARACEOUT[] oUTField;

        private string nUMField;

        private string tIMEField;

        private string fINAL_COLLATEField;

        private string idField;

        /// <remarks/>
        [XmlElement("OUT")]
        public ROOTPLARACEOUT[] OUT
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
    }

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public partial class ROOTPLARACEOUT
    {

        private string mINField;

        private string mAXField;

        private string tYPEField;

        private string nUMField;

        private string mIN_WILLPAYField;

        private string mAX_WILLPAYField;

        private string hfField;

        private string oDDSDROPField;

        /// <remarks/>
        public string MIN
        {
            get
            {
                return this.mINField;
            }
            set
            {
                this.mINField = value;
            }
        }

        /// <remarks/>
        public string MAX
        {
            get
            {
                return this.mAXField;
            }
            set
            {
                this.mAXField = value;
            }
        }

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
        public string MIN_WILLPAY
        {
            get
            {
                return this.mIN_WILLPAYField;
            }
            set
            {
                this.mIN_WILLPAYField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string MAX_WILLPAY
        {
            get
            {
                return this.mAX_WILLPAYField;
            }
            set
            {
                this.mAX_WILLPAYField = value;
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
    }


}