using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class SceneTransitioner : MonoBehaviour
    {
        public Button[] Button;
        //[SerializeField] private string m_Name;
        // Use this for initialization
        void Start()
        {
            //scene1Text = scene1Text.GetComponent<Button>();
        }
        public void ChangeScene(string nameOfScene)
        {
            SceneManager.LoadScene(nameOfScene);
        }
    }
}
