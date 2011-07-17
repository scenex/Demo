
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
        private LabelControl helloWorldLabel;

        private ButtonControl okButton;

        private ButtonControl cancelButton;

        private void InitializeComponent()
        {
            this.helloWorldLabel = new Nuclex.UserInterface.Controls.LabelControl();
            this.okButton = new Nuclex.UserInterface.Controls.Desktop.ButtonControl();
            this.cancelButton = new Nuclex.UserInterface.Controls.Desktop.ButtonControl();

            this.helloWorldLabel.Text = "Hello World! This is a label.";
            this.helloWorldLabel.Bounds = new UniRectangle(10.0f, 15.0f, 110.0f, 30.0f);

            this.okButton.Bounds = new UniRectangle(new UniScalar(1.0f, -180.0f), new UniScalar(1.0f, -40.0f), 80, 24);

            this.cancelButton.Bounds = new UniRectangle(new UniScalar(1.0f, -90.0f), new UniScalar(1.0f, -40.0f), 80, 24);

            this.Bounds = new UniRectangle(100.0f, 100.0f, 512.0f, 384.0f);
            Children.Add(this.helloWorldLabel);
            Children.Add(this.okButton);
            Children.Add(this.cancelButton);
        }
    }
}
