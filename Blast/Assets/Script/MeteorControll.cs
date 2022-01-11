using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControll : MonoBehaviour
{
    GameObject TextScoreUI;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        TextScoreUI = GameObject.FindGameObjectWithTag("ScoreGame");

    }

    // Update is called once per frame
    void Update()
    {
        //Dapetin posisi meteor
        Vector2 posisi = transform.position;

        //Hitung posisi baru meteor
        posisi = new Vector2(posisi.x - speed * Time.deltaTime, posisi.y);

        //Update posisi baru meteor
        transform.position = posisi;

        //posisi max layar di kiri bawah
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //Jika meteor keluar layar maka destroy meteor
        if(transform.position.x < min.x)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "Peluru")||(col.tag == "Roket"))
        {
            TextScoreUI.GetComponent<GameScoring>().Score += 10;
            Destroy(gameObject);
        }

    }
}
