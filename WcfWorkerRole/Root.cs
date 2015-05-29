namespace WcfWorkerRole
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class ROOT
    {

        private ROOTSTARTERS sTARTERSField;

        private string eVENT_MSNField;

        /// <remarks/>
        public ROOTSTARTERS STARTERS
        {
            get
            {
                return this.sTARTERSField;
            }
            set
            {
                this.sTARTERSField = value;
            }
        }

        /// <remarks/>
        public string EVENT_MSN
        {
            get
            {
                return this.eVENT_MSNField;
            }
            set
            {
                this.eVENT_MSNField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ROOTSTARTERS
    {

        private string mEETING_TRACKField;

        private string gOINGField;

        private string gOING_CField;

        private string gOING_SCField;

        private string tRACKField;

        private ROOTSTARTERSRACE rACEField;

        private string dATEField;

        private string vENUEField;

        private string tIMEField;

        private string updateDateField;

        private string updateTimeField;

        /// <remarks/>
        public string MEETING_TRACK
        {
            get
            {
                return this.mEETING_TRACKField;
            }
            set
            {
                this.mEETING_TRACKField = value;
            }
        }

        /// <remarks/>
        public string GOING
        {
            get
            {
                return this.gOINGField;
            }
            set
            {
                this.gOINGField = value;
            }
        }

        /// <remarks/>
        public string GOING_C
        {
            get
            {
                return this.gOING_CField;
            }
            set
            {
                this.gOING_CField = value;
            }
        }

        /// <remarks/>
        public string GOING_SC
        {
            get
            {
                return this.gOING_SCField;
            }
            set
            {
                this.gOING_SCField = value;
            }
        }

        /// <remarks/>
        public string TRACK
        {
            get
            {
                return this.tRACKField;
            }
            set
            {
                this.tRACKField = value;
            }
        }

        /// <remarks/>
        public ROOTSTARTERSRACE RACE
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ROOTSTARTERSRACE
    {

        private string rACE_COURSEField;

        private string rACE_NAMEField;

        private string rACE_NAME_CField;

        private string rACE_NAME_SCField;

        private decimal sTAKE_PRIZEField;

        private string rACE_INDEXField;

        private string pROVISIONAL_RACE_NOField;

        private string iNTER_GROUP_RACE_INDField;

        private string gROUP_RACE_INDField;

        private string sECTION_OR_DIVISION_NOField;

        private string rEMARKSField;

        private string pOST_DATEField;

        private string pOST_TIMEField;

        private string cLASSESField;

        private string cLASSES_EField;

        private string cLASSES_CField;

        private string cLASSES_SCField;

        private string sECTIONField;

        private string dISTANCEField;

        private string fIELD_SIZEField;

        private string rATING_RANGEField;

        private string rACE_TYPEField;

        private string iNTERNATIONAL_RACE_INDField;

        private ROOTSTARTERSRACERUNNER[] rUNNERField;

        private string nUMField;

        /// <remarks/>
        public string RACE_COURSE
        {
            get
            {
                return this.rACE_COURSEField;
            }
            set
            {
                this.rACE_COURSEField = value;
            }
        }

        /// <remarks/>
        public string RACE_NAME
        {
            get
            {
                return this.rACE_NAMEField;
            }
            set
            {
                this.rACE_NAMEField = value;
            }
        }

        /// <remarks/>
        public string RACE_NAME_C
        {
            get
            {
                return this.rACE_NAME_CField;
            }
            set
            {
                this.rACE_NAME_CField = value;
            }
        }

        /// <remarks/>
        public string RACE_NAME_SC
        {
            get
            {
                return this.rACE_NAME_SCField;
            }
            set
            {
                this.rACE_NAME_SCField = value;
            }
        }

        /// <remarks/>
        public decimal STAKE_PRIZE
        {
            get
            {
                return this.sTAKE_PRIZEField;
            }
            set
            {
                this.sTAKE_PRIZEField = value;
            }
        }

        /// <remarks/>
        public string RACE_INDEX
        {
            get
            {
                return this.rACE_INDEXField;
            }
            set
            {
                this.rACE_INDEXField = value;
            }
        }

        /// <remarks/>
        public string PROVISIONAL_RACE_NO
        {
            get
            {
                return this.pROVISIONAL_RACE_NOField;
            }
            set
            {
                this.pROVISIONAL_RACE_NOField = value;
            }
        }

        /// <remarks/>
        public string INTER_GROUP_RACE_IND
        {
            get
            {
                return this.iNTER_GROUP_RACE_INDField;
            }
            set
            {
                this.iNTER_GROUP_RACE_INDField = value;
            }
        }

        /// <remarks/>
        public string GROUP_RACE_IND
        {
            get
            {
                return this.gROUP_RACE_INDField;
            }
            set
            {
                this.gROUP_RACE_INDField = value;
            }
        }

        /// <remarks/>
        public string SECTION_OR_DIVISION_NO
        {
            get
            {
                return this.sECTION_OR_DIVISION_NOField;
            }
            set
            {
                this.sECTION_OR_DIVISION_NOField = value;
            }
        }

        /// <remarks/>
        public string REMARKS
        {
            get
            {
                return this.rEMARKSField;
            }
            set
            {
                this.rEMARKSField = value;
            }
        }

        /// <remarks/>
        public string POST_DATE
        {
            get
            {
                return this.pOST_DATEField;
            }
            set
            {
                this.pOST_DATEField = value;
            }
        }

        /// <remarks/>
        public string POST_TIME
        {
            get
            {
                return this.pOST_TIMEField;
            }
            set
            {
                this.pOST_TIMEField = value;
            }
        }

        /// <remarks/>
        public string CLASSES
        {
            get
            {
                return this.cLASSESField;
            }
            set
            {
                this.cLASSESField = value;
            }
        }

        /// <remarks/>
        public string CLASSES_E
        {
            get
            {
                return this.cLASSES_EField;
            }
            set
            {
                this.cLASSES_EField = value;
            }
        }

        /// <remarks/>
        public string CLASSES_C
        {
            get
            {
                return this.cLASSES_CField;
            }
            set
            {
                this.cLASSES_CField = value;
            }
        }

        /// <remarks/>
        public string CLASSES_SC
        {
            get
            {
                return this.cLASSES_SCField;
            }
            set
            {
                this.cLASSES_SCField = value;
            }
        }

        /// <remarks/>
        public string SECTION
        {
            get
            {
                return this.sECTIONField;
            }
            set
            {
                this.sECTIONField = value;
            }
        }

        /// <remarks/>
        public string DISTANCE
        {
            get
            {
                return this.dISTANCEField;
            }
            set
            {
                this.dISTANCEField = value;
            }
        }

        /// <remarks/>
        public string FIELD_SIZE
        {
            get
            {
                return this.fIELD_SIZEField;
            }
            set
            {
                this.fIELD_SIZEField = value;
            }
        }

        /// <remarks/>
        public string RATING_RANGE
        {
            get
            {
                return this.rATING_RANGEField;
            }
            set
            {
                this.rATING_RANGEField = value;
            }
        }

        /// <remarks/>
        public string RACE_TYPE
        {
            get
            {
                return this.rACE_TYPEField;
            }
            set
            {
                this.rACE_TYPEField = value;
            }
        }

        /// <remarks/>
        public string INTERNATIONAL_RACE_IND
        {
            get
            {
                return this.iNTERNATIONAL_RACE_INDField;
            }
            set
            {
                this.iNTERNATIONAL_RACE_INDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RUNNER")]
        public ROOTSTARTERSRACERUNNER[] RUNNER
        {
            get
            {
                return this.rUNNERField;
            }
            set
            {
                this.rUNNERField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ROOTSTARTERSRACERUNNER
    {

        private string sCRATCHField;

        private string sCR_REASONField;

        private string sCR_REASON_CField;

        private string sCR_REASON_SCField;

        private string hORSE_NAMEField;

        private string hORSE_NAME_CField;

        private string hORSE_NAME_SCField;

        private string hORSE_NUMField;

        private string bAR_DRAWField;

        private string hORSE_WGTField;

        private string hANDICAP_WGTField;

        private string hORSE_WGT_CRTField;

        private string lAST_HORSE_WGTField;

        private string lAST_ONDAY_HORSE_WGTField;

        private string lAST_HORSE_WGT_DATEField;

        private string lAST_WIN_WGTField;

        private string lAST_WIN_WGT_DATEField;

        private string rATINGField;

        private string bLINKERSField;

        private string dIFF_CLASSField;

        private string aLLOWANCEField;

        private string fREELANCE_ALLOWANCEField;

        private string wIN_LAST5Field;

        private string pLA_LAST5Field;

        private string sADDLE_CLOTHField;

        private string jOCKEY_CODEField;

        private string jOCKEY_NAMEField;

        private string jOCKEY_NAME_CField;

        private string jOCKEY_NAME_SCField;

        private string jOCKEY_STATField;

        private string jOCKEY_WIN_STATField;

        private string jOCKEY_PLA_STATField;

        private string tRAINER_CODEField;

        private string tRAINER_NAMEField;

        private string tRAINER_NAME_CField;

        private string tRAINER_NAME_SCField;

        private string tRAINER_STATField;

        private string oWNER_NAMEField;

        private string oWNER_NAME_CField;

        private string oWNER_NAME_SCField;

        private string lAST_SIX_RUNSField;

        private string lAST_RATINGField;

        private string lAST_WEIGHTField;

        private string sIREField;

        private string dAMField;

        private string bEST_TIMEField;

        private string hORSE_AGEField;

        private string sEXField;

        private string iMPORT_CATEGORYField;

        private decimal sTAKES_WONField;

        private string rUNNING_COMMENTField;

        private string wFAField;

        private string eQUIPMENTField;

        private string oVERWEIGHTField;

        private string iNTERNATIONAL_RATINGField;

        private string pRIORITYField;

        private string tRUMP_CARDField;

        private string pREFERENCEField;

        private string sTANDBYField;

        private string sTANDBY_NUMField;

        private bool sTANDBY_NUMFieldSpecified;

        private string nUMField;

        /// <remarks/>
        public string SCRATCH
        {
            get
            {
                return this.sCRATCHField;
            }
            set
            {
                this.sCRATCHField = value;
            }
        }

        /// <remarks/>
        public string SCR_REASON
        {
            get
            {
                return this.sCR_REASONField;
            }
            set
            {
                this.sCR_REASONField = value;
            }
        }

        /// <remarks/>
        public string SCR_REASON_C
        {
            get
            {
                return this.sCR_REASON_CField;
            }
            set
            {
                this.sCR_REASON_CField = value;
            }
        }

        /// <remarks/>
        public string SCR_REASON_SC
        {
            get
            {
                return this.sCR_REASON_SCField;
            }
            set
            {
                this.sCR_REASON_SCField = value;
            }
        }

        /// <remarks/>
        public string HORSE_NAME
        {
            get
            {
                return this.hORSE_NAMEField;
            }
            set
            {
                this.hORSE_NAMEField = value;
            }
        }

        /// <remarks/>
        public string HORSE_NAME_C
        {
            get
            {
                return this.hORSE_NAME_CField;
            }
            set
            {
                this.hORSE_NAME_CField = value;
            }
        }

        /// <remarks/>
        public string HORSE_NAME_SC
        {
            get
            {
                return this.hORSE_NAME_SCField;
            }
            set
            {
                this.hORSE_NAME_SCField = value;
            }
        }

        /// <remarks/>
        public string HORSE_NUM
        {
            get
            {
                return this.hORSE_NUMField;
            }
            set
            {
                this.hORSE_NUMField = value;
            }
        }

        /// <remarks/>
        public string BAR_DRAW
        {
            get
            {
                return this.bAR_DRAWField;
            }
            set
            {
                this.bAR_DRAWField = value;
            }
        }

        /// <remarks/>
        public string HORSE_WGT
        {
            get
            {
                return this.hORSE_WGTField;
            }
            set
            {
                this.hORSE_WGTField = value;
            }
        }

        /// <remarks/>
        public string HANDICAP_WGT
        {
            get
            {
                return this.hANDICAP_WGTField;
            }
            set
            {
                this.hANDICAP_WGTField = value;
            }
        }

        /// <remarks/>
        public string HORSE_WGT_CRT
        {
            get
            {
                return this.hORSE_WGT_CRTField;
            }
            set
            {
                this.hORSE_WGT_CRTField = value;
            }
        }

        /// <remarks/>
        public string LAST_HORSE_WGT
        {
            get
            {
                return this.lAST_HORSE_WGTField;
            }
            set
            {
                this.lAST_HORSE_WGTField = value;
            }
        }

        /// <remarks/>
        public string LAST_ONDAY_HORSE_WGT
        {
            get
            {
                return this.lAST_ONDAY_HORSE_WGTField;
            }
            set
            {
                this.lAST_ONDAY_HORSE_WGTField = value;
            }
        }

        /// <remarks/>
        public string LAST_HORSE_WGT_DATE
        {
            get
            {
                return this.lAST_HORSE_WGT_DATEField;
            }
            set
            {
                this.lAST_HORSE_WGT_DATEField = value;
            }
        }

        /// <remarks/>
        public string LAST_WIN_WGT
        {
            get
            {
                return this.lAST_WIN_WGTField;
            }
            set
            {
                this.lAST_WIN_WGTField = value;
            }
        }

        /// <remarks/>
        public string LAST_WIN_WGT_DATE
        {
            get
            {
                return this.lAST_WIN_WGT_DATEField;
            }
            set
            {
                this.lAST_WIN_WGT_DATEField = value;
            }
        }

        /// <remarks/>
        public string RATING
        {
            get
            {
                return this.rATINGField;
            }
            set
            {
                this.rATINGField = value;
            }
        }

        /// <remarks/>
        public string BLINKERS
        {
            get
            {
                return this.bLINKERSField;
            }
            set
            {
                this.bLINKERSField = value;
            }
        }

        /// <remarks/>
        public string DIFF_CLASS
        {
            get
            {
                return this.dIFF_CLASSField;
            }
            set
            {
                this.dIFF_CLASSField = value;
            }
        }

        /// <remarks/>
        public string ALLOWANCE
        {
            get
            {
                return this.aLLOWANCEField;
            }
            set
            {
                this.aLLOWANCEField = value;
            }
        }

        /// <remarks/>
        public string FREELANCE_ALLOWANCE
        {
            get
            {
                return this.fREELANCE_ALLOWANCEField;
            }
            set
            {
                this.fREELANCE_ALLOWANCEField = value;
            }
        }

        /// <remarks/>
        public string WIN_LAST5
        {
            get
            {
                return this.wIN_LAST5Field;
            }
            set
            {
                this.wIN_LAST5Field = value;
            }
        }

        /// <remarks/>
        public string PLA_LAST5
        {
            get
            {
                return this.pLA_LAST5Field;
            }
            set
            {
                this.pLA_LAST5Field = value;
            }
        }

        /// <remarks/>
        public string SADDLE_CLOTH
        {
            get
            {
                return this.sADDLE_CLOTHField;
            }
            set
            {
                this.sADDLE_CLOTHField = value;
            }
        }

        /// <remarks/>
        public string JOCKEY_CODE
        {
            get
            {
                return this.jOCKEY_CODEField;
            }
            set
            {
                this.jOCKEY_CODEField = value;
            }
        }

        /// <remarks/>
        public string JOCKEY_NAME
        {
            get
            {
                return this.jOCKEY_NAMEField;
            }
            set
            {
                this.jOCKEY_NAMEField = value;
            }
        }

        /// <remarks/>
        public string JOCKEY_NAME_C
        {
            get
            {
                return this.jOCKEY_NAME_CField;
            }
            set
            {
                this.jOCKEY_NAME_CField = value;
            }
        }

        /// <remarks/>
        public string JOCKEY_NAME_SC
        {
            get
            {
                return this.jOCKEY_NAME_SCField;
            }
            set
            {
                this.jOCKEY_NAME_SCField = value;
            }
        }

        /// <remarks/>
        public string JOCKEY_STAT
        {
            get
            {
                return this.jOCKEY_STATField;
            }
            set
            {
                this.jOCKEY_STATField = value;
            }
        }

        /// <remarks/>
        public string JOCKEY_WIN_STAT
        {
            get
            {
                return this.jOCKEY_WIN_STATField;
            }
            set
            {
                this.jOCKEY_WIN_STATField = value;
            }
        }

        /// <remarks/>
        public string JOCKEY_PLA_STAT
        {
            get
            {
                return this.jOCKEY_PLA_STATField;
            }
            set
            {
                this.jOCKEY_PLA_STATField = value;
            }
        }

        /// <remarks/>
        public string TRAINER_CODE
        {
            get
            {
                return this.tRAINER_CODEField;
            }
            set
            {
                this.tRAINER_CODEField = value;
            }
        }

        /// <remarks/>
        public string TRAINER_NAME
        {
            get
            {
                return this.tRAINER_NAMEField;
            }
            set
            {
                this.tRAINER_NAMEField = value;
            }
        }

        /// <remarks/>
        public string TRAINER_NAME_C
        {
            get
            {
                return this.tRAINER_NAME_CField;
            }
            set
            {
                this.tRAINER_NAME_CField = value;
            }
        }

        /// <remarks/>
        public string TRAINER_NAME_SC
        {
            get
            {
                return this.tRAINER_NAME_SCField;
            }
            set
            {
                this.tRAINER_NAME_SCField = value;
            }
        }

        /// <remarks/>
        public string TRAINER_STAT
        {
            get
            {
                return this.tRAINER_STATField;
            }
            set
            {
                this.tRAINER_STATField = value;
            }
        }

        /// <remarks/>
        public string OWNER_NAME
        {
            get
            {
                return this.oWNER_NAMEField;
            }
            set
            {
                this.oWNER_NAMEField = value;
            }
        }

        /// <remarks/>
        public string OWNER_NAME_C
        {
            get
            {
                return this.oWNER_NAME_CField;
            }
            set
            {
                this.oWNER_NAME_CField = value;
            }
        }

        /// <remarks/>
        public string OWNER_NAME_SC
        {
            get
            {
                return this.oWNER_NAME_SCField;
            }
            set
            {
                this.oWNER_NAME_SCField = value;
            }
        }

        /// <remarks/>
        public string LAST_SIX_RUNS
        {
            get
            {
                return this.lAST_SIX_RUNSField;
            }
            set
            {
                this.lAST_SIX_RUNSField = value;
            }
        }

        /// <remarks/>
        public string LAST_RATING
        {
            get
            {
                return this.lAST_RATINGField;
            }
            set
            {
                this.lAST_RATINGField = value;
            }
        }

        /// <remarks/>
        public string LAST_WEIGHT
        {
            get
            {
                return this.lAST_WEIGHTField;
            }
            set
            {
                this.lAST_WEIGHTField = value;
            }
        }

        /// <remarks/>
        public string SIRE
        {
            get
            {
                return this.sIREField;
            }
            set
            {
                this.sIREField = value;
            }
        }

        /// <remarks/>
        public string DAM
        {
            get
            {
                return this.dAMField;
            }
            set
            {
                this.dAMField = value;
            }
        }

        /// <remarks/>
        public string BEST_TIME
        {
            get
            {
                return this.bEST_TIMEField;
            }
            set
            {
                this.bEST_TIMEField = value;
            }
        }

        /// <remarks/>
        public string HORSE_AGE
        {
            get
            {
                return this.hORSE_AGEField;
            }
            set
            {
                this.hORSE_AGEField = value;
            }
        }

        /// <remarks/>
        public string SEX
        {
            get
            {
                return this.sEXField;
            }
            set
            {
                this.sEXField = value;
            }
        }

        /// <remarks/>
        public string IMPORT_CATEGORY
        {
            get
            {
                return this.iMPORT_CATEGORYField;
            }
            set
            {
                this.iMPORT_CATEGORYField = value;
            }
        }

        /// <remarks/>
        public decimal STAKES_WON
        {
            get
            {
                return this.sTAKES_WONField;
            }
            set
            {
                this.sTAKES_WONField = value;
            }
        }

        /// <remarks/>
        public string RUNNING_COMMENT
        {
            get
            {
                return this.rUNNING_COMMENTField;
            }
            set
            {
                this.rUNNING_COMMENTField = value;
            }
        }

        /// <remarks/>
        public string WFA
        {
            get
            {
                return this.wFAField;
            }
            set
            {
                this.wFAField = value;
            }
        }

        /// <remarks/>
        public string EQUIPMENT
        {
            get
            {
                return this.eQUIPMENTField;
            }
            set
            {
                this.eQUIPMENTField = value;
            }
        }

        /// <remarks/>
        public string OVERWEIGHT
        {
            get
            {
                return this.oVERWEIGHTField;
            }
            set
            {
                this.oVERWEIGHTField = value;
            }
        }

        /// <remarks/>
        public string INTERNATIONAL_RATING
        {
            get
            {
                return this.iNTERNATIONAL_RATINGField;
            }
            set
            {
                this.iNTERNATIONAL_RATINGField = value;
            }
        }

        /// <remarks/>
        public string PRIORITY
        {
            get
            {
                return this.pRIORITYField;
            }
            set
            {
                this.pRIORITYField = value;
            }
        }

        /// <remarks/>
        public string TRUMP_CARD
        {
            get
            {
                return this.tRUMP_CARDField;
            }
            set
            {
                this.tRUMP_CARDField = value;
            }
        }

        /// <remarks/>
        public string PREFERENCE
        {
            get
            {
                return this.pREFERENCEField;
            }
            set
            {
                this.pREFERENCEField = value;
            }
        }

        /// <remarks/>
        public string STANDBY
        {
            get
            {
                return this.sTANDBYField;
            }
            set
            {
                this.sTANDBYField = value;
            }
        }

        /// <remarks/>
        public string STANDBY_NUM
        {
            get
            {
                return this.sTANDBY_NUMField;
            }
            set
            {
                this.sTANDBY_NUMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool STANDBY_NUMSpecified
        {
            get
            {
                return this.sTANDBY_NUMFieldSpecified;
            }
            set
            {
                this.sTANDBY_NUMFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    }


}

