using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject Seina;

    private void Start()
    {
        int leveys = 5;

        for(int rivi = 0; rivi < 1000; rivi++)
        {
            for(int sarake = 0; sarake < leveys; sarake++)
            {
                Instantiate(Seina, new Vector3(sarake, rivi, 0) + new Vector3(-9, -10, 0), Quaternion.identity);
            }

            leveys += Random.Range(-1, 2);
            leveys = Mathf.Clamp(leveys, 2, 8);
        }

        for (int rivi = 0; rivi < 1000; rivi++)
        {
            for (int sarake = 0; sarake < leveys; sarake++)
            {
                Instantiate(Seina, new Vector3(-sarake, rivi, 0) + new Vector3(9, -10, 0), Quaternion.identity);
            }

            leveys += Random.Range(-1, 2);
            leveys = Mathf.Clamp(leveys, 2, 8);
        }
    }
}
