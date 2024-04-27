using Application.Services;
using Domain.Entities;
using KeyboardTrainer.Domain.Primitives;
using System.Reflection;

namespace KeyboardTrainer
{
    public partial class LevelForm : Form
    {

        private Level _currentLevel;
        private LevelService _levelService;
        private SessionService _sessionService;
        private MainForm _mainForm;
        private DateTime _startTime;
        private System.Threading.Timer _timer;
        private TimeSpan _currentPassTime { get; set; }
        private LevelStatus _status { get; set; }
        private Dictionary<string, string> keyImage = new Dictionary<string, string>();
        private int MissCount { get; set; }
        private bool _currentLetterIsMissed;
        private Session _session;

        public LevelForm(Level currentLevel, SessionService sessionService, LevelService levelService, MainForm mainForm, Session session)
        {
            InitializeComponent();
            _session = session;
            _currentLevel = currentLevel;
            _sessionService = sessionService;
            _mainForm = mainForm;
            _levelService = levelService;
            textBox1.Text = "";

            string levelText = _currentLevel.LevelText;


            label10.Text = levelText.ToCharArray()[0].ToString();

            List<char> c = levelText.ToCharArray().ToList();

            c.RemoveAt(0);

            label1.Text = new string(c.ToArray());



            ChangeImageKeyboardDeafault();

            SetKeyImage();
        }

        private void SetKeyImage()
        {
            // проходимся по всем клавишам клавиатуры и устанавливаем значения в keyImage
            string[] AnglSymblBig = new string[] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "OemOpenBrackets", "Oem6", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Oem1", "OemQuotes", "Oem5", "Z", "X", "C", "V", "B", "N", "M", "Oemcomma", "OemPeriod", "OemQuestion", "~", "Space" };
            foreach (var symbl in AnglSymblBig)
            {
                string folder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(folder, "Images", "Key" + symbl + ".jpg");
                Uri pathUri = new Uri(filePath);
                if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    folder += Path.DirectorySeparatorChar;
                Uri folderUri = new Uri(folder);

                string path = Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));

                keyImage.Add(symbl, path);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// метод останавливающий прохождение
        /// </summary>
        private void End()
        {
            //останавливаем таймер
            _timer.Change(Timeout.Infinite, Timeout.Infinite);

            //помечаем уровень как законченный
            _status = LevelStatus.Finished;

            //записываем данные прохождения в объхект сесии
            _session.LevelsCompleted[_currentLevel.Index] = true;

            //сохраняем объект сессии или обновляем
            _sessionService.SetRecordValues(_session, MissCorrectAccurasyBar(), new TimeOnly(_currentPassTime.Hours, _currentPassTime.Minutes, _currentPassTime.Seconds), _currentLevel.Index);
        }
        /// <summary>
        /// метод проверяющий не закончили ли мы прохождение
        /// </summary>
        /// <returns></returns>
        private bool CheckComplete()
        {
            return label1.Text == "" && label10.Text == "";
        }
        /// <summary>
        /// метод начинающий прохождение
        /// </summary>
        private void Play()
        {
            //запускаем таймер который будет отсчитывать время за которое мы пройдем уровень
            _startTime = DateTime.Now;
            _timer = new System.Threading.Timer(
            (object state) =>
            {
                _currentPassTime = DateTime.Now - _startTime;
                UpdateLabel4Text(_currentPassTime.ToString(@"mm\:ss"));
            }, null, 0, 1000); // Таймер будет вызывать метод TimerCallback каждую секунду


            //помечаем свойство начато ли прохождение как Playing
            _status = LevelStatus.Playing;
        }
        private void UpdateLabel4Text(string text)
        {
            if (label4.InvokeRequired)
            {
                label4.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    label4.Text = text;
                });
            }
            else
            {
                label4.Text = text;
            }
        }
        /// <summary>
        /// метод обновляющий текст в соответствии с прохождением
        /// </summary>
        private void NextLetterLabelText()
        {
            //разделяем правое и левое поля на масив чар
            List<char> leftLabelChars = textBox1.Text.ToCharArray().ToList();
            List<char> rightLabelChars = label1.Text.ToCharArray().ToList();

            //в левое поле добовляем букву на кнопке
            leftLabelChars.Add(label10.Text.ToCharArray()[0]);
            textBox1.Text = new string(leftLabelChars.ToArray());

            //устанавливаем в кнопку текст с первой буквы правого поля, если оно не пусто
            if (rightLabelChars.Count != 0)
            {
                label10.Text = rightLabelChars[0].ToString();
                //удаляем первый знак с правого поля и сохраняем его
                rightLabelChars.RemoveAt(0);

                label1.Text = new string(rightLabelChars.ToArray());
            }
            else
            {
                label10.Text = "";
            }
        }

        /// <summary>
        /// меняет внешний вид клавиатуры в зависимоти от символа
        /// </summary>
        /// <param name="letter"></param>
        private void ChangeImageKeyboardWord(Keys key)
        {
            string keyStr = new KeysConverter().ConvertToString(key);
            if (keyImage.ContainsKey(keyStr))
            {
                pictureBox1.ImageLocation = keyImage[keyStr];
            }
        }
        /// <summary>
        /// меняет внешний вид клавиатуры на обычный
        /// </summary>
        private void ChangeImageKeyboardDeafault()
        {
            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var relativePath = @"Images\defaultKey.jpg";
            var fullPath = Path.Combine(appDir, relativePath);
            pictureBox1.ImageLocation = fullPath;
        }
        /// <summary>
        /// метод обрабатывает полученное значение клавиши и переводит ее на русскую раскладку и возвращает в строке
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private string KeyHandler(KeyEventArgs e)
        {
            string enteredChar = new KeysConverter().ConvertToString(e.KeyValue);

            string[] RusSymbolSmal = new string[] { "й", "ц", "у", "к", "е", "н", "г", "ш", "щ", "з", "х", "ъ", "ф", "ы", "в", "а", "п", "р", "о", "л", "д", "ж", "э", @"\", "я", "ч", "с", "м", "и", "т", "ь", "б", "ю", ".", "ё", " " };
            string[] AnglSymblBig = new string[] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "OemOpenBrackets", "Oem6", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Oem1", "OemQuotes", "Oem5", "Z", "X", "C", "V", "B", "N", "M", "Oemcomma", "OemPeriod", "OemQuestion", "~", "Space" };

            int index = Array.IndexOf<string>(AnglSymblBig, enteredChar);
            if (index != -1)
            {
                return RusSymbolSmal[index];
            }
            else
            {
                return new KeysConverter().ConvertToString(e.KeyValue);
            }
        }
        private void RefreshProgressBarValue()
        {
            double progressBarValue = ((double)textBox1.Text.ToCharArray().Count() / (double)_currentLevel.LevelText.ToCharArray().Count()) * 100;
            label8.Text = $"{progressBarValue:f0}%";
        }
        private double MissCorrectAccurasyBar()
        {
            return 100 - (double)MissCount / (double)_currentLevel.LevelText.ToCharArray().Length * 100;
        }
        /// <summary>
        /// метод вызывающийся при нажатии на клавишу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyDownLevel(object sender, KeyEventArgs e)
        {
            //получаем клавишу с измененной раскладкой 
            string input = KeyHandler(e);

            //если нажата клавиша значение которой равно значению на кнопке, и прохождение не начато, то вызвать метод начала прохождения
            if (label10.Text == input && _status == LevelStatus.WaitingForStart)
            {
                Play();
            }
            //если нажатая клавиша не совпадает с клавишей на кнопке, то уменьшить точность
            if (label10.Text != input && _status == LevelStatus.Playing && !_currentLetterIsMissed)
            {
                MissCount++;
                _currentLetterIsMissed = true;
                label5.Text = $"{MissCorrectAccurasyBar():f0}%";
            }

            //если нажатая клавиша совпадает с клавишей на кнопке, то сдвинуть символы в полях, и увеличить значение на прогрес баре
            if (label10.Text == input && _status == LevelStatus.Playing)
            {
                NextLetterLabelText();
                RefreshProgressBarValue();
                _currentLetterIsMissed = false;
            }

            // если уровень пройден, то вызвать метод сохраняюищй результаты
            if (CheckComplete() && _status == LevelStatus.Playing)
            {
                End();
                KeyDown -= KeyDownLevel;
                KeyUp -= KeyUpLevel;
                ChangeImageKeyboardDeafault();
            }

            //изменить изображение клавиатуры в зависмости от нажатой клавиши
            ChangeImageKeyboardWord(e.KeyCode);

        }
        private void KeyUpLevel(object sender, KeyEventArgs e)
        {
            ChangeImageKeyboardDeafault();
        }



        private void LevelForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// кнопка нажатия выйти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            _mainForm.RefreshLabels();
            Close();
            _mainForm.Show();
        }
    }
}
