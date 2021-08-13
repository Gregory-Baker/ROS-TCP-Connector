using System;
using RosMessageTypes.Geometry;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

namespace Unity.Robotics.MessageVisualizers
{
    public class DefaultVisualizerPointStamped : StampedDrawingVisualFactory<PointStampedMsg>
    {
        [SerializeField]
        float m_Radius = 0.01f;
        [SerializeField]
        Color m_Color;
        [SerializeField]
        string m_Label;
        [SerializeField]
        TFTrackingType m_TFTrackingType;

        public override void Draw(BasicDrawing drawing, PointStampedMsg message, MessageMetadata meta)
        {
            drawing.SetTFTrackingType(m_TFTrackingType, message.header);
<<<<<<< HEAD
            message.point.Draw<FLU>(drawing, SelectColor(m_Color, meta), SelectLabel(m_Label, meta), m_Radius);
=======
            DefaultVisualizerPoint.Draw<FLU>(message.point, drawing, SelectColor(m_Color, meta), SelectLabel(m_Label, meta), m_Radius);
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055
        }

        public override Action CreateGUI(PointStampedMsg message, MessageMetadata meta)
        {
            return () =>
            {
                message.header.GUI();
                message.point.GUI();
            };
        }
    }
}
