using Academy.Domain;
using System.Collections.Generic;

namespace Academy.Application
{
    public interface ICourseService
    {
        int Create(CreateCourseViewModel command);
        void Edit(EditCourseViewModel command);
        void Delete(int id);
        List<Course> GetAll();
    }
}
