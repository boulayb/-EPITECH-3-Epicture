using Newtonsoft.Json;

namespace DotNet_epicture_2016
{

    internal class Tag
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("total_items")]
        public int TotalItems { get; set; }
    }

    internal class Datum
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("datetime")]
        public int Datetime { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("animated")]
        public bool Animated { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("bandwidth")]
        public object Bandwidth { get; set; }

        [JsonProperty("vote")]
        public object Vote { get; set; }

        [JsonProperty("favorite")]
        public bool Favorite { get; set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("account_url")]
        public string AccountUrl { get; set; }

        [JsonProperty("account_id")]
        public int? AccountId { get; set; }

        [JsonProperty("is_ad")]
        public bool IsAd { get; set; }

        [JsonProperty("tags")]
        public Tag[] Tags { get; set; }

        [JsonProperty("in_gallery")]
        public bool InGallery { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("topic_id")]
        public int TopicId { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("comment_count")]
        public int CommentCount { get; set; }

        [JsonProperty("ups")]
        public int Ups { get; set; }

        [JsonProperty("downs")]
        public int Downs { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("is_album")]
        public bool IsAlbum { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("cover_width")]
        public int? CoverWidth { get; set; }

        [JsonProperty("cover_height")]
        public int? CoverHeight { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

        [JsonProperty("images_count")]
        public int? ImagesCount { get; set; }

        [JsonProperty("gifv")]
        public string Gifv { get; set; }

        [JsonProperty("mp4")]
        public string Mp4 { get; set; }

        [JsonProperty("mp4_size")]
        public int? Mp4Size { get; set; }

        [JsonProperty("looping")]
        public bool? Looping { get; set; }
    }

    internal class ImgurResponse
    {

        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }

}

namespace DotNet_epicture_2016
{

    internal class Data
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("datetime")]
        public int Datetime { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("animated")]
        public bool Animated { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("bandwidth")]
        public int Bandwidth { get; set; }

        [JsonProperty("vote")]
        public object Vote { get; set; }

        [JsonProperty("favorite")]
        public bool Favorite { get; set; }

        [JsonProperty("nsfw")]
        public object Nsfw { get; set; }

        [JsonProperty("section")]
        public object Section { get; set; }

        [JsonProperty("account_url")]
        public object AccountUrl { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("is_ad")]
        public bool IsAd { get; set; }

        [JsonProperty("tags")]
        public object[] Tags { get; set; }

        [JsonProperty("in_gallery")]
        public bool InGallery { get; set; }

        [JsonProperty("deletehash")]
        public string Deletehash { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }

    internal class ImgurResponseUpload
    {

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }

}
