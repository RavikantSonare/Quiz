using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for ExamRun.xaml
    /// </summary>
    public partial class ExamRun : System.Windows.Controls.Page
    {
        int index = 0;
        List<propertyClass> _list = new List<propertyClass>();
        TodoItem filelist = (TodoItem)Application.Current.Properties["test"];

        public ExamRun()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _list = bindQuestionListboxToList();
            listQuestion.ItemsSource = _list.Skip(index).Take(1);
            btnPrevious.IsEnabled = false;
            showQuestionNo(index + 1, _list.Count);
        }

        private List<propertyClass> bindQuestionListboxToList()
        {
            string[] filePath;
            if (filelist.Path != null)
            {
                filePath = File.ReadAllLines(filelist.Path);
            }
            else
            {
                filePath = File.ReadAllLines(System.AppDomain.CurrentDomain.BaseDirectory + "\\Examfile\\Quiz1.txt");
            }
            //System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Examfile\Quiz2.txt");

            List<propertyClass> objprop = new List<propertyClass>();
            List<Answerlist> objprop1 = new List<Answerlist>();
            List<RightAnswer> objAnswerlist = new List<RightAnswer>();
            List<string> objprop2 = new List<string>() { "A.", "B.", "C.", "D.", "E.", "F.", "G.", "H.", "I.", "J." };

            string tempp = string.Empty; string explaination = string.Empty;
            int questNo = 0;
            bool flag = true, flagQue = false, flagExp = false;
            string[] s;
            string[] aas = null;
            for (int i = 0; i < filePath.Length; i++)
            {
                string temp = filePath[i].Trim();
                if (temp != string.Empty)
                {
                    if (temp == "Question")
                    {
                        questNo++;
                        flagQue = true; flagExp = true;
                    }
                    else
                    {
                        if (objprop2.Contains(temp.Substring(0, 2)))
                        {
                            objprop1.Add(new Answerlist { Answer = temp.Substring(2).Trim(), QuestionNo = questNo });
                        }
                        else
                        {
                            if (temp.Contains("Answer:"))
                            {
                                s = temp.Split(':');
                                aas = Array.ConvertAll(s[1].Split(','), p => p.Trim());
                                for (int j = 0; j < objprop1.Count; j++)
                                {
                                    string value = Convert.ToChar(65 + j).ToString();
                                    if (aas.Contains(value))
                                    {
                                        objAnswerlist.Add(new RightAnswer { Rightanswer = true });
                                        if (filelist.Mode == "SM")
                                        {
                                            objprop1[j].UserAnwer = true;
                                        }
                                    }
                                    else objAnswerlist.Add(new RightAnswer { Rightanswer = false });
                                }
                            }
                            else if (temp.Contains("Explanation:"))
                            {
                                explaination += temp + "\n";
                                flagQue = false;
                                flagExp = false;
                            }
                            else
                            {
                                if (flagQue == true && flagExp == true)
                                {
                                    tempp += temp + "\n";
                                }
                                else if (flagExp == false && flagQue == false)
                                {
                                    explaination += temp + "\n";
                                    flag = false;
                                }
                            }
                        }
                    }
                }
                if (questNo > 0 && flag == false)
                {
                    int qtype = 1; bool mode = true; bool ureslut = false;
                    if (aas.Length > 1)
                    {
                        qtype = 2;
                    }
                    if (filelist.Mode == "SM")
                    { mode = false; ureslut = true; }
                    objprop.Add(new propertyClass { QuestionNo = questNo, Question = tempp, Answerlist = objprop1, RightAnswerlist = objAnswerlist, QuestionType = qtype, NoofAnswer = objprop1.Count, Score = 1, userResult = ureslut, Explaination = explaination, ExamMode = mode });
                    tempp = explaination = ""; objprop1 = new List<Answerlist>(); objAnswerlist = new List<RightAnswer>();
                    flag = true; flagQue = false; flagExp = false;
                }
            }
            return objprop;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (_list.Count - 1 > index)
            {
                index++;
                btnPrevious.IsEnabled = true;
                listQuestion.ItemsSource = _list.Skip(index).Take(1);
                showQuestionNo(index + 1, _list.Count);
            }
            if (_list.Count - 1 == index)
            {
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = false;
            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                btnNext.IsEnabled = true;
                listQuestion.ItemsSource = _list.Skip(index).Take(1);
                showQuestionNo(index + 1, _list.Count);

            }
            if (index == 0)
            {
                btnNext.IsEnabled = true;
                btnPrevious.IsEnabled = false;
            }
        }

        private void showQuestionNo(int qno, int totalques)
        {
            lblQuestionOutof.Content = totalques.ToString();
            lblQuestionNo.Content = qno.ToString();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            var QuestionNo = Convert.ToInt32(button.TabIndex);
            var UserAns = button.Tag.ToString();
            _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.ToList().ForEach(n => n.UserAnwer = false);
            _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.Where(f => f.Answer.Equals(UserAns)).FirstOrDefault().UserAnwer = true;

            var QuetionOrignalAns = _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().RightAnswerlist;
            var QuetionUserAns = _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.ToList();
            int i = 0;
            foreach (var item in QuetionOrignalAns.ToList())
            {
                if (item.Rightanswer == QuetionUserAns[i].UserAnwer && item.Rightanswer)
                {

                    _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().userResult = true;
                    break;
                }
                else
                {
                    _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().userResult = false;
                }
                i++;
            }
        }

        private void btnEndExam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ExamReport(_list.Where(z => z.userResult == true).Count(), _list.Count()));
        }
    }


    class propertyClass
    {
        public int QuestionNo { get; set; }
        public string Question { get; set; }
        public List<Answerlist> Answerlist { get; set; }
        public List<RightAnswer> RightAnswerlist { get; set; }
        public int QuestionType { get; set; }
        public int NoofAnswer { get; set; }
        public decimal Score { get; set; }
        public bool userResult { get; set; }
        public string Explaination { get; set; }
        public bool ExamMode { get; set; }
    }

    class Answerlist
    {
        public string Answer { get; set; }
        public bool UserAnwer { get; set; }
        public int QuestionNo { get; set; }
    }

    class RightAnswer { public bool Rightanswer { get; set; } }
}

