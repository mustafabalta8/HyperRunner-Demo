using System.Collections;
using System.IO;
using UnityEngine;

public class Paintable1 : MonoBehaviour
{
    [SerializeField] private GameObject Brush;
    [SerializeField] private float brushSize = 0.1f;

    private int totalNewObject = 0;
    void Update()
    {
        if(GameManager.GameState == Screens.Final)
        if (Input.GetMouseButton(0))
        {
            //cast a ray to the wall
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(Ray, out hit))
            {
                    var newObj = Instantiate(Brush, hit.point + (Vector3.back * 0.1f), transform.rotation, transform);              
                    newObj.transform.localScale = Vector3.one * brushSize;
                    totalNewObject++;
                    if (totalNewObject > 300)
                    {
                        GameManager.instance.HandleWinning();
                    }
            }

        }
    }

 
}
