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
            foreach (var s in Tools.GetResourceNames().Where(m => m.StartsWith("Help.") && m.EndsWith(".txt")))
            {
                LbHelp.Items.Add(new HelpFile(s.Substring(5, s.Length - 9)));
            }
            Tools.ScaleForm(this);
        }

        public void SetHelpArticle(string Name)
        {
            for(var i = 0; i < LbHelp.Items.Count; i++)
            {
                var H = (HelpFile)LbHelp.Items[i];
                if (H.ResourceName == Name)
                {
                    LbHelp.SelectedIndex = i;
                }
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
    }
}
