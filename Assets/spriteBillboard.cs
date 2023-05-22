
using UnityEngine;

public class spriteBillboard : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
     //   transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0f);
    }
}
