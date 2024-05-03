using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pelaja : MonoBehaviour
{
    public Transform Kamera;
    public float MoveSpeed = 5f;
    public GameObject FailText;
    public GameObject WinText;

    public int pisteet = 0;
    public TextMeshProUGUI PisteText;

    public GameObject Vihollinen;
    public GameObject Timantti;

    private AudioSource source;

    private void Start()
    {
        StartCoroutine(LuoObjekt());

        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //kerätään käyttäyän input
        float Horizontal = Input.GetAxis("Horizontal");

        float pros = transform.position.y / 1000;


        //                                      vaaka liike        vakio,                                                   kiihtyvyys
        transform.position += new Vector3(Horizontal * MoveSpeed, MoveSpeed + MoveSpeed * pros, 0) * Time.deltaTime;
        Kamera.position = new Vector3(0, transform.position.y + 4, -10);


        if (transform.position.y >= 1000)
        {
            WinText.SetActive(true);
            StartCoroutine(ResetScene(3));
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Vihollinen")
        {
            MoveSpeed = 0;
            FailText.SetActive(true);

            source.Play();

            StartCoroutine(ResetScene(3));
        }

        if (other.gameObject.tag == "Timantti")
        {
            pisteet++;
            PisteText.text = pisteet + " points";
            Destroy(other.gameObject);
        }
    }

    IEnumerator ResetScene(int aika)
    {
        yield return new WaitForSeconds(aika);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LuoObjekt()
    {
        yield return new WaitForSeconds(2);
        GameObject Go = Vihollinen;

        if(Random.Range(0.0f, 1.0f) < 0.5f)
        {
            Go = Timantti;
        }

        Vector3 position = new Vector3(Random.Range(-5, 5), transform.position.y + 15, 0);

        Instantiate(Go, position, Quaternion.identity);

        StartCoroutine(LuoObjekt());
    }
}
