using FTPDataDirectory.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WK.Libraries.BetterFolderBrowserNS;

namespace FTPDataDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FTPDataDirectory.Name.downloadEvent += UpdatePictureStat;
        }

        private void UpdatePictureStat(object sender, EventArgs e)
        {
            SetPicture(true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }


        private void SetPicture(bool vis)
        {
            RunOnUIThread(() =>
            {

                pictureBox1.Visible = vis;

            });

        }


        public void ProgressBar(bool a)
        {
            SetPicture(a);
        }

        void RunOnUIThread(Action code)
        {
            if (this.InvokeRequired)
                this.Invoke(code);
            else
                code();
        }


        private FtpWebRequest ftpRequestSS = null;
        string userNameSS = "ftp";
        string passwordSS = "iwgss";
        TreeNode[] array = new TreeNode[4];
        string ip = "";
        string port = "";
        private void btnCheck_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            if (!String.IsNullOrEmpty(txtHost.Text.Trim()) && !String.IsNullOrEmpty(txtHost.Text.Trim()))
            {
                //then we will start to get the all directory under the ftp server like (Terrain, Exercise & Database)
                try
                {
                    treeView1.Nodes.Clear();

                    ip = txtHost.Text.Trim();
                    port = txtPort.Text.Trim();
                    string hostSS = "ftp://" + ip + ":" + port;
                    ftpRequestSS = (FtpWebRequest)FtpWebRequest.Create(hostSS + "/");
                    //Log in to the FTP Server with the User Name and Password Provided
                    ftpRequestSS.Method = WebRequestMethods.Ftp.ListDirectory;
                    ftpRequestSS.Credentials = new NetworkCredential(userNameSS, passwordSS);
                    FtpWebResponse response = (FtpWebResponse)ftpRequestSS.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    string names = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    List<string> dir = names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    Console.WriteLine();
                    int i = 0;
                    foreach (var value in dir)
                    {
                        if (value != ".") 
                        {
                            array[i] = new TreeNode(value);
                            i++;
                        }
                    }

                    TreeNode treeNode = new TreeNode("Server Connected", array);
                    treeView1.Nodes.Add(treeNode);


                    treeView1.Nodes[0].ForeColor = Color.Green;
                    Font f = new Font("Arial", 11, FontStyle.Bold);
                    treeView1.Nodes[0].NodeFont = f;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed!! "+ex.Message);
                }
            }
        }

        public List<string> GetDirs(string subDir)
        {
            string hostSS = "ftp://" + ip + ":" + port;
            ftpRequestSS = (FtpWebRequest)FtpWebRequest.Create(hostSS + subDir);
            //Log in to the FTP Server with the User Name and Password Provided
            ftpRequestSS.Method = WebRequestMethods.Ftp.ListDirectory;
            ftpRequestSS.Credentials = new NetworkCredential(userNameSS, passwordSS);
            FtpWebResponse response = (FtpWebResponse)ftpRequestSS.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string names = reader.ReadToEnd();
            reader.Close();
            response.Close();

            List<string> dir = names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return dir;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();
            if (!String.IsNullOrEmpty(e.Node.Text))
            {
                string hostSS = "ftp://" + ip + ":" + port;
                string current_dir = hostSS + "/" + e.Node.Text;
                List<string> dir = GetDirs("/" + e.Node.Text);

                foreach (var directory in dir)
                {

                    if (directory.Length > 2 && String.IsNullOrEmpty(Path.GetExtension(hostSS + "/" + e.Node.Text + "/" + directory)))
                    {
                        Name n = new Name();
                        n.folder_Name = directory;
                        n.folder_Path = hostSS + "/" + e.Node.Text + "/" + directory;
                        n.SetLbl();
                        this.flowLayoutPanel1.Controls.Add(n);
                    }

                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (radioButtonDB.Checked == true || radioButtonEx.Checked == true || radioButtonSn.Checked == true || radioButtonTr.Checked == true)
            {
                flowLayoutPanel1.Controls.Clear();

                if (radioButtonDB.Checked == true)
                {
                    this.DatabaseUpload();
                }
                else if (radioButtonEx.Checked == true)
                {
                    this.ExerciseUpload();
                }
                else if (radioButtonTr.Checked == true)
                {
                    this.TerrainUpload();
                }
                else if (radioButtonSn.Checked == true)
                {
                    this.SessionsUpload();
                }
            }
            else
            {
                MessageBox.Show("Please! Select an item!!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }


        Thread thread;
        Thread thread1;
        Thread thread2;
        Thread thread3;
        public void DatabaseUpload()
        {
            thread = new Thread(() =>
            {
                try
                {

                    string sourceDirToUpload = "";

                    var betterFolderBrowser = new BetterFolderBrowser();
                    betterFolderBrowser.Title = "Select folders...";
                    betterFolderBrowser.RootFolder = "C:\\";
                    betterFolderBrowser.Multiselect = false;

                    if (betterFolderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        sourceDirToUpload = betterFolderBrowser.SelectedFolder;
                    }
                    else
                    {
                        return;
                    }


                    if (!String.IsNullOrEmpty(sourceDirToUpload) && !String.IsNullOrEmpty(ip) && !String.IsNullOrEmpty(port))
                    {
                        ProgressBar(true);
                        string ftpServerUrl = ip + ":" + port + "/Database";
                        //MyFtpClient ftp = new MyFtpClient(userNameSS, passwordSS, ftpServerUrl, @"C:\Users\User\Desktop\Test_DB_18_Mar_2021");
                        MyFtpClient ftp = new MyFtpClient(userNameSS, passwordSS, ftpServerUrl, sourceDirToUpload);
                        ftp.UploadDirectory();
                        ProgressBar(false);
                        MessageBox.Show("Successfully Uploaded!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Console.ReadLine();
                    }
                    else
                    {
                        MessageBox.Show("Check IP, Port & Dir path");
                    }


                }
                catch (Exception e)
                {
                    MessageBox.Show("" + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            });

            thread.Start();
        }

        public void ExerciseUpload()
        {
            thread1 = new Thread(() =>
            {
                try
                {

                    string sourceDirToUpload = "";

                    var betterFolderBrowser = new BetterFolderBrowser();
                    betterFolderBrowser.Title = "Select folders...";
                    betterFolderBrowser.RootFolder = "C:\\";
                    betterFolderBrowser.Multiselect = false;

                    if (betterFolderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        sourceDirToUpload = betterFolderBrowser.SelectedFolder;
                    }
                    else
                    {
                        return;
                    }


                    if (!String.IsNullOrEmpty(sourceDirToUpload) && !String.IsNullOrEmpty(ip) && !String.IsNullOrEmpty(port))
                    {
                        ProgressBar(true);
                        string ftpServerUrl = ip + ":" + port + "/Exercise";
                        //MyFtpClient ftp = new MyFtpClient(userNameSS, passwordSS, ftpServerUrl, @"C:\Users\User\Desktop\Test_DB_18_Mar_2021");
                        MyFtpClient ftp = new MyFtpClient(userNameSS, passwordSS, ftpServerUrl, sourceDirToUpload);
                        ftp.UploadDirectory();
                        ProgressBar(false);
                        MessageBox.Show("Successfully Uploaded!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Console.ReadLine();
                    }
                    else
                    {
                        MessageBox.Show("Check IP, Port & Dir path");
                    }


                }
                catch (Exception e)
                {
                    MessageBox.Show("" + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            });
            thread1.Start();

        }

        public void TerrainUpload()
        {
            thread2 = new Thread(() =>
            {
                try
                {

                    string sourceDirToUpload = "";

                    var betterFolderBrowser = new BetterFolderBrowser();
                    betterFolderBrowser.Title = "Select folders...";
                    betterFolderBrowser.RootFolder = "C:\\";
                    betterFolderBrowser.Multiselect = false;

                    if (betterFolderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        sourceDirToUpload = betterFolderBrowser.SelectedFolder;
                    }
                    else
                    {
                        return;
                    }


                    if (!String.IsNullOrEmpty(sourceDirToUpload) && !String.IsNullOrEmpty(ip) && !String.IsNullOrEmpty(port))
                    {
                        ProgressBar(true);
                        string ftpServerUrl = ip + ":" + port + "/Terrain";
                        //MyFtpClient ftp = new MyFtpClient(userNameSS, passwordSS, ftpServerUrl, @"C:\Users\User\Desktop\Test_DB_18_Mar_2021");
                        MyFtpClient ftp = new MyFtpClient(userNameSS, passwordSS, ftpServerUrl, sourceDirToUpload);
                        ftp.UploadDirectory();
                        ProgressBar(false);
                        MessageBox.Show("Successfully Uploaded!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Console.ReadLine();
                    }
                    else
                    {
                        MessageBox.Show("Check IP, Port & Dir path");
                    }


                }
                catch (Exception e)
                {
                    MessageBox.Show("" + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            thread2.Start();
        }

        public void SessionsUpload()
        {
            thread3 = new Thread(() =>
            {
                try
                {

                    string sourceDirToUpload = "";

                    var betterFolderBrowser = new BetterFolderBrowser();
                    betterFolderBrowser.Title = "Select folders...";
                    betterFolderBrowser.RootFolder = "C:\\";
                    betterFolderBrowser.Multiselect = false;

                    if (betterFolderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        sourceDirToUpload = betterFolderBrowser.SelectedFolder;
                    }
                    else
                    {
                        return;
                    }


                    if (!String.IsNullOrEmpty(sourceDirToUpload) && !String.IsNullOrEmpty(ip) && !String.IsNullOrEmpty(port))
                    {
                        ProgressBar(true);
                        string ftpServerUrl = ip + ":" + port + "/Sessions";
                        //MyFtpClient ftp = new MyFtpClient(userNameSS, passwordSS, ftpServerUrl, @"C:\Users\User\Desktop\Test_DB_18_Mar_2021");
                        MyFtpClient ftp = new MyFtpClient(userNameSS, passwordSS, ftpServerUrl, sourceDirToUpload);
                        ftp.UploadDirectory();
                        ProgressBar(false);
                        MessageBox.Show("Successfully Session Uploaded !!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Console.ReadLine();
                    }
                    else
                    {
                        MessageBox.Show("Check IP, Port & Dir path");
                    }


                }
                catch (Exception e)
                {
                    MessageBox.Show("" + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

            thread3.Start();
        }
    }
}
