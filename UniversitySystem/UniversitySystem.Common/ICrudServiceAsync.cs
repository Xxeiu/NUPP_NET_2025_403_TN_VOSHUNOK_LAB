using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversitySystem.Common
{
    // Інтерфейс для асинхронного CRUD сервісу з підтримкою IEnumerable (Завдання 1)
    public interface ICrudServiceAsync<T> : IEnumerable<T>
    {
        public Task<bool> CreateAsync(T element);
        public Task<T> ReadAsync(Guid id);
        public Task<IEnumerable<T>> ReadAllAsync();

        // Метод з пагінацією
        public Task<IEnumerable<T>> ReadAllAsync(int page, int amount); 

        public Task<bool> UpdateAsync(T element);
        public Task<bool> RemoveAsync(T element);
        public Task<bool> SaveAsync(string filePath); // Зберігає колекцію асинхронно
    }
}
