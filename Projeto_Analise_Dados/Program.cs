using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projeto_Analise_Dados
{

    class Program
    {
        List<Customers> listcustomers = new List<Customers>();
        List<Employee_privileges> listcEmployeePrevileges = new List<Employee_privileges>();
        List<Employees> listEmployees = new List<Employees>();
        List<Inventory_transaction_types> listInventoryTransactionTypes = new List<Inventory_transaction_types>();
        List<Inventory_Transactions> listInventoryTransactions = new List<Inventory_Transactions>();
        List<Invoices> listInvoices = new List<Invoices>();
        List<Order_Details> listOrderDetails = new List<Order_Details>();
        List<Order_Details_Status> listOrderDetailsStatus = new List<Order_Details_Status>();
        List<Order_status> listOrderStatus = new List<Order_status>();
        List<Orders> listOrders = new List<Orders>();
        List<Orders_tax_status> listOrderTaxStatus = new List<Orders_tax_status>();
        List<Previleges> listPrevileges = new List<Previleges>();
        List<Products> listProducts = new List<Products>();
        List<Purchase_order_details> listPurchaseOrderDetails = new List<Purchase_order_details>();
        List<Purchase_Order_Status> listPurchaseOrderStatus = new List<Purchase_Order_Status>();
        List<Purchase_Orders> listPurchaseOrders = new List<Purchase_Orders>();
        List<Sales_Report> listSalesReport = new List<Sales_Report>();
        List<Shippers> listShippers = new List<Shippers>();
        List<Suppliers> listSuppliers = new List<Suppliers>();
        public static string connectionstring = "server =localhost;user id = root; persistsecurityinfo=True;database=northwind";
        void Main(string[] args)
        {
            
        }

        

    }

}
