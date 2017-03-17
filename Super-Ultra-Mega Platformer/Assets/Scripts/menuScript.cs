using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets._2D
{
    public class menuScript : MonoBehaviour
    {

        public Button scene1Text;

        // Use this for initialization
        void Start()
        {
            //scene1Text = scene1Text.GetComponent<Button>();
        }

        public void scene1Press()
        {
            Application.LoadLevel(1);
        }
    }
}
