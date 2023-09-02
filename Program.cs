using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld
{
    
    class Program
{
        static void Main(string[] args)
    {
        //Database connection
        string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=false;User Id=sa;Password=SQLConnect1;";
        IDbConnection dbConnection= new SqlConnection(connectionString);

        //Test if database is connected
        string sqlCommand = "SELECT GETDATE()";
        DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);
        // Console.WriteLine("writeNow" + rightNow.ToString());

        Computer myComputer = new Computer()
        {
            Motherboard = "Z960",
            HasWifi = true,
            HasLTE = false,
            ReleaseDate = DateTime.Now,
            Price = 20.40m,
            VideoCard = "RTX 2023"
        };
//......................... Query 1 INSERT
        string sql = @"INSERT INTO TutorialAppSchema.Computer (
            Motherboard,
            HasWifi,
            HasLTE,
            ReleaseDate,
            Price,
            VideoCard
        ) VALUES ('" + myComputer.Motherboard
            + "','" + myComputer.HasWifi
            + "','" + myComputer.HasLTE
            + "','" + myComputer.ReleaseDate
            + "','" + myComputer.Price
            + "','" + myComputer.VideoCard
            + "')";
            // Console.WriteLine(sql);
            int result = dbConnection.Execute(sql);
            // Console.WriteLine("result" + result);
        
//......................... Query 2 GET
            string sqlSelect = @"
            SELECT 
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
            FROM TutorialAppSchema.Computer";
        
        IEnumerable<Computer> computers = dbConnection.Query<Computer>(sqlSelect);

        Console.WriteLine("'Motherboard', 'HasWifi', 'HasLTE', 'ReleaseDate', 'Price', 'VideoCard'");

        foreach (Computer singleComputer in computers)
        {
            Console.WriteLine("'" 
            + myComputer.Motherboard
            + "','" + myComputer.HasWifi
            + "','" + myComputer.HasLTE
            + "','" + myComputer.ReleaseDate
            + "','" + myComputer.Price
            + "','" + myComputer.VideoCard
            +"'");
        }

        // Console.WriteLine(myComputer.Motherboard);
        // Console.WriteLine(myComputer.CPUCore);
        // Console.WriteLine(myComputer.HasWifi);
        // Console.WriteLine(myComputer.HasLTE);
        // Console.WriteLine(myComputer.ReleaseDate);
        // Console.WriteLine(myComputer.Price);
        // Console.WriteLine(myComputer.VideoCard);
    }
}
}
