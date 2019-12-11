using System;
using xAPI.Dao.Order;
using xAPI.Entity;
using xAPI.Entity.Order;
using xAPI.Library.Base;

namespace xAPI.BL.Order
{
    public class OrderBL
    {
        #region Singleton
        private static OrderBL instance = null;
        public static OrderBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new OrderBL();
                return instance;
            }
        }
        #endregion

        public Boolean Insertar_Pedido(ref BaseEntity objBase, ref OrderHeader objOrder, tBaseDetailOrderList objDetail) 
        {
            Boolean success;
            try
            {
                objBase = new BaseEntity();
                success = OrderDAO.Instance.Insertar_Pedido(ref objBase, ref objOrder, objDetail);
            }
            catch (Exception ex)
            {
                success = false;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return success;
        }
    }
}
