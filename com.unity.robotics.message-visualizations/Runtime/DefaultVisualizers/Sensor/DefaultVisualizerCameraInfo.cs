using System;
using RosMessageTypes.Sensor;
using Unity.Robotics.MessageVisualizers;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using UnityEngine;

public class DefaultVisualizerCameraInfo : TextureVisualFactory<CameraInfoMsg>
{
    [SerializeField]
    public string ImageTopic;
    bool m_ViewK;
    bool m_ViewP;
    bool m_ViewR;

    public override Texture2D CreateTexture(CameraInfoMsg message)
    {
        // False if ROI not used, true if subwindow captured
<<<<<<< HEAD
        if (message.roi.do_rectify)
        {
            RosTopicState imageState = ROSConnection.GetOrCreateInstance().GetTopic(ImageTopic);
            if (imageState != null)
            {
                var imageVisual = imageState.Visual as ITextureVisual;
                if (imageVisual != null)
                    return message.roi.RegionOfInterestTexture(imageVisual.GetTexture());
            }
        }
=======
        if (!message.roi.do_rectify)
            return null;

        RosTopicState imageState = ROSConnection.GetOrCreateInstance().GetTopic(imageTopic);
        if (imageState == null)
            return null;

        RosTopicVisualizationState visualizationState = RosTopicVisualizationState.GetOrCreate(imageState);
        var imageVisual = visualizationState.Visual as ITextureVisual;
        if (imageVisual == null)
            return null;
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055

        return message.roi.RegionOfInterestTexture(imageVisual.GetTexture());
    }

    public override Action CreateGUI(CameraInfoMsg message, MessageMetadata meta, Texture2D tex)
    {
        return () =>
        {
            message.header.GUI();
            GUILayout.Label($"Height x Width: {message.height}x{message.width}\nDistortion model: {message.distortion_model}");
            GUILayout.Label($"Distortion parameters: {string.Join(", ", message.d)}");
            MessageVisualizations.GUIGrid(message.k, 3, "K", ref m_ViewK);
            MessageVisualizations.GUIGrid(message.r, 3, "R", ref m_ViewR);
            MessageVisualizations.GUIGrid(message.p, 3, "P", ref m_ViewP);
            GUILayout.Label($"Binning X: {message.binning_x}\nBinning Y: {message.binning_y}");
            message.roi.GUI(tex);
        };
    }
}
