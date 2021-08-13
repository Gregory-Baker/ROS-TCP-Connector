using System;
using RosMessageTypes.Geometry;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

namespace Unity.Robotics.MessageVisualizers
{
    public class DefaultVisualizerVector3Stamped : StampedDrawingVisualFactory<Vector3StampedMsg>
    {
        [SerializeField]
        float m_Radius = 0.01f;
        [SerializeField]
        Color m_Color;
        [SerializeField]
        string m_Label;
        [SerializeField]
        TFTrackingType m_TFTrackingType;

        public override void Draw(BasicDrawing drawing, Vector3StampedMsg message, MessageMetadata meta)
        {
            drawing.SetTFTrackingType(m_TFTrackingType, message.header);
<<<<<<< HEAD
            message.vector.Draw<FLU>(drawing, SelectColor(m_Color, meta), SelectLabel(m_Label, meta), m_Radius);
=======
            DefaultVisualizerVector3.Draw<FLU>(message.vector, drawing, SelectColor(m_Color, meta), SelectLabel(m_Label, meta), m_Radius);
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055
        }

        public override Action CreateGUI(Vector3StampedMsg message, MessageMetadata meta)
        {
            return () =>
            {
                message.header.GUI();
                message.vector.GUI();
            };
        }
    }
}
