using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using UniversityAPI.Application.Contract;
using UniversityAPI.Application.DTOs.Request;
using UniversityAPI.Application.DTOs.Response;
using UniversityAPI.Domain.Entities;
using UniversityAPI.Domain.Interfaces;

namespace UniversityAPI.Application.Services
{
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepo;

        public LectureService(ILectureRepository lectureRepo)
        {
            _lectureRepo = lectureRepo;
        }

        public async Task<LectureResponse> CreateLectureAsync(LectureRequest lectureRequest)
        {
            var Lectures = lectureRequest.Adapt<Lecture>();

           await _lectureRepo.AddAsync(Lectures);

            return Lectures.Adapt<LectureResponse>();
        }

        public async Task<LectureResponse> GetLectureAsync(int id)
        {
            
            var Lectures = await _lectureRepo.GetAsync(id);

            return Lectures.Adapt<LectureResponse>();
        }

        public async Task<IEnumerable<LectureResponse>> GetAllAsync()
        {
            var Lectures = await _lectureRepo.GetAllAsync();

            return Lectures.Adapt<IEnumerable<LectureResponse>>();
        }

    }
}
