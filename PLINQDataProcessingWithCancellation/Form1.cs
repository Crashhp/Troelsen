using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLINQDataProcessingWithCancellation
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void ProcessingData()
        {
            try
            {
                int[] source = Enumerable.Range(1, 50000000).ToArray();
                Stopwatch watch = Stopwatch.StartNew();
                int[] modThreeIsZero = source.AsParallel().WithCancellation(cancelToken.Token).Where(num => num % 3 == 0).OrderByDescending(num => num).Select(num => num).ToArray();
                watch.Stop();
                var ms = watch.ElapsedMilliseconds;
                MessageBox.Show(string.Format("Found {0} numbers that match query in {1} ms!", modThreeIsZero.Count(), ms));
            }
            catch (OperationCanceledException ex)
            {
                this.Invoke((Action)delegate
                {
                    Text = ex.Message;
                });
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                ProcessingData();
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
