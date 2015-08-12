using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pikabu_BestComment
{
    public partial class GUISettings : Form
    {
        private Settings settings;
        public GUISettings(Settings settings)
        {
            InitializeComponent();
            this.settings = settings;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if(validateUserInput())
            {
                settings.IntervalMinutes = Int32.Parse(IntervalTextBox.Text.Trim());
                settings.CommentsCount = Int32.Parse(commentsQuantityTextBox.Text.Trim());
                settings.NotifyUser = notificateCheckBox.Checked;
                this.Dispose();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void deleteDataButton_Click(object sender, EventArgs e)
        {
            Directory.Delete(Settings.SaveDirPath, true);
            deleteDataButton.Enabled = false;
        }

        private void GUISettings_Shown(object sender, EventArgs e)
        {
            IntervalTextBox.Text = settings.IntervalMinutes.ToString();
            commentsQuantityTextBox.Text = settings.CommentsCount.ToString();
            notificateCheckBox.Checked = settings.NotifyUser;
            DirectoryInfo dirInfo = new DirectoryInfo(Settings.SaveDirPath);
            dataLocationLabel.Text = String.Format("Данные хранятся в {0}", dirInfo.FullName);
            deleteDataButton.Enabled = Directory.Exists(Settings.SaveDirPath);
        }

        private bool validateUserInput()
        {
            string intervalText = IntervalTextBox.Text.Trim();
            string commentsQuantityText = commentsQuantityTextBox.Text.Trim();
            int intervalMinutes = 0;
            int commentsQuantity = 0;
            if(String.IsNullOrEmpty(intervalText) || !Int32.TryParse(intervalText, out intervalMinutes))
            {
                MessageBox.Show(this, "Интервал таким быть не может.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(intervalMinutes < 10)
            {
                MessageBox.Show(this, "Интервал слишком маленький. Минимум 10 минут.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(String.IsNullOrEmpty(commentsQuantityText) || !Int32.TryParse(commentsQuantityText, out commentsQuantity) || commentsQuantity <= 0)
            {
                MessageBox.Show(this, "Количество комментариев не должно быть таким.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
