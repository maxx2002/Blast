using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject GameManagerGO;
    public GameObject Meteor1;
    public GameObject Meteor2;
    public GameObject Meteor3;
    public GameObject Meteor4;
    public GameObject Meteor5;
    public GameObject Meteor6;
    public GameObject Meteor7;
    public GameObject Meteor8;
    public GameObject Meteor9;
    public GameObject Meteor10;
    public GameObject HealthBar;

    float maxSpawnRateInSeconds = 5f;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnMeteor()
    {
        if (GlobalVariable.level == 1)
        {
            this.maxSpawnRateInSeconds = 3f;
        }
        else if (GlobalVariable.level == 2)
        {
            this.maxSpawnRateInSeconds = 2f;
        }
        else if (GlobalVariable.level == 3)
        {
            this.maxSpawnRateInSeconds = 1f;
        }

        int i = Random.Range(1, 12);
        switch (i)
        {
            case 1:
                obj = Meteor1;
                break;
            case 2:
                obj = Meteor2;
                break;
            case 3:
                obj = Meteor3;
                break;
            case 4:
                obj = Meteor4;
                break;
            case 5:
                obj = Meteor5;
                break;
            case 6:
                obj = Meteor6;
                break;
            case 7:
                obj = Meteor7;
                break;
            case 8:
                obj = Meteor8;
                break;
            case 9:
                obj = Meteor9;
                break;
            case 10:
                obj = Meteor10;
                break;
            case 11:
                obj = HealthBar;
                break;
        }
        //Posisi layar kiri bawah
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //Posisi layar atas kanan
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Instantiate meteor
        GameObject SebuahMeteor = (GameObject)Instantiate(obj);
        SebuahMeteor.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));

        //Spawn meteor selanjutnya
        nextMeteorSpawn();
    }

    void nextMeteorSpawn()
    {
        float detikSpawn;

        if(maxSpawnRateInSeconds > 1f)
        {
            //Random number buat spawn dari 1 sampai maksimal spawn
            detikSpawn = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            detikSpawn = 1f;
        }

        Invoke("SpawnMeteor", detikSpawn);
    }

    void TingkatinKecepatanSpawn()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("TingkatinKecepatanSpawn");
    }

    public void ScheduledMeteorSpawner()
    {
        //Invoke untuk memanggil function di suatu kecepatan
        Invoke("SpawnMeteor", maxSpawnRateInSeconds);

        //Naikin spawn rate setiap 30 detik
        InvokeRepeating("TingkatinKecepatanSpawn", 0f, 30f);
    }
    public void UnscheduleMeteorSpawner()
    {
        CancelInvoke("SpawnMeteor");
        CancelInvoke("TingkatinKecepatanSpawn");
    }
}
