using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManUI : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Level1()
    {
        SceneManager.LoadScene("Lv1");
        level=1;
    }
    public void Level2()
    {
        SceneManager.LoadScene("Lv2");
        level=2;
    }

    public void keluarBtn()
    {
        Application.Quit();
    }
    public void MenuBtn()
    {
        SceneManager.LoadScene("SceneManager");
    }
}
