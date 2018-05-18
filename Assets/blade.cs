using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour {

    public GameObject BladeTrailPrefab;
    bool isCutting = false;

    GameObject currentBladeTrail;

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;


    public void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
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
        currentBladeTrail = Instantiate(BladeTrailPrefab, transform);
        circleCollider.enabled = true;
    }
    public void stopCutting() {

        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }
}
