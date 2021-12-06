using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WK.Libraries.BetterFolderBrowserNS;

namespace FTPDataDirectory
{
    public partial class Name : UserControl
    {

        public static EventHandler downloadEvent;

        public Name()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
        }

        public string folder_Name { get; set; } = "";
        public string folder_Path { get; set; } = "";

        public void SetLbl()
        {
            label1.Text = folder_Name;
        }

        public void btnDownloadStatus(bool status)
        {
            if (btnDownload.InvokeRequired)
            {
                btnDownload.Invoke(new MethodInvoker(
                delegate ()
                {
                    btnDownload.Enabled = status;
                }));
            }
        }


        string userNameSS = "ftp";
        string passwordSS = "iwgss";
        Thread thread;
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you want to download?? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                thread = new Thread(() =>
                            {
                                try
                                {
                                    Console.WriteLine(this.folder_Name + " " + this.folder_Path);
                                    btnDownloadStatus(false);
                                    string sourceDirToDownload = "";

                                    var betterFolderBrowser = new BetterFolderBrowser();
                                    betterFolderBrowser.Title = "Select folder to download..";
                                    betterFolderBrowser.RootFolder = @"C:\Users\User\Desktop\";
                                    betterFolderBrowser.Multiselect = false;

                                    if (betterFolderBrowser.ShowDialog() == DialogResult.OK)
                                    {
                                        sourceDirToDownload = betterFolderBrowser.SelectedFolder;
                                    }
                                    else
                                    {
                                        btnDownloadStatus(true);
                                        return;
                                    }


                                    if (!String.IsNullOrEmpty(sourceDirToDownload))
                                    {

                                        string root = sourceDirToDownload + @"\" + folder_Name;

                                        if (!Directory.Exists(root))
                                        {
                                            Directory.CreateDirectory(root);
                                            sourceDirToDownload = root;
                                        }
                                        else
                                        {
                                            DialogResult dialogResult = MessageBox.Show("There have same directory which is going to replace!!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                            if (DialogResult.OK == dialogResult)
                                            {
                                                sourceDirToDownload = root;
                                            }
                                            else
                                            {
                                                btnDownloadStatus(true);
                                                return;
                                            }

                                        }


                                        NetworkCredential credentials = new NetworkCredential(userNameSS, passwordSS);
                                        string url = this.folder_Path + "/";


                                        //OnDownload();


                                        //Form1 f = new Form1();
                                        //f.ProgressBar(true);

                                        if (pictureBox1.InvokeRequired)
                                        {
                                            pictureBox1.Invoke(new MethodInvoker(
                                            delegate ()
                                            {
                                                pictureBox1.Visible = true;
                                            }));
                                        }

                                        bool status = DownloadFtpDirectory(url, credentials, sourceDirToDownload);


                                        if (pictureBox1.InvokeRequired)
                                        {
                                            pictureBox1.Invoke(new MethodInvoker(
                                            delegate ()
                                            {
                                                pictureBox1.Visible = false;
                                            }));
                                        }
                                        //f.ProgressBar(false);
                                        if (status == true)
                                        {
                                            MessageBox.Show("Download Successful!!");
                                            btnDownloadStatus(true);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Download Failed!!");
                                            btnDownloadStatus(true);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Select a valid directory");
                                        btnDownloadStatus(true);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("" + ex.Message);
                                    btnDownloadStatus(true);
                                }
                            });
                thread.Start();
            }


        }




        private void OnDownload()
        {
            if (downloadEvent != null)
            {
                downloadEvent(this, EventArgs.Empty);
            }
        }



        public bool DownloadFtpDirectory(string url, NetworkCredential credentials, string localPath)
        {
            try
            {
                FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(url);
                listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                listRequest.Credentials = credentials;

                List<string> lines = new List<string>();

                using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
                using (Stream listStream = listResponse.GetResponseStream())
                using (StreamReader listReader = new StreamReader(listStream))
                {
                    while (!listReader.EndOfStream)
                    {
                        //Console.WriteLine(listReader.ReadLine());
                        var a = listReader.ReadLine();
                        Console.WriteLine(a);
                        lines.Add(a);
                    }
                }

                for (int i = 0; i < lines.Count; i++)
                //Parallel.ForEach(lines, line =>
                {
                    string[] tokens =
                        lines[i].Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens.Length == 9)
                    {
                        if (tokens[8].Length > 2)
                        //if (tokens[tokens.Length - 1].Length > 2)
                        //if (true)
                        {
                            //string name = tokens[tokens.Length - 1];
                            string name = tokens[8];
                            string permissions = tokens[0];

                            string localFilePath = Path.Combine(localPath, name);
                            string fileUrl = url + name;

                            if (permissions[0] == 'd')
                            {
                                if (!Directory.Exists(localFilePath))
                                {
                                    Directory.CreateDirectory(localFilePath);
                                }

                                DownloadFtpDirectory(fileUrl + "/", credentials, localFilePath);
                            }
                            else
                            {
                                FtpWebRequest infoRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                                infoRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                                infoRequest.Credentials = credentials;
                                FtpWebResponse response = (FtpWebResponse)infoRequest.GetResponse();
                                //Console.WriteLine(response.LastModified);
                                //localFilePath
                                //System.IO.File.GetLastWriteTime("C:\\Users\\User\\Desktop\\TestDownload\\Ex_Durjoy Ghati_test\\area\\areas.json").ToString()
                                if (!response.LastModified.ToString().Equals(System.IO.File.GetLastWriteTime(localFilePath).ToString(), StringComparison.OrdinalIgnoreCase))
                                {
                                    FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                                    downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                                    downloadRequest.Credentials = credentials;

                                    using (FtpWebResponse downloadResponse =
                                              (FtpWebResponse)downloadRequest.GetResponse())
                                    using (Stream sourceStream = downloadResponse.GetResponseStream())
                                    using (Stream targetStream = File.Create(localFilePath))
                                    {
                                        byte[] buffer = new byte[10240];
                                        int read;
                                        while ((read = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                                        {
                                            targetStream.Write(buffer, 0, read);
                                        }
                                    }


                                    //here we will set same time satamp
                                    File.SetLastWriteTime(localFilePath, response.LastModified);
                                }
                            }
                        }
                    }
                    else
                    {
                        //Console.WriteLine();

                        tokens = lines[i].Split(new[] { " " }, 4, StringSplitOptions.RemoveEmptyEntries);

                        string name = tokens[3];
                        //string permissions = tokens[0];

                        string localFilePath = Path.Combine(localPath, name);
                        string fileUrl = url + name;

                        if (String.IsNullOrWhiteSpace(Path.GetExtension(fileUrl)))
                        {
                            if (!Directory.Exists(localFilePath))
                            {
                                Directory.CreateDirectory(localFilePath);
                                DownloadFtpDirectory(fileUrl + "/", credentials, localFilePath);
                            }
                        }

                        if (String.IsNullOrWhiteSpace(Path.GetExtension(fileUrl)))
                        {
                            //i++;
                            continue;
                            //Console.WriteLine();
                        }

                        FtpWebRequest infoRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                        infoRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                        infoRequest.Credentials = credentials;
                        FtpWebResponse response = (FtpWebResponse)infoRequest.GetResponse();
                        //Console.WriteLine(response.LastModified);
                        //localFilePath
                        //System.IO.File.GetLastWriteTime("C:\\Users\\User\\Desktop\\TestDownload\\Ex_Durjoy Ghati_test\\area\\areas.json").ToString()
                        if (!response.LastModified.ToString().Equals(System.IO.File.GetLastWriteTime(localFilePath).ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                            downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                            downloadRequest.Credentials = credentials;

                            using (FtpWebResponse downloadResponse =
                                      (FtpWebResponse)downloadRequest.GetResponse())
                            using (Stream sourceStream = downloadResponse.GetResponseStream())
                            using (Stream targetStream = File.Create(localFilePath))
                            {
                                byte[] buffer = new byte[10240];
                                int read;
                                while ((read = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    targetStream.Write(buffer, 0, read);
                                }
                            }


                            //here we will set same time satamp
                            File.SetLastWriteTime(localFilePath, response.LastModified);
                        }
                    }



                    //try
                    //{

                    //}
                    //catch (Exception ex)
                    //{

                    //}

                }
                //});
                return true;
            }
            catch (Exception e)
            {
                //MessageBox.Show("Download Failed");
                return false;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you want to delete?? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                try
                {
                    NetworkCredential credentials = new NetworkCredential(userNameSS, passwordSS);
                    if (pictureBox1.InvokeRequired)
                    {
                        pictureBox1.Invoke(new MethodInvoker(
                        delegate ()
                        {
                            pictureBox1.Visible = true;
                        }));
                    }

                    DeleteFtpDirectory(folder_Path+@"/",credentials);

                    if (pictureBox1.InvokeRequired)
                    {
                        pictureBox1.Invoke(new MethodInvoker(
                        delegate ()
                        {
                            pictureBox1.Visible = false;
                        }));
                    }
                    MessageBox.Show("Deleted!!! Do refresh!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error !!" + Environment.NewLine + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        static void DeleteFtpDirectory(string url, NetworkCredential credentials)
        {
            FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(url);
            listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            listRequest.Credentials = credentials;

            List<string> lines = new List<string>();

            using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
            using (Stream listStream = listResponse.GetResponseStream())
            using (StreamReader listReader = new StreamReader(listStream))
            {
                while (!listReader.EndOfStream)
                {
                    //Console.WriteLine(listReader.ReadLine());
                    var a = listReader.ReadLine();
                    Console.WriteLine(a);
                    lines.Add(a);
                }
            }

            for (int i = 0; i<lines.Count; i++)
            {
                string[] tokens =
                    lines[i].Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 9)
                {
                    string name = tokens[8];
                    string permissions = tokens[0];

                    string fileUrl = url + name;

                    if (name.Length <= 2)
                    {
                        continue;
                    }
                    


                    if (String.IsNullOrWhiteSpace(Path.GetExtension(fileUrl)))
                    {
                        DeleteFtpDirectory(fileUrl + "/", credentials);
                    }

                    if (String.IsNullOrWhiteSpace(Path.GetExtension(fileUrl)))
                    {
                        //i++;
                        continue;
                        //Console.WriteLine();
                    }

                    FtpWebRequest deleteRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                    deleteRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                    deleteRequest.Credentials = credentials;

                    deleteRequest.GetResponse();
                }
                else
                {
                    tokens = lines[i].Split(new[] { " " }, 4, StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[3];
                    string fileUrl = url + name;
                    if (String.IsNullOrWhiteSpace(Path.GetExtension(fileUrl)))
                    {
                        DeleteFtpDirectory(fileUrl + "/", credentials);
                    }

                    if (String.IsNullOrWhiteSpace(Path.GetExtension(fileUrl)))
                    {
                        //i++;
                        continue;
                        //Console.WriteLine();
                    }

                    FtpWebRequest deleteRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                    deleteRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                    deleteRequest.Credentials = credentials;

                    deleteRequest.GetResponse();
                }
               
            }

            FtpWebRequest removeRequest = (FtpWebRequest)WebRequest.Create(url);
            removeRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
            removeRequest.Credentials = credentials;

            removeRequest.GetResponse();
        }

    }
}
