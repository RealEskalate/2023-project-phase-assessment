﻿namespace Application.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task? DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}