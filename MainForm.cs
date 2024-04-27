using Application.Services;
using Domain.Entities;
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
    public partial class MainForm : Form
    {
        /// <summary>
        /// текущая сессия
        /// </summary>
        private Session _session;
        /// <summary>
        /// сервис для работы с сесиями
        /// </summary>
        private SessionService _sessionService;

        private LevelService _levelService;

        public MainForm(Session session, SessionService sessionService, LevelService levelService)
        {
            InitializeComponent();
            _session = session;
            _sessionService = sessionService;
            _levelService = levelService;
            RefreshLabels();
        }

        /// <summary>
        /// обновляет все статичные поля данными из базы данных
        /// </summary>
        public void RefreshLabels()
        {
            string output = "";

            output = $"{_session.PassTime[0].ToString("mm:ss")}";
            label7.Text = output;
            output = $"{_session.PassTime[1].ToString("mm:ss")}";
            label8.Text = output;
            output = $"{_session.PassTime[2].ToString("mm:ss")}";
            label9.Text = output;
            output = $"{_session.PassTime[3].ToString("mm:ss")}";
            label10.Text = output;

                output = $"{_session.PassAccurasy[0]}%";
                label15.Text = output;
                output = $"{_session.PassAccurasy[1]}%";
                label16.Text = output;
                output = $"{_session.PassAccurasy[2]}%";
                label17.Text = output;
                output = $"{_session.PassAccurasy[3]}%";
                label18.Text = output;
        }




  

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void Main_Load_1(object sender, EventArgs e)
        {

        }

        #region нажатие кнопок уровней
        private void button1_Click(object sender, EventArgs e)
        {
            LevelForm level = new LevelForm(_levelService.ReadByName(button1.Text), _sessionService, _levelService, this, _session);
            level.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LevelForm level = new LevelForm(_levelService.ReadByName(button2.Text), _sessionService, _levelService, this, _session);
            level.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LevelForm level = new LevelForm(_levelService.ReadByName(button3.Text), _sessionService, _levelService, this, _session);
            level.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LevelForm level = new LevelForm(_levelService.ReadByName(button4.Text), _sessionService, _levelService, this, _session);
            level.Show();
            Hide();
        }
        #endregion

        /// <summary>
        /// кнопка обновить результаты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            RefreshLabels();
        }
    }
}
