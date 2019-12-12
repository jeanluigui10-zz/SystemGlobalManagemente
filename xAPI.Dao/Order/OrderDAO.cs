using System;
using System.Data;
using System.Data.SqlClient;
using xAPI.Entity;
using xAPI.Entity.Order;
using xAPI.Library.Base;
using xAPI.Library.Connection;

namespace xAPI.Dao.Order
{
    public class OrderDAO
    {
        #region Singleton
        private static OrderDAO instance = null;
        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new OrderDAO();
                return instance;
            }
        }
        #endregion

        public Boolean Insertar_Pedido(ref BaseEntity objBase, ref OrderHeader objOrder, tBaseDetailOrderList objDetail)
        {
            SqlCommand cmd = null;
            Boolean success;
            try
            {
                cmd = new SqlCommand("Order_Save_Sp", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parmIdPedidoOut = cmd.Parameters.Add("@OrderId", SqlDbType.Int);
                parmIdPedidoOut.Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@CustomerId", objOrder.Customer.CustomerId);
                cmd.Parameters.AddWithValue("@Total", objOrder.Ordertotal);
                cmd.Parameters.AddWithValue("@IgvTotal", objOrder.IGV);
                cmd.Parameters.AddWithValue("@SubTotal", objOrder.SubTotal);
                cmd.Parameters.AddWithValue("@IsCotization", objOrder.IsCotization);
                cmd.Parameters.AddWithValue("@Description", objOrder.Description);
                cmd.Parameters.AddWithValue("@Status", objOrder.Status);
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@TY_OrderDetail", Value = objDetail, SqlDbType = SqlDbType.Structured, TypeName = "TY_OrdersDetail" });
                cmd.ExecuteReader();
                success = true;
                if (!cmd.Parameters["@OrderId"].Value.ToString().Equals(string.Empty))
                    objOrder.OrderId = Convert.ToInt32(cmd.Parameters["@OrderId"].Value);

            }
            catch (Exception ex)
            {
                success = false;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "A ocurrido un error al guardar la Orden."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }
    }
}
