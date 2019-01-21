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
                if (DateTime.Now.Hour == 23 && DateTime.Now.Minute < 5)
                {
                    DeleteAllData();
                    
                }
                else
                {
                    ReadCustomers();
                    ReadPurchaseOrders();
                    ReadPurchaseOrdersDetails();
                    ReadOrderDetails();
                    ReadEmployees();
                    ReadFaturas();
                    ReadFornecedores();
                    ReadOrders();
                    ReadProducts();
                    ReadRemetende();
                    WriteCustomers();
                    WritePurchaseOrders();
                    WritePurchaseOrdersDetails();
                    WriteOrdersDetails();
                    WriteEmployees();
                    WriteFaturas();
                    WriteFornecedores();
                    WriteOrders();
                    WriteProducts();
                    WriteRemetente();
                   
                }
                Thread.Sleep(1000 * 60 * 5); //executa o codigo de 5 em 5 minutos
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
                    od.Id_Factos = (int)dr["id_factos"];

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
                    e.First_name = (string)dr["first_name"];
                    e.Last_name = (string)dr["last_name"];
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
                    o.Payment_type = (string)dr["payment_type"];
                    o.Id_remetente = (int)dr["id_remetente"];

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
                    p.Quantity = (int)dr["quantidade"];
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
                    s.First_name = (string)dr["first_name"].ToString();
                    s.Last_name = dr["last_name"].ToString();                
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
                        
                            cmd.CommandText = "INSERT INTO detalhes_ordem (id_ordem_detalhes,id_factos,idprodutos,quantidade,unit_price,type,create_time)" +
                                " VALUES("
                                + od.Id + ","
                                 + od.Id_Factos + ","
                                + od.Product_id + ","
                                + od.Quantity.ToString().Replace(",", ".") + ","
                                + od.Unit_price.ToString().Replace(",", ".") + ","
                                + "'" + od.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        

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
                        
                                                                        
                            cmd.CommandText = "INSERT INTO empregados (idempregados,first_name,last_name,company,jobtitle,city,country,type,create_time)" +
                                " VALUES("
                                + e.Id + ","
                                + "'" + e.First_name + "'" + ","
                                + "'" + e.Last_name + "'" + ","
                                + "'" + e.Company + "'" + ","
                                + "'" + e.Job_title + "'" + ","
                                + "'" + e.City + "'" + ","
                                 + "'" + e.Country + "'" + ","
                                 + "'" + e.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        

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
                        
                            cmd.CommandText = "INSERT INTO faturas (id_fatura,id_order,type,create_time)" +
                                " VALUES("
                                + f.Id_Fatura + ","
                                + f.Id_Order + ","
                                 + "'" + f.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        

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

                        


                            cmd.CommandText = "INSERT INTO ordem (id_ordem,id_empregado,id_cliente,status_id,type," +
                            "create_time,data_ordem,data_paid,data_shipped,id_remetente,payment_type)" +
                                " VALUES("
                                + o.Id + ","
                                + o.Employee_id + ","
                                + o.Customer_id + ","
                                 + o.Status_id + "," 
                                 + "'" + o.Type + "'" + ","
                                 + "'" + created_time + "',"
                                 + "'" + order_date + "',"
                                 + "'" + paid_date + "',"
                                 + "'" + shipped_date + "' ,"
                                  + o.Id_remetente + ","
                                  + "'" + o.Payment_type + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        

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
                        


                            cmd.CommandText = "INSERT INTO produtos (id_produto,category,nome,standard_cost,quantidade,list_price,type,create_time)" +
                                " VALUES("
                                + p.Id + ","
                                + "'" + p.Category + "',"
                                 + "'" + p.Product_name + "',"
                                 + p.Standard_cost.ToString().Replace(",", ".") + ","
                                 + p.Quantity.ToString().Replace(",", ".") + ","
                                 + p.List_price.ToString().Replace(",", ".") + ","
                                 + "'" + p.Type + "'" + ","
                                 + "'" + created_time + "'"
                                
                                + ");";

                            cmd.ExecuteNonQuery();
                        

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

                            //jobtitle
                            cmd.CommandText = "INSERT INTO remetente (id_remetente,first_name,last_name,company,city,country,type,create_time)" +
                                " VALUES("
                                + s.Id + ","
                                + "'" + s.First_name + "'" + ","
                                + "'" + s.Last_name + "'" + ","
                                + "'" + s.Company + "'" + ","
                                + "'" + s.City + "'" + ","
                                 + "'" + s.Country + "'" + ","
                                 + "'" + s.Type + "'" + ","
                                 + "'" + date + "'"
                                + ");";

                            cmd.ExecuteNonQuery();
                        

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void DeleteAllData()
        {
            string sql1 = " SET SQL_SAFE_UPDATES = 0;" +
                        "   Delete FROM Cliente  ";
            string sql2 = " SET SQL_SAFE_UPDATES = 0;" +
                        "   Delete FROM compra_ordem  ";
            string sql3 = " SET SQL_SAFE_UPDATES = 0;" +
                       "   Delete FROM compra_ordem_detalhes  ";
            string sql4 = " SET SQL_SAFE_UPDATES = 0;" +
                       "   Delete FROM detalhes_ordem  ";
            string sql5 = " SET SQL_SAFE_UPDATES = 0;" +
                       "   Delete FROM empregados  ";
            string sql6 = " SET SQL_SAFE_UPDATES = 0;" +
                      "   Delete FROM faturas  ";
            string sql7 = " SET SQL_SAFE_UPDATES = 0;" +
                      "   Delete FROM fornecedores  ";
            string sql9 = " SET SQL_SAFE_UPDATES = 0;" +
                      "   Delete FROM ordem  ";
            string sql10 = " SET SQL_SAFE_UPDATES = 0;" +
                      "   Delete FROM produtos  ";
            string sql11 = " SET SQL_SAFE_UPDATES = 0;" +
                      "   Delete FROM Remetente  ";
            MySqlConnection con = new MySqlConnection(connectionstring);
            MySqlConnection con2 = new MySqlConnection(connectionstring2);
            MySqlCommand cmd1 = new MySqlCommand(sql1, con);
            MySqlCommand cmd2 = new MySqlCommand(sql2, con);
            MySqlCommand cmd3 = new MySqlCommand(sql3, con);
            MySqlCommand cmd4= new MySqlCommand(sql4, con);
            MySqlCommand cmd5 = new MySqlCommand(sql5, con);
            MySqlCommand cmd6 = new MySqlCommand(sql6, con);
            MySqlCommand cmd7 = new MySqlCommand(sql7, con);
            MySqlCommand cmd9 = new MySqlCommand(sql9, con);
            MySqlCommand cmd10 = new MySqlCommand(sql10, con);
            MySqlCommand cmd11 = new MySqlCommand(sql11, con);
            MySqlCommand cmd12 = new MySqlCommand(sql1, con2);
            MySqlCommand cmd13 = new MySqlCommand(sql2, con2);
            MySqlCommand cmd14 = new MySqlCommand(sql3, con2);
            MySqlCommand cmd15 = new MySqlCommand(sql4, con2);
            MySqlCommand cmd16 = new MySqlCommand(sql5, con2);
            MySqlCommand cmd17 = new MySqlCommand(sql6, con2);
            MySqlCommand cmd18 = new MySqlCommand(sql7, con2);
            MySqlCommand cmd20 = new MySqlCommand(sql9, con2);
            MySqlCommand cmd21 = new MySqlCommand(sql10, con2);
            MySqlCommand cmd22 = new MySqlCommand(sql11, con2);
            con.Open();
            try
            {
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();
                cmd6.ExecuteNonQuery();
                cmd7.ExecuteNonQuery();
                cmd9.ExecuteNonQuery();
                cmd10.ExecuteNonQuery();
                cmd11.ExecuteNonQuery();
                cmd12.ExecuteNonQuery();
                cmd13.ExecuteNonQuery();
                cmd14.ExecuteNonQuery();
                cmd15.ExecuteNonQuery();
                cmd16.ExecuteNonQuery();
                cmd17.ExecuteNonQuery();
                cmd18.ExecuteNonQuery();
                cmd20.ExecuteNonQuery();
                cmd21.ExecuteNonQuery();
                cmd22.ExecuteNonQuery();

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

    }

}


