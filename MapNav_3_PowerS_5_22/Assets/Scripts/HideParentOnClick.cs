using UnityEngine;
using System.Collections;

public class HideParentOnClick : MonoBehaviour {
    void Start () {}
    void Update () {}
    
    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
