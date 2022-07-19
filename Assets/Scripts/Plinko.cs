using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plinko : MonoBehaviour
{

    private GameObject plinko;

    public Animator plinkoAnim;

    private Coroutine plinkoWait;

    public PlinkoManager plinkoM;

    private PlinkoScore score;

    public Collider[] rungColliders;
    private bool spacePressed;

    public bool hit = false;

    public float timeSinceHiit;
    // Start is called before the first frame update
    void Start()
    {
        plinkoWait =  StartCoroutine(PlinkoAnimate());
        plinko = this.gameObject;
    }

    private IEnumerator PlinkoAnimate()
    {
        if (!spacePressed)
            plinkoAnim.SetBool("Stopped?", false);
        yield return new WaitForEndOfFrame();
    }

    // Update is called once per frame
    void Update()
    {
       if(hit == true)
        {
            timeSinceHiit += Time.deltaTime;
            if(timeSinceHiit >= 0.1f)
            {
                plinkoM.GetScore((int)score.score);
                Debug.Log(plinkoM.score);
            }
        }
        spacePressed = Input.GetKeyDown(KeyCode.Space);
        if (spacePressed)
        {
            StopCoroutine(plinkoWait);
            plinkoFalls();
        }
    } 

    private void plinkoFalls()
    {
        plinkoAnim.SetBool("Stopped?", true);
        plinkoAnim.enabled = false;
        Rigidbody rb = plinko.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.isKinematic = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
           

           if(collision.gameObject.tag == "Score")
           {
                score = collision.gameObject.GetComponent<PlinkoScore>();
                if(score != null)
                {
                    hit = !hit;
                    //plinkoM.GetScore((int)score.score);
                    //Debug.Log(plinkoM.score);
                }
           }

        
    }
}
