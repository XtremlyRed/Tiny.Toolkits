using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Tiny.Toolkits
{
    /// <summary>
    /// <see cref="EasyFolder"/>
    /// </summary> 
    public readonly struct EasyFolder
    {
        /// <summary>
        /// <see cref="Environment.SpecialFolder.Desktop"/> folder
        /// </summary>
        public static EasyFolder Desktop = new(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.Programs"/> folder
        /// </summary>
        public static EasyFolder Programs = new(Environment.GetFolderPath(Environment.SpecialFolder.Programs));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.MyDocuments"/> folder
        /// </summary>
        public static EasyFolder MyDocuments = new(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

        /// <summary>
        /// <see cref="Environment.SpecialFolder.Favorites"/> folder
        /// </summary>
        public static EasyFolder Favorites = new(Environment.GetFolderPath(Environment.SpecialFolder.Favorites));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.Startup"/> folder
        /// </summary>
        public static EasyFolder Startup = new(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.Recent"/> folder
        /// </summary>
        public static EasyFolder Recent = new(Environment.GetFolderPath(Environment.SpecialFolder.Recent));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.SendTo"/> folder
        /// </summary>
        public static EasyFolder SendTo = new(Environment.GetFolderPath(Environment.SpecialFolder.SendTo));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.StartMenu"/> folder
        /// </summary>
        public static EasyFolder StartMenu = new(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.MyMusic"/> folder
        /// </summary>
        public static EasyFolder MyMusic = new(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.MyVideos"/> folder
        /// </summary>
        public static EasyFolder MyVideos = new(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.DesktopDirectory"/> folder
        /// </summary>
        public static EasyFolder DesktopDirectory = new(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.MyComputer"/> folder
        /// </summary>
        public static EasyFolder MyComputer = new(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.NetworkShortcuts"/> folder
        /// </summary>
        public static EasyFolder NetworkShortcuts = new(Environment.GetFolderPath(Environment.SpecialFolder.NetworkShortcuts));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.Fonts"/> folder
        /// </summary>
        public static EasyFolder Fonts = new(Environment.GetFolderPath(Environment.SpecialFolder.Fonts));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.Templates"/> folder
        /// </summary>
        public static EasyFolder Templates = new(Environment.GetFolderPath(Environment.SpecialFolder.Templates));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonStartMenu"/> folder
        /// </summary>
        public static EasyFolder CommonStartMenu = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonPrograms"/> folder
        /// </summary>
        public static EasyFolder CommonPrograms = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonStartup"/> folder
        /// </summary>
        public static EasyFolder CommonStartup = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonDesktopDirectory"/> folder
        /// </summary>
        public static EasyFolder CommonDesktopDirectory = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.ApplicationData"/> folder
        /// </summary>
        public static EasyFolder ApplicationData = new(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.PrinterShortcuts"/> folder
        /// </summary>
        public static EasyFolder PrinterShortcuts = new(Environment.GetFolderPath(Environment.SpecialFolder.PrinterShortcuts));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.LocalApplicationData"/> folder
        /// </summary>
        public static EasyFolder LocalApplicationData = new(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.InternetCache"/> folder
        /// </summary>
        public static EasyFolder InternetCache = new(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.Cookies"/> folder
        /// </summary>
        public static EasyFolder Cookies = new(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.History"/> folder
        /// </summary>
        public static EasyFolder History = new(Environment.GetFolderPath(Environment.SpecialFolder.History));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonApplicationData"/> folder
        /// </summary>
        public static EasyFolder CommonApplicationData = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.Windows"/> folder
        /// </summary>
        public static EasyFolder Windows = new(Environment.GetFolderPath(Environment.SpecialFolder.Windows));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.System"/> folder
        /// </summary>
        public static EasyFolder System = new(Environment.GetFolderPath(Environment.SpecialFolder.System));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.ProgramFiles"/> folder
        /// </summary>
        public static EasyFolder ProgramFiles = new(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.MyPictures"/> folder
        /// </summary>
        public static EasyFolder MyPictures = new(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.UserProfile"/> folder
        /// </summary>
        public static EasyFolder UserProfile = new(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.SystemX86"/> folder
        /// </summary>
        public static EasyFolder SystemX86 = new(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.ProgramFilesX86"/> folder
        /// </summary>
        public static EasyFolder ProgramFilesX86 = new(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonProgramFiles"/> folder
        /// </summary>
        public static EasyFolder CommonProgramFiles = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonProgramFilesX86"/> folder
        /// </summary>
        public static EasyFolder CommonProgramFilesX86 = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonTemplates"/> folder
        /// </summary>
        public static EasyFolder CommonTemplates = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonTemplates));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonDocuments"/> folder
        /// </summary>
        public static EasyFolder CommonDocuments = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonAdminTools"/> folder
        /// </summary>
        public static EasyFolder CommonAdminTools = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonAdminTools));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.AdminTools"/> folder
        /// </summary>
        public static EasyFolder AdminTools = new(Environment.GetFolderPath(Environment.SpecialFolder.AdminTools));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonMusic"/> folder
        /// </summary>
        public static EasyFolder CommonMusic = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonPictures"/> folder
        /// </summary>
        public static EasyFolder CommonPictures = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonVideos"/> folder
        /// </summary>
        public static EasyFolder CommonVideos = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.Resources"/> folder
        /// </summary>
        public static EasyFolder Resources = new(Environment.GetFolderPath(Environment.SpecialFolder.Resources));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.LocalizedResources"/> folder
        /// </summary>
        public static EasyFolder LocalizedResources = new(Environment.GetFolderPath(Environment.SpecialFolder.LocalizedResources));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CommonOemLinks"/> folder
        /// </summary>
        public static EasyFolder CommonOemLinks = new(Environment.GetFolderPath(Environment.SpecialFolder.CommonOemLinks));
        /// <summary>
        /// <see cref="Environment.SpecialFolder.CDBurning"/> folder
        /// </summary>
        public static EasyFolder CDBurning = new(Environment.GetFolderPath(Environment.SpecialFolder.CDBurning));

        /// <summary>
        /// <see cref="Environment.CurrentDirectory"/> folder
        /// </summary>
        public static EasyFolder Current = new(Environment.CurrentDirectory);


        /// <summary>
        /// auto create folder when not exist
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool AutoCreateFolder = true;

        /// <summary>
        /// share a new <see cref="EasyFolder"/> folder
        /// </summary> 
        public EasyFolder(string folder) { this.folder = folder; }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder;
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return this;
        }

        /// <summary>
        /// combines four strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <Exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</Exception>
        /// <Exception cref="System.ArgumentNullException">one of the strings in the array is null.</Exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths)
        {
            return new EasyFolder(Path.Combine(folder.Concat(paths).ToArray()));
        }

        /// <summary>
        /// get folder string from <paramref name="easyFolder"/>
        /// </summary>
        /// <param name="easyFolder"></param>
        public static implicit operator string(EasyFolder easyFolder)
        {
            if (AutoCreateFolder)
            {
                easyFolder.TryCreateFolder();
            }
            return easyFolder.folder;
        }

        /// <summary>
        ///  Create Directory If Not Exists
        /// </summary>
        public EasyFolder TryCreateFolder()
        {
            string dir = Path.GetDirectoryName(folder);
            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }

            return this;
        }

        /// <summary>
        /// create <see cref="EasyFolder"/> from string  
        /// </summary>
        /// <param name="path"></param>
        public static implicit operator EasyFolder(string path)
        {
            return new EasyFolder(path);
        }

        /// <summary>
        /// get <see cref="EasyFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return folder.GetHashCode();
        }

        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return obj != null && obj is EasyFolder easyFolder && easyFolder.GetHashCode() == GetHashCode();
        }
    }
}
