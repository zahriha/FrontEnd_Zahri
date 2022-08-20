﻿using FrontEnd.Models;

namespace FrontEnd_Zahri.Services
{
    public interface ICourse
    {
        Task<IEnumerable<Course>> GetAll(string token);
        Task<Course> GetById(int id);
        Task<Course> Insert(Course obj);
        Task<Course> Update(Course obj);
        Task Delete(int id);
        Task<IEnumerable<Course>> GetByName(string name);
    }
}
