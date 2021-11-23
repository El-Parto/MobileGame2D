using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContnueAfterSceneLoad : MonoBehaviour
{
	
	
	private void Awake()
	{
		GameObject[] musicGameObject = GameObject.FindGameObjectsWithTag("Music");
		if(musicGameObject.Length > 1)
			Destroy(this.gameObject);
		DontDestroyOnLoad(this.gameObject);
	}

	// Update is called once per frame
    void Update()
    {
        
    }
}
