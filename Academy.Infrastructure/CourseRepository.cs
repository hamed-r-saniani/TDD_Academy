using Academy.Domain;
using System.Collections.Generic;

namespace Academy.Infrastructure.Tests.Unit
{
    public class CourseRepository
    {
        public List<Course> Courses = new List<Course>()
        {
            new Course(30,"Asp.Net Core",true,4444,"Hamed Rezaie Saniani")
        };
         
        public void Create(Domain.Course course)
        {
            Courses.Add(course);
        }
    }
}
