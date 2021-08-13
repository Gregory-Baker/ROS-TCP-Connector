using System;
using RosMessageTypes.Geometry;
using Unity.Robotics.MessageVisualizers;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

public class DefaultVisualizerAccelStamped : StampedDrawingVisualFactory<AccelStampedMsg>
{
    public float m_Thickness = 0.01f;
    public float m_LengthScale = 1.0f;
    public float m_SphereRadius = 1.0f;
    public GameObject m_Origin;
    [SerializeField]
    Color m_Color;
    [SerializeField]
    TFTrackingType m_TFTrackingType;

    public override void Draw(BasicDrawing drawing, AccelStampedMsg message, MessageMetadata meta)
    {
        drawing.SetTFTrackingType(m_TFTrackingType, message.header);
<<<<<<< HEAD
        message.accel.Draw<FLU>(drawing, SelectColor(m_Color, meta), m_Origin, m_LengthScale, m_SphereRadius, m_Thickness);
=======
        DefaultVisualizerAccel.Draw<FLU>(message.accel, drawing, SelectColor(m_Color, meta), m_Origin, m_LengthScale, m_SphereRadius, m_Thickness);
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055
    }

    public override Action CreateGUI(AccelStampedMsg message, MessageMetadata meta)
    {
        return () =>
        {
            message.header.GUI();
            message.accel.GUI();
        };
    }
}
