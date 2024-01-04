using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public float rotationSpeed = 5f;

    private void Update()
    {
        transform.rotation = Rotation();
        
        if (transform.rotation.eulerAngles.z > 0 && transform.rotation.eulerAngles.z < 180) transform.localScale = GunScale(-1);
        else transform.localScale = GunScale(1);
    }
    
    private Vector3 GunScale(int X) => new Vector3(X, 1, 1f);

    private Vector3 MousePos()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 direction = mousePosition - transform.position;
        return direction;
    }

    private Quaternion Rotation()
    {
        float angle = Mathf.Atan2(MousePos().y, MousePos().x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        return Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
