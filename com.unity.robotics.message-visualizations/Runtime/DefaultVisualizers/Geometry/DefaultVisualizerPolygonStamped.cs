using System;
using RosMessageTypes.Geometry;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

namespace Unity.Robotics.MessageVisualizers
{
    public class DefaultVisualizerPolygonStamped : StampedDrawingVisualFactory<PolygonStampedMsg>
    {
        [SerializeField]
        float m_Thickness = 0.01f;
        [SerializeField]
        Color m_Color;
        [SerializeField]
        TFTrackingType m_TFTrackingType;

        public override void Draw(BasicDrawing drawing, PolygonStampedMsg message, MessageMetadata meta)
        {
            drawing.SetTFTrackingType(m_TFTrackingType, message.header);
<<<<<<< HEAD
            message.polygon.Draw<FLU>(drawing, SelectColor(m_Color, meta), m_Thickness);
=======
            DefaultVisualizerPolygon.Draw<FLU>(message.polygon, drawing, SelectColor(m_Color, meta), m_Thickness);
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055
        }

        public override Action CreateGUI(PolygonStampedMsg message, MessageMetadata meta)
        {
            return () =>
            {
                message.header.GUI();
                message.polygon.GUI();
            };
        }
    }
}
