using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private float planetMass;
    [SerializeField] private Vector2 planetDistance;
    private float planetDistanceFloat;
    private float angle;

    private float forcef;







    public Vector2 GetVelocity(Transform _transform)
    {
        planetDistance = (transform.position - _transform.position);
        planetDistanceFloat = Mathf.Sqrt(Mathf.Pow(planetDistance.x, 2) + Mathf.Pow(planetDistance.y, 2));
        forcef = planetMass / Mathf.Pow(planetDistanceFloat, 2);

        return new Vector2(forcef * planetDistance.x, forcef * planetDistance.y);
    }

    public Vector3 GetAngle(Transform _transform)
    {
        planetDistance = (transform.position - _transform.position);
        angle = Mathf.Atan2(planetDistance.y, planetDistance.x) * Mathf.Rad2Deg;
        return new Vector3(0, 0, 90 + angle);
    }

}
