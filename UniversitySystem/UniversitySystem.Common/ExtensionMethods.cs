namespace UniversitySystem.Common
{
    // Статичний клас для методів розширення
    public static class ExtensionMethods
    {
        // Метод розширення (Завдання 2)
        // Ключове слово 'this' вказує, що це метод розширення для типу Person
        public static string ToFullName(this Person person)
        {
            return $"{person.FirstName} {person.LastName}";
        }
    }
}
