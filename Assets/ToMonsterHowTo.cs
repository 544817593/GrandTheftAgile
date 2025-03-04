using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMonsterHowTo : MonoBehaviour
{
    public void ToMonster()
    {
        SceneManager.LoadSceneAsync(3);
    }

}