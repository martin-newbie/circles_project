﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DMZSceneChange : MonoBehaviour
{
    public void ScneneChange1()
    {
        SceneManager.LoadScene("DMZMap");
    }
}
