using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeluruControll : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Dapatin posisi peluru
        Vector2 posisi = transform.position;

        //Hitung posisi baru peluru
        posisi = new Vector2(posisi.x + speed * Time.deltaTime, posisi.y);

        //Update posisi peluru
        transform.position = posisi;

        //Posisi max layar atas kanan
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Jika peluru keluar dari layar peluru di destroy
        if(transform.position.x > max.x)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Meteor")
        {
            Destroy(gameObject);
        } 
    }
}
