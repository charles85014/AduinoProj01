using UnityEngine;
using System.Collections;

public class ControllerCamera : MonoBehaviour
{
    public static ControllerCamera master;

    public float Yoffset;
    public float time;

    void Awake()
    {
        master = this;
    }

    public void MoveCameraToTop(GameObject obj)
    {
        iTween.MoveTo(this.gameObject, iTween.Hash(
                "y", obj.transform.position.y + this.Yoffset,
                "time", this.time
                ));
    }
}