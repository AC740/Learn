namespace DownLoadBlobs
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure; // Namespace for CloudConfigurationManager
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("BlobStorageConnectionString"));
            // Create the table client.
            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
            // Retrieve a reference to the table.

            var cloudBlobs = cloudBlobClient.GetContainerReference("sampleblobcontainer").GetDirectoryReference("SampleData").ListBlobs();

            foreach (CloudBlockBlob blob in cloudBlobs)
            {
                var test = blob.Name;
                using (var fileStream = System.IO.File.Create(@"\GitHub\Learn\Task7_Storage\Porjects\BlobDataDownLoad\" + blob.Name))
                {
                    var blobReference = cloudBlobClient.GetBlobReferenceFromServer(blob.Uri);
                    blobReference.DownloadToStream(fileStream);
                }
            }

            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
