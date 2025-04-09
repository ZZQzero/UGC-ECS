

using System;
using System.IO;
using MessagePack;
using Palmmedia.ReportGenerator.Core.Common;
using UGC;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    private void Start()
    {
        string path = Application.dataPath + "/UGC/";
        string filePath = path + "test.bytes";
        /*UGCSceneManager.Instance.CreateUgcScene("test"); //创建场景
        
        var entity = UGCSceneManager.Instance.GetUgcEntityManager().CreateUgcEntity(1);//创建对象
        
        UGCSceneManager.Instance.AddUgcEntity(entity);//添加对象到场景
        
        var component = new MoveComponent();//创建组件
        component.Id = 10;
        component.X = 111;
        component.Y = 123;
        entity.AddComponent(component);//添加组件到对象
        
        var bytes = MessagePackSerializer.Serialize(UGCSceneManager.Instance.GetUgcScene());
        //Debug.LogError($"{bytes.Length}");
        
        
        
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }
        File.WriteAllBytes(filePath, bytes);
        */

        var bytes = File.ReadAllBytes(filePath);
        UGCSceneManager.Instance.DeserializeUgcScene(bytes);
        
    }

    public void RegisterComponent()
    {
        
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UGCSceneManager.Instance.DestroyUgcScene();

        }
    }
}