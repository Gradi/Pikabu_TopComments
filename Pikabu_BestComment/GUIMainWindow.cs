using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Pikabu_BestComment
{
    public partial class GUIMainWindow : Form
    {
        private Settings settings;
        private PikabuGetter getter;
        private DataTable table;
        private TimeSpan previousTick;
        private TimeSpan futureSpan;

        public GUIMainWindow()
        {
            InitializeComponent();
        }

        private void GUIMainWindow_Load(object sender, EventArgs e)
        {
            settings = Settings.tryLoad();
            getter = new PikabuGetter(settings);
            getter.tryLoadComments();
            table = new DataTable();
            table.Columns.Add("Плюсы");
            table.Columns.Add("Автор");
            table.Columns.Add("Комментарий");
            table.Columns.Add("Название поста");
            commentsDataGridView.DataSource = table;
            resetTimer();
            mainTimer.Start();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            new GUIAbout().ShowDialog(this);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = getter.updateComments();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(getter.status == Status.Error)
            {
                showBallon(getter.lastException.Message, true);
            }
            else if(settings.NotifyUser && e.Result != null)
            {
                PikabuComment com = e.Result as PikabuComment;
                showBallon(String.Format("{0}: +{1} - {2}", com.CommentAuthor, com.CommentLikes, com.CommentText), false);
            }
            mainTimer.Start();
            this.Enabled = true;
            updateTable();
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan now = new TimeSpan(DateTime.Now.Ticks);
            if (now.TotalMinutes - previousTick.TotalMinutes >= settings.IntervalMinutes)
            {
                mainTimer.Stop();
                this.Enabled = false;
                backgroundWorker.RunWorkerAsync();
                resetTimer();
            }
            else
            {
                TimeSpan diff = new TimeSpan(futureSpan.Ticks - now.Ticks);
                string txt = String.Format("Pikabu - Top Comments: Следующая проверка через {0}", diff.ToString(@"hh\:mm\:ss"));
                this.Text = txt;
                notifyIcon.Text = txt;
            }
        }

        private void forceRefreshMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Pikabu - Top Comments: Обновляем...";
            this.Enabled = false;
            mainTimer.Stop();
            resetTimer();
            backgroundWorker.RunWorkerAsync();
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            GUISettings guiSetting = new GUISettings(settings);
            guiSetting.ShowDialog(this);
            resetTimer();
            mainTimer.Start();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            DialogResult result = MessageBox.Show(this, "Сохранить настройки и комментарии?", "Выход.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Settings.saveSettings(settings);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, String.Format("Не удалось сохранить настройки:\n {0}", exc.Message), "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    getter.saveComments();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, String.Format("Не удалось сохранить комментарии:\n {0}", exc.Message), "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Environment.Exit(0);
        }

        private void GUIMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            PikabuComment lastComment = getter.getLastComment();
            if (lastComment != null)
                Process.Start(lastComment.PostLink);
        }

        private void showBallon(string msg, bool isError)
        {
            notifyIcon.BalloonTipIcon = isError ? ToolTipIcon.Error : ToolTipIcon.Info;
            notifyIcon.BalloonTipText = msg;
            notifyIcon.BalloonTipTitle = isError ? "Что-то пошло не так." : "Новый топовый комментарий!";
            notifyIcon.ShowBalloonTip(3000);
        }

        private void resetTimer()
        {
            previousTick = new TimeSpan(DateTime.Now.Ticks);
            futureSpan = new TimeSpan(DateTime.Now.AddMinutes(settings.IntervalMinutes).Ticks);
        }

        private void updateTable()
        {
            commentsDataGridView.ClearSelection();
            table.Rows.Clear();
            foreach(PikabuComment com in getter.comments)
            {
                string[] comInfo = new string[] { com.CommentLikes.ToString(), com.CommentAuthor, com.CommentText, com.PostName };
                table.Rows.Add(comInfo);
            }
        }

        private void commentsDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewSelectedCellCollection col = commentsDataGridView.SelectedCells;
            foreach(PikabuComment com in getter.comments)
            {
                if(com.PostName.Equals(col[3].Value) && com.CommentText.Equals(col[2].Value))
                {
                    Process.Start(com.PostLink);
                    break;
                }
            }
        }

        private void showMainWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}