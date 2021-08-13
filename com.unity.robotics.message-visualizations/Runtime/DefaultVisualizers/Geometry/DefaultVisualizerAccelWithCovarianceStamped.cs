using System;
using RosMessageTypes.Geometry;
using Unity.Robotics.MessageVisualizers;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

public class DefaultVisualizerAccelWithCovarianceStamped : StampedDrawingVisualFactory<AccelWithCovarianceStampedMsg>
{
    public float m_Thickness = 0.01f;
    public float m_LengthScale = 1.0f;
    public float m_SphereRadius = 1.0f;
    public GameObject m_Origin;
    [SerializeField]
    Color m_Color;
    bool m_ViewCovariance;

    public override void Draw(BasicDrawing drawing, AccelWithCovarianceStampedMsg message, MessageMetadata meta)
    {
<<<<<<< HEAD
        drawing.SetTFTrackingType(m_TFTrackingType, message.header);
        message.accel.accel.Draw<FLU>(drawing, SelectColor(m_Color, meta), m_Origin, m_LengthScale, m_SphereRadius, m_Thickness);
=======
        DefaultVisualizerAccelWithCovariance.Draw<FLU>(message.accel, drawing, SelectColor(m_Color, meta), m_Origin, m_LengthScale, m_SphereRadius, m_Thickness);
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055
    }

    public override Action CreateGUI(AccelWithCovarianceStampedMsg message, MessageMetadata meta)
    {
        return () =>
        {
            message.header.GUI();
            message.accel.accel.GUI();
            MessageVisualizations.GUIGrid(message.accel.covariance, 6, ref m_ViewCovariance);
        };
    }
}
