using System.Collections.Generic;

namespace Academy.Domain
{
    public interface ICourseRepository
    {
        void Create(Domain.Course course);
        List<Course> GetAll();
        Course GetBy(int id);
        void Delete(int id);
    }
}
