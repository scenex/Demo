using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

namespace AdrenalineRush
{
    public partial class StartupScreen : Form
    {
        DisplayModeCollection displayModeCollection;
        DisplayMode currentDisplayMode;

        public StartupScreen()
        {
            InitializeComponent();
        }



        private void StartupScreen_Load(object sender, EventArgs e)
        {
            // Find some more intelligent way to access graphics adapter capabilities
            //DemoDummy gameMock = new DemoDummy();
            //displayModeCollection = gameMock.GraphicsDevice.Adapter.SupportedDisplayModes;
            //currentDisplayMode = gameMock.GraphicsDevice.Adapter.CurrentDisplayMode;
            //gameMock.Dispose();

            foreach (DisplayMode displayMode in displayModeCollection)
            {
                if (displayMode.Format == SurfaceFormat.Color)
                {
                    Item item = new Item(displayMode.Width + "x" + displayMode.Height, displayMode);
                    comboSupportedResolutions.Items.Add(item);

                    if ((displayMode.Width == currentDisplayMode.Width) && (displayMode.Height == currentDisplayMode.Height))
                    {
                        comboSupportedResolutions.SelectedItem = item;
                    }
                }
            }           

        }

        private void RunDemo()
        {
            using (Demo game = new Demo())
            {
                game.Run();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DisplayMode displayMode = ((Item)comboSupportedResolutions.SelectedItem).Value;

            DemoSettings.SetFullscreen(chkFullscreen.Checked);
            DemoSettings.SetVSync(chkVSync.Checked);
            DemoSettings.SetAntiAlias(chkAntiAlias.Checked);           
            DemoSettings.SetDemoResolution(new DemoResolution(displayMode.Width, displayMode.Height));
            DemoSettings.SetDemoAspectRatio(displayMode.AspectRatio);
            //DemoSettings.SetDemoResolution(new DemoResolution(1680, 1050));
            //DemoSettings.SetDemoAspectRatio(1.6f);

            Thread demoThread = new Thread(new ThreadStart(RunDemo));
            demoThread.Name = "Adrenaline Rush Demo";
            demoThread.Start();

            this.Close();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboSupportedResolutions_SelectedValueChanged(object sender, EventArgs e)
        {
            Item item = (Item)comboSupportedResolutions.SelectedItem;
            lblAspectRatio.Text = Math.Round(item.Value.AspectRatio, 2).ToString();
        }

    }


    class Item
    {
        public string Name;
        public DisplayMode Value;

        public Item(string name, DisplayMode value)
        {
            Name = name; Value = value;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
