using System;
using System.Linq;
using System.Reflection;
using TheChest.Tests.Common.Items.Interfaces;
using TheChest.Tests.Common.Extensions;

namespace TheChest.Tests.Common.Items
{
    public sealed class ItemFactory<T> : IItemFactory<T>
    {
        public T CreateDefault()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type) ??
                throw new InvalidOperationException($"Could not create instance of type {type.FullName}");

            return (T)instance;
        }

        public T CreateRandom()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type) ??
                throw new InvalidOperationException($"Could not create instance of type {type.FullName}");

            var instanceType = instance.GetType();
            if(instanceType.IsEnum || instanceType.IsPrimitive)
            {
                if (instanceType.IsEnum)
                {
                    var values = ((T[])instanceType.GetEnumValues()).Skip(1).ToArray();
                    values.Shuffle();
                    return (T)values.GetValue(0)!;
                }
                return SetRandomValue<T>(instanceType);
            }

            var fields = instanceType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                field.SetValue(instance, ItemFactory<T>.SetRandomValue<dynamic>(field.FieldType));
            }
            return (T)instance;
        }

        public T[] CreateMany(int amount)
        {
            return Enumerable.Repeat(CreateDefault(), amount).ToArray();
        }

        public T[] CreateManyRandom(int amount)
        {
            return Enumerable.Repeat(CreateRandom(), amount).ToArray();
        }

        private static Y SetRandomValue<Y>(Type type)
        {
            var random = new Random();

            return type switch
            {
                var t when t == typeof(int) || t == typeof(short) || t == typeof(long)
                    => (Y)(object)random.Next(1, 1000),

                var t when t == typeof(double) || t == typeof(float) || t == typeof(decimal)
                    => (Y)(object)(random.NextDouble() * 1000),

                var t when t == typeof(byte)
                    => (Y)(object)(byte)random.Next(1, 255),

                var t when t == typeof(string)
                    => (Y)(object)Guid.NewGuid().ToString(),

                var t when t == typeof(bool)
                    => (Y)(object)(random.Next(0, 2) == 1),

                _ => throw new NotImplementedException(
                    $"Random generation for type {typeof(Y).Name} is not implemented.")
            };
        }

    }
}
