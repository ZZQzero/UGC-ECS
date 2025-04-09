using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessagePack;
using UnityEngine;
using UnityEngine.Serialization;

namespace UGC
{
    /// <summary>
    /// UGC场景
    /// </summary>
    ///
    [MessagePackObject]
    public class UGCScene : IDisposable,IMessagePackSerializationCallbackReceiver
    {
        //第一个int -->表里的唯一Id，第二个int-->UGCEntity的Id（自动生成的）
        [Key(0)]
        public Dictionary<int, Dictionary<int, UGCEntity>> UgcEntityDic = new();
        [Key(1)]
        public string SceneName;
        [Key(2)]
        public string ScenePath;
        [Key(3)]
        public string SceneType;
        [Key(4)]
        public string SceneDesc;
        [Key(5)]
        public string SceneVersion;
        [Key(6)]
        public string SceneId;
        [Key(7)]
        public string SceneIcon;
        [Key(8)]
        public string SceneAuthor;
        [IgnoreMember]
        public UGCEntityManager EntityManager;

        public UGCScene()
        {
            EntityManager = new UGCEntityManager();
            Debug.LogError("UGCScene 构造函数");
        }

        public void AddUgcEntity(UGCEntity entity)
        {
            if (!UgcEntityDic.TryGetValue(entity.Id, out Dictionary<int, UGCEntity> ugcEntityDic))
            {
                ugcEntityDic = new Dictionary<int, UGCEntity>();
                ugcEntityDic.Add(entity.EntityId, entity);
                UgcEntityDic.Add(entity.Id, ugcEntityDic);
            }
            else
            {
                ugcEntityDic.Add(entity.EntityId, entity);
            }
        }

        public UGCEntity GetUgcEntity(int id, int entityId)
        {
            if (UgcEntityDic.TryGetValue(id, out Dictionary<int, UGCEntity> ugcEntityDic))
            {
                ugcEntityDic.TryGetValue(entityId, out UGCEntity ugcEntity);
                return ugcEntity;
            }

            return null;
        }

        public void DestroyUgcEntity(int id, int entityId)
        {
            if (UgcEntityDic.TryGetValue(id, out Dictionary<int, UGCEntity> ugcEntityDic))
            {
                if (!ugcEntityDic.TryGetValue(entityId, out UGCEntity ugcEntity))
                {
                    return;
                }

                ugcEntity.Dispose();
                ugcEntityDic.Remove(entityId);
                if (ugcEntityDic.Count == 0)
                {
                    UgcEntityDic.Remove(id);
                }
            }
        }

        public void Update()
        {
            EntityManager.Update();
        }

        public void Dispose()
        {
            EntityManager.Dispose();
            UgcEntityDic.Clear();
            EntityManager = null;
            Debug.LogError("dispose ugc scene");
        }

        public void OnBeforeSerialize()
        {
            Debug.LogError("OnBeforeSerialize");
        }

        public void OnAfterDeserialize()
        {
            foreach (var item in UgcEntityDic.Values)
            {
                foreach (var entity in item)
                {
                    EntityManager.OnAfterDeserializeAddEntity(entity.Key, entity.Value);
                }
            }
            Debug.LogError("UGCScene OnAfterDeserialize");

        }
    }
}


