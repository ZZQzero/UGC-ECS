
using System;
using System.Collections.Generic;

namespace UGC
{
    public class UGCEntityManager : IDisposable
    {
        private readonly Dictionary<int,UGCEntity> _entityDict = new();
    
        /// <summary>
        /// 创建UGCEntity
        /// </summary>
        /// <param name="id">部件Id，表里配置的唯一id</param>
        /// <returns></returns>
        public UGCEntity CreateUgcEntity(int id)
        {
            //
            UGCEntity entity = new UGCEntity(id);
            entity.Desc = "描述";
            entity.Name = "名字";
            entity.EntityId = 100;
            _entityDict.Add(entity.EntityId, entity);
            return entity;
        }

        public void DestroyUgcEntity(int entityId)
        {
            if (_entityDict.ContainsKey(entityId))
            {
                _entityDict.Remove(entityId);
            }
        }
    
        public UGCEntity GetUgcEntity(int entityId)
        {
            return _entityDict.GetValueOrDefault(entityId);
        }
        
        public void OnAfterDeserializeAddEntity(int entityId,UGCEntity entity)
        {
            _entityDict.Add(entityId,entity);
        }

        public void Dispose()
        {
            foreach (var item in _entityDict)
            {
                item.Value.Dispose();
            }
            _entityDict.Clear();
        }

        public void Update()
        {
            foreach (var item in _entityDict)
            {
                item.Value.Update();
            }
        }
    }
}
