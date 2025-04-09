using System;
using System.Collections;
using System.Collections.Generic;
using MessagePack;
using UnityEngine;

namespace UGC
{
    public class UGCSceneManager : MonoSingleton<UGCSceneManager>
    {
        private UGCScene _ugcScene;

        private void Update()
        {
            if (_ugcScene != null && _ugcScene.EntityManager != null)
            {
                _ugcScene.Update();
            }
        }

        public void CreateUgcScene(string sceneName)
        {
            UGCScene scene = new UGCScene();
            scene.SceneName = sceneName;
            _ugcScene = scene;
        }

        public void DestroyUgcScene()
        {
            _ugcScene.Dispose();
            _ugcScene = null;
        }

        public void AddUgcEntity(UGCEntity entity)
        {
            if (_ugcScene != null)
            {
                _ugcScene.AddUgcEntity(entity);
            }
            else
            {
                Debug.LogError("UGC场景没有创建");
            }
        }

        public UGCScene GetUgcScene()
        {
            return _ugcScene;
        }
    
        //通过反序列化加载ugc场景
        public void LoadUgcScene(string sceneName)
        {
            // Logic to load a UGC scene
            Debug.Log("Loading UGC Scene: " + sceneName);
        }
    
        //序列化UGC场景
        public void SerializeUgcScene(string sceneName)
        {
            // Logic to serialize a UGC scene
            Debug.Log("Serializing UGC Scene: " + sceneName);
        }
    
        //反序列化UGC场景
        public void DeserializeUgcScene(byte[] bytes)
        {
            _ugcScene = MessagePackSerializer.Deserialize<UGCScene>(bytes);
            if (_ugcScene != null)
            {
            }
        }
    }

}

