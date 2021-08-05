using System;
using UnityEngine;

namespace Extensions.GameObjects
{
    public static class GameObjectExtensions
    {
        public static bool HasComponent<T> (this GameObject gameObject)
        {
            var component = gameObject.GetComponent<T>();

            return component != null;
        }
    }
}
