using InputData.Common;
using InputData.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InputData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //点击查询按钮
        private void ButtonSearch_Click(object sender, System.EventArgs e)
        {
            string strNum = this.TextBoxNum.Text;
            if (strNum == "")
            {
                MessageBox.Show("请输入单号！");
            }
            GetDataTableFromSqlServer(strNum);
        }

        //根据单号查询数据库信息
        private void GetDataTableFromSqlServer(string strNum)
        {
            string strSql = string.Format("select a.ID,field0005,field0015,field0020,field0010,b.field0055,a.state from formmain_2524 a left join formson_2526 b on b.formmain_id = a.ID where field0002 = '{0}'", strNum);
            LoadResultToDataGridView(strSql);
        }

        //显示到DataGridView中
        private void LoadResultToDataGridView(string strSql, params SqlParameter[] parameters)
        {
            List<PaymentInfo> PaymentInfoList = new List<PaymentInfo>();
            DataTable dt = SQLHelper.ExecuteDataTable(strSql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                PaymentInfo PaymentInfo = new PaymentInfo();
                PaymentInfo.ID = long.Parse(row["ID"].ToString().Trim());
                PaymentInfo.EmployeeID = row["field0005"].ToString().Trim();
                PaymentInfo.ReceivingUnit = row["field0015"].ToString().Trim();
                PaymentInfo.Tax = row["field0020"].ToString().Trim();
                PaymentInfo.AmountMoney = row["field0010"].ToString().Trim();
                PaymentInfo.Subject = row["field0055"].ToString().Trim();
                PaymentInfo.State = row["state"].ToString().Trim();
                PaymentInfoList.Add(PaymentInfo);
            }

            this.DataGridViewPayment.DataSource = PaymentInfoList;
            this.DataGridViewPayment.Columns["ID"].HeaderText = "ID";
            this.DataGridViewPayment.Columns["ID"].Width = 130;
            this.DataGridViewPayment.Columns["EmployeeID"].HeaderText = "工号";
            this.DataGridViewPayment.Columns["EmployeeID"].Width = 70;
            this.DataGridViewPayment.Columns["ReceivingUnit"].HeaderText = "供应商";
            this.DataGridViewPayment.Columns["ReceivingUnit"].Width = 250;
            this.DataGridViewPayment.Columns["Tax"].HeaderText = "税额";
            this.DataGridViewPayment.Columns["Tax"].Width = 80;
            this.DataGridViewPayment.Columns["AmountMoney"].HeaderText = "金额";
            this.DataGridViewPayment.Columns["AmountMoney"].Width = 100;
            this.DataGridViewPayment.Columns["Subject"].HeaderText = "科目明细";
            this.DataGridViewPayment.Columns["Subject"].Width = 220;
            this.DataGridViewPayment.Columns["state"].HeaderText = "状态";
        }

        //点击选择文件按钮
        private void ButtonChosefile_Click(object sender, System.EventArgs e)
        {
            if (DataGridViewPayment.DataSource == null || DataGridViewPayment.RowCount == 0)     //未绑定数据源 或 绑定的数据源为空
            {
                MessageBox.Show("请先查询付款单号！");
                return;
            }
            if (DataGridViewPayment.Rows[0].Cells[6].Value.ToString() != "0")
            {
                MessageBox.Show("该单据未撤回，请先撤回再进行操作");
                return;
            }
            string formain_ID = DataGridViewPayment.Rows[0].Cells[0].Value.ToString();      //主表ID
            DataGridViewExcel.DataSource = null;            //每次打开清除内容
            var data = OpenExcel.GetData();
            if (data != null)
            {
                DataTable dtExcel = data.Tables[0];
                DataGridViewExcel.DataSource = dtExcel;
                string strSql = string.Format("delete formson_2526_load where 主表ID = '{0}'", formain_ID);
                int deleteCount = SQLHelper.ExecuteNoQuery(strSql);
                int addCount = InsertData(dtExcel);
                LabelRemarks.Text = "删除数据：" + deleteCount + "；添加数据：" + addCount;
            }
        }

        //点击更新按钮
        private void ButtonUpdate_Click(object sender, System.EventArgs e)
        {
            if (DataGridViewPayment.DataSource == null || DataGridViewPayment.RowCount == 0)     //未绑定数据源 或 绑定的数据源为空
            {
                MessageBox.Show("请先查询付款单号！");
                return;
            }
            if (DataGridViewPayment.Rows[0].Cells[6].Value.ToString() != "0")
            {
                MessageBox.Show("该单据未撤回，请先撤回再进行操作");
                return;
            }
            string formain_ID = DataGridViewPayment.Rows[0].Cells[0].Value.ToString();      //主表ID
            string strDeleteSql = string.Format("delete formson_2526 where formmain_id = '{0}'", formain_ID); ;     //先删除formson_2526表中主表ID数据
            int deleteCount = SQLHelper.ExecuteNoQuery(strDeleteSql);

            string strAddSql = string.Format("insert into formson_2526(ID,formmain_id,sort,field0053,field0054,field0055,field0056,field0057,field0058,field0059,field0060,field0061,field0062, field0063, field0064, field0065, field0066) select a.ID,a.主表ID as formmain_id,a.序号 as sort, a.序号 as field0053, c.ID as field0054, a.科目名称 as field0055,a.研发项目号 as field0056,a.内部项目号 as field0057, a.税额 as field0058, a.金额 as field0059, a.部门编号 as field0060, d.field0011 as field0061, d.field0003 as field0062, d.field0015 as field0063, b.MEMBER_ID as field0064,a.备注 as field0065, a.责任人工号 as field0066 from formson_2526_load as a left join ORG_PRINCIPAL as b on b.LOGIN_NAME = a.责任人工号 left join ORG_UNIT as c on a.部门编号 = c.CODE and c.IS_ENABLE = 1 left join formmain_0994 as d on d.field0010 = a.部门编号 and d.field0004 = a.科目名称 where a.主表ID = '{0}'", formain_ID);
            int addCount = SQLHelper.ExecuteNoQuery(strAddSql);     //将数据插入到formson_2526表中

            MessageBox.Show("已添加" + addCount + "条数据！");
        }


        //插入数据到formson_2526_load
        public int InsertData(DataTable dt)
        {
            int i = 0;
            string formain_ID = DataGridViewPayment.Rows[0].Cells[0].Value.ToString();      //主表ID
            string projectNum = "A0001";        //研发项目号
            string internalNum = "AI01080";     //内部项目号
            string subject = DataGridViewPayment.Rows[0].Cells[5].Value.ToString();         //科目名称
            using (SqlConnection conn = new SqlConnection(SQLHelper.GetConnectionString()))
            {
                conn.Open();
                string strSql = string.Format("Insert into formson_2526_load(ID,主表ID,序号,部门编号,责任人,责任人工号,部门,税额,金额,研发项目号,内部项目号,备注,科目名称,添加时间) values (@ID,@主表ID,@序号,@部门编号,@责任人,@责任人工号,@部门,@税额,@金额,@研发项目号,@内部项目号,@备注,@科目名称,@添加时间)");
                foreach (DataRow dr in dt.Rows)
                {
                    byte[] buffer = Guid.NewGuid().ToByteArray();
                    long ID = BitConverter.ToInt64(buffer, 0);
                    string num = dr["序号"].ToString().Trim();
                    string departmentNum = dr["部门编号"].ToString().Trim();
                    string person = dr["责任人"].ToString().Trim();
                    string jobnum = dr["责任人工号"].ToString().Trim();
                    string department = dr["部门"].ToString().Trim();
                    string tax = dr["税额"].ToString().Trim();
                    string amount = dr["金额"].ToString().Trim();
                    string remarks = dr["备注"].ToString().Trim();
                    using (SqlCommand cmd = new SqlCommand(strSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@主表ID", formain_ID);
                        cmd.Parameters.AddWithValue("@序号", num);
                        cmd.Parameters.AddWithValue("@部门编号", departmentNum);
                        cmd.Parameters.AddWithValue("@部门", department);
                        cmd.Parameters.AddWithValue("@责任人", person);
                        cmd.Parameters.AddWithValue("@责任人工号", jobnum);
                        cmd.Parameters.AddWithValue("@税额", tax);
                        cmd.Parameters.AddWithValue("@金额", amount);
                        cmd.Parameters.AddWithValue("@研发项目号", projectNum);
                        cmd.Parameters.AddWithValue("@内部项目号", internalNum);
                        cmd.Parameters.AddWithValue("@备注", remarks);
                        cmd.Parameters.AddWithValue("@科目名称", subject);
                        cmd.Parameters.AddWithValue("@添加时间", DateTime.Now);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            i++;
                        }
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            return i;
        }

    }
}
