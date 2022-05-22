using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

    [SerializeField] private Vector2 threshold; 
    private CubeManager cm;
    private RectTransform rect;
    public RectTransform cubeRect;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector2 localPoint;
    private float startTime;
    private float endTime;
    [SerializeField] private float speed;
    private Rigidbody2D rigid;
    void Start()
        {
        rigid = GetComponent<Rigidbody2D>();
            cm = FindObjectOfType<CubeManager>();
        rect = cm.GetComponent<RectTransform>();
            Debug.Log("Start");
        }

    private void Update()
    {
        BounceOffScreen();
        BounceOffEachOther();
        StartCoroutine(SlowDown());
        
    }


    private IEnumerator SlowDown()
    {

        float timer = 5;

        //rigid.velocity *= (1 - rigid.drag);
        yield return new WaitForSeconds(timer);

        rigid.drag = .3f;
    }

    private void BounceOffEachOther()
    {
       
    }

    private void BounceOffScreen()
    {
        int width = Screen.width;
        int height = Screen.height;
        Debug.Log(cubeRect.position.x + cubeRect.rect.max.x);
        Debug.Log(width);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
        if (cubeRect.position.y + cubeRect.rect.max.y > height / 2)
        {
            Vector3 velocity = rb.velocity;
            velocity = Vector2.Reflect(velocity, Vector2.down);
            rb.velocity = velocity;
        }
        if (cubeRect.position.y + cubeRect.rect.min.y < -height / 2)
        {
            Vector3 velocity = rb.velocity;
            velocity = Vector2.Reflect(velocity, Vector2.up);
            rb.velocity = velocity;
        }
        if (cubeRect.position.x + cubeRect.rect.max.x > width / 2)
        {
            Vector3 velocity = rb.velocity;
            velocity = Vector2.Reflect(velocity, Vector2.left);
            rb.velocity = velocity;
        }
        if (cubeRect.position.x + cubeRect.rect.min.x < -width / 2)
        {
            Vector3 velocity = rb.velocity;
            velocity = Vector2.Reflect(velocity, Vector2.right);
            rb.velocity = velocity;
        }
    }

    public void OnBeginDrag(PointerEventData _EventData) //start dragging the cube and keep track of mouse velocity
    {
        startPos = cm.cam.ScreenToWorldPoint(Input.mousePosition);
        startTime = Time.time;
       Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData _EventData) //update velocity and mouse position while dragging 
    {
        //Debug.Log(_EventData);

        transform.position = cm.cam.ScreenToWorldPoint(Input.mousePosition);


        //rect.anchoredPosition += _EventData.delta;
        //if mouse increases magnitude set cubes magnitude to mouses;
        //if (cm.mousePos.magnitude >= threshold)
       //{
       //    Rigidbody2D rb = GetComponent<Rigidbody2D>();
       //    rb.AddForce(cm.mousePos , ForceMode2D.Force); 
         
       //}
    }

        public void OnEndDrag(PointerEventData _EventData) //track most recent mouse velocity and keep cube moving at that velocity and slow it down over time or until mouse clicks again, starting new drag
        {
        endPos = cm.cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 magnitude = endPos - startPos;
        endTime = Time.time;
        float deltaTime = endTime - startTime;
        //Debug.Log(magnitude);

            Vector2 velocity = magnitude / deltaTime * speed;
            rigid.AddForce(velocity, ForceMode2D.Force);



        //whatever old magnitude mouse had keep it on cube

        //make sure mouse is not moving



        //var distance = (touch.position - startSwipePosition).magnitude;
        //var deltaTime = Time.time - startSwipeTime;
        //var velocity = distance / deltaTime;

        //ThrowBall(velocity);



        Debug.Log("OnEndDrag");
        }
    void ConvertPoint(Vector2 pointPosition)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, pointPosition, null, out localPoint);
        transform.localPosition = localPoint;
    }
}
