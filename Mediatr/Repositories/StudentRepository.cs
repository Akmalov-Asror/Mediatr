﻿using Mediatr3.Data;
using Mediatr3.Domains;
using Mediatr3.Interface;
using Microsoft.EntityFrameworkCore;

namespace Mediatr3.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _dbContext;

    public StudentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
    {
        var result = _dbContext.Students.Add(studentDetails);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<int> DeleteStudentAsync(int Id)
    {
        var filteredData = _dbContext.Students.Where(x => x.Id == Id).FirstOrDefault();
        _dbContext.Students.Remove(filteredData);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<StudentDetails> GetStudentByIdAsync(int Id)
    {
        return await _dbContext.Students.Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<List<StudentDetails>> GetStudentListAsync()
    {
        return await _dbContext.Students.ToListAsync();
    }

    public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
    {
        _dbContext.Students.Update(studentDetails);
        return await _dbContext.SaveChangesAsync();
    }
}