using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessagePack;
using UnityEngine;

namespace UGC
{
    [MessagePackObject]
    public class UGCEntity : IDisposable,IMessagePackSerializationCallbackReceiver
    {
        [Key(0)]
        public int Id { get; } //表里配置的部件唯一Id
        [Key(1)]
        public int EntityId; //实例化的部件唯一Id（自动生成）
        [Key(2)]
        public string Name;
        [Key(3)]
        public string Type;
        [Key(4)]
        public string Path;
        [Key(5)]
        public string Desc;
        [Key(6)]
        public string IconPath;
        [Key(7)]
        public Dictionary<int, UGCComponentBase> Components = new Dictionary<int, UGCComponentBase>();


        public UGCEntity(int id)
        {
            Id = id;
        }

        public void AddComponent(UGCComponentBase component)
        {
            Components.TryAdd(component.Id, component);
            component.RegisterSystem();
            component.SystemBase.Start();
        }

        public void RemoveComponent(int id)
        {
            Components.Remove(id, out UGCComponentBase component);
            if (component != null)
            {
                component.SystemBase.Destroy();
                component.SystemBase = null;
            }
        }

        public T GetComponent<T>(int id) where T : UGCComponentBase
        {
            if (Components.TryGetValue(id, out UGCComponentBase component))
            {
                return component as T;
            }

            return null;
        }

        public bool HasComponent(int id)
        {
            return Components.ContainsKey(id);
        }

        public void Update()
        {
            foreach (var component in Components.Values)
            {
                component.SystemBase.Update();
            }
        }

        public void Dispose()
        {
            foreach (var component in Components.Values)
            {
                component.SystemBase.Destroy();
                component.SystemBase = null;
            }
            Components.Clear();
        }

        public void OnBeforeSerialize()
        {
            
        }

        public void OnAfterDeserialize()
        {
            if (Components is { Count: > 0 })
            {
                foreach (var entity in Components)
                {
                    entity.Value.RegisterSystem();
                    entity.Value.SystemBase.Start();
                }
            }
        }
    }
}


