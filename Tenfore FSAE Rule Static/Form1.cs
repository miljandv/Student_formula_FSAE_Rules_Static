using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tenfore_FSAE_Rule_Static
{
    public partial class ea_sp_osv_box : Form
    {
        private void button1_g(Object sender, System.EventArgs e)
        {
            try
            {
                if (dana_box.Text == string.Empty && sudije_box.Text == string.Empty && max_box.Text == string.Empty)
                {
                    osvojeni_box.Text = String.Empty;
                }
                double poeni = 0;
                if (int.Parse(dana_box.Text) >= 10)
                    osvojeni_box.Text = "0";
                else
                {
                    poeni = (75 * (double.Parse(sudije_box.Text) / double.Parse(max_box.Text))
                        - (int.Parse(dana_box.Text) < 5 ? int.Parse(dana_box.Text) * (10) : 50));
                    osvojeni_box.Text = (poeni).ToString();
                }
            } catch (Exception) { }

        }
        private void button2_g(Object sender, System.EventArgs e) {
            try
            {
                double poeni = 0;
                poeni = (double.Parse(osvojeni_box.Text) + (int.Parse(dana_box.Text) < 5 ? int.Parse(dana_box.Text) * (10) : 50)) * double.Parse(max_box.Text) / 75.0;
                sudije_box.Text = (poeni).ToString();

            } catch (Exception) { }
        }
        private void button3_g(Object sender, System.EventArgs e) {
            try
            {
                double poeni = 0;
                poeni = (double.Parse(osvojeni_box.Text) + (int.Parse(dana_box.Text) < 5 ? int.Parse(dana_box.Text) * (10) : 50)) * double.Parse(sudije_box.Text) / 75.0;
                max_box.Text = (poeni).ToString();

            }
            catch (Exception) { }
        }

        private void button4_g(Object sender, System.EventArgs e) {
            try
            {
                double dan = 0;
                dan = (75.0 * (double.Parse(sudije_box.Text) / double.Parse(max_box.Text)) - double.Parse(osvojeni_box.Text)) / 10;
                dana_box.Text = dan.ToString();

            }
            catch (Exception) { }
        }
        private void button5_g(Object sender, System.EventArgs e) {
            try
            {
                double kaz = 0;
                kaz = (75.0 * (double.Parse(sudije_box.Text) / double.Parse(max_box.Text)) - double.Parse(osvojeni_box.Text));
                kazna_box.Text = kaz.ToString();

            }
            catch (Exception) { }
        }
        public ea_sp_osv_box()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void FSEAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                double poeni = 0;
                poeni = 70 * double.Parse(PG_sudije_box.Text) / double.Parse(PG_max_box.Text);
                PG_osvojeni_box.Text = poeni.ToString();
            } catch { }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                double poeni = 0;
                poeni = double.Parse(PG_osvojeni_box.Text) * double.Parse(PG_max_box.Text) / 70.0;
                PG_sudije_box.Text = poeni.ToString();
            } catch { }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                double poeni = 0;
                poeni = 70 * double.Parse(PG_sudije_box.Text) / double.Parse(PG_osvojeni_box.Text);
                PG_max_box.Text = poeni.ToString();
            }
            catch { }

        }

        private void EfficiencyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button20_Click(object sender, EventArgs e)
        {
            try
            {
                int p = TypeA();
                pta.Text = p.ToString();

            } catch { }
        }

        int TypeA()
        {
            return int.Parse(mpf.Text) + 3 * int.Parse(part.Text) + 5 * int.Parse(assembly.Text);
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            int p = 0, a = 0, pen = 0, m = 0;
            m = int.Parse(mpf.Text);
            p = int.Parse(part.Text);
            pen = int.Parse(pta.Text);
            a = pen - 3 * p - m;
            a /= 5;
            assembly.Text = a.ToString();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            int p = 0, a = 0, pen = 0, m = 0;
            p = int.Parse(part.Text);
            a = int.Parse(assembly.Text);
            pen = int.Parse(pta.Text);
            m = pen - 3 * p - 5 * a;
            mpf.Text = m.ToString();
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            int p = 0, a = 0, pen = 0, m = 0;
            m = int.Parse(mpf.Text);
            a = int.Parse(assembly.Text);
            pen = int.Parse(pta.Text);
            p = pen - m - 5 * a;
            p /= 3;
            part.Text = p.ToString();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            int dan;
            double ta = 0, tb = 0, ret = 0;
            dan = int.Parse(EA_C_dana.Text);
            if (dan > 10) EA_C_osvojeni.Text = (-100).ToString();
            else
            {
                if (price.Text == string.Empty)
                {
                    ta = PriceScoreA() + double.Parse(DS.Text) + double.Parse(SS.Text) - (double.Parse(pta.Text) + DRPenalty());
                    if (ptb.Text != string.Empty)
                    {
                        tb = PriceScoreB() + double.Parse(DS.Text) + double.Parse(SS.Text) - (DRPenalty());
                        ret = ta < tb ? ta : tb;
                    }
                    else ret = ta;
                }
                else ret = double.Parse(price.Text) + +double.Parse(DS.Text) + double.Parse(SS.Text) - DRPenalty() - (ta < tb ? double.Parse(pta.Text) : 0);


                EA_C_osvojeni.Text = ret.ToString();
            }
        }

        double PriceScoreA()
        {
            double min, max, our;
            min = double.Parse(pmin.Text);
            max = double.Parse(pmax.Text);
            our = double.Parse(price.Text);
            return 40 * ((max / our) - 1) / ((max / min) - 1);

        }
        double PriceScoreB()
        {
            double min, max, our, bp;
            min = double.Parse(pmin.Text);
            max = double.Parse(pmax.Text);
            our = double.Parse(price.Text);
            bp = double.Parse(ptb.Text);
            return 40 * ((max / (our + bp)) - 1) / ((max / min) - 1);

        }

        double DRPenalty()
        {
            int dan;
            dan = int.Parse(EA_C_dana.Text);
            if (dan > 8) return 80;
            else return 10 * dan;
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            string s;
            s = "A = " + PriceScoreA();
            if (ptb.Text != string.Empty) s += " B = " + PriceScoreB();
            PS.Text = s;

        }

        private void Button17_Click(object sender, EventArgs e)
        {
            EA_C_Penalty.Text = DRPenalty().ToString();
        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {
            int p = 0, a = 0, pen = 0, m = 0;
            m = int.Parse(G_C_mpf.Text);
            p = int.Parse(G_C_part.Text);
            pen = int.Parse(G_C_Penalty.Text);
            a = pen - 3 * p - m;
            a /= 5;
            G_C_assembly.Text = a.ToString();
        }

        private void Label26_Click(object sender, EventArgs e)
        {

        }

        private void Button22_Click(object sender, EventArgs e)
        {
            double pen = 0;
            if (G_C_Penalty.Text != string.Empty) pen = double.Parse(G_C_Penalty.Text);
            G_C_osvojeni.Text = (95 * ((double.Parse(G_C_poeni.Text) - pen) / double.Parse(G_C_max.Text))).ToString();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            int p = 0, a = 0, pen = 0, m = 0;
            p = int.Parse(G_C_part.Text);
            a = int.Parse(G_C_assembly.Text);
            pen = int.Parse(G_C_Penalty.Text);
            m = pen - 3 * p - 5 * a;
            G_C_mpf.Text = m.ToString();
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            int p = 0, a = 0, pen = 0, m = 0;
            m = int.Parse(G_C_mpf.Text);
            a = int.Parse(G_C_assembly.Text);
            pen = int.Parse(G_C_Penalty.Text);
            p = pen - m - 5 * a;
            p /= 3;
            G_C_part.Text = p.ToString();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            int p = int.Parse(G_C_mpf.Text) + 3 * int.Parse(G_C_part.Text) + 5 * int.Parse(G_C_assembly.Text);
            p = p > 35 ? 35 : p;
            G_C_Penalty.Text = p.ToString();
        }

        private void Label34_Click(object sender, EventArgs e)
        {

        }

        private void Button21_Click(object sender, EventArgs e)
        {
            G_C_poeni.Text = (double.Parse(G_C_max.Text) * double.Parse(G_C_osvojeni.Text) / 95).ToString();
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            G_C_max.Text = (95 * (double.Parse(G_C_poeni.Text) / double.Parse(G_C_osvojeni.Text))).ToString();
        }
        void setpanelstounivisible()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel11.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel16.Visible = false;
        }
        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel2.Visible = true;
        }

        private void ToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel1.Visible = true;
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel3.Visible = true;
        }
        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel5.Visible = true;
        }
        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel13.Visible = true;
        }
        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel4.Visible = true;
        }
        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel6.Visible = true;
        }
        private void ToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel7.Visible = true;
        }
        private void ToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel8.Visible = true;
        }
        private void ToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel9.Visible = true;
        }
        private void Panel8_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel10.Visible = true;
        }
        private void ToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel11.Visible = true;
        }
        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel14.Visible = true;
        }
        private void EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setpanelstounivisible();
            panel16.Visible = true;
        }
        private void Ea_acc_max_box_TextChanged(object sender, EventArgs e)
        {
            if (ea_acc_min_box.Text != string.Empty)
                ea_acc_max_box.Text = (int.Parse(ea_acc_min_box.Text) * 1.5).ToString();
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            double min = 0;
            min = (((double.Parse(ea_acc_osv_box.Text) - 4.5) * 0.5 / 95.5) + 1) * double.Parse(ea_acc_corr_box.Text) / 1.5;
            ea_acc_min_box.Text = min.ToString();
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            if (ea_acc_cunj_box.Text == string.Empty)
            {
                ea_acc_corr_box.Text = (1.5 * double.Parse(ea_acc_min_box.Text) / (((double.Parse(ea_acc_osv_box.Text) - 4.5) * 0.5 / 95.5) + 1)).ToString();
            }
            else
            {
                ea_acc_corr_box.Text = (double.Parse(ea_acc_run_box.Text) + 2 * double.Parse(ea_acc_cunj_box.Text)).ToString();
            }
        }

        private void Button26_Click(object sender, EventArgs e)
        {
            ea_acc_run_box.Text = (double.Parse(ea_acc_corr_box.Text) - 2 * double.Parse(ea_acc_cunj_box.Text)).ToString();
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            ea_acc_cunj_box.Text = ((double.Parse(ea_acc_corr_box.Text) - double.Parse(ea_acc_run_box.Text)) / 2).ToString();

        }

        private void Button25_Click(object sender, EventArgs e)
        {
            double poeni = 0;
            poeni = 95.5 * (1.5 * double.Parse(ea_acc_min_box.Text) / double.Parse(ea_acc_corr_box.Text) - 1) / 0.5 + 4.5;
            poeni = poeni < 4.5 ? 4.5 : poeni;
            ea_acc_osv_box.Text = poeni.ToString();
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            ea_acc_max_box.Text = (1.5 * double.Parse(ea_acc_min_box.Text)).ToString();
        }

        private void Button32_Click(object sender, EventArgs e)
        {
            ea_sp_max_box.Text = (1.25 * double.Parse(ea_sp_min_box.Text)).ToString();
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            double min = 0;
            min = ((double.Parse(ea_sp_osvp_box.Text) - 3.5) * 0.5625 / 71.5 + 1) * 0.8 * double.Parse(ea_sp_corr_box.Text);
            ea_sp_min_box.Text = min.ToString();

        }

        private void Button30_Click(object sender, EventArgs e)
        {
            double our = 0;
            if (ea_sp_cunj_box.Text == string.Empty)
            {
                our = double.Parse(ea_sp_min_box.Text) / (((double.Parse(ea_sp_osvp_box.Text) - 3.5) * 0.5625 / 71.5 + 1) * 0.8);
            }
            else
            {
                our = (double.Parse(ea_sp_ll_box.Text) + double.Parse(ea_sp_rl_box.Text)) / 2 + (double.Parse(ea_sp_cunj_box.Text) * 0.125);
            }
            ea_sp_corr_box.Text = our.ToString();
        }

        private void Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button33_Click(object sender, EventArgs e)
        {
            double cunj = 0;
            cunj = (double.Parse(ea_sp_corr_box.Text) - (double.Parse(ea_sp_ll_box.Text) + double.Parse(ea_sp_rl_box.Text)) / 2) / 0.125;
            ea_sp_cunj_box.Text = cunj.ToString();
        }

        private void Button34_Click(object sender, EventArgs e)
        {
            double score = 0;
            score = 71.5 * (Math.Pow((double.Parse(ea_sp_min_box.Text) * 1.25 / double.Parse(ea_sp_corr_box.Text)), 2) - 1) / 0.5625 + 3.5;
            score = score < 3.5 ? 3.5 : score;
            ea_sp_osvp_box.Text = score.ToString();
        }

        private void Button38_Click(object sender, EventArgs e)
        {
            if (g_acc_team_box.Text == "" || g_acc_max_box.Text == "") return;
            g_acc_osvp_box.Text = (71.5 * (double.Parse(g_acc_max_box.Text) / double.Parse(g_acc_team_box.Text) - 1) / 0.5).ToString();
        }

        private void Button36_Click(object sender, EventArgs e)
        {
            if (g_acc_team_box.Text == "" || g_acc_osvp_box.Text == "") return;
            g_acc_max_box.Text = (((double.Parse(g_acc_osvp_box.Text) * 0.5) / 71.5 + 1) * double.Parse(g_acc_team_box.Text)).ToString();
        }

        private void Button31_Click(object sender, EventArgs e)
        {
            if (g_acc_max_box.Text == "" || g_acc_osvp_box.Text == "") return;
            g_acc_team_box.Text = (1 / (double.Parse(g_acc_osvp_box.Text) * 0.5 / 71.5 + 1) * double.Parse(g_acc_max_box.Text)).ToString();
        }

        private void Button39_Click(object sender, EventArgs e)
        {
            if (g_auto_team_box.Text == "" || g_auto_max_box.Text == "") return;
            g_auto_osvp_box.Text = (95.5 * (double.Parse(g_auto_max_box.Text) / double.Parse(g_auto_team_box.Text) - 1) / 0.25).ToString();
        }

        private void Button35_Click(object sender, EventArgs e)
        {
            if (g_auto_max_box.Text == "" || g_auto_osvp_box.Text == "") return;
            g_auto_team_box.Text = (1 / (double.Parse(g_auto_osvp_box.Text) * 0.25 / 95.5 + 1) * double.Parse(g_auto_max_box.Text)).ToString();
        }

        private void Button37_Click(object sender, EventArgs e)
        {
            if (g_auto_team_box.Text == "" || g_auto_osvp_box.Text == "") return;
            g_auto_max_box.Text = (((double.Parse(g_auto_osvp_box.Text) * 0.25) / 95.5 + 1) * double.Parse(g_auto_team_box.Text)).ToString();
        }

        private void PravilnikToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Button57_Click(object sender, EventArgs e)
        {
            if (ea_auto_min_box.Text == "" || ea_auto_team_box.Text == "") return;
            double sc = (118.5 * (((1.45 * double.Parse(ea_auto_min_box.Text)) / (double.Parse(ea_auto_team_box.Text)) - 1) / (0.45)) + 6.5);
            sc = sc < 6.5 ? 6.5 : sc;
            ea_auto_osv_box.Text = sc.ToString();
        }

        private void Button51_Click(object sender, EventArgs e)
        {
            if (ea_auto_cunj_box.Text == "")
            {
                if (ea_auto_cunj_box.Text == "" || ea_auto_oc_box.Text == "" || ea_auto_rt_box.Text == "") return;
                double sc = double.Parse(ea_auto_rt_box.Text) + 2 * double.Parse(ea_auto_cunj_box.Text) + 20 * double.Parse(ea_auto_oc_box.Text);
                ea_auto_team_box.Text = sc.ToString();
            }
            else {
                if (ea_auto_min_box.Text == "") return;
                double sc = double.Parse(ea_auto_min_box.Text) / ((double.Parse(ea_auto_osv_box.Text) - 6.5) * 0.45 / (118.5) + 1) * 0.6896;
                ea_auto_team_box.Text = sc.ToString();
            }
        }

        private void Button55_Click(object sender, EventArgs e)
        {
            if (ea_auto_team_box.Text == "" || ea_auto_oc_box.Text == "" || ea_auto_rt_box.Text == "") return;
            double sc = (double.Parse(ea_auto_team_box.Text) - 20 * double.Parse(ea_auto_oc_box.Text) - double.Parse(ea_auto_rt_box.Text)) / 2;
            ea_auto_cunj_box.Text = sc.ToString();
        }

        private void Button49_Click(object sender, EventArgs e)
        {
            ea_auto_max_box.Text = (1.45 * double.Parse(ea_auto_min_box.Text)).ToString();
        }

        private void Button50_Click(object sender, EventArgs e)
        {
            if (ea_auto_team_box.Text == "" || ea_auto_osv_box.Text == "") return;
            double sc = double.Parse(ea_auto_team_box.Text) * ((double.Parse(ea_auto_osv_box.Text) - 6.5) * 0.45 / (118.5) + 1) * 0.6896;
            ea_auto_min_box.Text = sc.ToString();
        }

        private void Button56_Click(object sender, EventArgs e)
        {
            if (ea_auto_team_box.Text == "" || ea_auto_cunj_box.Text == "" || ea_auto_rt_box.Text == "") return;
            double sc = (double.Parse(ea_auto_team_box.Text) - 2 * double.Parse(ea_auto_cunj_box.Text) - double.Parse(ea_auto_rt_box.Text)) / 20;
            ea_auto_oc_box.Text = sc.ToString();
        }

        private void Button58_Click(object sender, EventArgs e)
        {
            if (ea_auto_team_box.Text == "" || ea_auto_cunj_box.Text == "" || ea_auto_oc_box.Text == "") return;
            double sc = (double.Parse(ea_auto_team_box.Text) - 2 * double.Parse(ea_auto_cunj_box.Text) - 20 * double.Parse(ea_auto_oc_box.Text));
            ea_auto_rt_box.Text = sc.ToString();
        }

        private void Button65_Click(object sender, EventArgs e)
        {
            if (dnf_check.Checked == true)
            {
                if (ea_end_laps_box.Text == "" || ea_end_ppl_box.Text == "") return;
                double sc = (double.Parse(ea_end_ppl_box.Text) * double.Parse(ea_end_laps_box.Text));
                ea_end_osv_box.Text = sc.ToString();
            }
            else
            {
                if (ea_end_laps_box.Text == "" || ea_end_ppl_box.Text == "") return;
                double sc = (250 * (((1.45 * double.Parse(ea_end_min_box.Text)) / (double.Parse(ea_end_team_box.Text)) - 1) / (0.45)) + 25);
                sc = sc < 25 ? 25 : sc;
                ea_end_osv_box.Text = sc.ToString();
            }
        }

        private void Button60_Click(object sender, EventArgs e)
        {
            ea_end_max_box.Text = (double.Parse(ea_end_min_box.Text) * 1.45).ToString();
        }

        private void Button64_Click(object sender, EventArgs e)
        {
            if (ea_end_team_box.Text == "" || ea_end_oc_box.Text == "" || ea_end_rt_box.Text == "") return;
            double sc = (double.Parse(ea_end_team_box.Text) - 20 * double.Parse(ea_end_oc_box.Text) - double.Parse(ea_end_rt_box.Text)) / 2;
            ea_end_cunj_box.Text = sc.ToString();
        }

        private void Button59_Click(object sender, EventArgs e)
        {
            if (ea_end_team_box.Text == "" || ea_end_osv_box.Text == "") return;
            double sc = double.Parse(ea_end_team_box.Text) * ((double.Parse(ea_end_osv_box.Text) - 25) * 0.45 / (250) + 1) * 0.6896;
            ea_end_min_box.Text = sc.ToString();
        }

        private void Button54_Click(object sender, EventArgs e)
        {
            if (ea_end_cunj_box.Text == "")
            {
                if (ea_end_cunj_box.Text == "" || ea_end_oc_box.Text == "" || ea_end_rt_box.Text == "") return;
                double sc = double.Parse(ea_end_rt_box.Text) + 2 * double.Parse(ea_end_cunj_box.Text) + 20 * double.Parse(ea_end_oc_box.Text);
                ea_end_team_box.Text = sc.ToString();
            }
            else
            {
                if (ea_end_min_box.Text == "") return;
                double sc = double.Parse(ea_end_min_box.Text) / ((double.Parse(ea_end_osv_box.Text) - 25) * 0.45 / (250) + 1) * 0.6896;
                ea_end_team_box.Text = sc.ToString();
            }
        }

        private void Button53_Click(object sender, EventArgs e)
        {
            if (ea_end_team_box.Text == "" || ea_end_cunj_box.Text == "" || ea_end_rt_box.Text == "") return;
            double sc = (double.Parse(ea_end_team_box.Text) - 2 * double.Parse(ea_end_cunj_box.Text) - double.Parse(ea_end_rt_box.Text)) / 20;
            ea_end_oc_box.Text = sc.ToString();
        }

        private void Button52_Click(object sender, EventArgs e)
        {
            if (ea_end_team_box.Text == "" || ea_end_cunj_box.Text == "" || ea_end_oc_box.Text == "") return;
            double sc = (double.Parse(ea_end_team_box.Text) - 2 * double.Parse(ea_end_cunj_box.Text) - 20 * double.Parse(ea_end_oc_box.Text));
            ea_end_rt_box.Text = sc.ToString();
        }


        private void Panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button69_Click(object sender, EventArgs e)
        {
            if (ea_eff_e_co2team_box.Text == "") return;
            ea_eff_e_co2team_box.Text = (0.55 * double.Parse(ea_eff_e_co2team_box.Text)).ToString();
        }

        private void Button66_Click(object sender, EventArgs e)
        {
            try
            {
                double tmin = double.Parse(ea_eff_e_tmin_box.Text);
                double tminlaps = double.Parse(ea_eff_e_lapstm_box.Text);
                double tteam = double.Parse(ea_eff_e_team_box.Text);
                double lapsteam = double.Parse(ea_eff_e_lapst_box.Text);
                double co2min = double.Parse(ea_eff_e_co2min_box.Text);
                double co2laps = double.Parse(ea_eff_e_co2minlaps_box.Text);
                double co2team = double.Parse(ea_eff_e_co2team_box.Text);
                ea_eff_e_efficf_box.Text = ((tmin / tminlaps) / (tteam / lapsteam) * ((co2min / co2laps) / (co2team / lapsteam))).ToString();
            }
            catch (Exception) { }
        }
    }
}
