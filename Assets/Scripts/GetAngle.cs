using UnityEngine;
using System.Collections;

public class GetAngle : MonoBehaviour {

    public SteamVR_TrackedObject tracked_controller;
    public SteamVR_TrackedObject camera_head;

    // Use this for initialization
    void Start () {
        if (tracked_controller == null)
        {
            tracked_controller = GetComponent<SteamVR_TrackedObject>();
        }

        if (camera_head == null)
        {
            camera_head = GameObject.Find("Camera (head)").GetComponent<SteamVR_TrackedObject>();
        }
        
        var device_controller = SteamVR_Controller.Input((int)tracked_controller.index);

    }

    // Update is called once per frame
    void Update () {
        var device_controller = SteamVR_Controller.Input((int)tracked_controller.index);

        if (device_controller.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("トリガーを浅く引いた");

            // 視線の向き（頭部の向き）を求める
            Vector3 lineOfSight = camera_head.transform.forward;
            Debug.Log("lineOfSight: " + lineOfSight);

            // Cameraからコントローラーまでのベクトルを取得する
            Vector3 controllerFromHead = tracked_controller.transform.position - camera_head.transform.position;
            Debug.Log("tracked_controller.position: " + tracked_controller.transform.position);
            Debug.Log("camera_head.position: " + camera_head.transform.position);

            // 視線方向に対するコントローラー角度を求める
            var angle = Vector3.Angle(lineOfSight, controllerFromHead);
            Debug.Log("angle: " + angle);

        }

    }
}
