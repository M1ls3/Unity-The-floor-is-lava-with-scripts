using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace MyAssets
{
    public class CameraMoving : MonoBehaviour
    {
        private Vector3 startPos;
        public Transform sphere;
        // Start is called before the first frame update
        void Start()
        {
            startPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            try
            {
                CameraMove.FollowSphere(transform, sphere, 5f, 2f, 0f);
            }
            catch
            {
                CameraMove.ReplaceCamera(transform, startPos);
            }
        }
    }

    public class Camera
    {
        private Vector3 position;
        private Quaternion rotation;

        public Vector3 Position { get { return position; } set { position = value; } }
        public Quaternion Rotation { get { return rotation; }  set { rotation = value; } }

        public Camera()
        {
            position = Vector3.zero; rotation = Quaternion.identity;
        }

        public Camera(Transform transform, Transform sphere)
        {
            if (transform)
            {
                try
                {
                    Vector3 spherePosition = sphere.position;
                    transform.position = spherePosition;
                }
                catch
                {
                    transform.position = position;
                }
            }
            else
            {
                Debug.LogError("Sphere reference is not set. Please assign the sphere GameObject to the script.");
            }
        }
    }

    public class CameraMove : Camera
    {
        private static Camera camera;

        public Camera Camera { get { return camera; } set {  camera = value; } }

        public static void FollowSphere(Transform transform, Transform sphere, float distanceX, float distanceY, float distanceZ)
        {
            camera = new Camera(transform, sphere);

            if (camera != null)
            {
                Vector3 spherePosition = sphere.position;
                Vector3 newPosition = spherePosition + new Vector3(distanceX, distanceY, distanceZ);
                transform.position = newPosition;
                transform.LookAt(spherePosition);
            }
            else
            {
                Debug.LogError("Camera reference is not set.");
            }
        }

        public static void ReplaceCamera(Transform transform, Vector3 position)
        {
            Vector3 newPosition = position;
            transform.position = newPosition;
        }
    }
}