﻿

using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace Tiny.Toolkits
{

    /// <summary>
    /// pick from file system
    /// </summary>
    public static class PickFactory
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly System.Windows.Forms.OpenFileDialog openFileDialog = new();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly System.Windows.Forms.SaveFileDialog saveFileDialog = new();


        /// <summary>
        /// pick folder from file system
        /// </summary>
        /// <param name="defaultPath"></param>
        /// <param name="title"></param>
        /// <param name="showNewFolderButton"></param>
        /// <returns></returns>
        public static string FolderPicker(string defaultPath = null, string title = "please select folder", bool showNewFolderButton = false)
        {
            folderBrowserDialog.Description = title;
            folderBrowserDialog.ShowNewFolderButton = showNewFolderButton;
            folderBrowserDialog.SelectedPath = defaultPath;
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectPath = folderBrowserDialog.SelectedPath;
                return selectPath;
            }

            return default;
        }

        /// <summary>
        /// pick folder from file system
        /// </summary>
        /// <param name="defaultPath"></param>
        /// <param name="title"></param>
        /// <param name="showNewFolderButton"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static async Task<string> FolderPickerAsync(string defaultPath = null, string title = "please select folder", bool showNewFolderButton = false)
        {
            return await await (Application.Current?.Dispatcher?.InvokeAsync(async () =>
            {

                folderBrowserDialog.Description = title;
                folderBrowserDialog.ShowNewFolderButton = showNewFolderButton;
                folderBrowserDialog.SelectedPath = defaultPath;

                try
                {
                    if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string selectPath = folderBrowserDialog.SelectedPath;
                        return selectPath;
                    }

                    return default;
                }
                finally
                {
                    //make subsequent processing smoother
                    await Task.Delay(150);
                }
            }) ?? throw new System.Exception("The application dispatcher is empty"));




        }


        /// <summary>
        /// pick file name from file system
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="title"></param>
        /// <param name="defaultFileName"></param>
        /// <param name="rootFolder"></param>
        /// <returns></returns>
        public static string FileNamePicker(string filter = "all file|*.*", string title = "please input file name", string defaultFileName = null, string rootFolder = null)
        {
            rootFolder ??= EasyFolder.Desktop;
            saveFileDialog.Filter = filter;
            saveFileDialog.SupportMultiDottedExtensions = false;
            saveFileDialog.Title = title;
            saveFileDialog.InitialDirectory = rootFolder;

            if (defaultFileName.IsNullOrWhiteSpace() == false)
            {
                saveFileDialog.FileName = defaultFileName;
            }

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                return fileName;
            }

            return default;
        }


        /// <summary>
        /// pick file name from file system
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="title"></param>
        /// <param name="defaultFileName"></param>
        /// <param name="rootFolder"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static async Task<string> FileNamePickerAsync(string filter = "all file|*.*", string title = "please input file name", string defaultFileName = null, string rootFolder = null)
        {
            return await await (Application.Current?.Dispatcher?.InvokeAsync(async () =>
            {
                rootFolder ??= EasyFolder.Desktop;
                saveFileDialog.Filter = filter;
                saveFileDialog.SupportMultiDottedExtensions = false;
                saveFileDialog.Title = title;
                saveFileDialog.InitialDirectory = rootFolder;

                if (defaultFileName.IsNullOrWhiteSpace() == false)
                {
                    saveFileDialog.FileName = defaultFileName;
                }

                try
                {
                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string fileName = saveFileDialog.FileName;
                        return fileName;
                    }

                    return default;
                }
                finally
                {
                    //make subsequent processing smoother
                    await Task.Delay(150);
                }
            }) ?? throw new System.Exception("The application dispatcher is empty"));





        }



        /// <summary>
        ///  pick file from file system
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="title"></param> 
        /// <param name="rootFolder"></param>
        /// <returns></returns>

        public static string FilePicker(string filter = "all file|*.*", string title = "please select files", string rootFolder = null)
        {
            rootFolder ??= EasyFolder.Desktop;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = filter;
            openFileDialog.Title = title;
            openFileDialog.InitialDirectory = rootFolder;
            openFileDialog.FilterIndex = 0;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                return fileName;
            }

            return default;
        }

        /// <summary>
        ///  pick files from file system
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="title"></param> 
        /// <param name="rootFolder"></param>
        /// <returns></returns>
        public static string[] FilesPicker(string filter = "all file|*.*", string title = "please select files", string rootFolder = null)
        {
            rootFolder ??= EasyFolder.Desktop;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = filter;
            openFileDialog.Title = title;
            openFileDialog.InitialDirectory = rootFolder;
            openFileDialog.FilterIndex = 0;


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] fileNames = openFileDialog.FileNames;
                return fileNames;
            }

            return new string[] { };
        }


        /// <summary>
        ///  pick file from file system
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="title"></param> 
        /// <param name="rootFolder"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static async Task<string> FilePickerAsync(string filter = "all file|*.*", string title = "please select files", string rootFolder = null)
        {
            return await await (Application.Current?.Dispatcher?.InvokeAsync(async () =>
            {
                rootFolder ??= EasyFolder.Desktop;
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = filter;
                openFileDialog.Title = title;
                openFileDialog.InitialDirectory = rootFolder;
                openFileDialog.FilterIndex = 0;
                try
                {
                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string fileName = openFileDialog.FileName;
                        return fileName;
                    }

                    return default;
                }
                finally
                {
                    //make subsequent processing smoother
                    await Task.Delay(150);
                }
            }) ?? throw new System.Exception("The application dispatcher is empty"));


        }

        /// <summary>
        /// pick files from file system
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="title"></param> 
        /// <param name="rootFolder"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static async Task<string[]> FilesPickerAsync(string filter = "all file|*.*", string title = "please select files", string rootFolder = null)
        {
            return await await (Application.Current?.Dispatcher?.InvokeAsync(async () =>
            {
                rootFolder ??= EasyFolder.Desktop;
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = filter;
                openFileDialog.Title = title;
                openFileDialog.InitialDirectory = rootFolder;
                openFileDialog.FilterIndex = 0;

                try
                {
                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string[] fileNames = openFileDialog.FileNames;
                        return fileNames;
                    }

                    return new string[] { };
                }
                finally
                {
                    //make subsequent processing smoother
                    await Task.Delay(150);
                }
            }) ?? throw new System.Exception("The application dispatcher is empty"));


        }
    }
}
