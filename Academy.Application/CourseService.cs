using Academy.Domain;

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
            var course = new Course(command.Id, command.Name, command.IsOnline, command.Tuition, command.Instructor);

            _courseRepository.Create(course);

            return course.Id;
        }
    }
}
