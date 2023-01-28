using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconInputManager : MonoBehaviour
{
    private List<Joycon> joycons;

    // Values made available via Unity
    public Vector3 accel;
    public int jc_ind = 0;
    public Vector3 GyroVector;
    public Vector3 GyroVector_Delta;
    public Vector3 GyroQuaternion;
    public Vector3 GyroQuaternion_Old;
    public Vector3 GyroQuaternion_Delta;
    private bool Activating;

    void Start()
    {
        accel = new Vector3(0, 0, 0);
        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1)
        {
            Activating = false;
        }
        else
        {
            Activating = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Activating) return;
        // make sure the Joycon only gets checked if attached
        if (joycons.Count > 0)
        {
            Joycon j = joycons[jc_ind];

            // GetButtonDown checks if a button has been pressed (not held)
            if (j.GetButtonDown(Joycon.Button.SHOULDER_2))
            {
                Debug.Log("Shoulder button 2 pressed");
                // GetStick returns a 2-element vector with x/y joystick components
                Debug.Log(string.Format("Stick x: {0:N} Stick y: {1:N}", j.GetStick()[0], j.GetStick()[1]));

                // Joycon has no magnetometer, so it cannot accurately determine its yaw value. Joycon.Recenter allows the user to reset the yaw value.
                //j.Recenter();
                GyroVector_Delta = Vector3.zero;
                GyroQuaternion_Delta = Vector3.zero;
                GyroQuaternion_Old = j.GetVector().eulerAngles;
            }
            // GetButtonDown checks if a button has been released
            if (j.GetButtonUp(Joycon.Button.SHOULDER_2))
            {
                Debug.Log("Shoulder button 2 released");
            }
            // GetButtonDown checks if a button is currently down (pressed or held)
            if (j.GetButton(Joycon.Button.SHOULDER_2))
            {
                Debug.Log("Shoulder button 2 held");
            }

            if (j.GetButtonDown(Joycon.Button.DPAD_DOWN))
            {
                Debug.Log("Rumble");
                j.SetRumble(160, 320, 0.6f, 200);
            }

            // Accel values:  x, y, z axis values (in Gs)
            accel = j.GetAccel();

            GyroQuaternion = j.GetVector().eulerAngles;
            GyroQuaternion_Delta = GyroQuaternion - GyroQuaternion_Old;
            GyroVector = j.GetGyro();
            float Gx = (Mathf.Abs(GyroVector.x) > 0.03 ? GyroVector.x : 0) + GyroVector_Delta.x;
            float Gy = (Mathf.Abs(GyroVector.y) > 0.03 ? GyroVector.y : 0) + GyroVector_Delta.y;
            float Gz = (Mathf.Abs(GyroVector.z) > 0.03 ? GyroVector.z : 0) + GyroVector_Delta.z;
            GyroVector_Delta = new Vector3(Gx, Gy, Gz);
        }
        else
        {
            Debug.Log("No Joycon");
        }
    }
}
