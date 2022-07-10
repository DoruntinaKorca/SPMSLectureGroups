using Application.DTOs.LectureGroupDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AsyncDataService
{
    public interface IMessageBusClient
    {
        void PublishNewLectureGroup(LectureGroupPublishedDto lectureGroupPublishedDto);
    }
}
