using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Security;
using xAPI.Entity.Security;
using xAPI.Library.Base;
using xSystem_Maintenance.src.app_code;

namespace xSystem_Maintenance.Private.Chat
{
    public partial class RedirectChatModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucRedirectChatModule.SetUserId(BaseSession.SsUser.Id_Usuario);
        }
        [WebMethod]
        public static object RegistroOrden(String clientes, String productos, String descripcion, String cantidad, String precio, String estado)
        {
            Object objReturn = new Object();
            try
            {
           
                BaseEntity objBase = new BaseEntity();
                Byte Status = Convert.ToByte(estado);
                #region GetMarkets
                JavaScriptSerializer sr = new JavaScriptSerializer();
                List<String> lstClientesString = sr.Deserialize<List<String>>(clientes);
                List<Int32> lstClientesInt = new List<Int32>();
                if (lstClientesString.Count > 0)
                {
                    if (lstClientesString[0].Equals("multiselect-all")) { lstClientesString.RemoveAt(0); }
                    lstClientesInt = lstClientesString.Select(Int32.Parse).ToList();
                }
                else { lstClientesInt.Insert(0, 0); }

                //xss.AutoshipBackend.Entity.tBaseTaxUserMarketsList ListTaxMarkets = new xss.AutoshipBackend.Entity.tBaseTaxUserMarketsList();
                //foreach (int item in lstClientesInt)
                //{
                //    ListTaxMarkets.Add(new xss.AutoshipBackend.Entity.tBaseTaxUserMarkets
                //    {
                //        MarketId = item,
                //        Status = 1
                //    });
                //}
                #endregion

                
            }
            catch (Exception exception)
            {
            }
            return objReturn;
        }
    }
}