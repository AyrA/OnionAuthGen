using System.Linq;
using System.Windows.Forms;

namespace OnionAuthGen
{
    public partial class FrmHelp : Form
    {
        private class HelpFile
        {
            public string ResourceName { get; private set; }
            public string Title { get; private set; }

            public HelpFile(string ResName)
            {
                ResourceName = ResName;
                Title = GetText().Split('\n').First().Trim();
            }

            public string GetText()
            {
                return Tools.GetResourceText($"Help.{ResourceName}.txt");
            }
            public override string ToString()
            {
                if (string.IsNullOrEmpty(Title))
                {
                    if (string.IsNullOrEmpty(ResourceName))
                    {
                        return "Untitled help file";
                    }
                    return ResourceName;
                }
                return Title;
            }
        }

        public FrmHelp()
        {
            InitializeComponent();
            var HelpFiles = Tools.GetResourceNames()
                .Where(m => m.StartsWith("Help.") && m.EndsWith(".txt"))
                .Select(m => new HelpFile(m.Substring(5, m.Length - 9)))
                .OrderBy(m => m.Title)
                .ToArray();
            LbHelp.Items.AddRange(HelpFiles);
            Tools.ScaleForm(this);
        }

        public void SetHelpArticle(string Name)
        {
            var Set = false;
            for(var i = 0; i < LbHelp.Items.Count; i++)
            {
                var H = (HelpFile)LbHelp.Items[i];
                if (H.ResourceName == Name)
                {
                    LbHelp.SelectedIndex = i;
                    Set = true;
                }
            }
            if (!Set)
            {
#if DEBUG
                MessageBox.Show($"Help file not found: {Name}", "DEBUG error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                System.Diagnostics.Debug.Print($"Help file not found: {Name}");
            }
        }

        private void LbHelp_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (LbHelp.SelectedIndex >= 0)
            {
                var H = (HelpFile)LbHelp.SelectedItem;
                TbHelp.Text = H.GetText();
            }
        }

        private void FrmHelp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Close();
            }
        }
    }
}
