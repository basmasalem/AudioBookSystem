using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
  public  class AudioCommentService : IAudioCommentService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;

        public AudioCommentService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
        }
        public List<AudioCommentViewModel> GetAudioComments(int AudioId, int UserId,int langId)
        {
            return _repoWrapper.audioCommentRepository.List().Where(x => x.AudioId == AudioId).Select(x => new AudioCommentViewModel
            {
                AudioCommentId=x.AudioCommentId,
                Key=_protector.Protect(x.AudioCommentId.ToString()),
                ClientName=x.Client.FullName,
                Comment=x.Text,
                ClientImage=x.Client.Image,
                Duration= returnPeriod(x.CreationDate, langId),
                CanUpdate=(x.ClientId==UserId && UserId!=0 ? true:false)
            }).ToList();
        }

        public void CreateAudioComment(AudioComment audioComment)
        {
            _repoWrapper.audioCommentRepository.Add(audioComment);
        }

        public AudioComment GetAudioComment(int id)
        {
            return _repoWrapper.audioCommentRepository.Find(id);
        }

        public void UpdateAudioComment(AudioComment AudioComment)
        {
            _repoWrapper.audioCommentRepository.Update(AudioComment);
        }

        public void SaveAudioComment()
        {
            _repoWrapper.Save();
        }

        public void DeleteAudioComment(int id)
        {
            AudioComment audioComment = GetAudioComment(id);
            _repoWrapper.audioCommentRepository.Delete(audioComment);
            SaveAudioComment();
        }

        public string returnPeriod(DateTime dateFrom,int langId)
        {
            var dateTo = DateTime.Now;
            TimeSpan Span = dateTo.Subtract(dateFrom);
            int weeks = 0;
            if (Span.Days <= 7)
            {

                if (Span.Days < 7)
                {
                    if (Span.Days >= 1)
                    {
                        weeks = Span.Days;
                        return langId == 1 ? "منذ" + " " + weeks + " " + "يوم" : weeks + " " + "d" + " " + "ago";
                    }
                    else if (Span.Minutes >= 60)
                    {
                        weeks = Span.Hours;
                        return langId == 1 ? "منذ" + " " + weeks + " " + "ساعه" : weeks + " " + "h" + " " + "ago";
                    }
                    else if (Span.Seconds >= 60)
                    {
                        weeks = Span.Minutes;
                        return langId == 1 ? "منذ" + " " + weeks + " " + "دقيقه" : weeks + " " + "m" + " " + "ago";
                    }
                    else
                    {
                        weeks = Span.Seconds;
                        return langId == 1 ? "منذ" + " " + weeks + " " + "ثانيه" : weeks + " " + "s" + " " + "ago";
                    }

                }
                else
                {
                    weeks = 1;
                    return langId == 1 ? "منذ" + " " + weeks + " " + "اسبوع" : weeks + " " + "w" + " " + "ago";
                }


            }
            else
            {
                int Days = Span.Days - 7 + (int)dateFrom.DayOfWeek;
                int WeekCount = 1;
                int DayCount = 0;

                for (WeekCount = 1; DayCount < Days; WeekCount++)
                {
                    DayCount += 7;
                }

                weeks = WeekCount;
                return langId == 1 ? "منذ" + " " + weeks + " " + "اسبوع" : weeks + " " + "w" + " " + "ago";
            }

        }
    }

    public interface IAudioCommentService
    {
        List<AudioCommentViewModel> GetAudioComments(int AudioId,int UserId,int langId);

        void CreateAudioComment(AudioComment audioComment);
        AudioComment GetAudioComment(int id);
        void UpdateAudioComment(AudioComment AudioComment);
        void SaveAudioComment();
        void DeleteAudioComment(int id);
        string returnPeriod(DateTime dateFrom, int langId);
    }
    }
