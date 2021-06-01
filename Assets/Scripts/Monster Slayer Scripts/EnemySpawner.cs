using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    ObjectPooler objpool;

    void Start(){
        objpool = ObjectPooler.Instance; 
    }
    void FixedUpdate(){
        ObjectPooler.Instance.SpawnFromPool("Forest Enemy Slime", transform.position, Quaternion.identity);
    }
}
