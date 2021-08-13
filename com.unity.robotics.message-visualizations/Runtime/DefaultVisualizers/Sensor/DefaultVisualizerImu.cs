using System;
using RosMessageTypes.Sensor;
using Unity.Robotics.MessageVisualizers;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

public class DefaultVisualizerImu : StampedDrawingVisualFactory<ImuMsg>
{
    [SerializeField]
    public Color m_Color;
    [SerializeField]
    public float m_LengthScale = 1;
    [SerializeField]
    public float m_SphereRadius = 1;
    [SerializeField]
    public float m_Thickness = 0.01f;
    bool m_ViewAccel;
    bool m_ViewAngular;
    bool m_ViewOrientation;

    public override void Draw(BasicDrawing drawing, ImuMsg message, MessageMetadata meta)
    {
<<<<<<< HEAD
        drawing.SetTFTrackingType(m_TFTrackingType, message.header);
        message.Draw<FLU>(drawing, SelectColor(m_Color, meta), m_LengthScale, m_SphereRadius, m_Thickness);
=======
        Draw<FLU>(message, drawing, SelectColor(m_Color, meta), m_LengthScale, m_SphereRadius, m_Thickness);
    }

    public static void Draw<C>(ImuMsg message, BasicDrawing drawing, Color color, float lengthScale = 1, float sphereRadius = 1, float thickness = 0.01f) where C : ICoordinateSpace, new()
    {
        TFFrame frame = TFSystem.instance.GetTransform(message.header);
        message.orientation.Draw<C>(drawing, frame.translation);
        drawing.DrawArrow(frame.translation, frame.translation + message.linear_acceleration.From<C>() * lengthScale, color, thickness);
        MessageVisualizations.DrawAngularVelocityArrow(drawing, message.angular_velocity.From<C>(), frame.translation, color, sphereRadius, thickness);
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055
    }

    public override Action CreateGUI(ImuMsg message, MessageMetadata meta)
    {
        return () =>
        {
            message.header.GUI();
            message.orientation.GUI("Orientation");
            message.angular_velocity.GUI("Angular velocity");
            message.linear_acceleration.GUI("Linear acceleration");
            MessageVisualizations.GUIGrid(message.orientation_covariance, 3, "Orientation covariance", ref m_ViewOrientation);
            MessageVisualizations.GUIGrid(message.angular_velocity_covariance, 3, "Angular velocity covariance", ref m_ViewAngular);
            MessageVisualizations.GUIGrid(message.linear_acceleration_covariance, 3, "Linear acceleration covariance", ref m_ViewAccel);
        };
    }
}
