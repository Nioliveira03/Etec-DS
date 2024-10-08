MySql.Data.MySqlClient.MySqlConnection myConnection;
    string myConnectionString;
    //set the correct values for your server, user, password and database name
    myConnectionString = "server=localhost;uid=root;pwd=;database=teste";
 
    try
    {
      myConnection = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
      //open a connection
      myConnection.Open();
 
      // create a MySQL command and set the SQL statement with parameters
      MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
      myCommand.Connection = myConnection;
      myCommand.CommandText = @"SELECT * FROM cursos";
     
 
      // execute the command and read the results
      using ( var myReader = myCommand.ExecuteReader() )
      {
        while (myReader.Read())
        {
          var cod = myReader.GetInt32("cod");
          var curso = myReader.GetString("curso");
          var vagas = myReader.GetInt32("vagas");
          var periodo = myReader.GetString("periodo");
          Console.WriteLine(cod+" | "+curso+" | "+vagas+" | "+periodo    );
        }
      }
      myConnection.Close();
    }
    catch (MySql.Data.MySqlClient.MySqlException ex)
    {
      Console.WriteLine(ex.Message);
    }