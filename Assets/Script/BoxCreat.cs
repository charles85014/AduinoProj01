using UnityEngine;
using System.Collections;

public class BoxCreat : MonoBehaviour
{
    public static BoxCreat master;

    public GameObject Box;

    public float ColdDownTime;

    void Awake()
    {
        master = this;
    }

    void Start()
    {
        GameObject obj = (GameObject)Instantiate(this.Box, this.transform.position, this.Box.transform.rotation);
        obj.GetComponent<BoxControl>().isFirstBox = true;
    }

    public void CallCreateBox()
    {
        StartCoroutine(CreateBox());
    }

    IEnumerator CreateBox()
    {
        yield return new WaitForSeconds(ColdDownTime);
        GameObject obj = (GameObject)Instantiate(this.Box, this.transform.position, this.Box.transform.rotation);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 3);
    }
}
