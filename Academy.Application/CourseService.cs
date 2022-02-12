﻿using Academy.Domain;
using Academy.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Academy.Application
{
    public class CourseService : ICourseService
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

        public void Edit(EditCourseViewModel command)
        {
            if (_courseRepository.GetBy(command.Id) == null)
                throw new CourseNotExistsException();
            _courseRepository.Delete(command.Id);
            var course = new Course(command.Id, command.Name, command.IsOnline, command.Tuition, command.Instructor);
            _courseRepository.Create(course);
        }

        public void Delete(int id)
        {
            _courseRepository.Delete(id);
        }

        public List<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }
    }
}
