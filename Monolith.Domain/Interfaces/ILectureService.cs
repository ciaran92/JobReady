using System.Collections.Generic;
using Monolith.Domain.Models.Lecture;

namespace Monolith.Domain.Interfaces
{
    public interface ILectureService
    {
        bool CreateLecture(int topicId, List<CreateLectureModel> lecturesForCreation);
    }
}