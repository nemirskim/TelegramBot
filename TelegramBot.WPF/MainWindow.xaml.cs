﻿using System;
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
using System.Windows.Threading;
using TelegramBot.BLL;


namespace TelegramBot.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TBot _tbot;
        private const string _token = "5149025176:AAF9ywvM1nXIkvpfKK4wV7Fsy8nTapirCDE";
        private List<string> _labels;
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
            _tbot = new TBot(_token, OnMessage);
            _labels = new List<string>();
            InitializeComponent();

            ListBox_Users.ItemsSource = _labels;


            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += OnTick;
            _timer.Start();
            _tbot.Start();
        }

        public void OnMessage(string s)
        {
            _labels.Add(s);
        }
        private void OnTick(object sender, EventArgs e)
        {
            ListBox_Users.Items.Refresh();
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            _tbot.Send(TextBox_Question.Text);
        }


        private void ComboBox_ChooseQuestionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_ChooseQuestionType.SelectedIndex != -1)
            {
                RadioButton_Test.Visibility = Visibility.Visible;
                RadioButton_Test.IsChecked = false;
                RadioButton_Poll.Visibility = Visibility.Visible;
                RadioButton_Poll.IsChecked = false;
                TextBox_Question.Visibility = Visibility.Visible;
                Lable_QuestionTitle.Visibility = Visibility.Visible;
            }

            switch (ComboBox_ChooseQuestionType.SelectedIndex)
            {
                case 0:
                    TextBox_VariantsChoseOneOfFew.Visibility = Visibility.Hidden;
                    Button_AddVariantChoseOneOfFew.Visibility = Visibility.Hidden;
                    Button_RemoveVariantChoseOneOfFew.Visibility = Visibility.Hidden;

                    TextBox_VariantsChosenMultiple.Visibility = Visibility.Hidden;
                    Button_AddVariantChosenMultiple.Visibility = Visibility.Hidden;
                    Button_RemoveVariantChosenMultiple.Visibility = Visibility.Hidden;

                    Label_TrueAnswer.Visibility = Visibility.Hidden;
                    TextBox_TrueAnswerChoseOneOfFew.Visibility = Visibility.Hidden;

                    TextBox_TrueAnswerChosenMultiple.Visibility = Visibility.Hidden;
                    Button_AddAnswer.Visibility = Visibility.Hidden;
                    Button_RemoveAnswer.Visibility = Visibility.Hidden;
                    ChoseMultiple.Visibility = Visibility.Hidden;

                    RadioButton_Yes.Visibility = Visibility.Hidden;
                    RadioButton_No.Visibility = Visibility.Hidden;
                    YesOrNo.Visibility = Visibility.Hidden;

                    break;
                case 1:
                    TextBox_VariantsChosenMultiple.Visibility = Visibility.Hidden;
                    Button_AddVariantChosenMultiple.Visibility = Visibility.Hidden;
                    Button_RemoveVariantChosenMultiple.Visibility = Visibility.Hidden;

                    Label_TrueAnswer.Visibility = Visibility.Hidden;
                    TextBox_AnswerUserEnter.Visibility = Visibility.Hidden;

                    TextBox_TrueAnswerChosenMultiple.Visibility = Visibility.Hidden;
                    Button_AddAnswer.Visibility = Visibility.Hidden;
                    Button_RemoveAnswer.Visibility = Visibility.Hidden;
                    ChoseMultiple.Visibility = Visibility.Hidden;

                    RadioButton_Yes.Visibility = Visibility.Hidden;
                    RadioButton_No.Visibility = Visibility.Hidden;
                    YesOrNo.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    TextBox_VariantsChoseOneOfFew.Visibility = Visibility.Hidden;
                    Button_AddVariantChoseOneOfFew.Visibility = Visibility.Hidden;
                    Button_RemoveVariantChoseOneOfFew.Visibility = Visibility.Hidden;

                    Label_TrueAnswer.Visibility = Visibility.Hidden;
                    TextBox_AnswerUserEnter.Visibility = Visibility.Hidden;

                    Label_TrueAnswer.Visibility = Visibility.Hidden;
                    TextBox_TrueAnswerChoseOneOfFew.Visibility = Visibility.Hidden;

                    RadioButton_Yes.Visibility = Visibility.Hidden;
                    RadioButton_No.Visibility = Visibility.Hidden;
                    YesOrNo.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    TextBox_VariantsChoseOneOfFew.Visibility = Visibility.Hidden;
                    Button_AddVariantChoseOneOfFew.Visibility = Visibility.Hidden;
                    Button_RemoveVariantChoseOneOfFew.Visibility = Visibility.Hidden;

                    TextBox_VariantsChosenMultiple.Visibility = Visibility.Hidden;
                    Button_AddVariantChosenMultiple.Visibility = Visibility.Hidden;
                    Button_RemoveVariantChosenMultiple.Visibility = Visibility.Hidden;

                    Label_TrueAnswer.Visibility = Visibility.Hidden;
                    TextBox_AnswerUserEnter.Visibility = Visibility.Hidden;

                    Label_TrueAnswer.Visibility = Visibility.Hidden;
                    TextBox_TrueAnswerChoseOneOfFew.Visibility = Visibility.Hidden;

                    TextBox_TrueAnswerChosenMultiple.Visibility = Visibility.Hidden;
                    Button_AddAnswer.Visibility = Visibility.Hidden;
                    Button_RemoveAnswer.Visibility = Visibility.Hidden;
                    ChoseMultiple.Visibility = Visibility.Hidden;

                    break;
                case 4:

                    break;
            }

            switch (ComboBox_ChooseQuestionType.SelectedIndex)
            {

                case 1:
                    TextBox_VariantsChoseOneOfFew.Visibility = Visibility.Visible;
                    Button_AddVariantChoseOneOfFew.Visibility = Visibility.Visible;
                    Button_RemoveVariantChoseOneOfFew.Visibility = Visibility.Visible;
                    break;
                case 2:
                    TextBox_VariantsChosenMultiple.Visibility = Visibility.Visible;
                    Button_AddVariantChosenMultiple.Visibility = Visibility.Visible;
                    Button_RemoveVariantChosenMultiple.Visibility = Visibility.Visible;
                    break;
 
                case 4:

                    break;
            }
        }

        private void RadioButton_Test_Click(object sender, RoutedEventArgs e)
        {
            switch (ComboBox_ChooseQuestionType.SelectedIndex)
            {
                case 0:
                    Label_TrueAnswer.Visibility = Visibility.Visible;
                    TextBox_AnswerUserEnter.Visibility = Visibility.Visible;
                    break;
                case 1:
                    Label_TrueAnswer.Visibility = Visibility.Visible;
                    TextBox_TrueAnswerChoseOneOfFew.Visibility = Visibility.Visible;
                    break;
                case 2:
                    TextBox_TrueAnswerChosenMultiple.Visibility = Visibility.Visible;
                    Button_AddAnswer.Visibility = Visibility.Visible;
                    Button_RemoveAnswer.Visibility = Visibility.Visible;
                    ChoseMultiple.Visibility = Visibility.Visible;
                    break;
                case 3:
                    RadioButton_Yes.Visibility = Visibility.Visible;
                    RadioButton_No.Visibility = Visibility.Visible;
                    YesOrNo.Visibility = Visibility.Visible;
                    break;
                case 4:

                    break;
            }
        }

        private void RadioButton_Poll_Click(object sender, RoutedEventArgs e)
        {
            switch (ComboBox_ChooseQuestionType.SelectedIndex)
            {
                case 0:
                    Label_TrueAnswer.Visibility = Visibility.Hidden;
                    TextBox_AnswerUserEnter.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    Label_TrueAnswer.Visibility = Visibility.Hidden;
                    TextBox_TrueAnswerChoseOneOfFew.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    TextBox_TrueAnswerChosenMultiple.Visibility = Visibility.Hidden;
                    Button_AddAnswer.Visibility = Visibility.Hidden;
                    Button_RemoveAnswer.Visibility = Visibility.Hidden;
                    ChoseMultiple.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    RadioButton_Yes.Visibility = Visibility.Hidden;
                    RadioButton_No.Visibility = Visibility.Hidden;
                    YesOrNo.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    break;
            }
        }

    }
}
