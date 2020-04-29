using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 5f;
	public float rotSpeed = 180f;

	float shipBoundaryRadius = 0.5f;

	void Start () {
	
	}
	
	void Update () {
        
        // buat muter muter

		Quaternion rot = transform.rotation;
        
		float z = rot.eulerAngles.z;
        
		z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        
		rot = Quaternion.Euler( 0, 0, z );
        
		transform.rotation = rot;

		// buat gerakin si kampret

		Vector3 pos = transform.position;
		 
		Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

		pos += rot * velocity;

		// buat batasan wilayah y

		if(pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
			pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
		}

		if(pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
			pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		}
        
        // buat batasan wilayah x

		float screenRatio = (float)Screen.width / (float)Screen.height;

		float widthOrtho = Camera.main.orthographicSize * screenRatio;
        
		if(pos.x + shipBoundaryRadius > widthOrtho)
        {
			pos.x = widthOrtho - shipBoundaryRadius;
		}

		if(pos.x - shipBoundaryRadius < -widthOrtho)
        {
			pos.x = -widthOrtho + shipBoundaryRadius;
		}
        
        // buat ngupdet posisi player

		transform.position = pos;

	}
}
