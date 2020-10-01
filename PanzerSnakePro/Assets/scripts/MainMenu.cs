using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int licznikBoluDupy = 0;
    public void PlayGame ()
    {
        SceneManager.LoadScene(1);
    }
    public void DUPA()
    {
        licznikBoluDupy += 1;
    }

}
