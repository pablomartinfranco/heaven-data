using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using Xunit;

namespace Heaven.Data.Tests
{
    public class SqlDapperTests : IClassFixture<TestsBaseFixture>
    {
        class NombreClave
        {
            public string Nombre { get; set; }
            public string CLave { get; set; }
        }

        [Fact]
        public async void DataTest()
        {

            var connectionString = "Server=heavencloud.mine.nu\\MSSQLHEAVEN,1433;Database=demoretail;User Id=HeavenAdmin;MultipleActiveResultSets=True;Password=HeavenFramework;";

            var connectionFactory = new DbConnectionFactory(() => {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            });

            ISql sql = new Sql(connectionFactory);

            var conditions = new List<string>();
            if (true) conditions.Add("");
            if (true) conditions.Add("");

            var query = sql.Select().From<Depositos>()
                .Where("NombreDeposito LIKE @nombreDeposito")
                .ToString();

            var result = await sql.QueryAsync<Depositos>(new { nombreDeposito = "%a%" });

            Assert.True(true);            
        }
    }
}