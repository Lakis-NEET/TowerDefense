using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // reload screen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
