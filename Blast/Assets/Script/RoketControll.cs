using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoketControll : MonoBehaviour
{
    public GameObject GameManagerGO;
    public GameObject Peluru;
    public GameObject PosisiPeluru;

    public Text TextLife;

    const int Maxlife = 3;
    int life;

    public float speed;
    AudioSource audio;

    public void Init()
    {
        life = Maxlife;

        TextLife.text = life.ToString();

        gameObject.SetActive(true);

    }
    // Start is called before the first frame update
    void Start()
    {
       

        audio = GetComponent<AudioSource>();

        //reset position
        transform.position = new Vector2(0, 0);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Tembak peluru jika pencet spasi
        if(Input.GetKeyDown("space"))
        {
            //play laser shoot
            audio.Play();

            GameObject ObjectPeluru = (GameObject)Instantiate(Peluru);
            ObjectPeluru.transform.position = PosisiPeluru.transform.position;
        }

        float x = Input.GetAxisRaw("Horizontal"); // akan bernilai -1 (kiri), 0 (no input), 1 (kanan)
        float y = Input.GetAxisRaw("Vertical"); // akan bernilai -1 (bawah), 0 (no input), 1 (atas)

        //berdasarkan input kita cari arahnya lalu di normalized agar besar arah vector selalu sama
        Vector2 arah = new Vector2(x, y).normalized;

        //setelah dapat arahnya kita masukkan ke roket
        Gerak(arah);
    }
    void Gerak(Vector2 arah)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // pojok kiri bawah dari layar
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // pojok kanan atas dari layar

        max.x = max.x - 0.225f; //kurangi roket setengah lebar
        min.y = min.x + 0.225f; //tambah roket setengah lebar

        max.y = max.y - 0.285f; //kurangi roket setengah lebar
        min.y = min.y + 0.285f; //tambah roket setengah lebar

        //Dapatin posisi roket
        Vector2 posisi = transform.position;

        //Hitung posisi baru
        posisi += arah * speed * Time.deltaTime;

        //Pastikan posisinya tidak diluar layar
        posisi.x = Mathf.Clamp(posisi.x, min.x, max.x);
        posisi.y = Mathf.Clamp(posisi.y, min.y, max.y);

        //Update posisi
        transform.position = posisi;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "Meteor") || (col.tag == "Bomb"))
        {
            life--;
            TextLife.text = life.ToString();
            if(life == 0)
            {
                GameManagerGO.GetComponent<GameManagerGO>().SetGameManagerState(GameManagerState.GameOver);
                gameObject.SetActive(false);
            }
            
        }
    }
}


