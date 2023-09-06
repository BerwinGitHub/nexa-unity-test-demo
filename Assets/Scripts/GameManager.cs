using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class GameManager : Singleton<GameManager>
{
    public bool IsPromp = true;
    public Animator Promp;
    public bool IsMix = false;
 
    void Start()
    {
       Promp=GameObject.Find("PrompPanel").GetComponent<Animator>();
       if (Promp == null) return;
        Promp.SetBool("IsPromp", IsPromp);
    }

    // Update is called once per frame
    void Update()
    {

        Promp.gameObject.SetActive(IsPromp);
        Promp.SetBool("IsPromp", IsPromp);
    }
   
}
