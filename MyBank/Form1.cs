using MyBank.Model;
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

namespace MyBank
{
    public partial class Form1 : Form
    {
        private List<TradePoint> TradePoints { get; set; }
        private List<SpendingGroup> _spendingGroups;
        private List<SpendingGroup> SpendingGroups
        {
            get
            {
                if (_spendingGroups == null)
                {
                    var jsonTxt = File.ReadAllText(SettingFilePath, Encoding.UTF8);
                    _spendingGroups = SerializeHelper.Deserialize<List<SpendingGroup>>(jsonTxt);
                }

                return _spendingGroups;
            }
        }

        private string groupSettingFileName = "groupSetting.json";
        private string SettingFilePath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, groupSettingFileName);
            }
        }
        private string pathToMainBill = @"d:\1.csv";

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            SpendingGroupComboBox.Items.Clear();
            SpendingGroups.ForEach(x => SpendingGroupComboBox.Items.Add(x.Name));
            MainPathLabel.Text = pathToMainBill;
            SaveSettingsBtn.Enabled = false;
            AddItemToGroupBtn.Enabled = false;
            NewGroupName.Text = string.Empty;
        }

        private void DoGood_Click(object sender, EventArgs e)
        {
            ReportTree.Nodes.Clear();
            
            var lines = File.ReadAllLines(pathToMainBill, Encoding.UTF8);
            var bills = lines.Select(x => new Bill(x));

            TradePoints = new List<TradePoint>();
            foreach (var bill in bills)
            {
                var currentGroup = TradePoints.FirstOrDefault(x => x.GroupDesc == bill.Desc);
                if (currentGroup == null)
                {
                    currentGroup = new TradePoint(bill.Desc, bill.Currency);
                    TradePoints.Add(currentGroup);
                }
                currentGroup.Bills.Add(bill);
            }

            TradePoints = TradePoints.OrderByDescending(x => x.MainSumm).ToList();
            
            SpendingGroups.ForEach(x => ReportTree.Nodes.Add(CreateTreeNode(x)));

            var otherNode = new TreeNode($"Остальное. Сумма: {TradePoints.Sum(x => x.MainSumm)}. Счетов: {TradePoints.Sum(x => x.Bills.Count())}");
            TradePoints.ForEach(x => otherNode.Nodes.Add(x.Guid.ToString(), x.ToString()));
            ReportTree.Nodes.Add(otherNode);
        }

        private TreeNode CreateTreeNode(SpendingGroup spendingGroup)
        {
            var node = new TreeNode();
            double summ = 0;
            var count = 0;
            foreach (var mark in spendingGroup.Marks)
            {
                var tradePoint = TradePoints.FirstOrDefault(x => x.GroupDesc.Contains(mark));
                if (tradePoint != null)
                {
                    summ += tradePoint.MainSumm;
                    count += tradePoint.Bills.Count();
                    node.Nodes.Add(tradePoint.Guid.ToString(), tradePoint.ToString());
                    TradePoints.Remove(tradePoint);
                }
            }
            node.Text = $"{spendingGroup.Name}. Сумма: {summ}. Счетов: {count}";
            return node;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var guid = ReportTree.SelectedNode.Name;
            var bill = TradePoints.FirstOrDefault(x => x.Guid.ToString() == guid);
            var spendingGroup = SpendingGroupComboBox.SelectedItem;
            var gr = SpendingGroups.First(x => x.Name == spendingGroup);
            gr.Marks.Add(bill.GroupDesc);
            DoGood_Click(null, null);
            SaveSettingsBtn.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                pathToMainBill = openFileDialog1.FileName;
                MainPathLabel.Text = pathToMainBill;
            }
        }

        private void SaveSettingsBtn_Click(object sender, EventArgs e)
        {
            SaveSettingsBtn.Enabled = false;
            var jsonTxt = SerializeHelper.Serialize(SpendingGroups);
            File.WriteAllText(SettingFilePath, jsonTxt);
        }

        private void SpendingGroupList_SelectedValueChanged(object sender, EventArgs e)
        {
            AddItemToGroupBtn.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var newGroupName = NewGroupName.Text;
            if (string.IsNullOrEmpty(newGroupName))
            {
                return;
            }

            SpendingGroups.Add(new SpendingGroup(newGroupName, new List<string>()));
            Init();
            DoGood_Click(null, null);
            SaveSettingsBtn.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var spendingGroup = SpendingGroupComboBox.SelectedItem;
            var gr = SpendingGroups.First(x => x.Name == spendingGroup);
            SpendingGroups.Remove(gr);
            SaveSettingsBtn.Enabled = true;
            Init();
            DoGood_Click(null, null);
        }
    }
}
