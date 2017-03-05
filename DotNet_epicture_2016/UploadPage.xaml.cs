using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DotNet_epicture_2016
{

    public sealed partial class UploadPage : Page
    {
        private Windows.Storage.StorageFile fileSelected = null;
        private ImgurAPI api = new ImgurAPI();

        public UploadPage()
        {
            this.InitializeComponent();
        }

        public async Task<byte[]> FileToByte(StorageFile file)
        {
            byte[] fileBytes = null;
            using (IRandomAccessStreamWithContentType stream = await file.OpenReadAsync())
            {
                fileBytes = new byte[stream.Size];
                using (DataReader reader = new DataReader(stream))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    reader.ReadBytes(fileBytes);
                }
            }

            return fileBytes;
        }
        private void BackToMain_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void FilePickerClicked(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the pic1ked file
                PickFile.Content = file.Name;
                fileSelected = file;
            }
        }

        private async void UploadImageButtonClicked(object sender, RoutedEventArgs e)
        {
            if (fileSelected != null) {
                byte[] file = await FileToByte(fileSelected);
                HttpResponseMessage ret = await api.uploadFile(file, TitleBox.Text, DescriptionBox.Text);
                HttpContent content = ret.Content;
                string jsoncontent = content.ReadAsStringAsync().Result;
                ImgurResponseUpload response = JsonConvert.DeserializeObject<ImgurResponseUpload>(jsoncontent);
                if (response.Status == 200)
                {
                    ContentDialog successUpload = new ContentDialog()
                    {
                        Title = "The upload was successful",
                        Content = response.Data.Link,
                        PrimaryButtonText = "Ok"
                    };

                    await successUpload.ShowAsync();
                }
                else
                {
                    ContentDialog failureUpload = new ContentDialog()
                    {
                        Title = "The upload failed",
                        Content = response.Status,
                        PrimaryButtonText = "Ok"
                    };

                    await failureUpload.ShowAsync();
                }
            }
        }
    }
}
