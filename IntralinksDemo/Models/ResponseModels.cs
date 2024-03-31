using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntralinksDemo.Models
{
    public class TokenResponse
    {
        public Links _links { get; set; }
        public Data data { get; set; }
        public Status _status { get; set; }
    }
    public class Data
    {
        public string id { get; set; }
        public string principalKind { get; set; }
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public string providerId { get; set; }
        public string createdBy { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Status
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class WorkSpacesResponse
    {
        public Status status { get; set; }
        public List<Workspace> workspace { get; set; }
    }

    public class Statistics
    {
        public int newTasks { get; set; }
        public int newParticipantRequests { get; set; }
    }

    public class Workspace
    {
        public string workspaceName { get; set; }
        public int parentTemplateId { get; set; }
        public string host { get; set; }
        public int securityLevel { get; set; }
        public string type { get; set; }
        public Statistics statistics { get; set; }
        public string pvpEnabled { get; set; }
        public int version { get; set; }
        public string htmlViewEnabled { get; set; }
        public int businessGroupId { get; set; }
        public string phase { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class CreatedBy
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string firstNameSort { get; set; }
        public string lastNameSort { get; set; }
        public string organization { get; set; }
        public string organizationSort { get; set; }
    }

    public class CreatedOn
    {
        public object milliseconds { get; set; }
    }

    public class Folder
    {
        public int id { get; set; }
        public string name { get; set; }
        public int orderNumber { get; set; }
        public string version { get; set; }
        public bool hasChildFolders { get; set; }
        public bool indexingDisabled { get; set; }
        public int parentId { get; set; }
        public CreatedOn createdOn { get; set; }
        public CreatedBy createdBy { get; set; }
        public LastModifiedOn lastModifiedOn { get; set; }
        public LastModifiedBy lastModifiedBy { get; set; }
        public bool isFavorite { get; set; }
        public int versionNumber { get; set; }
        public bool isEmailin { get; set; }
    }

    public class LastModifiedBy
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string firstNameSort { get; set; }
        public string lastNameSort { get; set; }
    }

    public class LastModifiedOn
    {
        public object milliseconds { get; set; }
    }

    public class FoldersResponse
    {
        public Status status { get; set; }
        public List<Folder> folder { get; set; }
    }

    public class ContentList
    {
        public List<DocFolder> docFolderList { get; set; }
    }

    public class DocFolder
    {
        public int id { get; set; }
        public string name { get; set; }
        public int orderNumber { get; set; }
        public string version { get; set; }
        public int fileSize { get; set; }
        public string fileHash { get; set; }
        public string fileHashDownload { get; set; }
        public string mimeType { get; set; }
        public bool noteRequired { get; set; }
        public int parentId { get; set; }
        public CreatedOn createdOn { get; set; }
        public CreatedBy createdBy { get; set; }
        public SubmittedOn submittedOn { get; set; }
        public SubmittedBy submittedBy { get; set; }
        public SubmitterGroups submitterGroups { get; set; }
        public LastModifiedOn lastModifiedOn { get; set; }
        public LastModifiedBy lastModifiedBy { get; set; }
        public bool unread { get; set; }
        public int pageCount { get; set; }
        public int workspaceId { get; set; }
        public int versionNumber { get; set; }
        public bool isFavorite { get; set; }
        public string pdfProtection { get; set; }
        public bool hasNote { get; set; }
        public string extension { get; set; }
        public EffectiveDate effectiveDate { get; set; }
        public bool isIrmSecured { get; set; }
        public bool isDeleted { get; set; }
        public bool isBusinessProcessEnabled { get; set; }
        public string documentHash { get; set; }
        public XmlLock xmlLock { get; set; }
        public int sharedResourceId { get; set; }
        public int sharedResourceCount { get; set; }
        public string entityType { get; set; }
    }

    public class EffectiveDate
    {
        public long milliseconds { get; set; }
    }

    public class FolderContentResponse
    {
        public Status status { get; set; }
        public ContentList contentList { get; set; }
    }

    public class SubmittedBy
    {
    }

    public class SubmittedOn
    {
    }

    public class SubmitterGroups
    {
    }

    public class XmlLock
    {
        public string contentLockStatus { get; set; }
    }

}
