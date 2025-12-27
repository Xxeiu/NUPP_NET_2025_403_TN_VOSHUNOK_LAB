using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversitySystem.Common
{
    // Реалізація generic CRUD сервісу (Завдання 3)
    // Обмеження where T : Person додано для коректної роботи з властивістю Id
    public class UniversityCrudService<T> : ICrudService<T> where T : Person
    {
        // Використання Dictionary як вбудованої колекції .NET для зберігання даних
        private readonly Dictionary<Guid, T> _storage = new Dictionary<Guid, T>();

        public void Create(T element)
        {
            if (element.Id == Guid.Empty) element.Id = Guid.NewGuid();
            _storage.Add(element.Id, element);
            Console.WriteLine($"[CRUD] Додано новий елемент: {element.Id}");
        }

        public T Read(Guid id)
        {
            if (_storage.ContainsKey(id))
            {
                return _storage[id];
            }
            throw new KeyNotFoundException($"Елемент з ID {id} не знайдено.");
        }

        public IEnumerable<T> ReadAll()
        {
            return _storage.Values;
        }

        public void Update(T element)
        {
            if (!_storage.ContainsKey(element.Id))
            {
                throw new KeyNotFoundException($"Елемент для оновлення з ID {element.Id} не знайдено.");
            }
            // Оновлення посилання на об'єкт у словнику
            _storage[element.Id] = element;
            Console.WriteLine($"[CRUD] Оновлено елемент: {element.Id}");
        }

        public void Remove(T element)
        {
            if (_storage.Remove(element.Id))
            {
                Console.WriteLine($"[CRUD] Видалено елемент: {element.Id}");
            }
            else
            {
                throw new KeyNotFoundException($"Елемент для видалення з ID {element.Id} не знайдено.");
            }
        }
    }
}
