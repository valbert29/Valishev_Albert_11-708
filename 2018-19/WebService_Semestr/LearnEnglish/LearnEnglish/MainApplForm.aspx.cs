using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LearnEnglish
{
    public partial class MainApplForm : Page
    {

        public static MainWebService service = new MainWebService();
        List<string> questions = service.InitQuestions();
        List<Tuple<string, int>> currentBtnConfig; //= service.GetCurrConfiguration();

        //прикаждом нажатии клавиши запукается этот метод
        protected void Page_Load(object sender, EventArgs e)
        {
            //получаем конфигурацию заданий а потом подготавливаем к работе
            currentBtnConfig = service.GetCurrConfiguration();
            ChangeBtnsVisible(service.IsStarted);
        }

        //меняет видимость кнопок
        private void ChangeBtnsVisible(bool isStarted)
        {
            btnTR.Visible = isStarted;
            btnTL.Visible = isStarted;
            btnDR.Visible = isStarted;
            btnDL.Visible = isStarted;
            service.IsStarted = true;
            StartBtn.Visible = !isStarted;
        }

        //заполняет кнопки данными, взятыми из БД
        private void FillBtnValues()
        {
            //var buttons = service.InputToButton(i);
           
            btnTL.Text = currentBtnConfig[0].Item1;
            btnTR.Text = currentBtnConfig[1].Item1;
            btnDL.Text = currentBtnConfig[2].Item1;
            btnDR.Text = currentBtnConfig[3].Item1;
        }
        
        //метод, вызывающийся на нажатие клавиши и вызывающие след вопрос
        protected void btnDiv_Click(object sender, EventArgs e)
        {
            //вызов метода, который проверит правильность ответа
            var item = sender as Button;
            service.CheckAnswCorrctness((item as Button).Text);
            //проходит вызов метода, записывающего ответ пользователя в таблицу
            Next(sender, e);
        }

        //метод предоставляющий след вопрос
        protected void Next(object sender, EventArgs e)
        {
            Word.Text = service.GetNextQuest(questions);
            if(Word.Text == "")
            {
                btnTR.Visible = false;
                btnTL.Visible = false;
                btnDR.Visible = false;
                btnDL.Visible = false;
                Word.Text = $"Thank you for passing our test Your scored {service.CorrectAnswCounter}/25";
            }
            else FillBtnValues();
        }
    }
}