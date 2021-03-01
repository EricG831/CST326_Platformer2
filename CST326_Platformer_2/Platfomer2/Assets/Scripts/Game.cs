using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Game : MonoBehaviour
{
    public TextMeshProUGUI time;
    //public GameObject Goal;
    float timer = 0.0f;
    int countdown = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        timer += Time.deltaTime;
        int seconds = (int)(timer % 60);
        
       if((countdown - seconds) <= 0)
        {
            Debug.Log("Game Over");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        
        time.text = $"TIME\n{countdown - seconds}";
    }
}
