using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    bool isInRange = false;
    bool isChatting = false; 
    public GameObject pressE;
    public GameObject Chat;
    public CharacterControll cc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isChatting){
            pressE.SetActive(false);
            Chat.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            cc.enabled = false;
        }
        if(!isChatting)
        {
            if(isInRange){
                pressE.SetActive(true);
                if (Input.GetKeyDown("e"))
            {   
            isChatting = true;
            }
            }
            else{
                pressE.SetActive(false);
            }
            
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player"){
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag =="Player"){
            isInRange = false;
        }
    }
}
