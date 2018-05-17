using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour {

    bool isCutting = false;

    Rigidbody2D rb;
    Camera cam;

    public void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButtonDown(0)) {
            
            startCutting();
        } 
        else if(Input.GetMouseButtonUp(0)) {
            
            stopCutting();
        }
        if(isCutting) {

            updateCut();
        }
		
	}

    public void updateCut() {

        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void startCutting() {

        isCutting = true;
    }
    public void stopCutting() {

        isCutting = false;
    }
}
