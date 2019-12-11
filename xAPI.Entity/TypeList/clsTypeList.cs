using System;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using System.Data;

using xAPI.Library.General;
using xAPI.Library.Base;

namespace xAPI.Entity
{
    #region BaseId
    [Serializable]
    public class tBaseId
    {
        public Int32 Id { get; set; }
        public Int16 Status { get; set; }
        public Int16 Action { get; set; }
    }

    [Serializable]
    public class tBaseIdList : List<tBaseId>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt)
                );
            foreach (tBaseId data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt16(1, data.Status);
                ret.SetInt16(2, data.Action);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseLanguage
    {
        public Int32 ID { get; set; }
        public String LANGUAGENAME { get; set; }
        public String FOLDEREXTENSION { get; set; }
        public String ICON { get; set; }
        public Int16 STATUS { get; set; }
        public String CULTUREINFO { get; set; }
        public Int16 PUBLISHED { get; set; }
        public Int32 CREATEDBY { get; set; }
        public Int32 UPDATEDBY { get; set; }
        public String LEGACYLANGUAGE { get; set; }
        public Int32 MARKETID { get; set; }
        public Int32 ORDER { get; set; }
    }

    [Serializable]
    public class tBaseListLanguage : List<tBaseLanguage>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("LANGUAGENAME", SqlDbType.NVarChar, 100),
                new SqlMetaData("FOLDEREXTENSION", SqlDbType.NVarChar, 100),
                new SqlMetaData("ICON", SqlDbType.NVarChar, 600),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("CULTUREINFO", SqlDbType.NVarChar, 100),
                new SqlMetaData("PUBLISHED", SqlDbType.SmallInt),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                new SqlMetaData("UPDATEDBY", SqlDbType.Int),
                new SqlMetaData("LEGACYLANGUAGE", SqlDbType.NVarChar, 100),
                new SqlMetaData("MARKETID", SqlDbType.Int),
                new SqlMetaData("ORDER", SqlDbType.Int)
                );
            foreach (tBaseLanguage data in this)
            {
                ret.SetInt32(0, data.ID);
                ret.SetString(1, data.LANGUAGENAME ?? "");
                ret.SetString(2, data.FOLDEREXTENSION ?? "");
                ret.SetString(3, data.ICON ?? "");
                ret.SetInt16(4, data.STATUS);
                ret.SetString(5, data.CULTUREINFO ?? "");
                ret.SetInt16(6, data.PUBLISHED);
                ret.SetInt32(7, data.CREATEDBY);
                ret.SetInt32(8, data.UPDATEDBY);
                ret.SetString(9, data.LEGACYLANGUAGE ?? "");
                ret.SetInt32(10, data.MARKETID);
                ret.SetInt32(11, data.ORDER);
                yield return ret;
            }
        }
    }
    //

    [Serializable]
    public class tBasePP
    {
        public Int32 ID { get; set; }
        public Decimal custom1 { get; set; }
        public Decimal custom2 { get; set; }

    }

    [Serializable]
    public class tBasePPList : List<tBasePP>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("custom1", SqlDbType.Decimal),
                new SqlMetaData("custom2", SqlDbType.Decimal)
                );
            foreach (tBasePP data in this)
            {
                ret.SetInt32(0, data.ID);
                ret.SetDecimal(1, data.custom1);
                ret.SetDecimal(2, data.custom2);
                yield return ret;
            }
        }
    }

    //

    [Serializable]
    public class tBaseId_v6
    {
        public Int64 legacynumber { get; set; }

    }

    [Serializable]
    public class tBaseIdList_v6 : List<tBaseId_v6>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("LEGACYNUMBER", SqlDbType.BigInt)

                );
            foreach (tBaseId_v6 data in this)
            {
                ret.SetInt64(0, data.legacynumber);
                yield return ret;
            }
        }
    }
    #region TABLETYPE PAY
    [Serializable]
    public class tBasePayout
    {
        public Int64 legacynumber { get; set; }
        public Int32 TransactionID { get; set; }
        public String custom1 { get; set; }
        public String custom2 { get; set; }
        public String custom3 { get; set; }

    }
    [Serializable]
    public class tBasePayoutList : List<tBasePayout>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("LEGACYNUMBER", SqlDbType.BigInt),
                new SqlMetaData("transactionID", SqlDbType.Int),
                new SqlMetaData("custom1", SqlDbType.NVarChar,250),
                new SqlMetaData("custom2", SqlDbType.NVarChar,250),
                new SqlMetaData("custom3", SqlDbType.NVarChar,250)
                );
            foreach (tBasePayout data in this)
            {
                ret.SetInt64(0, data.legacynumber);
                ret.SetInt32(1, data.TransactionID);
                ret.SetString(2, String.IsNullOrEmpty(data.custom1) ? String.Empty : data.custom1);
                ret.SetString(3, String.IsNullOrEmpty(data.custom2) ? String.Empty : data.custom2);
                ret.SetString(4, String.IsNullOrEmpty(data.custom3) ? String.Empty : data.custom3);
                yield return ret;
            }
        }
    }
    #endregion
    [Serializable]
    public class tBaseExportDetails
    {
        public Int32 Id { get; set; }
        public Int32 OrderExportId { get; set; }
        public Int32 FilterField { get; set; }        
        public String FilterName { get; set; }
        public Int32 FilterType { get; set; }
        public Int16 Status { get; set; }
        public Int16 Action { get; set; }
    }

    [Serializable]
    public class tBaseExportDetailsList : List<tBaseExportDetails>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("ExportId", SqlDbType.Int),
                new SqlMetaData("FilterField", SqlDbType.Int),
                new SqlMetaData("FilterName", SqlDbType.VarChar, 500),
                new SqlMetaData("FilterType", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt)
                );
            foreach (tBaseExportDetails data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.OrderExportId);
                ret.SetInt32(2, data.FilterField);
                ret.SetString(3, String.IsNullOrEmpty(data.FilterName) ? "" : data.FilterName);
                ret.SetInt32(4, data.FilterType);
                ret.SetInt16(5, data.Status);
                ret.SetInt16(6, data.Action);
                yield return ret;
            }
        }
    }
    [Serializable]
    public class tBaseExportColumns
    {
        public Int32 Id { get; set; }
        public Int32 ExportId { get; set; }
        public Int32 OrderColumn { get; set; }
        public String ColumnName { get; set; }
        public String ColumnType { get; set; }
        public String ColumnValue { get; set; }
        public String TableName { get; set; }
        public Int16 Status { get; set; }
        public Int16 Action { get; set; }
    }

    [Serializable]
    public class tBaseExportColumnsList : List<tBaseExportColumns>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("ExportId", SqlDbType.Int),
                new SqlMetaData("OrderColumn", SqlDbType.Int),
                new SqlMetaData("ColumnName", SqlDbType.VarChar, 500),
                new SqlMetaData("ColumnType", SqlDbType.VarChar, 500),
                new SqlMetaData("ColumnValue", SqlDbType.VarChar, 500),
                new SqlMetaData("TableName", SqlDbType.VarChar, 500),              
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt)
                );
            foreach (tBaseExportColumns data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.ExportId);
                ret.SetInt32(2, data.OrderColumn);
                ret.SetString(3, String.IsNullOrEmpty(data.ColumnName) ? "": data.ColumnName);
                ret.SetString(4, String.IsNullOrEmpty(data.ColumnType) ? "" : data.ColumnType);
                ret.SetString(5, String.IsNullOrEmpty(data.ColumnValue) ? "":data.ColumnValue);
                ret.SetString(6, String.IsNullOrEmpty(data.TableName) ? "":data.TableName);
                ret.SetInt16(7, data.Status);
                ret.SetInt16(8, data.Action);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseBanner
    {
        public Int32 Id { get; set; }
        public Int32 Order { get; set; }
    }

    [Serializable]
    public class tBaseBannerList : List<tBaseBanner>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("ORDER", SqlDbType.Int)
                );
            foreach (tBaseBanner data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.Order);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tTypeBasePayout
    {
        public Int64 InvoiceId { get; set; }
        public Int64 legacynumber { get; set; }
        public Int32 TransactionID { get; set; }
        public String custom1 { get; set; }
        public String custom2 { get; set; }
        public String custom3 { get; set; }

    }
    [Serializable]
    public class tTypeBasePayoutList : List<tTypeBasePayout>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("InvoiceId", SqlDbType.BigInt),
                new SqlMetaData("LegacyNumber", SqlDbType.BigInt),
                new SqlMetaData("transactionID", SqlDbType.Int),
                new SqlMetaData("custom1", SqlDbType.NVarChar, 250),
                new SqlMetaData("custom2", SqlDbType.NVarChar, 250),
                new SqlMetaData("custom3", SqlDbType.NVarChar, 250)
                );
            foreach (tTypeBasePayout data in this)
            {
                ret.SetInt64(0, data.InvoiceId);
                ret.SetInt64(1, data.legacynumber);
                ret.SetInt32(2, data.TransactionID);
                ret.SetString(3, String.IsNullOrEmpty(data.custom1) ? String.Empty : data.custom1);
                ret.SetString(4, String.IsNullOrEmpty(data.custom2) ? String.Empty : data.custom2);
                ret.SetString(5, String.IsNullOrEmpty(data.custom3) ? String.Empty : data.custom3);
                yield return ret;
            }
        }
    }


    public class tBaseEmailTemplateManagment
    {
        public String Value { get; set; }
        public Int16 Status { get; set; }
        public Int16 Action { get; set; }
    }

    public class tBaseEmailTemplateManagmentList : List<tBaseEmailTemplateManagment>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("VALUE", SqlDbType.NVarChar),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt)
                );
            foreach (tBaseEmailTemplateManagment data in this)
            {
                ret.SetString(0, data.Value);
                ret.SetInt16(1, data.Status);
                ret.SetInt16(2, data.Action);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseAutoResponder
    {
        public Int32 Id { get; set; }
        public Int32 TypeId { get; set; }
        public Int16 Status { get; set; }
        public Int32 DistributorId { get; set; }
        public Int16 Action { get; set; }
    }
    [Serializable]
    public class tBaseAutoResponderList : List<tBaseAutoResponder>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("TYPEID", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("DISTRIBUTORID", SqlDbType.Int),
                new SqlMetaData("ACTION", SqlDbType.SmallInt)
                );
            foreach (tBaseAutoResponder data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.TypeId);
                ret.SetInt16(2, data.Status);
                ret.SetInt32(3, data.DistributorId);
                ret.SetInt16(4, data.Action);
                yield return ret;
            }
        }
    }



    [Serializable]
    public class tBaseUserSettings
    {
        public Int32 Id { get; set; }
        public Int32 Code { get; set; }
        public Int32 Table { get; set; }
        public Byte Status { get; set; }
        public Int16 Action { get; set; }
        public String Url { get; set; }
        #region Methods
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            tBaseUserSettings o = (tBaseUserSettings)obj;
            return (this.Id == o.Id);
        }
        #endregion

        public string UrlOnSinglePage { get; set; }
        public string MenuId { get; set; }
        public string MenuIcon { get; set; }
        public string MenuName { get; set; }
        public Int32 TotalChilds { get; set; }
        public short IsOnMenu { get; set; }
        public Boolean IsExternalModule { get; set; }
        public Byte VersionId { get; set; }
        public String VersionName { get; set; }
        public String VersionTranslationKey { get; set; }
    }

    [Serializable]
    public class tBaseUserSettingsList : List<tBaseUserSettings>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("CODE   ", SqlDbType.Int),
                new SqlMetaData("TABLE", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.TinyInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt),
                 new SqlMetaData("EXTERNALMODULE", SqlDbType.Bit)
                );
            foreach (tBaseUserSettings data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.Code);
                ret.SetInt32(2, data.Table);
                ret.SetByte(3, data.Status);
                ret.SetInt16(4, data.Action);
                ret.SetBoolean(5, data.IsExternalModule);
                yield return ret;
            }
        }
    }


    [Serializable]
    public class tBaseCountriesID
    {
        public Int32 Id { get; set; }
        public Int32 CountriesID { get; set; }

    }

    public class tBaseCountriesIDList : List<tBaseCountriesID>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("COUNTRIESID", SqlDbType.Int)

            );

            foreach (tBaseCountriesID data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.CountriesID);

                yield return ret;
            }
        }
    }



    [Serializable]
    public class tBaseAddress
    {
        public Int32 ID { get; set; }
        public Int16 Addresstype { get; set; }
        public String Address { get; set; }
        public String Address1 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public String County { get; set; }
        public String Country { get; set; }
        public Int16 Setasdefault { get; set; }
        public Int32 Position { get; set; }
        public Int16 Action { get; set; }
        public Int32 Status { get; set; }
    }

    [Serializable]
    public class tBaseAddressList : List<tBaseAddress>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("ADDRESSTYPE", SqlDbType.SmallInt),
                new SqlMetaData("ADDRESS", SqlDbType.VarChar, 50),
                new SqlMetaData("ADDRESS1", SqlDbType.VarChar, 50),
                new SqlMetaData("CITY", SqlDbType.VarChar, 50),
                new SqlMetaData("STATE", SqlDbType.VarChar, 50),
                new SqlMetaData("ZIP", SqlDbType.VarChar, 50),
                new SqlMetaData("COUNTY", SqlDbType.VarChar, 50),
                new SqlMetaData("COUNTRY", SqlDbType.VarChar, 50),
                new SqlMetaData("SETASDEFAULT", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt),
                new SqlMetaData("POSITION", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.Int)
                );
            foreach (tBaseAddress data in this)
            {
                ret.SetInt32(0, data.ID);
                ret.SetInt16(1, data.Addresstype);
                ret.SetString(2, data.Address);
                ret.SetString(3, data.Address1);
                ret.SetString(4, data.City);
                ret.SetString(5, data.State);
                ret.SetString(6, data.Zip);
                ret.SetString(7, !String.IsNullOrEmpty(data.County) ? data.County:"");
                ret.SetString(8, data.Country);
                ret.SetInt16(9, data.Setasdefault);
                ret.SetInt16(10, data.Action);
                ret.SetInt32(11, data.Position);
                ret.SetInt32(12, data.Status);
                yield return ret;
            }
        }
    }
    [Serializable]
    public class tBaseShippingRatesByMarketAndOrderType
    {
        public Int32 Id { get; set; }
        public Int32 MarketId { get; set; }
        public String Market_Abrev { get; set; }
        public Decimal StartPrice { get; set; }
        public Decimal EndPrice { get; set; }
        public Int16 OrderType { get; set; }
        public String OrderTypeDesc { get; set; }
        public Decimal ShipCost { get; set; }
        public String Speed { get; set; }
        public Int16 Status { get; set; }
        public Int16 Action { get; set; }
        //public Decimal HandlingFee { get; set; }
    }

    [Serializable]
    public class tBaseShippingRatesByMarketAndOrderTypeList : List<tBaseShippingRatesByMarketAndOrderType>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            //var obj = { ID: "", Country: "",  StartWeight: "", EndWeight: "", ShipFromState: "", ShipToState: "", Price: "", Status: "", Action: "" };

            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("STARTPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("ENDPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("SHIPCOST", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt),
                new SqlMetaData("ORDERTYPE", SqlDbType.SmallInt),
                new SqlMetaData("ORDERTYPEDESC", SqlDbType.NVarChar, 50),
                new SqlMetaData("MARKETID", SqlDbType.Int),
                new SqlMetaData("MARKET_ABREV", SqlDbType.NVarChar, 50),
                new SqlMetaData("SPEED", SqlDbType.NVarChar, 50)
                //new SqlMetaData("HANDLINGFEE", SqlDbType.Decimal, 18, 2)
                );
            foreach (tBaseShippingRatesByMarketAndOrderType data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetDecimal(1, data.StartPrice);
                ret.SetDecimal(2, data.EndPrice);
                ret.SetDecimal(3, data.ShipCost);
                ret.SetInt16(4, data.Status);
                ret.SetInt16(5, data.Action);
                ret.SetInt16(6, data.OrderType);
                ret.SetString(7, data.OrderTypeDesc);
                ret.SetInt32(8, data.MarketId);
                ret.SetString(9, data.Market_Abrev);
                ret.SetString(10, data.Speed);
                //ret.SetDecimal(6, data.HandlingFee);                
                yield return ret;
            }
        }
    }
    [Serializable]
    public class tBaseBank
    {
        public int ID { get; set; }
        public int AccountType { get; set; }
        public string BankName { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountNumber { get; set; }
        public Int16 Setasdefault { get; set; }
        public Int16 Action { get; set; }
        public Int32 Position { get; set; }
    }
    [Serializable]
    public class tBaseBankList : List<tBaseBank>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                //new SqlMetaData("DISTRIBUTORID", SqlDbType.Int),
                new SqlMetaData("ACCOUNTTYPE", SqlDbType.Int),
                new SqlMetaData("BANKNAME", SqlDbType.VarChar, 50),
                new SqlMetaData("ROUTINGNUMBER", SqlDbType.VarChar, 50),
                new SqlMetaData("ACCOUNTNUMBER", SqlDbType.VarChar, 50),
                new SqlMetaData("SETASDEFAULT", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt),
                new SqlMetaData("POSITION", SqlDbType.Int)
                );
            foreach (tBaseBank data in this)
            {
                ret.SetInt32(0, data.ID);
                ret.SetInt32(1, data.AccountType);
                ret.SetString(2, data.BankName);
                ret.SetString(3, data.RoutingNumber);
                ret.SetString(4, data.AccountNumber);
                ret.SetInt16(5, data.Setasdefault);
                ret.SetInt16(6, data.Action);
                ret.SetInt32(7, data.Position);
                yield return ret;
            }
        }
    }


    #region "Bonus Parameters / Esto ya no se usara"

    [Serializable]
    public class tBaseBonusParameters
    {
        public Int32 BonusID { get; set; }
        public String ParameterName { get; set; }
        public Int32 CreateBy { get; set; }
    }

    [Serializable]
    public class tBasetBaseBonusParametersList : List<tBaseBonusParameters>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("BONUSID", SqlDbType.Int),
                new SqlMetaData("PARAMETERNAME", SqlDbType.NVarChar),
                new SqlMetaData("CREATEDBY", SqlDbType.Int)
                );
            foreach (tBaseBonusParameters data in this)
            {
                ret.SetInt32(0, data.BonusID);
                ret.SetString(1, data.ParameterName);
                ret.SetInt32(2, data.CreateBy);
                yield return ret;
            }
        }
    }

    #endregion


    [Serializable]
    public class tBaseCard
    {
        public Int32 ID { get; set; }
        public String Nameoncard { get; set; }
        public String Cardtype { get; set; }
        public String Cardnumber { get; set; }
        public Int32 Expmonth { get; set; }
        public Int32 Expyear { get; set; }
        public Int32 Ccv { get; set; }
        public Int32 Last4 { get; set; }
        public Int16 Setasdefault { get; set; }
        public Int16 Action { get; set; }
        public Int32 Position { get; set; }
        public Int32 Status { get; set; }
    }
    [Serializable]
    public class tBaseCardList : List<tBaseCard>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("NAMEONCARD", SqlDbType.VarChar, 50),
                new SqlMetaData("CARDTYPE", SqlDbType.VarChar, 50),
                new SqlMetaData("CARDNUMBER", SqlDbType.VarChar, 50),
                new SqlMetaData("EXPMONTH", SqlDbType.Int),
                new SqlMetaData("EXPYEAR", SqlDbType.Int),
                new SqlMetaData("CCV", SqlDbType.Int),
                new SqlMetaData("LAST4", SqlDbType.Int),
                new SqlMetaData("SETASDEFAULT", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt),
                new SqlMetaData("POSITION", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.Int)
                );
            foreach (tBaseCard data in this)
            {
                ret.SetInt32(0, data.ID);
                ret.SetString(1, data.Nameoncard);
                ret.SetString(2, data.Cardtype);
                ret.SetString(3, data.Cardnumber);
                ret.SetInt32(4, data.Expmonth);
                ret.SetInt32(5, data.Expyear);
                ret.SetInt32(6, data.Ccv);
                ret.SetInt32(7, data.Last4);
                ret.SetInt16(8, data.Setasdefault);
                ret.SetInt16(9, data.Action);
                ret.SetInt32(10, data.Position);
                ret.SetInt32(11, data.Status);
                yield return ret;
            }
        }
    }
    [Serializable]
    public class tBaseEmail
    {
        public String Email { get; set; }
    }
    [Serializable]
    public class tBaseEmailList : List<tBaseEmail>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("EMAIL", SqlDbType.VarChar, 100)
                );
            foreach (tBaseEmail data in this)
            {
                ret.SetString(0, data.Email);
                yield return ret;
            }
        }
    }
    [Serializable]
    public class tBasePrices
    {
        public Int32 Id { get; set; }
        public Decimal Retail { get; set; }
        public Decimal Preferred { get; set; }
        public Decimal Whosale { get; set; }
        public Decimal PersonalV { get; set; }
        public Decimal CommissionV { get; set; }
        public String Currency { get; set; }
        public Decimal Price { get; set; }
        public Int16 PriceLevel { get; set; }
        public Decimal QualifyVolumen { get; set; }
        public Decimal CommissionVolume { get; set; }
        public Decimal AdjustedCV { get; set; }
        public Int16 TypePrice { get; set; }
        public Int32 MaxQuty { get; set; }
        public Int32 MaxQutySales { get; set; }
        public Int16 IsForAutoship { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Enddate { get; set; }
        public Int16 Status { get; set; }
        public Int16 Action { get; set; }
        public Decimal Taxable { get; set; }
        public Decimal HandlingFee { get; set; }
        public Int32 MarketId { get; set; }
    }

    [Serializable]
    public class tBasePricesList : List<tBasePrices>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("RETAIL", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("PREFERRED", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("WHOSALE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("PERSONALV", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("COMMISSIONV", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("CURRENCY", SqlDbType.NVarChar, 3),
                new SqlMetaData("PRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("PRICELEVEL", SqlDbType.SmallInt),
                new SqlMetaData("QUALIFYVOLUMEN", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("COMMISSIONVOLUME", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("ADJUSTEDCV", SqlDbType.Decimal, 18, 2),               
                new SqlMetaData("TYPEPRICE", SqlDbType.SmallInt),
                new SqlMetaData("MAXQUTY", SqlDbType.Int),
                new SqlMetaData("MAXQTYAVAILABLE", SqlDbType.Int),
                new SqlMetaData("ISFORAUTOSHIP", SqlDbType.SmallInt),
                new SqlMetaData("STARTDATE", SqlDbType.DateTime),
                new SqlMetaData("ENDDATE", SqlDbType.DateTime),
                new SqlMetaData("TAXABLE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt),
                new SqlMetaData("HANDLINGFEE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("MARKETID", SqlDbType.Int)
                
                );
            foreach (tBasePrices data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetDecimal(1, data.Retail);
                ret.SetDecimal(2, data.Preferred);
                ret.SetDecimal(3, data.Whosale);
                ret.SetDecimal(4, data.PersonalV);
                ret.SetDecimal(5, data.CommissionV);
                ret.SetString(6, data.Currency);
                ret.SetDecimal(7, data.Price);
                ret.SetInt16(8, data.PriceLevel);
                ret.SetDecimal(9, data.QualifyVolumen);
                ret.SetDecimal(10, data.CommissionVolume);
                ret.SetDecimal(11, data.AdjustedCV);
                ret.SetInt16(12, data.TypePrice);
                ret.SetInt32(13, data.MaxQuty);
                ret.SetInt32(14, data.MaxQutySales);
                ret.SetInt16(15, data.IsForAutoship);
                ret.SetDateTime(16, data.StartDate == DateTime.MinValue ? Convert.ToDateTime("12-12-2012") : data.StartDate);
                ret.SetDateTime(17, data.Enddate == DateTime.MinValue ? Convert.ToDateTime("12-12-2012") : data.Enddate);
                ret.SetDecimal(18, data.Taxable);
                ret.SetInt16(19, data.Status);
                ret.SetInt16(20, data.Action);
                ret.SetDecimal(21, data.HandlingFee);
                ret.SetInt32(22, data.MarketId);
                yield return ret;
            }
        }
    }



    #endregion




    #region translation
    [Serializable]
    public class tBaseLanguageTranslator
    {
        public Int32 Id { get; set; }
        public String English { get; set; }
        public String Spanish { get; set; }
        public String FrenchCanadien { get; set; }
        public String German { get; set; }
        public String Hungary { get; set; }
        public String France { get; set; }
        public String Ireland { get; set; }
        public String Netherlands { get; set; }
        public String Austria { get; set; }
        public String Italy { get; set; }
        public String GreatBritain { get; set; }
        public String Slovenia { get; set; }
        public String Norway { get; set; }
        public String Dutch { get; set; }
        public String FrenchBelgium { get; set; }
        public String DutchBelgium { get; set; }
        public String Swedish { get; set; }
        public String Croatian { get; set; }
        public String Denmark { get; set; }
        public String Finland { get; set; }
        public String SpanishMexico { get; set; }
    }

    [Serializable]
    public class tBaseLanguageTranslatorList : List<tBaseLanguageTranslator>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("ENGLISH", SqlDbType.NVarChar, -1),
                new SqlMetaData("SPANISH", SqlDbType.NVarChar, -1),
                new SqlMetaData("FRENCHCANADIEN", SqlDbType.NVarChar, -1),
                new SqlMetaData("GERMAN", SqlDbType.NVarChar, -1),
                new SqlMetaData("HUNGARY", SqlDbType.NVarChar, -1),
                new SqlMetaData("FRANCE", SqlDbType.NVarChar, -1),
                new SqlMetaData("IRELAND", SqlDbType.NVarChar, -1),
                new SqlMetaData("NETHERLANS", SqlDbType.NVarChar, -1),
                new SqlMetaData("AUSTRIA", SqlDbType.NVarChar, -1),
                new SqlMetaData("ITALY", SqlDbType.NVarChar, -1),
                new SqlMetaData("GREATBRITAIN", SqlDbType.NVarChar, -1),
                new SqlMetaData("SLOVENIA", SqlDbType.NVarChar, -1),
                new SqlMetaData("NORWAY", SqlDbType.NVarChar, -1),
                new SqlMetaData("DUTCH", SqlDbType.NVarChar, -1),
                new SqlMetaData("FRENCHBELGIUM", SqlDbType.NVarChar, -1),
                new SqlMetaData("DUTCHBELGIUM", SqlDbType.NVarChar, -1),
                new SqlMetaData("SWEDISH", SqlDbType.NVarChar, -1),
                new SqlMetaData("CROATIAN", SqlDbType.NVarChar, -1),
                new SqlMetaData("DENMARK", SqlDbType.NVarChar, -1),
                new SqlMetaData("FINLAND", SqlDbType.NVarChar, -1),
                new SqlMetaData("SPANISHMEXICO", SqlDbType.NVarChar, -1)

                );
            foreach (tBaseLanguageTranslator data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.English);
                ret.SetString(2, data.Spanish);
                ret.SetString(3, data.FrenchCanadien);
                ret.SetString(4, data.German);
                ret.SetString(5, data.Hungary);
                ret.SetString(6, data.France);
                ret.SetString(7, data.Ireland);
                ret.SetString(8, data.Netherlands);
                ret.SetString(9, data.Austria);
                ret.SetString(10, data.Italy);
                ret.SetString(11, data.GreatBritain);
                ret.SetString(12, data.Slovenia);
                ret.SetString(13, data.Norway);
                ret.SetString(14, data.Dutch);
                ret.SetString(15, data.FrenchBelgium);
                ret.SetString(16, data.DutchBelgium);
                ret.SetString(17, data.Swedish);
                ret.SetString(18, data.Croatian);
                ret.SetString(19, data.Denmark);
                ret.SetString(20, data.Finland);
                ret.SetString(21, data.SpanishMexico);
                yield return ret;
            }
        }
    }
    #endregion

    #region shippingrates
    [Serializable]
    public class tBaseShippingRates
    {
        public Int32 Id { get; set; }
        public Int32 Country { get; set; }
        public Decimal StartWeight { get; set; }
        public Decimal EndWeight { get; set; }
        public String ShipFromState { get; set; }
        public String ShipToState { get; set; }
        public Decimal Price { get; set; }
        public Decimal StartPrice { get; set; }
        public Decimal EndPrice { get; set; }
        public Decimal ShipCost { get; set; }
        public Int16 Status { get; set; }
        public Int16 Action { get; set; }
        //public Decimal HandlingFee { get; set; }
    }

    [Serializable]
    public class tBaseShippingRatesList : List<tBaseShippingRates>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            //var obj = { ID: "", Country: "",  StartWeight: "", EndWeight: "", ShipFromState: "", ShipToState: "", Price: "", Status: "", Action: "" };

            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("STARTPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("ENDPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("SHIPCOST", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt),
                new SqlMetaData("STARTWEIGHT", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("ENDWEIGHT", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("SHIPFROMSTATE", SqlDbType.VarChar,50),
                new SqlMetaData("SHIPTOSTATE", SqlDbType.VarChar,50),
                new SqlMetaData("COUNTRYID", SqlDbType.Int)
                //new SqlMetaData("HANDLINGFEE", SqlDbType.Decimal, 18, 2)
                );
            foreach (tBaseShippingRates data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetDecimal(1, data.StartPrice);
                ret.SetDecimal(2, data.EndPrice);
                ret.SetDecimal(3, data.Price);
                ret.SetInt16(4, data.Status);
                ret.SetInt16(5, data.Action);
                ret.SetDecimal(6, data.StartWeight);
                ret.SetDecimal(7, data.EndWeight);
                ret.SetString(8, data.ShipFromState);
                ret.SetString(9, data.ShipToState);
                ret.SetInt32(10, data.Country);                
                //ret.SetDecimal(6, data.HandlingFee);                
                yield return ret;
            }
        }
    }

    public class tBaseShippingMarketRates
    {
        public Int32 Id { get; set; }
        public Int32 Country { get; set; }
        public Decimal StartWeight { get; set; }
        public Decimal EndWeight { get; set; }
        public Int32 ShipFromMarket { get; set; }
        public Int32 ShipToMarket { get; set; }
        public Decimal Price { get; set; }
        public Decimal StartPrice { get; set; }
        public Decimal EndPrice { get; set; }
        public Decimal ShipCost { get; set; }
        public Int16 Status { get; set; }
        public Int16 Action { get; set; }
        //public Decimal HandlingFee { get; set; }
    }

    [Serializable]
    public class tBaseShippingMarketRatesList : List<tBaseShippingMarketRates>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            //var obj = { ID: "", Country: "",  StartWeight: "", EndWeight: "", ShipFromState: "", ShipToState: "", Price: "", Status: "", Action: "" };

            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("STARTPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("ENDPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("SHIPCOST", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt),
                new SqlMetaData("STARTWEIGHT", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("ENDWEIGHT", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("SHIPFROMMARKET", SqlDbType.Int),
                new SqlMetaData("SHIPTOMARKET", SqlDbType.Int),
                new SqlMetaData("COUNTRYID", SqlDbType.Int)
                //new SqlMetaData("HANDLINGFEE", SqlDbType.Decimal, 18, 2)
                );
            foreach (tBaseShippingMarketRates data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetDecimal(1, data.StartPrice);
                ret.SetDecimal(2, data.EndPrice);
                ret.SetDecimal(3, data.Price);
                ret.SetInt16(4, data.Status);
                ret.SetInt16(5, data.Action);
                ret.SetDecimal(6, data.StartWeight);
                ret.SetDecimal(7, data.EndWeight);
                ret.SetInt32(8, data.ShipFromMarket);
                ret.SetInt32(9, data.ShipToMarket);
                ret.SetInt32(10, data.Country);
                //ret.SetDecimal(6, data.HandlingFee);                
                yield return ret;
            }
        }
    }


    [Serializable]
    public class tBaseShippingRatesBS
    {
        public Int32 Id { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal ShipCost { get; set; }
        public Int16 Status { get; set; }
        public Int16 Action { get; set; }
        //public Decimal HandlingFee { get; set; }
    }

    [Serializable]
    public class tBaseShippingRatesBSList : List<tBaseShippingRatesBS>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("UNITPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("SHIPCOST", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt)
                //new SqlMetaData("HANDLINGFEE", SqlDbType.Decimal, 18, 2)
                );
            foreach (tBaseShippingRatesBS data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetDecimal(1, data.UnitPrice);
                ret.SetDecimal(2, data.ShipCost);
                ret.SetInt16(3, data.Status);
                ret.SetInt16(4, data.Action);
                //ret.SetDecimal(5, data.HandlingFee);
                yield return ret;
            }
        }
    }


    #endregion

    /// <summary>
    /// </summary>
    #region "Autoship Points"
    [Serializable]
    public class tAutoshipPoints
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Decimal Value { get; set; }
        public Int32 CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public Int32 UpdateBy { get; set; }

    }

    public class tBaseAutoshipPointsList : List<tAutoshipPoints>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("NAME", SqlDbType.VarChar, 50),
                new SqlMetaData("VALUE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                new SqlMetaData("UPDATEDATE", SqlDbType.DateTime),
                new SqlMetaData("UPDATEDBY", SqlDbType.Int)
                );
            foreach (tAutoshipPoints data in this)
            {
                ret.SetInt32(0, data.ID);
                ret.SetString(1, data.Name);
                ret.SetDecimal(2, data.Value);
                ret.SetInt32(3, data.CreateBy);
                ret.SetDateTime(4, data.UpdateDate);
                ret.SetInt32(5, data.UpdateBy);
                yield return ret;
            }
        }
    }
    #endregion


    #region Categories
    [Serializable]
    public class tBaseProductCategories
    {
        public Int32 Id { get; set; }
        public Int32 CatalogId { get; set; }
        public Int32 CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int16 CreatedBy { get; set; }
        public Int16 Status { get; set; }

        #region Methods
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            tBaseUserSettings o = (tBaseUserSettings)obj;
            return (this.Id == o.Id);
        }
        #endregion
    }

    [Serializable]
    public class tBaseCatalogCategoriesList : List<tBaseProductCategories>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("CATALOGID   ", SqlDbType.Int),
                new SqlMetaData("CATEGORYID", SqlDbType.Int),
                new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("CREATEDBY", SqlDbType.SmallInt),
                new SqlMetaData("STATUS", SqlDbType.SmallInt)
                );
            foreach (tBaseProductCategories data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.CatalogId);
                ret.SetInt32(2, data.CategoryId);
                ret.SetDateTime(3, DateTime.Now);
                ret.SetInt16(4, data.CreatedBy);
                ret.SetInt16(5, data.Status);
                yield return ret;
            }
        }
    }
    #endregion






    //#region "Email"
    //    [Serializable]
    //    public class tBaseEmailChangeCategory
    //    {
    //        public Int32 Id { get; set; }
    //        public String Subject { get; set; }
    //    }

    //    [Serializable]
    //    public class tBaseIdList : List<tBaseEmailChangeCategory>, IEnumerable<SqlDataRecord>
    //    {
    //        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
    //        {
    //            SqlDataRecord ret = new SqlDataRecord(
    //                new SqlMetaData("ID", SqlDbType.Int),
    //                new SqlMetaData("STATUS", SqlDbType.SmallInt),
    //                new SqlMetaData("ACTION", SqlDbType.SmallInt)
    //                );
    //            foreach (tBaseId data in this)
    //            {
    //                ret.SetInt32(0, data.Id);
    //                ret.SetInt16(1, data.Status);
    //                ret.SetInt16(2, data.Action);
    //                yield return ret;
    //            }
    //        }
    //    }
    //#endregion



    [Serializable]
    public class tTaskId
    {
        public Int32 Id { get; set; }
    }

    [Serializable]
    public class tTaskIdList : List<tTaskId>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int)
                );
            foreach (tTaskId data in this)
            {
                ret.SetInt32(0, data.Id);
                yield return ret;
            }
        }
    }


    [Serializable]
    public class tFigureOutOrder
    {
        public Int32 ProductId { get; set; }
        /*public String SkuId { get; set; }
        public String Name { get; set; }
        public Decimal UnitPrice { get; set; }*/
        public Int32 Quantity { get; set; }
        public Decimal TotalPrice { get; set; }
        /*public Decimal Discount { get; set; }
        public Decimal QualifyingVolume { get; set; }
        public Decimal CommValue { get; set; }
        public Decimal ShippingAndHandlingPrice { get; set; }*/
    }

    [Serializable]
    public class tFigureOutOrderList : List<tFigureOutOrder>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("PRODUCTID", SqlDbType.Int),
                /*new SqlMetaData("SKUID", SqlDbType.NVarChar, 50),
                new SqlMetaData("NAME", SqlDbType.NVarChar, 50),
                new SqlMetaData("UNITPRICE", SqlDbType.Decimal),*/
                new SqlMetaData("QUANTITY", SqlDbType.Int),
                new SqlMetaData("TOTALPRICE", SqlDbType.Decimal)
                /*new SqlMetaData("TOTALPRICE", SqlDbType.Decimal),
                new SqlMetaData("DISCOUNT", SqlDbType.Decimal),
                new SqlMetaData("QUALIFYINGVOLUME", SqlDbType.Decimal),
                new SqlMetaData("COMMVALUE", SqlDbType.Decimal),
                new SqlMetaData("SHIPPINGANDHANDLINGPRICE", SqlDbType.Decimal)*/
                );
            foreach (tFigureOutOrder data in this)
            {
                ret.SetInt32(0, data.ProductId);
                /*ret.SetString(1, data.SkuId);
                ret.SetString(2, data.Name);
                ret.SetDecimal(3, data.UnitPrice);*/
                ret.SetInt32(1, data.Quantity);
                ret.SetDecimal(2, data.TotalPrice);
                /*ret.SetDecimal(5, data.TotalPrice);
                ret.SetDecimal(6, data.Discount);
                ret.SetDecimal(7, data.QualifyingVolume);
                ret.SetDecimal(8, data.CommValue);
                ret.SetDecimal(9, data.ShippingAndHandlingPrice);*/

                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseEvent
    {
        // add + campos 
        public Int32 ID { get; set; }
        public Int32 EventIdxPos { get; set; }
    }

    [Serializable]
    public class tBaseEventList : List<tBaseEvent>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("IDXPOS", SqlDbType.Int)

                );
            foreach (tBaseEvent data in this)
            {
                ret.SetInt32(0, data.ID);
                ret.SetInt32(1, data.EventIdxPos);

                yield return ret;
            }
        }
    }


    [Serializable]
    public class tBaseInviteOtherGuests
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    [Serializable]
    public class tBaseInviteOtherGuestsList : List<tBaseInviteOtherGuests>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("FIRSTNAME", SqlDbType.NVarChar, 100),
                new SqlMetaData("LASTNAME", SqlDbType.NVarChar, 100),
                new SqlMetaData("EMAIL", SqlDbType.NVarChar, 150)

                );
            foreach (tBaseInviteOtherGuests data in this)
            {
                ret.SetString(0, data.FirstName);
                ret.SetString(1, data.LastName);
                ret.SetString(2, data.Email);

                yield return ret;
            }
        }
    }




    [Serializable]
    public class tBaseInviteGuests
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long AssociateId { get; set; }

        public short Type { get; set; }

        public short Attending { get; set; }

        public short HasSpecialDietary { get; set; }
        public short HasSDDiabetic { get; set; }
        public short HasSDGlutenFree { get; set; }
        public short HasSDDairyFree { get; set; }
        public short HasSDNutAllergy { get; set; }
        public short HasSDVegan { get; set; }
        public short HasSDVegetarian { get; set; }
        public short HasSDOther { get; set; }
        public string SDOtherText { get; set; }

        public short HasPhysicalLimitations { get; set; }
        public short HasPLVisionImpaired { get; set; }
        public short HasPLHearingImpaired { get; set; }
        public short HasPLWheelchairAccesible { get; set; }
        public short HasPLOther { get; set; }
        public string PLOtherText { get; set; }
    }
    [Serializable]
    public class tBaseInviteGuestsList : List<tBaseInviteGuests>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("CUSTOMERID", SqlDbType.Int),
                new SqlMetaData("FIRSTNAME", SqlDbType.NVarChar, 50),
                new SqlMetaData("LASTNAME", SqlDbType.NVarChar, 50),
                new SqlMetaData("EMAIL", SqlDbType.NVarChar, 50),
                new SqlMetaData("TYPE", SqlDbType.SmallInt),
                new SqlMetaData("ASSOCIATEID", SqlDbType.BigInt),

                new SqlMetaData("ATTENDING", SqlDbType.SmallInt),

                new SqlMetaData("HASSPECIALDIETARYNEED", SqlDbType.SmallInt),
                new SqlMetaData("HASDIABETIC", SqlDbType.SmallInt),
                new SqlMetaData("HASGLUTENFREE", SqlDbType.SmallInt),
                new SqlMetaData("HASDAIRYFREE", SqlDbType.SmallInt),
                new SqlMetaData("HASNUTALLERGY", SqlDbType.SmallInt),
                new SqlMetaData("HASVEGAN", SqlDbType.SmallInt),
                new SqlMetaData("HASVEGETARIAN", SqlDbType.SmallInt),
                new SqlMetaData("HASOTHERSPECIALDIETARYNEED", SqlDbType.SmallInt),
                new SqlMetaData("OTHERSPECIALDIETARYNEEDTEXT", SqlDbType.NVarChar, 150),

                new SqlMetaData("HASPHYSICALLIMITATIONS", SqlDbType.SmallInt),
                new SqlMetaData("HASVISIONIMPAIRED", SqlDbType.SmallInt),
                new SqlMetaData("HASHEARINGIMPAIRED", SqlDbType.SmallInt),
                new SqlMetaData("HASWHEELCHAIRACCESSIBLE", SqlDbType.SmallInt),
                new SqlMetaData("HASOTHERSPHYSICALLIMITATIONS", SqlDbType.SmallInt),
                new SqlMetaData("OTHERSPHYSICALLIMITATIONSTEXT", SqlDbType.NVarChar, 150)

                );
            foreach (tBaseInviteGuests data in this)
            {
                ret.SetInt32(0, data.CustomerId);
                ret.SetString(1, data.FirstName);
                ret.SetString(2, data.LastName);
                ret.SetString(3, data.Email);
                ret.SetInt16(4, data.Type);
                ret.SetInt64(5, data.AssociateId);
                ret.SetInt16(6, data.Attending);
                ret.SetInt16(7, data.HasSpecialDietary);
                ret.SetInt16(8, data.HasSDDiabetic);
                ret.SetInt16(9, data.HasSDGlutenFree);
                ret.SetInt16(10, data.HasSDDairyFree);
                ret.SetInt16(11, data.HasSDNutAllergy);
                ret.SetInt16(12, data.HasSDVegan);
                ret.SetInt16(13, data.HasSDVegetarian);
                ret.SetInt16(14, data.HasSDOther);
                ret.SetString(15, data.SDOtherText);
                ret.SetInt16(16, data.HasPhysicalLimitations);
                ret.SetInt16(17, data.HasPLVisionImpaired);
                ret.SetInt16(18, data.HasPLHearingImpaired);
                ret.SetInt16(19, data.HasPLWheelchairAccesible);
                ret.SetInt16(20, data.HasPLOther);
                ret.SetString(21, data.PLOtherText);

                yield return ret;
            }
        }
    }

    public class tBaseOrderDetailsList : List<tBaseOrderDetail>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {



            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("SKUID", SqlDbType.VarChar, 50),
                new SqlMetaData("UNITPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("QUANTITY", SqlDbType.Int),
                new SqlMetaData("DETAILTYPE", SqlDbType.Int),
                new SqlMetaData("TOTALPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("DISCOUNT", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("QUALIFYINGVOLUME", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("COMMVALUE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("ACTION", SqlDbType.SmallInt),
                new SqlMetaData("ATTRIBUTEID", SqlDbType.Int),
                new SqlMetaData("NAME", SqlDbType.NVarChar, 500),
                new SqlMetaData("PRODUCTID", SqlDbType.Int),
                new SqlMetaData("WAREHOUSEID", SqlDbType.Int)
                );
            foreach (tBaseOrderDetail data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.Skuid);
                ret.SetDecimal(2, data.Unitprice);
                ret.SetInt32(3, data.Quantity);
                ret.SetInt32(4, data.DetailType.ID);
                ret.SetDecimal(5, data.Totalprice);
                ret.SetDecimal(6, data.Discount);
                ret.SetDecimal(7, data.Qualifyingvolume);
                ret.SetDecimal(8, data.Commvalue);
                ret.SetInt16(9, data.Action);
                ret.SetInt32(10, data.AttributeId);
                ret.SetString(11, data.Name);
                ret.SetInt32(12, data.ProductId);
                ret.SetInt32(13, data.WarehouseId);
                yield return ret;
            }
        }
    }

    public class tBaseOrderDetailListv2 : List<tBaseOrderDetail>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

          

            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("SKUID", SqlDbType.VarChar, 50),
                new SqlMetaData("UNITPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("QUANTITY", SqlDbType.Int),
                new SqlMetaData("DETAILTYPE", SqlDbType.Int),
                new SqlMetaData("TOTALPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("DISCOUNT", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("QUALIFYINGVOLUME", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("COMMVALUE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("ACTION", SqlDbType.SmallInt),
                new SqlMetaData("ATTRIBUTEID", SqlDbType.Int),
                new SqlMetaData("NAME", SqlDbType.VarChar, 500),
                new SqlMetaData("PRODUCTID", SqlDbType.Int),
                new SqlMetaData("WAREHOUSEID", SqlDbType.Int),
			 new SqlMetaData("SALESTAX", SqlDbType.Decimal, 18, 6)
			 );
            foreach (tBaseOrderDetail data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.Skuid);
                ret.SetDecimal(2, data.Unitprice);
                ret.SetInt32(3, data.Quantity);
                ret.SetInt32(4, data.DetailType.ID);
                ret.SetDecimal(5, data.Totalprice);
                ret.SetDecimal(6, data.Discount);
                ret.SetDecimal(7, data.Qualifyingvolume);
                ret.SetDecimal(8, data.Commvalue);
                ret.SetInt16(9, data.Action);
                ret.SetInt32(10, data.AttributeId);
                ret.SetString(11, data.Name);
                ret.SetInt32(12, data.ProductId);
                ret.SetInt32(13, data.WarehouseId);
			 ret.SetDecimal(14, data.SalesTax);
			 yield return ret;
            }
        }
    }
    [Serializable]
    public class tBaseAddresses
    {
        public Int32 ID { get; set; }
        public Int32 DistributorID { get; set; }
        public Int16 Addresstype { get; set; }
        public Int32 LanguageCharSet { get; set; }
        public Int32 RelatedAddressID { get; set; }
        public String Address { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public String County { get; set; }
        public String Country { get; set; }
        public Int32 CountryID { get; set; }
        public Int16 Setasdefault { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 CreatedBy { get; set; }        
        public Int32 Status { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 UpdatedBy { get; set; }
        public Int16 IsBusiness { get; set; }
        public Int16 InsideCityLimits { get; set; }
        public Int64 LegacyNumber { get; set; }
        public Int16 IsMainAddress { get; set; }
    }

    [Serializable]
    public class tBaseAddressesList : List<tBaseAddresses>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("DISTRIBUTORID", SqlDbType.Int),
                new SqlMetaData("ADDRESSTYPE", SqlDbType.SmallInt),
                new SqlMetaData("CHARTYPE", SqlDbType.Int),
                new SqlMetaData("RELATEDADDRESSID", SqlDbType.Int),
                new SqlMetaData("ADDRESS", SqlDbType.NVarChar, 250),
                new SqlMetaData("ADDRESS1", SqlDbType.NVarChar, 250),
                new SqlMetaData("ADDRESS2", SqlDbType.NVarChar, 250),
                new SqlMetaData("CITY", SqlDbType.NVarChar, 50),
                new SqlMetaData("STATE", SqlDbType.NVarChar, 50),
                new SqlMetaData("ZIP", SqlDbType.NVarChar, 50),
                new SqlMetaData("COUNTY", SqlDbType.NVarChar, 50),
                new SqlMetaData("COUNTRY", SqlDbType.NVarChar, 50),
                new SqlMetaData("COUNTRYID", SqlDbType.Int),
                new SqlMetaData("SETASDEFAULT", SqlDbType.SmallInt),
                new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.Int),
                new SqlMetaData("UPDATEDBY", SqlDbType.Int),
                new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("ISBUSINESS", SqlDbType.SmallInt),
                new SqlMetaData("INSIDECITYLIMITS", SqlDbType.SmallInt),
                new SqlMetaData("LEGACYTEMP", SqlDbType.BigInt),
                new SqlMetaData("ISMAINADDRESS", SqlDbType.SmallInt)
                );
            foreach (tBaseAddresses data in this)
            {
                ret.SetInt32(0, data.ID);
                ret.SetInt32(1, data.DistributorID);
                ret.SetInt16(2, data.Addresstype);
                ret.SetInt32(3, data.LanguageCharSet);
                ret.SetInt32(4, data.RelatedAddressID);
                ret.SetString(5, data.Address);
                ret.SetString(6, data.Address1);
                ret.SetString(7, data.Address2);
                ret.SetString(8, data.City);
                ret.SetString(9, data.State);
                ret.SetString(10, data.Zip);
                ret.SetString(11, data.County);
                ret.SetString(12, data.Country);
                ret.SetInt32(13, data.CountryID);
                ret.SetInt16(14, data.Setasdefault);
                ret.SetDateTime(15, data.CreatedDate);
                ret.SetInt32(16, data.CreatedBy);
                ret.SetInt32(17, data.Status);
                ret.SetInt32(18, data.UpdatedBy);
                ret.SetDateTime(19, data.UpdatedDate);                
                ret.SetInt16(20, data.IsBusiness);
                ret.SetInt16(21, data.InsideCityLimits);
                ret.SetInt64(22, data.LegacyNumber);
                ret.SetInt16(23, data.IsMainAddress);
                yield return ret;
            }
        }
    }

    public class tBaseOrderDetailChild
    {
        public Int32 Id { get; set; }
        public Int32 DetaildId { get; set; }
        public Int32 ProductId { get; set; }
        public Int32 ChildDetailId { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal QuantitySelected { get; set; }
        public String SkuId { get; set; }
        public Int32 MarketId { get; set; }
        public Int32 ProductChildId { get; set; }
    }

    public class tBaseOrderDetailChildList : List<tBaseOrderDetailChild>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("DETAILID", SqlDbType.Int),
                new SqlMetaData("PRODUCTID", SqlDbType.Int),
                new SqlMetaData("CHILDDETAILID", SqlDbType.Int),
                new SqlMetaData("QUANTITY", SqlDbType.Decimal),
                new SqlMetaData("QUANTITYSELECTED", SqlDbType.Decimal),
                new SqlMetaData("SKUID", SqlDbType.VarChar, 50),
                new SqlMetaData("MARKETID", SqlDbType.Int),
                new SqlMetaData("PRODUCTCHILDID", SqlDbType.Int)
                );
            foreach (tBaseOrderDetailChild data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.DetaildId);
                ret.SetInt32(2, data.ProductId);
                ret.SetInt32(3, data.ChildDetailId);
                ret.SetDecimal(4, data.Quantity);
                ret.SetDecimal(5, data.QuantitySelected);
                ret.SetString(6, data.SkuId);
                ret.SetInt32(7, data.MarketId);
                ret.SetInt32(8, data.ProductChildId);
                yield return ret;
            }
        }
    }




    [Serializable]
    public class tBaseTicket
    {
        public Int32 Id { get; set; }
        public Int32 EventId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public Int32 Quantity { get; set; }
        public Int16 ShowDescriptionOnEventPage { get; set; }
        public Int32 MinPerOrder { get; set; }
        public Int32 MaxPerOrder { get; set; }
        public Int16 Type { get; set; }
        public DateTime SaleStartDateTime { get; set; }
        public DateTime SaleEndDateTime { get; set; }
        public Int16 AllowGuestToRegister { get; set; }
        public Int16 Status { get; set; }
    }

    [Serializable]
    public class tBaseTicketList : List<tBaseTicket>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("EVENTID", SqlDbType.Int),
                new SqlMetaData("NAME", SqlDbType.NVarChar, 150),
                new SqlMetaData("DESCRIPTION", SqlDbType.NVarChar, 350),
                new SqlMetaData("PRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("QUANTITY", SqlDbType.Int),
                new SqlMetaData("SHOWDESCRIPTIONONEVENTPAGE", SqlDbType.SmallInt),
                new SqlMetaData("MINPERORDER", SqlDbType.Int),
                new SqlMetaData("MAXPERORDER", SqlDbType.Int),
                new SqlMetaData("TYPE", SqlDbType.SmallInt),
                new SqlMetaData("SALESTARTDATETIME", SqlDbType.DateTime),
                new SqlMetaData("SALEENDDATETIME", SqlDbType.DateTime),
                new SqlMetaData("ALLOWGUESTTOREGISTER", SqlDbType.SmallInt),
                new SqlMetaData("STATUS", SqlDbType.SmallInt)
                );
            foreach (tBaseTicket data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.EventId);
                ret.SetString(2, data.Name);
                ret.SetString(3, data.Description);
                ret.SetDecimal(4, data.Price);
                ret.SetInt32(5, data.Quantity);
                ret.SetInt16(6, data.ShowDescriptionOnEventPage);
                ret.SetInt32(7, data.MinPerOrder);
                ret.SetInt32(8, data.MaxPerOrder);
                ret.SetInt16(9, data.Type);
                ret.SetDateTime(10, data.SaleStartDateTime);
                ret.SetDateTime(11, data.SaleEndDateTime);
                ret.SetInt16(12, data.AllowGuestToRegister);
                ret.SetInt16(13, data.Status);

                yield return ret;
            }
        }
    }















    public class tBaseOrderDetailTick
    {
        public Int32 Id { get; set; }
        public String Skuid { get; set; }
        public Decimal Unitprice { get; set; }
        public Int32 Quantity { get; set; }
        public Int32 DetailType { get; set; }
        public Decimal Totalprice { get; set; }
        public Decimal Discount { get; set; }
        public Decimal Qualifyingvolume { get; set; }
        public Decimal Commvalue { get; set; }
        public Int16 Action { get; set; }
    }

    [Serializable]
    public class tBaseOrderDetailTickList : List<tBaseOrderDetailTick>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("SKUID", SqlDbType.VarChar, 50),
                new SqlMetaData("UNITPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("QUANTITY", SqlDbType.Int),
                new SqlMetaData("DETAILTYPE", SqlDbType.Int),
                new SqlMetaData("TOTALPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("DISCOUNT", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("QUALIFYINGVOLUME", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("COMMVALUE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("ACTION", SqlDbType.SmallInt)
                );
            foreach (tBaseOrderDetailTick data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.Skuid);
                ret.SetDecimal(2, data.Unitprice);
                ret.SetInt32(3, data.Quantity);
                ret.SetInt32(4, data.DetailType);
                ret.SetDecimal(5, data.Totalprice);
                ret.SetDecimal(6, data.Discount);
                ret.SetDecimal(7, data.Qualifyingvolume);
                ret.SetDecimal(8, data.Commvalue);
                ret.SetInt16(9, data.Action);
                yield return ret;
            }
        }
    }



    public class tBaseOrderDetail
    {
        public Int32 Id { get; set; }
        public String Skuid { get; set; }
        public Decimal Unitprice { get; set; }
        public Int32 Quantity { get; set; }
        public BaseEntity DetailType { get; set; }
        public Decimal Totalprice { get; set; }
        public Decimal Discount { get; set; }
        public Decimal Qualifyingvolume { get; set; }
        public Decimal Commvalue { get; set; }
	   public Decimal SalesTax { get; set; }
	   public Int16 Action { get; set; }
        public String Name { get; set; }
        public Int32 AttributeId { get; set; }
        public Int32 ProductId { get; set; }
        public Int32 WarehouseId { get; set; }        
    }


    public class tBaseOrderDetailList : List<tBaseOrderDetail>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("SKUID", SqlDbType.VarChar, 50),
                new SqlMetaData("UNITPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("QUANTITY", SqlDbType.Int),
                new SqlMetaData("DETAILTYPE", SqlDbType.Int),
                new SqlMetaData("TOTALPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("DISCOUNT", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("QUALIFYINGVOLUME", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("COMMVALUE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("ACTION", SqlDbType.SmallInt)
                );
            foreach (tBaseOrderDetail data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.Skuid);
                ret.SetDecimal(2, data.Unitprice);
                ret.SetInt32(3, data.Quantity);
              //  ret.SetInt32(4, data.DetailType.ID);
                ret.SetDecimal(5, data.Totalprice);
                ret.SetDecimal(6, data.Discount);
                ret.SetDecimal(7, data.Qualifyingvolume);
                ret.SetDecimal(8, data.Commvalue);
                ret.SetInt16(9, data.Action);
                yield return ret;
            }
        }
    }
     //--------------------------
    public class tBaseOrderDetailUpdateStock : List<tBaseOrderDetail>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("SKUID", SqlDbType.VarChar, 50),
                new SqlMetaData("PRODUCTID", SqlDbType.Int),
                new SqlMetaData("UNITPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("QUANTITY", SqlDbType.Int),
                new SqlMetaData("DETAILTYPE", SqlDbType.Int),
                new SqlMetaData("TOTALPRICE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("DISCOUNT", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("QUALIFYINGVOLUME", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("COMMVALUE", SqlDbType.Decimal, 18, 2),
                new SqlMetaData("ACTION", SqlDbType.SmallInt)
                );
            foreach (tBaseOrderDetail data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.Skuid);
                ret.SetInt32(2, data.ProductId);
                ret.SetDecimal(3, data.Unitprice);
                ret.SetInt32(4, data.Quantity);
                ret.SetInt32(5, data.DetailType.ID);
                ret.SetDecimal(6, data.Totalprice);
                ret.SetDecimal(7, data.Discount);
                ret.SetDecimal(8, data.Qualifyingvolume);
                ret.SetDecimal(9, data.Commvalue);
                ret.SetInt16(10, data.Action);
                yield return ret;
            }
        }
    }
    //--------------------------



    [Serializable]
    public class tBaseIdv3
    {
        public Int32 Id { get; set; }
        public Int32 Id2 { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Quantity2 { get; set; }
        public Int16 Status { get; set; }
        public Int16 Action { get; set; }
    }

    [Serializable]
    public class tBaseIdListv3 : List<tBaseIdv3>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("ID2", SqlDbType.Int),
                new SqlMetaData("QUANTITY", SqlDbType.Decimal),
                new SqlMetaData("QUANTITY2", SqlDbType.Decimal),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt)
                );
            foreach (tBaseIdv3 data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.Id2);
                ret.SetDecimal(2, data.Quantity);
                ret.SetDecimal(3, data.Quantity2);
                ret.SetInt16(4, data.Status);
                ret.SetInt16(5, data.Action);
                yield return ret;
            }
        }
    }
    [Serializable]
    public class tBasePartyAttendees
    {
        public Int32 ID { get; set; }
        public Int32 PartyId { get; set; }
        public String InviteeName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public Int16 Status { get; set; }
        public DateTime ThanksYouSent { get; set; }
        public DateTime Reminded { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 UpdatedBy { get; set; }
        public DateTime Invited { get; set; }
        public DateTime Missed { get; set; }
        public Int16 Action { get; set; }
        public String Address1 { get; set; }
        public Int32 CountryId { get; set; }
        public Int16 Confirmed { get; set; }
    }

    [Serializable]
    public class tBasePartyAttendeesList : List<tBasePartyAttendees>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("PARTYID", SqlDbType.Int),
                new SqlMetaData("INVITEENAME", SqlDbType.NVarChar, 50),
                new SqlMetaData("EMAIL", SqlDbType.NVarChar, 50),
                new SqlMetaData("PHONE", SqlDbType.NVarChar, 50),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("THANKYOUSENT", SqlDbType.DateTime),
                new SqlMetaData("REMINDED", SqlDbType.DateTime),
                new SqlMetaData("INVITED", SqlDbType.DateTime),
                new SqlMetaData("MISSED", SqlDbType.DateTime),
                new SqlMetaData("ACTION", SqlDbType.SmallInt),
                new SqlMetaData("ADDRESS1", SqlDbType.NVarChar, 250),
                new SqlMetaData("COUNTRYID", SqlDbType.Int),
                new SqlMetaData("CONFIRMED", SqlDbType.SmallInt)
                );
            foreach (tBasePartyAttendees data in this)
            {
                ret.SetInt32(0, data.ID);
                ret.SetInt32(1, data.PartyId);
                ret.SetString(2, data.InviteeName);
                ret.SetString(3, data.Email);
                ret.SetString(4, data.Phone);
                ret.SetInt16(5, data.Status);
                ret.SetDateTime(6, data.ThanksYouSent);
                ret.SetDateTime(7, data.Reminded);
                ret.SetDateTime(8, data.Invited);
                ret.SetDateTime(9, data.Missed);
                ret.SetInt16(10, data.Action);
                ret.SetString(11, data.Address1);
                ret.SetInt32(12, data.CountryId);
                ret.SetInt16(13, data.Confirmed);
                yield return ret;
            }
        }
    }

    #region AlertSystem_Market
    [Serializable]
    public class tBaseAlertSystem_Market
    {
        public Int32 AlertId { get; set; }
        public Int32 MarketId { get; set; }
        public Int16 Status { get; set; }
    }

    [Serializable]
    public class tBaseAlertSystem_MarketList : List<tBaseAlertSystem_Market>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ALERTID", SqlDbType.Int),
                new SqlMetaData("MARKETID", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt)
                );
            foreach (tBaseAlertSystem_Market data in this)
            {
                ret.SetInt32(0, data.AlertId);
                ret.SetInt32(1, data.MarketId);
                ret.SetInt16(2, data.Status);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseAlertSystem_Distributor
    {
        public Int32 AlertId { get; set; }
        public Int32 DistributorId { get; set; }
        public Int16 Status { get; set; }
        public Int64 LegacyNumber { get; set; }
    }


    [Serializable]
    public class tBaseAlertSystem_DistributorList : List<tBaseAlertSystem_Distributor>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ALERTID", SqlDbType.Int),
                new SqlMetaData("DISTRIBUTORID", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("LEGACYNUMBER", SqlDbType.BigInt)
                );
            foreach (tBaseAlertSystem_Distributor data in this)
            {
                ret.SetInt32(0, data.AlertId);
                ret.SetInt32(1, data.DistributorId);
                ret.SetInt16(2, data.Status);
                ret.SetInt64(3, data.LegacyNumber);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseAlertSystem_Rank
    {
        public Int32 AlertId { get; set; }
        public Int16 RankId { get; set; }
        public Int16 Status { get; set; }
    }


    [Serializable]
    public class tBaseAlertSystem_RankList : List<tBaseAlertSystem_Rank>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ALERTID", SqlDbType.Int),
                new SqlMetaData("RANKID", SqlDbType.SmallInt),
                new SqlMetaData("STATUS", SqlDbType.SmallInt)
                );
            foreach (tBaseAlertSystem_Rank data in this)
            {
                ret.SetInt32(0, data.AlertId);
                ret.SetInt16(1, data.RankId);
                ret.SetInt16(2, data.Status);
                yield return ret;
            }
        }
    }



    [Serializable]
    public class tBaseAlertSystem_Language
    {
        public Int32 AlertId { get; set; }
        public Int32 LanguageId { get; set; }
        public Int16 Status { get; set; }
    }


    [Serializable]
    public class tBaseAlertSystem_LanguageList : List<tBaseAlertSystem_Language>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ALERTID", SqlDbType.Int),
                new SqlMetaData("LANGUAGEID", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt)
                );
            foreach (tBaseAlertSystem_Language data in this)
            {
                ret.SetInt32(0, data.AlertId);
                ret.SetInt32(1, data.LanguageId);
                ret.SetInt16(2, data.Status);
                yield return ret;
            }
        }
    }


    #endregion

    [Serializable]
    public class tBaseProductMarket
    {
        public Int32 Id { get; set; }
        public Int32 ProductId { get; set; }
        public Int32 MarketId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 Createdby { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Updateby { get; set; }
        public Int16 Status { get; set; }
    }

    [Serializable]
    public class tBaseCauseMarket
    {
        public Int32 Id { get; set; }
        public Int32 CauseID { get; set; }
        public Int32 MarketID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 Createdby { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Updateby { get; set; }
        public Int16 Status { get; set; }
    }

    [Serializable]
    public class tBaseCauseDistributor
    {
        public Int32 Id { get; set; }
        public Int32 CauseID { get; set; }
        public Int32 DistributorID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 Createdby { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Updateby { get; set; }
        public Int16 Status { get; set; }
    }

    [Serializable]
    public class tBaseCauseModule
    {
        public Int32 Id { get; set; }
        public Int32 CauseID { get; set; }
        public Int32 ModuleID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 Createdby { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Updateby { get; set; }
        public Int16 Status { get; set; }
    }

    [Serializable]
    public class TBaseProductAccountType
    {
        public Int32 Id { get; set; }
        public Int32 ProductId { get; set; }
        public Int32 AccountTypeID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 Createdby { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Updateby { get; set; }
        public Int16 Status { get; set; }
    }

    [Serializable]
    public class TBaseProductModule
    {
        public Int32 Id { get; set; }
        public Int32 ProductId { get; set; }
        public Int32 ModuleID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 Createdby { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Updateby { get; set; }
        public Int16 Status { get; set; }
    }

    [Serializable]
    public class TBaseProductOrderSource
    {
        public Int32 Id { get; set; }
        public Int32 ProductId { get; set; }
        public Int32 OrderSourceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 Createdby { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Updateby { get; set; }
        public Int16 Status { get; set; }
    }


    [Serializable]
    public class tBaseProductMarketList : List<tBaseProductMarket>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("PRODUCTID", SqlDbType.Int),
                new SqlMetaData("MARKETID", SqlDbType.Int),
                 new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                  new SqlMetaData("CREATEDBY", SqlDbType.Int),
                   new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime),
                    new SqlMetaData("UPDATEDBY", SqlDbType.Int),
                    new SqlMetaData("STATUS", SqlDbType.SmallInt)
                );
            foreach (tBaseProductMarket data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.ProductId);
                ret.SetInt32(2, data.MarketId);
                ret.SetDateTime(3, data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate);
                ret.SetInt32(4, data.Createdby);
                ret.SetDateTime(5, data.UpdatedDate == default(DateTime) ? DateTime.Now : data.UpdatedDate);
                ret.SetInt32(6, data.Updateby);
                ret.SetInt16(7, data.Status);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseCauseMarketList : List<tBaseCauseMarket>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("CAUSEID", SqlDbType.Int),
                new SqlMetaData("MARKETID", SqlDbType.Int),
                 new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                  new SqlMetaData("CREATEDBY", SqlDbType.Int),
                   new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime),
                    new SqlMetaData("UPDATEDBY", SqlDbType.Int),
                    new SqlMetaData("STATUS", SqlDbType.SmallInt)
                );
            foreach (tBaseCauseMarket data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.CauseID);
                ret.SetInt32(2, data.MarketID);
                ret.SetDateTime(3, data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate);
                ret.SetInt32(4, data.Createdby);
                ret.SetDateTime(5, data.UpdatedDate == default(DateTime) ? DateTime.Now : data.UpdatedDate);
                ret.SetInt32(6, data.Updateby);
                ret.SetInt16(7, data.Status);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseCauseModuleList : List<tBaseCauseModule>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("CAUSEID", SqlDbType.Int),
                new SqlMetaData("MODULEID", SqlDbType.Int),
                 new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                  new SqlMetaData("CREATEDBY", SqlDbType.Int),
                   new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime),
                    new SqlMetaData("UPDATEDBY", SqlDbType.Int),
                    new SqlMetaData("STATUS", SqlDbType.SmallInt)
                );
            foreach (tBaseCauseModule data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.CauseID);
                ret.SetInt32(2, data.ModuleID);
                ret.SetDateTime(3, data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate);
                ret.SetInt32(4, data.Createdby);
                ret.SetDateTime(5, data.UpdatedDate == default(DateTime) ? DateTime.Now : data.UpdatedDate);
                ret.SetInt32(6, data.Updateby);
                ret.SetInt16(7, data.Status);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseCauseDistributorList : List<tBaseCauseDistributor>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("CAUSEID", SqlDbType.Int),
                new SqlMetaData("DISTRIBUTORID", SqlDbType.Int),
                 new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                  new SqlMetaData("CREATEDBY", SqlDbType.Int),
                   new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime),
                    new SqlMetaData("UPDATEDBY", SqlDbType.Int),
                    new SqlMetaData("STATUS", SqlDbType.SmallInt)
                );
            foreach (tBaseCauseDistributor data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.CauseID);
                ret.SetInt32(2, data.DistributorID);
                ret.SetDateTime(3, data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate);
                ret.SetInt32(4, data.Createdby);
                ret.SetDateTime(5, data.UpdatedDate == default(DateTime) ? DateTime.Now : data.UpdatedDate);
                ret.SetInt32(6, data.Updateby);
                ret.SetInt16(7, data.Status);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class TBaseProductAccountTypeList : List<TBaseProductAccountType>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
              new SqlMetaData("ID", SqlDbType.Int),
              new SqlMetaData("PRODUCTID", SqlDbType.Int),
              new SqlMetaData("ACCOUNTTYPEID", SqlDbType.Int),
               new SqlMetaData("STATUS", SqlDbType.SmallInt),
               new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                 new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime),
                  new SqlMetaData("UPDATEDBY", SqlDbType.Int)
              );
            foreach (TBaseProductAccountType data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.ProductId);
                ret.SetInt32(2, data.AccountTypeID);
                ret.SetInt16(3, data.Status);
                ret.SetDateTime(4, data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate);
                ret.SetInt32(5, data.Createdby);
                ret.SetDateTime(6, data.UpdatedDate == default(DateTime) ? DateTime.Now : data.UpdatedDate);
                ret.SetInt32(7, data.Updateby);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class TBaseProductModuleList : List<TBaseProductModule>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
              new SqlMetaData("ID", SqlDbType.Int),
              new SqlMetaData("PRODUCTID", SqlDbType.Int),
              new SqlMetaData("MODULEID", SqlDbType.Int),
              new SqlMetaData("STATUS", SqlDbType.SmallInt),
               new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                 new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime),
                  new SqlMetaData("UPDATEDBY", SqlDbType.Int)
              );
            foreach (TBaseProductModule data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.ProductId);
                ret.SetInt32(2, data.ModuleID);
                ret.SetInt16(3, data.Status);
                ret.SetDateTime(4, data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate);
                ret.SetInt32(5, data.Createdby);
                ret.SetDateTime(6, data.UpdatedDate == default(DateTime) ? DateTime.Now : data.UpdatedDate);
                ret.SetInt32(7, data.Updateby);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class TBaseProductOrderSourceList : List<TBaseProductOrderSource>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
              new SqlMetaData("ID", SqlDbType.Int),
              new SqlMetaData("PRODUCTID", SqlDbType.Int),
              new SqlMetaData("OrderSourceId", SqlDbType.Int),
              new SqlMetaData("STATUS", SqlDbType.SmallInt),
               new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                 new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime),
                  new SqlMetaData("UPDATEDBY", SqlDbType.Int)
              );
            foreach (TBaseProductOrderSource data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.ProductId);
                ret.SetInt32(2, data.OrderSourceId);
                ret.SetInt16(3, data.Status);
                ret.SetDateTime(4, data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate);
                ret.SetInt32(5, data.Createdby);
                ret.SetDateTime(6, data.UpdatedDate == default(DateTime) ? DateTime.Now : data.UpdatedDate);
                ret.SetInt32(7, data.Updateby);
                yield return ret;
            }
        }
    }


    [Serializable]
    public class tBaseTaxProviderMarket
    {
        public Int32 Id { get; set; }
        public Int32 TaxProviderId { get; set; }
        public Int32 MarketId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 Createdby { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Updateby { get; set; }
        public Int16 Status { get; set; }
    }

    [Serializable]
    public class tBaseTaxProviderMarketList : List<tBaseTaxProviderMarket>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("MARKETID", SqlDbType.Int),
                new SqlMetaData("TAXPROVIDERID", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                 new SqlMetaData("CREATEDBY", SqlDbType.Int),
                 new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                 new SqlMetaData("UPDATEDBY", SqlDbType.Int),
                   new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime)
                    
                    
                );
            foreach (tBaseTaxProviderMarket data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.MarketId);
                ret.SetInt32(2, data.TaxProviderId);
                ret.SetInt16(3, data.Status);
                ret.SetInt32(4, data.Createdby);
                ret.SetDateTime(5, data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate);
                ret.SetInt32(6, data.Updateby);
                ret.SetDateTime(7, data.UpdatedDate == default(DateTime) ? DateTime.Now : data.UpdatedDate);
               
               
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseTaxUserCurrencies
    {
        public Int32 Id { get; set; }
        public Int32 CurrencyId { get; set; }
        public Int32 UserId { get; set; }
        public Int16 Status { get; set; }
        public Int32 Createdby { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Updateby { get; set; }
    }
    
    [Serializable]
    public class tBaseTaxUserCurrenciesList : List<tBaseTaxUserCurrencies>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("CURRENCYID", SqlDbType.Int),
                new SqlMetaData("USERID", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("UPDATEDBY", SqlDbType.Int),
                new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime)
            );
            foreach (tBaseTaxUserCurrencies data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.CurrencyId);
                ret.SetInt32(2, data.UserId);
                ret.SetInt16(3, data.Status);
                ret.SetInt32(4, data.Createdby);
                ret.SetDateTime(5, data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate);
                ret.SetInt32(6, data.Updateby);
                ret.SetDateTime(7, data.UpdatedDate == default(DateTime) ? DateTime.Now : data.UpdatedDate);

                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseTaxUserCountries
    {
        public Int32 Id { get; set; }
        public Int32 CountryId { get; set; }
        public Int32 UserId { get; set; }
        public Int16 Status { get; set; }
        public Int32 Createdby { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Updateby { get; set; }
    }
    
    public class tBaseTaxUserCountriesList : List<tBaseTaxUserCountries>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("COUNTRYID", SqlDbType.Int),
                new SqlMetaData("USERID", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("UPDATEDBY", SqlDbType.Int),
                new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime)
            );
            foreach (tBaseTaxUserCountries data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.CountryId);
                ret.SetInt32(2, data.UserId);
                ret.SetInt16(3, data.Status);
                ret.SetInt32(4, data.Createdby);
                ret.SetDateTime(5, data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate);
                ret.SetInt32(6, data.Updateby);
                ret.SetDateTime(7, data.UpdatedDate == default(DateTime) ? DateTime.Now : data.UpdatedDate);

                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseTaxUserMarkets
    {
        public Int32 Id { get; set; }
        public Int32 MarketId { get; set; }
        public Int32 UserId { get; set; }
        public Int16 Status { get; set; }
        public Int32 Createdby { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Updateby { get; set; }
    }

    public class tBaseTaxUserMarketsList : List<tBaseTaxUserMarkets>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("MARKETID", SqlDbType.Int),
                new SqlMetaData("USERID", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("UPDATEDBY", SqlDbType.Int),
                new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime)
            );
            foreach (tBaseTaxUserMarkets data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.MarketId);
                ret.SetInt32(2, data.UserId);
                ret.SetInt16(3, data.Status);
                ret.SetInt32(4, data.Createdby);
                ret.SetDateTime(5, data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate);
                ret.SetInt32(6, data.Updateby);
                ret.SetDateTime(7, data.UpdatedDate == default(DateTime) ? DateTime.Now : data.UpdatedDate);

                yield return ret;
            }
        }
    }





    [Serializable]
    public class tBaseOrdersStatus
    {
        public Int32 Id { get; set; }
        public Int32 OrderStatusId { get; set; }

    }

    public class tBaseOrdersStatusList : List<tBaseOrdersStatus>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("ORDERSTATUSID", SqlDbType.Int)

            );

            foreach (tBaseOrdersStatus data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.OrderStatusId);

                yield return ret;
            }
        }
    }



    [Serializable]
    public class tBaseOrdersType
    {
        public Int32 Id { get; set; }
        public Int32 OrderTypesId { get; set; }

    }

    public class tBaseOrdersTypeList : List<tBaseOrdersType>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("ORDERTYPEID", SqlDbType.Int)

            );

            foreach (tBaseOrdersType data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.OrderTypesId);

                yield return ret;
            }
        }
    }




    [Serializable]
    public class tBaseLanguageID
    {
        public Int32 Id { get; set; }
        public Int32 LanguageId { get; set; }

    }

    public class tBaseLanguagueIdList : List<tBaseLanguageID>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("LANGUAGEID", SqlDbType.Int)

            );

            foreach (tBaseLanguageID data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.LanguageId);

                yield return ret;
            }
        }
    }



    [Serializable]
    public class tBaseShippingProviderDetail
    {
        public Int32 Id { get; set; }
        public Int32 ShippingProviderId { get; set; }
        public String Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 Createdby { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Updatedby { get; set; }
        public Int16 Status { get; set; }
        public Int32 ServiceId { get; set; }
    }

    [Serializable]
    public class tBaseShippingProviderDetailList : List<tBaseShippingProviderDetail>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("SHIPPINGPROVIDERID", SqlDbType.Int),
                new SqlMetaData("NAME", SqlDbType.VarChar, 500),
                new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                new SqlMetaData("UPDATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("UPDATEDBY", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("SERVICEID", SqlDbType.Int)
                );
            foreach (tBaseShippingProviderDetail data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.ShippingProviderId);
                ret.SetString(2, data.Name);
                ret.SetDateTime(3, data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate);
                ret.SetInt32(4, data.Createdby);
                ret.SetDateTime(5, data.UpdatedDate == default(DateTime) ? DateTime.Now : data.UpdatedDate);
                ret.SetInt32(6, data.Updatedby);
                ret.SetInt16(7, data.Status);
                ret.SetInt32(8, data.ServiceId);
                yield return ret;
            }
        }

    }
    [Serializable]
    public class srProductFilters
    {
        public Int32 Id { get; set; }
    }

    [Serializable]
    public class tBaseProducFiltersList : List<srProductFilters>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int)
                );
            foreach (srProductFilters data in this)
            {
                ret.SetInt32(0, data.Id);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tCreditCard {
        public Int32 Id { get; set; }
        public Int32 DistributorId { get; set; }
        public String TokenID { get; set; }
        public String Nameoncard { get; set; }
        public String Cardtype { get; set; }
        public String Cardnumber { get; set; }
        public Int32 Expmonth { get; set; }
        public Int32 Expyear { get; set; }
        public Int32 Ccv { get; set; }
        public String Ccv2 { get; set; }
        public string CVV { get; set; }
        public String Last4 { get; set; }
        public string Last4Str { get; set; }
        public Int32 save { get; set; }
        public Int16 type { get; set; } // default or backup
        public string CcvStr { get; set; }
        public Int32 CompanyId { get; set; }    
        public Int32 Createdby { get; set; }
        public Int32 Status { get; set; }
        public Int32 PaymentType { get; set; }
        public Decimal Amount { get; set; }
        public Int64 IdProcessing { get; set; }
        public String TransactionID { get; set; }
        public Int32 MerchantProcessorID { get; set; }

    }

    [Serializable]
    public class tCreditCardList : List<tCreditCard>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("DISTRIBUTORID", SqlDbType.Int),
                new SqlMetaData("NAMEONCARD", SqlDbType.NVarChar, 50),
                new SqlMetaData("CARDTYPE", SqlDbType.VarChar, 50),
                new SqlMetaData("CARDNUMBER", SqlDbType.VarChar, 50),
                new SqlMetaData("EXPMONTH", SqlDbType.Int),
                new SqlMetaData("EXPYEAR", SqlDbType.Int),
                new SqlMetaData("CCV", SqlDbType.VarChar, 50),
                new SqlMetaData("LAST4", SqlDbType.VarChar, 8),
                new SqlMetaData("STATUS", SqlDbType.Int),
                new SqlMetaData("LAST4_STR", SqlDbType.VarChar, 4),
                new SqlMetaData("PAYMENTTYPE", SqlDbType.Int),
                new SqlMetaData("AMOUNT", SqlDbType.Decimal, 18,2),
                new SqlMetaData("IDPROCESSING",SqlDbType.BigInt),
                new SqlMetaData("TRANSACTIONID", SqlDbType.VarChar, 50),
                new SqlMetaData("TOKENID", SqlDbType.VarChar, 50),
                new SqlMetaData("MERCHANTPROCESSORID", SqlDbType.Int)
                );
            foreach (tCreditCard data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.DistributorId);
                ret.SetString(2, data.Nameoncard);
                ret.SetString(3, data.Cardtype);
                ret.SetString(4, !String.IsNullOrEmpty(data.Cardnumber) ? data.Cardnumber : String.Empty);
                ret.SetInt32(5, data.Expmonth);
                ret.SetInt32(6, data.Expyear);
                ret.SetString(7, !String.IsNullOrEmpty(data.Ccv2) ? data.Ccv2 : String.Empty);
                ret.SetString(8, data.Last4);
                ret.SetInt32(9, data.Status);
                ret.SetString(10, !String.IsNullOrEmpty(data.Last4Str)? data.Last4Str: String.Empty);
                ret.SetInt32(11, data.PaymentType);
                ret.SetDecimal(12, data.Amount);
                ret.SetInt64(13, data.IdProcessing);
                ret.SetString(14, data.TransactionID);
                ret.SetString(15, !String.IsNullOrEmpty(data.TokenID)? data.TokenID:String.Empty);
                ret.SetInt32(16, data.MerchantProcessorID);
                yield return ret;
            }
        }
    }


    [Serializable]
    public class tDetailPayment
    {
        public Int32 Id { get; set; }
        public Int32 OrderId { get; set; }
        public Int32 CardId { get; set; }
        public Int32 PaymentType { get; set; }
        public Decimal Amount { get; set; }
        public Int32 Status { get; set; }
        public String TransactionID { get; set; }
        public Int32 DistributorID { get; set; }
    }

    [Serializable]
    public class tDetailPaymentList : List<tDetailPayment>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("ORDERID", SqlDbType.Int),
                new SqlMetaData("CARDID", SqlDbType.Int),
                new SqlMetaData("PAYMENTYPE", SqlDbType.Int),
                new SqlMetaData("AMOUNT", SqlDbType.Decimal, 18,2),  
                new SqlMetaData("TRANSACTIONID", SqlDbType.VarChar, 50),
                new SqlMetaData("STATUS", SqlDbType.Int),
                new SqlMetaData("DISTRIBUTORID", SqlDbType.Int)

                );
            foreach (tDetailPayment data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.OrderId);
                ret.SetInt32(2, data.CardId);
                ret.SetInt32(3, data.PaymentType);
                ret.SetDecimal(4, data.Amount);
                ret.SetString(5, data.TransactionID);
                ret.SetInt32(6, data.Status);
                ret.SetInt32(7, data.DistributorID);
                
                yield return ret;
            }
        }
    }


    [Serializable]
    public class srBaseLogger
    {
        public srBaseLogger()
        {
            this.CreatedDate = DateTime.Now;
            this.NameAPI = String.Empty;
            this.ActionAPI = String.Empty;
            this.NameProcess = String.Empty;
            this.MessageSuccessError = String.Empty;
            this.Custom1 = String.Empty;
            this.Custom2 = String.Empty;
            this.Custom3 = String.Empty;
            this.Custom4 = String.Empty;
            this.Custom5 = String.Empty;
            this.Custom6 = String.Empty;
            this.Custom7 = String.Empty;
            this.Custom8 = String.Empty;
            this.Custom9 = String.Empty;
            this.Custom10 = String.Empty;
        }
        public Int64 DistributorId { get; set; }
        public String NameAPI { get; set; }
        public String ActionAPI { get; set; }
        public String NameProcess { get; set; }
        public String MessageSuccessError { get; set; }
        public String InvoiceNro { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 CreatedBy { get; set; }
        public Int32 Status { get; set; }
        public String Custom1 { get; set; }//REQUEST
        public String Custom2 { get; set; }//RESPONSE
        public String Custom3 { get; set; }//PASSWORD
        public String Custom4 { get; set; }//IPADDRESS
        public String Custom5 { get; set; }//CULTURENAME
        public String Custom6 { get; set; }
        public String Custom7 { get; set; }
        public String Custom8 { get; set; }
        public String Custom9 { get; set; }
        public String Custom10 { get; set; }
        public Int32 Custom11 { get; set; }
        public Int16 Custom12 { get; set; }
    }

    [Serializable]
    public class tBaseLoggerList : List<srBaseLogger>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("DISTRIBUTORID", SqlDbType.BigInt),
                new SqlMetaData("NAMEAPI", SqlDbType.VarChar, 50),
                new SqlMetaData("ACTIONAPI", SqlDbType.VarChar, 50),
                new SqlMetaData("NAMEPROCESS", SqlDbType.VarChar, 50),
                new SqlMetaData("MESSAGESUCCESSERROR", SqlDbType.VarChar, 200),
                new SqlMetaData("INVOICENRO", SqlDbType.VarChar, 50),
                new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.Int),
                new SqlMetaData("CUSTOM1", SqlDbType.NText),//REQUEST
                new SqlMetaData("CUSTOM2", SqlDbType.NText),//RESPONSE
                new SqlMetaData("CUSTOM3", SqlDbType.VarChar, -1),//PASSWORD
                new SqlMetaData("CUSTOM4", SqlDbType.VarChar, -1),//IPADDRESS
                new SqlMetaData("CUSTOM5", SqlDbType.VarChar, -1),//CULTURENAME
                new SqlMetaData("CUSTOM6", SqlDbType.VarChar, 50),
                new SqlMetaData("CUSTOM7", SqlDbType.VarChar, 50),
                new SqlMetaData("CUSTOM8", SqlDbType.VarChar, 50),
                new SqlMetaData("CUSTOM9", SqlDbType.VarChar, 50),
                new SqlMetaData("CUSTOM10", SqlDbType.VarChar, 50),
                new SqlMetaData("CUSTOM11", SqlDbType.Int),
                new SqlMetaData("CUSTOM12", SqlDbType.SmallInt)
                );
            foreach (srBaseLogger data in this)
            {
                ret.SetInt64(0, data.DistributorId);
                ret.SetString(1, data.NameAPI ?? String.Empty);
                ret.SetString(2, data.ActionAPI ?? String.Empty);
                ret.SetString(3, data.NameProcess ?? String.Empty);
                ret.SetString(4, data.MessageSuccessError ?? String.Empty);
                ret.SetString(5, data.InvoiceNro ?? String.Empty);
                ret.SetDateTime(6, data.CreatedDate);
                ret.SetInt32(7, data.CreatedBy);
                ret.SetInt32(8, data.Status);
                ret.SetString(9, data.Custom1 ?? String.Empty);
                ret.SetString(10, data.Custom2 ?? String.Empty);
                ret.SetString(11, data.Custom3 ?? String.Empty);
                ret.SetString(12, data.Custom4 ?? String.Empty);
                ret.SetString(13, data.Custom5 ?? String.Empty);
                ret.SetString(14, data.Custom6 ?? String.Empty);
                ret.SetString(15, data.Custom7 ?? String.Empty);
                ret.SetString(16, data.Custom8 ?? String.Empty);
                ret.SetString(17, data.Custom9 ?? String.Empty);
                ret.SetString(18, data.Custom10 ?? String.Empty);
                ret.SetInt32(19, data.Custom11);
                ret.SetInt16(20, data.Custom12);
                yield return ret;
            }
        }
    }


    #region XIPIX
    [Serializable]
    public class tDetailShippingXipix
    {
        public Int32 Id { get; set; }
        public Int64 LegacyNumber { get; set; }
        public String TrackingNumber { get; set; }
        public DateTime ShippingDate { get; set; }
        public String InvoiceNo { get; set; }
        //public Decimal Amount { get; set; }
        //public Int32 Status { get; set; }
    }

    [Serializable]
    public class tDetailShippingXipixList : List<tDetailShippingXipix>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

            SqlDataRecord ret = new SqlDataRecord(
                 new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("LEGACYNUMBER", SqlDbType.BigInt),
                new SqlMetaData("TRACKINGNUMBER", SqlDbType.VarChar,50),
                new SqlMetaData("SHIPPINGDATE", SqlDbType.DateTime),
                new SqlMetaData("INVOICENO", SqlDbType.NVarChar, 50)

    
                );
            foreach (tDetailShippingXipix data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt64(1, data.LegacyNumber);
                ret.SetString(2, data.TrackingNumber);
                ret.SetDateTime(3, data.ShippingDate);
                ret.SetString(4, data.InvoiceNo);

                yield return ret;
            }
        }
    }
    #endregion XIPIX

    #region IntegraCore
    [Serializable]
    public class tDetailShippingIntegraCore
    {
        public Int32 Id { get; set; }
        public String InvoiceNo { get; set; }
        public String TrackingNumber { get; set; }
        public DateTime ShippingDate { get; set; }
        //public Decimal Amount { get; set; }
        //public Int32 Status { get; set; }
    }

    [Serializable]
    public class tDetailShippingIntegraCoreList : List<tDetailShippingIntegraCore>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

            SqlDataRecord ret = new SqlDataRecord(
                 new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("INVOICENO", SqlDbType.VarChar, 50),
                new SqlMetaData("TRACKINGNUMBER", SqlDbType.VarChar, 50),
                new SqlMetaData("SHIPPINGDATE", SqlDbType.DateTime)

                );
            foreach (tDetailShippingIntegraCore data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.InvoiceNo);
                ret.SetString(2, data.TrackingNumber);
                ret.SetDateTime(3, data.ShippingDate);

                yield return ret;
            }
        }
    }

    [Serializable]
    public class tDetailMessageIntegraCore
    {
        public Int32 Id { get; set; }
        public String InvoiceNo { get; set; }
        public String Message { get; set; }
    }

    [Serializable]
    public class tDetailMessageIntegraCoreList : List<tDetailMessageIntegraCore>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("INVOICENO", SqlDbType.VarChar, 50),
                new SqlMetaData("MESSAGE", SqlDbType.VarChar, 200)
                );
            foreach (tDetailMessageIntegraCore data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.InvoiceNo);
                ret.SetString(2, data.Message);

                yield return ret;
            }
        }
    }


    [Serializable]
    public class tDetailIntegraCore
    {
        public Int32 Id { get; set; }
        public Int32 LogLevel { get; set; }
        public String InvoiceNo { get; set; }
        public String Webservice { get; set; }
        public String Request { get; set; }
        public String Response { get; set; }
        public String Message { get; set; }
        public Int32 isSend { get; set; }
        public String TrackingNumber { get ; set; }
        public DateTime DateShipped { get; set; }
        public String CUSTOM1 { get; set; }
        public String CUSTOM2 { get; set; }

        public tDetailIntegraCore(Int32 Id = 0, Int32 LogLevel = 0, String InvoiceNo = "", String Webservice = "", String Request = "", String Response = "", String Message = "", Int32 isSend = 0, String TrackingNumber = "", DateTime? DateShipped = null)
        {
            this.Id = Id;
            this.LogLevel = LogLevel;
            this.InvoiceNo = InvoiceNo;
            this.Webservice = Webservice;
            this.Request = Request;
            this.Response = Response;
            this.Message = Message;
            this.isSend = isSend;
            this.TrackingNumber = TrackingNumber;
            this.DateShipped = DateShipped ?? (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }

    }

    [Serializable]
    public class tDetailIntegraCoreList : List<tDetailIntegraCore>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("LOGLEVEL", SqlDbType.Int),
                new SqlMetaData("INVOICENO", SqlDbType.NVarChar,250),
                new SqlMetaData("WEBSERVICE", SqlDbType.NVarChar,150),
                new SqlMetaData("REQUEST", SqlDbType.NText),
                new SqlMetaData("RESPONSE", SqlDbType.NText),
                new SqlMetaData("MESSAGE", SqlDbType.NText),
                new SqlMetaData("ISSEND", SqlDbType.Int),
                new SqlMetaData("TRACKINGNUMBER", SqlDbType.NVarChar,250),
                new SqlMetaData("DATESHIPPED", SqlDbType.DateTime),
                new SqlMetaData("CUSTOM1", SqlDbType.NVarChar, 250),
                new SqlMetaData("CUSTOM2", SqlDbType.NVarChar, 250)
                );
            foreach (tDetailIntegraCore data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.LogLevel);
                ret.SetString(2, data.InvoiceNo);
                ret.SetString(3, data.Webservice);
                ret.SetString(4, data.Request);
                ret.SetString(5, data.Response);
                ret.SetString(6, data.Message);
                ret.SetInt32(7, data.isSend);
                ret.SetString(8, data.TrackingNumber);
                ret.SetDateTime(9, data.DateShipped);

                yield return ret;
            }
        }
    }
    #endregion IntegraCore





    #region Query Reports
    [Serializable]
    public class tQueryFields
    {
        public Int32 Id { get; set; }
        public Int32 QueryId { get; set; }
        public Int32 TableQueryId { get; set; }
        public Int32 TableQueryColumnId { get; set; }
        public String Alias { get; set; }
        public Int16 status { get; set; }
    }

    [Serializable]
    public class tQueryFieldsList : List<tQueryFields>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("QUERYID", SqlDbType.Int),
                new SqlMetaData("TABLEQUERYID", SqlDbType.Int),
                new SqlMetaData("TABLEQUERYCOLUMNID", SqlDbType.Int),
                new SqlMetaData("ALIAS", SqlDbType.NVarChar, 500),
                new SqlMetaData("STATUS", SqlDbType.SmallInt)
                );
            foreach (tQueryFields data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.QueryId);
                ret.SetInt32(2, data.TableQueryId);
                ret.SetInt32(3, data.TableQueryColumnId);
                ret.SetString(4, data.Alias);
                ret.SetInt16(5, data.status);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tQueryFilters
    {
        public Int32 Id { get; set; }
        public Int32 QueryId { get; set; }
        public Int32 TableQueryId { get; set; }
        public Int32 TableQueryColumnId { get; set; }
        public Int32 QueryComparisonId { get; set; }
        public String Value { get; set; }
        public Int16 Operator { get; set; }
        public Int16 status { get; set; }
    }

    [Serializable]
    public class tQueryFiltersList : List<tQueryFilters>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("QUERYID", SqlDbType.Int),
                new SqlMetaData("TABLEQUERYID", SqlDbType.Int),
                new SqlMetaData("TABLEQUERYCOLUMNID", SqlDbType.Int),
                new SqlMetaData("QUERYCOMPARISONID", SqlDbType.Int),
                new SqlMetaData("VALUE", SqlDbType.NVarChar, 500),
                new SqlMetaData("OPERATOR", SqlDbType.SmallInt),
                new SqlMetaData("STATUS", SqlDbType.SmallInt)
                );
            foreach (tQueryFilters data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.QueryId);
                ret.SetInt32(2, data.TableQueryId);
                ret.SetInt32(3, data.TableQueryColumnId);
                ret.SetInt32(4, data.QueryComparisonId);
                ret.SetString(5, data.Value);
                ret.SetInt16(6, data.Operator);
                ret.SetInt16(7, data.status);
                yield return ret;
            }
        }
    }
    #endregion

    #region password
    [Serializable]
    public class tBasePass
    {
        public Int32 ID { get; set; }
        public String Password { get; set; }
    }
    [Serializable]
    public class tBasePassList : List<tBasePass>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("PASSWORD", SqlDbType.VarChar, 150)

                );
            foreach (tBasePass data in this)
            {
                ret.SetInt32(0, data.ID);
                ret.SetString(1, data.Password);
                yield return ret;
            }
        }
    }
    #endregion


    [Serializable]
    public class tBaseEncryptionLogger
    {
        public tBaseEncryptionLogger()
        {
            this.CreatedDate = DateTime.Now;
            this.NameProcess = String.Empty;
            this.Title = String.Empty;
            this.MessageSuccessError = String.Empty;
            this.Data = String.Empty;
            this.Custom1 = String.Empty;
            this.Custom2 = String.Empty;
            this.Custom3 = String.Empty;
            this.Custom4 = String.Empty;
            this.Custom5 = String.Empty;
            this.Custom6 = String.Empty;
            this.Custom7 = String.Empty;
            this.Custom8 = String.Empty;
            this.Custom9 = String.Empty;
            this.Custom10 = String.Empty;
        }

        public Int32 Id { get; set; }
        public Int64 UserId { get; set; }
        public String NameProcess { get; set; }
        public String Title { get; set; }
        public String MessageSuccessError { get; set; }
        public String Data { get; set; }
        public String Indetifier { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 CreatedBy { get; set; }
        public Int16 Status { get; set; }
        public String Custom1 { get; set; }
        public String Custom2 { get; set; }
        public String Custom3 { get; set; }
        public String Custom4 { get; set; }
        public String Custom5 { get; set; }
        public String Custom6 { get; set; }
        public String Custom7 { get; set; }
        public String Custom8 { get; set; }
        public String Custom9 { get; set; }
        public String Custom10 { get; set; }
    }

    [Serializable]
    public class tBaseEncryptionLoggerList : List<tBaseEncryptionLogger>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("USERID", SqlDbType.BigInt),
                new SqlMetaData("NAMEPROCESS", SqlDbType.NVarChar, 150),
                new SqlMetaData("TITLE", SqlDbType.NVarChar, 150),
                new SqlMetaData("MESSAGESUCCESSERROR", SqlDbType.NVarChar, 250),
                new SqlMetaData("DATA", SqlDbType.NText),
                new SqlMetaData("IDENTIFIER", SqlDbType.NVarChar, 150),
                new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("CREATEDBY", SqlDbType.BigInt),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("CUSTOM1", SqlDbType.NText),//REQUEST
                new SqlMetaData("CUSTOM2", SqlDbType.NText),//RESPONSE
                new SqlMetaData("CUSTOM3", SqlDbType.NText),//PASSWORD
                new SqlMetaData("CUSTOM4", SqlDbType.NVarChar, 250),//IPADDRESS
                new SqlMetaData("CUSTOM5", SqlDbType.NVarChar, 250),//CULTURENAME
                new SqlMetaData("CUSTOM6", SqlDbType.NVarChar, 250),
                new SqlMetaData("CUSTOM7", SqlDbType.NVarChar, 250),
                new SqlMetaData("CUSTOM8", SqlDbType.NVarChar, 250),
                new SqlMetaData("CUSTOM9", SqlDbType.NVarChar, 250),
                new SqlMetaData("CUSTOM10", SqlDbType.NVarChar, 250)
            );

            foreach (tBaseEncryptionLogger data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt64(1, data.UserId);
                ret.SetString(2, data.NameProcess ?? String.Empty);
                ret.SetString(3, data.Title ?? String.Empty);
                ret.SetString(4, data.MessageSuccessError ?? String.Empty);
                ret.SetString(5, data.Data ?? String.Empty);
                ret.SetString(6, data.Indetifier ?? String.Empty);
                ret.SetDateTime(7, data.CreatedDate);
                ret.SetInt64(8, data.CreatedBy);
                ret.SetInt16(9, data.Status);
                ret.SetString(10, data.Custom1 ?? String.Empty);
                ret.SetString(11, data.Custom2 ?? String.Empty);
                ret.SetString(12, data.Custom3 ?? String.Empty);
                ret.SetString(13, data.Custom4 ?? String.Empty);
                ret.SetString(14, data.Custom5 ?? String.Empty);
                ret.SetString(15, data.Custom6 ?? String.Empty);
                ret.SetString(16, data.Custom7 ?? String.Empty);
                ret.SetString(17, data.Custom8 ?? String.Empty);
                ret.SetString(18, data.Custom9 ?? String.Empty);
                ret.SetString(19, data.Custom10 ?? String.Empty);

                yield return ret;
            }
        }
    }


    [Serializable]
    public class tBaseInput
    {
        public Int32 Id { get; set; }
        public String Property { get; set; }
        public Int32 DataTypeId { get; set; }
        public String Notes { get; set; }
        public Int32 Status { get; set; }
        public Int32 MethodId { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }

    [Serializable]
    public class tBaseInputList : List<tBaseInput>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("PROPERTY", SqlDbType.VarChar, 50),
                new SqlMetaData("DATATYPEID", SqlDbType.Int),
                new SqlMetaData("NOTES", SqlDbType.VarChar, 500),
                new SqlMetaData("STATUS", SqlDbType.Int),
                new SqlMetaData("METHODID", SqlDbType.Int),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                new SqlMetaData("UPDATEDBY", SqlDbType.Int)
                );
            foreach (tBaseInput data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.Property);
                ret.SetInt32(2, data.DataTypeId);
                ret.SetString(3, data.Notes);
                ret.SetInt32(4, data.Status);
                ret.SetInt32(5, data.MethodId);
                ret.SetInt32(6, data.CreatedBy);
                ret.SetInt32(7, data.UpdatedBy);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseOutput
    {
        public Int32 Id { get; set; }
        public String Property { get; set; }
        public Int32 DataTypeId { get; set; }
        public String Notes { get; set; }
        public Int32 Status { get; set; }
        public Int32 MethodId { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }

    [Serializable]
    public class tBaseOutputList : List<tBaseOutput>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("PROPERTY", SqlDbType.VarChar, 50),
                new SqlMetaData("DATATYPEID", SqlDbType.Int),
                new SqlMetaData("NOTES", SqlDbType.VarChar, 500),
                new SqlMetaData("STATUS", SqlDbType.Int),
                new SqlMetaData("METHODID", SqlDbType.Int),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                new SqlMetaData("UPDATEDBY", SqlDbType.Int)
                );
            foreach (tBaseOutput data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.Property);
                ret.SetInt32(2, data.DataTypeId);
                ret.SetString(3, data.Notes);
                ret.SetInt32(4, data.Status);
                ret.SetInt32(5, data.MethodId);
                ret.SetInt32(6, data.CreatedBy);
                ret.SetInt32(7, data.UpdatedBy);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseUpdateGenealogy
    {
        public Int64 legacyNumber { get; set; }
        public Int64 PlacementId { get; set; }
    }

    [Serializable]
    public class tBaseUpdateGenealogyList : List<tBaseUpdateGenealogy>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("LEGACYNUMBER", SqlDbType.BigInt),
                new SqlMetaData("PLACEMENTID", SqlDbType.BigInt)
                );
            foreach (tBaseUpdateGenealogy data in this)
            {
                ret.SetInt64(0, data.legacyNumber);
                ret.SetInt64(1, data.PlacementId);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseIdx2
    {
        public Int32 Id { get; set; }
        public Int16 Status { get; set; }
        public String Value { get; set; }
    }

    [Serializable]
    public class tBaseIdListx2 : List<tBaseIdx2>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("VALUE", SqlDbType.NVarChar, 4000)
                );
            foreach (tBaseIdx2 data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt16(1, data.Status);
                ret.SetString(2, data.Value);
                yield return ret;
            }
        }
    }



    [Serializable]
    public class tAccountLedgerLogger
    {
        public tAccountLedgerLogger()
        {
            this.ProcessName = String.Empty;
            this.MessageSuccessError = String.Empty;

            this.Custom1 = String.Empty;
            this.Custom2 = String.Empty;
            this.Custom3 = String.Empty;
            this.Custom4 = String.Empty;
            this.Custom5 = String.Empty;
            this.Custom6 = String.Empty;
            this.Custom7 = String.Empty;
            this.Custom8 = String.Empty;
            this.Custom9 = String.Empty;
            this.Custom10 = String.Empty;
        }

        public Int64 DistributorId { get; set; }
        public Int64 ProcessingId { get; set; }
        public Int64 RefundOrderId { get; set; }
        public Int16 ModuleId { get; set; }
        public Int64 OrderLegacyNumber { get; set; }

        public String ProcessName { get; set; }
        public String MessageSuccessError { get; set; }

        public DateTime CreatedDate { get; set; }
        public Int64 CreatedBy { get; set; }

        public String Custom1 { get; set; }
        public String Custom2 { get; set; }
        public String Custom3 { get; set; }
        public String Custom4 { get; set; }
        public String Custom5 { get; set; }
        public String Custom6 { get; set; }
        public String Custom7 { get; set; }
        public String Custom8 { get; set; }
        public String Custom9 { get; set; }
        public String Custom10 { get; set; }
    }

    [Serializable]
    public class tAccountLedgerLoggerList : List<tAccountLedgerLogger>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("DISTRIBUTORID", SqlDbType.BigInt),
                new SqlMetaData("PROCESSINGID", SqlDbType.BigInt),
                new SqlMetaData("REFUNDORDERID", SqlDbType.BigInt),
                new SqlMetaData("MODULEID", SqlDbType.SmallInt),
                new SqlMetaData("ORDERLEGACYNUMBER", SqlDbType.BigInt),
                new SqlMetaData("PROCESSNAME", SqlDbType.VarChar, 150),
                new SqlMetaData("MESSAGESUCCESSERROR", SqlDbType.VarChar, 350),
                new SqlMetaData("CREATEDDATE", SqlDbType.DateTime),
                new SqlMetaData("CREATEDBY", SqlDbType.BigInt),
                new SqlMetaData("CUSTOM1", SqlDbType.NText),//REQUEST
                new SqlMetaData("CUSTOM2", SqlDbType.NText),//RESPONSE
                new SqlMetaData("CUSTOM3", SqlDbType.VarChar, 50),
                new SqlMetaData("CUSTOM4", SqlDbType.VarChar, 50),
                new SqlMetaData("CUSTOM5", SqlDbType.VarChar, 50),
                new SqlMetaData("CUSTOM6", SqlDbType.VarChar, 50),
                new SqlMetaData("CUSTOM7", SqlDbType.VarChar, 50),
                new SqlMetaData("CUSTOM8", SqlDbType.VarChar, 50),
                new SqlMetaData("CUSTOM9", SqlDbType.VarChar, 50),
                new SqlMetaData("CUSTOM10", SqlDbType.VarChar, 50)
            );

            foreach (tAccountLedgerLogger data in this)
            {
                ret.SetInt64(0, data.DistributorId);
                ret.SetInt64(1, data.ProcessingId);
                ret.SetInt64(2, data.RefundOrderId);
                ret.SetInt16(3, data.ModuleId);
                ret.SetInt64(4, data.OrderLegacyNumber);
                ret.SetString(5, data.ProcessName ?? String.Empty);
                ret.SetString(6, data.MessageSuccessError ?? String.Empty);
                ret.SetDateTime(7, (data.CreatedDate == default(DateTime) ? DateTime.Now : data.CreatedDate));
                ret.SetInt64(8, data.CreatedBy);

                ret.SetString(9, data.Custom1 ?? String.Empty);
                ret.SetString(10, data.Custom2 ?? String.Empty);
                ret.SetString(11, data.Custom3 ?? String.Empty);
                ret.SetString(12, data.Custom4 ?? String.Empty);
                ret.SetString(13, data.Custom5 ?? String.Empty);
                ret.SetString(14, data.Custom6 ?? String.Empty);
                ret.SetString(15, data.Custom7 ?? String.Empty);
                ret.SetString(16, data.Custom8 ?? String.Empty);
                ret.SetString(17, data.Custom9 ?? String.Empty);
                ret.SetString(18, data.Custom10 ?? String.Empty);

                yield return ret;
            }
        }
    }

    [Serializable]
    public class tPayout
    {
        public Int64 legacynumber { get; set; }
        public String transactionID { get; set; }
        public String note { get; set; }
    }

    [Serializable]
    public class tBaseMarket
    {
        public Int32 ID { get; set; }
        public string NAME { get; set; }
        public string ABBNAME { get; set; }
        public Int32 MARKETID { get; set; }
        public Int16 STATUS { get; set; }
        public Int16 ACTION { get; set; }
    }

    [Serializable]
    public class tBaseMarketsList : List<tBaseMarket>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("NAME", SqlDbType.NVarChar, 4000),
                new SqlMetaData("ABBNAME", SqlDbType.NVarChar, 4000),
                new SqlMetaData("MARKETID", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt),
                new SqlMetaData("ACTION", SqlDbType.SmallInt)
                );
            foreach (tBaseMarket data in this)
            {
                ret.SetInt32(0, data.ID);
                ret.SetString(1, data.NAME);
                ret.SetString(2, data.ABBNAME);
                ret.SetInt32(3, data.MARKETID);
                ret.SetInt16(4, data.STATUS);
                ret.SetInt16(5, data.ACTION);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseIntBigint
    {
        public Int32 IDINT { get; set; }
        public Int64 IDBIGINT { get; set; }
        public Int32 LOGID { get; set; }
        public Int16 STATUS { get; set; }
    }

    [Serializable]
    public class tBaseIntBigintList : List<tBaseIntBigint>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("IDINT", SqlDbType.Int),
                new SqlMetaData("IDBIGINT", SqlDbType.BigInt),
                new SqlMetaData("LOGID", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.SmallInt)
                );
            foreach (tBaseIntBigint data in this)
            {
                ret.SetInt32(0, data.IDINT);
                ret.SetInt64(1, data.IDBIGINT);
                ret.SetInt32(2, data.LOGID);
                ret.SetInt16(3, data.STATUS);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseOrderTaxLine
    {
        public Int32 Id { get; set; }
        public String LineNo { get; set; }
        public String TaxCode { get; set; } 
        public Decimal Taxable { get; set; }
        public Decimal Rate { get; set; }
        public Decimal Tax { get; set; }
        public Decimal TaxCalculated { get; set; }
        public String Skuid { get; set; }
        public Int32 OrderId { get; set; }
        public Decimal Exempt { get; set; }
    }

    [Serializable]
    public class tBaseOrderTaxLineList : List<tBaseOrderTaxLine>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("LINENO", SqlDbType.VarChar, 50),
                new SqlMetaData("TAXCODE", SqlDbType.VarChar, 50),
                new SqlMetaData("TAXABLE", SqlDbType.Decimal, 18,4),
                new SqlMetaData("RATE", SqlDbType.Decimal, 18,4),
                new SqlMetaData("TAX", SqlDbType.Decimal, 18,4),
                new SqlMetaData("TAXCALCULATED", SqlDbType.Decimal, 18,4),
                new SqlMetaData("SKUID", SqlDbType.VarChar, 50),
                new SqlMetaData("ORDERID", SqlDbType.Int),
                new SqlMetaData("EXEMPT", SqlDbType.Decimal, 18,2)
                );
            foreach (tBaseOrderTaxLine data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.LineNo);
                ret.SetString(2, data.TaxCode);
                ret.SetDecimal(3, data.Taxable);
                ret.SetDecimal(4, data.Rate);
                ret.SetDecimal(5, data.Tax);
                ret.SetDecimal(6, data.TaxCalculated);
                ret.SetString(7, data.Skuid);
                ret.SetInt32(8, data.OrderId);
                ret.SetDecimal(9, data.Exempt);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tBaseOrderTaxDetail
    {
        public Int32 Id { get; set; }
        public String Country { get; set; }
        public String Region { get; set; }
        public String JurisType { get; set; }
        public String JurisCode { get; set; }
        public Decimal Taxable { get; set; }
        public Decimal Rate { get; set; }
        public Decimal Tax { get; set; }
        public String JurisName { get; set; }
        public String TaxName { get; set; }
        public String Skuid { get; set; }
        public Int32 OrderId { get; set; }
        public Decimal Exempt { get; set; }
    }

    [Serializable]
    public class tBaseOrderTaxDetailList : List<tBaseOrderTaxDetail>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("COUNTRY", SqlDbType.VarChar, 50),
                new SqlMetaData("REGION", SqlDbType.VarChar, 200),
                new SqlMetaData("JURISTYPE", SqlDbType.VarChar, 200),
                new SqlMetaData("JURISCODE", SqlDbType.VarChar, 50),
                new SqlMetaData("TAXABLE", SqlDbType.Decimal, 18, 4),
                new SqlMetaData("RATE", SqlDbType.Decimal, 18, 4),
                new SqlMetaData("TAX", SqlDbType.Decimal , 18, 4),
                new SqlMetaData("JURISNAME", SqlDbType.VarChar, 250),
                new SqlMetaData("TAXNAME", SqlDbType.VarChar, 250),
                new SqlMetaData("SKUID", SqlDbType.VarChar, 50),
                new SqlMetaData("ORDERID", SqlDbType.Int),
                new SqlMetaData("EXEMPT", SqlDbType.Decimal, 18, 2)
                );

            foreach (tBaseOrderTaxDetail data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.Country);
                ret.SetString(2, data.Region);
                ret.SetString(3, data.JurisType);
                ret.SetString(4, data.JurisCode);
                ret.SetDecimal(5, data.Taxable);
                ret.SetDecimal(6, data.Rate);
                ret.SetDecimal(7, data.Tax);
                ret.SetString(8, data.JurisName);
                ret.SetString(9, data.TaxName);
                ret.SetString(10, data.Skuid);
                ret.SetInt32(11, data.OrderId);
                ret.SetDecimal(12, data.Exempt);
                yield return ret;
            }
        }

    }

    #region shipstation

    [Serializable]
    public class tDetailShipStation
    {
        public Int32 Id { get; set; }
        public Int64 OrderNumber { get; set; }
        public String TrackingNumber { get; set; }
        public DateTime ShippingDate { get; set; }
    }

    [Serializable]
    public class tDetailShipStationList : List<tDetailShipStation>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("ORDERNUMBER", SqlDbType.BigInt),
                new SqlMetaData("TRACKINGNUMBER", SqlDbType.VarChar, 50),
                new SqlMetaData("SHIPPINGDATE", SqlDbType.DateTime)

                );
            foreach (tDetailShipStation data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt64(1, data.OrderNumber);
                ret.SetString(2, data.TrackingNumber);
                ret.SetDateTime(3, data.ShippingDate);

                yield return ret;
            }
        }
    }

    [Serializable]
    public class tDetailMessageShipStation
    {
        public Int32 Id { get; set; }
        public Int64 OrderNumber { get; set; }
        public String Message { get; set; }
        public Int64 OrderIdSS { get; set; }
        public Int64 OrderShipmentIdSS { get; set; }
    }

    [Serializable]
    public class tDetailMessageShipStationList : List<tDetailMessageShipStation>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("ORDERNUMBER", SqlDbType.BigInt),
                new SqlMetaData("MESSAGE", SqlDbType.VarChar, 200),
                new SqlMetaData("ORDERIDSS", SqlDbType.BigInt)
                );
            foreach (tDetailMessageShipStation data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt64(1, data.OrderNumber);
                ret.SetString(2, data.Message);
                ret.SetInt64(3, data.OrderIdSS);

                yield return ret;
            }
        }
    }


    #endregion

    #region Global Access

    [Serializable]
    public class tDetailGlobalAccess
    {
	   public Int32 Id { get; set; }
	   public Int64 OrderNumber { get; set; }
	   public DateTime GlobalAccessDate { get; set; }
    }

    [Serializable]
    public class tDetailGlobalAccessList : List<tDetailGlobalAccess>, IEnumerable<SqlDataRecord>
    {
	   IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
	   {

		  SqlDataRecord ret = new SqlDataRecord(
			 new SqlMetaData("Id", SqlDbType.Int),
			 new SqlMetaData("OrderNumber", SqlDbType.BigInt),
			 new SqlMetaData("GlobalAccessDate", SqlDbType.DateTime)

			 );
		  foreach (tDetailGlobalAccess data in this)
		  {
			 ret.SetInt32(0, data.Id);
			 ret.SetInt64(1, data.OrderNumber);
			 ret.SetDateTime(2, data.GlobalAccessDate);

			 yield return ret;
		  }
	   }
    }

    [Serializable]
    public class tDetailMessageGlobalAccess
    {
	   public Int32 Id { get; set; }
	   public Int64 OrderNumber { get; set; }
	   public String Message { get; set; }
    }

    [Serializable]
    public class tDetailMessageGlobalAccessList : List<tDetailMessageGlobalAccess>, IEnumerable<SqlDataRecord>
    {
	   IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
	   {
		  SqlDataRecord ret = new SqlDataRecord(
			 new SqlMetaData("Id", SqlDbType.Int),
			 new SqlMetaData("OrderNumber", SqlDbType.BigInt),
			 new SqlMetaData("Message", SqlDbType.VarChar, 200)
			 );
		  foreach (tDetailMessageGlobalAccess data in this)
		  {
			 ret.SetInt32(0, data.Id);
			 ret.SetInt64(1, data.OrderNumber);
			 ret.SetString(2, data.Message);

			 yield return ret;
		  }
	   }
    }

    #endregion Global Access

    [Serializable]
    public class tBasePromoCodeSettings
    {
        public Int32 Id { get; set; }
        public Int32 PromoCodeId { get; set; }
        public Int64 TableId { get; set; }
        public Int32 Table { get; set; }
        public Int16 Status { get; set; }
        public Int16 Action { get; set; }

    }

    [Serializable]
    public class tBasePromoCodeSettingsList : List<tBasePromoCodeSettings>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("Id", SqlDbType.Int),
                new SqlMetaData("PromoCodeId", SqlDbType.Int),
                new SqlMetaData("TableId", SqlDbType.BigInt),
                new SqlMetaData("Table", SqlDbType.Int),
                new SqlMetaData("Status", SqlDbType.SmallInt),
                new SqlMetaData("Action", SqlDbType.SmallInt)
                );
            foreach (tBasePromoCodeSettings data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.PromoCodeId);
                ret.SetInt64(2, data.TableId);
                ret.SetInt32(3, data.Table);
                ret.SetInt16(4, data.Status);
                ret.SetInt16(5, data.Action);
                yield return ret;
            }
        }
    }


    [Serializable]
    public class tBaseCommissionTax
    {
        public Int32 Id { get; set; }
        public Int32 MarketId { get; set; }
        public Decimal LowerLimit { get; set; }
        public Decimal TopLimit { get; set; }
        public Decimal FixedFee { get; set; }
        public Decimal PercentageLowerLimit { get; set; }
        public Byte Status { get; set; }
        public Int16 Action { get; set; }
    }

    [Serializable]
    public class tBaseCommissionTaxList : List<tBaseCommissionTax>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("Id", SqlDbType.Int),
                new SqlMetaData("MarketId", SqlDbType.Int),
                new SqlMetaData("LowerLimit", SqlDbType.Decimal, 18, 6),
                new SqlMetaData("TopLimit", SqlDbType.Decimal, 18, 6),
                new SqlMetaData("FixedFee", SqlDbType.Decimal, 18, 6),
                new SqlMetaData("PercentageLowerLimit", SqlDbType.Decimal, 18, 6),
                new SqlMetaData("Status", SqlDbType.TinyInt),
                new SqlMetaData("Action", SqlDbType.SmallInt)
                );
            foreach (tBaseCommissionTax data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.MarketId);
                ret.SetDecimal(2, data.LowerLimit);
                ret.SetDecimal(3, data.TopLimit);
                ret.SetDecimal(4, data.FixedFee);
                ret.SetDecimal(5, data.PercentageLowerLimit);
                ret.SetByte(6, data.Status);
                ret.SetInt16(7, data.Action);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class TBaseResource
    {
        public Int32 Id { get; set; }
        public String FileName { get; set; } = String.Empty;
        public String Description { get; set; } = String.Empty;
        public String FileExtension { get; set; } = String.Empty;
        public String FilePublicName { get; set; } = String.Empty;
        public Int32 AplicationId { get; set; }
        public Int32 DistributorId { get; set; }
        public String NameResource { get; set; } = String.Empty;
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Int32 UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public Int16 Status { get; set; }
        public String DocType { get; set; } = String.Empty;
        public Int32 LanguageId { get; set; }
        public String Url { get; set; } = String.Empty;
        public Int16 IsUpload { get; set; }
        public Int32 ResourceCategoryId { get; set; }
        public Int32 SystemContactId { get; set; }
        public String Name { get; set; } = String.Empty;
        public Int32 InternalMessagesId { get; set; }
    }

    [Serializable]
    public class TBaseResourceList : List<TBaseResource>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ID", SqlDbType.Int),
                new SqlMetaData("FileName", SqlDbType.VarChar, 150),
                new SqlMetaData("Description", SqlDbType.NVarChar, -1),
                new SqlMetaData("FileExtension", SqlDbType.VarChar, 10),
                new SqlMetaData("FilePublicName", SqlDbType.VarChar, 100),
                new SqlMetaData("AplicationID", SqlDbType.Int),
                new SqlMetaData("DistributorID", SqlDbType.Int),
                new SqlMetaData("NameResource", SqlDbType.VarChar, 500),
                new SqlMetaData("CreatedBy", SqlDbType.Int),
                new SqlMetaData("CreatedDate", SqlDbType.DateTime),
                new SqlMetaData("UpdatedBy", SqlDbType.Int),
                new SqlMetaData("UpdatedDate", SqlDbType.DateTime),
                new SqlMetaData("Status", SqlDbType.SmallInt),
                new SqlMetaData("DocType", SqlDbType.VarChar, 150),
                new SqlMetaData("LanguageId", SqlDbType.Int),
                new SqlMetaData("URL", SqlDbType.NVarChar, 250),
                new SqlMetaData("IsUpload", SqlDbType.SmallInt),
                new SqlMetaData("ResourceCategoryID", SqlDbType.Int),
                new SqlMetaData("SYSTEMCONTACID", SqlDbType.Int),
                new SqlMetaData("Name", SqlDbType.NVarChar, 500),
                new SqlMetaData("InternalMessagesID", SqlDbType.Int)
            );
            foreach (TBaseResource data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.FileName);
                ret.SetString(2, data.Description);
                ret.SetString(3, data.FileExtension);
                ret.SetString(4, data.FilePublicName);
                ret.SetInt32(5, data.AplicationId);
                ret.SetInt32(6, data.DistributorId);
                ret.SetString(7, data.NameResource);
                ret.SetInt32(8, data.CreatedBy);
                ret.SetDateTime(9, data.CreatedDate);
                ret.SetInt32(10, data.UpdatedBy);
                ret.SetDateTime(11, data.UpdatedDate);
                ret.SetInt16(12, data.Status);
                ret.SetString(13, data.DocType);
                ret.SetInt32(14, data.LanguageId);
                ret.SetString(15, data.Url);
                ret.SetInt16(16, data.IsUpload);
                ret.SetInt32(17, data.ResourceCategoryId);
                ret.SetInt32(18, data.SystemContactId);
                ret.SetString(19, data.Name);
                ret.SetInt32(20, data.InternalMessagesId);
                yield return ret;
            }
        }
    }


    [Serializable]
    public class tBaseDiscount
    {
        public Int32 DiscountId { get; set; }
        public Int32 MarketId { get; set; }
        public Decimal DiscountLowerLimit { get; set; }
        public Decimal DiscountTopLimit { get; set; }
        public Decimal DiscountPercentage { get; set; }
    }

    [Serializable]
    public class tBaseDiscountList : List<tBaseDiscount>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("Id", SqlDbType.Int),
                new SqlMetaData("MarketId", SqlDbType.Int),
                new SqlMetaData("DiscountLowerLimit", SqlDbType.Decimal, 18, 6),
                new SqlMetaData("DiscountTopLimit", SqlDbType.Decimal, 18, 6),
                new SqlMetaData("DiscountPercentage", SqlDbType.Decimal, 18, 6)
                );
            foreach (tBaseDiscount data in this)
            {
                ret.SetInt32(0, data.DiscountId);
                ret.SetInt32(1, data.MarketId);
                ret.SetDecimal(2, data.DiscountLowerLimit);
                ret.SetDecimal(3, data.DiscountTopLimit);
                ret.SetDecimal(4, data.DiscountPercentage);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tGovermentID
    {
        public Int32 Id { get; set; }
        public String Value { get; set; }
    }

    [Serializable]
    public class tGovermentIDList : List<tGovermentID>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
               new SqlMetaData("Id", SqlDbType.Int),
               new SqlMetaData("Value", SqlDbType.NVarChar, 500)
               );
            foreach (tGovermentID data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetString(1, data.Value);

                yield return ret;
            }
        }
    }


    [Serializable]
    public class TrackingDetail : BaseEntity
    {
        public Int64 OrderId { get; set; }
        public String TrackingNumber { get; set; }
        public String FileName { get; set; }
    }

    [Serializable]
    public class TrackingDetailList : List<TrackingDetail>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("OrderId", SqlDbType.BigInt),
                new SqlMetaData("TrackingNumber", SqlDbType.NVarChar, SqlMetaData.Max),
                new SqlMetaData("FileName", SqlDbType.NVarChar, SqlMetaData.Max),
                new SqlMetaData("CreatedBy", SqlDbType.Int)
                );
            foreach (TrackingDetail data in this)
            {
                ret.SetInt64(0, data.OrderId);
                ret.SetString(1, data.TrackingNumber);
                ret.SetString(2, data.FileName);
                ret.SetInt32(3, data.Createdby);
                yield return ret;
            }
        }
    }


    [Serializable]
    public class tBaseLegacyNumber
    {
        public Int64 LegacyNumber { get; set; }

    }

    [Serializable]
    public class tBaseLegacyNumberList : List<tBaseLegacyNumber>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("LegacyNumber", SqlDbType.BigInt)

                );
            foreach (tBaseLegacyNumber data in this)
            {
                ret.SetInt64(0, data.LegacyNumber);
                yield return ret;
            }
        }
    }


    [Serializable]
    public class WareHouseProduct
    {
        public Int32 FOLIOID { get; set; }
        public Int32 PRODUCTID { get; set; }
        public String PRODUCTNAME { get; set; }
        public String SKUID { get; set; }
        public Int32 QUANTITY { get; set; }
        public Int32 QUANTITYRECIVED { get; set; }
        public String BATCHID { get; set; }
        public Byte STATUS { get; set; }
        public Int32 CREATEDBY { get; set; }
        public Int32 UPDATEDBY { get; set; }
        

    }

    public class WareHouseProductList : List<WareHouseProduct>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
            new SqlMetaData("FOLIOID", SqlDbType.Int),
            new SqlMetaData("PRODUCTID", SqlDbType.Int),
            new SqlMetaData("PRODUCTNAME", SqlDbType.VarChar,200),
            new SqlMetaData("SKUID", SqlDbType.VarChar, 50),
            new SqlMetaData("QUANTITY", SqlDbType.Int),
             new SqlMetaData("QUANTITYRECIVED", SqlDbType.Int),
            new SqlMetaData("BATCHID", SqlDbType.VarChar, 200),
            new SqlMetaData("STATUS", SqlDbType.TinyInt),
            new SqlMetaData("CREATEDBY", SqlDbType.Int),
            new SqlMetaData("UPDATEDBY", SqlDbType.Int)
           
            );
            foreach (WareHouseProduct data in this)
            {
                ret.SetInt32(0, data.FOLIOID);
                ret.SetInt32(1, data.PRODUCTID);
                ret.SetString(2, data.PRODUCTNAME);
                ret.SetString(3, data.SKUID);
                ret.SetInt32(4, data.QUANTITY);
                ret.SetInt32(5, data.QUANTITYRECIVED);
                ret.SetString(6, data.BATCHID);
                ret.SetByte(7, data.STATUS);
                ret.SetInt32(8, data.CREATEDBY);
                ret.SetInt32(9, data.UPDATEDBY);
                yield return ret;
            }
        }
    }
    [Serializable]
    public class WareHouseProductStock
    {
        public Int32 WAREHOUSEID { get; set; }
        public Int32 PRODUCTID { get; set; }
        public Int32 MOVEMENTTYPEID { get; set; }
        public Int32 QUANTITY { get; set; }
        public Byte STATUS { get; set; }
        public Int32 CREATEDBY { get; set; }
        public Int32 UPDATEDBY { get; set; }
        public DateTime FECHAEXPIRATION { get; set; }
        public String BATCH { get; set; }
    }

    [Serializable]
    public class WareHouseProductStockList : List<WareHouseProductStock>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("WAREHOUSEID", SqlDbType.Int),
                new SqlMetaData("PRODUCTID", SqlDbType.Int),
                new SqlMetaData("MOVEMENTTYPEID", SqlDbType.Int),
                new SqlMetaData("QUANTITY", SqlDbType.Int),
                new SqlMetaData("STATUS", SqlDbType.TinyInt),
                new SqlMetaData("CREATEDBY", SqlDbType.Int),
                new SqlMetaData("UPDATEDBY", SqlDbType.Int),
                new SqlMetaData("FECHAEXPIRATION", SqlDbType.DateTime),
                new SqlMetaData("BATCH", SqlDbType.NVarChar, 200)
                );
            foreach (WareHouseProductStock data in this)
            {
                ret.SetInt32(0, data.WAREHOUSEID);
                ret.SetInt32(1, data.PRODUCTID);
                ret.SetInt32(2, data.MOVEMENTTYPEID);
                ret.SetInt32(3, data.QUANTITY);
                ret.SetByte(4, data.STATUS);
                ret.SetInt32(5, data.CREATEDBY);
                ret.SetInt32(6, data.UPDATEDBY);
                ret.SetDateTime(7, data.FECHAEXPIRATION);
                ret.SetString(8, data.BATCH);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class BaseWarehouseFolioDetails
    {
        public Int32 FolioId { get; set; }
        public Int32 WarehouseId { get; set; }
        public Int32 MarketId { get; set; }
        public Byte WarehouseFolioDetailRequestType { get; set; }
        public Byte Status { get; set; }
        public Int32 CreatedBy { get; set; }
        public Int32 UpdatedBy { get; set; }
    }

    [Serializable]
    public class BaseWarehouseFolioDetailsList : List<BaseWarehouseFolioDetails>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("FolioId", SqlDbType.Int),
                new SqlMetaData("WarehouseId", SqlDbType.Int),
                new SqlMetaData("MarketId", SqlDbType.Int),
                new SqlMetaData("WarehouseFolioDetailRequestType", SqlDbType.TinyInt),
                new SqlMetaData("Status", SqlDbType.TinyInt),
                new SqlMetaData("CreatedBy", SqlDbType.Int),
                new SqlMetaData("UpdatedBy", SqlDbType.Int)
                );
            foreach (BaseWarehouseFolioDetails data in this)
            {
                ret.SetInt32(0, data.FolioId);
                ret.SetInt32(1, data.WarehouseId);
                ret.SetInt32(2, data.MarketId);
                ret.SetByte(3, data.WarehouseFolioDetailRequestType);
                ret.SetByte(4, data.Status);
                ret.SetInt32(5, data.CreatedBy);
                ret.SetInt32(6, data.UpdatedBy);
                yield return ret;
            }
        }
    }



    [Serializable]
    public class TypeCashierProvides
    {
        public Int32 WarehouseId { get; set; }
        public Int32 MerchantDetailId { get; set; }
        public Decimal Amount { get; set; }       

    }

    public class ListTypeCashierProvider : List<TypeCashierProvides>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("WareHouseId", SqlDbType.Int),
                new SqlMetaData("MerchantDetailId", SqlDbType.Int),
                new SqlMetaData("Amount", SqlDbType.Decimal,15,4)                
            );
            foreach (TypeCashierProvides data in this)
            {
                ret.SetInt32(0, data.WarehouseId);
                ret.SetInt32(1, data.MerchantDetailId);
                ret.SetDecimal(2, data.Amount);                
                yield return ret;
            }
        }
    }


    [Serializable]
    public class tBaseDetailOrder
    {
        public Int32 ProductId { get; set; }
        public Decimal Price { get; set; }
        public Int32 Quantity { get; set; }
        public Int32 CreatedBy { get; set; }
        public Int32 UpdatedBy { get; set; }
        public Byte Status { get; set; }
    }

    [Serializable]
    public class tBaseDetailOrderList : List<tBaseDetailOrder>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("ProductId", SqlDbType.Int),
                new SqlMetaData("Price", SqlDbType.Decimal),
                new SqlMetaData("Quantity", SqlDbType.Int),
                new SqlMetaData("CreatedBy", SqlDbType.Int),
                new SqlMetaData("UpdatedBy", SqlDbType.Int),
                new SqlMetaData("Status", SqlDbType.TinyInt)
                );
            foreach (tBaseDetailOrder data in this)
            {
                ret.SetInt32(0, data.ProductId);
                ret.SetDecimal(1, data.Price);
                ret.SetInt32(2, data.Quantity);
                ret.SetInt32(3, data.CreatedBy);
                ret.SetInt32(4, data.UpdatedBy);
                ret.SetByte(5, data.Status);
                yield return ret;
            }
        }
    }



}
