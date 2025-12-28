using System;
using System.Collections;
using System.Collections.Concurrent; 
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading; 
using System.Threading.Tasks;

namespace UniversitySystem.Common
{
    
    public class UniversityCrudServiceAsync<T> : ICrudServiceAsync<T> where T : Person
    {
        
        private readonly ConcurrentDictionary<Guid, T> _storage = new ConcurrentDictionary<Guid, T>();

        
        private static readonly SemaphoreSlim FileSemaphore = new SemaphoreSlim(1, 1); 

       

        public Task<bool> CreateAsync(T element)
        {
            if (element.Id == Guid.Empty)
                element.Id = Guid.NewGuid();

           
            bool result = _storage.TryAdd(element.Id, element);
            return Task.FromResult(result);
        }

        public Task<T> ReadAsync(Guid id)
        {
            
            if (_storage.TryGetValue(id, out T element))
            {
                return Task.FromResult(element);
            }
            throw new KeyNotFoundException($"Елемент з ID {id} не знайдено.");
        }

        public Task<IEnumerable<T>> ReadAllAsync()
        {
            return Task.FromResult(_storage.Values.AsEnumerable());
        }

       
        public Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
        {
            var elements = _storage.Values
                .Skip((page - 1) * amount) 
                .Take(amount)            
                .AsEnumerable();

            return Task.FromResult(elements);
        }

        public Task<bool> UpdateAsync(T element)
        {
            if (_storage.ContainsKey(element.Id))
            {
               
                _storage.TryUpdate(element.Id, element, _storage[element.Id]); 
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> RemoveAsync(T element)
        {
           
            return Task.FromResult(_storage.TryRemove(element.Id, out _));
        }

       
        public async Task<bool> SaveAsync(string filePath)
        {
            await FileSemaphore.WaitAsync(); 
            try
            {
                var jsonString = JsonSerializer.Serialize(_storage.Values.ToList(), new JsonSerializerOptions { WriteIndented = true });
                
                await File.WriteAllTextAsync(filePath, jsonString);
                Console.WriteLine($"[SAVE ASYNC] Дані успішно збережено у файл: {filePath}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SAVE ASYNC ERROR] {ex.Message}");
                return false;
            }
            finally
            {
                FileSemaphore.Release(); 
            }
        }

       
        public async Task LoadAsync(string filePath)
        {
            await FileSemaphore.WaitAsync();
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"[LOAD ASYNC] Файл не знайдено: {filePath}. Пропуск завантаження.");
                    return;
                }

                var jsonString = await File.ReadAllTextAsync(filePath);
                var loadedList = JsonSerializer.Deserialize<List<T>>(jsonString);

                if (loadedList != null)
                {
                    _storage.Clear();
                    foreach (var item in loadedList)
                    {
                        if (item.Id == Guid.Empty) item.Id = Guid.NewGuid();
                        _storage.TryAdd(item.Id, item);
                    }
                    Console.WriteLine($"[LOAD ASYNC] Успішно завантажено {_storage.Count} елементів.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LOAD ASYNC ERROR] Не вдалося завантажити дані: {ex.Message}");
            }
            finally
            {
                FileSemaphore.Release();
            }
        }

        
        public IEnumerator<T> GetEnumerator() => _storage.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
