using System;
using System.Collections.Generic;

namespace UniversitySystem.Common
{
    // Інтерфейс для CRUD сервісу (Завдання 3)
    public interface ICrudService<T>
    {
        public void Create(T element); // [cite: 77]
        public T Read(Guid id); // [cite: 78]
        public IEnumerable<T> ReadAll(); // [cite: 79]
        public void Update(T element); // [cite: 80]
        public void Remove(T element); // [cite: 81]
    }
}
