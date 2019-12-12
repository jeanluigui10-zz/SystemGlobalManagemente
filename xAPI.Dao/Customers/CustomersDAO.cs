using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity.Order;
using xAPI.Entity.Report;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;
using xAPI.Entity.Customers;
namespace xAPI.Dao.Customers
{
    public class CustomersDAO
    {
     
        private static CustomersDAO instance = null;
        public static CustomersDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomersDAO();
                return instance;
            }
        }

        public List<Customer> ListarCliente(ref BaseEntity objBase, String fechaInicio, String fechaFin)
        {
            SqlCommand ObjCmd = null;
            List<Customer> lstClientes = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("[Customer_GetAll_Sp]", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                ObjCmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                lstClientes = new List<Customer>();
                dr = ObjCmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count++;
                    Customer objCliente = new Customer();
                    objCliente.CustomerId = dr.GetColumnValue<Int32>("CustomerId");
                    objCliente.FirstName = dr.GetColumnValue<String>("FirstName");
                    objCliente.DocumentTypeName = dr.GetColumnValue<String>("DocumentType");
                    objCliente.NumberDocument = dr.GetColumnValue<String>("NumberDocument");
                    objCliente.CellPhone = dr.GetColumnValue<String>("CellPhone");
                    objCliente.Email = dr.GetColumnValue<String>("Email");
                    objCliente.CreatedDate = dr.GetColumnValue<DateTime>("CreatedDate").ToString();                    
                    objCliente.IsCheckbox = "1";
                    objCliente.Index = count.ToString();
                    objCliente.Status = dr.GetColumnValue<Int32>("Status");

                    lstClientes.Add(objCliente);
                }
            }
            catch (Exception ex)
            {
                lstClientes = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Lista de clientes no encontradas."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return lstClientes;
        }
        public List<CustomerExport> ListarClienteExport(ref BaseEntity objBase, String fechaInicio, String fechaFin)
        {
            SqlCommand ObjCmd = null;
            List<CustomerExport> lstClientes = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("[Customer_GetAll_Sp]", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                ObjCmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                lstClientes = new List<CustomerExport>();
                dr = ObjCmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count++;
                    CustomerExport objCliente = new CustomerExport();
                    objCliente.CustomerId = dr.GetColumnValue<Int32>("CustomerId").ToString();
                    objCliente.FirstName = dr.GetColumnValue<String>("FirstName");
                    objCliente.DocumentTypeName = dr.GetColumnValue<String>("DocumentType");
                    objCliente.NumberDocument = dr.GetColumnValue<String>("NumberDocument");
                    objCliente.CellPhone = dr.GetColumnValue<String>("CellPhone");
                    objCliente.Email = dr.GetColumnValue<String>("Email");
                    objCliente.CreatedDate = dr.GetColumnValue<DateTime>("CreatedDate").ToString();
                    objCliente.StatusDes = (dr.GetColumnValue<String>("Status") == "1") ? "PAGADO":"PENDIENTE";

                    lstClientes.Add(objCliente);
                }
            }
            catch (Exception ex)
            {
                lstClientes = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Lista de clientes no encontradas."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return lstClientes;
        }

    }
}
