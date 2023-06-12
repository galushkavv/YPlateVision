using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YPlateVision
{
    public partial class FormSettings : Form
    {
        Settings settings;

        public FormSettings()
        {
            InitializeComponent();
        }

        public FormSettings(ref Settings setts)
        {
            InitializeComponent();

            this.settings = setts;
            textBoxComment.Text = settings.comment;
            textBoxMinPlate.Text = settings.thresholdForPlates.ToString();
            textBoxMinSymbol.Text = settings.thresholdForSymbols.ToString();
            textBoxPort.Text = settings.HTTPport.ToString();
            checkBoxAllowClose.Checked = !settings.allowClose;
            checkBoxRearrange.Checked = settings.rearrangeSquare;
            checkBoxStartTray.Checked = settings.startMinimized;
            

            dataGridViewAngles.Rows.Clear();
            for(int i=0; i<settings.camAngles.Count; i++)
            {
                dataGridViewAngles.Rows.Add();
                dataGridViewAngles.Rows[i].Cells[0].Value = settings.camAngles[i].camRegExp;
                dataGridViewAngles.Rows[i].Cells[1].Value = settings.camAngles[i].value;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            settings.thresholdForPlates = Convert.ToDouble(textBoxMinPlate.Text);
            settings.thresholdForSymbols = Convert.ToDouble(textBoxMinSymbol.Text);
            settings.allowClose = !checkBoxAllowClose.Checked;
            settings.comment = textBoxComment.Text;
            settings.rearrangeSquare = checkBoxRearrange.Checked;
            settings.HTTPport = Convert.ToInt32(textBoxPort.Text);
            settings.startMinimized = checkBoxStartTray.Checked;

            settings.camAngles = new List<CamAngle>(dataGridViewAngles.RowCount);

            for (int i = 0; i < dataGridViewAngles.Rows.Count - 1; i++)
            {
                CamAngle tmp = new CamAngle();
                tmp.camRegExp = dataGridViewAngles.Rows[i].Cells[0].Value.ToString();
                tmp.value = Convert.ToInt32(dataGridViewAngles.Rows[i].Cells[1].Value);
                settings.camAngles.Add(tmp);
            }

            settings.Save();
            this.Close();
        }
    }
}
