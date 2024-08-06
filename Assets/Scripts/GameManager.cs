using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TestScriptable scriptable;

    public void OnButtonClick()
    {
        scriptable.AttackPower = 10;
        SceneManager.LoadScene("NextScene");
    }
}
