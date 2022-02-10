using Academy.Domain;
using Academy.Domain.Exceptions;

namespace Academy.Application
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public int Create(CreateCourseViewModel command)
        {
            if (_courseRepository.GetBy(command.Name) != null)
                throw new DuplicatedCourseNameException();

            var course = new Course(command.Id, command.Name, command.IsOnline, command.Tuition, command.Instructor);

            _courseRepository.Create(course);

            return course.Id;
        }
    }
}
