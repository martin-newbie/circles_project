using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMapSceneChange : MonoBehaviour
{
    public void ScneneChange1()
    {
        SceneManager.LoadScene("mainKoreaMap");
    }
}
