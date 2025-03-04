using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPage : MonoBehaviour
{
    public void BackToStart()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
