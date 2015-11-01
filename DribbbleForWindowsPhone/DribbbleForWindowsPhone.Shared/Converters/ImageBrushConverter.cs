﻿using DribbbleForWindowsPhone.Helpers;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace DribbbleForWindowsPhone.Converters
{
    /// <summary>
    /// A converter of a Image Path to the BitmapImage object.
    /// </summary>
    public class ImageBrushConverter : IValueConverter
    {
        #region IValueConverter members

        /// <summary>
        /// Convert the ImageFileName to an BitmapImage object.
        /// </summary>
        /// <param name="value">The image file name.</param>
        /// <param name="targetType">BitmapImage</param>
        /// <param name="parameter">The source data being passed to the target.</param>
        /// <param name="language">The language of the conversion.</param>
        /// <returns>The converted value.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            /*
             * TODO: Try to use a totally asynchronous solution.
             * 
             * Uri uri = new Uri(path);
             * 
             * StorageFile file = await FileReader.GetFileFromInstalledFolderAsync(path);
             * 
             * ImageBrush imageBrush = new ImageBrush();
             * 
             * using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
             * {
             *  BitmapImage bitmapImage = new BitmapImage();
             *  
             *  await bitmapImage.SetSourceAsync(fileStream);
             * }
             * 
             * string path = value as string;
             * return imageBrush;
             */

            Uri uri = value as Uri;

            ImageBrush imageBrush = new ImageBrush();

            BitmapImage bitmapImage = new BitmapImage { UriSource = uri };

            imageBrush.ImageSource = bitmapImage;

            return imageBrush;
        }

        /// <summary>
        /// Convert Back the BitmapImage object to the ImageFileName.
        /// </summary>
        /// <param name="value">An BitmapImage object.</param>
        /// <param name="targetType">string</param>
        /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
        /// <param name="language">The language of the conversion.</param>
        /// <returns>The value converted back.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion IValueConverter members
    }
}
