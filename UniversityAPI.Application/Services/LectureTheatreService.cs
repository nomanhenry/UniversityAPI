using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Application.Contract;
using UniversityAPI.Application.DTOs;
using UniversityAPI.Application.DTOs.Request;
using UniversityAPI.Application.DTOs.Response;
using UniversityAPI.Domain.Entities;
using UniversityAPI.Domain.Interfaces;

namespace UniversityAPI.Application.Services
{
    public class LectureTheatreService : ILectureTheatreService
    {
        private readonly ILectureTheatreRepository _lectureTheatreRepo;

        public LectureTheatreService(ILectureTheatreRepository lectureTheatreRepo)
        {
            _lectureTheatreRepo = lectureTheatreRepo;
        }

        public async Task<LectureTheatreResponse> CreateLectureTheatreAsync(LectureTheatreRequest lectureTheatreRequest)
        {
            var Lectures = lectureTheatreRequest.Adapt<LectureTheatre>();

            await _lectureTheatreRepo.AddAsync(Lectures);

            return Lectures.Adapt<LectureTheatreResponse>();
        }

        public async Task<LectureTheatreResponse> GetLectureTheatreAsync(int id)
        {
            var Lectures = await _lectureTheatreRepo.GetAsync(id);

            return Lectures.Adapt<LectureTheatreResponse>();
        }

        public async Task<IEnumerable<LectureTheatreResponse>> GetAllAsync()
        {
            var Lectures = await _lectureTheatreRepo.GetAllAsync();

            return Lectures.Adapt<IEnumerable<LectureTheatreResponse>>();
        }
    }
}
