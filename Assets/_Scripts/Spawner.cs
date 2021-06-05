using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject zombie;
    private int round;
    private static Spawner _instance;

    private int zombiesRound;

    private int currentZombies = 0;

    GameManager gm;
    // Start is called before the first frame update

    void Awake()
    {
        gm = GameManager.GetInstance();
        _instance = this;

    }
    void Start()
    {
        gm.round = 0;
        _instance.zombiesRound = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_instance.currentZombies <= 0){
            NextRound();

        }
        
    }

    public static void ZombieKilled()
    {
        _instance.currentZombies--;
    }

    private void NextRound(){
        Debug.Log("Next round");
        gm.round++;
        _instance.zombiesRound = 20 *_instance.zombiesRound /19 + 5  ;
        Spawn();
    }


    private void Spawn(){

        for (int i=0; i<_instance.zombiesRound;i++){
        Vector3 offset = Random.onUnitSphere * Random.Range(10, 100);
        GameObject zombi = Instantiate(_instance.zombie, new Vector3(offset.x, 0, offset.z), Quaternion.identity );
        zombi.GetComponent<EnemyController>().playerPos = player;
        }

        _instance.currentZombies = _instance.zombiesRound;

    }
}
