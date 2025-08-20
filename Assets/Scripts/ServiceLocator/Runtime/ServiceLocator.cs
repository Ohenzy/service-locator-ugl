using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UGL.ServiceLocator
{
    internal class ServiceLocator
    {
        internal static readonly ServiceLocator instance = new();

        private readonly Dictionary<string, object> _services = new();

        private ServiceLocator()
        {
        }

        internal T Get<T>()
        {
            var key = GetKey(typeof(T));

            if (_services.TryGetValue(key, out var value))
            {
                return (T)value;
            }

            Debug.LogError($"Тип не найден: {key}");
            return default;
        }

        internal void Register<T>(T instance)
        {
            Register(GetKey(typeof(T)), instance);
        }

        internal void RegisterInterfaces<T>(T instance)
        {
            var interfaces = instance.GetType().GetInterfaces();

            if (interfaces.Length == 0)
            {
                Register(instance);
                return;
            }

            foreach (var i in interfaces)
            {
                Register(GetKey(i), instance);
            }
        }

        private void Register(string key, object instance)
        {
            if (!_services.TryAdd(key, instance))
            {
                Debug.LogError($"Тип уже зарегестрирован: {key}");
            }
        }

        internal void Clear()
        {
            _services.Clear();
        }

        private static string GetKey(Type type)
        {
            if (!type.IsGenericType)
            {
                return type.FullName;
            }

            var genericArguments = type.GetGenericArguments();
            return $"{type.FullName}[{string.Join(":", genericArguments.Select(a => a.FullName))}]";
        }
    }
}