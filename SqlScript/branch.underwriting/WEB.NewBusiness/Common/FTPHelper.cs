using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WEB.NewBusiness.Common
{
    public class FTPHelper
    {
        string domain;
        string user;
        string password;
        string directory;

        public FTPHelper(string domain, string user, string password, string directory)
        {
            this.domain = domain;
            this.user = user;
            this.password = password;
            this.directory = directory;
        }

        public void UploadFiles(List<FileInfo> files)
        {
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(user, password);

                foreach (var f in files)
                {
                    var response = client.UploadFile(new Uri("ftp://" + user + ":" + password + "@" + domain + f.Name), f.FullName);
                }
            }
        }   
    }

}