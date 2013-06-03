using UnityEngine;
using System.Collections;

public class BoxControl : MonoBehaviour
{
    public float MoveDistance;
    public float MoveTime;

    public float GroundDetectDistance;
    public Vector3 GroundDetectDirection;

    [HideInInspector]
    public bool isFirstBox = false;

    public LayerMask PlaneLayer;

    public enum BoxState
    {
        NotRelease = 0, Release, TouchGround
    }
    public BoxState currentBoxState = BoxState.NotRelease;

    // Use this for initialization
    void Start()
    {
        this.rigidbody.isKinematic = true;
        this.transform.position -= new Vector3(this.MoveDistance, 0, 0);
        iTween.MoveTo(this.gameObject, iTween.Hash(
            "time", this.MoveTime,
            "easetype", iTween.EaseType.linear,
            "position", this.transform.position + new Vector3(2 * this.MoveDistance, 0, 0),
            "looptype", iTween.LoopType.pingPong,
            "name", "MoveBox"
            ));
    }

    // Update is called once per frame
    void Update()
    {

        switch (this.currentBoxState)
        {
            case BoxState.NotRelease:
                if (Input.GetKeyUp(KeyCode.A))
                {
                    this.currentBoxState = BoxState.Release;
                    iTween.StopByName("MoveBox");

                    this.rigidbody.isKinematic = false;
                    this.rigidbody.velocity = Vector3.zero;
                }
                break;

            case BoxState.Release:
                if (this.isGround())
                {
                    ControllerCamera.master.MoveCameraToTop(this.gameObject);
                    BoxCreat.master.CallCreateBox();
                    this.currentBoxState = BoxState.TouchGround;
                }
                break;

            case BoxState.TouchGround:

                if (!this.isFirstBox)
                {
                    if (this.isBoxDown())
                    {
                        //偵測非第一個BOX是否碰到地面(碰到GameOver)
                        print("GameOver");
                    }
                }
                break;
        }
    }

    bool isGround()
    {
        RaycastHit hit;

        return this.rigidbody.SweepTest(this.GroundDetectDirection, out hit, this.GroundDetectDistance);
        //return Physics.Raycast(this.transform.position, this.GroundDetectDirection, out hit, this.GroundDetectDistance);
    }

    bool isBoxDown()
    {
        RaycastHit hit;

        if (this.rigidbody.SweepTest(this.GroundDetectDirection, out hit, this.GroundDetectDistance))
        {
            if (((1 << hit.collider.gameObject.layer) & this.PlaneLayer.value) > 0)
                return true;
        }
        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawLine(this.transform.position, this.transform.position + (this.GroundDetectDirection * this.GroundDetectDistance));
    }
}
