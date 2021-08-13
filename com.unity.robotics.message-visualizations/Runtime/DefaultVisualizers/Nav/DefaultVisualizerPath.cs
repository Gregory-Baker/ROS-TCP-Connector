using System;
using System.Linq;
using RosMessageTypes.Geometry;
using RosMessageTypes.Nav;
using Unity.Robotics.MessageVisualizers;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

public class DefaultVisualizerPath : StampedDrawingVisualFactory<PathMsg>
{
    [SerializeField]
    float m_Thickness;
    [SerializeField]
    Color m_Color;

    public override void Draw(BasicDrawing drawing, PathMsg message, MessageMetadata meta)
    {
<<<<<<< HEAD
        drawing.SetTFTrackingType(m_TFTrackingType, message.header);
        message.Draw<FLU>(drawing, SelectColor(m_Color, meta), m_Thickness);
=======
        Draw<FLU>(message, drawing, SelectColor(m_Color, meta), m_Thickness);
    }

    public static void Draw<C>(PathMsg message, BasicDrawing drawing, Color color, float thickness = 0.1f)
        where C : ICoordinateSpace, new()
    {
        drawing.DrawPath(message.poses.Select(pose => pose.pose.position.From<C>()), color, thickness);
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055
    }

    public override Action CreateGUI(PathMsg message, MessageMetadata meta)
    {
        return () =>
        {
            message.header.GUI();
            foreach (PoseStampedMsg pose in message.poses)
            {
                pose.header.GUI();
                pose.pose.GUI();
            }
        };
    }
}
