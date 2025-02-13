using System;
using System.Collections.Generic;

namespace EntJoy
{
    /// <summary>
    /// 运行时组件类型注册管理
    /// </summary>
    public class ComponentTypeRegistry
    {
        private static int idAllocator;
        private static readonly Dictionary<Type, ComponentType> hasRegistries = new();
        public static readonly Dictionary<int, Type> idToTpyeMap = new();

        public static ComponentType GetComponentType(Type type)
        {
            if (hasRegistries.TryGetValue(type, out var componentType))
            {
                return componentType;
            }

            var newComponentType = new ComponentType(idAllocator);
            hasRegistries.Add(type, newComponentType);
            idToTpyeMap.Add(idAllocator, type);
            idAllocator++;
            return newComponentType;
        }

        public static Type GetTypeByComponentType(int id)
        {
            return idToTpyeMap[id];
        }
    }
}