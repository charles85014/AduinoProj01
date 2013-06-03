using UnityEngine;
using System.Collections;

public class BoxCreat : MonoBehaviour
{
    public static BoxCreat master;

    public GameObject Box;
    public bool BoxCanCreate = true;

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

    // Update is called once per frame
    void Update()
    {
        //if (this.BoxCanCreate)
        //{
        //    GameObject obj = (GameObject)Instantiate(this.Box, this.transform.position, this.Box.transform.rotation);
        //    this.BoxCanCreate = false;
        //}
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 3);
    }
}
