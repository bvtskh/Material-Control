using Material_System.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_System
{
    public partial class FormMonitoringUpdateJob : Form
    {
        public FormMonitoringUpdateJob()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormMonitoringUpdateJob_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Tên Job", typeof(string));
            table.Columns.Add("Last Update", typeof(string));
            table.Columns.Add("Ý nghĩa", typeof(string));
            table.Rows.Add("LoadedOrderItemJob", MoritoringHelper.LoadedOrderItemJob(),"Load những WO từ ca trước");
            table.Rows.Add("VerifedOrderItemJob", MoritoringHelper.VerifedOrderItemJob(),"Số lượng Part đã verify đầu giờ");
            table.Rows.Add("TokusaiAlarmJob", MoritoringHelper.TokusaiAlarmJob(),"Trạng thái part có Tokusai hay không");
            table.Rows.Add("MainSubAlarmJob", MoritoringHelper.MainSubAlarmJob(),"Part có thay nối hay không");
            dataGridView1.DataSource = table;
        }
    }
}
