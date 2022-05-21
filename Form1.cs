using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
//using System.Windows.Forms.dll;

namespace H_R
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=" + Properties.Settings.Default.Server_Name + "; Initial Catalog=" + Properties.Settings.Default.DataBaseName + "; User ID=" + Properties.Settings.Default.UserName + "; PASSWORD=" + Properties.Settings.Default.Password + "; ");
        Classes.holiday holiday = new Classes.holiday();
        Classes.branches branch = new Classes.branches();
        Classes.DGV_Mangment class_dgvMangment = new Classes.DGV_Mangment();
        Classes.Reward reward = new Classes.Reward();
        Classes.Salary salary_class = new Classes.Salary();
        Classes.Discount discount = new Classes.Discount();
        Classes.absence abse = new Classes.absence();
        //decimal txtsalary;
        //decimal txtDiscount;
        //decimal txtReward;

        public Form1()
        {
            InitializeComponent();
        }

        private void tab_all_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_new_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void txt_place_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void save_emp_Click(object sender, EventArgs e)
        {
            if (id_txt.Text.Trim() == "") { Save(); Clear(); }
            else
            {
                Edit();
                Clear();
            }
            fill_Dgv_Emp();
        }

        public void Save()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = "INSERT INTO Employee_HR (code, name_Emp, department, emp_job, situation, insurance, office, coast, birthdate,national_id, txt_salary, date_job, insurance_job, insurance_situation, healthy_card, study, title, txt_branch, phone,todate, Weakly_holiday_Day) VALUES (@code, @name_Emp, @department, @emp_job, @situation, @insurance, @office,@coast, @birthdate,@national_id, @txt_salary, @date_job, @insurance_job, @insurance_situation, @healthy_card, @study,@title, @txt_branch, @phone,@todate, @Weakly_holiday_Day)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@code ", code_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@name_Emp ", name_Emp_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@department ", department_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@emp_job ", emp_job_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@situation ", situation_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@insurance ", insurance_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@office ", office_txt.Text.Trim());
                decimal deccoast = Convert.ToDecimal(coast_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@coast", deccoast);
                cmd.Parameters.AddWithValue("@birthdate", birthdate_txt.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@national_id", national_id_txt.Text.Trim());
                decimal decsalary = Convert.ToDecimal(txt_salary_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@txt_salary", decsalary);
                cmd.Parameters.AddWithValue("@date_job ", date_job_txt.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@insurance_job ", insurancejob_txt.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@insurance_situation ", insurance_situation_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@healthy_card ", healthy_card_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@study ", study_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@title ", title_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@txt_branch ", txt_branch_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@phone ", phone_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@todate ", to_date_txt.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Weakly_holiday_Day ", Weakly_holiday_Day.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الحفظ بنجاح", "رسالة الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }

        public void Edit()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = "UPDATE Employee_HR SET code =@code, name_Emp =@name_Emp,department =@department, emp_job =@emp_job," +
                    " situation =@situation, insurance =@insurance,office =@office, coast =@coast, birthdate =@birthdate," +
                    " national_id =@national_id, txt_salary =@txt_salary, date_job =@date_job,insurance_job =@insurance_job," +
                    " insurance_situation =@insurance_situation,healthy_card =@healthy_card, study =@study, title =@title," +
                    "txt_branch =@txt_branch,phone =@phone, todate =@todate,Weakly_holiday_Day =@Weakly_holiday_Day where id=N'" + id_txt.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@code", code_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@name_Emp", name_Emp_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@department", department_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@emp_job", emp_job_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@situation", situation_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@insurance", insurance_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@office", office_txt.Text.Trim());
                if (coast_txt.Text.Trim() == "") { coast_txt.Text = "0"; }
                decimal deccoast = Convert.ToDecimal(coast_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@coast", deccoast);
                cmd.Parameters.AddWithValue("@birthdate", birthdate_txt.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@national_id", national_id_txt.Text.Trim());
                if (txt_salary_txt.Text.Trim() == "") { txt_salary_txt.Text = "0"; }
                decimal decsalary = Convert.ToDecimal(txt_salary_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@txt_salary", decsalary);
                cmd.Parameters.AddWithValue("@date_job", date_job_txt.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@insurance_job", insurancejob_txt.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@insurance_situation", insurance_situation_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@healthy_card", healthy_card_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@study", study_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@title", title_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@txt_branch", txt_branch_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", phone_txt.Text.Trim());
                cmd.Parameters.AddWithValue("@todate", to_date_txt.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Weakly_holiday_Day ", Weakly_holiday_Day.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم التعديل بنجاح", "رسالة الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }

        public void fill_Dgv_Emp()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = "Select * from Employee_HR";                    //where department=N'"+ cbo.Text.Trim()+ "'
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_Emp.DataSource = dt;
            }
            catch { }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                CountDGVRows(txt_total_emp, dgv_Emp);
            }
        }

        public void select_name_Emp()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = "Select * from Employee_HR where name_Emp = N'" + txt_search_name_emp.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id_txt.Text = dr["id"].ToString();
                    code_txt.Text = dr["code"].ToString();
                    name_Emp_txt.Text = dr["name_Emp"].ToString();
                    department_txt.Text = dr["department"].ToString();
                    emp_job_txt.Text = dr["emp_job"].ToString();
                    situation_txt.Text = dr["situation"].ToString();
                    insurance_txt.Text = dr["insurance"].ToString();
                    office_txt.Text = dr["office"].ToString();
                    coast_txt.Text = dr["coast"].ToString();
                    birthdate_txt.Text = dr["birthdate"].ToString();
                    national_id_txt.Text = dr["national_id"].ToString();
                    txt_salary_txt.Text = dr["txt_salary"].ToString();
                    date_job_txt.Text = dr["date_job"].ToString();
                    insurancejob_txt.Text = dr["insurance_job"].ToString();
                    insurance_situation_txt.Text = dr["insurance_situation"].ToString();
                    healthy_card_txt.Text = dr["healthy_card"].ToString();
                    study_txt.Text = dr["study"].ToString();
                    title_txt.Text = dr["title"].ToString();
                    txt_branch_txt.Text = dr["txt_branch"].ToString();
                    phone_txt.Text = dr["phone"].ToString();
                    to_date_txt.Text = dr["todate"].ToString();
                    //Day_coast.Text = dr["Day_coast"].ToString();
                    //Day_Half_Coast.Text = dr["Day_Half_Coast"].ToString();
                    //Day_Quarter_Coast.Text = dr["Day_Quarter_Coast"].ToString();
                    Weakly_holiday_Day.Text = dr["Weakly_holiday_Day"].ToString();
                }
                dr.Close();
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
            //con.Close();
        }
        public void select_code()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = "Select * from Employee_HR where code = N'" + txt_search_name_emp.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id_txt.Text = dr["id"].ToString();
                    code_txt.Text = dr["code"].ToString();
                    name_Emp_txt.Text = dr["name_Emp"].ToString();
                    department_txt.Text = dr["department"].ToString();
                    emp_job_txt.Text = dr["emp_job"].ToString();
                    situation_txt.Text = dr["situation"].ToString();
                    insurance_txt.Text = dr["insurance"].ToString();
                    office_txt.Text = dr["office"].ToString();
                    coast_txt.Text = dr["coast"].ToString();
                    birthdate_txt.Text = dr["birthdate"].ToString();
                    national_id_txt.Text = dr["national_id"].ToString();
                    txt_salary_txt.Text = dr["txt_salary"].ToString();
                    date_job_txt.Text = dr["date_job"].ToString();
                    insurancejob_txt.Text = dr["insurance_job"].ToString();
                    insurance_situation_txt.Text = dr["insurance_situation"].ToString();
                    healthy_card_txt.Text = dr["healthy_card"].ToString();
                    study_txt.Text = dr["study"].ToString();
                    title_txt.Text = dr["title"].ToString();
                    txt_branch_txt.Text = dr["txt_branch"].ToString();
                    phone_txt.Text = dr["phone"].ToString();
                    to_date_txt.Text = dr["todate"].ToString();
                    //Day_coast.Text = dr["Day_coast"].ToString();
                    //Day_Half_Coast.Text = dr["Day_Half_Coast"].ToString();
                    //Day_Quarter_Coast.Text = dr["Day_Quarter_Coast"].ToString();
                    Weakly_holiday_Day.Text = dr["Weakly_holiday_Day"].ToString();
                }
                dr.Close();
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
            //con.Close();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (cbo_select_code_name.Text.Trim() == "بحث بالأسم") { Clear(); select_name_Emp(); }
            else
            if (cbo_select_code_name.Text.Trim() == "بحث بالكود") { Clear(); select_code(); }
        }

        public void Clear()
        {
            id_txt.Text = " ";
            code_txt.Text = " ";
            name_Emp_txt.Text = " ";
            department_txt.Text = " ";
            emp_job_txt.Text = " ";
            situation_txt.Text = " ";
            insurance_txt.Text = " ";
            office_txt.Text = " ";
            coast_txt.Text = " ";
            birthdate_txt.Value = DateTime.Now;
            national_id_txt.Text = " ";
            txt_salary_txt.Text = " ";
            date_job_txt.Value = DateTime.Now;
            insurancejob_txt.Value = DateTime.Now;
            insurance_situation_txt.Text = " ";
            healthy_card_txt.Text = " ";
            study_txt.Text = " ";
            title_txt.Text = " ";
            txt_branch_txt.Text = " ";
            phone_txt.Text = " ";
            to_date_txt.Value = DateTime.Now;
            //txt_search_name_emp.Text = " ";
            //Day_coast.Text = "";
            //Day_Half_Coast.Text = "";
            //Day_Quarter_Coast.Text = "";
            Weakly_holiday_Day.Text = "";
        }

        public void Delete_Emp()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = " Delete from Employee_HR where id = N'" + id_txt.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } Clear(); }
        }

        private void delete_emp_Click(object sender, EventArgs e)
        {
            Delete_Emp(); Clear(); fill_Dgv_Emp();
        }

        private void new_emp_Click(object sender, EventArgs e)
        {
            Clear(); fill_Dgv_Emp();
        }
        // نهاية شاشة الموظف

        public void Select_sections_name(TextBox txt_seach)
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                string query = "Select Department From Employee_HR Group By Department";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    col.Add(dr[0].ToString());
                }
                txt_seach.AutoCompleteCustomSource = col;
                dr.Close();
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }

        public void Select_sections_name(ComboBox txt_seach)
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                string query = "Select Department From Employee_HR Group By Department";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    col.Add(dr[0].ToString());
                }
                txt_seach.AutoCompleteCustomSource = col;
                dr.Close();
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Fill_name_Emp(txt_search_name_emp);
                Fill_name_Emp(txt_search);
                select_jobs();
                fill_DGV_Sections();
                fill_Dgv_Emp();
                //class_dgvMangment.fill_Dgv_Mangment(dgv_mangment);
                holiday.fill_Dgv_holiday(dgv_holiday);
                holiday.Fill_h_Code(h_Code);
                //salary_class.fill_Salary(search_salary);
                //salary_class.fill_DGV_Salary(DGV_Salary);
                reward.Fill_dgv_reward(dgv_reward);
                discount.Fill_DGV_Discount(Dgv_Discount);
                txt_ServerName.Text = Properties.Settings.Default.Server_Name;
                txt_DataBaseName.Text = Properties.Settings.Default.DataBaseName;
                txt_UserName.Text = Properties.Settings.Default.UserName;
                txt_Paswword.Text = Properties.Settings.Default.Password;

                Select_sections_name(txt_search_Qawmia);
                Select_sections_name(txt_search_Express);
                Select_sections_name(txt_search_Baroon);
                Select_sections_name(txt_search_Store);
                Select_sections_name(txt_search_Dyarb);

                Select_sections_name(cbo_Qawmia);
                Select_sections_name(cbo_Express);
                Select_sections_name(cbo_Baroon);
                Select_sections_name(cbo_Store);
                Select_sections_name(cbo_Diarb);
            }
            catch { }
            this.reportViewer1.RefreshReport();
        }

        public void Fill_name_Emp(TextBox txt_search_name_emp)
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                string query = "Select name_Emp from Employee_HR";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    col.Add(dr[0].ToString());
                }
                txt_search_name_emp.AutoCompleteCustomSource = col;
                dr.Close();
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }

        public void Fill_Code_Emp(TextBox txt_search_name_emp)
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                string query = "Select code from Employee_HR";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    col.Add(dr[0].ToString());
                }
                txt_search_name_emp.AutoCompleteCustomSource = col;
                dr.Close();
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }

        private void btn_job_save_Click(object sender, EventArgs e)
        {
            if (id_jobs.Text.Trim() == "") { Save_jobs(); }
            else { Edit_jobs(); }
            Clear_jobs();
            select_jobs();
        }

        public void Save_jobs()
        {
            try
            {
                string details_1 = "";
                string details_2 = "";
                string details_3 = "";
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = "INSERT INTO Jobs(job_name, branch_name, mangment, nature_job, job_salary, job_age, details_1, details_2, details_3) VALUES (@job_name, @branch_name, @mangment, @nature_job, @job_salary, @job_age, @details_1, @details_2, @details_3)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@job_name ", job_name.Text.Trim());
                cmd.Parameters.AddWithValue("@branch_name ", branch_name.Text.Trim());
                cmd.Parameters.AddWithValue("@mangment ", mangment.Text.Trim());
                cmd.Parameters.AddWithValue("@nature_job ", nature_job.Text.Trim());
                decimal decjob_salary = Convert.ToDecimal(job_salary.Text.Trim());
                cmd.Parameters.AddWithValue("@job_salary ", decjob_salary);
                cmd.Parameters.AddWithValue("@job_age ", job_age.Text.Trim());
                cmd.Parameters.AddWithValue("@details_1 ", details_1);
                cmd.Parameters.AddWithValue("@details_2 ", details_2);
                cmd.Parameters.AddWithValue("@details_3 ", details_3);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الحفظ بنجاح", "رسالة الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } Clear_jobs(); }
        }

        public void Edit_jobs()
        {
            try
            {
                string detail_1 = "";
                string detail_2 = "";
                string detail_3 = "";
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = "UPDATE  jobs SET  job_name =@job_name,branch_name=@branch_name,mangment=@mangment,nature_job=@nature_job,job_salary=@job_salary,job_age=@job_age ,details_1 =@details_1,details_2 =@details_2, details_3 =@details_3 where id= N'" + id_jobs.Text.Trim() + "' ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@job_name", job_name.Text.Trim());
                cmd.Parameters.AddWithValue("@branch_name", branch_name.Text.Trim());
                cmd.Parameters.AddWithValue("@mangment", mangment.Text.Trim());
                cmd.Parameters.AddWithValue("@nature_job", nature_job.Text.Trim());
                decimal decjob_salary = Convert.ToDecimal(job_salary.Text.Trim());
                cmd.Parameters.AddWithValue("@job_salary ", decjob_salary);
                cmd.Parameters.AddWithValue("@job_age", job_age.Text.Trim());
                cmd.Parameters.AddWithValue("@details_1", detail_1);
                cmd.Parameters.AddWithValue("@details_2", detail_2);
                cmd.Parameters.AddWithValue("@details_3", detail_3);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم التعديل بنجاح", "رسالة الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                Clear_jobs();
            }
        }

        public void Delete_jobs()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = "Delete from jobs where id = N'" + id_jobs.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الحذف بنجاح", "رسالة تأكيد الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } Clear_jobs(); }
        }

        private void btn_job_new_Click(object sender, EventArgs e)
        {
            Clear_jobs(); select_jobs();
        }

        public void Clear_jobs()
        {
            id_jobs.Text = "";
            job_name.Text = "";
            branch_name.Text = "";
            mangment.Text = "";
            nature_job.Text = "";
            job_salary.Text = "";
            job_age.Text = "";
        }

        public void Fill_jobs()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                string query = "Select job_name from jobs";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    col.Add(dr[0].ToString());
                }
                txt_search_jobs.AutoCompleteCustomSource = col;
                dr.Close();
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }

        public void select_jobs()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = "Select id,job_name,branch_name,mangment,nature_job,job_salary,job_age From Jobs";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_jobs.DataSource = dt;
                //dgv_jobs.Columns[1].HeaderText = "الوظيفة";
                //dgv_jobs.Columns[2].HeaderText = "الفرع";
                //dgv_jobs.Columns[3].HeaderText = "الإدارة";
                //dgv_jobs.Columns[4].HeaderText = "طبيعة الوظيفة";
                //dgv_jobs.Columns[5].HeaderText = "الراتب";
                //dgv_jobs.Columns[6].HeaderText = "السن المطلوب";
                //dgv_jobs.Columns[7].HeaderText = "الرقم الآلي";

                //dgv_jobs.Columns[7].Visible = false;
                //dgv_jobs.Columns[8].Visible = false;
                //dgv_jobs.Columns[9].Visible = false;
                //dgv_jobs.Columns[10].Visible = false;
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }

        private void btn_job_delete_Click(object sender, EventArgs e)
        {
            Delete_jobs();
            Clear_jobs();
            select_jobs();
        }

        private void dgv_jobs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgv_jobs.Rows[e.RowIndex].Selected = true;
                job_name.Text = dgv_jobs.SelectedRows[0].Cells["job"].Value.ToString();
                branch_name.Text = dgv_jobs.SelectedRows[0].Cells["branch1"].Value.ToString(); //"branch1"
                mangment.Text = dgv_jobs.SelectedRows[0].Cells["manged"].Value.ToString();
                nature_job.Text = dgv_jobs.SelectedRows[0].Cells["job_description"].Value.ToString();
                job_salary.Text = dgv_jobs.SelectedRows[0].Cells["salary"].Value.ToString();
                job_age.Text = dgv_jobs.SelectedRows[0].Cells["age"].Value.ToString();
                id_jobs.Text = dgv_jobs.SelectedRows[0].Cells["Id_auto"].Value.ToString();
            }
            catch { throw; }
        }

        private void btn_delete_sections_Click(object sender, EventArgs e)
        {
            try
            {

                if (id_sectionss.Text.Trim() != "")
                {

                    if (con.State == ConnectionState.Open) { con.Close(); }
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete  from Sections where id_sections=N'" + id_sectionss.Text.Trim() + "' ", con);
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open) { con.Close(); }
                }
                else { MessageBox.Show("يرجى اختيار القسم المراد حذفه"); }
            }
            catch
            {

            }
            finally
            {
                Clear_Sections();
                fill_DGV_Sections();
            }
        }

        public void Clear_Sections()
        {
            id_sectionss.Text = "";
            section_name.Text = "";
            section_details.Text = "";
        }

        private void btn_new_sections_Click(object sender, EventArgs e)
        {
            Clear_Sections();
        }

        public void save_sections()
        {
            try
            {


                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into sections(sections_name,sections_details) Values (@sections_name,@sections_details)", con);
                cmd.Parameters.AddWithValue("@sections_name ", section_name.Text.Trim());
                cmd.Parameters.AddWithValue("@sections_details ", section_details.Text.Trim());
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {

            }
        }

        public void Edite_sections()
        {
            try
            {

                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                SqlCommand cmd = new SqlCommand("update sections set sections_name=@sections_name,sections_details=@sections_details where id_sections=N'" + id_sectionss.Text.Trim() + "' ", con);
                cmd.Parameters.AddWithValue("@sections_name", section_name.Text.Trim());
                cmd.Parameters.AddWithValue("@sections_details", section_details.Text.Trim());
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {

            }
        }

        private void btn_save_sections_Click(object sender, EventArgs e)
        {
            if (id_sectionss.Text.Trim() == "") { save_sections(); }
            else
            if (id_sectionss.Text.Trim() != "") { Edite_sections(); }
            fill_DGV_Sections();
            Clear_Sections();
        }

        public void fill_DGV_Sections()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Sections", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DGV_Sections.DataSource = dt;
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {
            }
        }

        private void DGV_Sections_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DGV_Sections.Rows[e.RowIndex].Selected = true;
                id_sectionss.Text = DGV_Sections.SelectedRows[0].Cells[0].Value.ToString();
                section_name.Text = DGV_Sections.SelectedRows[0].Cells[1].Value.ToString();
                section_details.Text = DGV_Sections.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch { }
        }

        /// <summary>
        ///                                 /فورم الادارة            
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        //private void btn_new_admin_Click(object sender, EventArgs e)
        //{
        //    clear_admin();
        //}

        //public void clear_admin()
        //{
        //    id_mangment.Text = "";
        //    MANGMENT_NAME.Text = "";
        //    MANGMENT_TASK.Text = "";
        //}

        //private void btn_delete_admin_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (con.State == ConnectionState.Open) { con.Close(); }
        //        con.Open();
        //        string query = "Delete from MANGMENT Where ID_MANGMENT = N'" + id_mangment.Text.Trim() + "' ";
        //        SqlCommand cmd = new SqlCommand(query , con);
        //        cmd.ExecuteNonQuery();
        //        MessageBox.Show("تم الحذف بنجاح", "رسالة تأكيد الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch { }
        //    finally 
        //    { 
        //        if (con.State == ConnectionState.Open) { con.Close(); } 
        //        clear_admin();
        //        class_dgvMangment.fill_Dgv_Mangment(dgv_mangment); 
        //    }
        //}

        //private void btn_save_Admin_Click(object sender, EventArgs e)
        //{
        //    if (id_mangment.Text.Trim() == "") { class_dgvMangment.save_Mangment(MANGMENT_NAME,MANGMENT_TASK); }
        //    else
        //    if (id_mangment.Text.Trim() != "") { class_dgvMangment.Edite_Mangment(MANGMENT_NAME,MANGMENT_TASK,id_mangment); }
        //    class_dgvMangment.fill_Dgv_Mangment(dgv_mangment);
        //}

        //private void dgv_mangment_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    dgv_mangment.Rows[e.RowIndex].Selected = true;
        //    //class_dgvMangment.DGV_Cell_click();
        //    Classes.DGV_Mangment.DGV_Cell_click(id_mangment, MANGMENT_NAME, MANGMENT_TASK, dgv_mangment);
        //}

        private void dgv_Emp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DGV_Sections.Rows[e.RowIndex].Selected = true;
                id_txt.Text = dgv_Emp.SelectedRows[0].Cells["id"].Value.ToString();
                code_txt.Text = dgv_Emp.SelectedRows[0].Cells["code1"].Value.ToString();
                name_Emp_txt.Text = dgv_Emp.SelectedRows[0].Cells["name_Emp1"].Value.ToString();
                department_txt.Text = dgv_Emp.SelectedRows[0].Cells["department1"].Value.ToString();
                emp_job_txt.Text = dgv_Emp.SelectedRows[0].Cells["emp_job1"].Value.ToString();
                situation_txt.Text = dgv_Emp.SelectedRows[0].Cells["situation1"].Value.ToString();
                insurance_txt.Text = dgv_Emp.SelectedRows[0].Cells["insurance1"].Value.ToString();
                office_txt.Text = dgv_Emp.SelectedRows[0].Cells["office1"].Value.ToString();
                coast_txt.Text = dgv_Emp.SelectedRows[0].Cells["coast"].Value.ToString();
                birthdate_txt.Text = dgv_Emp.SelectedRows[0].Cells["birthdate1"].Value.ToString();
                national_id_txt.Text = dgv_Emp.SelectedRows[0].Cells["national_id1"].Value.ToString();
                txt_salary_txt.Text = dgv_Emp.SelectedRows[0].Cells["txt_salary1"].Value.ToString();
                date_job_txt.Text = dgv_Emp.SelectedRows[0].Cells["date_job1"].Value.ToString();
                insurancejob_txt.Text = dgv_Emp.SelectedRows[0].Cells["insurance_job1"].Value.ToString();
                insurance_situation_txt.Text = dgv_Emp.SelectedRows[0].Cells["insurance_situation1"].Value.ToString();
                healthy_card_txt.Text = dgv_Emp.SelectedRows[0].Cells["healthy_card1"].Value.ToString();
                study_txt.Text = dgv_Emp.SelectedRows[0].Cells["study1"].Value.ToString();
                title_txt.Text = dgv_Emp.SelectedRows[0].Cells["title1"].Value.ToString();
                txt_branch_txt.Text = dgv_Emp.SelectedRows[0].Cells["txt_branch1"].Value.ToString();
                phone_txt.Text = dgv_Emp.SelectedRows[0].Cells["phone1"].Value.ToString();
                to_date_txt.Text = dgv_Emp.SelectedRows[0].Cells["todate1"].Value.ToString();
                Weakly_holiday_Day.Text = dgv_Emp.SelectedRows[0].Cells["Weakly_holiday_Day2"].Value.ToString();
            }
            catch
            {
            }
        }

        /// <summary>
        ///                                     //فورم الموظفين     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void btn_save_hr_Click(object sender, EventArgs e)
        {
            if (txt_id_holiday.Text.Trim() == "") { holiday.Save(h_Code, h_name, h_department, h_count_year, h_month, h_dt, h_year, public_holiday, absence, Patients, rest_allowance, Remaining_annual_balance, official_holidays, h_absence2, Patients2, rest_allowance2, h_total, Annual_balance_consumed, h_Code); }
            else
            if (txt_id_holiday.Text.Trim() != "") { holiday.Update(h_Code, h_name, h_department, h_count_year, h_month, h_dt, h_year, public_holiday, absence, Patients, rest_allowance, Remaining_annual_balance, official_holidays, h_absence2, Patients2, rest_allowance2, h_total, Annual_balance_consumed, Emp_id, txt_id_holiday); }
            //holiday.ClearDGV(dgv_holiday);
            holiday.fill_Dgv_holiday(dgv_holiday);
        }

        private void btn_new_holiday_Click(object sender, EventArgs e)
        {
            holiday.clear(h_Code, h_name, h_department, h_count_year, h_month, h_dt, h_year, Remaining_annual_balance, public_holiday, absence, Patients, rest_allowance, official_holidays, h_absence2, Patients2, rest_allowance2, h_total, Annual_balance_consumed, Emp_id);
            holiday.fill_Dgv_holiday(dgv_holiday);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            holiday.Delete(txt_id_holiday);
            holiday.clear(h_Code, h_name, h_department, h_count_year, h_month, h_dt, h_year, Remaining_annual_balance, public_holiday, absence, Patients, rest_allowance, official_holidays, h_absence2, Patients2, rest_allowance2, h_total, Annual_balance_consumed, Emp_id);
            holiday.fill_Dgv_holiday(dgv_holiday);
            MessageBox.Show("تم الحذف بنجاح", "رسالة الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// / فورم الاجازات
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void save_reward_Click(object sender, EventArgs e)
        {
            if (id_reward.Text.Trim() == "") { reward.Save_Reward(reward_amount, Emp_Code_, Reward_Provider_Name, bounty_owner, reward_date, reward_reason, date_time_now); }
            else
                if (id_reward.Text.Trim() != "") { reward.Edit_Reward(reward_amount, Emp_Code_, Reward_Provider_Name, bounty_owner, reward_date, reward_reason, date_time_now, id_reward); }
            reward.Fill_dgv_reward(dgv_reward);
            MessageBox.Show("تم الحفظ بنجاح", "رسالة الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void new_reward_Click(object sender, EventArgs e)
        {
            reward.clear_reward_reward(id_reward, reward_amount, Reward_Provider_Name, bounty_owner, reward_date, reward_reason, date_time_now);
            reward.Fill_dgv_reward(dgv_reward);
        }

        private void delete_reward_Click(object sender, EventArgs e)
        {
            reward.Delete_Reward(id_reward);
            reward.clear_reward_reward(id_reward, reward_amount, Reward_Provider_Name, bounty_owner, reward_date, reward_reason, date_time_now);
            reward.Fill_dgv_reward(dgv_reward);
        }

        private void dgv_holiday_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgv_holiday.Rows[e.RowIndex].Selected = true;
                txt_id_holiday.Text = dgv_holiday.SelectedRows[0].Cells["h_Code1"].Value.ToString();
                h_Code.Text = dgv_holiday.SelectedRows[0].Cells["h_Code1"].Value.ToString();
                h_name.Text = dgv_holiday.SelectedRows[0].Cells["h_name1"].Value.ToString();
                h_department.Text = dgv_holiday.SelectedRows[0].Cells["h_department1"].Value.ToString();
                h_count_year.Text = dgv_holiday.SelectedRows[0].Cells["h_count_year1"].Value.ToString();
                h_month.Text = dgv_holiday.SelectedRows[0].Cells["h_month1"].Value.ToString();
                h_dt.Text = dgv_holiday.SelectedRows[0].Cells["h_dt1"].Value.ToString();
                h_year.Text = dgv_holiday.SelectedRows[0].Cells["h_year1"].Value.ToString();
                public_holiday.Text = dgv_holiday.SelectedRows[0].Cells["public_holiday1"].Value.ToString();
                absence.Text = dgv_holiday.SelectedRows[0].Cells["absence1"].Value.ToString();
                Patients.Text = dgv_holiday.SelectedRows[0].Cells["Patients1"].Value.ToString();
                rest_allowance.Text = dgv_holiday.SelectedRows[0].Cells["rest_allowance1"].Value.ToString();
                Remaining_annual_balance.Text = dgv_holiday.SelectedRows[0].Cells["Remaining_annual_balance1"].Value.ToString();
                official_holidays.Text = dgv_holiday.SelectedRows[0].Cells["official_holidays_1"].Value.ToString();
                h_absence2.Text = dgv_holiday.SelectedRows[0].Cells["h_absence22"].Value.ToString();
                Patients2.Text = dgv_holiday.SelectedRows[0].Cells["Patients22"].Value.ToString();
                rest_allowance2.Text = dgv_holiday.SelectedRows[0].Cells["rest_allowance22"].Value.ToString();
                h_total.Text = dgv_holiday.SelectedRows[0].Cells["h_total2"].Value.ToString();
                Annual_balance_consumed.Text = dgv_holiday.SelectedRows[0].Cells["Annual_balance_consumed2"].Value.ToString();
                Emp_id.Text = dgv_holiday.SelectedRows[0].Cells["id_Emp2"].Value.ToString();
            }
            catch
            {

            }
        }

        /// <summary>
        /// / فورم المرتبات
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void btn_save_salary_Click(object sender, EventArgs e)
        {
            //if (id_salary.Text.Trim() == "") { salary_class.Save_salary(Emp_code, Emp_name_Salary, main_salary, total_discount, total_bonus, total_absence, total_vacations, total_salary); }
            //else
            //if (id_salary.Text.Trim() != "") { salary_class.Edit_salary(Emp_code, Emp_name_Salary, main_salary, total_discount, total_bonus, total_absence, total_vacations, total_salary); }
            //salary_class.fill_DGV_Salary(DGV_Salary);
        }

        private void btn_new_salary_Click(object sender, EventArgs e)
        {
            //salary_class.New_salary(Emp_code, main_salary, total_discount, total_bonus, total_absence, Emp_name_Salary, total_vacations, total_salary);  //Emp_name_Salary
            //salary_class.fill_DGV_Salary(DGV_Salary);
        }

        private void btn_delete_salary_Click(object sender, EventArgs e)
        {
            //salary_class.Delete_salary(Emp_code);
            //salary_class.New_salary(Emp_code, main_salary, total_discount, total_bonus, Emp_name_Salary, total_absence, total_vacations, total_salary);
            //salary_class.fill_DGV_Salary(DGV_Salary);
        }

        private void btn_salary_Refresh_Click(object sender, EventArgs e)
        {
            //search_salary.Clear();
            //salary_class.fill_Salary(search_salary);
            //salary_class.New_salary(Emp_code, main_salary, total_discount, total_bonus, Emp_name_Salary, total_absence, total_vacations, total_salary);
        }

        private void search_salary_TextChanged(object sender, EventArgs e)
        {
            //if (search_salary.Text.Trim() == "")
            //{
            //    salary_class.New_salary(Emp_code, main_salary, total_discount, total_bonus, Emp_name_Salary, total_absence, total_vacations, total_salary);
            //}
            //else
            //{
            //    decimal salary = 0;
            //    decimal reward = 0;
            //    decimal discount = 0;
            //    salary_class.fill_Salary_changed(Emp_code, Emp_name_Salary, main_salary, search_salary);
            //    salary_class.Count_Discount(search_salary, total_discount, dt1, dt2);
            //    salary_class.Count_Reward(Emp_code, dt1, dt2, total_bonus);
            //    if (main_salary.Text.Trim() == "")
            //    {
            //        main_salary.Text = "0";
            //    }
            //    if (total_bonus.Text.Trim() == "")
            //    {
            //        total_bonus.Text = "0";
            //    }
            //    if (total_discount.Text.Trim() == "")
            //    {
            //        total_discount.Text = "0";
            //    }
            //    salary = Convert.ToDecimal(main_salary.Text.Trim());
            //    reward = Convert.ToDecimal(total_bonus.Text.Trim());
            //    discount = Convert.ToDecimal(total_discount.Text.Trim());
            //    decimal total = salary + reward - discount;
            //    total_salary.Text = total.ToString();
            //}
        }

        private void DGV_Salary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    id_salary.Text = DGV_Salary.SelectedRows[0].Cells[0].Value.ToString();
            //    Emp_code.Text = DGV_Salary.SelectedRows[0].Cells["Emp_code1"].Value.ToString();
            //    main_salary.Text = DGV_Salary.SelectedRows[0].Cells["main_salary1"].Value.ToString();
            //    total_discount.Text = DGV_Salary.SelectedRows[0].Cells["total_discount1"].Value.ToString();
            //    total_bonus.Text = DGV_Salary.SelectedRows[0].Cells["total_bonus1"].Value.ToString();
            //    total_absence.Text = DGV_Salary.SelectedRows[0].Cells["total_absence1"].Value.ToString();
            //    total_vacations.Text = DGV_Salary.SelectedRows[0].Cells["total_vacations1"].Value.ToString();
            //    total_salary.Text = DGV_Salary.SelectedRows[0].Cells["total_salary1"].Value.ToString();
            //}
            //catch
            //{
            //}
        }

        private void dgv_reward_CellClick(object sender, DataGridViewCellEventArgs e)  ///يحتاج تعديل 
        {
            try
            {
                id_reward.Text = dgv_reward.SelectedRows[0].Cells[0].Value.ToString();
                reward_amount.Text = dgv_reward.SelectedRows[0].Cells["reward_amount1"].Value.ToString();
                Reward_Provider_Name.Text = dgv_reward.SelectedRows[0].Cells["Reward_Provider_Name1"].Value.ToString();
                bounty_owner.Text = dgv_reward.SelectedRows[0].Cells["bounty_owner1"].Value.ToString();
                reward_date.Text = dgv_reward.SelectedRows[0].Cells["reward_date1"].Value.ToString();
                reward_reason.Text = dgv_reward.SelectedRows[0].Cells["reward_reason1"].Value.ToString();
                date_time_now.Text = dgv_reward.SelectedRows[0].Cells["date_time_now1"].Value.ToString();
                Emp_Code_.Text = dgv_reward.SelectedRows[0].Cells["Emp_Code_Reward"].Value.ToString();
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void btn_save_discount_Click(object sender, EventArgs e)
        {
            if (id_discount.Text == "") { discount.Save_Discount(discountamount, Emp_Code_Discount, DiscountProviderName, discount_owner, discountdate, discountreason, datetimenow); }
            else
            if (id_discount.Text != "") { discount.Edit_Discount(discountamount, Emp_Code_Discount, DiscountProviderName, discount_owner, discountdate, discountreason, datetimenow, id_discount); }
            discount.Fill_DGV_Discount(Dgv_Discount);
        }

        private void btn_Connection_Click(object sender, EventArgs e)
        {
            //try
            //{
            //axCZKEM1.SetCommPassword(Convert.ToInt16(Txt_CommKey.Text.Trim()));
            //axCZKEM1.BASE64 = 1;
            //conn = axCZKEM1.Connect_Net(btn.Text.Trim(),
            //Convert.ToInt16(btn.Text.Trim()));
            //axCZKEM1.GetLastError(errCode);
            //rr = axCZKEM1.MachineNumber;
            //    if (conn.Equals(true))
            //    {
            //        //LblMsGError.Text = "تم الاتصال بنجاح";
            //    }
            //}
            //catch (Exception ex)
            //{
            //string Er = ex.ToString();
            //HttpCookie ErCokis = new HttpCookie("ErCokis");
            //ErCokis.Value = Er.ToString();
            //ErCokis.Expires = DateTime.Now.AddHours(1);
            //Azure.Response.Cookies.Add(ErCokis);
            //Response.Redirect("~/ErrorPage.aspx");
            //}
        }

        private void btn_Click(object sender, EventArgs e)
        {
            //con.Open();
            ////ConnectMang con = new ConnectMang();
            //int dwEnrollNumber = 0;
            //string name = "";
            //string password = "";
            //int privileg = 0;
            //SqlConnection conexaoMySQL = default(SqlConnection);
            //string strSQL = " ";
            //int dwVerifyMode = 0;
            //int dwInOutMode = 0;
            //string timeStr = " ";
            //bool enable = false;
            //StringBuilder _data = new StringBuilder();
            //int _errorCode = 0;
            //int _machineNumber = 0;
            //int _enrollNumber = 0;
            //int _enrollMachineNumber = 0;
            //int _verifyMode = 0;
            //int _inOutMode = 0;
            //int _year = 0;
            //int _month = 0;
            //int _day = 0;
            //int _hour = 0;
            //int _minute = 0;
            /*  axCZKEM1.BASE64 = 1;
              axCZKEM1.ReadMark = true;
              axCZKEM1.GetLastError(_errorCode);
              axCZKEM1.ReadAllUserID(1);
              axCZKEM1.ReadMark = true;
              Boolean DD = axCZKEM1.ReadGeneralLogData(rr);
              MessageBox.Show( DD.ToString() + "MacNum____" + rr.ToString());
              if (axCZKEM1.ReadGeneralLogData(1))
              {
                  axCZKEM1.GetLastError(ref _errorCode);
                  while (axCZKEM1.GetGeneralLogData(1, ref _machineNumber, ref _enrollNumber, ref
                 _enrollMachineNumber, ref _verifyMode, ref _inOutMode, ref _year, ref _month, ref _day, ref _hour, ref
                 _minute))
                  {
                      axCZKEM1.GetGeneralLogDataStr(1, ref dwEnrollNumber, ref dwVerifyMode, ref dwInOutMode,ref timeStr);
                      axCZKEM1.GetUserInfo(1, dwEnrollNumber, ref name, ref password, ref privileg, ref enable);
                      int data1 = 0;
                      int data2 = 1000000;
                      conexaoMySQL = new SqlConnection(@"Data Source=DESKTOP-G2CDA6M\SQLEXPRESS;Initial Catalog=H_R;Integrated Security=True ");
                      if (data1 < _minute)
                    //*/
            //{
            //strSQL = "INSERT INTO InOut (dwEnrollNumber,[name], password, privileg, dwVerifyMode," +
            //    " dwInOutMode, timeStr, _machineNumber, _enrollNumber,_enrollMachineNumber, _verifyMode, _inOutMode, _year," +
            //    " _month, _day, _hour, _minute) VALUES('" +dwEnrollNumber + "','" + name + "','" + password + "','" + privileg + "','" + dwVerifyMode + "','" +dwInOutMode + "','" + timeStr + "','" + _machineNumber + "','" + _enrollNumber + "','" + _enrollMachineNumber + "','" + _verifyMode + "','" + _inOutMode + "','" + _year + "','" + _month + "','" + _day + "', '" + _hour + "', '" + _minute + "')";

            //strSQL = "INSERT INTO InOut (dwEnrollNumber,[name], password, privileg, dwVerifyMode, dwInOutMode," +
            //    " timeStr, _machineNumber, _enrollNumber,_enrollMachineNumber, _verifyMode, _inOutMode, _year, " +
            //    "_month, _day, _hour, _minute) VALUES('" + 1 + "', '" + "MM" + "','" + "PS" + "','" + 1 + "','" + 1 + "'," +
            //    "'" + 1 + "','" + "timeStr" + "','" + 1 + "','" + 1 +"','" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "'," +
            //    "'" + 1 + "', '" + 1 + "','" + 1 + "','" + 1 + "')";

            //addinmacdll.AddGdata(dwEnrollNumber, name, password, privileg, dwVerifyMode,dwInOutMode, timeStr, _machineNumber, _enrollNumber, _enrollMachineNumber, _verifyMode, _inOutMode,_year, _month, _day, _hour, _minute);
            //        }
            //        //Label1.Text = _enrollNumber.ToString();
            //    }
            //    addinmacdll.AddActdata();
            //    LblMsGError.Text= "تم تحميل الحركات";
            //}
            //con.Close();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void count_Salary_Click(object sender, EventArgs e)
        {
            //string dec = (txtsalary + txtReward - txtDiscount).ToString();
        }

        //private void past_month_Click(object sender, EventArgs e)
        //{
        //    abse.Past_button(dgv_month);
        //    abse.BALANCE(dgv_month, discount_month);
        //    txt_abs_month.Text = dgv_month.Rows.Count.ToString();
        //}

        //private void past_without_permession_Click(object sender, EventArgs e)
        //{
        //    abse.Past_button(dgv_without_permession);
        //    abse.BALANCE(dgv_without_permession, discount_without_permssion);
        //    txt_out_per.Text = dgv_without_permession.Rows.Count.ToString();
        //}

        //private void past_with_permession_Click(object sender, EventArgs e)
        //{
        //    abse.Past_button(dgv_permession);
        //    abse.BALANCE(dgv_permession, discount_permwssion);
        //    txt_with_perm.Text = dgv_permession.Rows.Count.ToString();
        //}

        private void btn_new_discount_Click(object sender, EventArgs e)
        {
            discount.clear_discount_reward(id_discount, Emp_Code_Discount, discountamount, DiscountProviderName, discount_owner, discountdate, discountreason, datetimenow);
            discount.Fill_DGV_Discount(Dgv_Discount);
        }

        private void btn_delete_discount_Click(object sender, EventArgs e)
        {
            discount.Delete_Discount(id_discount);
            discount.Fill_DGV_Discount(Dgv_Discount);
        }

        //private void btn_count_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        decimal dc1 = 0; ; decimal dc2 = 0;
        //        if (discount_permwssion.Text.Trim() == "")
        //        {
        //            discount_permwssion.Text = "0";
        //        }
        //        else
        //        {
        //            dc1 = Convert.ToDecimal(discount_permwssion.Text.Trim());
        //        }

        //        if (discount_without_permssion.Text.Trim() == "")
        //        {
        //            discount_without_permssion.Text = "0";
        //        }
        //        else
        //        {
        //            dc2 = Convert.ToDecimal(discount_without_permssion.Text.Trim());
        //        }
        //        total_count_discount.Text = (dc1 + dc2).ToString();
        //    }
        //    catch
        //    {

        //    }
        //}

        private void txt_salary_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_salary_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar) && e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
            catch
            {
            }
        }

        private void national_id_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar) && e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
            catch
            {
            }
        }

        private void Day_coast_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            catch { }
        }

        private void btn_Refresh_Qawmia_Click(object sender, EventArgs e)
        {
            string str = "القومية";
            branch.Refrech(str, dgv_qawmia, cbo_Qawmia);
            CountDGVRows(txt_Qawmia, dgv_qawmia);
        }

        private void Refresh_Express_Click(object sender, EventArgs e)
        {
            string str = "اكسبريس";
            branch.Refrech(str, dgv_Express, cbo_Express);
            CountDGVRows(txt_express, dgv_Express);
        }

        private void Refresh_Paroon_Click(object sender, EventArgs e)
        {
            string str = "البارون";
            branch.Refrech(str, dgv_Paroon, cbo_Baroon);
            CountDGVRows(txt_baroon, dgv_Paroon);
        }

        private void Refresh_Store_Click(object sender, EventArgs e)
        {
            string str = "المخزن";
            branch.Refrech(str, dgv_Store, cbo_Store);
            CountDGVRows(txt_store, dgv_Store);
        }

        private void Refresh_Diarb_Click(object sender, EventArgs e)
        {
            string str = "ديرب نجم";
            branch.Refrech(str, dgv_diarb, cbo_Diarb);
            CountDGVRows(txt_diarb, dgv_diarb);
        }

        public void CountDGVRows(TextBox txt, DataGridView DGV)
        {
            txt.Text = DGV.Rows.Count.ToString();
        }

        private void Dgv_Discount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Dgv_Discount.Rows[e.RowIndex].Selected = true;
                discountamount.Text = Dgv_Discount.SelectedRows[0].Cells["discountamount1"].Value.ToString();
                discount_owner.Text = Dgv_Discount.SelectedRows[0].Cells["discount_owner1"].Value.ToString();
                Emp_Code_Discount.Text = Dgv_Discount.SelectedRows[0].Cells["Emp_Code3"].Value.ToString();
                discountdate.Text = Dgv_Discount.SelectedRows[0].Cells["discountdate1"].Value.ToString();
                discountreason.Text = Dgv_Discount.SelectedRows[0].Cells["discountreason1"].Value.ToString();
                DiscountProviderName.Text = Dgv_Discount.SelectedRows[0].Cells["DiscountProviderName1"].Value.ToString();
                datetimenow.Text = Dgv_Discount.SelectedRows[0].Cells["datetimenow1"].Value.ToString();
            }
            catch { }
        }

        private void txt_search_name_emp_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ( e.KeyChar ==' ')   // يسمح بكتابة ارقام ونقاط فقط
            //{
            //    Clear();
            //}
        }

        private void cbo_select_code_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_select_code_name.Text.Trim() == "بحث بالأسم") { txt_search_name_emp.Clear(); Fill_name_Emp(txt_search_name_emp); }
            else
            if (cbo_select_code_name.Text.Trim() == "بحث بالكود") { txt_search_name_emp.Clear(); Fill_Code_Emp(txt_search); }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (txt_me.Text.Trim() == "28807211300")
            {
                pnl_login.Visible = false;
                //txt_users.Visible = true;
                //btn_insert.Visible = true;
                //msg2.Visible = true;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server_Name = txt_ServerName.Text.Trim();
            Properties.Settings.Default.DataBaseName = txt_DataBaseName.Text.Trim();
            Properties.Settings.Default.UserName = txt_UserName.Text.Trim();
            Properties.Settings.Default.Password = txt_Paswword.Text.Trim();
            //Properties.Settings.Default.PRINTER = txt_Printer.Text.Trim();
            Properties.Settings.Default.Save();
            msg.Text = "تم الحفظ بنجاح";
        }

        private void Select_Server_Load(object sender, EventArgs e)
        {
            txt_ServerName.Text = Properties.Settings.Default.Server_Name;
            txt_DataBaseName.Text = Properties.Settings.Default.DataBaseName;
            txt_UserName.Text = Properties.Settings.Default.UserName;
            txt_Paswword.Text = Properties.Settings.Default.Password;
            //txt_Printer.Text = Properties.Settings.Default.PRINTER;
            //txt_users.Text = Properties.Settings.Default.login;
        }

        private void txt_me_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void h_Code_TextChanged(object sender, EventArgs e)
        {
            Select_h_code();
        }

        public void Select_h_code()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = "Select h_name,h_department,h_count_year,h_year,public_holiday,Patients,absence,rest_allowance,Remaining_annual_balance,Annual_balance_consumed from holiday where h_Code = N'" + h_Code.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    h_name.Text = dr["h_name"].ToString();
                    h_department.Text = dr["h_department"].ToString();
                    h_count_year.Text = dr["h_count_year"].ToString();
                    h_year.Text = dr["h_year"].ToString();
                    public_holiday.Text = dr["public_holiday"].ToString();
                    Patients.Text = dr["Patients"].ToString();
                    absence.Text = dr["absence"].ToString();
                    rest_allowance.Text = dr["rest_allowance"].ToString();
                    Annual_balance_consumed.Text = dr["Annual_balance_consumed"].ToString();
                }
                dr.Close();
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
            //con.Close();
        }

        public void Select_All_holiday()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = "Select h_name,h_department,h_count_year,h_year,public_holiday,Patients,rest_allowance,Remaining_annual_balance,Annual_balance_consumed from holiday where code = N'" + h_Code.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dgv_holiday.DataSource = dr;
                }
                dr.Close();
            }
            catch { }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }

        private void dgv_Emp_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            CountDGVRows(txt_total_emp, dgv_Emp);
        }
        private void Btn_Search_Report_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            con.Open();
            string query = "Select * from Employee_HR where emp_job = N'" + cbo_Search_Rpt.Text.Trim() + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();                             /// اسم الداتا سيت التي قمت بانشائها مسبقا
            da.Fill(ds, "DataTable");                               /// اسم الجدول الذي انشاته داخل هذه الداتا سيت
            ReportDataSource dataSource = new ReportDataSource("DataSet", ds.Tables[0]); //تكرار اسم الداتا سيت
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.RefreshReport();
            if (con.State == ConnectionState.Open) { con.Close(); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "بحث بالأسم") { txt_search.Clear(); Fill_name_Emp(txt_search); }
            else
            if (comboBox1.Text.Trim() == "بحث بالكود") { txt_search.Clear(); Fill_Code_Emp(txt_search); }
        }

        private void txt_search_TextChanged_1(object sender, EventArgs e)
        {
            Select_Salary();
            Select_h_total();
        }

        public void Select_Salary()
        {
            try
            {

            
            if (con.State == ConnectionState.Open) { con.Close(); }
            con.Open();
            string query = "SELECT  name_Emp, emp_job,txt_salary FROM Employee_HR where name_Emp = N'" + txt_search.Text.Trim() + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name_Sa.Text = dr[0].ToString();
                job_sa.Text = dr[1].ToString();
                salary_sa.Text = dr[2].ToString();
                //discount_sa.Text = dr[3].ToString();
            }
            dr.Close();
            }
            catch
            {

            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
        }
        public void Select_h_total()
        {
            try
            {


                if (con.State == ConnectionState.Open) { con.Close(); }
                con.Open();
                string query = "SELECT h_total from holiday where h_name = N'" + txt_search.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    discount_sa.Text = dr[0].ToString();
                }
                else { discount_sa.Text = "0"; }
                dr.Close();
            }
            catch {  }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
        }

    }
}
