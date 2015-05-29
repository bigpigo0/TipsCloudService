using System.Xml.Serialization;

namespace WcfWorkerRole
{

    /// <remarks/>
    [XmlRoot("ROOT"), XmlType("ROOT")]
    public partial class PoolTot
    {

        private ROOTPOOL_TOT pOOL_TOTField;

        /// <remarks/>
        public ROOTPOOL_TOT POOL_TOT
        {
            get
            {
                return this.pOOL_TOTField;
            }
            set
            {
                this.pOOL_TOTField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ROOTPOOL_TOT
    {

        private ROOTPOOL_TOTRACE rACEField;

        private string dATEField;

        private string vENUEField;

        private string updateDateField;

        private System.DateTime updateTimeField;

        /// <remarks/>
        public ROOTPOOL_TOTRACE RACE
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "time")]
        public System.DateTime updateTime
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ROOTPOOL_TOTRACE
    {

        private ushort mTG_SALESField;

        private byte cUR_RACE_SALESField;

        private ROOTPOOL_TOTRACEINV[] iNVField;

        private byte nUMField;

        /// <remarks/>
        public ushort MTG_SALES
        {
            get
            {
                return this.mTG_SALESField;
            }
            set
            {
                this.mTG_SALESField = value;
            }
        }

        /// <remarks/>
        public byte CUR_RACE_SALES
        {
            get
            {
                return this.cUR_RACE_SALESField;
            }
            set
            {
                this.cUR_RACE_SALESField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("INV")]
        public ROOTPOOL_TOTRACEINV[] INV
        {
            get
            {
                return this.iNVField;
            }
            set
            {
                this.iNVField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte NUM
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
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ROOTPOOL_TOTRACEINV
    {

        private string pOOLField;

        private uint tIMEField;

        private string idField;

        private byte mergedField;

        private ushort pIDField;

        private bool pIDFieldSpecified;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string POOL
        {
            get
            {
                return this.pOOLField;
            }
            set
            {
                this.pOOLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint TIME
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Merged
        {
            get
            {
                return this.mergedField;
            }
            set
            {
                this.mergedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort PID
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

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PIDSpecified
        {
            get
            {
                return this.pIDFieldSpecified;
            }
            set
            {
                this.pIDFieldSpecified = value;
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


 

}