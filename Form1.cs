using System.Drawing.Drawing2D;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Icon customIcon = new Icon("icon.ico");
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            list.Add("Профессиональный разработчик с опытом работы более X лет в области программирования на C#, C++ и использования Microsoft SQL Server. Обладаю глубокими знаниями и практическим опытом в разработке масштабируемых и эффективных приложений, отвечающих высоким стандартам качества.");
            list.Add("Программирование на C# и C++: опыт разработки приложений с использованием современных практик и стандартов языка, включая многозадачность, обработку ошибок и оптимизацию производительности.");
            list.Add("Базы данных: глубокие знания в проектировании, оптимизации и обслуживании баз данных с использованием Microsoft SQL Server. Опыт работы с T-SQL для создания эффективных запросов и процедур.");
            list.Add("Архитектура приложений: опыт проектирования и разработки модульных, масштабируемых и поддерживаемых приложений с применением принципов объектно-ориентированного программирования.");



            int wordCount = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                wordCount += list[i].Length;
                MessageBox.Show(list[i], "РЕЗЮМЕ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            wordCount += list[list.Count - 1].Length;
            MessageBox.Show(list[list.Count - 1], "" + (wordCount / list.Count), MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int targetNumber = random.Next(1, 2001);
            int attempts = 0;
            int lastNum = 0;

            MessageBox.Show("Загадано число от 1 до 2000", "Игра", MessageBoxButtons.OK, MessageBoxIcon.Information);

            while (true)
            {
                string userInput = Microsoft.VisualBasic.Interaction.InputBox("Введите ваше предположение:" + (lastNum != 0 ? "\n\nПрошлое введенное число: " + lastNum : ""), "Игра", "", -1, -1);

                // был ли введен пустой ответ
                if (userInput == "")
                {
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите завершить игру?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                        break;
                    else
                        continue;
                }

                if (!int.TryParse(userInput, out int userGuess))
                {
                    MessageBox.Show("Введите корректное число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                lastNum = userGuess;

                attempts++;

                if (userGuess == targetNumber)
                {
                    MessageBox.Show($"Вы угадали число {targetNumber} за {attempts} попыток.", "Игра", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                else if (userGuess < targetNumber)
                {
                    MessageBox.Show("Загаданное число больше вашего предположения.", "Игра", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Загаданное число меньше вашего предположения.", "Игра", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private bool checkCtrl()
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                label4.Text = "push";
                return true;
            }
            else label4.Text = "unpush";
            return false;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;


            Point clientCoordinates = panel1.PointToClient(new Point(mouseX, mouseY));
            //Point screenCoordinates = panel1.PointToScreen(new Point(mouseX, mouseY));

            //Form1.ActiveForm.Text = clientCoordinates.X + ":" + clientCoordinates.Y;
            //реализация не возможна,не возможно использовать заголовок одновременно для размера окна и для отображения координаты мыши(перебивают друг друга)
            label2.Text = $"{clientCoordinates.X} : {clientCoordinates.Y}";
            checkCtrl();

        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            checkCtrl();
            label1.Text = "IN";

        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "OUT";
            checkCtrl();
        }





        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            checkCtrl();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Size clientSize = this.ClientSize;
                Form1.ActiveForm.Text = $"Ширина: {clientSize.Width}| Высота: {clientSize.Height}";
            }
            if (checkCtrl())
            {

                label5.Text = "exit";
                //Close();
            }
        }
    }
}
