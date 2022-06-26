using Application.DTOs.CourseAcademicStaffDto;
using Application.DTOs.LectureDtos;
using Application.DTOs.LectureGroupDtos;
using Application.DTOs.LectureHallDtos;
using Application.DTOs.LGRSDtos;
using Application.DTOs.LocationDtos;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Lecture, LectureDto>()
                .ForPath(dest => dest.AcademicStaff,
               opts => opts.MapFrom(src => src.Course_AcademicStaff.AcademicStaff))
                .ForPath(dest => dest.Course,
               opts => opts.MapFrom(src => src.Course_AcademicStaff.Course));

            CreateMap<Lecture, ScheduleForStudentDto>()
               .ForPath(dest => dest.AcademicStaff,
              opts => opts.MapFrom(src => src.Course_AcademicStaff.AcademicStaff))
               .ForPath(dest => dest.Course,
              opts => opts.MapFrom(src => src.Course_AcademicStaff.Course));

            CreateMap<Lecture, ScheduleForAcademicStaffDto>()
             .ForPath(dest => dest.Course,
            opts => opts.MapFrom(src => src.Course_AcademicStaff.Course));

            CreateMap<Course, CourseDto>();



            CreateMap<AcademicStaff, AcademicStaffDto>();

            CreateMap<Course_AcademicStaff, CourseASDto>();

            CreateMap<Location, LocationDto>();

            CreateMap<LectureGroup,LectureGroupDto>();

            CreateMap<LectureGroup, LectureGroupForLectureDto>();

            CreateMap<LectureGroupRegisteringSeason, LGRSDto>();

            CreateMap<LectureHall, LectureHallDto>();
        }
    }
}
