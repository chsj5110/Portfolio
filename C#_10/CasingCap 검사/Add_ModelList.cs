using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chsj
{
    public partial class Add_ModelList : Form
    {
        public Main main;
        public Add_ModelList()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                PF.ReadModelData();

                if (PV.nLModel == 1)
                {
                    // 카메라1
                    tb_Lower_Results_Item_0_Score_1.Text = PV.stringArray_Limit1[0];
                    tb_Lower_Results_GetBlobs_Count_1.Text = PV.stringArray_Limit1[1];
                    tb_Lower_Results_GetBlobs_Item_0_Area_1.Text = PV.stringArray_Limit1[2];
                    tb_Lower_Results_GetBlobs_Count1_1.Text = PV.stringArray_Limit1[3];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_1.Text = PV.stringArray_Limit1[4];
                    tb_Lower_Results_GetBlobs_Count2_1.Text = PV.stringArray_Limit1[5];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_1.Text = PV.stringArray_Limit1[6];
                    tb_Lower_Result_Mean_1.Text = PV.stringArray_Limit1[7];
                    tb_Upper_Result_Mean_1.Text = PV.stringArray_Limit1[8];
                    tb_Lower_Result_StandardDeviation_1.Text = PV.stringArray_Limit1[9];
                    tb_Upper_Result_StandardDeviation_1.Text = PV.stringArray_Limit1[10];
                    tb_Lower_Result_Mean1_1.Text = PV.stringArray_Limit1[11];
                    tb_Upper_Result_Mean1_1.Text = PV.stringArray_Limit1[12];
                    tb_Lower_Result_StandardDeviation1_1.Text = PV.stringArray_Limit1[13];
                    tb_Upper_Result_StandardDeviation1_1.Text = PV.stringArray_Limit1[14];

                    // 카메라 2
                    tb_Lower_Results_Item_0_Score_2.Text = PV.stringArray_Limit1[15];
                    tb_Lower_Results_GetBlobs_Count_2.Text = PV.stringArray_Limit1[16];
                    tb_Lower_Results_GetBlobs_Item_0_Area_2.Text = PV.stringArray_Limit1[17];
                    tb_Lower_Results_GetBlobs_Count1_2.Text = PV.stringArray_Limit1[18];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_2.Text = PV.stringArray_Limit1[19];
                    tb_Lower_Results_GetBlobs_Count2_2.Text = PV.stringArray_Limit1[20];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_2.Text = PV.stringArray_Limit1[21];
                    tb_Lower_Result_Mean_2.Text = PV.stringArray_Limit1[22];
                    tb_Upper_Result_Mean_2.Text = PV.stringArray_Limit1[23];
                    tb_Lower_Result_StandardDeviation_2.Text = PV.stringArray_Limit1[24];
                    tb_Upper_Result_StandardDeviation_2.Text = PV.stringArray_Limit1[25];
                    tb_Lower_Result_Mean1_2.Text = PV.stringArray_Limit1[26];
                    tb_Upper_Result_Mean1_2.Text = PV.stringArray_Limit1[27];
                    tb_Lower_Result_StandardDeviation1_2.Text = PV.stringArray_Limit1[28];
                    tb_Upper_Result_StandardDeviation1_2.Text = PV.stringArray_Limit1[29];

                    // 카메라3
                    tb_Lower_Results_Item_0_Score_3.Text = PV.stringArray_Limit1[30];
                    tb_Lower_Results_GetBlobs_Count_3.Text = PV.stringArray_Limit1[31];
                    tb_Lower_Results_GetBlobs_Item_0_Area_3.Text = PV.stringArray_Limit1[32];
                    tb_Lower_Results_GetBlobs_Count1_3.Text = PV.stringArray_Limit1[33];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_3.Text = PV.stringArray_Limit1[34];
                    tb_Lower_Results_GetBlobs_Count2_3.Text = PV.stringArray_Limit1[35];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_3.Text = PV.stringArray_Limit1[36];
                    tb_Lower_Result_Mean_3.Text = PV.stringArray_Limit1[37];
                    tb_Upper_Result_Mean_3.Text = PV.stringArray_Limit1[38];
                    tb_Lower_Result_StandardDeviation_3.Text = PV.stringArray_Limit1[39];
                    tb_Upper_Result_StandardDeviation_3.Text = PV.stringArray_Limit1[40];
                    tb_Lower_Result_Mean1_3.Text = PV.stringArray_Limit1[41];
                    tb_Upper_Result_Mean1_3.Text = PV.stringArray_Limit1[42];
                    tb_Lower_Result_StandardDeviation1_3.Text = PV.stringArray_Limit1[43];
                    tb_Upper_Result_StandardDeviation1_3.Text = PV.stringArray_Limit1[44];

                    // 카메라4
                    tb_Lower_Results_Item_0_Score_4.Text = PV.stringArray_Limit1[45];
                    tb_Lower_Results_GetBlobs_Count_4.Text = PV.stringArray_Limit1[46];
                    tb_Lower_Results_GetBlobs_Item_0_Area_4.Text = PV.stringArray_Limit1[47];
                    tb_Lower_Results_GetBlobs_Count1_4.Text = PV.stringArray_Limit1[48];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_4.Text = PV.stringArray_Limit1[49];
                    tb_Lower_Results_GetBlobs_Count2_4.Text = PV.stringArray_Limit1[50];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_4.Text = PV.stringArray_Limit1[51];
                    tb_Lower_Result_Mean_4.Text = PV.stringArray_Limit1[52];
                    tb_Upper_Result_Mean_4.Text = PV.stringArray_Limit1[53];
                    tb_Lower_Result_StandardDeviation_4.Text = PV.stringArray_Limit1[54];
                    tb_Upper_Result_StandardDeviation_4.Text = PV.stringArray_Limit1[55];
                    tb_Lower_Result_Mean1_4.Text = PV.stringArray_Limit1[56];
                    tb_Upper_Result_Mean1_4.Text = PV.stringArray_Limit1[57];
                    tb_Lower_Result_StandardDeviation1_4.Text = PV.stringArray_Limit1[58];
                    tb_Upper_Result_StandardDeviation1_4.Text = PV.stringArray_Limit1[59];
                }
                else if(PV.nLModel == 2)
                {
                    // 카메라1
                    tb_Lower_Results_Item_0_Score_1.Text = PV.stringArray_Limit2[0];
                    tb_Lower_Results_GetBlobs_Count_1.Text = PV.stringArray_Limit2[1];
                    tb_Lower_Results_GetBlobs_Item_0_Area_1.Text = PV.stringArray_Limit2[2];
                    tb_Lower_Results_GetBlobs_Count1_1.Text = PV.stringArray_Limit2[3];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_1.Text = PV.stringArray_Limit2[4];
                    tb_Lower_Results_GetBlobs_Count2_1.Text = PV.stringArray_Limit2[5];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_1.Text = PV.stringArray_Limit2[6];
                    tb_Lower_Result_Mean_1.Text = PV.stringArray_Limit2[7];
                    tb_Upper_Result_Mean_1.Text = PV.stringArray_Limit2[8];
                    tb_Lower_Result_StandardDeviation_1.Text = PV.stringArray_Limit2[9];
                    tb_Upper_Result_StandardDeviation_1.Text = PV.stringArray_Limit2[10];
                    tb_Lower_Result_Mean1_1.Text = PV.stringArray_Limit2[11];
                    tb_Upper_Result_Mean1_1.Text = PV.stringArray_Limit2[12];
                    tb_Lower_Result_StandardDeviation1_1.Text = PV.stringArray_Limit2[13];
                    tb_Upper_Result_StandardDeviation1_1.Text = PV.stringArray_Limit2[14];

                    // 카메라 2
                    tb_Lower_Results_Item_0_Score_2.Text = PV.stringArray_Limit2[15];
                    tb_Lower_Results_GetBlobs_Count_2.Text = PV.stringArray_Limit2[16];
                    tb_Lower_Results_GetBlobs_Item_0_Area_2.Text = PV.stringArray_Limit2[17];
                    tb_Lower_Results_GetBlobs_Count1_2.Text = PV.stringArray_Limit2[18];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_2.Text = PV.stringArray_Limit2[19];
                    tb_Lower_Results_GetBlobs_Count2_2.Text = PV.stringArray_Limit2[20];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_2.Text = PV.stringArray_Limit2[21];
                    tb_Lower_Result_Mean_2.Text = PV.stringArray_Limit2[22];
                    tb_Upper_Result_Mean_2.Text = PV.stringArray_Limit2[23];
                    tb_Lower_Result_StandardDeviation_2.Text = PV.stringArray_Limit2[24];
                    tb_Upper_Result_StandardDeviation_2.Text = PV.stringArray_Limit2[25];
                    tb_Lower_Result_Mean1_2.Text = PV.stringArray_Limit2[26];
                    tb_Upper_Result_Mean1_2.Text = PV.stringArray_Limit2[27];
                    tb_Lower_Result_StandardDeviation1_2.Text = PV.stringArray_Limit2[28];
                    tb_Upper_Result_StandardDeviation1_2.Text = PV.stringArray_Limit2[29];

                    // 카메라3
                    tb_Lower_Results_Item_0_Score_3.Text = PV.stringArray_Limit2[30];
                    tb_Lower_Results_GetBlobs_Count_3.Text = PV.stringArray_Limit2[31];
                    tb_Lower_Results_GetBlobs_Item_0_Area_3.Text = PV.stringArray_Limit2[32];
                    tb_Lower_Results_GetBlobs_Count1_3.Text = PV.stringArray_Limit2[33];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_3.Text = PV.stringArray_Limit2[34];
                    tb_Lower_Results_GetBlobs_Count2_3.Text = PV.stringArray_Limit2[35];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_3.Text = PV.stringArray_Limit2[36];
                    tb_Lower_Result_Mean_3.Text = PV.stringArray_Limit2[37];
                    tb_Upper_Result_Mean_3.Text = PV.stringArray_Limit2[38];
                    tb_Lower_Result_StandardDeviation_3.Text = PV.stringArray_Limit2[39];
                    tb_Upper_Result_StandardDeviation_3.Text = PV.stringArray_Limit2[40];
                    tb_Lower_Result_Mean1_3.Text = PV.stringArray_Limit2[41];
                    tb_Upper_Result_Mean1_3.Text = PV.stringArray_Limit2[42];
                    tb_Lower_Result_StandardDeviation1_3.Text = PV.stringArray_Limit2[43];
                    tb_Upper_Result_StandardDeviation1_3.Text = PV.stringArray_Limit2[44];

                    // 카메라4
                    tb_Lower_Results_Item_0_Score_4.Text = PV.stringArray_Limit2[45];
                    tb_Lower_Results_GetBlobs_Count_4.Text = PV.stringArray_Limit2[46];
                    tb_Lower_Results_GetBlobs_Item_0_Area_4.Text = PV.stringArray_Limit2[47];
                    tb_Lower_Results_GetBlobs_Count1_4.Text = PV.stringArray_Limit2[48];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_4.Text = PV.stringArray_Limit2[49];
                    tb_Lower_Results_GetBlobs_Count2_4.Text = PV.stringArray_Limit2[50];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_4.Text = PV.stringArray_Limit2[51];
                    tb_Lower_Result_Mean_4.Text = PV.stringArray_Limit2[52];
                    tb_Upper_Result_Mean_4.Text = PV.stringArray_Limit2[53];
                    tb_Lower_Result_StandardDeviation_4.Text = PV.stringArray_Limit2[54];
                    tb_Upper_Result_StandardDeviation_4.Text = PV.stringArray_Limit2[55];
                    tb_Lower_Result_Mean1_4.Text = PV.stringArray_Limit2[56];
                    tb_Upper_Result_Mean1_4.Text = PV.stringArray_Limit2[57];
                    tb_Lower_Result_StandardDeviation1_4.Text = PV.stringArray_Limit2[58];
                    tb_Upper_Result_StandardDeviation1_4.Text = PV.stringArray_Limit2[59];
                }
                else if (PV.nLModel == 3)
                {
                    // 카메라1
                    tb_Lower_Results_Item_0_Score_1.Text = PV.stringArray_Limit3[0];
                    tb_Lower_Results_GetBlobs_Count_1.Text = PV.stringArray_Limit3[1];
                    tb_Lower_Results_GetBlobs_Item_0_Area_1.Text = PV.stringArray_Limit3[2];
                    tb_Lower_Results_GetBlobs_Count1_1.Text = PV.stringArray_Limit3[3];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_1.Text = PV.stringArray_Limit3[4];
                    tb_Lower_Results_GetBlobs_Count2_1.Text = PV.stringArray_Limit3[5];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_1.Text = PV.stringArray_Limit3[6];
                    tb_Lower_Result_Mean_1.Text = PV.stringArray_Limit3[7];
                    tb_Upper_Result_Mean_1.Text = PV.stringArray_Limit3[8];
                    tb_Lower_Result_StandardDeviation_1.Text = PV.stringArray_Limit3[9];
                    tb_Upper_Result_StandardDeviation_1.Text = PV.stringArray_Limit3[10];
                    tb_Lower_Result_Mean1_1.Text = PV.stringArray_Limit3[11];
                    tb_Upper_Result_Mean1_1.Text = PV.stringArray_Limit3[12];
                    tb_Lower_Result_StandardDeviation1_1.Text = PV.stringArray_Limit3[13];
                    tb_Upper_Result_StandardDeviation1_1.Text = PV.stringArray_Limit3[14];

                    // 카메라 2
                    tb_Lower_Results_Item_0_Score_2.Text = PV.stringArray_Limit3[15];
                    tb_Lower_Results_GetBlobs_Count_2.Text = PV.stringArray_Limit3[16];
                    tb_Lower_Results_GetBlobs_Item_0_Area_2.Text = PV.stringArray_Limit3[17];
                    tb_Lower_Results_GetBlobs_Count1_2.Text = PV.stringArray_Limit3[18];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_2.Text = PV.stringArray_Limit3[19];
                    tb_Lower_Results_GetBlobs_Count2_2.Text = PV.stringArray_Limit3[20];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_2.Text = PV.stringArray_Limit3[21];
                    tb_Lower_Result_Mean_2.Text = PV.stringArray_Limit3[22];
                    tb_Upper_Result_Mean_2.Text = PV.stringArray_Limit3[23];
                    tb_Lower_Result_StandardDeviation_2.Text = PV.stringArray_Limit3[24];
                    tb_Upper_Result_StandardDeviation_2.Text = PV.stringArray_Limit3[25];
                    tb_Lower_Result_Mean1_2.Text = PV.stringArray_Limit3[26];
                    tb_Upper_Result_Mean1_2.Text = PV.stringArray_Limit3[27];
                    tb_Lower_Result_StandardDeviation1_2.Text = PV.stringArray_Limit3[28];
                    tb_Upper_Result_StandardDeviation1_2.Text = PV.stringArray_Limit3[29];

                    // 카메라3
                    tb_Lower_Results_Item_0_Score_3.Text = PV.stringArray_Limit3[30];
                    tb_Lower_Results_GetBlobs_Count_3.Text = PV.stringArray_Limit3[31];
                    tb_Lower_Results_GetBlobs_Item_0_Area_3.Text = PV.stringArray_Limit3[32];
                    tb_Lower_Results_GetBlobs_Count1_3.Text = PV.stringArray_Limit3[33];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_3.Text = PV.stringArray_Limit3[34];
                    tb_Lower_Results_GetBlobs_Count2_3.Text = PV.stringArray_Limit3[35];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_3.Text = PV.stringArray_Limit3[36];
                    tb_Lower_Result_Mean_3.Text = PV.stringArray_Limit3[37];
                    tb_Upper_Result_Mean_3.Text = PV.stringArray_Limit3[38];
                    tb_Lower_Result_StandardDeviation_3.Text = PV.stringArray_Limit3[39];
                    tb_Upper_Result_StandardDeviation_3.Text = PV.stringArray_Limit3[40];
                    tb_Lower_Result_Mean1_3.Text = PV.stringArray_Limit3[41];
                    tb_Upper_Result_Mean1_3.Text = PV.stringArray_Limit3[42];
                    tb_Lower_Result_StandardDeviation1_3.Text = PV.stringArray_Limit3[43];
                    tb_Upper_Result_StandardDeviation1_3.Text = PV.stringArray_Limit3[44];

                    // 카메라4
                    tb_Lower_Results_Item_0_Score_4.Text = PV.stringArray_Limit3[45];
                    tb_Lower_Results_GetBlobs_Count_4.Text = PV.stringArray_Limit3[46];
                    tb_Lower_Results_GetBlobs_Item_0_Area_4.Text = PV.stringArray_Limit3[47];
                    tb_Lower_Results_GetBlobs_Count1_4.Text = PV.stringArray_Limit3[48];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_4.Text = PV.stringArray_Limit3[49];
                    tb_Lower_Results_GetBlobs_Count2_4.Text = PV.stringArray_Limit3[50];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_4.Text = PV.stringArray_Limit3[51];
                    tb_Lower_Result_Mean_4.Text = PV.stringArray_Limit3[52];
                    tb_Upper_Result_Mean_4.Text = PV.stringArray_Limit3[53];
                    tb_Lower_Result_StandardDeviation_4.Text = PV.stringArray_Limit3[54];
                    tb_Upper_Result_StandardDeviation_4.Text = PV.stringArray_Limit3[55];
                    tb_Lower_Result_Mean1_4.Text = PV.stringArray_Limit3[56];
                    tb_Upper_Result_Mean1_4.Text = PV.stringArray_Limit3[57];
                    tb_Lower_Result_StandardDeviation1_4.Text = PV.stringArray_Limit3[58];
                    tb_Upper_Result_StandardDeviation1_4.Text = PV.stringArray_Limit3[59];
                }
                else if (PV.nLModel == 4)
                {
                    // 카메라1
                    tb_Lower_Results_Item_0_Score_1.Text = PV.stringArray_Limit4[0];
                    tb_Lower_Results_GetBlobs_Count_1.Text = PV.stringArray_Limit4[1];
                    tb_Lower_Results_GetBlobs_Item_0_Area_1.Text = PV.stringArray_Limit4[2];
                    tb_Lower_Results_GetBlobs_Count1_1.Text = PV.stringArray_Limit4[3];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_1.Text = PV.stringArray_Limit4[4];
                    tb_Lower_Results_GetBlobs_Count2_1.Text = PV.stringArray_Limit4[5];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_1.Text = PV.stringArray_Limit4[6];
                    tb_Lower_Result_Mean_1.Text = PV.stringArray_Limit4[7];
                    tb_Upper_Result_Mean_1.Text = PV.stringArray_Limit4[8];
                    tb_Lower_Result_StandardDeviation_1.Text = PV.stringArray_Limit4[9];
                    tb_Upper_Result_StandardDeviation_1.Text = PV.stringArray_Limit4[10];
                    tb_Lower_Result_Mean1_1.Text = PV.stringArray_Limit4[11];
                    tb_Upper_Result_Mean1_1.Text = PV.stringArray_Limit4[12];
                    tb_Lower_Result_StandardDeviation1_1.Text = PV.stringArray_Limit4[13];
                    tb_Upper_Result_StandardDeviation1_1.Text = PV.stringArray_Limit4[14];

                    // 카메라 2
                    tb_Lower_Results_Item_0_Score_2.Text = PV.stringArray_Limit4[15];
                    tb_Lower_Results_GetBlobs_Count_2.Text = PV.stringArray_Limit4[16];
                    tb_Lower_Results_GetBlobs_Item_0_Area_2.Text = PV.stringArray_Limit4[17];
                    tb_Lower_Results_GetBlobs_Count1_2.Text = PV.stringArray_Limit4[18];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_2.Text = PV.stringArray_Limit4[19];
                    tb_Lower_Results_GetBlobs_Count2_2.Text = PV.stringArray_Limit4[20];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_2.Text = PV.stringArray_Limit4[21];
                    tb_Lower_Result_Mean_2.Text = PV.stringArray_Limit4[22];
                    tb_Upper_Result_Mean_2.Text = PV.stringArray_Limit4[23];
                    tb_Lower_Result_StandardDeviation_2.Text = PV.stringArray_Limit4[24];
                    tb_Upper_Result_StandardDeviation_2.Text = PV.stringArray_Limit4[25];
                    tb_Lower_Result_Mean1_2.Text = PV.stringArray_Limit4[26];
                    tb_Upper_Result_Mean1_2.Text = PV.stringArray_Limit4[27];
                    tb_Lower_Result_StandardDeviation1_2.Text = PV.stringArray_Limit4[28];
                    tb_Upper_Result_StandardDeviation1_2.Text = PV.stringArray_Limit4[29];

                    // 카메라3
                    tb_Lower_Results_Item_0_Score_3.Text = PV.stringArray_Limit4[30];
                    tb_Lower_Results_GetBlobs_Count_3.Text = PV.stringArray_Limit4[31];
                    tb_Lower_Results_GetBlobs_Item_0_Area_3.Text = PV.stringArray_Limit4[32];
                    tb_Lower_Results_GetBlobs_Count1_3.Text = PV.stringArray_Limit4[33];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_3.Text = PV.stringArray_Limit4[34];
                    tb_Lower_Results_GetBlobs_Count2_3.Text = PV.stringArray_Limit4[35];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_3.Text = PV.stringArray_Limit4[36];
                    tb_Lower_Result_Mean_3.Text = PV.stringArray_Limit4[37];
                    tb_Upper_Result_Mean_3.Text = PV.stringArray_Limit4[38];
                    tb_Lower_Result_StandardDeviation_3.Text = PV.stringArray_Limit4[39];
                    tb_Upper_Result_StandardDeviation_3.Text = PV.stringArray_Limit4[40];
                    tb_Lower_Result_Mean1_3.Text = PV.stringArray_Limit4[41];
                    tb_Upper_Result_Mean1_3.Text = PV.stringArray_Limit4[42];
                    tb_Lower_Result_StandardDeviation1_3.Text = PV.stringArray_Limit4[43];
                    tb_Upper_Result_StandardDeviation1_3.Text = PV.stringArray_Limit4[44];

                    // 카메라4
                    tb_Lower_Results_Item_0_Score_4.Text = PV.stringArray_Limit4[45];
                    tb_Lower_Results_GetBlobs_Count_4.Text = PV.stringArray_Limit4[46];
                    tb_Lower_Results_GetBlobs_Item_0_Area_4.Text = PV.stringArray_Limit4[47];
                    tb_Lower_Results_GetBlobs_Count1_4.Text = PV.stringArray_Limit4[48];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_4.Text = PV.stringArray_Limit4[49];
                    tb_Lower_Results_GetBlobs_Count2_4.Text = PV.stringArray_Limit4[50];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_4.Text = PV.stringArray_Limit4[51];
                    tb_Lower_Result_Mean_4.Text = PV.stringArray_Limit4[52];
                    tb_Upper_Result_Mean_4.Text = PV.stringArray_Limit4[53];
                    tb_Lower_Result_StandardDeviation_4.Text = PV.stringArray_Limit4[54];
                    tb_Upper_Result_StandardDeviation_4.Text = PV.stringArray_Limit4[55];
                    tb_Lower_Result_Mean1_4.Text = PV.stringArray_Limit4[56];
                    tb_Upper_Result_Mean1_4.Text = PV.stringArray_Limit4[57];
                    tb_Lower_Result_StandardDeviation1_4.Text = PV.stringArray_Limit4[58];
                    tb_Upper_Result_StandardDeviation1_4.Text = PV.stringArray_Limit4[59];
                }
                else if (PV.nLModel == 5)
                {
                    // 카메라1
                    tb_Lower_Results_Item_0_Score_1.Text = PV.stringArray_Limit5[0];
                    tb_Lower_Results_GetBlobs_Count_1.Text = PV.stringArray_Limit5[1];
                    tb_Lower_Results_GetBlobs_Item_0_Area_1.Text = PV.stringArray_Limit5[2];
                    tb_Lower_Results_GetBlobs_Count1_1.Text = PV.stringArray_Limit5[3];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_1.Text = PV.stringArray_Limit5[4];
                    tb_Lower_Results_GetBlobs_Count2_1.Text = PV.stringArray_Limit5[5];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_1.Text = PV.stringArray_Limit5[6];
                    tb_Lower_Result_Mean_1.Text = PV.stringArray_Limit5[7];
                    tb_Upper_Result_Mean_1.Text = PV.stringArray_Limit5[8];
                    tb_Lower_Result_StandardDeviation_1.Text = PV.stringArray_Limit5[9];
                    tb_Upper_Result_StandardDeviation_1.Text = PV.stringArray_Limit5[10];
                    tb_Lower_Result_Mean1_1.Text = PV.stringArray_Limit5[11];
                    tb_Upper_Result_Mean1_1.Text = PV.stringArray_Limit5[12];
                    tb_Lower_Result_StandardDeviation1_1.Text = PV.stringArray_Limit5[13];
                    tb_Upper_Result_StandardDeviation1_1.Text = PV.stringArray_Limit5[14];

                    // 카메라 2
                    tb_Lower_Results_Item_0_Score_2.Text = PV.stringArray_Limit5[15];
                    tb_Lower_Results_GetBlobs_Count_2.Text = PV.stringArray_Limit5[16];
                    tb_Lower_Results_GetBlobs_Item_0_Area_2.Text = PV.stringArray_Limit5[17];
                    tb_Lower_Results_GetBlobs_Count1_2.Text = PV.stringArray_Limit5[18];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_2.Text = PV.stringArray_Limit5[19];
                    tb_Lower_Results_GetBlobs_Count2_2.Text = PV.stringArray_Limit5[20];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_2.Text = PV.stringArray_Limit5[21];
                    tb_Lower_Result_Mean_2.Text = PV.stringArray_Limit5[22];
                    tb_Upper_Result_Mean_2.Text = PV.stringArray_Limit5[23];
                    tb_Lower_Result_StandardDeviation_2.Text = PV.stringArray_Limit5[24];
                    tb_Upper_Result_StandardDeviation_2.Text = PV.stringArray_Limit5[25];
                    tb_Lower_Result_Mean1_2.Text = PV.stringArray_Limit5[26];
                    tb_Upper_Result_Mean1_2.Text = PV.stringArray_Limit5[27];
                    tb_Lower_Result_StandardDeviation1_2.Text = PV.stringArray_Limit5[28];
                    tb_Upper_Result_StandardDeviation1_2.Text = PV.stringArray_Limit5[29];

                    // 카메라3
                    tb_Lower_Results_Item_0_Score_3.Text = PV.stringArray_Limit5[30];
                    tb_Lower_Results_GetBlobs_Count_3.Text = PV.stringArray_Limit5[31];
                    tb_Lower_Results_GetBlobs_Item_0_Area_3.Text = PV.stringArray_Limit5[32];
                    tb_Lower_Results_GetBlobs_Count1_3.Text = PV.stringArray_Limit5[33];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_3.Text = PV.stringArray_Limit5[34];
                    tb_Lower_Results_GetBlobs_Count2_3.Text = PV.stringArray_Limit5[35];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_3.Text = PV.stringArray_Limit5[36];
                    tb_Lower_Result_Mean_3.Text = PV.stringArray_Limit5[37];
                    tb_Upper_Result_Mean_3.Text = PV.stringArray_Limit5[38];
                    tb_Lower_Result_StandardDeviation_3.Text = PV.stringArray_Limit5[39];
                    tb_Upper_Result_StandardDeviation_3.Text = PV.stringArray_Limit5[40];
                    tb_Lower_Result_Mean1_3.Text = PV.stringArray_Limit5[41];
                    tb_Upper_Result_Mean1_3.Text = PV.stringArray_Limit5[42];
                    tb_Lower_Result_StandardDeviation1_3.Text = PV.stringArray_Limit5[43];
                    tb_Upper_Result_StandardDeviation1_3.Text = PV.stringArray_Limit5[44];

                    // 카메라4
                    tb_Lower_Results_Item_0_Score_4.Text = PV.stringArray_Limit5[45];
                    tb_Lower_Results_GetBlobs_Count_4.Text = PV.stringArray_Limit5[46];
                    tb_Lower_Results_GetBlobs_Item_0_Area_4.Text = PV.stringArray_Limit5[47];
                    tb_Lower_Results_GetBlobs_Count1_4.Text = PV.stringArray_Limit5[48];
                    tb_Lower_Results_GetBlobs_Item_0_Area1_4.Text = PV.stringArray_Limit5[49];
                    tb_Lower_Results_GetBlobs_Count2_4.Text = PV.stringArray_Limit5[50];
                    tb_Lower_Results_GetBlobs_Item_0_Area2_4.Text = PV.stringArray_Limit5[51];
                    tb_Lower_Result_Mean_4.Text = PV.stringArray_Limit5[52];
                    tb_Upper_Result_Mean_4.Text = PV.stringArray_Limit5[53];
                    tb_Lower_Result_StandardDeviation_4.Text = PV.stringArray_Limit5[54];
                    tb_Upper_Result_StandardDeviation_4.Text = PV.stringArray_Limit5[55];
                    tb_Lower_Result_Mean1_4.Text = PV.stringArray_Limit5[56];
                    tb_Upper_Result_Mean1_4.Text = PV.stringArray_Limit5[57];
                    tb_Lower_Result_StandardDeviation1_4.Text = PV.stringArray_Limit5[58];
                    tb_Upper_Result_StandardDeviation1_4.Text = PV.stringArray_Limit5[59];
                }
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("LoadDataGrid", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }
        private void btn_BackToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_SaveModel_Click(object sender, EventArgs e)
        {

            if ((tb_Lower_Results_Item_0_Score_1.Text != "") && (tb_Lower_Results_GetBlobs_Count_1.Text != "") && (tb_Lower_Results_GetBlobs_Item_0_Area_1.Text != "") && (tb_Lower_Results_GetBlobs_Item_0_Area1_1.Text != ""))
            {


                // Limit
                StreamWriter sw1;
                string FileName1 = PV.DataPath + @"LimitList.txt";
                sw1 = new StreamWriter(FileName1, true, Encoding.Default);
                sw1.WriteLine(tb_Lower_Results_Item_0_Score_1.Text + "," + tb_Lower_Results_GetBlobs_Count_1.Text);
                sw1.Close();

                // Offset
                StreamWriter sw2;
                string FileName2 = PV.DataPath + @"OffsetList.txt";
                sw2 = new StreamWriter(FileName2, true, Encoding.Default);
                sw2.WriteLine(tb_Lower_Results_GetBlobs_Item_0_Area_1.Text);
                sw2.Close();

                // Score
                StreamWriter sw3;
                string FileName3 = PV.DataPath + @"ScoreList.txt";
                sw3 = new StreamWriter(FileName3, true, Encoding.Default);
                sw3.WriteLine(tb_Lower_Results_GetBlobs_Item_0_Area1_1.Text);
                sw3.Close();

                // AngleScore
                StreamWriter sw4;
                string FileName4 = PV.DataPath + @"ScoreList1.txt";
                sw4 = new StreamWriter(FileName4, true, Encoding.Default);
                sw4.WriteLine(tb_Lower_Results_GetBlobs_Count1_1.Text);
                sw4.Close();

                PF.ReadModelData();
            }
            else
            {
                MessageBox.Show("정확히 입력하세요");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(PV.nLModel == 1)
            {
                string FileName_Limit = PV.DataPath + @"\LimitList1.txt";
                StreamWriter sw1;
                sw1 = new StreamWriter(FileName_Limit, false, Encoding.Default);
                sw1.WriteLine(tb_Lower_Results_Item_0_Score_1.Text + ";" + tb_Lower_Results_GetBlobs_Count_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_1.Text + ";" + tb_Lower_Results_GetBlobs_Count1_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_1.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_1.Text + ";" + tb_Lower_Result_Mean_1.Text + ";" + tb_Upper_Result_Mean_1.Text + ";" + tb_Lower_Result_StandardDeviation_1.Text + ";" + tb_Upper_Result_StandardDeviation_1.Text
                    + ";" + tb_Lower_Result_Mean1_1.Text + ";" + tb_Upper_Result_Mean1_1.Text + ";" + tb_Lower_Result_StandardDeviation1_1.Text + ";" + tb_Upper_Result_StandardDeviation1_1.Text
                    
                    +"\r\n" + tb_Lower_Results_Item_0_Score_2.Text + ";" + tb_Lower_Results_GetBlobs_Count_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_2.Text + ";" + tb_Lower_Results_GetBlobs_Count1_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_2.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_2.Text + ";" + tb_Lower_Result_Mean_2.Text + ";" + tb_Upper_Result_Mean_2.Text + ";" + tb_Lower_Result_StandardDeviation_2.Text + ";" + tb_Upper_Result_StandardDeviation_2.Text
                    + ";" + tb_Lower_Result_Mean1_2.Text + ";" + tb_Upper_Result_Mean1_2.Text + ";" + tb_Lower_Result_StandardDeviation1_2.Text + ";" + tb_Upper_Result_StandardDeviation1_2.Text
                    
                    + "\r\n" + tb_Lower_Results_Item_0_Score_3.Text + ";" + tb_Lower_Results_GetBlobs_Count_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_3.Text + ";" + tb_Lower_Results_GetBlobs_Count1_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_3.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_3.Text + ";" + tb_Lower_Result_Mean_3.Text + ";" + tb_Upper_Result_Mean_3.Text + ";" + tb_Lower_Result_StandardDeviation_3.Text + ";" + tb_Upper_Result_StandardDeviation_3.Text
                    + ";" + tb_Lower_Result_Mean1_3.Text + ";" + tb_Upper_Result_Mean1_3.Text + ";" + tb_Lower_Result_StandardDeviation1_3.Text + ";" + tb_Upper_Result_StandardDeviation1_3.Text
                    
                    + "\r\n" + tb_Lower_Results_Item_0_Score_4.Text + ";" + tb_Lower_Results_GetBlobs_Count_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_4.Text + ";" + tb_Lower_Results_GetBlobs_Count1_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_4.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_4.Text + ";" + tb_Lower_Result_Mean_4.Text + ";" + tb_Upper_Result_Mean_4.Text + ";" + tb_Lower_Result_StandardDeviation_4.Text + ";" + tb_Upper_Result_StandardDeviation_4.Text
                    + ";" + tb_Lower_Result_Mean1_4.Text + ";" + tb_Upper_Result_Mean1_4.Text + ";" + tb_Lower_Result_StandardDeviation1_4.Text + ";" + tb_Upper_Result_StandardDeviation1_4.Text

                    ) ;
                sw1.Close();
                PF.ReadModelData();
                PF.DataLog(1);
            }
            else if (PV.nLModel == 2)
            {
                string FileName_Limit = PV.DataPath + @"\LimitList2.txt";
                StreamWriter sw1;
                sw1 = new StreamWriter(FileName_Limit, false, Encoding.Default);
                sw1.WriteLine(tb_Lower_Results_Item_0_Score_1.Text + ";" + tb_Lower_Results_GetBlobs_Count_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_1.Text + ";" + tb_Lower_Results_GetBlobs_Count1_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_1.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_1.Text + ";" + tb_Lower_Result_Mean_1.Text + ";" + tb_Upper_Result_Mean_1.Text + ";" + tb_Lower_Result_StandardDeviation_1.Text + ";" + tb_Upper_Result_StandardDeviation_1.Text
                    + ";" + tb_Lower_Result_Mean1_1.Text + ";" + tb_Upper_Result_Mean1_1.Text + ";" + tb_Lower_Result_StandardDeviation1_1.Text + ";" + tb_Upper_Result_StandardDeviation1_1.Text

                    + "\r\n" + tb_Lower_Results_Item_0_Score_2.Text + ";" + tb_Lower_Results_GetBlobs_Count_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_2.Text + ";" + tb_Lower_Results_GetBlobs_Count1_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_2.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_2.Text + ";" + tb_Lower_Result_Mean_2.Text + ";" + tb_Upper_Result_Mean_2.Text + ";" + tb_Lower_Result_StandardDeviation_2.Text + ";" + tb_Upper_Result_StandardDeviation_2.Text
                    + ";" + tb_Lower_Result_Mean1_2.Text + ";" + tb_Upper_Result_Mean1_2.Text + ";" + tb_Lower_Result_StandardDeviation1_2.Text + ";" + tb_Upper_Result_StandardDeviation1_2.Text

                    + "\r\n" + tb_Lower_Results_Item_0_Score_3.Text + ";" + tb_Lower_Results_GetBlobs_Count_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_3.Text + ";" + tb_Lower_Results_GetBlobs_Count1_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_3.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_3.Text + ";" + tb_Lower_Result_Mean_3.Text + ";" + tb_Upper_Result_Mean_3.Text + ";" + tb_Lower_Result_StandardDeviation_3.Text + ";" + tb_Upper_Result_StandardDeviation_3.Text
                    + ";" + tb_Lower_Result_Mean1_3.Text + ";" + tb_Upper_Result_Mean1_3.Text + ";" + tb_Lower_Result_StandardDeviation1_3.Text + ";" + tb_Upper_Result_StandardDeviation1_3.Text

                    + "\r\n" + tb_Lower_Results_Item_0_Score_4.Text + ";" + tb_Lower_Results_GetBlobs_Count_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_4.Text + ";" + tb_Lower_Results_GetBlobs_Count1_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_4.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_4.Text + ";" + tb_Lower_Result_Mean_4.Text + ";" + tb_Upper_Result_Mean_4.Text + ";" + tb_Lower_Result_StandardDeviation_4.Text + ";" + tb_Upper_Result_StandardDeviation_4.Text
                    + ";" + tb_Lower_Result_Mean1_4.Text + ";" + tb_Upper_Result_Mean1_4.Text + ";" + tb_Lower_Result_StandardDeviation1_4.Text + ";" + tb_Upper_Result_StandardDeviation1_4.Text

                    );
                sw1.Close();
                PF.ReadModelData();
                PF.DataLog(2);
            }
            else if (PV.nLModel == 3)
            {
                string FileName_Limit = PV.DataPath + @"\LimitList3.txt";
                StreamWriter sw1;
                sw1 = new StreamWriter(FileName_Limit, false, Encoding.Default);
                sw1.WriteLine(tb_Lower_Results_Item_0_Score_1.Text + ";" + tb_Lower_Results_GetBlobs_Count_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_1.Text + ";" + tb_Lower_Results_GetBlobs_Count1_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_1.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_1.Text + ";" + tb_Lower_Result_Mean_1.Text + ";" + tb_Upper_Result_Mean_1.Text + ";" + tb_Lower_Result_StandardDeviation_1.Text + ";" + tb_Upper_Result_StandardDeviation_1.Text
                    + ";" + tb_Lower_Result_Mean1_1.Text + ";" + tb_Upper_Result_Mean1_1.Text + ";" + tb_Lower_Result_StandardDeviation1_1.Text + ";" + tb_Upper_Result_StandardDeviation1_1.Text

                    + "\r\n" + tb_Lower_Results_Item_0_Score_2.Text + ";" + tb_Lower_Results_GetBlobs_Count_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_2.Text + ";" + tb_Lower_Results_GetBlobs_Count1_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_2.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_2.Text + ";" + tb_Lower_Result_Mean_2.Text + ";" + tb_Upper_Result_Mean_2.Text + ";" + tb_Lower_Result_StandardDeviation_2.Text + ";" + tb_Upper_Result_StandardDeviation_2.Text
                    + ";" + tb_Lower_Result_Mean1_2.Text + ";" + tb_Upper_Result_Mean1_2.Text + ";" + tb_Lower_Result_StandardDeviation1_2.Text + ";" + tb_Upper_Result_StandardDeviation1_2.Text

                    + "\r\n" + tb_Lower_Results_Item_0_Score_3.Text + ";" + tb_Lower_Results_GetBlobs_Count_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_3.Text + ";" + tb_Lower_Results_GetBlobs_Count1_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_3.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_3.Text + ";" + tb_Lower_Result_Mean_3.Text + ";" + tb_Upper_Result_Mean_3.Text + ";" + tb_Lower_Result_StandardDeviation_3.Text + ";" + tb_Upper_Result_StandardDeviation_3.Text
                    + ";" + tb_Lower_Result_Mean1_3.Text + ";" + tb_Upper_Result_Mean1_3.Text + ";" + tb_Lower_Result_StandardDeviation1_3.Text + ";" + tb_Upper_Result_StandardDeviation1_3.Text

                    + "\r\n" + tb_Lower_Results_Item_0_Score_4.Text + ";" + tb_Lower_Results_GetBlobs_Count_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_4.Text + ";" + tb_Lower_Results_GetBlobs_Count1_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_4.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_4.Text + ";" + tb_Lower_Result_Mean_4.Text + ";" + tb_Upper_Result_Mean_4.Text + ";" + tb_Lower_Result_StandardDeviation_4.Text + ";" + tb_Upper_Result_StandardDeviation_4.Text
                    + ";" + tb_Lower_Result_Mean1_4.Text + ";" + tb_Upper_Result_Mean1_4.Text + ";" + tb_Lower_Result_StandardDeviation1_4.Text + ";" + tb_Upper_Result_StandardDeviation1_4.Text

                    );
                sw1.Close();
                PF.ReadModelData();
                PF.DataLog(3);
            }
            else if (PV.nLModel == 4)
            {
                string FileName_Limit = PV.DataPath + @"\LimitList4.txt";
                StreamWriter sw1;
                sw1 = new StreamWriter(FileName_Limit, false, Encoding.Default);
                sw1.WriteLine(tb_Lower_Results_Item_0_Score_1.Text + ";" + tb_Lower_Results_GetBlobs_Count_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_1.Text + ";" + tb_Lower_Results_GetBlobs_Count1_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_1.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_1.Text + ";" + tb_Lower_Result_Mean_1.Text + ";" + tb_Upper_Result_Mean_1.Text + ";" + tb_Lower_Result_StandardDeviation_1.Text + ";" + tb_Upper_Result_StandardDeviation_1.Text
                    + ";" + tb_Lower_Result_Mean1_1.Text + ";" + tb_Upper_Result_Mean1_1.Text + ";" + tb_Lower_Result_StandardDeviation1_1.Text + ";" + tb_Upper_Result_StandardDeviation1_1.Text

                    + "\r\n" + tb_Lower_Results_Item_0_Score_2.Text + ";" + tb_Lower_Results_GetBlobs_Count_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_2.Text + ";" + tb_Lower_Results_GetBlobs_Count1_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_2.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_2.Text + ";" + tb_Lower_Result_Mean_2.Text + ";" + tb_Upper_Result_Mean_2.Text + ";" + tb_Lower_Result_StandardDeviation_2.Text + ";" + tb_Upper_Result_StandardDeviation_2.Text
                    + ";" + tb_Lower_Result_Mean1_2.Text + ";" + tb_Upper_Result_Mean1_2.Text + ";" + tb_Lower_Result_StandardDeviation1_2.Text + ";" + tb_Upper_Result_StandardDeviation1_2.Text

                    + "\r\n" + tb_Lower_Results_Item_0_Score_3.Text + ";" + tb_Lower_Results_GetBlobs_Count_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_3.Text + ";" + tb_Lower_Results_GetBlobs_Count1_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_3.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_3.Text + ";" + tb_Lower_Result_Mean_3.Text + ";" + tb_Upper_Result_Mean_3.Text + ";" + tb_Lower_Result_StandardDeviation_3.Text + ";" + tb_Upper_Result_StandardDeviation_3.Text
                    + ";" + tb_Lower_Result_Mean1_3.Text + ";" + tb_Upper_Result_Mean1_3.Text + ";" + tb_Lower_Result_StandardDeviation1_3.Text + ";" + tb_Upper_Result_StandardDeviation1_3.Text

                    + "\r\n" + tb_Lower_Results_Item_0_Score_4.Text + ";" + tb_Lower_Results_GetBlobs_Count_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_4.Text + ";" + tb_Lower_Results_GetBlobs_Count1_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_4.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_4.Text + ";" + tb_Lower_Result_Mean_4.Text + ";" + tb_Upper_Result_Mean_4.Text + ";" + tb_Lower_Result_StandardDeviation_4.Text + ";" + tb_Upper_Result_StandardDeviation_4.Text
                    + ";" + tb_Lower_Result_Mean1_4.Text + ";" + tb_Upper_Result_Mean1_4.Text + ";" + tb_Lower_Result_StandardDeviation1_4.Text + ";" + tb_Upper_Result_StandardDeviation1_4.Text

                    );
                sw1.Close();
                PF.ReadModelData();
                PF.DataLog(4);
            }
            else if (PV.nLModel == 5)
            {
                string FileName_Limit = PV.DataPath + @"\LimitList5.txt";
                StreamWriter sw1;
                sw1 = new StreamWriter(FileName_Limit, false, Encoding.Default);
                sw1.WriteLine(tb_Lower_Results_Item_0_Score_1.Text + ";" + tb_Lower_Results_GetBlobs_Count_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_1.Text + ";" + tb_Lower_Results_GetBlobs_Count1_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_1.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_1.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_1.Text + ";" + tb_Lower_Result_Mean_1.Text + ";" + tb_Upper_Result_Mean_1.Text + ";" + tb_Lower_Result_StandardDeviation_1.Text + ";" + tb_Upper_Result_StandardDeviation_1.Text
                    + ";" + tb_Lower_Result_Mean1_1.Text + ";" + tb_Upper_Result_Mean1_1.Text + ";" + tb_Lower_Result_StandardDeviation1_1.Text + ";" + tb_Upper_Result_StandardDeviation1_1.Text

                    + "\r\n" + tb_Lower_Results_Item_0_Score_2.Text + ";" + tb_Lower_Results_GetBlobs_Count_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_2.Text + ";" + tb_Lower_Results_GetBlobs_Count1_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_2.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_2.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_2.Text + ";" + tb_Lower_Result_Mean_2.Text + ";" + tb_Upper_Result_Mean_2.Text + ";" + tb_Lower_Result_StandardDeviation_2.Text + ";" + tb_Upper_Result_StandardDeviation_2.Text
                    + ";" + tb_Lower_Result_Mean1_2.Text + ";" + tb_Upper_Result_Mean1_2.Text + ";" + tb_Lower_Result_StandardDeviation1_2.Text + ";" + tb_Upper_Result_StandardDeviation1_2.Text

                    + "\r\n" + tb_Lower_Results_Item_0_Score_3.Text + ";" + tb_Lower_Results_GetBlobs_Count_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_3.Text + ";" + tb_Lower_Results_GetBlobs_Count1_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_3.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_3.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_3.Text + ";" + tb_Lower_Result_Mean_3.Text + ";" + tb_Upper_Result_Mean_3.Text + ";" + tb_Lower_Result_StandardDeviation_3.Text + ";" + tb_Upper_Result_StandardDeviation_3.Text
                    + ";" + tb_Lower_Result_Mean1_3.Text + ";" + tb_Upper_Result_Mean1_3.Text + ";" + tb_Lower_Result_StandardDeviation1_3.Text + ";" + tb_Upper_Result_StandardDeviation1_3.Text

                    + "\r\n" + tb_Lower_Results_Item_0_Score_4.Text + ";" + tb_Lower_Results_GetBlobs_Count_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area_4.Text + ";" + tb_Lower_Results_GetBlobs_Count1_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area1_4.Text
                    + ";" + tb_Lower_Results_GetBlobs_Count2_4.Text + ";" + tb_Lower_Results_GetBlobs_Item_0_Area2_4.Text + ";" + tb_Lower_Result_Mean_4.Text + ";" + tb_Upper_Result_Mean_4.Text + ";" + tb_Lower_Result_StandardDeviation_4.Text + ";" + tb_Upper_Result_StandardDeviation_4.Text
                    + ";" + tb_Lower_Result_Mean1_4.Text + ";" + tb_Upper_Result_Mean1_4.Text + ";" + tb_Lower_Result_StandardDeviation1_4.Text + ";" + tb_Upper_Result_StandardDeviation1_4.Text

                    );
                sw1.Close();
                PF.ReadModelData();
                PF.DataLog(5);
            }





        }


        private void comboBox_Model_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Model.SelectedIndex == 0)
            {
                PV.nLModel = 1;
                LoadData();
            }
            else if (comboBox_Model.SelectedIndex == 1)
            {
                PV.nLModel = 2;
                LoadData();
            }
            else if (comboBox_Model.SelectedIndex == 2)
            {
                PV.nLModel = 3;
                LoadData();
            }
            else if (comboBox_Model.SelectedIndex == 3)
            {
                PV.nLModel = 4;
                LoadData();
            }
            else if (comboBox_Model.SelectedIndex == 4)
            {
                PV.nLModel = 5;
                LoadData();
            }
        }
    }
}
