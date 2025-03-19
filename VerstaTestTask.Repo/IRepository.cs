﻿using VerstaTestTask.Domain;

namespace VerstaTestTask.Repo;

public interface IRepository<T> where T : Entity
{
    public List<T> GetAll();
    public T GetById(Guid id);
    public void Add(T entity);
    public void SaveChanges();
}
