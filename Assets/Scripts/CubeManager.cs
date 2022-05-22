using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeManager : MonoBehaviour, IPointerClickHandler
{
    public Vector2 mousePos;
    //[SerializeField] private Vector2 ;
    [SerializeField] private GameObject cube;
    public RectTransform rt;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 newPos = mousePos;

            var square = Instantiate(cube, rt); // instantiate a cube on mouse down
            square.transform.position = new Vector3(newPos.x, newPos.y, 0);
            
        }
    }
}
