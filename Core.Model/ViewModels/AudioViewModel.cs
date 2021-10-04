using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
    public class AudioViewModel
    {
        public int AudioId { get; set; }
        public string BookNameAr { get; set; }
        public string BookNameEn { get; set; }
        public string AuthorNameAr { get; set; }
        public string AuthorNameEn { get; set; }
        public string PublisherNameAr { get; set; }
        public string PublisherNameEn { get; set; }
        public string PublisherImage { get; set; }
        public string BookImage { get; set; }
        public string AudioSrc { get; set; }

        public string AuthorImage { get; set; }
        public string CategoryNameAr { get; set; }
        public string AudioTypeNameAr { get; set; }
        public string CategoryNameEn { get; set; }
        public string AudioTypeNameEn { get; set; }
        public string AudioTypeImage { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public string Key { get; set; }
        public List<int> ClientLikeIds { get; set; }
        public List<int> PlaylistClientIds { get; set; }
        public List<AudioCommentViewModel> AudioComments { get; set; }

        public string ArticleUrl { get; set; }
        public string VideoUrl { get; set; }
        public PublishType PublishType { get; set; }
        public UploadType UploadType { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }   //user ,client
        public string CreationDate { get; set; }
        public int ListenerCount { get; set; }
        public decimal RatingCount { get; set; }
        public string CityNameAr { get; set; }
        public string CityNameEn { get; set; }
        public string BioAr { get; set; }
        public string BioEn { get; set; }
        public int AudioCount { get; set; }

    }

    public class AudioCommentViewModel
    {
        public int AudioCommentId { get; set; }
        public string Key { get; set; }
        public string Duration { get; set; }
        public string ClientName { get; set; }
        public string ClientImage { get; set; }
        public string Comment { get; set; }
        public bool CanUpdate { get; set; }

    }
    public class AudioRateViewModel
    {
        public decimal TotalRate { get; set; }
        public decimal ClientRate { get; set; }
        public int RateCount { get; set; }
        public List<ClientAudioRateViewModel> ClientRates { get; set; }
    }
    public class ClientAudioRateViewModel
    {
        public decimal Rate { get; set; }
        public string Image { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string RateText{ get; set; }


    }
}
