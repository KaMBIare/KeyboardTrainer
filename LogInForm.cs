using Application.Services;
using Domain.Entities;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardTrainer
{
    public partial class LogInForm : Form
    {
        private SessionService _sessionService;
        private LevelService _levelService;
        public LogInForm()
        {
            var context = new KeyboardTrainerDBContext();
            _sessionService = new SessionService(context);
            _levelService = new LevelService(context);
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //првоерка на ввод текста в оба поля
            if (NameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                errorLabel.Text = "Поля имя и пароль должны быть заполнены";
            }
            else
            {

                //авторизация в базе данных
                Session session = _sessionService.Authorization(NameTextBox.Text, PasswordTextBox.Text);

                //открыте главного окна
                MainForm mainForm = new MainForm(session, _sessionService, _levelService);
                mainForm.Show();

                //сокрытие формы логина
                Hide();
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
