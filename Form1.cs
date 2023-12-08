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

            list.Add("���������������� ����������� � ������ ������ ����� X ��� � ������� ���������������� �� C#, C++ � ������������� Microsoft SQL Server. ������� ��������� �������� � ������������ ������ � ���������� �������������� � ����������� ����������, ���������� ������� ���������� ��������.");
            list.Add("���������������� �� C# � C++: ���� ���������� ���������� � �������������� ����������� ������� � ���������� �����, ������� ���������������, ��������� ������ � ����������� ������������������.");
            list.Add("���� ������: �������� ������ � ��������������, ����������� � ������������ ��� ������ � �������������� Microsoft SQL Server. ���� ������ � T-SQL ��� �������� ����������� �������� � ��������.");
            list.Add("����������� ����������: ���� �������������� � ���������� ���������, �������������� � �������������� ���������� � ����������� ��������� ��������-���������������� ����������������.");



            int wordCount = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                wordCount += list[i].Length;
                MessageBox.Show(list[i], "������", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            MessageBox.Show("�������� ����� �� 1 �� 2000", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);

            while (true)
            {
                string userInput = Microsoft.VisualBasic.Interaction.InputBox("������� ���� �������������:" + (lastNum != 0 ? "\n\n������� ��������� �����: " + lastNum : ""), "����", "", -1, -1);

                // ��� �� ������ ������ �����
                if (userInput == "")
                {
                    DialogResult result = MessageBox.Show("�� �������, ��� ������ ��������� ����?", "�����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                        break;
                    else
                        continue;
                }

                if (!int.TryParse(userInput, out int userGuess))
                {
                    MessageBox.Show("������� ���������� �����!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                lastNum = userGuess;

                attempts++;

                if (userGuess == targetNumber)
                {
                    MessageBox.Show($"�� ������� ����� {targetNumber} �� {attempts} �������.", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                else if (userGuess < targetNumber)
                {
                    MessageBox.Show("���������� ����� ������ ������ �������������.", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("���������� ����� ������ ������ �������������.", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //���������� �� ��������,�� �������� ������������ ��������� ������������ ��� ������� ���� � ��� ����������� ���������� ����(���������� ���� �����)
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
                Form1.ActiveForm.Text = $"������: {clientSize.Width}| ������: {clientSize.Height}";
            }
            if (checkCtrl())
            {

                label5.Text = "exit";
                //Close();
            }
        }
    }
}
