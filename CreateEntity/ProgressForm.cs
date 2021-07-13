using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CreateEntity
{
    public partial class ProgressForm : Form
    {
        private readonly MainForm _mf;
        private readonly BackgroundWorker _backgroundWorker1; //ProgressForm窗体事件(进度条窗体)
        public ProgressForm(MainForm mf,BackgroundWorker bgWork)
        {
            InitializeComponent();
            _mf = mf;
            _backgroundWorker1 = bgWork;
            //绑定进度条改变事件
            _backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            //绑定后台操作完成，取消，异常时的事件
            _backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if(DialogResult.OK== MessageBox.Show(e.Error.Message, "实体生成器", MessageBoxButtons.OK, MessageBoxIcon.Error))
                {
                    Close();
                }
            }
            else
            {
                Text = "生成完毕";
                okBtn.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProgressForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _backgroundWorker1.CancelAsync(); //请求取消挂起的后台操作
            if (_mf != null)
            {
                _mf.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
    }
}
