using System;
using System.Collections.Generic;
using xAPI.Dao.Customers;
using xAPI.Entity.Customers;
using xAPI.Entity.Report;
using xAPI.Library.Base;

namespace xAPI.BL.Customers
{
    public class CustomersBL
    {
        #region Singleton
        private static CustomersBL instance = null;
        public static CustomersBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomersBL();
                return instance;
            }
        }
        #endregion


        public List<Customer> ListarCliente(ref BaseEntity objBase, String fechaInicio, String fechaFin)
        {
            objBase = new BaseEntity();
            List<Customer> lstClientes = null;
            try
            {
                lstClientes = CustomersDAO.Instance.ListarCliente(ref objBase, fechaInicio, fechaFin);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstClientes;
        }
        public List<CustomerExport> ListarClienteExport(ref BaseEntity objBase, String fechaInicio, String fechaFin)
        {
            objBase = new BaseEntity();
            List<CustomerExport> lstClientes = null;
            try
            {
                lstClientes = CustomersDAO.Instance.ListarClienteExport(ref objBase, fechaInicio, fechaFin);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstClientes;
        }
    }
}
