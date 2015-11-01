using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace DribbbleForWindowsPhone.Helpers
{
    /// <summary>
    /// A file reader helper class.
    /// </summary>
    public static class FileReader
    {
        /// <summary>
        /// Help to get a file stored in InstalledFolder asynchronously.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <returns>A <see cref="StorageFile"/> object.</returns>
        public static async Task<StorageFile> GetFileFromInstalledFolderAsync(string path)
        {
            return await Package.Current.InstalledLocation.GetFileAsync(path);
        }

        /// <summary>
        /// Read a file from the installed folder in an asynchronous mode.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <returns>Content of the file.</returns>
        public async static Task<string> ReadTextFileFromInstalledFolderAsync(string path)
        {
            StorageFile file = await GetFileFromInstalledFolderAsync(path);

            return await FileIO.ReadTextAsync(file);
        }
    }
}
