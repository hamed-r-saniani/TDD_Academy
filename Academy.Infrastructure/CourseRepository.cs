using Academy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Infrastructure.Tests.Unit
{
    public class CourseRepository : ICourseRepository
    {
        public List<Course> Courses = new List<Course>()
        {
            new Course(30,"Asp.Net Core",true,4444,"Hamed Rezaie Saniani")
        };

        public void Create(Domain.Course course)
        {
            Courses.Add(course);
        }

        public List<Course> GetAll()
        {
            return Courses;
        }

        public Course GetBy(int id)
        {
            return Courses.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            Courses.Remove(GetBy(id));
        }
    }
}
