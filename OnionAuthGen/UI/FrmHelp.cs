using System.Linq;
using System.Windows.Forms;

namespace OnionAuthGen
{
    public partial class FrmHelp : Form
    {
        public FrmHelp()
        {
            InitializeComponent();
            foreach (var s in Tools.GetResourceNames().Where(m => m.StartsWith("Help.") && m.EndsWith(".txt")))
            {
                LbHelp.Items.Add(s.Substring(5, s.Length - 9));
            }
            Tools.ScaleForm(this);
        }

        public void SetHelpArticle(string Name)
        {
            //TbHelp.Text = Tools.GetResourceText($"Help.{Name}.txt");
            LbHelp.SelectedItem = Name;
        }

        private void LbHelp_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            TbHelp.Text = Tools.GetResourceText($"Help.{LbHelp.SelectedItem}.txt");
        }
    }
}
