using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projeto_Analise_Dados
{

    class Program
    {
           static List<Customers> Listcustomers = new List<Customers>();
      
           static List<Employees> ListEmployees = new List<Employees>();

          static List<Order_Details> ListOrderDetails = new List<Order_Details>();
     
            static List<Orders> ListOrders = new List<Orders>();
        
             static List<Inventory> ListInventory = new List<Inventory>();
        static List<Products> ListProducts = new List<Products>();
            static List<Purchase_order_details> ListPurchaseOrderDetails = new List<Purchase_order_details>();
            static List<Purchase_Orders> ListPurchaseOrders = new List<Purchase_Orders>();
            static List<Shippers> ListShippers = new List<Shippers>();
            static List<Suppliers> ListSuppliers = new List<Suppliers>();
            static List<Fatura> ListFatura = new List<Fatura>();
        public static string connectionstring = "server =localhost;user id = root; Password=1234; persistsecurityinfo=True;database=northwind";
        public static string connectionstring2 = "server =localhost;user id = root; Password=1234; persistsecurityinfo=True;database=dw_northwind";
        public static void Main(string[] args)
        {
            Thread printer = new Thread(new ThreadStart(ChamarMetodos));
            printer.Start();

        }
        static void ChamarMetodos()
        {
            while (true)
            {
                ReadCustomers();
                ReadPurchaseOrders();
                ReadPurchaseOrdersDetails();
                ReadOrderDetails();
                ReadEmployees();//falta adicionar o first_name e last_name nas tabelas e descomentar o codigo daqui
                ReadFaturas();
                ReadFornecedores();//falta adicionar a city e country nas tabelas e descomentar o codigo daqui
                ReadInventory();
                ReadOrders();
                ReadProducts();
                ReadRemetende();//nao ha job title?
                WriteCustomers();
                WritePurchaseOrders();
                WritePurchaseOrdersDetails();
                WriteOrdersDetails();
                WriteEmployees();
                WriteFaturas();
                WriteFornecedores();
                WriteInventory();
                WriteOrders();
                WriteProducts();
                WriteRemetente();
                Thread.Sleep(1000 * 60* 5); //executa o codigo de 5 em 5 minutos

            }
            
        }

        public static void ReadCustomers()
        {
            string sql = " SELECT * FROM Cliente  ";
            MySqlConnection con = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            Console.WriteLine("-----Leitura dos Clientes---------\n");
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Customers customers = new Customers();
                    
                    customers.Id_Cliente = (int)dr["idcliente"];
                    customers.First_name = (string)dr["first_name"];
                    customers.Last_name= (string)dr["last_name"];
                    customers.Company= (string)dr["company"];
                    customers.Job_title = (string)dr["jobtitle"];
                    customers.City = (string)dr["city"];
                    customers.Country = (string)dr["country"];
                    customers.Type = (string)dr["type"];
                    customers.Create_Time = (DateTime)dr["create_time"];

                    Listcustomers.Add(customers);
                }

                Console.WriteLine("Clientes lidos com sucesso!!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        public static void ReadPurchaseOrders()
        {
            string sql = " SELECT * FROM compra_ordem  ";
            MySqlConnection con = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            Console.WriteLine("-----Leitura dos Puchase Orders---------\n");
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Purchase_Orders po = new Purchase_Orders();

                    po.Id = (int)dr["id_compra_ordem"];
                    po.Id_Empregado = (int)dr["id_empregado"];
                    po.Status = (int)dr["status"];
                    po.Id_Fornecedor= (int)dr["id_fornecedor"];
                    po.Type= (string)dr["type"];
                    po.Create_Date = (DateTime)dr["create_time"];

                    ListPurchaseOrders.Add(po);
                }

                Console.WriteLine("Purchase Orders lidos com sucesso!!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void ReadPurchaseOrdersDetails()
        {
            string sql = " SELECT * FROM compra_ordem_detalhes  ";
            MySqlConnection con = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            Console.WriteLine("-----Leitura dos Puchase Orders Details---------\n");
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Purchase_order_details po = new Purchase_order_details();

                    po.Id = (int)dr["id_compra_details"];
                    po.Product_id= (int)dr["product_id"];
                    po.Quantity = (decimal)dr["quantidade"];
                    po.Unit_cost = (decimal)dr["unit_cost"];
                    po.Purchase_order_id = (string)dr["compra_id"];
                    po.Type = (string)dr["type"];
                    po.Create_Time= (DateTime)dr["create_time"];

                    ListPurchaseOrderDetails.Add(po);
                }

                Console.WriteLine("Purchase Orders Details lidos com sucesso!!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void ReadOrderDetails()
        {
            string sql = " SELECT * FROM detalhes_ordem ";
            MySqlConnection con = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            Console.WriteLine("-----Leitura dos Order Details---------\n");
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Order_Details od = new Order_Details();

                    od.Id = (int)dr["id_ordem_detalhes"];
                    od.Product_id = (int)dr["idprodutos"];
                    od.Quantity = (decimal)dr["quantidade"];
                    od.Unit_price = (decimal)dr["unit_price"];
                    od.Type = (string)dr["type"];
                    od.Create_Date = (DateTime)dr["create_time"];

                    ListOrderDetails.Add(od);
                }

                Console.WriteLine("Order details lidos com sucesso!!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public static void ReadEmployees()
        {
            string sql = " SELECT * FROM empregados  ";
            MySqlConnection con = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            Console.WriteLine("-----Leitura dos Empregados---------\n");
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Employees e = new Employees();

                    e.Id = (int)dr["idempregados"];
                   /* e.First_name = (string)dr["first_name"];
                    e.Last_name = (string)dr["last_name"];*/
                    e.Company = (string)dr["company"];
                    e.Job_title = (string)dr["jobtitle"];
                    e.City = (string)dr["city"];
                    e.Country = (string)dr["country"];
                    e.Type = (string)dr["type"];
                    e.Create_Time = (DateTime)dr["create_time"];

                    ListEmployees.Add(e);
                }

                Console.WriteLine("Clientes lidos com sucesso!!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public static void ReadFaturas()
        {
            string sql = " SELECT * FROM faturas  ";
            MySqlConnection con = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            Console.WriteLine("-----Leitura dos faturas---------\n");
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Fatura f = new Fatura();

                    f.Id_Fatura = (int)dr["id_fatura"];
                    f.Id_Order = (int)dr["id_order"];
                    f.Type = (string)dr["type"];
                    f.Created_Time = (DateTime)dr["create_time"];

                    ListFatura.Add(f);
                }

                Console.WriteLine("faturas lidas com sucesso!!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public static void ReadFornecedores()
        {
            string sql = " SELECT * FROM fornecedores  ";
            MySqlConnection con = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            Console.WriteLine("-----Leitura dos fornecedores---------\n");
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Suppliers s = new Suppliers();

                   

                    s.Id = (int)dr["id_fornecedor"];
                    s.First_name = (string)dr["first_name"];
                    s.Last_name = (string)dr["last_name"];
                    s.Company = (string)dr["company"];
                    s.Job_title = (string)dr["jobtitle"];
                    //s.City = (string)dr["city"];
                    //s.Country = (string)dr["country"];
                    s.Type = (string)dr["type"];
                    s.Create_Time = (DateTime)dr["create_time"];

                    ListSuppliers.Add(s);

      
                }

                Console.WriteLine("fornecedores lidos com sucesso!!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public static void ReadInventory()
        {
            string sql = " SELECT * FROM inventorio  ";
            MySqlConnection con = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            Console.WriteLine("-----Leitura dos inventorios---------\n");
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Inventory i = new Inventory();



                    i.Id = (int)dr["id_inventorio"];
                    i.Product_id = (int)dr["id_produto"];
                    i.Quantity = (int)dr["quantidade"];
                    
                    i.Type = (string)dr["type"];
                    i.Create_Date = (DateTime)dr["create_time"];

                    ListInventory.Add(i);


                }

                Console.WriteLine("inventorios lidos com sucesso!!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public static void ReadOrders()
        {
            string sql = " SELECT * FROM ordem  ";
            MySqlConnection con = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            Console.WriteLine("-----Leitura dos Orders---------\n");
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Orders o = new Orders();

                    o.Id = (int)dr["id_ordem"];
                    o.Employee_id = (int)dr["id_empregado"];
                    o.Customer_id = (int)dr["id_cliente"];
                    o.Status_id = (int)dr["status_id"];
                    o.Type = (string)dr["type"];
                    o.Created_Time= (DateTime)dr["create_time"];
                    o.Order_date = (DateTime)dr["data_ordem"];
                    o.Paid_date= (DateTime)dr["data_paid"];
                    o.Shipped_date = (DateTime)dr["data_shipped"];

                    ListOrders.Add(o);
                }

                Console.WriteLine("Orders lidos com sucesso!!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public static void ReadProducts()
        {
            string sql = " SELECT * FROM produtos  ";
            MySqlConnection con = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            Console.WriteLine("-----Leitura dos Produtos---------\n");
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Products p = new Products();

                    p.Id= (int)dr["id_produto"];
                    p.Category = (string)dr["category"];
                    p.Product_name= (string)dr["nome"];
                    p.Type = (string)dr["type"];
                    p.Standard_cost = (decimal)dr["standard_cost"];
                    p.List_price = (decimal)dr["list_price"];
                    p.Create_Date = (DateTime)dr["create_time"];


                    ListProducts.Add(p);
                }

                Console.WriteLine("Produtos lidos com sucesso!!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public static void ReadRemetende()
        {
            string sql = " SELECT * FROM Remetente  ";
            MySqlConnection con = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            Console.WriteLine("-----Leitura dos Remetentes---------\n");
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Shippers s = new Shippers();

                    s.Id = (int)dr["id_remetente"];
                    s.First_name = (string)dr["first_name"];
                    s.Last_name = (string)dr["last_name"];
                    s.Company = (string)dr["company"];
                   // s.Job_title = (string)dr["jobtitle"];
                    s.City = (string)dr["city"];
                    s.Country = (string)dr["country"];
                    s.Type = (string)dr["type"];
                    s.Create_Time = (DateTime)dr["create_time"];

                    

                    ListShippers.Add(s);
                }

                Console.WriteLine("Remetentes lidos com sucesso!!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void WriteCustomers()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring2))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                try
                {
                    connection.Open();

                    foreach (Customers customers in Listcustomers)
                    {
                       
                            string date = customers.Create_Time.ToString("yyyy-MM-dd HH:mm:ss");
                        
                        cmd.CommandText = "UPDATE cliente "
                                    + "SET "
                                    + " first_name = '" + customers.First_name + "' ,"
                                    + " last_name = '" + customers.Last_name + "' ,"
                                    + " company = '" + customers.Company + "' ,"
                                    + " jobtitle = '" + customers.Job_title + "' ,"
                                     + " city = '" + customers.City + "' ,"
                                     + " country = '" + customers.Country + "' ,"
                                     + " type = '" + customers.Type + "' ,"
                                     + " create_time = '" + date +"'"
                                    + " WHERE idcliente = " + customers.Id_Cliente;

                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {
                           
                            


                            cmd.CommandText = "INSERT INTO cliente (idcliente,first_name,last_name,company,jobtitle,city,country,type,create_time)" +
                                " VALUES("
                                + customers.Id_Cliente + ","
                                + "'" + customers.First_name + "'" + ","
                                + "'" + customers.Last_name + "'" + ","
                                + "'" + customers.Company + "'" + ","
                                + "'" + customers.Job_title + "'" + ","
                                + "'" + customers.City + "'" + ","
                                 + "'" + customers.Country + "'" + ","
                                 + "'" + customers.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void WritePurchaseOrders()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring2))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                try
                {
                    connection.Open();

                    foreach (Purchase_Orders po in ListPurchaseOrders)
                    {
                        string date = po.Create_Date.ToString("yyyy-MM-dd HH:mm:ss");


                        cmd.CommandText = "UPDATE compra_ordem "
                                    + "SET "
                                    + " id_empregado = '" + po.Id_Empregado + "' ,"
                                    + " status = '" + po.Status + "' ,"
                                    + " id_fornecedor= '" + po.Id_Fornecedor + "' ,"   
                                     + " type = '" + po.Type + "' ,"
                                     + " create_time = '" + date + "'"
                                    + " WHERE id_compra_ordem = " + po.Id;

                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {




                            cmd.CommandText = "INSERT INTO compra_ordem (id_compra_ordem,id_empregado,status,id_fornecedor,type,create_time)" +
                                " VALUES("
                                + po.Id + ","
                                + "'" + po.Id_Empregado + "'" + ","
                                + "'" + po.Status + "'" + ","
                                + "'" + po.Id_Fornecedor + "'" + ","
                                + "'" + po.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void WritePurchaseOrdersDetails()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring2))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                try
                {
                    connection.Open();

                    foreach (Purchase_order_details po in ListPurchaseOrderDetails)
                    {
                        string date = po.Create_Time.ToString("yyyy-MM-dd HH:mm:ss");

                      

                        cmd.CommandText = "UPDATE compra_ordem_detalhes "
                                    + "SET "
                                    + " product_id = '" + po.Product_id + "' ,"
                                    + " quantidade= " + po.Quantity.ToString().Replace(",", ".") + " ,"
                                     + " unit_cost = " + po.Unit_cost.ToString().Replace(",", ".") + " ,"
                                     + " compra_id = '" + po.Purchase_order_id + "' ,"
                                     + " type = '" + po.Type + "' ,"
                                     + " create_time = '" + date + "'"
                                    + " WHERE id_compra_details = " + po.Id;

                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {




                            cmd.CommandText = "INSERT INTO compra_ordem_detalhes (id_compra_details,product_id,quantidade,unit_cost,compra_id,type,create_time)" +
                                " VALUES("
                                + po.Id + ","
                                + po.Product_id + ","
                                + po.Quantity.ToString().Replace(",", ".") + ","
                                + po.Unit_cost.ToString().Replace(",", ".") + ","
                                + "'" + po.Purchase_order_id + "'" + ","
                                + "'" + po.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void WriteOrdersDetails()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring2))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                try
                {
                    connection.Open();

                    foreach (Order_Details od in ListOrderDetails)
                    {
                        string date = od.Create_Date.ToString("yyyy-MM-dd HH:mm:ss");

                        cmd.CommandText = "UPDATE detalhes_ordem "
                                    + "SET "
                                    + " idprodutos = '" + od.Product_id + "' ,"
                                    + " quantidade= " + od.Quantity.ToString().Replace(",", ".") + " ,"
                                     + " unit_price = " + od.Unit_price.ToString().Replace(",", ".") + " ,"
                                     + " type = '" + od.Type + "' ,"
                                     + " create_time = '" + date + "'"
                                    + " WHERE id_ordem_detalhes = " + od.Id;

                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {
                            cmd.CommandText = "INSERT INTO detalhes_ordem (id_ordem_detalhes,idprodutos,quantidade,unit_price,type,create_time)" +
                                " VALUES("
                                + od.Id + ","
                                + od.Product_id + ","
                                + od.Quantity.ToString().Replace(",", ".") + ","
                                + od.Unit_price.ToString().Replace(",", ".") + ","
                                + "'" + od.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void WriteEmployees()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring2))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                try
                {
                    connection.Open();

                    foreach (Employees e in ListEmployees)
                    {
                        

                        string date = e.Create_Time.ToString("yyyy-MM-dd HH:mm:ss");

                        cmd.CommandText = "UPDATE empregados "
                                    + "SET "
                                   /* + " first_name = '" + e.First_name + "' ,"
                                    + " last_name = '" + e.Last_name + "' ,"*/
                                    + " company = '" + e.Company + "' ,"
                                    + " jobtitle = '" + e.Job_title + "' ,"
                                     + " city = '" + e.City + "' ,"
                                     + " country = '" + e.Country + "' ,"
                                     + " type = '" + e.Type + "' ,"
                                     + " create_time = '" + date + "'"
                                    + " WHERE idempregados = " + e.Id;

                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {



                                                                        //first_name,last_name
                            cmd.CommandText = "INSERT INTO empregados (idempregados,company,jobtitle,city,country,type,create_time)" +
                                " VALUES("
                                + e.Id + ","
                               /* + "'" + e.First_name + "'" + ","
                                + "'" + e.Last_name + "'" + ","*/
                                + "'" + e.Company + "'" + ","
                                + "'" + e.Job_title + "'" + ","
                                + "'" + e.City + "'" + ","
                                 + "'" + e.Country + "'" + ","
                                 + "'" + e.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void WriteFaturas()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring2))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                try
                {
                    connection.Open();

                    foreach (Fatura f in ListFatura)
                    {


                        string date = f.Created_Time.ToString("yyyy-MM-dd HH:mm:ss");
                         

                      
                        cmd.CommandText = "UPDATE faturas "
                                    + "SET "
                                    + " id_order = '" + f.Id_Order + "' ,"
                                     + " type = '" + f.Type + "' ,"
                                     + " create_time = '" + date + "'"
                                    + " WHERE id_fatura = " + f.Id_Fatura;

                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {

                            cmd.CommandText = "INSERT INTO faturas (id_fatura,id_order,type,create_time)" +
                                " VALUES("
                                + f.Id_Fatura + ","
                                + f.Id_Order + ","
                                 + "'" + f.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void WriteFornecedores()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring2))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                try
                {
                    connection.Open();

                    foreach (Suppliers s in ListSuppliers)
                    {

                        string date = s.Create_Time.ToString("yyyy-MM-dd HH:mm:ss");

                        cmd.CommandText = "UPDATE fornecedores "
                                    + "SET "
                                    + " first_name = '" + s.First_name + "' ,"
                                    + " last_name = '" + s.Last_name + "' ,"
                                    + " company = '" + s.Company + "' ,"
                                    + " jobtitle = '" + s.Job_title + "' ,"
                                    /* + " city = '" + s.City + "' ,"
                                     + " country = '" + s.Country + "' ,"*/
                                     + " type = '" + s.Type + "' ,"
                                     + " create_time = '" + date + "'"
                                    + " WHERE id_fornecedor = " + s.Id;

                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {


                            //city,country

                            cmd.CommandText = "INSERT INTO fornecedores (id_fornecedor,first_name,last_name,company,jobtitle,type,create_time)" +
                                " VALUES("
                                + s.Id + ","
                                + "'" + s.First_name + "'" + ","
                                + "'" + s.Last_name + "'" + ","
                                + "'" + s.Company + "'" + ","
                                + "'" + s.Job_title + "'" + ","
                               /* + "'" + s.City + "'" + ","
                                 + "'" + s.Country + "'" + ","*/
                                 + "'" + s.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void WriteInventory()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring2))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                try
                {
                    connection.Open();

                    foreach (Inventory i in ListInventory)
                    {
                        

                        string date = i.Create_Date.ToString("yyyy-MM-dd HH:mm:ss");

                     

                        cmd.CommandText = "UPDATE inventorio "
                                    + "SET "
                                    + " id_produto = '" + i.Product_id + "' ,"
                                     + " quantidade= " + i.Quantity.ToString().Replace(",", ".") + " ,"
                                     + " type = '" + i.Type + "' ,"
                                     + " create_time = '" + date + "'"
                                    + " WHERE id_inventorio = " + i.Id;

                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {

                            cmd.CommandText = "INSERT INTO inventorio (id_inventorio,id_produto,quantidade,type,create_time)" +
                                " VALUES("
                                + i.Id + ","
                                + i.Product_id + ","
                                 + i.Quantity.ToString().Replace(",", ".") + ","
                                  + "'" + i.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void WriteOrders()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring2))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                try
                {
                    connection.Open();

                    foreach (Orders o in ListOrders)
                    {

                        string created_time = o.Created_Time.ToString("yyyy-MM-dd HH:mm:ss");
                        string order_date=o.Order_date.ToString("yyyy-MM-dd HH:mm:ss");
                        string paid_date = o.Paid_date.ToString("yyyy-MM-dd HH:mm:ss");
                        string shipped_date = o.Shipped_date.ToString("yyyy-MM-dd HH:mm:ss");


                        cmd.CommandText = "UPDATE ordem "
                                    + "SET "
                                    + " id_empregado ="+ o.Employee_id + ","
                                    + " id_cliente =" + o.Customer_id + ","
                                    + " status_id = " + o.Status_id + ","
                                     + " type = '" + o.Type + "' ,"
                                     + " create_time = '" + created_time + "' ,"
                                     + " data_ordem = '" + order_date + "' ,"
                                      + " data_paid = '" + paid_date + "' ,"
                                       + " data_shipped = '" + shipped_date + "'"
                                    + " WHERE id_ordem = " + o.Id;

                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {


                            cmd.CommandText = "INSERT INTO ordem (id_ordem,id_empregado,id_cliente,status_id,type,create_time,data_ordem,data_paid,data_shipped)" +
                                " VALUES("
                                + o.Id + ","
                                + o.Employee_id + ","
                                + o.Customer_id + ","
                                 + o.Status_id + "," 
                                 + "'" + o.Type + "'" + ","
                                 + "'" + created_time + "',"
                                 + "'" + order_date + "',"
                                 + "'" + paid_date + "',"
                                 + "'" + shipped_date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void WriteProducts()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring2))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                try
                {
                    connection.Open();

                    foreach (Products p in ListProducts)
                    {

                        string created_time = p.Create_Date.ToString("yyyy-MM-dd HH:mm:ss");
                        

                        cmd.CommandText = "UPDATE produtos "
                                    + "SET "
                                     + " category = '" + p.Category + "' ,"
                                     + " nome = '" + p.Product_name + "' ,"
                                      + "standard_cost= " + p.Standard_cost.ToString().Replace(",", ".") + " ,"
                                       + "list_price= " + p.List_price.ToString().Replace(",", ".") + " ,"
                                     + " type = '" + p.Type + "' ,"
                                     + " create_time = '" + created_time + "'"
                                    + " WHERE id_produto = " + p.Id;

                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {


                            cmd.CommandText = "INSERT INTO produtos (id_produto,category,nome,standard_cost,list_price,type,create_time)" +
                                " VALUES("
                                + p.Id + ","
                                + "'" + p.Category + "',"
                                 + "'" + p.Product_name + "',"
                                 + p.Standard_cost.ToString().Replace(",", ".") + ","
                                 + p.List_price.ToString().Replace(",", ".") + ","
                                 + "'" + p.Type + "'" + ","
                                 + "'" + created_time + "'"
                                
                                + ");";

                            cmd.ExecuteNonQuery();
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void WriteRemetente()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionstring2))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                try
                {
                    connection.Open();

                    foreach (Shippers s in ListShippers)
                    {

                        string date = s.Create_Time.ToString("yyyy-MM-dd HH:mm:ss");

                        cmd.CommandText = "UPDATE remetente "
                                    + "SET "
                                    + " first_name = '" + s.First_name + "' ,"
                                    + " last_name = '" + s.Last_name + "' ,"
                                    + " company = '" + s.Company + "' ,"
                                   // + " jobtitle = '" + s.Job_title + "' ,"
                                     + " city = '" + s.City + "' ,"
                                     + " country = '" + s.Country + "' ,"
                                     + " type = '" + s.Type + "' ,"
                                     + " create_time = '" + date + "'"
                                    + " WHERE id_remetente = " + s.Id;

                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {



                            //jobtitle
                            cmd.CommandText = "INSERT INTO remetente (id_remetente,first_name,last_name,company,city,country,type,create_time)" +
                                " VALUES("
                                + s.Id + ","
                                + "'" + s.First_name + "'" + ","
                                + "'" + s.Last_name + "'" + ","
                                + "'" + s.Company + "'" + ","
                               // + "'" + customers.Job_title + "'" + ","
                                + "'" + s.City + "'" + ","
                                 + "'" + s.Country + "'" + ","
                                 + "'" + s.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        }

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }

}
