using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour {

    public GameObject BladeTrailPrefab;

    public float minCuttingVelocity = .001f;
    bool isCutting = false;

    GameObject currentBladeTrail;

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    // this is going to check the velocity of our blade 
    // to enable activate the circle collider
    Vector2 previousPosition;


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

        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        // Delta time will help not to change our velocity because of frame rate.
        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if(velocity > minCuttingVelocity) {

            circleCollider.enabled = true;
        } else {
            circleCollider.enabled = false;
        }

        previousPosition = newPosition;
    }

    public void startCutting() {

        isCutting = true;
        currentBladeTrail = Instantiate(BladeTrailPrefab, transform);
        circleCollider.enabled = false;
    }
    public void stopCutting() {

        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }
}
