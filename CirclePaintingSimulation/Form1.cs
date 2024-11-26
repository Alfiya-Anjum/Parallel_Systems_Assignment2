using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CirclePaintingSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            for (int i = 5; i <= 100; i += 5)
            {
                cbWorkerCount.Items.Add(i);
            }
            cbWorkerCount.SelectedIndex = 0; 
        }

        private List<Circle> GenerateCircles(int count)
        {
            var circles = new List<Circle>();
            int circlesPerRow = pictureBox1.Width / (int)(Circle.Radius * 2); 
            int rowCount = count / circlesPerRow + 1; 

            int id = 0;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < circlesPerRow; col++)
                {
                    if (id >= count) break; 

                    circles.Add(new Circle
                    {
                        Id = id++,
                        X = (col * Circle.Radius * 2) + Circle.Radius,
                        Y = (row * Circle.Radius * 2) + Circle.Radius  
                    });
                }
            }
            return circles;
        }

        private async Task PaintCirclesAsync(List<Circle> circles, int workerCount)
        {
            var workers = new List<Worker>();
            var random = new Random();

            for (int i = 0; i < workerCount; i++)
            {
                workers.Add(new Worker
                {
                    Id = i,
                    WorkerColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256))
                });
            }

            var lockObject = new object();
            int paintedCount = 0;
            var totalCircles = circles.Count;

            var graphics = pictureBox1.CreateGraphics();

            var stopwatch = Stopwatch.StartNew();

            var tasks = new List<Task>();
            foreach (var worker in workers)
            {
                tasks.Add(Task.Run(() =>
                {
                    while (true)
                    {
                        Circle circleToPaint = null;

                        
                        lock (lockObject)
                        {
                            circleToPaint = circles.Find(c => !c.IsPainted);
                            if (circleToPaint == null) break; 
                            circleToPaint.IsPainted = true;
                            paintedCount++;
                        }

                       
                        Thread.Sleep(20);

                        
                        lock (graphics)
                        {
                            using (var brush = new SolidBrush(worker.WorkerColor))
                            {
                                graphics.FillEllipse(brush,
                                    circleToPaint.X - Circle.Radius, circleToPaint.Y - Circle.Radius,
                                    Circle.Radius * 2, Circle.Radius * 2);
                            }
                        }

                       
                        Invoke(new Action(() =>
                        {
                            lblWorkers.Text = $"Progress: {paintedCount}/{totalCircles}";
                        }));
                    }
                }));
            }

            await Task.WhenAll(tasks);
            stopwatch.Stop();
            MessageBox.Show($"All circles have been painted! Time taken: {stopwatch.ElapsedMilliseconds} ms");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (cbWorkerCount.SelectedItem == null)
            {
                MessageBox.Show("Please select the number of workers.");
                return;
            }       
            int workerCount = int.Parse(cbWorkerCount.SelectedItem.ToString());

            // Generate circles
            var circles = GenerateCircles(1000);         
            pictureBox1.Refresh();           
            await PaintCirclesAsync(circles, workerCount);
        }

        private void lblWorkers_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbWorkerCount_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
