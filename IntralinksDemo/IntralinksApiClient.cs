using IntralinksDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntralinksDemo
{
    internal class IntralinksApiClient
    {
        public string accessToken = string.Empty;
        public void SetupToken()
        {
            var clienId = "";
            var clientSecret = "";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://apps-preview.intralinks.com/v3/apis/il-iam/oauth/token");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", "Basic " + Base64Encode(clienId + ":" + clientSecret));
            var content = new StringContent("{\"data\":{\"grant_type\":\"client_credentials\"}}", null, "application/json");
            request.Content = content;
            var response = client.Send(request);
            var respstr = response.Content.ReadAsStringAsync().Result;
            var tokenResp = JsonConvert.DeserializeObject<TokenResponse>(respstr);
            this.accessToken = tokenResp.data.accessToken;
        }

        public List<Workspace> GetWorkSpaces()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://apps-preview.intralinks.com/v2/workspaces");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", "Bearer " + this.accessToken);
            var response = client.Send(request);
            var respstr = response.Content.ReadAsStringAsync().Result;
            var responseObj = JsonConvert.DeserializeObject<WorkSpacesResponse>(respstr);
            return responseObj.workspace;
        }

        public List<Folder> GetFolders(int workspaceId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://apps-preview.intralinks.com/v2/workspaces/" + workspaceId + "/folders");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", "Bearer " + this.accessToken);
            var response = client.Send(request);
            var respstr = response.Content.ReadAsStringAsync().Result;
            var responseObj = JsonConvert.DeserializeObject<FoldersResponse>(respstr);
            return responseObj.folder;
        }

        public List<DocFolder> GetFolderContents(int workspaceId, int folderId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://apps-preview.intralinks.com/v2/workspaces/" + workspaceId + "/folders/" + folderId + "/contents");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", "Bearer " + this.accessToken);
            var response = client.Send(request);
            var respstr = response.Content.ReadAsStringAsync().Result;
            var responseObj = JsonConvert.DeserializeObject<FolderContentResponse>(respstr);
            return responseObj.contentList.docFolderList;
        }

        public void DownloadFile(int workspaceId, int documentId, string fileName)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://apps-preview.intralinks.com/v2/workspaces/" + workspaceId + "/documents/" + documentId + "/file");
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Bearer " + this.accessToken);
                var content = new StringContent("", null, "text/plain");
                request.Content = content;
                var response = client.Send(request);
                var respstr = response.Content.ReadAsStream();
                using (var fs = new FileStream(fileName, FileMode.CreateNew))
                {
                    respstr.CopyToAsync(fs);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public string Base64Encode(string text)
        {
            var textBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(textBytes);
        }
        public string Base64Decode(string base64)
        {
            var base64Bytes = System.Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(base64Bytes);
        }

        public string GetFolderPath(List<Folder> allFolders, DocFolder doc)
        {
            var fileFullPath = string.Empty;

            var currentItem = allFolders.Find(f => f.id == doc.parentId);
            fileFullPath = currentItem.name;
            while(currentItem != null && currentItem.parentId != null)
            {
                currentItem = allFolders.Find(f => f.id == currentItem.parentId);
                if (currentItem != null)
                {
                    fileFullPath = currentItem.name + "\\" + fileFullPath;
                }
            }

            return fileFullPath;
        }

    }
}
