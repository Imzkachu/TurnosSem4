using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{

    private static MouseWorld instance;

    [SerializeField] private LayerMask mouseFloorLayerMask;

    private void Awake()
    {
        instance = this;
    }

    public static Vector3 GetPosition()
    {
        //Raycast tells me the position of objects
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Screenpoint es la pantalla (x,y)
        Physics.Raycast(ray,out RaycastHit hit, float.MaxValue, instance.mouseFloorLayerMask);
        //      funcion(nombre, "quiero" info, tipo de dato,Que si y que no)

        return hit.point;
        //regresa el punto del impacto
    }
}
