using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI計算機
{
    public partial class frmBMI : Form
    {
        string[] strResultList = { "體重過輕", "健康體位", "體位過重", "輕度肥胖", "中度肥胖", "重度肥胖" };
        Color[] colorList = { Color.Blue, Color.Green, Color.Orange, Color.DarkOrange, Color.Red, Color.Purple };
        string[] suggestionList = {
            "建議多攝取營養，並進行適度運動以增加肌肉量。",
            "非常棒！請繼續保持均衡飲食與規律運動的習慣。",
            "體重稍微超標囉！建議控制零食攝取，並增加有氧運動。",
            "達到肥胖等級了。建議諮詢營養師，調整飲食結構並規律運動。",
            "健康風險增加。建議制定減重計畫，減少高熱量食物攝取。",
            "肥胖程度較嚴重。為了您的健康，建議尋求專業醫師或營養師協助。"
        };

        public frmBMI()
        {
            InitializeComponent();
            txtHeight.Text = "170";
            txtWeight.Text = "50";
            txtAge.Text = "20";
            rdoMale.Checked = true;
            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            bool isWeightValid = double.TryParse(txtWeight.Text, out double weight);
            bool isAgeValid = int.TryParse(txtAge.Text, out int age);


            if (isHeightValid && isWeightValid && isAgeValid && height > 0 && weight > 0 && age > 0)
            {
                height /= 100;
                double bmi = weight / (height * height);

                string strResult = "";
                Color colorResult = Color.Black;
                int resultIndex = 0;
                if (bmi < 18.5)
                {
                    resultIndex = 0;
                }
                else if (bmi < 24)
                {
                    resultIndex = 1;
                }
                else if (bmi < 27)
                {
                    resultIndex = 2;
                }
                else if (bmi < 30)
                {
                    resultIndex = 3;
                }
                else if (bmi < 35)
                {
                    resultIndex = 4;
                }
                else
                {
                    resultIndex = 5;
                }
                strResult = strResultList[resultIndex];
                colorResult = colorList[resultIndex];

                lblBMIResult.Text = $"{bmi:F2} ({strResult})";
                lblBMIResult.BackColor = colorResult;

                int genderCode = 0;
                if (rdoMale.Checked)
                {
                    genderCode = 1;
                }
                else if (rdoFemale.Checked)
                {
                    genderCode = 0;
                }

                double bfp = (1.2 * bmi) + (0.23 * (double)age) - (10.8 * (double)genderCode) - 5.4;

                lblBFPResult.Text = $"{bfp:F2} %";

                lblSuggestion.Text = suggestionList[resultIndex];
                lblSuggestion.ForeColor = Color.Black; // 確保文字顏色清晰
            }

            else
            {
                MessageBox.Show("請輸入有效的數字。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
