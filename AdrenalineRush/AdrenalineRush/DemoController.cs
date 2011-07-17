
namespace AdrenalineRush
{
    using Nuclex.UserInterface;
    using Nuclex.UserInterface.Controls;
    using Nuclex.UserInterface.Controls.Desktop;

    public partial class DemoController : WindowControl
    {
        public DemoController()
        {
            InitializeComponent();
        }
    }

    partial class DemoController
    {
        private LabelControl lblSeek;

        private ButtonControl btnPlayPause;

        private ButtonControl btnClose;

        private InputControl txtSeek;

        private void InitializeComponent()
        {
            this.Title = "Timeline Controller";
            this.lblSeek = new LabelControl();

            this.btnPlayPause = new ButtonControl();
            this.btnClose = new ButtonControl();

            this.txtSeek = new InputControl();

            this.Bounds = new UniRectangle(100.0f, 100.0f, 512.0f, 384.0f);

            this.lblSeek.Text = "Seek to: ";
            this.lblSeek.Bounds = new UniRectangle(10.0f, 45.0f, 110.0f, 30.0f);
            this.btnPlayPause.Bounds = new UniRectangle(new UniScalar(1.0f, -180.0f), new UniScalar(1.0f, -40.0f), 80, 24);
            this.btnClose.Bounds = new UniRectangle(new UniScalar(1.0f, -90.0f), new UniScalar(1.0f, -40.0f), 80, 24);
            
            this.txtSeek.Bounds = new UniRectangle(10.0f, 80.0f, 100, 20);
            this.btnPlayPause.Text = "Play";
            this.btnClose.Text = "Close";
            
            Children.Add(this.lblSeek);
            Children.Add(this.btnPlayPause);
            Children.Add(this.btnClose);
            Children.Add(this.txtSeek);
        }
    }
}
