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
        private List<GroupBill> BillsGroups { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void DoGood_Click(object sender, EventArgs e)
        {
            var path = @"d:\1.csv";
            var lines = File.ReadAllLines(path, Encoding.UTF8);
            var bills = lines.Select(x => new Bill(x));

            BillsGroups = new List<GroupBill>();
            foreach (var bill in bills) {
                var currentGroup = BillsGroups.FirstOrDefault(x => x.GroupName == bill.Desc);
                if (currentGroup == null) {
                    currentGroup = new GroupBill(bill.Desc, bill.Currency);
                    BillsGroups.Add(currentGroup);
                }
                currentGroup.Bills.Add(bill);
            }
            BillsGroups = BillsGroups.OrderByDescending(x => x.MainSumm).ToList();

            var eatMarks = new List<string> { "KRASAVIK", "MCDONALDS", "RESTORAN", "EVROOPT", "KOFEYNYA", "WOK.BY" };
            ReportTree.Nodes.Add(CreateTreeNode("Еда", eatMarks));

            var sportMarks = new List<string> { "ADRENALIN" };
            ReportTree.Nodes.Add(CreateTreeNode("Спорт", sportMarks));

            var moviesMarks = new List<string> { "SILVERSCREEN", "KINO.BYCARD" };
            ReportTree.Nodes.Add(CreateTreeNode("Кино", moviesMarks));

            var otherNode = new TreeNode($"Остальное. Сумма: {BillsGroups.Sum(x => x.MainSumm)}. Счетов: {BillsGroups.Sum(x => x.Bills.Count())}");
            BillsGroups.ForEach(x => otherNode.Nodes.Add(x.ToString()));
            ReportTree.Nodes.Add(otherNode);
        }

        private TreeNode CreateTreeNode(string name, List<string> groupMarks)
        {
            var node = new TreeNode();

            double summ = 0;
            var count = 0;
            foreach (var mark in groupMarks) {
                var groupBill = BillsGroups.FirstOrDefault(x => x.GroupName.Contains(mark));
                if (groupBill != null) {
                    summ += groupBill.MainSumm;
                    count += groupBill.Bills.Count();
                    node.Nodes.Add(groupBill.Guid.ToString(), groupBill.ToString());
                    BillsGroups.Remove(groupBill);
                }
            }
            node.Text = $"{name}. Сумма: {summ}. Счетов: {count}";
            return node;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var guid = ReportTree.SelectedNode.Name;
            var bill = BillsGroups.FirstOrDefault(x => x.Guid.ToString() == guid);


        }
    }
}
