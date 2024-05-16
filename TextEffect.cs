using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.Applications;
using Tizen.NUI.Components;
using System.Collections.Generic;

namespace TextEffect
{
    class Program : NUIApplication
    {
        private static NUIApplication app;
        private static View RootView;

        View makeView(Size size, ImageView image, TextLabel label)
        {
            var view = new View
            {
                Size2D = size,
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                ParentOrigin = ParentOrigin.TopLeft,
            };

            view.Add(image);
            view.Add(label);

            return view;
        }

        ImageView makeImageView(string url)
        {
            var image = new ImageView
            {
                ResourceUrl = url,
                //Size = new Tizen.NUI.Size(1000, 500),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };

            return image;
        }

        TextLabel makeTextLabel(string s, Color backgroundColor, Color TextColor, int pointSize)
        {
            TextLabel label = new TextLabel
            {
                Text = s,
                BackgroundColor = backgroundColor,
                TextColor = TextColor,
                Position2D = new Position2D(0, 0),
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                ParentOrigin = ParentOrigin.TopLeft,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PointSize = pointSize,
                RemoveFrontInset = false,
                RemoveBackInset = false,
                Cutout = true,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            return label;
        }

        protected override void OnCreate()
        {
            Window window = Window.Instance;
            window.WindowSize = new Size(1000, 1250);

            string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            FontClient.Instance.AddCustomFontDirectory(resourcePath + "/fonts");

            RootView = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                ParentOrigin = ParentOrigin.TopLeft,

            };
            Window.Instance.GetDefaultLayer().Add(RootView);

            var image1 = makeImageView(resourcePath + "/image/colorful.jpg");
            TextLabel label1 = makeTextLabel("COLORFUL", new Color(0.0f, 0.0f, 0.0f, 1.0f), new Color(0.0f, 0.0f, 0.0f, 0.0f), 120);
            label1.FontFamily = "Gotham";
            var view1 = makeView(new Size(1000, 250), image1, label1);
            RootView.Add(view1);

            var image2 = makeImageView(resourcePath + "/image/leaves.jpg");
            TextLabel label2 = makeTextLabel("Leavin' Leaf", new Color(1.0f, 1.0f, 1.0f, 1.0f), new Color(0.0f, 0.0f, 0.0f, 0.3f), 200);
            label2.FontFamily = "Morganite";
            label2.WidthResizePolicy = ResizePolicyType.Fixed;
            label2.HeightResizePolicy = ResizePolicyType.Fixed;
            label2.Size = new Size(1000, 200);
            label2.Ellipsis = false;
            label2.HorizontalAlignment = HorizontalAlignment.Begin;
            var view2 = makeView(new Size(1000, 250), image2, label2);
            RootView.Add(view2);

            var iamge4 = makeImageView(resourcePath + "/image/sky.jpg");
            TextLabel label4 = makeTextLabel("SUNSET", new Color(0.0f, 0.0f, 0.0f, 0.5f), new Color(0.0f, 0.0f, 0.0f, 0.0f), 150);
            var shadow = new PropertyMap();
            shadow.Add("color", new PropertyValue(new Color(0.0f, 0.0f, 0.0f, 0.5f)));
            shadow.Add("offset", new PropertyValue(new Vector2(5, 5)));
            shadow.Add("blurRadius", new PropertyValue(3));
            label4.Shadow = shadow;
            label4.FontFamily = "Montserrat";
            var view4 = makeView(new Size(1000, 250), iamge4, label4);
            RootView.Add(view4);

            var image3 = makeImageView(resourcePath + "/image/wave.gif");
            TextLabel label3 = makeTextLabel("WAVE", new Color(0.0f, 0.0f, 0.0f, 0.9f), new Color(0.0f, 0.0f, 0.0f, 0.0f), 100);
            label3.FontFamily = "MachineatDemo";
            var view3 = makeView(new Size(1000, 250), image3, label3);
            RootView.Add(view3);

            var image5 = makeImageView(resourcePath + "/image/ocean.gif");
            TextLabel label5 = makeTextLabel("OCEAN", new Color(1.0f, 1.0f, 1.0f, 0.8f), new Color(0.0f, 0.0f, 0.0f, 0.0f), 150);
            label5.FontFamily = "Montserrat ExtraBold";
            var view5 = makeView(new Size(1000, 250), image5, label5);
            RootView.Add(view5);
        }
        static void Main(string[] args)
        {
            app = new Program();
            app.Run(args);
        }
    }
}
