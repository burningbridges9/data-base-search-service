using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
namespace SQAAAAAAAAAAAA
{
    internal class PersonRepository
    {
        public PersonRepository()
        {
        }

        /// <summary>
        /// FindBySurnameAndName and show results in first grid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal List<Person> FindBySurnameAndName(string value)
        {
            List<Person> persons = new List<Person>();

            SeparatorDictionary separatorDictionary = new SeparatorDictionary();

            if (value.Contains(','))
            {
                Separator sp = separatorDictionary.GetSeparator(',');
                string[] valArr = sp.Separate(value);
                string nameArr = valArr[1];
                string surnameArr = valArr[0];

                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; // @"Server = RFTALIPOV\MSSQL2016; 
                                                                                                                                //Initial Catalog = AdventureWorks;" + "Integrated Security = SSPI; Pooling = False";
                    connection.Open();

                    string sqlExpression = "SELECT FirstName, LastName " +
                        "FROM [Person].[Person] where LastName Like @surnameArr and FirstName Like @nameArr order by FirstName , LastName";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@surnameArr", "%" + surnameArr + "%");
                    command.Parameters.AddWithValue("@nameArr", "%" + nameArr + "%");
                    SqlDataReader reader = command.ExecuteReader(); 

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            object name = reader.GetValue(0);
                            object lastName = reader.GetValue(1);

                            persons.Add(new Person { Name = name.ToString(), Surname = lastName.ToString() }); //add founded person

                        }
                    }
                    reader.Close();
                    return persons;
                }
            }
            if (value.Contains(" "))
            {
                Separator sp = separatorDictionary.GetSeparator(' ');
                string[] valArr = sp.Separate(value);
                string nameArr = valArr[1];
                string surnameArr = valArr[0];

                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = connection.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; //@"Server = RFTALIPOV\MSSQL2016; 
                                                                                                                                                              //Initial Catalog = AdventureWorks;" + "Integrated Security = SSPI; Pooling = False";
                    connection.Open();

                    string sqlExpression = "SELECT FirstName, LastName " +
                        "FROM [Person].[Person] where LastName Like @surnameArr and FirstName Like @nameArr order by FirstName , LastName";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@surnameArr", "%" + surnameArr + "%");
                    command.Parameters.AddWithValue("@nameArr", "%" + nameArr + "%");

                    
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            object name = reader.GetValue(0);
                            object lastName = reader.GetValue(1);

                            persons.Add(new Person { Name = name.ToString(), Surname = lastName.ToString() }); //add founded person

                        }
                    }
                    reader.Close();
                    return persons;
                }
            }

            return persons;
        }
        internal List<Person> FindBySurname(string value)
        {
            //throw new NotImplementedException(); //SQL
            List<Person> persons = new List<Person>();

            SeparatorDictionary separatorDictionary = new SeparatorDictionary();
            
            if (value.Contains(','))
            {
                Separator sp = separatorDictionary.GetSeparator(',');
                string[] valArr = sp.Separate(value);
                string nameArr = valArr[1];
                string surnameArr = valArr[0];

                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; // @"Server = RFTALIPOV\MSSQL2016; 
                                                                                                                                //Initial Catalog = AdventureWorks;" + "Integrated Security = SSPI; Pooling = False";
                    connection.Open();

                    string sqlExpression = "SELECT FirstName, LastName " +
                        "FROM [Person].[Person] where LastName Like @surnameArr  order by FirstName , LastName";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@surnameArr", "%" + surnameArr + "%");
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            object name = reader.GetValue(0);
                            object lastName = reader.GetValue(1);

                            persons.Add(new Person { Name = name.ToString(), Surname = lastName.ToString() }); //add founded person
                            
                        }
                    }
                    reader.Close();
                    return persons;
                }
            }
            if (value.Contains(" "))
            {
                Separator sp = separatorDictionary.GetSeparator(' ');
                string[] valArr = sp.Separate(value);
                string nameArr = valArr[1];
                string surnameArr = valArr[0];

                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = connection.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; //@"Server = RFTALIPOV\MSSQL2016; 
                //Initial Catalog = AdventureWorks;" + "Integrated Security = SSPI; Pooling = False";
                    connection.Open();

                    string sqlExpression = "SELECT FirstName, LastName " +
                        "FROM [Person].[Person] where LastName Like @surnameArr order by FirstName , LastName";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@surnameArr", "%" + surnameArr + "%");
                    
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            object name = reader.GetValue(0);
                            object lastName = reader.GetValue(1);

                            persons.Add(new Person { Name = name.ToString(), Surname = lastName.ToString() }); //add founded person

                        }
                    }
                    reader.Close();
                    return persons;
                }
            }
            
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connection.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; //@"Server = RFTALIPOV\MSSQL2016; 
                //Initial Catalog = AdventureWorks;" + "Integrated Security = SSPI; Pooling = False";
                connection.Open();

                string sqlExpression = "SELECT FirstName, LastName " +
                    "FROM [Person].[Person] where LastName Like @value order by FirstName , LastName";
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                command.Parameters.AddWithValue("@value", "%" + value + "%");
                
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object name = reader.GetValue(0);
                        object lastName = reader.GetValue(1);

                        persons.Add(new Person { Name = name.ToString(), Surname = lastName.ToString() }); //add founded person

                    }
                }
                reader.Close();
                return persons;
            }
        }

        internal List<Person> FindByName(string value)
        {
            List<Person> persons = new List<Person>();

            SeparatorDictionary separatorDictionary = new SeparatorDictionary();

            if (value.Contains(','))
            {
                Separator sp = separatorDictionary.GetSeparator(',');
                string[] valArr = sp.Separate(value);
                string nameArr = valArr[1];
                string surnameArr = valArr[0];

                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = connection.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; //@"Server = RFTALIPOV\MSSQL2016; 
                                                                                                                                                              //Initial Catalog = AdventureWorks;" + "Integrated Security = SSPI; Pooling = False";
                    connection.Open();

                    string sqlExpression = "SELECT FirstName, LastName " +
                        "FROM [Person].[Person] where FirstName Like @nameArr order by FirstName , LastName";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@nameArr", "%" + nameArr + "%");
                    
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            object name = reader.GetValue(0);
                            object lastName = reader.GetValue(1);

                            persons.Add(new Person { Name = name.ToString(), Surname = lastName.ToString() }); //add founded person

                        }
                    }
                    reader.Close();
                    return persons;
                }
            }
            if (value.Contains(" "))
            {
                Separator sp = separatorDictionary.GetSeparator(' ');
                string[] valArr = sp.Separate(value);
                string nameArr = valArr[1];
                string surnameArr = valArr[0];

                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = connection.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; //@"Server = RFTALIPOV\MSSQL2016; 
                                                                                                                                                              //Initial Catalog = AdventureWorks;" + "Integrated Security = SSPI; Pooling = False";
                    connection.Open();

                    string sqlExpression = "SELECT FirstName, LastName " +
                        "FROM [Person].[Person] where FirstName Like @nameArr order by FirstName , LastName";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@nameArr", "%" + nameArr + "%");
                    
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            object name = reader.GetValue(0);
                            object lastName = reader.GetValue(1);

                            persons.Add(new Person { Name = name.ToString(), Surname = lastName.ToString() }); //add founded person

                        }
                    }
                    reader.Close();
                    return persons;
                }
            }

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connection.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; //@"Server = RFTALIPOV\MSSQL2016; 
                //Initial Catalog = AdventureWorks;" + "Integrated Security = SSPI; Pooling = False";
                connection.Open();

                string sqlExpression = "SELECT FirstName, LastName " +
                    "FROM [Person].[Person] where FirstName Like @value order by FirstName , LastName";
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                command.Parameters.AddWithValue("@value", "%" + value + "%");
                
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object name = reader.GetValue(0);
                        object lastName = reader.GetValue(1);

                        persons.Add(new Person { Name = name.ToString(), Surname = lastName.ToString() }); //add founded person

                    }
                }
                reader.Close();
                return persons;
            }
        }
        
    }
}