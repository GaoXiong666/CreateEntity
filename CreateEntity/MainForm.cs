using System;
using System.ComponentModel;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateEntity
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetNames(typeof(DataBaseType));
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //开始按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Helper.nameSpace = NameSpace.Text.Trim();
            Helper.path = txtPath.Text.Trim();
            Helper.conStr = ConStr.Text.Trim();

            if (string.IsNullOrEmpty(Helper.nameSpace))
            {
                MessageBox.Show("请填写命名空间", "实体生成器", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(Helper.path))
            {
                MessageBox.Show("请填写连接字符串", "实体生成器", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(Helper.conStr))
            {
                MessageBox.Show("请选择生成路径", "实体生成器", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!testCon())
            {
                return;
            }

            //隐藏自己
            Hide();
            ProgressForm pgForm = new ProgressForm();
            pgForm.ShowDialog();
            Visible = true;
        }


        //选择路径
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            txtPath.Text = path.SelectedPath;
        }

        /// <summary>
        /// 测试连接是否成功
        /// </summary>
        /// <returns>true为成功，false为失败</returns>
        private bool testCon()
        {
            bool ok = true;
            try
            {
                DbConnection conn = Helper.GetDbConnection();
                conn.Open();
                conn.Close();
            }
            catch (Exception e)
            {
                ok = false;
                MessageBox.Show("连接超时，" + e.Message, "实体生成器", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ok;
        }

        private void testConBtn_Click(object sender, EventArgs e)
        {
            Helper.conStr = ConStr.Text.Trim();
            if (testCon())
            {
                MessageBox.Show("测试连接成功", "实体生成器", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Helper.dbType = (DataBaseType)(Enum.Parse(typeof(DataBaseType), comboBox1.Text, true));
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        private void checkReplace_CheckedChanged(object sender, EventArgs e)
        {
            Helper.IsReplace = checkReplace.Checked;
        }
    }
}