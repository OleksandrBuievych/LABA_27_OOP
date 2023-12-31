﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA_27_OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive.Name);
                driveNode.Tag = drive.RootDirectory;
                driveNode.Nodes.Add(new TreeNode()); // Add a dummy node to show expand icon

                treeView.Nodes.Add(driveNode);
            }
        }

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            if (selectedNode.Nodes.Count == 1 && selectedNode.Nodes[0].Text == "")
            {
                selectedNode.Nodes.Clear();
                DirectoryInfo selectedDir = (DirectoryInfo)selectedNode.Tag;

                try
                {
                    foreach (DirectoryInfo subDir in selectedDir.GetDirectories())
                    {
                        TreeNode subDirNode = new TreeNode(subDir.Name);
                        subDirNode.Tag = subDir;
                        subDirNode.Nodes.Add(new TreeNode()); // Add a dummy node to show expand icon

                        selectedNode.Nodes.Add(subDirNode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            DirectoryInfo selectedDir = (DirectoryInfo)selectedNode.Tag;

            listView.Items.Clear();

            try
            {
                foreach (DirectoryInfo subDir in selectedDir.GetDirectories())
                {
                    ListViewItem item = new ListViewItem(subDir.Name);
                    item.SubItems.Add("Folder");
                    item.SubItems.Add(subDir.LastWriteTime.ToString());

                    listView.Items.Add(item);
                }

                foreach (FileInfo file in selectedDir.GetFiles())
                {
                    ListViewItem item = new ListViewItem(file.Name);
                    item.SubItems.Add("File");
                    item.SubItems.Add(file.LastWriteTime.ToString());

                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                string selectedItemText = selectedItem.Text;
                TreeNode selectedNode = treeView.SelectedNode;
                DirectoryInfo selectedDir = (DirectoryInfo)selectedNode.Tag;
                string path = Path.Combine(selectedDir.FullName, selectedItemText);

                if (selectedItem.SubItems[1].Text == "Folder")
                {
                    DirectoryInfo selectedDirectory = new DirectoryInfo(path);
                    ShowDirectoryContents(selectedDirectory);
                    DisplaySecurityAttributes(selectedDirectory);
                }
                else if (selectedItem.SubItems[1].Text == "File")
                {
                    FileInfo selectedFile = new FileInfo(path);
                    ShowFileProperties(selectedFile);
                    DisplaySecurityAttributes(selectedFile);
                }
            }

            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                string selectedItemText = selectedItem.Text;
                TreeNode selectedNode = treeView.SelectedNode;
                DirectoryInfo selectedDir = (DirectoryInfo)selectedNode.Tag;
                string filePath = Path.Combine(selectedDir.FullName, selectedItemText);

                if (Path.GetExtension(filePath) == ".txt")
                {
                    // Відкрити файл у блокноті
                    Process.Start("notepad.exe", filePath);
                }
            }
        }

        private void ShowFileProperties(FileInfo file)
        {
            propertiesTextBox.Text = $"File Name: {file.Name}\t";
            propertiesTextBox.Text += $"Size: {file.Length} bytes\r\n";
        }

        private void ShowDirectoryContents(DirectoryInfo directory)
        {
            listView.Items.Clear();

            try
            {
                foreach (DirectoryInfo subDir in directory.GetDirectories())
                {
                    ListViewItem item = new ListViewItem(subDir.Name);
                    item.SubItems.Add("Folder");
                    item.SubItems.Add(subDir.LastWriteTime.ToString());

                    listView.Items.Add(item);
                }

                foreach (FileInfo file in directory.GetFiles())
                {
                    ListViewItem item = new ListViewItem(file.Name);
                    item.SubItems.Add("File");
                    item.SubItems.Add(file.LastWriteTime.ToString());

                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DisplaySecurityAttributes(FileSystemInfo fileSystemInfo)
        {
            try
            {
                var securityAttributes = File.GetAccessControl(fileSystemInfo.FullName);
                var securityRules = securityAttributes.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
                var securityInfo = new StringBuilder();

                foreach (FileSystemAccessRule rule in securityRules)
                {
                    securityInfo.AppendLine($"Ідентифікатор: {rule.IdentityReference}");
                    securityInfo.AppendLine($"Тип: {rule.AccessControlType}");
                    securityInfo.AppendLine($"Права: {rule.FileSystemRights}");
                    securityInfo.AppendLine();
                }

                Security.Text = "Атрибути безпеки: \r\n";
                Security.Text += securityInfo.ToString().Replace("\r\n", "\r\n ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка відображення атрибутів безпеки: " + ex.Message);
            }
        }

        private void CreateFile(string path)
        {
            try
            {
                File.Create(path);
                ShowDirectoryContents((DirectoryInfo)treeView.SelectedNode.Tag);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка створення файлу: " + ex.Message);
            }
        }

        private void MoveFile(string sourcePath, string destinationPath)
        {
            try
            {
                File.Move(sourcePath, destinationPath);
                ShowDirectoryContents((DirectoryInfo)treeView.SelectedNode.Tag);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка переміщення файлу: " + ex.Message);
            }
        }

        private void CopyFile(string sourcePath, string destinationPath)
        {
            try
            {
                File.Copy(sourcePath, destinationPath);
                ShowDirectoryContents((DirectoryInfo)treeView.SelectedNode.Tag);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
            }
        }

        private void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
                ShowDirectoryContents((DirectoryInfo)treeView.SelectedNode.Tag);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка видалення файлу: " + ex.Message);
            }
        }






        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDrives();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                string selectedItemText = selectedItem.Text;
                TreeNode selectedNode = treeView.SelectedNode;
                DirectoryInfo selectedDir = (DirectoryInfo)selectedNode.Tag;
                string filePath = Path.Combine(selectedDir.FullName, selectedItemText);

                DialogResult result = MessageBox.Show("Ви дійсно бажаєте видалити файл?", "Видалення файлу", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteFile(filePath);
                }
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                string selectedItemText = selectedItem.Text;
                TreeNode selectedNode = treeView.SelectedNode;
                DirectoryInfo selectedDir = (DirectoryInfo)selectedNode.Tag;
                string sourcePath = Path.Combine(selectedDir.FullName, selectedItemText);

                using (var dialog = new SaveFileDialog())
                {
                    dialog.Title = "Виберіть місце для копіювання файлу";
                    dialog.FileName = selectedItemText;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string destinationPath = dialog.FileName;
                        CopyFile(sourcePath, destinationPath);
                    }
                }
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                string selectedItemText = selectedItem.Text;
                TreeNode selectedNode = treeView.SelectedNode;
                DirectoryInfo selectedDir = (DirectoryInfo)selectedNode.Tag;
                string sourcePath = Path.Combine(selectedDir.FullName, selectedItemText);

                using (var dialog = new SaveFileDialog())
                {
                    dialog.Title = "Виберіть місце для переміщення файлу";
                    dialog.FileName = selectedItemText;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string destinationPath = dialog.FileName;
                        MoveFile(sourcePath, destinationPath);
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            DirectoryInfo selectedDir = (DirectoryInfo)selectedNode.Tag;

            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Виберіть місце для створення файлу";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    CreateFile(filePath);
                }
            }
        }

        private void CreateZipArchive(string sourceDirectory, string destinationPath)
        {
            ZipFile.CreateFromDirectory(sourceDirectory, destinationPath);
        }

        // Метод для розпакування ZIP-архіву у вказаний каталог
        private void ExtractZipArchive(string sourceFilePath, string destinationDirectory)
        {
            ZipFile.ExtractToDirectory(sourceFilePath, destinationDirectory);
        }

        // Обробник події для кнопки "Створити архів"
        private void btnCreateArchive_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            DirectoryInfo selectedDir = (DirectoryInfo)selectedNode.Tag;

            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Виберіть місце для створення ZIP-архіву";
                dialog.DefaultExt = "zip";
                dialog.Filter = "ZIP Files (*.zip)|*.zip";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string archivePath = dialog.FileName;
                    CreateZipArchive(selectedDir.FullName, archivePath);
                }
            }
        }

        // Обробник події для кнопки "Розпакувати архів"
        private void btnExtractArchive_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                string selectedItemText = selectedItem.Text;
                TreeNode selectedNode = treeView.SelectedNode;
                DirectoryInfo selectedDir = (DirectoryInfo)selectedNode.Tag;
                string archivePath = Path.Combine(selectedDir.FullName, selectedItemText);

                using (var dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "Виберіть каталог для розпакування ZIP-архіву";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string destinationDirectory = dialog.SelectedPath;
                        ExtractZipArchive(archivePath, destinationDirectory);
                    }
                }
            }
        }
    }
}
