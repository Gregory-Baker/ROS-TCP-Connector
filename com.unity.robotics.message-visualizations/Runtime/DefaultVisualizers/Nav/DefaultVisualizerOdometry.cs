using System;
using RosMessageTypes.Nav;
using Unity.Robotics.MessageVisualizers;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

public class DefaultVisualizerOdometry : StampedDrawingVisualFactory<OdometryMsg>
{
    public float thickness = 0.01f;
    public float lengthScale = 1.0f;
    public float sphereRadius = 1.0f;
    public GameObject origin;
    [SerializeField]
    Color m_Color;

    public override void Draw(BasicDrawing drawing, OdometryMsg message, MessageMetadata meta)
    {
<<<<<<< HEAD
        drawing.SetTFTrackingType(m_TFTrackingType, message.header);
        message.Draw<FLU>(drawing, SelectColor(m_Color, meta), lengthScale, sphereRadius, thickness);
=======
        Draw<FLU>(message, drawing, SelectColor(m_Color, meta), origin, lengthScale, sphereRadius, thickness);
    }

    public static void Draw<C>(OdometryMsg message, BasicDrawing drawing, Color color, GameObject origin, float lengthScale = 1, float sphereRadius = 1, float thickness = 0.01f) where C : ICoordinateSpace, new()
    {
        // TODO
        TFFrame frame = TFSystem.instance.GetTransform(message.header);
        Vector3 pos = frame.TransformPoint(message.pose.pose.position.From<C>());
        if (origin != null)
        {
            pos += origin.transform.position;
        }
        message.pose.pose.Draw<C>(drawing);
        DefaultVisualizerTwist.Draw<C>(message.twist.twist, drawing, color, pos, lengthScale, sphereRadius, thickness);
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055
    }

    public override Action CreateGUI(OdometryMsg message, MessageMetadata meta) => () =>
    {
        message.header.GUI();
        GUILayout.Label($"Child frame ID: {message.child_frame_id}");
        message.pose.pose.GUI("Pose:");
        message.twist.twist.GUI("Twist:");
    };
}
