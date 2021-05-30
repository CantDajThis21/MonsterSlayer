using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameController cont;
    public GameValues gamedata;
    EnemyPooler enemypooler;
    

    private void Start(){
        gamedata = cont.gamedata;
        enemypooler = EnemyPooler.Instance;
    }


    void FixedUpdate()
    {

        if(cont.gamedata.health == 0){
            enemypooler.SpawnFromPool("Forest Snake Enemy", transform.position, Quaternion.identity);   
        }
        
        enemypooler.SpawnFromPool("Forest Slime Enemy", transform.position, Quaternion.identity);
        
    }
}
