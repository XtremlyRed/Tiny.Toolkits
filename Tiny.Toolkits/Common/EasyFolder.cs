using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Tiny.Toolkits
{
    /// <summary>
    /// <see cref="EasyFolder"/>
    /// </summary>
    [TypeConverter(typeof(EasyFolderTypeConverter))]
    public readonly struct EasyFolder
    {
        /// <summary>
        /// auto create folder when not exist
        /// </summary>
        public static bool AutoCreateFolder = true;
        /// <summary>
        /// <see cref="DesktopFolder"/>
        /// </summary>
        public static readonly DesktopFolder Desktop = new();

        /// <summary>
        /// <see cref="ProgramsFolder"/>
        /// </summary>
        public static readonly ProgramsFolder Programs = new();

        /// <summary>
        /// <see cref="MyDocumentsFolder"/>
        /// </summary>
        public static readonly MyDocumentsFolder MyDocuments = new();

        /// <summary>
        /// <see cref="PersonalFolder"/>
        /// </summary>
        public static readonly PersonalFolder Personal = new();

        /// <summary>
        /// <see cref="FavoritesFolder"/>
        /// </summary>
        public static readonly FavoritesFolder Favorites = new();

        /// <summary>
        /// <see cref="StartupFolder"/>
        /// </summary>
        public static readonly StartupFolder Startup = new();

        /// <summary>
        /// <see cref="RecentFolder"/>
        /// </summary>
        public static readonly RecentFolder Recent = new();

        /// <summary>
        /// <see cref="SendToFolder"/>
        /// </summary>
        public static readonly SendToFolder SendTo = new();

        /// <summary>
        /// <see cref="StartMenuFolder"/>
        /// </summary>
        public static readonly StartMenuFolder StartMenu = new();

        /// <summary>
        /// <see cref="MyMusicFolder"/>
        /// </summary>
        public static readonly MyMusicFolder MyMusic = new();

        /// <summary>
        /// <see cref="MyVideosFolder"/>
        /// </summary>
        public static readonly MyVideosFolder MyVideos = new();

        /// <summary>
        /// <see cref="DesktopDirectoryFolder"/>
        /// </summary>
        public static readonly DesktopDirectoryFolder DesktopDirectory = new();

        /// <summary>
        /// <see cref="MyComputerFolder"/>
        /// </summary>
        public static readonly MyComputerFolder MyComputer = new();

        /// <summary>
        /// <see cref="NetworkShortcutsFolder"/>
        /// </summary>
        public static readonly NetworkShortcutsFolder NetworkShortcuts = new();

        /// <summary>
        /// <see cref="FontsFolder"/>
        /// </summary>
        public static readonly FontsFolder Fonts = new();

        /// <summary>
        /// <see cref="TemplatesFolder"/>
        /// </summary>
        public static readonly TemplatesFolder Templates = new();

        /// <summary>
        /// <see cref="CommonStartMenuFolder"/>
        /// </summary>
        public static readonly CommonStartMenuFolder CommonStartMenu = new();

        /// <summary>
        /// <see cref="CommonProgramsFolder"/>
        /// </summary>
        public static readonly CommonProgramsFolder CommonPrograms = new();

        /// <summary>
        /// <see cref="CommonStartupFolder"/>
        /// </summary>
        public static readonly CommonStartupFolder CommonStartup = new();

        /// <summary>
        /// <see cref="CommonDesktopDirectoryFolder"/>
        /// </summary>
        public static readonly CommonDesktopDirectoryFolder CommonDesktopDirectory = new();

        /// <summary>
        /// <see cref="ApplicationDataFolder"/>
        /// </summary>
        public static readonly ApplicationDataFolder ApplicationData = new();

        /// <summary>
        /// <see cref="PrinterShortcutsFolder"/>
        /// </summary>
        public static readonly PrinterShortcutsFolder PrinterShortcuts = new();

        /// <summary>
        /// <see cref="LocalApplicationDataFolder"/>
        /// </summary>
        public static readonly LocalApplicationDataFolder LocalApplicationData = new();

        /// <summary>
        /// <see cref="InternetCacheFolder"/>
        /// </summary>
        public static readonly InternetCacheFolder InternetCache = new();

        /// <summary>
        /// <see cref="CookiesFolder"/>
        /// </summary>
        public static readonly CookiesFolder Cookies = new();

        /// <summary>
        /// <see cref="HistoryFolder"/>
        /// </summary>
        public static readonly HistoryFolder History = new();

        /// <summary>
        /// <see cref="CommonApplicationDataFolder"/>
        /// </summary>
        public static readonly CommonApplicationDataFolder CommonApplicationData = new();

        /// <summary>
        /// <see cref="WindowsFolder"/>
        /// </summary>
        public static readonly WindowsFolder Windows = new();

        /// <summary>
        /// <see cref="SystemFolder"/>
        /// </summary>
        public static readonly SystemFolder System = new();

        /// <summary>
        /// <see cref="ProgramFilesFolder"/>
        /// </summary>
        public static readonly ProgramFilesFolder ProgramFiles = new();

        /// <summary>
        /// <see cref="MyPicturesFolder"/>
        /// </summary>
        public static readonly MyPicturesFolder MyPictures = new();

        /// <summary>
        /// <see cref="UserProfileFolder"/>
        /// </summary>
        public static readonly UserProfileFolder UserProfile = new();

        /// <summary>
        /// <see cref="SystemX86Folder"/>
        /// </summary>
        public static readonly SystemX86Folder SystemX86 = new();

        /// <summary>
        /// <see cref="ProgramFilesX86Folder"/>
        /// </summary>
        public static readonly ProgramFilesX86Folder ProgramFilesX86 = new();

        /// <summary>
        /// <see cref="CommonProgramFilesFolder"/>
        /// </summary>
        public static readonly CommonProgramFilesFolder CommonProgramFiles = new();

        /// <summary>
        /// <see cref="CommonProgramFilesX86Folder"/>
        /// </summary>
        public static readonly CommonProgramFilesX86Folder CommonProgramFilesX86 = new();

        /// <summary>
        /// <see cref="CommonTemplatesFolder"/>
        /// </summary>
        public static readonly CommonTemplatesFolder CommonTemplates = new();

        /// <summary>
        /// <see cref="CommonDocumentsFolder"/>
        /// </summary>
        public static readonly CommonDocumentsFolder CommonDocuments = new();

        /// <summary>
        /// <see cref="CommonAdminToolsFolder"/>
        /// </summary>
        public static readonly CommonAdminToolsFolder CommonAdminTools = new();

        /// <summary>
        /// <see cref="AdminToolsFolder"/>
        /// </summary>
        public static readonly AdminToolsFolder AdminTools = new();

        /// <summary>
        /// <see cref="CommonMusicFolder"/>
        /// </summary>
        public static readonly CommonMusicFolder CommonMusic = new();

        /// <summary>
        /// <see cref="CommonPicturesFolder"/>
        /// </summary>
        public static readonly CommonPicturesFolder CommonPictures = new();

        /// <summary>
        /// <see cref="CommonVideosFolder"/>
        /// </summary>
        public static readonly CommonVideosFolder CommonVideos = new();

        /// <summary>
        /// <see cref="ResourcesFolder"/>
        /// </summary>
        public static readonly ResourcesFolder Resources = new();

        /// <summary>
        /// <see cref="LocalizedResourcesFolder"/>
        /// </summary>
        public static readonly LocalizedResourcesFolder LocalizedResources = new();

        /// <summary>
        /// <see cref="CommonOemLinksFolder"/>
        /// </summary>
        public static readonly CommonOemLinksFolder CommonOemLinks = new();

        /// <summary>
        /// <see cref="CDBurningFolder"/>
        /// </summary>
        public static readonly CDBurningFolder CDBurning = new();

        /// <summary>
        /// <see cref="CurrentFolder"/>
        /// </summary>
        public static readonly CurrentFolder Current = new();




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
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines four strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <Exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</Exception>
        /// <Exception cref="System.ArgumentNullException">one of the strings in the array is null.</Exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="easyFolder"/>
        /// </summary>
        /// <param name="easyFolder"></param>
        public static implicit operator string(EasyFolder easyFolder) { string dir = Path.GetDirectoryName(easyFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return easyFolder.folder; }

        /// <summary>
        /// create <see cref="EasyFolder"/> from string  
        /// </summary>
        /// <param name="path"></param>
        public static implicit operator EasyFolder(string path) { return new EasyFolder(path); }

        /// <summary>
        /// get <see cref="EasyFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CurrentFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }
    /// <summary>
    /// represents a Desktop folder
    /// </summary>
    public readonly struct DesktopFolder
    {
        /// <summary>
        /// share a new Desktop folder
        /// </summary>
        public DesktopFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="desktopFolder"/>
        /// </summary>
        /// <param name="desktopFolder"></param>
        public static implicit operator string(DesktopFolder desktopFolder) { string dir = Path.GetDirectoryName(desktopFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return desktopFolder.folder; }
        /// <summary>
        /// get <see cref="DesktopFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is DesktopFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a Programs folder
    /// </summary>
    public readonly struct ProgramsFolder
    {
        /// <summary>
        /// share a new Programs folder
        /// </summary>
        public ProgramsFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="programsFolder"/>
        /// </summary>
        /// <param name="programsFolder"></param>
        public static implicit operator string(ProgramsFolder programsFolder) { string dir = Path.GetDirectoryName(programsFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return programsFolder.folder; }
        /// <summary>
        /// get <see cref="ProgramsFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is ProgramsFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a MyDocuments folder
    /// </summary>
    public readonly struct MyDocumentsFolder
    {
        /// <summary>
        /// share a new MyDocuments folder
        /// </summary>
        public MyDocumentsFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="myDocumentsFolder"/>
        /// </summary>
        /// <param name="myDocumentsFolder"></param>
        public static implicit operator string(MyDocumentsFolder myDocumentsFolder) { string dir = Path.GetDirectoryName(myDocumentsFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return myDocumentsFolder.folder; }
        /// <summary>
        /// get <see cref="MyDocumentsFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is MyDocumentsFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a Personal folder
    /// </summary>
    public readonly struct PersonalFolder
    {
        /// <summary>
        /// share a new Personal folder
        /// </summary>
        public PersonalFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="personalFolder"/>
        /// </summary>
        /// <param name="personalFolder"></param>
        public static implicit operator string(PersonalFolder personalFolder) { string dir = Path.GetDirectoryName(personalFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return personalFolder.folder; }
        /// <summary>
        /// get <see cref="PersonalFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is PersonalFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a Favorites folder
    /// </summary>
    public readonly struct FavoritesFolder
    {
        /// <summary>
        /// share a new Favorites folder
        /// </summary>
        public FavoritesFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="favoritesFolder"/>
        /// </summary>
        /// <param name="favoritesFolder"></param>
        public static implicit operator string(FavoritesFolder favoritesFolder) { string dir = Path.GetDirectoryName(favoritesFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return favoritesFolder.folder; }
        /// <summary>
        /// get <see cref="FavoritesFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is FavoritesFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a Startup folder
    /// </summary>
    public readonly struct StartupFolder
    {
        /// <summary>
        /// share a new Startup folder
        /// </summary>
        public StartupFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="startupFolder"/>
        /// </summary>
        /// <param name="startupFolder"></param>
        public static implicit operator string(StartupFolder startupFolder) { string dir = Path.GetDirectoryName(startupFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return startupFolder.folder; }
        /// <summary>
        /// get <see cref="StartupFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is StartupFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a Recent folder
    /// </summary>
    public readonly struct RecentFolder
    {
        /// <summary>
        /// share a new Recent folder
        /// </summary>
        public RecentFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="recentFolder"/>
        /// </summary>
        /// <param name="recentFolder"></param>
        public static implicit operator string(RecentFolder recentFolder) { string dir = Path.GetDirectoryName(recentFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return recentFolder.folder; }
        /// <summary>
        /// get <see cref="RecentFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is RecentFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a SendTo folder
    /// </summary>
    public readonly struct SendToFolder
    {
        /// <summary>
        /// share a new SendTo folder
        /// </summary>
        public SendToFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="sendToFolder"/>
        /// </summary>
        /// <param name="sendToFolder"></param>
        public static implicit operator string(SendToFolder sendToFolder) { string dir = Path.GetDirectoryName(sendToFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return sendToFolder.folder; }
        /// <summary>
        /// get <see cref="SendToFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is SendToFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a StartMenu folder
    /// </summary>
    public readonly struct StartMenuFolder
    {
        /// <summary>
        /// share a new StartMenu folder
        /// </summary>
        public StartMenuFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="startMenuFolder"/>
        /// </summary>
        /// <param name="startMenuFolder"></param>
        public static implicit operator string(StartMenuFolder startMenuFolder) { string dir = Path.GetDirectoryName(startMenuFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return startMenuFolder.folder; }
        /// <summary>
        /// get <see cref="StartMenuFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is StartMenuFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a MyMusic folder
    /// </summary>
    public readonly struct MyMusicFolder
    {
        /// <summary>
        /// share a new MyMusic folder
        /// </summary>
        public MyMusicFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="myMusicFolder"/>
        /// </summary>
        /// <param name="myMusicFolder"></param>
        public static implicit operator string(MyMusicFolder myMusicFolder) { string dir = Path.GetDirectoryName(myMusicFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return myMusicFolder.folder; }
        /// <summary>
        /// get <see cref="MyMusicFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is MyMusicFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a MyVideos folder
    /// </summary>
    public readonly struct MyVideosFolder
    {
        /// <summary>
        /// share a new MyVideos folder
        /// </summary>
        public MyVideosFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="myVideosFolder"/>
        /// </summary>
        /// <param name="myVideosFolder"></param>
        public static implicit operator string(MyVideosFolder myVideosFolder) { string dir = Path.GetDirectoryName(myVideosFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return myVideosFolder.folder; }
        /// <summary>
        /// get <see cref="MyVideosFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is MyVideosFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a DesktopDirectory folder
    /// </summary>
    public readonly struct DesktopDirectoryFolder
    {
        /// <summary>
        /// share a new DesktopDirectory folder
        /// </summary>
        public DesktopDirectoryFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="desktopDirectoryFolder"/>
        /// </summary>
        /// <param name="desktopDirectoryFolder"></param>
        public static implicit operator string(DesktopDirectoryFolder desktopDirectoryFolder) { string dir = Path.GetDirectoryName(desktopDirectoryFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return desktopDirectoryFolder.folder; }
        /// <summary>
        /// get <see cref="DesktopDirectoryFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is DesktopDirectoryFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a MyComputer folder
    /// </summary>
    public readonly struct MyComputerFolder
    {
        /// <summary>
        /// share a new MyComputer folder
        /// </summary>
        public MyComputerFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="myComputerFolder"/>
        /// </summary>
        /// <param name="myComputerFolder"></param>
        public static implicit operator string(MyComputerFolder myComputerFolder) { string dir = Path.GetDirectoryName(myComputerFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return myComputerFolder.folder; }
        /// <summary>
        /// get <see cref="MyComputerFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is MyComputerFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a NetworkShortcuts folder
    /// </summary>
    public readonly struct NetworkShortcutsFolder
    {
        /// <summary>
        /// share a new NetworkShortcuts folder
        /// </summary>
        public NetworkShortcutsFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.NetworkShortcuts);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="networkShortcutsFolder"/>
        /// </summary>
        /// <param name="networkShortcutsFolder"></param>
        public static implicit operator string(NetworkShortcutsFolder networkShortcutsFolder) { string dir = Path.GetDirectoryName(networkShortcutsFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return networkShortcutsFolder.folder; }
        /// <summary>
        /// get <see cref="NetworkShortcutsFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is NetworkShortcutsFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a Fonts folder
    /// </summary>
    public readonly struct FontsFolder
    {
        /// <summary>
        /// share a new Fonts folder
        /// </summary>
        public FontsFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="fontsFolder"/>
        /// </summary>
        /// <param name="fontsFolder"></param>
        public static implicit operator string(FontsFolder fontsFolder) { string dir = Path.GetDirectoryName(fontsFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return fontsFolder.folder; }
        /// <summary>
        /// get <see cref="FontsFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is FontsFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a Templates folder
    /// </summary>
    public readonly struct TemplatesFolder
    {
        /// <summary>
        /// share a new Templates folder
        /// </summary>
        public TemplatesFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Templates);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="templatesFolder"/>
        /// </summary>
        /// <param name="templatesFolder"></param>
        public static implicit operator string(TemplatesFolder templatesFolder) { string dir = Path.GetDirectoryName(templatesFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return templatesFolder.folder; }
        /// <summary>
        /// get <see cref="TemplatesFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is TemplatesFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonStartMenu folder
    /// </summary>
    public readonly struct CommonStartMenuFolder
    {
        /// <summary>
        /// share a new CommonStartMenu folder
        /// </summary>
        public CommonStartMenuFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonStartMenuFolder"/>
        /// </summary>
        /// <param name="commonStartMenuFolder"></param>
        public static implicit operator string(CommonStartMenuFolder commonStartMenuFolder) { string dir = Path.GetDirectoryName(commonStartMenuFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonStartMenuFolder.folder; }
        /// <summary>
        /// get <see cref="CommonStartMenuFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonStartMenuFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonPrograms folder
    /// </summary>
    public readonly struct CommonProgramsFolder
    {
        /// <summary>
        /// share a new CommonPrograms folder
        /// </summary>
        public CommonProgramsFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonProgramsFolder"/>
        /// </summary>
        /// <param name="commonProgramsFolder"></param>
        public static implicit operator string(CommonProgramsFolder commonProgramsFolder) { string dir = Path.GetDirectoryName(commonProgramsFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonProgramsFolder.folder; }
        /// <summary>
        /// get <see cref="CommonProgramsFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonProgramsFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonStartup folder
    /// </summary>
    public readonly struct CommonStartupFolder
    {
        /// <summary>
        /// share a new CommonStartup folder
        /// </summary>
        public CommonStartupFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonStartupFolder"/>
        /// </summary>
        /// <param name="commonStartupFolder"></param>
        public static implicit operator string(CommonStartupFolder commonStartupFolder) { string dir = Path.GetDirectoryName(commonStartupFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonStartupFolder.folder; }
        /// <summary>
        /// get <see cref="CommonStartupFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonStartupFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonDesktopDirectory folder
    /// </summary>
    public readonly struct CommonDesktopDirectoryFolder
    {
        /// <summary>
        /// share a new CommonDesktopDirectory folder
        /// </summary>
        public CommonDesktopDirectoryFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonDesktopDirectoryFolder"/>
        /// </summary>
        /// <param name="commonDesktopDirectoryFolder"></param>
        public static implicit operator string(CommonDesktopDirectoryFolder commonDesktopDirectoryFolder) { string dir = Path.GetDirectoryName(commonDesktopDirectoryFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonDesktopDirectoryFolder.folder; }
        /// <summary>
        /// get <see cref="CommonDesktopDirectoryFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonDesktopDirectoryFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a ApplicationData folder
    /// </summary>
    public readonly struct ApplicationDataFolder
    {
        /// <summary>
        /// share a new ApplicationData folder
        /// </summary>
        public ApplicationDataFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="applicationDataFolder"/>
        /// </summary>
        /// <param name="applicationDataFolder"></param>
        public static implicit operator string(ApplicationDataFolder applicationDataFolder) { string dir = Path.GetDirectoryName(applicationDataFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return applicationDataFolder.folder; }
        /// <summary>
        /// get <see cref="ApplicationDataFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is ApplicationDataFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a PrinterShortcuts folder
    /// </summary>
    public readonly struct PrinterShortcutsFolder
    {
        /// <summary>
        /// share a new PrinterShortcuts folder
        /// </summary>
        public PrinterShortcutsFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.PrinterShortcuts);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="printerShortcutsFolder"/>
        /// </summary>
        /// <param name="printerShortcutsFolder"></param>
        public static implicit operator string(PrinterShortcutsFolder printerShortcutsFolder) { string dir = Path.GetDirectoryName(printerShortcutsFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return printerShortcutsFolder.folder; }
        /// <summary>
        /// get <see cref="PrinterShortcutsFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is PrinterShortcutsFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a LocalApplicationData folder
    /// </summary>
    public readonly struct LocalApplicationDataFolder
    {
        /// <summary>
        /// share a new LocalApplicationData folder
        /// </summary>
        public LocalApplicationDataFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="localApplicationDataFolder"/>
        /// </summary>
        /// <param name="localApplicationDataFolder"></param>
        public static implicit operator string(LocalApplicationDataFolder localApplicationDataFolder) { string dir = Path.GetDirectoryName(localApplicationDataFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return localApplicationDataFolder.folder; }
        /// <summary>
        /// get <see cref="LocalApplicationDataFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is LocalApplicationDataFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a InternetCache folder
    /// </summary>
    public readonly struct InternetCacheFolder
    {
        /// <summary>
        /// share a new InternetCache folder
        /// </summary>
        public InternetCacheFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="internetCacheFolder"/>
        /// </summary>
        /// <param name="internetCacheFolder"></param>
        public static implicit operator string(InternetCacheFolder internetCacheFolder) { string dir = Path.GetDirectoryName(internetCacheFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return internetCacheFolder.folder; }
        /// <summary>
        /// get <see cref="InternetCacheFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is InternetCacheFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a Cookies folder
    /// </summary>
    public readonly struct CookiesFolder
    {
        /// <summary>
        /// share a new Cookies folder
        /// </summary>
        public CookiesFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="cookiesFolder"/>
        /// </summary>
        /// <param name="cookiesFolder"></param>
        public static implicit operator string(CookiesFolder cookiesFolder) { string dir = Path.GetDirectoryName(cookiesFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return cookiesFolder.folder; }
        /// <summary>
        /// get <see cref="CookiesFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CookiesFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a History folder
    /// </summary>
    public readonly struct HistoryFolder
    {
        /// <summary>
        /// share a new History folder
        /// </summary>
        public HistoryFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.History);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="historyFolder"/>
        /// </summary>
        /// <param name="historyFolder"></param>
        public static implicit operator string(HistoryFolder historyFolder) { string dir = Path.GetDirectoryName(historyFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return historyFolder.folder; }
        /// <summary>
        /// get <see cref="HistoryFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is HistoryFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonApplicationData folder
    /// </summary>
    public readonly struct CommonApplicationDataFolder
    {
        /// <summary>
        /// share a new CommonApplicationData folder
        /// </summary>
        public CommonApplicationDataFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonApplicationDataFolder"/>
        /// </summary>
        /// <param name="commonApplicationDataFolder"></param>
        public static implicit operator string(CommonApplicationDataFolder commonApplicationDataFolder) { string dir = Path.GetDirectoryName(commonApplicationDataFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonApplicationDataFolder.folder; }
        /// <summary>
        /// get <see cref="CommonApplicationDataFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonApplicationDataFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a Windows folder
    /// </summary>
    public readonly struct WindowsFolder
    {
        /// <summary>
        /// share a new Windows folder
        /// </summary>
        public WindowsFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="windowsFolder"/>
        /// </summary>
        /// <param name="windowsFolder"></param>
        public static implicit operator string(WindowsFolder windowsFolder) { string dir = Path.GetDirectoryName(windowsFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return windowsFolder.folder; }
        /// <summary>
        /// get <see cref="WindowsFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is WindowsFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a System folder
    /// </summary>
    public readonly struct SystemFolder
    {
        /// <summary>
        /// share a new System folder
        /// </summary>
        public SystemFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.System);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="systemFolder"/>
        /// </summary>
        /// <param name="systemFolder"></param>
        public static implicit operator string(SystemFolder systemFolder) { string dir = Path.GetDirectoryName(systemFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return systemFolder.folder; }
        /// <summary>
        /// get <see cref="SystemFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is SystemFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a ProgramFiles folder
    /// </summary>
    public readonly struct ProgramFilesFolder
    {
        /// <summary>
        /// share a new ProgramFiles folder
        /// </summary>
        public ProgramFilesFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="programFilesFolder"/>
        /// </summary>
        /// <param name="programFilesFolder"></param>
        public static implicit operator string(ProgramFilesFolder programFilesFolder) { string dir = Path.GetDirectoryName(programFilesFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return programFilesFolder.folder; }
        /// <summary>
        /// get <see cref="ProgramFilesFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is ProgramFilesFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a MyPictures folder
    /// </summary>
    public readonly struct MyPicturesFolder
    {
        /// <summary>
        /// share a new MyPictures folder
        /// </summary>
        public MyPicturesFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="myPicturesFolder"/>
        /// </summary>
        /// <param name="myPicturesFolder"></param>
        public static implicit operator string(MyPicturesFolder myPicturesFolder) { string dir = Path.GetDirectoryName(myPicturesFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return myPicturesFolder.folder; }
        /// <summary>
        /// get <see cref="MyPicturesFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is MyPicturesFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a UserProfile folder
    /// </summary>
    public readonly struct UserProfileFolder
    {
        /// <summary>
        /// share a new UserProfile folder
        /// </summary>
        public UserProfileFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="userProfileFolder"/>
        /// </summary>
        /// <param name="userProfileFolder"></param>
        public static implicit operator string(UserProfileFolder userProfileFolder) { string dir = Path.GetDirectoryName(userProfileFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return userProfileFolder.folder; }
        /// <summary>
        /// get <see cref="UserProfileFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is UserProfileFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a SystemX86 folder
    /// </summary>
    public readonly struct SystemX86Folder
    {
        /// <summary>
        /// share a new SystemX86 folder
        /// </summary>
        public SystemX86Folder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="systemX86Folder"/>
        /// </summary>
        /// <param name="systemX86Folder"></param>
        public static implicit operator string(SystemX86Folder systemX86Folder) { string dir = Path.GetDirectoryName(systemX86Folder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return systemX86Folder.folder; }
        /// <summary>
        /// get <see cref="SystemX86Folder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is SystemX86Folder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a ProgramFilesX86 folder
    /// </summary>
    public readonly struct ProgramFilesX86Folder
    {
        /// <summary>
        /// share a new ProgramFilesX86 folder
        /// </summary>
        public ProgramFilesX86Folder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="programFilesX86Folder"/>
        /// </summary>
        /// <param name="programFilesX86Folder"></param>
        public static implicit operator string(ProgramFilesX86Folder programFilesX86Folder) { string dir = Path.GetDirectoryName(programFilesX86Folder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return programFilesX86Folder.folder; }
        /// <summary>
        /// get <see cref="ProgramFilesX86Folder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is ProgramFilesX86Folder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonProgramFiles folder
    /// </summary>
    public readonly struct CommonProgramFilesFolder
    {
        /// <summary>
        /// share a new CommonProgramFiles folder
        /// </summary>
        public CommonProgramFilesFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonProgramFilesFolder"/>
        /// </summary>
        /// <param name="commonProgramFilesFolder"></param>
        public static implicit operator string(CommonProgramFilesFolder commonProgramFilesFolder) { string dir = Path.GetDirectoryName(commonProgramFilesFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonProgramFilesFolder.folder; }
        /// <summary>
        /// get <see cref="CommonProgramFilesFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonProgramFilesFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonProgramFilesX86 folder
    /// </summary>
    public readonly struct CommonProgramFilesX86Folder
    {
        /// <summary>
        /// share a new CommonProgramFilesX86 folder
        /// </summary>
        public CommonProgramFilesX86Folder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonProgramFilesX86Folder"/>
        /// </summary>
        /// <param name="commonProgramFilesX86Folder"></param>
        public static implicit operator string(CommonProgramFilesX86Folder commonProgramFilesX86Folder) { string dir = Path.GetDirectoryName(commonProgramFilesX86Folder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonProgramFilesX86Folder.folder; }
        /// <summary>
        /// get <see cref="CommonProgramFilesX86Folder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonProgramFilesX86Folder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonTemplates folder
    /// </summary>
    public readonly struct CommonTemplatesFolder
    {
        /// <summary>
        /// share a new CommonTemplates folder
        /// </summary>
        public CommonTemplatesFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonTemplates);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonTemplatesFolder"/>
        /// </summary>
        /// <param name="commonTemplatesFolder"></param>
        public static implicit operator string(CommonTemplatesFolder commonTemplatesFolder) { string dir = Path.GetDirectoryName(commonTemplatesFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonTemplatesFolder.folder; }
        /// <summary>
        /// get <see cref="CommonTemplatesFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonTemplatesFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonDocuments folder
    /// </summary>
    public readonly struct CommonDocumentsFolder
    {
        /// <summary>
        /// share a new CommonDocuments folder
        /// </summary>
        public CommonDocumentsFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonDocumentsFolder"/>
        /// </summary>
        /// <param name="commonDocumentsFolder"></param>
        public static implicit operator string(CommonDocumentsFolder commonDocumentsFolder) { string dir = Path.GetDirectoryName(commonDocumentsFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonDocumentsFolder.folder; }
        /// <summary>
        /// get <see cref="CommonDocumentsFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonDocumentsFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonAdminTools folder
    /// </summary>
    public readonly struct CommonAdminToolsFolder
    {
        /// <summary>
        /// share a new CommonAdminTools folder
        /// </summary>
        public CommonAdminToolsFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonAdminTools);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonAdminToolsFolder"/>
        /// </summary>
        /// <param name="commonAdminToolsFolder"></param>
        public static implicit operator string(CommonAdminToolsFolder commonAdminToolsFolder) { string dir = Path.GetDirectoryName(commonAdminToolsFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonAdminToolsFolder.folder; }
        /// <summary>
        /// get <see cref="CommonAdminToolsFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonAdminToolsFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a AdminTools folder
    /// </summary>
    public readonly struct AdminToolsFolder
    {
        /// <summary>
        /// share a new AdminTools folder
        /// </summary>
        public AdminToolsFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.AdminTools);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="adminToolsFolder"/>
        /// </summary>
        /// <param name="adminToolsFolder"></param>
        public static implicit operator string(AdminToolsFolder adminToolsFolder) { string dir = Path.GetDirectoryName(adminToolsFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return adminToolsFolder.folder; }
        /// <summary>
        /// get <see cref="AdminToolsFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is AdminToolsFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonMusic folder
    /// </summary>
    public readonly struct CommonMusicFolder
    {
        /// <summary>
        /// share a new CommonMusic folder
        /// </summary>
        public CommonMusicFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonMusicFolder"/>
        /// </summary>
        /// <param name="commonMusicFolder"></param>
        public static implicit operator string(CommonMusicFolder commonMusicFolder) { string dir = Path.GetDirectoryName(commonMusicFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonMusicFolder.folder; }
        /// <summary>
        /// get <see cref="CommonMusicFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonMusicFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonPictures folder
    /// </summary>
    public readonly struct CommonPicturesFolder
    {
        /// <summary>
        /// share a new CommonPictures folder
        /// </summary>
        public CommonPicturesFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonPicturesFolder"/>
        /// </summary>
        /// <param name="commonPicturesFolder"></param>
        public static implicit operator string(CommonPicturesFolder commonPicturesFolder) { string dir = Path.GetDirectoryName(commonPicturesFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonPicturesFolder.folder; }
        /// <summary>
        /// get <see cref="CommonPicturesFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonPicturesFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonVideos folder
    /// </summary>
    public readonly struct CommonVideosFolder
    {
        /// <summary>
        /// share a new CommonVideos folder
        /// </summary>
        public CommonVideosFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonVideosFolder"/>
        /// </summary>
        /// <param name="commonVideosFolder"></param>
        public static implicit operator string(CommonVideosFolder commonVideosFolder) { string dir = Path.GetDirectoryName(commonVideosFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonVideosFolder.folder; }
        /// <summary>
        /// get <see cref="CommonVideosFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonVideosFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a Resources folder
    /// </summary>
    public readonly struct ResourcesFolder
    {
        /// <summary>
        /// share a new Resources folder
        /// </summary>
        public ResourcesFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Resources);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="resourcesFolder"/>
        /// </summary>
        /// <param name="resourcesFolder"></param>
        public static implicit operator string(ResourcesFolder resourcesFolder) { string dir = Path.GetDirectoryName(resourcesFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return resourcesFolder.folder; }
        /// <summary>
        /// get <see cref="ResourcesFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is ResourcesFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a LocalizedResources folder
    /// </summary>
    public readonly struct LocalizedResourcesFolder
    {
        /// <summary>
        /// share a new LocalizedResources folder
        /// </summary>
        public LocalizedResourcesFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalizedResources);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="localizedResourcesFolder"/>
        /// </summary>
        /// <param name="localizedResourcesFolder"></param>
        public static implicit operator string(LocalizedResourcesFolder localizedResourcesFolder) { string dir = Path.GetDirectoryName(localizedResourcesFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return localizedResourcesFolder.folder; }
        /// <summary>
        /// get <see cref="LocalizedResourcesFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is LocalizedResourcesFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CommonOemLinks folder
    /// </summary>
    public readonly struct CommonOemLinksFolder
    {
        /// <summary>
        /// share a new CommonOemLinks folder
        /// </summary>
        public CommonOemLinksFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonOemLinks);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="commonOemLinksFolder"/>
        /// </summary>
        /// <param name="commonOemLinksFolder"></param>
        public static implicit operator string(CommonOemLinksFolder commonOemLinksFolder) { string dir = Path.GetDirectoryName(commonOemLinksFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return commonOemLinksFolder.folder; }
        /// <summary>
        /// get <see cref="CommonOemLinksFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CommonOemLinksFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a CDBurning folder
    /// </summary>
    public readonly struct CDBurningFolder
    {
        /// <summary>
        /// share a new CDBurning folder
        /// </summary>
        public CDBurningFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.CDBurning);
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="cDBurningFolder"/>
        /// </summary>
        /// <param name="cDBurningFolder"></param>
        public static implicit operator string(CDBurningFolder cDBurningFolder) { string dir = Path.GetDirectoryName(cDBurningFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return cDBurningFolder.folder; }
        /// <summary>
        /// get <see cref="CDBurningFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CDBurningFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }

    /// <summary>
    /// represents a Current folder
    /// </summary>
    public readonly struct CurrentFolder
    {
        /// <summary>
        /// share a new Current folder
        /// </summary>
        public CurrentFolder() { }
        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private readonly string folder = Environment.CurrentDirectory;
        /// <summary>
        /// to string
        /// </summary>
        /// <returns>folder path</returns>
        public override string ToString() { if (EasyFolder.AutoCreateFolder) { string dir = Path.GetDirectoryName(folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } } return folder; }
        /// <summary>
        /// combines an array of strings into a path. 
        /// </summary>
        /// <param name="paths">an array of parts of the path.</param>
        /// <exception cref="System.ArgumentException">one of the strings in the array contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">one of the strings in the array is null.</exception>
        /// <returns>The combined paths.</returns>
        public EasyFolder Combine(params string[] paths) { string folderCombine = Path.Combine(new[] { folder }.Concat(paths).ToArray()); return new EasyFolder(folderCombine); }
        /// <summary>
        /// get folder string from <paramref name="currentFolder"/>
        /// </summary>
        /// <param name="currentFolder"></param>
        public static implicit operator string(CurrentFolder currentFolder) { string dir = Path.GetDirectoryName(currentFolder.folder); if (Directory.Exists(dir) == false) { Directory.CreateDirectory(dir); } return currentFolder.folder; }
        /// <summary>
        /// get <see cref="CurrentFolder"/> hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() { return folder.GetHashCode(); }
        /// <summary>
        /// compare two objects for equality
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns>compare result</returns>
        public override bool Equals(object obj) { return obj is CurrentFolder folderInfo && folderInfo.GetHashCode() == GetHashCode(); }
    }



    /// <summary>
    /// folder type converter
    /// </summary>
    public class EasyFolderTypeConverter : TypeConverter
    {

        /// <summary>
        /// CanConvertFrom
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// CanConvertTo
        /// </summary>
        /// <param name="context"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
        }
        /// <summary>
        /// ConvertFrom
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return value is not string stringValue ? base.ConvertFrom(context, culture, value) : new EasyFolder(stringValue);
        }

        /// <summary>
        /// ConvertTo
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value is EasyFolder folder)
                {
                    return folder.ToString();
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
