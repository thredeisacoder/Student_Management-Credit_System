using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDSV_HTC.BLL;
using QLDSV_HTC.DAL;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.GUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

            // Test database connection
            if (!DatabaseConnection.TestConnection())
            {
                MessageBox.Show("Cannot connect to database. Please check your connection settings.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            // Check if it's a student login
            if (rdoSinhVien.Checked)
            {
                try
                {
                    bool isValidLogin = SinhVienBLL.CheckLogin(username, password);
                    if (isValidLogin)
                    {
                        // Get student information
                        SinhVien sinhVien = SinhVienBLL.GetSinhVienByMaSV(username);
                        if (sinhVien != null)
                        {
                            // Store user information in Program.cs
                            Program.Username = username;
                            Program.Role = "SV";
                            Program.FullName = sinhVien.Ho + " " + sinhVien.Ten;

                            // Open main form
                            FormMain formMain = new FormMain();
                            this.Hide();
                            formMain.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Student not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Faculty login
            {
                try
                {
                    bool isValidLogin = GiangVienBLL.CheckLogin(username, password);
                    if (isValidLogin)
                    {
                        // Get faculty information
                        GiangVien giangVien = GiangVienBLL.GetGiangVienByMaGV(username);
                        if (giangVien != null)
                        {
                            // Store user information in Program.cs
                            Program.Username = username;
                            Program.Role = "GV";
                            Program.FullName = giangVien.Ho + " " + giangVien.Ten;

                            // Open main form
                            FormMain formMain = new FormMain();
                            this.Hide();
                            formMain.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Faculty not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoSinhVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSinhVien.Checked)
            {
                lblUsername.Text = "Mã SV:";
            }
        }

        private void rdoGiangVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGiangVien.Checked)
            {
                lblUsername.Text = "Login:";
            }
        }
    }
}
