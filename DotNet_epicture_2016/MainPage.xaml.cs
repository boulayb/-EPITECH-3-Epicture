using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Windows.UI.Xaml.Media.Imaging;

namespace DotNet_epicture_2016
{
    public sealed partial class MainPage : Page
    {
        private ImgurAPI api = new ImgurAPI();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Upload_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UploadPage));
        }

        private async void SearchImageClicked(object sender, RoutedEventArgs e)
        {
            ImageContainer.Children.Clear();
            HttpContent content = await api.getImages(SearchBox.Text, ((ComboBoxItem)SizeBox.SelectedItem).Content.ToString() , ((ComboBoxItem)TypeBox.SelectedItem).Content.ToString(), 1);
            string jsoncontent = content.ReadAsStringAsync().Result;
            ImgurResponse response = JsonConvert.DeserializeObject<ImgurResponse>(jsoncontent);
            foreach (Datum image in response.Data)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(image.Link));
                img.Height = image.Height;
                img.Width = image.Width;
                ImageContainer.Children.Add(img);
            }
        }
    }
}
