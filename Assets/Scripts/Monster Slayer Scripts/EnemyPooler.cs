using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool{
        public string tag;
        public GameObject prefab;
        public int size;
    }
    #region  Singleton
    public static EnemyPooler Instance;

    private void Awake(){
       Instance = this; 
    }

    #endregion
    
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> pooldict;

    public void Start(){
       pooldict = new Dictionary<string, Queue<GameObject>>();

       foreach (Pool pool in pools){
           Queue<GameObject> objectpool = new Queue<GameObject>();

           for(int i = 0; i < pool.size; i++){
               GameObject obj = Instantiate(pool.prefab);
               obj.SetActive(false);
               objectpool.Enqueue(obj);
           }

           pooldict.Add(pool.tag, objectpool);
       }
    }
    
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation){
        if(!pooldict.ContainsKey(tag)){
            Debug.LogWarning("Pool with tag " + tag + "Doesn't exist.");
            return null;
        }
        
        
        GameObject objtospawn = pooldict[tag].Dequeue();

        objtospawn.SetActive(true);
        objtospawn.transform.position = position;
        objtospawn.transform.rotation = rotation;

        pooldict[tag].Enqueue(objtospawn);

        return objtospawn;
    }
}
