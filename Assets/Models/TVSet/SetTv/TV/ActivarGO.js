#pragma strict
 
var Computer : GameObject;

function Start()
{
    Computer.SetActive(false);
}

function OnTriggerStay () 
 
{  
      
      
    if(Input.GetMouseButtonDown(0)) {
        Computer.SetActive (true);
    }
}

function OnTriggerExit ()
{
    Computer.SetActive (false);
}