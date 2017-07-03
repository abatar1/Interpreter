using System.Windows.Forms;

namespace Interpreter.UI
{
    public partial class PopupForm : Form
    {
        public PopupForm()
        {
            InitializeComponent();
        }

        public string Key => keyTextBox.Text;
    }
}
