namespace SampleStorageHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure; // Namespace for CloudConfigurationManager
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;

    /// <summary>
    /// Download Table Content and display all records on screen
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("TableStorageConnectionString"));
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            // Retrieve a reference to the table.
            CloudTable testTable = tableClient.GetTableReference("TestTable");

            #region Hide
            // Create the table if it doesn't exist.
            //testTable.CreateIfNotExists();
            // Create a new customer entity.
            //StateEntity state1 = new StateEntity("LL", "Learn");
            // Create the TableOperation object that inserts the customer entity.
            //TableOperation insertOperation = TableOperation.Insert(state1);
            // Execute the insert operation.
            // testTable.Execute(insertOperation);
            #endregion

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<StateEntity> query = new TableQuery<StateEntity>();
            // Print the fields for each customer.
            foreach (StateEntity entity in testTable.ExecuteQuery(query))
            {
                Console.WriteLine($"{entity.PartitionKey} \t {entity.RowKey}");
            }
            Console.ReadKey();
        }
    }


    public class StateEntity : TableEntity
    {
        public StateEntity(string stateCode, string stateName)
        {
            this.PartitionKey = stateCode;
            this.RowKey = stateName;
        }

        public StateEntity() { }

    }

}
