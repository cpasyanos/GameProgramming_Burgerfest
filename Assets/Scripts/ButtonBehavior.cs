using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {

   public void quitButton()
   {
      Debug.Log("quitted");
      Application.Quit();
   }

}