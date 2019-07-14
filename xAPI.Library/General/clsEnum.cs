using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace xAPI.Library.General
{
    public static class clsEnum
    {
        public static String SubGetStringValue(this Type value, Int32 id)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this typeAddress
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];


            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
        public static String GetValueById(Type _enum, Int32 attr)
        {

            Array values = Enum.GetValues(_enum);
            FieldInfo[] fi = _enum.GetFields();
            String Name = "";
            for (int i = 1; i < fi.Length; i++)
            {

                if (Convert.ToInt32(values.GetValue(i - 1)) == attr)
                {

                    StringValueAttribute[] attrs = fi[i].GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
                    if (attrs.Length > 0)
                    {
                        Name = attrs[0].StringValue;
                    }
                    //Name = values.GetValue(i - 1).ToString();
                    break;
                }
            }

            return Name;
        }
        public static String GetMessageById(Type _enum, Int32 attr)
        {

            Array values = Enum.GetValues(_enum);
            FieldInfo[] fi = _enum.GetFields();
            String Name = "";
            for (int i = 1; i < fi.Length; i++)
            {

                if (Convert.ToInt32(values.GetValue(i - 1)) == attr)
                {

                    StringMessageAttribute[] attrs = fi[i].GetCustomAttributes(typeof(StringMessageAttribute), false) as StringMessageAttribute[];
                    if (attrs.Length > 0)
                    {
                        Name = attrs[0].StringMessage;
                    }
                    //Name = values.GetValue(i - 1).ToString();
                    break;
                }
            }

            return Name;
        }
        public static String GetStringValue(this Enum value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            StringValueAttribute[] attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].StringValue;
            }
            return output;
        }
        public static Int32 GetValueByStringAttr(Type _enum, String attr)
        {
            Int32 ret = 0;
            Array values = Enum.GetValues(_enum);
            FieldInfo[] fi = _enum.GetFields();

            for (int i = 1; i < fi.Length; i++)
            {
                StringValueAttribute[] attrs = fi[i].GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
                if (attrs[0].StringValue == attr)
                {
                    ret = Convert.ToInt32(values.GetValue(i - 1));
                }
            }

            return ret;
        }
        public static String GetStringValue(Type _enum, Int32 IdEnum)
        {

            String stringValue = String.Empty;
            Array arrayValues = Enum.GetValues(_enum);

            string[] names = System.Enum.GetNames(_enum);
            for (int i = 0; i < arrayValues.Length; i++)
            {
                if ((Int32)arrayValues.GetValue(i) == IdEnum)
                {
                    Enum enumObj = (Enum)Enum.Parse(_enum, names[i]);
                    stringValue = enumObj.GetStringValue();
                    break;
                }
            }
            return stringValue;
        }
        public static String GetMessageValue(this Enum value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            StringMessageAttribute[] attrs = fi.GetCustomAttributes(typeof(StringMessageAttribute), false) as StringMessageAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].StringMessage;
            }
            return output;
        }

        public static string GetLocalizationValue(this Enum value)
        {
            string output = String.Empty;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            LocalizationAttribute[] attrs = fi.GetCustomAttributes(typeof(LocalizationAttribute), false) as LocalizationAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].LocalizationValue;
            }

            return output;
        }
    }

    #region Extension of Attribute
    public class StringValueAttribute : Attribute
    {
        public string StringValue { get; protected set; }
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
    }
    public class StringMessageAttribute : Attribute
    {
        public string StringMessage { get; protected set; }
        public StringMessageAttribute(string value)
        {
            this.StringMessage = value;
        }
    }
    public class LocalizationAttribute : Attribute
    {
        public string LocalizationValue { get; protected set; }
        public LocalizationAttribute(string value)
        {
            this.LocalizationValue = value;
        }
    }
    #endregion

    #region MyWallet

    public enum EnumPayoutsStatus
    {
        [StringValue("Available")]
        Complete = 1,
        [StringValue("Requested")]
        Requested = 2,
        [StringValue("Issued")]
        Issued = 3,
        [StringValue("Rejected")]
        Rejected = 4,
        [StringValue("Deleted")]
        Deleted = 5,
        [StringValue("Pending")]
        Pending = 6
    }

    public enum EnumPayoutsType
    {
        [StringValue("Commissions")]
        Commissions = 1,
        [StringValue("Hyperwallet")]
        Hyperwallet = 2,
        [StringValue("Check")]
        Check = 3,
        [StringValue("Debt")]
        Debt = 4,
        [StringValue("Monthly Commision")]
        MonthlyCommision = 5,
        [StringValue("Transfer Funds")]
        TransferFunds = 6,
        [StringValue("Used in Order")]
        UsedinOrder = 7,
        [StringValue("Account Credit Refund")]
        AccountCreditRefund = 12
    }

    public enum EnumPayoutsMethod
    {
        [StringValue("Unknown")]
        Unknown = 0,
        [StringValue("Propay")]
        Propay = 1,
        [StringValue("Manual")]
        Manual = 2,
        [StringValue("ACH")]
        ACH = 3,
        [StringValue("GPG")]
        GPG = 4,
        [StringValue("HyperWallet")]
        HyperWallet = 5
    }

    #endregion
    public enum EnumEntity
    {
        Individual = 1,
        Business = 2
    }

    public enum EnumAccion
    {
        Insert = 1,
        Edit = 2,
        Delete = 3,
        Ninguno = 0
    }

    public enum EnumRank
    {
        [StringValue("Zen 1")]
        Zen1 = 10,
        [StringValue("Zen 2")]
        Zen2 = 20,
        [StringValue("Zen 3")]
        Zen3 = 30,
        [StringValue("Zen 4")]
        Zen4 = 40,
        [StringValue("Zen 5")]
        Zen5 = 50,
        [StringValue("Zen 6")]
        Zen6 = 60,
        [StringValue("Zen 7")]
        Zen7 = 70,
        [StringValue("Zen 8")]
        Zen8 = 80,
        [StringValue("Zen 9")]
        Zen9 = 90,
        //[StringValue("Legacy")]
        //legacy = 100,
        [StringValue("Zen 10")]
        Zen10 = 100,

        [StringValue("Zen 11")]
        Zen11 = 110,

        [StringValue("Zen 12")]
        Zen12 = 120

    }
    public enum EnumContactMethod
    {
        Email = 1,
        Phone = 2
    }
    public enum EnumEnrollmentSponsorUrl
    {
        Username = 1,
        PromoterId = 2,
        Both = 3
    }

    public enum EnumFnClient
    {
        [StringValue("fn_buildtable();")]
        buildtable = 0,
        [StringValue("fn_filltable({0});")]
        filltable = 1,
        [StringValue("{0}({1});")]
        generic = 2
    }
    public enum EnumCardType
    {
        [StringValue("Visa")]
        Visa = 1,
        [StringValue("MasterCard")]
        MasterCard = 2,
        [StringValue("American Express")]
        AmericanExpress = 3,
        [StringValue("Discover")]
        Discover = 4,
        [StringValue("Diners")]
        Diners = 5

    }
    public enum EnumStatusParty
    {

        [StringValue("Opened")]
        Opened = 0,
        [StringValue("Closed")]
        Closed = 1

    }
    public enum EnumPartyScheduleStatus
    {
        [StringValue("Pending")]
        Pending = 0,
        [StringValue("Approved")]
        Approved = 1,
        [StringValue("Not Approved")]
        NotApproved = 2
    }
    public enum EnumGender
    {
        [StringValue("ALL")]
        All = 0,
        [StringValue("Male")]
        male = 1,
        [StringValue("Female")]
        female = 2,
        [StringValue("Company")]
        company = 3
    }

    public enum EnumPlanPayment
    {
        [StringValue("Plan_1Month")]
        Plan_1Month = 10,
        [StringValue("Plan_3Month")]
        Plan_3Month = 20,
        [StringValue("Plan_6Month")]
        Plan_6Month = 30,
        [StringValue("Plan_12Month")]
        Plan_12Month = 12
    }

    public enum EnumStatusOrder
    {
        /*[StringValue("Approved")] //Se registro correctamente en pasarela
        Approved = 1,
        [StringValue("StandBy")] //En proceso de registro en la pasarela
        StandBy = 2,
        [StringValue("NotProcessed")] //Error regitrando en pasarela
        NotProcessed = 3,
        [StringValue("TransactionDetailError")] //Se registro en la pasarela pero no en TransactionDetails
        TransactionDetailError = 4,
        [StringValue("Canceled")] //Cancelar Orden
        Canceled = 5*/
        [StringValue("Select All")]
        [LocalizationAttribute("_ENUM_ORDERTYPE_All")]
        Select = 0,
        [StringValue("Created")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_CREATED")]
        Created = 1,
        [StringValue("Pending")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_PENDING")]
        Pending = 2,
        [StringValue("Submitted")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_SUBMITTED")]
        Submitted = 3,
        [StringValue("Cancelled")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_CANCELLED")]
        Cancelled = 4,
        [StringValue("Printed")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_PRINTED")]
        Printed = 5,
        [StringValue("Shipped")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_SHIPPED")]
        Shipped = 6,
        [StringValue("Replacement")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_REPLACEMENT")]
        Replacement = 7,
        [StringValue("Returned")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_RETURNED")]
        Returned = 8,
        [StringValue("BackOrder")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_BACKORDER")]
        BackOrder = 9,
        [StringValue("PaymentRejected")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_PAYMENTREJECTED")]
        PaymentRejected = 10,
        [StringValue("Refunded")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_REFUNDED")]
        Refunded = 11,
        [StringValue("Unpaid")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_UNPAID")]
        Unpaid = 12,
        [StringValue("PartialRefunded")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_PARTIALREFUNDED")]
        PartialRefunded = 13,
        [StringValue("PendingRefund")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_PENDINGREFUND")]
        PendingRefund = 14,
        [StringValue("PaymentReceived")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_PAYMENTRECEIVED")]
        PaymentReceived = 15,
        [StringValue("SubmitToFinancing")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_SUBMITTOFINANCING")]
        SubmitToFinancing = 16,
        [StringValue("RigthToRescind")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_RIGHTTORESCIND")]
        RigthToRescind = 17,
        [StringValue("FailedFinancing")]
        [LocalizationAttribute("_ENUM_ORDERSTATUS_FAILEDFINANCING")]
        FailedFinancing = 18
    }

    public enum EnumStatusInstallation
    {
        [StringValue("ToBeScheduled")]
        Refunded = 1,
        [StringValue("Scheduled")]
        PendingRefund = 2,
        [StringValue("WaitInstallCost")]
        WaitInstallCost = 3,
        [StringValue("InstallationComplete")]
        InstallationComplete = 4
    }

    public enum EnumStatusOrderPendingRefund
    {
        [StringValue("Refunded")]
        [LocalizationAttribute("_ENUM_ORDER_REFUNDED")]
        Refunded = 11,
        [StringValue("PendingRefund")]
        [LocalizationAttribute("_ENUM_ORDER_PENDINGREFUND")]
        PendingRefund = 14
    }


    public enum EnumStatusAutoship
    {
        [StringValue("Created")]
        Created = 10,
        [StringValue("Active")]
        Active = 20,
        [StringValue("Paused")]
        Paused = 30,
        [StringValue("Deleted")]
        Deleted = 40,
        [StringValue("Canceled")]
        Canceled = 50,
        [StringValue("PendingEnroll")]
        PendingEnroll = 60
    }

    public enum EnumControlType
    {
        [StringValue("input")]
        Input = 1,
        [StringValue("textarea")]
        InputLarge = 2,
        [StringValue("ddl")]
        DropDownList = 3,
        [StringValue("url")]
        Url = 4,
        [StringValue("fileupload")]
        FileUpload = 5
    }

    public enum EnumEmailTemplates
    {

        Reminder = 2,
        ApproveYes = 7,
        ApproveNo = 8,
        Invited = 1050,
        welcome = 2057,
        Register = 2058,
        NewParty = 2059,
        Thank = 2062,
        Missed = 2063

    }

    public enum EnumVendorType
    {
        Distributor = 1,
        Corporation = 2

    }

    public enum EnumProductApproved
    {
        No = 0,
        Yes = 1
    }

    public enum EnumEmailAccess
    {
        [StringValue("mastermail@tru-friends.com|k+aRJKKGcsOsxh3P5u3gcQ==|Tru-Friends")]
        Mastermail = 1,
        [StringValue("billing@tru-friends.com|LAI7MxUXVD+KVMNFqFAAnCpWoe6JqALA4hWKI/0KoWI=|Tru-Friends Billing")]
        Billing = 2
    }

    public enum EnumEmailStatus
    {
        Success = 1,
        Error = 2,
        Cancelled = 3
    }

    public enum EnumFormType
    {
        EntryForm = 1,
        JudgeForm = 2,
        TemplateForm = 3
    }

    public enum EnumTypeEmailTemplates
    {
        PartyPlan = 1,
        CMS = 2,
        Notifications = 3,
        Responders = 4
    }

    public enum EnumTypeNote
    {
        [StringValue("Order")]
        Order = 1,
        [StringValue("Distributor")]
        Distributor = 2,
        [StringValue("Product")]
        Product = 3
    }

    public enum EnumMimeType
    {
        [StringValue("Document")]
        Document = 1,
        [StringValue("Image")]
        Image = 2,
        [StringValue("Video")]
        Video = 3,
        [StringValue("Audio")]
        Audio = 4,
        [StringValue("Presentation")]
        Presentation = 5
    }

    public enum EnumAccessType
    {
        [StringValue("Standard")]
        Standard = 1,
        [StringValue("Admin")]
        Admin = 2
    }
    public enum EnumTypeResource
    {
        [StringValue("Story")]
        Story = 0,
        [StringValue("Photo")]
        Photo = 1
    }
    public enum EnumSettingAccess
    {
        [StringValue("Roles")]
        Roles = 0,
        [StringValue("Pages")]
        Pages = 1,
        [StringValue("Report")]
        Report = 2,
    }
    public enum EnumTypeLanguageTranslation
    {
        [StringValue("WebandMovil")]
        WebandMovil = 1,
        [StringValue("Web")]
        Web = 2,
        [StringValue("Movil")]
        Movil = 3,
    }
    public enum EnumAccessQuery
    {
        [StringValue("SuperADmin")]
        Admin = -1
    }
    public enum EnumLibrary
    {
        [StringValue("Video")]
        Video = 1,
        [StringValue("Brochure")]
        Brochure = 2,
        [StringValue("Document")]
        Document = 3,
        [StringValue("FAQ")]
        FAQ = 4
    }
    public enum EnumExportFileExtension
    {
        [StringValue("csv")]
        csv = 1,
        [StringValue("xls")]
        xls = 2,
        [StringValue("txt")]
        txt = 3
    }
    public enum EnumExportDelimiter
    {
        [StringValue(",(comma)")]
        comma = 1,
        [StringValue("|(pipe)")]
        pipe = 2,
        [StringValue(":(colon)")]
        colon = 3,
        [StringValue("TAB")]
        TAB = 4
    }
    public enum EnumExportEncapsulation
    {
        [StringValue("'(single quote)")]
        singlequote = 1,
        [StringValue("*(double quote)")]
        doublequote = 2,
        [StringValue("None")]
        none = 3
    }
    public enum EnumExportType
    {
        [StringValue("Flat File")]
        Flat = 0,
        [StringValue("3PL Company A")]
        CompanyA = 1,
        [StringValue("3PL Company B")]
        CompanyB = 2

    }
    public enum EnumLibrarySectionFAQ
    {
        [StringValue("Library")]
        Library = 0,
        [StringValue("ASEA")]
        ASEA = 1,
        [StringValue("RENU28")]
        RENU28 = 2,

    }
    public enum EnumMessageError
    {
        [StringValue("Not authorized.")]
        Notauthorized = 1,
        [StringValue("Error in sending data")]
        Errorsendingdata = 2
    }
    public enum EnumFolderSettings
    {
        [StringValue("export\\")]
        FolderExport = 1,
        [StringValue("resources\\")]
        FolderResources = 2,
        [StringValue("images\\")]
        FolderImages = 3,
        FolderUpdates = 4,
        [StringValue("review\\")]
        FolderReview = 5,
        [StringValue("docs\\")]
        FolderDocs = 6,
        [StringValue("shippingFiles\\")]
        FolderShipping = 7,
        [StringValue("docs/")]
        FolderPDF = 8,
        [StringValue("images/")]
        ImageFolder = 9
    }
    public enum EnumxBackofficePathToReadFile
    {
        [StringValue("~/src/images/")]
        Image = 1,
    }
    public enum EnumRowGrid
    {
        [StringValue("")]
        Limit = 2000,
    }
    public enum EnumTypeRate
    {
        [StringValue("")]
        ExchangeRate = 1,
        [StringValue("")]
        PegRate = 2,
    }
    public enum EnumFolderType
    {
        [StringValue("products\\")]
        FolderProducts = 1,
        [StringValue("profile\\")]
        FolderProfile
    }

    public enum EnumResourcesExtlName
    {

        [StringValue("_profile.jpg")]
        Profile = 1,
        [StringValue("_product.jpg")]
        Product = 2,
        [StringValue("_mainhome.jpg")]
        MainHome = 3,
        [StringValue("_lefthome.jpg")]
        LeftHome = 4,
        [StringValue("_centerhome.jpg")]
        CenterHome = 5,
        [StringValue("_rigthhome.jpg")]
        RigthHome = 6,
        [StringValue("_cover.jpg")]
        Cover = 7,
        [StringValue("_background.jpg")]
        Background = 8,
        [StringValue("_aboutComp.jpg")]
        AboutComp = 9,
        [StringValue("_contact.jpg")]
        Contact = 10,
        [StringValue("_complan.pdf")]
        Complan = 11
    }

    public enum EnumAddressType
    {
        Home = 0,
        Billing = 1,
        Shipping = 2,
        Work = 3,
        Taxpayer = 4,
        Residence = 5,
        Mailing = 6,
        Contact = 10
    }

    public enum EnumAddressCharType
    {
        [StringValue("Kanji")]
        [LocalizationAttribute("_ENUM_KANJI")]
        Kanji = 1,
        [StringValue("Kana")]
        [LocalizationAttribute("_ENUM_KANA")]
        Kana = 2,
        [StringValue("Roman")]
        [LocalizationAttribute("_ENUM_ROMAN")]
        Roman = 3,
        [StringValue("Cyrillic")]
        [LocalizationAttribute("_ENUM_CYRILLIC")]
        Cyrillic = 4
    }

    public enum EnumLanguageCharSet
    {
        [StringValue("ja-JP Kanji")]
        ja_JP_Kanji = 1,
        [StringValue("ja-JP Kana")]
        ja_JP_Katakana = 2,
        [StringValue("ja-JP Roman")]
        ja_JP_Roman = 3,
        [StringValue("en-US Roman")]
        en_US_Roman = 4,
        [StringValue("es-US Roman")]
        es_US_Roman = 5,
        [StringValue("ru-RU Cyrillic")]
        ru_RU_Cyrillic = 6,
        [StringValue("ru-RU Roman")]
        ru_RU_Roman = 7
    }

    public enum EnumAddresPayment
    {
        [StringValue("Billing")]
        Billing = 1,
        [StringValue("Shipping")]
        Shipping = 2,
        [StringValue("Other")]
        Other = 0
    }

    public enum EnumDefaultCard
    {
        [StringValue("Default")]
        Default = 0,
        [StringValue("Backup")]
        Backup = 1
    }

    public enum EnumAccountType
    {
        [StringValue("Affiliate")]
        Distributor = 10,
        [StringValue("Preferred Customer")]
        PreferredCustomer = 20,
        [StringValue("Retail Customer")]
        RetailCustomer = 30,
        [StringValue("Customer")]
        Customers = 40,
        [StringValue("Associate")]
        Associate = 1,
        [StringValue("Contract")]
        Contract = 50
    }


    //public enum EnumAccountType
    //{
    //    PreferredCustomer = 0,  // Enroll
    //    IndependentExecutive = 1,
    //    RetailCustomer = 2 //para Buy
    //}
    public enum EnumBankAccountType
    {
        Checking = 0,
        Savings = 1
    }

    public enum EnumDomain
    {
        [StringValue("www.tru-friends.com")]
        Domain = 1,
        [StringValue("test.tru-friends.com")]
        Test = 2,
        [StringValue("localhost")]
        Localhost = 3

    }

    //public enum EnumCloseAccount
    //{
    //    [StringValue("I chose a different solution")]
    //    DifferenSolution = 1,
    //    [StringValue("The pricing is confusing")]
    //    PricingConfusing = 2,
    //    [StringValue("The pricing is too high")]
    //    PricingHigh = 3,
    //    [StringValue("The product is too difficult to use")]
    //    TheProductDifficult = 4,
    //    [StringValue("I do not host events")]
    //    Localhost = 5,
    //    [StringValue("The product lacks the necessary features")]
    //    Localhost = 6,
    //    [StringValue("I do not recall signing up for xEvent")]
    //    Localhost = 7,
    //    [StringValue("Other (Please explain)")]
    //    Localhost = 8,


    //}

    public enum EnumDomainReplicate
    {
        [StringValue("xreplicate-asea.xirectss.com")]
        Domain = 1,
        [StringValue("xreplicate-asea.xirectss.com")]
        Test = 2,
        [StringValue("localhost")]
        Localhost = 3
    }

    public enum EnumAppType
    {
        [StringValue("Free")]
        Free = 1,
        [StringValue("Paid")]
        Paid = 2
    }
    public enum EnumLogType
    {
        [StringValue("Product")]
        Product = 1,
        [StringValue("User")]
        User = 2,
        [StringValue("Parties")]
        Parties = 20,
    }
    public enum EnumxReplicatePathToReadFile
    {
        [StringValue("/src/distributor/images/profile/")]
        Image = 1
    }
    public enum EnumActionEmailTemplate
    {
        [StringValue("All")]
        [LocalizationAttribute("_ENUM_ACTIONEMAILTEMPLATE_ALL")]
        All = -1,
        [StringValue("User")]
        [LocalizationAttribute("_ENUM_ACTIONEMAILTEMPLATE_USER")]
        User = 0,
        [StringValue("System")]
        [LocalizationAttribute("_ENUM_ACTIONEMAILTEMPLATE_SYSTEM")]
        System = 1,
        [StringValue("Invitation")]
        [LocalizationAttribute("_ENUM_ACTIONEMAILTEMPLATE_INVITATION")]
        Invitation = 2,
        [StringValue("Remind")]
        [LocalizationAttribute("_ENUM_ACTIONEMAILTEMPLATE_REMIND")]
        Remind = 3,
        [StringValue("Gratitude")]
        [LocalizationAttribute("_ENUM_ACTIONEMAILTEMPLATE_GRATITUDE")]
        Gratitude = 4,
        [StringValue("Miss You")]
        [LocalizationAttribute("_ENUM_ACTIONEMAILTEMPLATE_MISSYOU")]
        Missyou = 5
    }

    public enum EnumReportTypes
    {
        [StringValue("SP_XB_RPT_EXECUTIVEDASHBOARD")]
        ExecutiveDashboard = 1,

        [StringValue("SP_XB_RPT_COMMISSIONSUMMARY")]
        CommissionSummary = 2,

        [StringValue("SP_XB_RPT_ORDERHISTORY")]
        OrderHistory = 3,

        [StringValue("SP_XB_RPT_EARNINGSHISTORY")]
        EarningsHistory = 4,

        [StringValue("SP_XB_REPORT_DistributorsbyStatus")]//No existe SP
        DistributorsbyStatus = 5,

        [StringValue("SP_XB_REPORT_Autoships")]//No existe SP
        Autoships = 6,
        //fhGgAQNK31qtvtVAGJcnfQ%3d%3d
        [StringValue("SP_XB_REPORT_Birthdays")]//No existe SP
        Birthdays = 11,

        [StringValue("SP_XB_REPORT_CustomersbyStatus")]//No existe SP
        CustomersbyStatus = 8,

        [StringValue("SP_XB_REPORT_DistributorsBirthdays")]//No existe SP
        DistributorsBirthdays = 9,


        [StringValue("SP_REPORT_DISTRIBUTORPURCHASES")]
        TotalPurchases = 17,
        //TcSdlvGa0dp%2fGAKz3V7AQA%3d%3d

        [StringValue("SP_REPORT_TOTALBONUSESBYPERIOD")]//
        TotalBonusesForThisPeriod = 15,
        //jOwa2VF0Un9QaXSixX%2bhTQ%3d%3d

        [StringValue("SP_XB_REPORT_DistributorsBirthdays")]//No existe SP
        TotalCurrentInventory = 12,
        //XoTKnBwxiwBPqPv7WpgMvQ%3d%3d

        [StringValue("SP_REPORT_TOTALSALES_BYDISTRIBUTORID")]//
        TotalSales = 13,
        //D8XqVnsEtlqDMV13azxvmA%3d%3d

        [StringValue("SP_XB_REPORT_DistributorsBirthdays")]
        TotalGroupPurchases = 16,
        //S9f1%2fWAl5%2fAU63nSqBjcyw%3d%3d
        [StringValue("SP_XB_REPORT_OrdersByFriendsdates")]
        OrdersByFriendsdates = 7,
        //%2fifyS9R9AXIuXsOSXOSTEg%3d%3d
        [StringValue("SP_XB_REPORT_TotalPayoutstoFriends")]
        TotalPayoutstoFriends = 14,
        //%2bdXIjP4cm6nFedGiJB1kOg%3d%3d
        [StringValue("SP_XB_REPORT_Recruiting")]
        Recruiting = 10
        //CEXIKfZeDy9fnCDI9ClBeQ%3d%3d
    }



    public enum EnumDistributorStatus
    {
        [StringValue("Begun Enrollment")]
        BegunEnrollment = 0,
        [StringValue("Cancelled")]
        Cancelled = 1,
        [StringValue("Active")]
        Active = 2,
        [StringValue("Inactive")]
        Inactive = 3,
        [StringValue("Suspended")]
        Suspended = 4,
        [StringValue("Deleted")]
        Deleted = 5,
        [StringValue("Pending")]
        NeedUpgrade = 6,
        [StringValue("Lock xBackOffice")]
        LockxBacOffice = 7,
        [StringValue("Force Active")]
        ForceActive = 8,
        [StringValue("Override Qualifications")]
        OverrideQualifications = 9,
        [StringValue("Tax Exempt")]
        TaxExempt = 10,
        [StringValue("Terminated")]
        Terminate = 11,
        [StringValue("Dormant")]
        Dormant = 12,
        [StringValue("All")]
        All = -1,

    }

    public enum EnumOrganizerStatus
    {
        [StringValue("Cancelled")]
        Cancelled = 1,
        [StringValue("Active")]
        Active = 2,
        [StringValue("Inactive")]
        Inactive = 3,
        [StringValue("Suspended")]
        Suspended = 4,
        [StringValue("Deleted")]
        Deleted = 5,

    }

    public enum EnumUserStatus
    {
        Inactive = 0,
        Active = 1,
        Deleted = 2,
        Cancelled = 3,
        Suspended = 4
    }

    public enum EnumMyApp
    {
        [StringValue("TruDating")]
        TruDating = 1
    }

    public enum EnumOperationType
    {
        [StringValue("Email Sent")]
        EmailSent = 0,
        [StringValue("Share Contact")]
        ShareContacts = 1,
        [StringValue("Campaign Sent")]
        CampaignSent = 2
    }

    public enum EnumModules //Name Site
    {

        [StringValue("TruFriends")]
        TruFriends = 1,
        [StringValue("TruFriendsTest")]
        TruFriendsTest = 2
    }

    public enum EnumThemes
    {
        [StringValue("classic")]
        classic = 1,
        [StringValue("black")]
        black = 2
    }

    public enum EnumTypeEvent
    {
        [StringValue("Challenge")]
        Challenge = 11,
        [StringValue("Competition")]
        Competition = 13,
        [StringValue("Contest")]
        Contest = 14
    }

    public enum EventEndIntructionsType
    {
        ArchiveEvent = 1,
        OneTimeEvent = 0
    }


    public enum EnumDefault
    {
        [StringValue("RoundsNumber")]
        RoundsNumber = 3
    }

    public enum EnumVotingTypes
    {
        [StringValue("Judges Panel")]
        JudgesPanel = 1,
        [StringValue("Online Voting")]
        OnlineVoting = 2
    }

    public enum EnumVotingRestriccion
    {
        [StringValue("By Ip")]
        ByIp = 19,
        [StringValue("Hour")]
        ByHour = 20,
        [StringValue("Day")]
        ByDay = 21,
        [StringValue("Month")]
        ByMonth = 22,
        [StringValue("Event")]
        ByEvent = 23
    }

    public enum EnumCategoryTypes
    {
        [StringValue("Currency")]
        Currency = 1,
        [StringValue("Award")]
        Award = 2,
        [StringValue("Voting Types")]
        VotingType = 3,
        [StringValue("Voting Restriction")]
        VotingRestriction = 4,
        [StringValue("TypeTeam")]
        EventMember = 5,
        [StringValue("TypeSatff")]
        TypeStaff = 7,
        [StringValue("RelatedEventCategory")]
        RelatedEventCategory = 10,
        [StringValue("EventCoverage")]
        EventCoverage = 11
    }

    public enum EnumTypeEventMember
    {
        [StringValue("ManagedTeam")]
        ManagedTeam = 58,
        [StringValue("CoorporateStaff")]
        CoorporateStaff = 59,
        [StringValue("Sponsors")]
        Sponsors = 60,
        [StringValue("Contestants")]
        Contestants = 75,
        [StringValue("Judges")]
        Judges = 78
    }

    public enum EnumTypeStaff
    {
        [StringValue("Employees")]
        Employees = 68,
        [StringValue("Investors")]
        Investors = 69,
        [StringValue("Joint Venture Partners")]
        JointVenturePartners = 70,
        [StringValue("Member")]
        Member = 74
    }

    public enum EnumGenealogyIco
    {

        [StringValue("circle")]
        circle = 0,
        [StringValue("star")]
        star = 1,
        [StringValue("point")]
        point = 2,
        [StringValue("circle")]
        circle2 = 3
    }
    public enum EnumGenealogyLimit
    {

        [StringValue("BackupMax")]
        BackupMax = Int32.MaxValue,

    }
    public enum EnumGenealogyStatus
    {

        [StringValue("completed")]
        complete = 10,
        [StringValue("scheduled")]
        scheduled = 20,
        [StringValue("failed")]
        failed = 30,
        [StringValue("cancelled")]
        cancelled = 40,
        [StringValue("nonautoship")]
        nonautoship = 60,
        [StringValue("nonqualautoship")]
        nonqualautoship = 70

    }
    public enum EnumGenealogyStatusWeb
    {

        [StringValue("completed")]
        complete = 10,
        [StringValue("scheduled")]
        scheduled = 20,
        [StringValue("Failed")]
        failed = 30,
        [StringValue("cancelled")]
        cancelled = 40,
        [StringValue("nonautoship")]
        nonautoship = 60,
        [StringValue("nonqualautoship")]
        nonqualautoship = 70

    }

    public enum EnumRegistrationToEnterEvent
    {
        Paid = 1,
        Free = 0
    }
    public enum EnumEventViewing
    {
        Private = 1,
        Public = 0
    }
    public enum EnumSettingsType
    {
        Comments = 1,
        Thumbs = 2,
        Stars = 3
    }
    public enum EnumCoreForm
    {

        [StringMessage("?rl={3}&ur={0}&dt={1}&m={2}")]
        [StringValue("Join")]
        Join = 1,
        [StringMessage("?rl={3}&ur={0}&dt={1}&m={2}")]
        [StringValue("Order")]
        Order = 2,
        [StringMessage("?rl={4}&ur={0}&q={1}&dt={2}&m={3}")]
        [StringValue("Orderedit")]
        Orderedit = 3
    }
    public enum EnumSettingsOption
    {
        Enable = 1,
        Disable = 0
    }
    public enum EnumVirtualPath //Path para el APP virtual
    {
        [StringValue("")]
        xBackOffice = 0,
        [StringValue(@"C:\FolderPages\MySite")]
        xReplicate = 1,
        [StringValue("")]
        xCorporateWeb = 2,
        [StringValue(@"C:\FolderPagesTest\MySite")]
        xReplicateTest = 3,
        [StringValue(@"D:\FolderPages\TruFriends\MySite")]
        MySite = 4,
        [StringValue(@"D:\FolderPages\TruFriendsTest\MySite")]
        MySiteTest = 5
    }
    public enum EnumAppPool
    {
        [StringValue("TruFriends")]
        TruFriends = 0,
        [StringValue("TruFriendsTest")]
        TruFriendsTest = 1

    }
    public enum EnumOrderDetailType
    {
        [StringValue("Product")]
        Product = 0,
        [StringValue("App")]
        App = 1

    }
    public enum EnumAppDomainAppId
    {
        [StringValue("pADducIiXlXhKmgqMPvZAUi2J7oPTTQxJ6QQWT1NHyTiAhxsvts0bAxLse7n")]
        xCorporate = 0

    }

    public enum EnumSQLTables
    {
        [StringValue("TBL_TF_EVENT")]
        TBL_TF_EVENT = 1

        //[StringValue("App")]
        //App = 1

    }

    public enum EnumHTTPMETHOD
    {
        [StringValue("GET")]
        GET = 0,
        [StringValue("POST")]
        POST = 1
    }

    public enum EnumTypeLog
    {
        [StringValue("Propay")]
        Propay = 1,
        [StringValue("HyperWalletPay")]
        HyperWalletPay = 3,
        [StringValue("HyperWalletCreateAccount")]
        HyperWalletCreateAccount = 4,
        [StringValue("DistributorJoinDateUpdate")]
        DistributorJoinDateUpdate = 5,
        [StringValue("NationalProcessing")]
        NationalProcessing = 6,
        [StringValue("MetrictsGlobal")]
        MetricsGlobal = 7
    }

    public enum EnumRelatedCategory
    {
        [StringValue("Innovation")]
        Innovation = 79,
        [StringValue("Investments")]
        Investments = 80,
        [StringValue("Technology")]
        Technology = 81,
        [StringValue("Products")]
        Products = 82,
        [StringValue("Services")]
        Services = 83,
        [StringValue("Processes_Methods")]
        Processes_Methods = 84,
        [StringValue("Entertainment")]
        Entertainment = 85,
        [StringValue("Music")]
        Music = 86,
        [StringValue("Movie_Video")]
        Movie_Video = 87,
        [StringValue("Art")]
        Art = 88,
        [StringValue("Community")]
        Community = 89,
        [StringValue("Family")]
        Family = 90,
        [StringValue("Company")]
        Company = 91,
        [StringValue("Non_Profit")]
        Non_Profit = 92,
        [StringValue("Government")]
        Government = 93
    }

    public enum EnumTypeReview
    {
        STORY = 1,
        PHOTO = 2,
        ABOUTCOMPANY = 3,
        MISSION = 4,
        CONTACT = 5,
        CORPMESSAGE = 6,
        COMPLAN = 7,
        HOMEIMGMAIN = 8,
        HOMEIMGLEFT = 9,
        HOMEIMGCENTER = 10,
        HOMEIMGRIGHT = 11,
        ABOUTCOMPANYPICTURE = 12,
        CONTACTPICTURE = 13
    }

    public enum EnumEventType
    {
        Global = 1,
        Distributor = 2,
        Online = 3
    }

    public enum EnumEventCoverage
    {
        [StringValue("Local - District or City")]
        Local_District_City = 94,
        [StringValue("State - Province")]
        State_Province = 95,
        [StringValue("Regional")]
        Regional = 96,
        [StringValue("National")]
        National = 97,
        [StringValue("International")]
        International = 98,
        [StringValue("Global")]
        Global = 99
    }

    public enum EnumEventLasting
    {
        [StringValue("Day")]
        Days = 0,
        [StringValue("Week")]
        Weeks = 1,
        [StringValue("Month")]
        Months = 2
    }


    public enum EnumEventStatus
    {
        [StringValue("Cancelled")]
        Cancelled = 1,
        [StringValue("Active")]
        Active = 2,
        [StringValue("Deleted")]
        Published = 3,
        [StringValue("Created")]
        Inactive = 4,
        [StringValue("Suspended")]
        Suspended = 5,
        [StringValue("Deleted")]
        Deleted = 6,
        [StringValue("Running")]
        Running = 7,
        [StringValue("Expired")]
        Expired = 8,
    }

    public enum EnumFrequency
    {
        [StringValue("Weekly")]
        Weekly = 0,
        [StringValue("Bi-Weekly")]
        BiWeekly = 1,
        [StringValue("Monthly")]
        Monthly = 2
    }
    public enum EnumQuerystring
    {
        [StringValue("aXis.Corporate.|{0}|.Orders")]
        AxisCorporateOrders = 0,
        [StringValue("aXis.Corporate.|{0}|.Distributor")]
        AxisCorporateDistributor = 1,
        [StringValue("aXis.Corporate.|{0}|.Autoship")]
        AxisCorporateAutoship = 2,
        [StringValue("aXis.Corporate.|{0}|.AdjusmentsOverrides")]
        AxisCorporateAdjusmentsOverrides = 3
    }

    public enum EnumAlertType
    {
        [StringValue("s")]
        Success = 1,
        [StringValue("e")]
        Error = 2,
        [StringValue("i")]
        Info = 3,
        [StringValue("c")]
        Confirm = 4,
        [StringValue("b")]
        Custom = 5
    }
    public enum AddressType
    {

        Home = 0,
        Billing = 1,
        Shipping = 2,
        Mailing = 3,
        Primary = 4,
        Contact = 10

    }
    public enum EnumEnvironment
    {

        [StringMessage("lbldevenvironment")]
        [StringValue("Dev Environment")]
        Dev = 1,
        [StringMessage("lbltestenvironment")]
        [StringValue("Test Environment")]
        Test = 2,
        [StringMessage("lblstageenvironment")]
        [StringValue("Stage Environment")]
        Stage = 3,
        [StringMessage("")]
        [StringValue("")]
        Live = 4
    }

    public enum EnumFeeType
    {
        Money = 1,
        Percent = 2
    }

    public enum EnumRegex
    {
        [StringMessage("Error Required {0}")]
        [StringValue(@"^*$")]
        None = 0,
        [StringMessage("Error Phone | {0}")]
        [StringValue(@"^([\+][0-9]{1,3}[ \.\-])?([\(]{1}[0-9]{2,6}[\)])?([0-9 \.\-\/]{3,20})((x|ext|extension)[ ]?[0-9]{1,4})?$")]
        Phone = 1,
        [StringMessage("Error in the email format")]
        [StringValue(@"^((([a-zA-Z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-zA-Z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-zA-Z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-zA-Z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-zA-Z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-zA-Z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-zA-Z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-zA-Z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-zA-Z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-zA-Z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$")]
        Email = 2,
        [StringMessage("Error Integer {0}")]
        [StringValue(@"^[\-\+]?\d+$")]
        Integer = 3,
        [StringMessage("Error Number {0}")]
        [StringValue(@"^[\-\+]?(?:\d+|\d{1,3})(?:\.\d+)$")] // Number, including positive, negative, and floating decimal.
        Number = 4,
        [StringMessage("Error Date {0}")]
        [StringValue(@"^\d{1,2}[\/\-]\d{1,2}[\/\-]\d{4}$")]
        Date = 5,
        [StringMessage("Error CreditNumber {0}")]
        [StringValue(@"^([0-9][0-9]{0,4})+([0-9][0-9]{0,4})+([0-9][0-9]{0,4})+([0-9][0-9]{0,4})+$")]
        CreditNumber = 6,
        [StringMessage("Error URL {0}")]
        [StringValue(@"^(http(?:s)?\:\/\/[a-zA-Z0-9\-]+(?:\.[a-zA-Z0-9\-]+)*\.[a-zA-Z]{2,6}(?:\/?|(?:\/[\w\-]+)*)(?:\/?|\/\w+\.[a-zA-Z]{2,4}(?:\?[\w]+\=[\w\-]+)?)?(?:\&[\w]+\=[\w\-]+)*)$")]
        URL = 7,
        [StringMessage("Error DateHour {0}")]
        [StringValue(@"^\d{1,2}[\/\-]\d{1,2}[\/\-]\d{4}\s([0-9][0-9]{0,2}):([0-9][0-9]{0,2})$")]
        DateHour = 8,
        [StringMessage("Error OnlyNumber {0}")]
        [StringValue(@"^[0-9\ ]+$")]
        NumberAndSpaces = 9,
        [StringMessage("Error NoSpecialCharacters {0}")]
        [StringValue(@"^[0-9a-zA-Z \']+$")]
        NoSpecialCharacters = 10,
        [StringMessage("Error OnlyLetter {0}")]
        [StringValue(@"^[a-zA-Z\ \']+$")]
        OnlyLetter = 11,
        [StringMessage("Error Only Number and 2 Decimal {0}")]
        [StringValue(@"^\d+(\.\d{1,2})?$")]
        NumberAnd2Decimal = 12,
        [StringMessage("Error Only Number and 3 Decimal {0}")]
        [StringValue(@"^\d+(\.\d{1,3})?$")]
        NumberAnd3Decimal = 13,
        [StringMessage("Error OnlyNumber {0}")]
        [StringValue(@"^[0-9]+$")]
        OnlyNumber = 14,
        [StringMessage("Error Name {0}")] //ejemplo
        [StringValue(@"^[0-9]+$")]
        Name = 15,
        [StringMessage("Error Date {0}")]
        [StringValue(@"^\d{4}[\-]\d{2}[\-]\d{2}$")]
        Date_YYYYMMDD = 16,
        [StringMessage("Error NoSpecialCharacters {0}")]
        [StringValue(@"^[a-zA-Z]{2}$")]
        ISO_2code = 17,
        [StringMessage("Error Date {0}")]
        [StringValue(@"^[0-9]{12}$")]
        Date_YYYYMMDDHHmm = 18,
        [StringMessage("Error Only Number and 2 Decimal {0}")]
        [StringValue(@"^(\d|-)?(\d|.)*\,?\d{1,2}$")]
        NumberAnd2Decimal2 = 19,
    }
    public enum EnumRegexLength
    {
        None = 0,
        Exact = 1,
        AtLeast = 2,
        Between = 3,
        Max = 4
    }

    public enum EnumStatus
    {
        [StringValue("n")]
        Disabled = 0,//Inactive
        [StringValue("y")]
        Enabled = 1,//Active
        Deleted = 2,
        ShowAll = 3,
        [StringValue("s")]
        Suspended = 4,//Suspended
        [StringValue("u")]
        notSuspended = 5,
        [StringValue("p")]
        purged = 6
    }
    public enum EnumStatusFilter
    {
        [StringValue("All")]
        All = 0,
        [StringValue("StatusForRefundOrder")]
        StatusForRefundOrder = 1,
        [StringValue("StatusForEditOrderEntry")]
        StatusForEditOrderEntry = 2

    }

    public enum EnumLanguage
    {
        [StringValue("en-US")]
        United_States = 1,
        [StringValue("es-ES")]
        Spain = 2,
        [StringValue("fr-CA")]
        Français_Canadien = 3,
        [StringValue("de-DE")]
        German = 4,
        [StringValue("hu-HU")]
        Hungary = 5,
        [StringValue("fr-FR")]
        France = 6,
        [StringValue("en-IE")]
        Ireland = 7,
        [StringValue("nl-NL")]
        Netherlands = 8,
        [StringValue("de-AT")]
        Austria = 9,
        [StringValue("it-IT")]
        Italy = 10,
        [StringValue("en-GB")]
        Great_Britain = 11,
        [StringValue("sl-SI")]
        Slovenia = 12,
        [StringValue("nn-NO")]
        Norway = 13,
        [StringValue("nl")]
        Dutch = 14,
        [StringValue("fr-BE")]
        French_Belgium = 15,
        [StringValue("nl-BE")]
        Dutch_Belgium = 16,
        [StringValue("sv-SE")]
        Swedish = 17,
        [StringValue("hr-HR")]
        Croatian = 18,
        [StringValue("da-DK")]
        Denmark = 19,
        [StringValue("ro")]
        Romanian = 20,
        [StringValue("ja-JP")]
        Japan = 21

        /*[StringValue("es-PE")]
        Peru = 3*/
    }

    /*public enum EnumResxFilesUrl
    {
        //[StringValue(@"D:\Axis2\trunk\xCorporate\xCorporate\App_GlobalResources\Strings.")]
        [StringValue(@"C:\Users\Eder Salinas\Documents\Tortoise\Axis2.0\trunk\xCorporate\xCorporate\App_GlobalResources\Strings.")]//EDER HOME!!
        //[StringValue(@"C:\Users\Eder Salinas\Documents\Tortoise\Axis2\trunk\xReplicate - StyleFinal\xCorporate\App_GlobalResources\Strings.")]//EDER HOME!!
        //[StringValue(@"D:\xAPPS\xReplicate\App_GlobalResources\Strings.")]
        //[StringValue(@"D:\Axis2\trunk\xCorporate\xCorporate\App_GlobalResources\Strings.")]
        //[StringValue(@"D:\Subversion\Axis2.0\trunk\xCorporate\xCorporate\App_GlobalResources\Strings.")]
        //[StringValue(@"C:\Users\Richard\Documents\XIRECTSS\axis2.0\trunk\xCorporate\xCorporate\App_GlobalResources\Strings.")] 
        //[StringValue(@"D:\aXis2.0\trunk\xCorporate\xCorporate\App_GlobalResources\Strings.")]                
        Resx = 1
    }*/

    public enum EnumCachesName
    {
        [StringValue("Nav")]
        MenuTabs = 1,
        [StringValue("Rng")]
        RangeIp = 2,
        [StringValue("Lng")]
        Languages = 3,
        [StringValue("Acc")]
        CountryAccess = 4
    }

    public enum EnumKeysLanguageCache
    {
        [StringValue("All")]
        All = 1
    }

    public enum EnumKeysRangeIPCache
    {
        [StringValue("All")]
        All = 1
    }

    public enum EnumKeysCountryAccessCache
    {
        [StringValue("All")]
        All = 1
    }

    public enum EnumCountries//TBL_TF_COUNTRIES
    {
        [StringValue("United States")]
        United_States = 55
    }

    public enum EnumIPDefault
    {
        [StringValue("100.0.0.1")]
        IPDefaulUSA = 1
    }

    public enum EnumTypeAplication
    {
        [StringValue("All")]
        All = -1,
        [StringValue("Backoffice")]
        Axis = 1,
        [StringValue("Replicate-ASEA")]
        Replicate_Asea = 2
    }
    public enum EnumOrderType
    {
        [StringValue("AutoShip")]
        [LocalizationAttribute("_ENUM_ORDERTYPE_AUTOSHIP")]
        Autoship = 106,
        [StringValue("Refund Order")]
        [LocalizationAttribute("_ENUM_ORDERTYPE_REFUNDORDER")]
        RefundOrder = 107,
        [StringValue("Order")]
        [LocalizationAttribute("_ENUM_ORDERTYPE_ORDER")]
        Order = 108,
        [StringValue("Enroll")]//XPP
        [LocalizationAttribute("_ENUM_ORDERTYPE_ENROLL")]
        Enroll = 109,
        [StringValue("Retail Order")]
        [LocalizationAttribute("_ENUM_ORDERTYPE_RETAILORDER")]
        RetailOrder = 110,
    }

    public enum EnumRecognitionType
    {
        [StringValue("ECARDS")]
        Ecards = 1,
        [StringValue("Autoresponders")]
        Autoresponders = 2
    }

    //EnumAppCode reference to tbl_ResourceApplications
    // Value = 0 used for invalid AppId
    public enum EnumAppCode
    {
        [StringValue("All")]
        All = -1,
        [StringValue("xBackOffice")]
        xBackOffice = 2,
        [StringValue("xCorporate")]
        xCorporate = 3,
        [StringValue("ResourcesManagement")]
        ResourcesManagement = 4,
        [StringValue("MyProductPhotos")]
        MyProductPhotos = 7,
        [StringValue("PartyPlan")]
        PartyPlan = 11,
        [StringValue("Soxial")]
        SoxialMarketing = 12
    }

    public enum EnumAction
    {
        Insert = 1,
        Update = 2,
        Delete = 3,
        Select = 4
    }

    public enum EnumTypeContact
    {
        ContactMe = 2
    }

    public enum EnumEmailApp
    {
        [StringValue("Contactme_xreplicated mail logs")]
        Contactme_xreplicted = 1,
        [StringValue("Axis")]
        Axis = 2
    }

    public enum EnumReportException
    {
        [StringValue("All")]
        All = 1,
        [StringValue("Not Found in XSS")]
        NotFoundXSS = 2,
        [StringValue("Not Found in InfoTrax")]
        NotFoundInfoTrax = 3,
        [StringValue("Business Site Name are different")]
        BusinessSitedifferent = 4

    }





    public enum EnumUCLoadGrid
    {
        [StringValue("LoadGrid")]
        LoadGrid = 0,
        [StringValue("LoadGridProd")]
        LoadGridProd = 1,
        [StringValue("LoadGeanology")]
        LoadGeanology = 2,
    }

    public enum EnumImageTypeOnEventRegistration
    {
        [StringValue("BAR")]
        BC = 1,
        [StringValue("QR")]
        QR = 2
    }
    public enum EnumUserType
    {
        [StringValue("User")]
        User = 0,
        [StringValue("Role")]
        Role = 1
    }

    public enum EnumResourceType
    {
        Audio = 1,
        Image = 2,
        IdentificationDocument = 3,
        Photos = 4

    }

    //,
    //    Presentation = 4,
    //    WeminarLink = 5,
    //    Tutorial = 6


    public enum EnumVideoFileFormat
    {
        avi,
        mp4,
        wmv,
        fla,
        flv,
        mpeg,
        mpg
    }
    public enum EnumPresentationFileFormat
    {
        ppt,
        pptx
    }
    public enum EnumImageFileFormat
    {
        gif,
        jpeg,
        jpg,
        tif,
        png,
        psd,
        ai,
        eps,
        bmp

    }
    public enum EnumAudioFileFormat
    {
        mp3,
        wma,
        wav,
        midi
    }

    public enum EnumDocumentFileFormat
    {
        doc,
        docx,
        xls,
        xlsx,
        ppt,
        pdf,
        pptx,
        txt,
        html
    }
    public enum EnumDocumenImagetFileFormat
    {
        doc,
        docx,
        xls,
        xlsx,
        ppt,
        pdf,
        pptx,
        txt,
        html,
        jpeg,
        jpg,
        png,
        gif,
        bmp,
    }
    public enum EnumFileExtentions
    {
        mp3,
        mpeg,
        doc,
        docx,
        xls,
        xlsx,
        ppt,
        pdf,
        pptx,
        wav,
        wmv,
        avi,
        mp4,
        m4v,
        gif,
        jpeg,
        jpg,
        tif,
        png,
        url,
        zip,
        rar,
        tar
    }


    public enum EnumMailCategory
    {
        [StringValue("Inbox")]
        Inbox = 1,
        [StringValue("Sent")]
        Sent = 2,
        [StringValue("Trash")]
        Trash = 3,
    }
    public enum EnumMailStatus
    {

        [StringValue("Read")]
        Read = 1,
        [StringValue("Unread")]
        Unread = 0,
        [StringValue("Delete")]
        Delete = 3
    }

    public enum EnumAlertStatus
    {
        [StringValue("Read")]
        Read = 1,
        [StringValue("Unread")]
        Unread = 0,
    }

    public enum EnumDistributorAdmin
    {
        ID = 10
    }

    //Modify by Eder - xEvent
    public enum EnumGeneralStatus
    {
        [StringValue("Disabled")]
        Disabled = 0,
        [StringValue("Enabled")]
        Enabled = 1,
        [StringValue("Deleted")]
        Deleted = 2
    }


    //public enum EnumTaxType
    //{
    //    [StringValue("Individual/Sole Proprietor")]
    //    IndividualProprietor = 1,
    //    [StringValue("C Corporation")]
    //    CCorporation = 2,
    //    [StringValue("S Corporation")]
    //    SCorporation = 3,
    //    [StringValue("Partnership")]
    //    Partnership = 4,
    //    [StringValue("Trust/estate")]
    //    TrustEstate = 5,
    //    [StringValue("Limited liability company (C Corporation)")]
    //    LimitedCCorporation = 6,
    //    [StringValue("Limited liability company (S Corporation)")]
    //    LimitedSCorporation = 7,
    //    [StringValue("Limited liability company (Partnership)")]
    //    LimitedPartnership = 8,
    //    [StringValue("Exempt Payee")]
    //    ExemptPayee = 9,
    //    [StringValue("Other")]
    //    Other = 10
    //}



    //public enum EnumEntityType
    //{
    //    [StringValue("Grantor Trust")]
    //    GrantorTrust = 1,
    //    [StringValue("Central bank of issue")]
    //    CCorporation = 2,
    //    [StringValue("Individual")]
    //    SCorporation = 3,
    //    [StringValue("Complex trust")]
    //    Partnership = 4,
    //    [StringValue("Tax-exempt organization")]
    //    TrustEstate = 5,
    //    [StringValue("Corporation")]
    //    LimitedCCorporation = 6,
    //    [StringValue("Estate")]
    //    LimitedSCorporation = 7,
    //    [StringValue("Private foundation")]
    //    LimitedPartnership = 8,
    //    [StringValue("Disregarded entity")]
    //    ExemptPayee = 9,
    //    [StringValue("Government")]
    //    Other = 10,
    //    [StringValue("Partnership")]
    //    Other = 10,
    //    [StringValue("International organization")]
    //    Other = 10,
    //    [StringValue("Simple trust")]
    //    Other = 10

    //}


    public enum EnumInvoice
    {

        [StringValue("Pending")]
        Pending = 1,
        [StringValue("Paid")]
        Paid = 2
    }

    public enum EnumTaxPayerNumberType
    {
        Ssn = 1,
        Ein = 2,

    }

    public enum EnumTicketType
    {
        [StringValue("Free")]
        Free = 0,
        [StringValue("Paid")]
        Paid = 1
    }

    public enum EnumCustomerType
    {
        [StringValue("Normal")]
        Normal = 0,
        [StringValue("Guest")]
        Guest = 1
    }


    public enum EnumAccInftrx
    {

        [StringValue("D")]
        [StringMessage("W")]
        Associate = 1,
        [StringValue("P")]
        [StringMessage("W")]
        PreferredCustomer = 2,
        [StringValue("C")]
        [StringMessage("R")]
        RetailCustomer = 3,

    }




    public enum EnumActionEmailTemplateParty
    {
        [StringValue("All")]
        All = -1,
        [StringValue("Invitation")]
        Invitation = 0,
        [StringValue("Remind")]
        Remind = 1,
        [StringValue("Gratitude")]
        Gratitude = 2,
        [StringValue("Missyou")]
        Missyou = 3
    }

    public enum EnumTemplateModule
    {
        [StringValue("Replicated Site")]
        [LocalizationAttribute("_ENUM_REPLICATED_SITE")]
        ReplicatedSite = 2,
        [StringValue("Party Plan")]
        [LocalizationAttribute("_ENUM_PARTY_PLAN")]
        PartyPlan = 3,
        [StringValue("AutoResponders")]
        [LocalizationAttribute("_ENUM_AUTO_RESPONDER")]
        AutoResponder = 4,
        [StringValue("General")]
        [LocalizationAttribute("_ENUM_GENERAL")]
        General = 5,
        [StringValue("Recognition")]
        [LocalizationAttribute("_ENUM_RECOGNITION")]
        Recognition = 6,
        [StringValue("xCorporate")]
        [LocalizationAttribute("_ENUM_CORPORATE")]
        Corporate = 7,
        [StringValue("xBackOffice")]
        [LocalizationAttribute("_ENUM_BACKOFFICE")]
        BackOffice = 8,
        [StringValue("xOrder")]
        [LocalizationAttribute("_ENUM_ORDER")]
        Order = 9,
        [StringValue("xEnrollment")]
        [LocalizationAttribute("_ENUM_ENROLLMENT")]
        Enrollment = 10,
        [StringValue("xAutoship")]
        [LocalizationAttribute("_ENUM_AUTOSHIP")]
        Autoship = 11,
        [StringValue("Commissions")]
        [LocalizationAttribute("_ENUM_COMMISSIONS")]
        Commissions = 12
    }



    public enum EnumModule
    {
        [StringValue("xCorporate")]
        xCorporate = 1,
        [StringValue("xBackoffice")]
        xBackoffice = 2,
        [StringValue("xReplicate")]
        xReplicate = 3,
        [StringValue("xOrder")]
        xOrder = 4,
        [StringValue("xEnroll")]
        xEnroll = 5,
        [StringValue("xAutoship")]
        xAutoship = 6,
        [StringValue("xWebservice")]
        xWebService = 7
    }
    //TBL_MODULE
    public enum EnumModuleS
    {
        [StringValue("xCorporate")]
        xCorporate = 1,
        [StringValue("xBackoffice")]
        xBackoffice = 2,
        [StringValue("xReplicate")]
        xReplicate = 3,
        [StringValue("xOrder")]
        xOrder = 4,
        [StringValue("xEnroll")]
        xEnroll = 5,
        [StringValue("xAutoship")]
        xAutoship = 6,
        [StringValue("xWebService")]
        xWebService = 7,
        [StringValue("xPOS")]
        xPOS = 8
    }

    public enum EnumAccType
    {
        [StringValue("Member")] // ex Associate
        Associate = 10,
        [StringValue("Preferred Customer")]
        PreferredCustomer = 20,
        [StringValue("Retail Customer")]
        RetailCustomer = 30,
        [StringValue("Customer")]
        Customer = 40,
        [StringValue("Distributor")]
        Distributor = 1
    }
    public enum EnumPriceLevel
    {
        [StringValue("Wholesale")]
        Wholesale = 1,
        [StringValue("Preferred Customer")]
        Preferred = 2,
        [StringValue("Retail")]
        Retail = 4
    }

    public enum EnumOrderFrom
    {
        [StringValue("Unknown")]
        Unknown = 0,
        [StringValue("xCorporate")]
        xCorporate = 1,
        [StringValue("xBackoffice")]
        xBackoffice = 2,
        [StringValue("xReplicate")]
        xReplicate = 3,
        [StringValue("xMobile")]
        xMobile = 4,
        [StringValue("xMerchant")]
        xMerchant = 5,
        [StringValue("xPP")]
        xPP = 6,
        [StringValue("xEnrollments")]
        xEnrollments = 7,
        [StringValue("xOrders")]
        xOrders = 8,
        [StringValue("xAutoship")]
        xAutoship = 9,
        [StringValue("xAdminOrder")]
        xAdminOrder = 10
    }

    public enum EnumMerchant
    {
        [StringValue("ProPay")]
        ProPay = 1,
        [StringValue("BrainTree")]
        BrainTree = 2, // IT MUST BE THE ID OF MERCHANT IN DATABASE
        [StringValue("GlobalCollect")]
        GlobalCollect = 3, // IT MUST BE THE ID OF MERCHANT IN DATABASE
        [StringValue("AuthorizeDotNet")]
        AuthorizeDotNet = 4, // IT MUST BE THE ID OF MERCHANT IN DATABASE        
        [StringValue("BaseCommerce")]
        BaseCommerce = 5,
        [StringValue("CGI")]
        CGI = 6,
        [StringValue("CASH")]
        Cash = 7,
        [StringValue("GPG")]
        GPG = 8,
        [StringValue("Free")]
        Free = 9,
        [StringValue("Single Card")]
        SingleCard = 10,
        [StringValue("Multiple Card")]
        MultipleCard = 11,
        [StringValue("Old Card")]
        OldCard = 12,
        [StringValue("Cash on Delyvery")]
        CashOnDelivery = 13,
        [StringValue("Bank Transfer")]
        BankTransfer = 14,
        [StringValue("Bank Wire")]
        BankWire = 15,
        [StringValue("Another Payment")]
        AnotherPayment = 16,
        [StringValue("JCB Card")]
        PropayJCB = 17,
        [StringValue("PayPal")]
        PayPal = 100,
        [StringValue("SafetyPay")]
        SafetyPay = 200,
        [StringValue("EWallet")]
        EWallet = 300,
        [StringValue("SafetyPay Cash")]
        SafetyPayCash = 400,
        [StringValue("Account Balance")]
        AccountBalance = 500,

    }

    public enum EnumJixiti_ApiKey
    {
        [StringValue("azgjhdf97321WFQ#$aGHFQ3$takhgfsavd")]
        ASEA = 1
    }

    public enum EnumPostAcion
    {
        [StringValue("Reach")]
        Reach = 10,
        [StringValue("Join")]
        Join = 20,
        [StringValue("Purchase")]
        Purchase = 30
    }


    public enum EnumBannerType
    {
        [StringValue("Report")]
        Report = 1,
        [StringValue("Recognition")]
        Recognition = 2
    }

    public enum EnumFilterCommission
    {
        [StringValue("Primary Bonus")]
        xPrimaryBonus = 1,
        [StringValue("Secundary Bonus")]
        xSecundaryBonus = 2
    }

    public enum EnumRecognitionPage
    {
        [StringValue("Fanfare")]
        Fanfare = 1,
        [StringValue("Million_Dollar_Club")]
        MillionDollarClub = 2,
        [StringValue("Fantastic_Ahievements")]
        FantasticAhievements = 3,
        [StringValue("Base_Camp")]
        BaseCamp = 4,
        [StringValue("Ascent")]
        Ascent = 5,
        [StringValue("Envision")]
        Envision = 6,
        [StringValue("Diamond_Retreat")]
        DiamondRetreat = 7,
        [StringValue("Rank_Advancements")]
        RankAdvancements = 8,
        [StringValue("Peak_Performance")]
        Peak_Performance = 9

    }


    public enum EnumDistributorRanks
    {
        //[StringValue("Product {{__DISTRIBUTOR__}}")]
        //ProductConsultant = 10,
        //[StringValue("Senior Product {{__DISTRIBUTOR__}}")]
        //SeniorProductConsultant = 20,
        //[StringValue("Area Manager")]
        //AreaManager = 30,
        //[StringValue("District Manager")]
        //DistrictManager = 40,
        //[StringValue("Regional Manager")]
        //RegionalManager = 50,
        //[StringValue("National Director")]
        //NationalDirector = 60,
        //[StringValue("National Director 1 Star")]
        //NationalDirector1Star = 70,
        //[StringValue("National Director 2 Star")]
        //NationalDirector2Star = 80,
        //[StringValue("National Director 3 Star")]
        //NationalDirector3Star = 90,
        //[StringValue("Distributor")]
        //Distributor = 0

        [StringValue("Zen 1")]
        Zen1 = 10,
        [StringValue("Zen 2")]
        Zen2 = 20,
        [StringValue("Zen 3")]
        Zen3 = 30,
        [StringValue("Zen 4")]
        Zen4 = 40,
        [StringValue("Zen 5")]
        Zen5 = 50,
        [StringValue("Zen 6")]
        Zen6 = 60,
        [StringValue("Affiliate")]
        Affiliate = 0,
        [StringValue("Zen 7")]
        Zen7 = 70,
        [StringValue("Zen 8")]
        Zen8 = 80,
        [StringValue("Zen 9")]
        Zen9 = 90,
        [StringValue("Zen 10")]
        Zen10 = 100,
        [StringValue("Zen 11")]
        Zen11 = 110,
        [StringValue("Zen 12")]
        Zen12 = 120
    }

    public enum EnumFilterReport
    {
        [StringValue("Sponsorship")]
        xSponsorship = 0,
        [StringValue("Binary")]
        xBinary = 1,
        [StringValue("Enrollment")]
        xEnrollment = 2,
        [StringValue("Placement")]
        xPlacement = 3,
        [StringValue("Customer")]
        xCustomer = 4

    }
    public enum EnumFilterEMP
    {
        [StringValue("Paid as Rank")]
        xPaidAsRank = 0,
        [StringValue("Bonuses Paid")]
        xBonusesPaid = 1
    }

    public enum EnumTreeTypes
    {
        [StringValue("EnrollmentTree")]
        enrollmentTree = 1,
        [StringValue("TeamTree")]
        teamTree = 2
    }


    public enum EnumPeakPerformanceSubmenu
    {
        [StringValue("Envision")]
        Envision = 1,
        [StringValue("Ascent")]
        Ascent = 2,
        [StringValue("Diamond_Retreat")]
        Diamond_Retreat = 3,
        [StringValue("Base_Camp")]
        Base_Camp = 4,
        [StringValue("Peak_Performance")]
        Peak_Performance = 5
    }
    public enum EnumReportJixitiApi
    {
        [StringValue("Associates D Enrollees")]
        AssociatesD = 1,
        [StringValue("Associates B, C, P Enrollees")]
        AssociatesBCP = 2,
        [StringValue("Sponsor Changes")]
        SponsorChanges = 3,
        [StringValue("Title Changes")]
        TitleChanges = 4,
        [StringValue("Autoship Differences")]
        AutoshipDifferences = 5,
        [StringValue("Rank Changes")]
        RankChanges = 6,
        [StringValue("Activity Changes")]
        ActivityChanges = 7
    }
    public enum EnumReportTopTen
    {
        [StringValue("Top Income Earners")]
        TopIncomeEarners = 1,
        [StringValue("Top Associate Enrollers")]
        TopAssociateEnrollers = 2,
        [StringValue("Emerging Leaders")]
        EmergingLeaders = 3,
        [StringValue("Autoship All-Star")]
        AutoshipAllStar = 4
    }

    public enum EnumRecognitionTable
    {
        [StringValue("All")]
        All = 0,
        [StringValue("Fanfare")]
        Fanfare = 1,
        [StringValue("MillionDollarClub")]
        MillionDollarClub = 2,
        [StringValue("Top10Report")]
        Top10Report = 3,
        [StringValue("PeakPerformace")]
        PeakPerformace = 4,
        [StringValue("RankAdvancements")]
        RankAdvancements = 5
    }
    public enum EnumAssociateType
    {
        [StringValue("registered_business_nz")]
        registered_business_nz = 10,
        [StringValue("without_tax_id_nz")]
        without_tax_id_nz = 20,
        [StringValue("valid_tax_id_nz")]
        valid_tax_id_nz = 30,

        [StringValue("join_a_hobby_aus")]
        join_a_hobby_aus = 40,
        [StringValue("registered_business_aus")]
        registered_business_aus = 50

    }


    public enum EnumMarkets
    {
        [StringValue("United States")]
        UnitedStates = 7,
        [StringValue("Japan")]
        Japan = 101,
        [StringValue("Australia")]
        Australia = 103,
        [StringValue("Singapore")]
        Singapore = 104,
        [StringValue("Canada")]
        Canada = 105,
        [StringValue("New Zealand")]
        NewZealand = 106,
        [StringValue("Russia")]
        Russia = 107,
        [StringValue("Poland")]
        Poland = 108
    }

    public enum EnumStatusPartyAtendee
    {
        Pending = 0,
        Confirmed = 1,
        Rejected = 2
    }
    public enum EnumEmailTemplatesType
    {
        Invited = 1,
        Missed = 2,
        Thank = 3,
        Invoice = 4,
        Review = 5

    }
    public enum EnumPartyConfirmation
    {
        [StringValue("Yes")]
        Yes = 1,
        [StringValue("No")]
        No = 2,
        [StringValue("Maybe")]
        Maybe = 3
    }

    public enum EnumEvalQuery
    {
        [StringValue("Enabled")]
        NoQuery = 0,
        [StringValue("Disabled")]
        OkQuery = 1,
        [StringValue("Deleted")]
        ErrorQuery = 2
    }


    public enum EnumAuth
    {
        [StringValue("Success")]
        NoRequired = 0,
        [StringValue("Required")]
        Required = 1
    }

    public enum EnumSettingsRegion
    {
        Company = 1,
        Commissions = 2,
        EmailConfig = 3,
        Notifications = 4,
        PaymentProcesing = 5,
        Markets = 6,
        Environment = 7,
        LegEnrollment = 8,
        Footers = 9,
        TreeEnroll = 10
    }


    public enum EnumPromoterSearchBy
    {
        [StringValue("Id")]
        Id = 0,
        [StringValue("LegacyNumber")]
        LegacyNumber = 1,
        [StringValue("Name")]
        Name = 2,
        [StringValue("LastName")]
        LastName = 3
    }


    public enum EnumPaymentType
    {
        [StringValue("CreditCard")]
        CreditCard = 1,
        [StringValue("Cash")]
        Cash = 2,
        [StringValue("AccountCredit")]
        AccounCredit = 3,
        [StringValue("Zennoa Bucks")]
        ZennoaBucks = 4,
        [StringValue("Financing")]
        Financing = 5,
        [StringValue("Tokenization")]
        Token = 6,
        [StringValue("BankWire")]
        BankWire = 7,
        [StringValue("JCBCard")]
        JCBCard = 17
    }

    public enum EnumPaymentTypeId
    {

        [StringValue("Credit Card")]
        M1 = 1,
        [StringValue("Cash")]
        rdCashCheck = 2,
        [StringValue("")]
        AccounCredit = 3,
        [StringValue("")]
        ZennoaBucks = 4,
        [StringValue("")]
        Financing = 5,
        [StringValue("")]
        Token = 6,
        [StringValue("Bank Wire")]
        rbBankWire = 7,
        [StringValue("Bank Transfer")]
        rbBankTransfer = 8,
        [StringValue("JCBCard")]
        M17 = 17
    }


    public enum EnumDetailPaymentType
    {
        [StringValue("Cash")]
        Cash = -1,
        [StringValue("Financing")]
        Financing = -4
    }

    public enum EnumBannerPosition
    {
        [StringValue("Main")]
        Main = 1,
        [StringValue("Center")]
        Center = 2,
        [StringValue("Footer1")]
        Footer1 = 3,
        [StringValue("Footer2")]
        Footer2 = 4
    }


    public enum EnumAutorepondersEnroll
    {
        [StringValue("ReceiveCorporateEmails")]
        Autoresponder1 = 1,
        [StringValue("ReceiveEmailsSponsor. ")]
        Autoresponder2 = 2,
        [StringValue("ReceiveCorporateCalls. ")]
        Autoresponder3 = 3,
        [StringValue("ReceiveCallSponsor.")]
        Autoresponder4 = 4
    }

    public enum EnumLanguageSession
    {
        [StringValue("en-US")]
        United_States = 1,
        [StringValue("es-US")]
        Spain = 2030,
        [StringValue("cs-CZ")]
        Cestina = 2024,
        [StringValue("da-DK")]
        Dansk = 19,
        [StringValue("de-DE")]
        Deutsch = 4,
        [StringValue("de-AT")]
        Deutsch_Osterreich = 9,
        [StringValue("en-AU")]
        Australia = 2026,
        [StringValue("en-CA")]
        Canada = 2022,
        [StringValue("da")]
        DenMark = 20,
        [StringValue("en-NZ")]
        Language1 = 2027,
        [StringValue("en-GB")]
        Language2 = 11,
        [StringValue("es-ES")]
        Language3 = 2,
        [StringValue("es-MX")]
        Language4 = 1021,
        [StringValue("fr-BE")]
        Language5 = 15,
        [StringValue("fr-CA")]
        Language6 = 3,
        [StringValue("fr-FR")]
        Language7 = 6,
        [StringValue("en-IE")]
        Language8 = 7,
        [StringValue("hr-HR")]
        Language9 = 18,
        [StringValue("it-IT")]
        Language10 = 10,
        [StringValue("hu-HU")]
        Language11 = 5,
        [StringValue("nl-BE")]
        Language12 = 16,
        [StringValue("nl-NL")]
        Language13 = 8,
        [StringValue("nn-NO")]
        Language14 = 13,
        [StringValue("pt-PT")]
        Language18 = 2023,
        [StringValue("ro")]
        french = 21,
        [StringValue("sk-SK")]
        Chinese = 2025,
        [StringValue("sl-SI")]
        Language15 = 12,
        [StringValue("fi-FI")]
        Language16 = 1022,
        [StringValue("sv-SE")]
        Language17 = 17

    }



    public enum EnumOptionsMainMenu
    {
        [StringValue("Market Selection")]
        MarketSelection = 0,
        [StringValue("Product Selection")]
        ProductSelection = 1,
        [StringValue("Cart Summary")]
        CartSummary = 2,
        [StringValue("Review Order")]
        ReviewOrder = 3,
        [StringValue("Order Complete")]
        OrderComplete = 4
    }

    public enum EnumFedexServiceType
    {
        [StringValue("EUROPE FIRST INTERNATIONAL PRIORITY")]
        EUROPE_FIRST_INTERNATIONAL_PRIORITY = 1,
        [StringValue("1 DAY FREIGHT")]
        FEDEX_1_DAY_FREIGHT = 2,
        [StringValue("2 DAY")]
        FEDEX_2_DAY = 3,
        [StringValue("2 DAY AM")]
        FEDEX_2_DAY_AM = 4,
        [StringValue("2 DAY FREIGHT")]
        FEDEX_2_DAY_FREIGHT = 5,
        [StringValue("3 DAY FREIGHT")]
        FEDEX_3_DAY_FREIGHT = 6,
        [StringValue("DISTANCE DEFERRED")]
        FEDEX_DISTANCE_DEFERRED = 7,
        [StringValue("EXPRESS SAVER")]
        FEDEX_EXPRESS_SAVER = 8,
        [StringValue("FIRST FREIGHT")]
        FEDEX_FIRST_FREIGHT = 9,
        [StringValue("FREIGHT ECONOMY")]
        FEDEX_FREIGHT_ECONOMY = 10,
        [StringValue("FREIGHT PRIORITY")]
        FEDEX_FREIGHT_PRIORITY = 11,
        [StringValue("GROUND")]
        FEDEX_GROUND = 12,
        [StringValue("NEXT DAY AFTERNOON")]
        FEDEX_NEXT_DAY_AFTERNOON = 13,
        [StringValue("NEXT DAY EARLY MORNING")]
        FEDEX_NEXT_DAY_EARLY_MORNING = 14,
        [StringValue("NEXT DAY END OF DAY")]
        FEDEX_NEXT_DAY_END_OF_DAY = 15,
        [StringValue("NEXT DAY FREIGHT")]
        FEDEX_NEXT_DAY_FREIGHT = 16,
        [StringValue("NEXT DAY MID MORNING")]
        FEDEX_NEXT_DAY_MID_MORNING = 17,
        [StringValue("FIRST OVERNIGHT")]
        FIRST_OVERNIGHT = 18,
        [StringValue("GROUND HOME DELIVERY")]
        GROUND_HOME_DELIVERY = 19,
        [StringValue("INTERNATIONAL ECONOMY")]
        INTERNATIONAL_ECONOMY = 20,
        [StringValue("INTERNATIONAL ECONOMY FREIGHT")]
        INTERNATIONAL_ECONOMY_FREIGHT = 21,
        [StringValue("INTERNATIONAL FIRST")]
        INTERNATIONAL_FIRST = 22,
        [StringValue("INTERNATIONAL PRIORITY")]
        INTERNATIONAL_PRIORITY = 23,
        [StringValue("INTERNATIONAL PRIORITY FREIGHT")]
        INTERNATIONAL_PRIORITY_FREIGHT = 24,
        [StringValue("PRIORITY OVERNIGHT")]
        PRIORITY_OVERNIGHT = 25,
        [StringValue("SAME DAY")]
        SAME_DAY = 26,
        [StringValue("SAME DAY CITY")]
        SAME_DAY_CITY = 27,
        [StringValue("SMART POST")]
        SMART_POST = 28,
        [StringValue("STANDARD OVERNIGHT")]
        STANDARD_OVERNIGHT = 29
    }


    #region xEvent

    public enum EnumEventDisplayStatus
    {

        [StringValue("Inactive")]
        Inactive = 0,
        [StringValue("Running")]
        Running = 1,
        [StringValue("Cancelled")]
        Cancelled = 2,
        [StringValue("Closed")]
        Closed = 3

        //[StringValue("Cancelled")]
        //Cancelled = 1,
        //[StringValue("Active")]
        //Active = 2,
        //[StringValue("Deleted")]
        //Published = 3,
        //[StringValue("Created")]
        //Inactive = 4,
        //[StringValue("Suspended")]
        //Suspended = 5,
        //[StringValue("Deleted")]
        //Deleted = 6,
        //[StringValue("Running")]
        //Running = 7,
        //[StringValue("Expired")]
        //Expired = 8,
    }


    public enum EnumEventCreationMethod
    {
        [StringValue("A new event")]
        NewEvent = 0,
        [StringValue("Using event template")]
        UsingEventTemplate = 1,
        [StringValue("Using existing event")]
        UsingExistingEvent = 2,
        [StringValue("Event without registration")]
        WithoutRegistration = 3
    }

    public enum EnumEventSendEmailMethod
    {
        [StringValue("Set scheduled emails to be manually sent instead")]
        ManuallySent = 0,
        [StringValue("Automatically adjust the send dates of scheduled emails")]
        AutomaticallyAdjustSendDates = 1,
        [StringValue("Make ALL emails inactive and automatically adjust the send dates of scheduled emails")]
        MakeAllEmailsInactive = 2
    }

    public enum EnumEventRegistrationOpenTo
    {
        [StringValue("Anyone (Public) ")]
        AnyOne = 0,
        [StringValue("Only those on an invitation list (Private)")]
        InvitationList = 1,
        [StringValue("Only thoise who register from a xEvent email invitation (Invite-Only)")]
        RegisterFromxEvent = 2
    }

    #endregion



    #region InfoTrax
    public enum EnumAddressTypeInfoTrax
    {
        [StringValue("Shipping")]
        Shipping = 1, // IT MUST BE THE ID OF MERCHANT IN DATABASE
        [StringValue("Billing")]
        Billing = 2 // IT MUST BE THE ID OF MERCHANT IN DATABASE
    }

    public enum EnumItx_OrderSource
    {
        [StringValue("Orders/Shopping Cart")]
        OrdersShoppingCart = /*200,*/51,
        [StringValue("Enrollments")]
        Enrollments = 201, //52,
        [StringValue("Party")]
        Party = 202, //53,
        [StringValue("POS")]
        POS = 203, //54,
        [StringValue("Replicated site")]
        ReplicatedSite = 204, //55,
        [StringValue("Autoship")]
        Autoship = 205 //56
    }


    #endregion

    public enum EnumCompany
    {
        [StringValue("xirectss")]
        xirectss = 1
    }

    public enum EnumDisabled
    {
        [StringValue("n")]
        Disabled = 1,//Inactive
        [StringValue("y")]
        Enabled = 0,//Active
        Deleted = 2
    }

    public enum AddressType_v2
    {

        Home = 0,
        Billing = 1,
        Shipping = 2,
        Mailing = 2
    }

    public enum EnumShippingProviderCredentials
    {
        [StringValue("FedEx")]
        FEDEX = 1,
        [StringValue("UPS")]
        UPS = 2,
        [StringValue("SUPS")]
        SUPS = 3,
        [StringValue("DHL")]
        DHL = 4
    }

    public enum EnumShippingProvider
    {
        [StringValue("FedEx")]
        FEDEX = 16
    }

    public enum AutoshipCancelReason
    {
        [StringValue("")]
        Nothing = 0,
        [StringValue("Too expensive")]
        TooExpensive = 1,
        [StringValue("Don't like the product")]
        Dontlike = 2,
        [StringValue("Other")]
        Other = 3

    }

    public enum EnumProductFrecuency
    {
        [StringValue("Monthly")]
        Monthly = 0,
        [StringValue("Anual")]
        Anual = 1
    }

    public enum EnumTaxProvider
    {
        [StringValue("Avalara")]
        Avalara = 1,
        [StringValue("Squire")]
        Squire = 2,
    }

    public enum EnumApiCredentials
    {
        [StringValue("E-Wallet")]
        EWallet = 5,
        [StringValue("GPG")]
        GPG = 6
    }

    public enum EnumDataTypes
    {
        [StringValue("String")]
        String = 1,
        [StringValue("Int")]
        Int = 2,
        [StringValue("Boolean")]
        Boolean = 3,
        [StringValue("DateTime")]
        DateTime = 4,
        [StringValue("Decimal")]
        Decimal = 5,
        [StringValue("Custom")]
        Custom = 6
    }

    public enum EnumFtpAction
    {
        [StringValue("Upload")]
        Upload = 1,
        [StringValue("Download")]
        Download = 2
    }

    public enum EnumUser
    {
        [StringValue("Ignore User xC")]
        IgnoreUser = -1,
        [StringValue("Automatic Job")]
        AutomaticJob = 99,
        [StringValue("Unknown")]
        Unknown = 0,
    }

    public enum EnumTemplatePurpose
    {
        [StringValue("Invitation")]
        Invitation = 1,
        [StringValue("Missed")]
        Missed = 2,
        [StringValue("Thank you for visiting my website")]
        ThankYou = 3,
        [StringValue("Enrollment Invoice")]
        EnrollInvoice = 4,
        [StringValue("Enroller Notification")]
        EnrollNotification = 5,
        [StringValue("Order Invoice")]
        OrderInvoice = 6,
        [StringValue("Your Product has Shipped")]
        ShippingNotification = 7,
        [StringValue("Contact Me")]
        ContactMe = 8,
        [StringValue("Thank you for visiting my replicated website")]
        ThanksVisitingSite = 9,
        [StringValue("xBackOffice Password Reset")]
        PasswordReset = 10,
        [StringValue("Distributor New sign up email")]
        xBackOfficeCredentials = 11,
        [StringValue("xCorporate Password Reset")]
        PasswordResetCorporate = 12,
        [StringValue("Customer new sign up email")]
        xBackOfficeCredentialsCustomer = 13,
        [StringValue("New xCorporate User")]
        xCorporateCredentials = 14,
        [StringValue("Commission Payout Notification")]
        PerformPayout = 15,
        [StringValue("Autoship Failed")]
        AutoshipFailed = 16,
        [StringValue("Credit Card Expired")]
        CardExpired = 17,
        [StringValue("Credit Card To Expired")]
        CardToExpired = 18,
        [StringValue("xBackoffice Password Changed")]
        PasswordChanged = 19
    }

    public enum EnumPaymentForm
    {
        [StringValue("Card")]
        Card = 1,
        [StringValue("Card list")]
        CardList = 2,
        [StringValue("Cash")]
        Cash = 3,
        [StringValue("Hidden")]
        Hidden = 4,
        [StringValue("Multiple Cards")]
        MultipleCards = 5,
        [StringValue("BankTransfer")]
        BankTransfer = 6,
        [StringValue("BankWire")]
        BankWire = 7,
        [StringValue("AnotherPayment")]
        AnotherPayment = 8
    }

    public enum EnumCoreSteps
    {
        [StringValue("Country And Language")]
        [LocalizationAttribute("_ENUM_COUNTRYLANGUAGE")]
        CountryLanguage = 1,
        [StringValue("Gaiyo Shomen")]
        [LocalizationAttribute("_ENUM_GAIYOSHOMEN")]
        GaiyoShomen = 2,
        [StringValue("Product Kits")]
        [LocalizationAttribute("_ENUM_PRODUCTKITS")]
        ProductsKits = 3,
        [StringValue("Products")]
        [LocalizationAttribute("_ENUM_PRODUCTS")]
        Products = 4,
        [StringValue("Autoship")]
        [LocalizationAttribute("_ENUM_AUTOSHIP")]
        Autoship = 5,
        [StringValue("Information")]
        [LocalizationAttribute("_ENUM_INFORMATION")]
        Information = 6,
        [StringValue("Review")]
        [LocalizationAttribute("_ENUM_REVIEW")]
        Review = 7,
        [StringValue("Confirmation")]
        [LocalizationAttribute("_ENUM_CONFIRMATION")]
        Confirmation = 8
    }

    public enum EnumDeliveryTime
    {
        [StringValue("8:00 - 12:00")]
        Time1 = 1,
        [StringValue("12:00 - 14:00")]
        Time2 = 2,
        [StringValue("14:00 - 16:00")]
        Time3 = 3,
        [StringValue("16:00 - 18:00")]
        Time4 = 4,
        [StringValue("18:00 - 20:00")]
        Time5 = 5,
        [StringValue("20:00 - 21:00")]
        Time6 = 6
    }

    public enum EnumCoolingOff
    {
        [StringValue("Active")]
        Active = 1,
        [StringValue("Expired")]
        Expired = 0
    }

    public enum EnumRunAutoshipResult
    {
        [StringValue("Started")]
        Started = 0,
        [StringValue("Proccessing")]
        Proccessing = 1,
        [StringValue("Successfull")]
        Successfull = 2,
        [StringValue("Error")]
        Error = 3
    }

    public enum EnumLogManager
    {
        [StringValue("Start")]
        Start = 0,
        [StringValue("Proccessing")]
        Proccessing = 1,
        [StringValue("Successfull")]
        Successfull = 2,
        [StringValue("Error")]
        Error = 3,
        [StringValue("End")]
        End = 4
    }

    public enum EnumTypeAccountLedger
    {
        [StringValue("Monthly Commisions")]
        MonthlyCommisions = 1,
        [StringValue("Payout")]
        Payout = 2,
        [StringValue("Weekly Commisions Bonus")]
        WeeklyCommisionsBonus = 3,
        [StringValue("QG Weekly Clawback")]
        QGWeeklyClawback = 4,
        [StringValue("Clawback")]
        WealthClubClawback = 5,
        [StringValue("Payment order from Subscription")]
        PayAutoship = 6,
        [StringValue("Refund of a paid Order")]
        RefundOrder = 7,
        [StringValue("Payment order from module Orders")]
        PayOrder = 8
    }

    public enum EnumProcessModule
    {
        [StringValue("xCorporate")]
        xCorporate = 1,
        [StringValue("xEnrollment")]
        xEnrollment = 2,
        [StringValue("xOrder")]
        xOrder = 3,
        [StringValue("xWebService")]
        xWebService = 4,
        [StringValue("xWebService")]
        xWebService2 = 7
    }

    public enum EnumAddressConfig
    {
        [StringMessage("Hide")]
        [StringValue("NoVisible")]
        NoVisible = 0,
        [StringMessage("Required")]
        [StringValue("Required")]
        Required = 1,
        [StringMessage("Optional")]
        [StringValue("NoRequired")]
        NoRequired = 2

    }


    public enum EnumIsNFR
    {
        [StringValue("1")]
        [StringMessage("is NFR")]
        isNFR = 1,
        [StringValue("0")]
        [StringMessage("no NFR")]
        noNFR = 0,
    }

    public enum EnumMethodPayout
    {
        [StringValue("0")]
        Unknown = 0,
        [StringValue("1")]
        Propay = 1,
        [StringValue("2")]
        Manual = 2,
        [StringValue("3")]
        ACH = 3,
        [StringValue("4")]
        GPG = 4,
        [StringValue("5")]
        HyperWallet = 5
    }
    public enum EnumStageNFR
    {
        [StringMessage("Selected")]
        [StringValue("0")]
        StageNFR0 = 0,
        [StringValue("1")]
        StageNFR1 = 1,
    }
    public enum EnumMaxLimit
    {
        [StringValue("1")]
        [StringMessage("No Limit")]
        noLimit = 1,
        [StringValue("2")]
        [StringMessage("Manual")]
        manual = 2,
    }

    public enum EnumSourceType
    {
        [StringValue("1")]
        [StringMessage("Zennoa")]
        Zennoa = 1,
        [StringValue("2")]
        [StringMessage("Zennoa NFR")]
        ZennoaNFR = 2,
    }

    public enum EnumAddressSameAs
    {
        [StringValue("1")]
        [StringMessage("Same as Primary Address")]
        PrimaryAddress = 1,
        [StringValue("2")]
        [StringMessage("Same as Shipping Address")]
        ShippingAddress = 2,
    }

    public enum EnumReportCategory
    {
        [StringValue("Commissions")]
        Commissions = 3,
        [StringValue("Distributor")]
        Distributor = 5,
        [StringValue("Finances")]
        Finances = 6,
        [StringValue("Warehouse And Inventory")]
        WarehouseAndInventory = 10,
        [StringValue("Enrollment And Sponsors")]
        EnrollmentAndSponsors = 15,
        [StringValue("Sales And Sign Up")]
        SalesAndSignUp = 20,
        [StringValue("Loyalty Order")]
        LoyaltyOrder = 54,
        [StringValue("Web Services")]
        WebServices = 58
    }

    public enum EnumHyperwalletAction
    {
        [StringValue("Create Account")]
        Account = 1,
        [StringValue("Payment")]
        Payment = 2
    }


    public enum EnumSystemAlertType
    {
        [StringValue("S")]
        Market = 1,
        [StringValue("D")]
        Distributor = 2,
        [StringValue("L")]
        Language = 3,
        [StringValue("R")]
        Rank = 4
    }


    public enum EnumViewOption
    {
        [StringValue("Show until expired or clicked")]
        ShowUntilExpiredorClicked = 0,
        [StringValue("Show until expired no confirm button")]
        ShowUntilExpirednoConfirmButton = 1,
        [StringValue("Show until require signature <> null or expired")]
        ShowUntilRequireSignatureDifnullorExpired = 2,
        [StringValue("Show until expired, show signature until signed")]
        ShowUntilExpiredShowSignatureUntilSigned = 3
    }


    public enum EnumPriority
    {
        [StringValue("Low")]
        Low = 3,
        [StringValue("Medium")]
        Medium = 2,
        [StringValue("High")]
        High = 1

    }

}
