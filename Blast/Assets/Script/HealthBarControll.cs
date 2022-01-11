using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControll : MonoBehaviour
{
   
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;

        if (GlobalVariable.level == 2)
        {
            speed = 4f;
        }
        else if (GlobalVariable.level == 3)
        {
            speed = 6f;
        }

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
        if (transform.position.x < min.x)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Roket")
        {
            Destroy(gameObject);
        }
    }
}
