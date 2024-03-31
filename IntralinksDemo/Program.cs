namespace IntralinksDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new IntralinksApiClient();
            client.SetupToken();
            var workSpaces = client.GetWorkSpaces();
            var workSpace = workSpaces[0];
            var workSpaceId = workSpace.id;
            var folders = client.GetFolders(workSpaceId);
            var outputFolderName = workSpace.workspaceName;

            Console.WriteLine(outputFolderName);
            Console.WriteLine("=======================");

            if (Directory.Exists(outputFolderName)) Directory.Delete(outputFolderName, true);
            
            foreach (var item in folders)
            {
                var contentList = client.GetFolderContents(workSpaceId, item.id);
                var folderName = item.name;
                Console.WriteLine("Folder: " + folderName);
                Console.WriteLine("=======================");
                foreach (var itemCon in contentList)
                {
                    var fileName = itemCon.name + itemCon.extension;
                    Console.WriteLine(fileName + " ====> " + itemCon.fileSize);
                    if (itemCon.fileSize > 0)
                    {
                        var filepath = client.GetFolderPath(folders, itemCon);
                        filepath = outputFolderName + "\\" + filepath;
                        Directory.CreateDirectory(filepath);
                        client.DownloadFile(workSpaceId, itemCon.id, filepath + "\\"+ fileName);
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

    }
}

