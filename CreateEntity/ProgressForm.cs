using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateEntity
{
    public partial class ProgressForm : Form
    {
        private EntityFactory _factory;
        public ProgressForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _factory = new EntityFactory(Helper.dbType);
        }

        private async void ProgressForm_Load(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    _factory.Create(this);
                    Thread.Sleep(100);

                    Text = "生成完毕";
                    okBtn.Enabled = true;
                });
            }
            catch (OperationCanceledException)
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "实体生成器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_factory != null)
                _factory.Cancel();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProgressForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

       
    }
}
