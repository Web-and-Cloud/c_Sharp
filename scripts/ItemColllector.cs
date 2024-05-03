using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemColllector : MonoBehaviour
{
    private int cherries = 0;

    //[SerializeField] private Text cherriesText;
    [SerializeField] private TextMeshProUGUI cherriesText;
    [SerializeField] private AudioSource CollectSoundEffect;

    private void Start()
    {
        cherriesText.text = "Cherries: " + cherries;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            CollectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;
        }
    }
}
