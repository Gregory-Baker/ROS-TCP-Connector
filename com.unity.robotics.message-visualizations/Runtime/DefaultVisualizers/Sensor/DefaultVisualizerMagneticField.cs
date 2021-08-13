using System;
using RosMessageTypes.Sensor;
using Unity.Robotics.MessageVisualizers;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

public class DefaultVisualizerMagneticField : StampedDrawingVisualFactory<MagneticFieldMsg>
{
    [SerializeField]
    Color m_Color;
    bool m_ViewCovariance;

    public override void Draw(BasicDrawing drawing, MagneticFieldMsg message, MessageMetadata meta)
    {
<<<<<<< HEAD
        drawing.SetTFTrackingType(m_TFTrackingType, message.header);
        message.Draw<FLU>(drawing, SelectColor(m_Color, meta));
=======
        Draw<FLU>(message, drawing, SelectColor(m_Color, meta));
    }

    public static void Draw<C>(MagneticFieldMsg message, BasicDrawing drawing, Color color, float lengthScale = 1) where C : ICoordinateSpace, new()
    {
        drawing.DrawArrow(Vector3.zero, message.magnetic_field.From<C>() * lengthScale, color);
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055
    }

    public override Action CreateGUI(MagneticFieldMsg message, MessageMetadata meta)
    {
        return () =>
        {
            message.header.GUI();
            message.magnetic_field.GUI("Magnetic field (Tesla)");
            MessageVisualizations.GUIGrid(message.magnetic_field_covariance, 3, "Covariance", ref m_ViewCovariance);
        };
    }
}
