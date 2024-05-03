using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetMenu : MonoBehaviour
{
    public void ResetGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
