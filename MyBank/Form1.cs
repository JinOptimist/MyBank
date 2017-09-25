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
        private List<TradePoint> BillsGroups { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void DoGood_Click(object sender, EventArgs e)
        {
            var path = @"d:\1.csv";
            var lines = File.ReadAllLines(path, Encoding.UTF8);
            var bills = lines.Select(x => new Bill(x));

            BillsGroups = new List<TradePoint>();
            foreach (var bill in bills) {
                var currentGroup = BillsGroups.FirstOrDefault(x => x.GroupName == bill.Desc);
                if (currentGroup == null) {
                    currentGroup = new TradePoint(bill.Desc, bill.Currency);
                    BillsGroups.Add(currentGroup);
                }
                currentGroup.Bills.Add(bill);
            }
            BillsGroups = BillsGroups.OrderByDescending(x => x.MainSumm).ToList();

            var spendingGroups = new List<SpendingGroup>();

            var eatMarks = new List<string> { "KRASAVIK", "MCDONALDS", "RESTORAN", "EVROOPT", "KOFEYNYA", "WOK.BY" };
            spendingGroups.Add(new SpendingGroup("Еда", eatMarks));
            
            var sportMarks = new List<string> { "ADRENALIN" };
            spendingGroups.Add(new SpendingGroup("Спорт", sportMarks));

            var moviesMarks = new List<string> { "SILVERSCREEN", "KINO.BYCARD" };
            spendingGroups.Add(new SpendingGroup("Кино", moviesMarks));

            spendingGroups.ForEach(x => ReportTree.Nodes.Add(CreateTreeNode(x)));

            var jsonStr = SerializeHelper.Serialize<List<SpendingGroup>>(spendingGroups);
            var jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "groupSetting.json");

            File.WriteAllText(jsonPath, jsonStr);

            var otherNode = new TreeNode($"Остальное. Сумма: {BillsGroups.Sum(x => x.MainSumm)}. Счетов: {BillsGroups.Sum(x => x.Bills.Count())}");
            BillsGroups.ForEach(x => otherNode.Nodes.Add(x.ToString()));
            ReportTree.Nodes.Add(otherNode);
        }

        private void Test(List<SpendingGroup> spendingGroups)
        {
            foreach(var a in spendingGroups) {
                
            }
            
        }

        private TreeNode CreateTreeNode(SpendingGroup spendingGroup)
        {
            var node = new TreeNode();

            double summ = 0;
            var count = 0;
            foreach (var mark in spendingGroup.Marks) {
                var groupBill = BillsGroups.FirstOrDefault(x => x.GroupName.Contains(mark));
                if (groupBill != null) {
                    summ += groupBill.MainSumm;
                    count += groupBill.Bills.Count();
                    node.Nodes.Add(groupBill.Guid.ToString(), groupBill.ToString());
                    BillsGroups.Remove(groupBill);
                }
            }
            node.Text = $"{spendingGroup.Name}. Сумма: {summ}. Счетов: {count}";
            return node;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var guid = ReportTree.SelectedNode.Name;
            var bill = BillsGroups.FirstOrDefault(x => x.Guid.ToString() == guid);


        }
    }
}
