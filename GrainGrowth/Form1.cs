using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace GrainGrowth
{
    public partial class Form1 : Form
    {
        public int XSize { get; set; } = 1;
        public int YSize { get; set; } = 1;
        public int NucleonAmount { get; set; }
        public int InclusionAmount { get; set; }
        public Color[] colorArray { get; set; }
        Bitmap checkpoint;
        Bitmap readBitmap;
        Graphics graphic;
        public bool isGrainActive { get; set; }
        Random random;
        List<int[,]> borderCoordinates;
        List<int[,]> globalBorder = new List<int[,]>();
        bool isBitmap = false;
        bool isGrainClick = false;

        public struct Grain
        {
            public int GrainId { get; set; }
            public int Value { get; set; }

        }
        Grain[,] grainCointainer;
        Grain[,] grainCointainerSecond;
        int [,] inclusionAfterArray;
        //Grain[,] inclusionsAfter;
        int[] total;
        int maximum, id;


        public Form1()
        {
            InitializeComponent();
            this.NucleonAmount = 0;
            this.isGrainActive = true;
            this.maximum = 0;
            this.id = 0;
            this.Neighbornhood.Text = "von Neumann";
            
        }
        public void randomGrain(int XSize, int YSize, int NucleonAmount, Random random)
        {
            int temp1, temp2;
            for (int i = 0; i < NucleonAmount; i++)
            {
                temp1 = random.Next(1, YSize-1);
                temp2 = random.Next(1, XSize-1);

                while(grainCointainer[temp1,temp2].Value == 2)
                {
                    temp1 = random.Next(1, YSize - 1);
                    temp2 = random.Next(1, XSize - 1);
                }

                grainCointainer[temp1, temp2].GrainId = i + 1;
                grainCointainer[temp1, temp2].Value = 1;
              //  Console.WriteLine("Ziarno: "+i+" Wsp Y: " + temp1 + " X: " + temp2);

            }
        }
        public void randomInclusionAfter(int InclusionAmount, int size)
        {
            graphic = Graphics.FromImage(checkpoint);
            borderCoordinates = new List<int[,]>();
            for (int y = 2; y < YSize - 2; y++)
            {
                for (int x = 2; x < XSize - 2; x++)
                {
                    int[,] temp = new int[1, 2];
                    if (grainCointainer[y,x].GrainId != grainCointainer[y-1, x].GrainId 
                        || grainCointainer[y, x].GrainId != grainCointainer[y, x-1].GrainId || 
                        grainCointainer[y, x].GrainId != grainCointainer[y + 1, x].GrainId ||
                        grainCointainer[y, x].GrainId != grainCointainer[y, x+1].GrainId)
                    {
                        temp[0,0] = y;
                        temp[0, 1] = x;
                        borderCoordinates.Add(temp);
                        
                    }
                   
                }
            }

            if(borderCoordinates.Any())
            {
                var localBorderCoordinates = borderCoordinates;
                for (int i = 0; i < borderCoordinates.Count; i++)
                {
                    // Console.WriteLine(borderCoordinates[i][0,0]+ " " + borderCoordinates[i][0, 1]);
                }
                inclusionAfterArray = new int[InclusionAmount, 2];
                Random rand = new Random();
                for (int i = 0; i < InclusionAmount; i++)

                {
                    var randomBorderPoint = localBorderCoordinates[rand.Next(localBorderCoordinates.Count)];
                    localBorderCoordinates.Remove(randomBorderPoint);

                    SolidBrush brush = new SolidBrush(Color.Black);
                    var inclusionX = (int)(randomBorderPoint[0, 0] - (double)(size / 2));
                    var inclusionY = (int)(randomBorderPoint[0, 1] - (double)(size / 2));

                    inclusionX = inclusionX < 2 ? 2 : (inclusionX > (XSize - 2) ? (XSize - 2) : inclusionX);
                    inclusionY = inclusionY < 2 ? 2 : (inclusionY > (XSize - 2) ? (XSize - 2) : inclusionY);
                    grainCointainer[inclusionX, inclusionY].Value = 2;
                    graphic.FillRectangle(brush, inclusionX, inclusionY, size, size);
                }
            } else
            {
                Random rand = new Random();
                for (int i = 0; i < InclusionAmount; i++)
                {
                    var inclusionX = rand.Next(XSize - 2) + 1;
                    var inclusionY = rand.Next(YSize - 2) + 1;

                    SolidBrush brush = new SolidBrush(Color.Black);

                    inclusionX = inclusionX < 2 ? 2 : (inclusionX > (XSize - 2) ? (XSize - 2) : inclusionX);
                    inclusionY = inclusionX < 2 ? 2 : (inclusionY > (XSize - 2) ? (XSize - 2) : inclusionY);

                    for (int ss = inclusionX; ss < inclusionX + size; ss++)
                    {
                        for (int sss = inclusionY; sss <= inclusionY + size; sss++)
                        {
                            if (ss > 0 && ss < XSize && sss > 0 && sss < YSize)
                            {
                                grainCointainer[ss, sss].Value = 2;
                            }
                        }
                    }

                    graphic.FillRectangle(brush, inclusionX, inclusionY, size, size);
                   
                }
            }

            pictureBox.Image = checkpoint;
            pictureBox.Refresh();
        }

        private bool IsAnyInclusion(Grain[,] tab)
        {
            for(var x = 0; x < XSize; x++)
            {
                for (var y = 0; y <YSize;y++)
                {
                    if (tab[x,y].Value == 2) return true;
                }
            } 
            return false;
        }

        public void createGrainArrays(int XSize, int YSize)
        {
            grainCointainer = new Grain[YSize, XSize];
            grainCointainerSecond = new Grain[YSize, XSize];

            for (int i = 0; i < YSize; i++)                                                                 
            {
                for (int j = 0; j < XSize; j++)
                {
                    grainCointainer[i, j] = new Grain();
                    grainCointainerSecond[i, j] = new Grain();
                }
            }

        }
        public void clearGrainValue(int XSize, int YSize)
        {
            for (int i = 0; i < YSize; i++)                                                                  
            {
                for (int j = 0; j < XSize; j++)
                {
                    grainCointainer[i, j].Value = 0;
                    grainCointainerSecond[i, j].Value = 0;
                }
            }

        }
        public Random setGrainColor(int NucleonAmount, int XSize, int YSize)
        {

            colorArray = new Color[XSize * YSize + 1];
            colorArray[0] = Color.White;
            //colorArray[1] = Color.White;
            Random random = new Random();
            for (int i = 1; i <= (YSize*XSize); i++)
            {
                colorArray[i] = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            }
            return random;
        }

        public void copyGrainArray(int XSize, int YSize, bool isGrainActive)
        {
            for (int i = 0; i < YSize; i++)
            {
                for (int j = 0; j < XSize; j++)                                                                 
                {
                    if(isGrainActive == true)
                    {
                        grainCointainerSecond[i, j].Value = grainCointainer[i, j].Value;
                        grainCointainerSecond[i, j].GrainId = grainCointainer[i, j].GrainId;
                    }
                    else
                    {
                        grainCointainer[i, j].Value = grainCointainerSecond[i, j].Value;
                        grainCointainer[i, j].GrainId = grainCointainerSecond[i, j].GrainId;

                    }
                   
                }
            }
        }

        private void NAmountLabel_Click(object sender, EventArgs e)
        {

        }



        public  int drawGrain(Grain[,] grainCointainer, Color[] color, Bitmap checkpoint)
        {
            int sizeFirst, sizeSecond, sizeThird, temp;
            sizeFirst = 1;
            sizeSecond = YSize - 1;
            sizeThird = XSize - 1;
            temp = 1;

            int counter = 0;
            graphic = Graphics.FromImage(checkpoint);
          
            for (int i = sizeFirst; i < sizeSecond; i++)
            {
                for (int j = sizeFirst; j < sizeThird; j++)
                {
                    if (grainCointainer[i, j].Value == 2)
                    {
                        SolidBrush brush = new SolidBrush(Color.Black);
                        graphic.FillRectangle(brush, i * temp, j * temp, temp, temp);
                    }
                    else
                    {

                        SolidBrush brush = new SolidBrush(color[grainCointainer[i, j].GrainId]);
                        graphic.FillRectangle(brush, i * temp, j * temp, temp, temp);
                    }

                    if (grainCointainer[i, j].Value == 0)
                            counter++; 
                }
            }
            System.Threading.Thread.Sleep(10);
            this.BeginInvoke((MethodInvoker)delegate {
                pictureBox.Image = checkpoint;
                pictureBox.Refresh();
            });
           
            return counter;

        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            randomGrain(XSize, YSize, NucleonAmount, random);
            isGrainActive = true;
            copyGrainArray(XSize, YSize, isGrainActive);
            drawGrain(grainCointainer, colorArray, checkpoint);
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            Task.Run(async () => await DrawGrainsAsync());
        }

        private async Task<bool> DrawGrainsAsync()
        {
            int sizeFirst, sizeSecond, sizeThird;

            sizeFirst = 1;
            sizeSecond = YSize - 1;
            sizeThird = XSize - 1;
            total = new int[YSize * XSize + 1];
            int next = 0;
            int counter = 1;
            while (counter > 0)
            {
                for (int i = sizeFirst; i < sizeSecond; i++)
                {
                    for (int j = sizeFirst; j < sizeThird; j++)
                    {
                        Random rand = new Random();
                        int x = rand.Next(0, 2);
                        maximum = 0;
                        id = 0;
                        if (grainCointainer[i, j].Value == 0 && grainCointainer[i,j].Value != 2)
                        {
                            if (NeighbornhoodType == "Moore")
                            next = mooreMethod(grainCointainer, i, j);
                            if (NeighbornhoodType == "von Neumann")
                                 next = vonNeumannMethod(grainCointainer, i, j);
                            if (maximum != 0)
                            {
                                grainCointainerSecond[i, j].Value = 1;
                                grainCointainerSecond[i, j].GrainId = id;
                            }

                        }
                    }
                }
                isGrainActive = false;
                copyGrainArray(XSize, YSize, isGrainActive);
                counter = drawGrain(grainCointainer, colorArray, checkpoint);
            }
                return await Task.FromResult<bool>(true);

        }

        private int vonNeumannMethod(Grain[,] grainCointainer, int i, int j)
        {
            int up, down, left, right;
            up = i - 1;
            down = i + 1;
            left = j - 1;
            right = j + 1;

            for (int q = 1; q < NucleonAmount + 1; q++)
            {
                total[q] = 0;

                if (grainCointainer[up, j].GrainId == q) total[q]++;
                if (grainCointainer[i, left].GrainId == q) total[q]++;
                if (grainCointainer[i, right].GrainId == q) total[q]++;
                if (grainCointainer[down, j].GrainId == q) total[q]++;
                if (total[q] > maximum)
                {
                    maximum = total[q];
                    id = q;

                }
            }
            return 0;
        }

        private int mooreMethod(Grain[,] grainCointainer, int i, int j)
        {
            int up, down, left, right;
            up = i - 1;
            down = i + 1;
            left = j - 1 ;
            right = j + 1 ;

            for (int k = 1; k < NucleonAmount + 1; k++)
            {
                total[k] = 0;

                if (grainCointainer[up, left].GrainId == k) total[k]++;
                if (grainCointainer[up, j].GrainId == k) total[k]++;
                if (grainCointainer[up, right].GrainId == k) total[k]++;
                if (grainCointainer[i, left].GrainId == k) total[k]++;
                if (grainCointainer[i, right].GrainId == k )total[k]++;
                if (grainCointainer[down, left].GrainId == k) total[k]++;
                if (grainCointainer[down, j].GrainId == k) total[k]++;
                if (grainCointainer[down, right].GrainId == k) total[k]++;
                if (total[k] > maximum)
                {
                    maximum = total[k];
                    id = k;

                }
            }
            return 0;
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            checkpoint.Save("result.bmp", ImageFormat.Bmp);
        }

        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                Bitmap imageImport = new Bitmap(file, true);
                XSize = (imageImport.Height);
                YSize = (imageImport.Width);
                createGrainArrays(XSize, YSize);
                clearGrainValue(XSize, YSize);
              
                List < Color> colors = new List<Color>(); //
                Color [] localColor = new Color[XSize * YSize + 1];
                try
                {
                    for (int y = 1; y < imageImport.Width-1; y++)
                    {
                        for (int x = 1; x < imageImport.Height-1; x++)
                        {
                            Color clr = imageImport.GetPixel(y, x);
                           
                            if (!colors.Contains(clr))
                             {
                                colors.Add(clr);
                            }
                        }
                    }

                    //test_box.Text = XSize.ToString();
                    for (int i = 0; i < colors.Count; i++)
                    {
                        Console.WriteLine(i.ToString());
                    }

                    colorArray = new Color[colors.Count];
                   // colorArray[0] = Color.Black;

                    Random random = new Random();
                    for (int i = 0; i < (colors.Count); i++)
                    {
                        colorArray[i] = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                    }

                    for (int y = 1; y < imageImport.Width - 1; y++)
                    {
                        for (int x = 1; x < imageImport.Height - 1; x++)
                        {
                            Color clr = imageImport.GetPixel(y, x);
                            for (int i = 0; i < colors.Count; i++)
                            {
                                if (clr == colors[i])
                                {
                                    grainCointainer[y, x].GrainId = i;
                                    grainCointainer[y, x].Value = 1;
                                }
                            }
                          
                        }
                    }
                    isBitmap = true;

                    checkpoint = new Bitmap(  YSize,  XSize);
                    pictureBox.Size = new Size(YSize, XSize);
                    drawGrain(grainCointainer, colorArray, checkpoint);

                }
                catch (IOException)
                {

                }
            }


            //readBitmap = new Bitmap("result.bmp", true);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
               
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    

                    StreamReader str = new StreamReader(file);
                    List<String[]> sizes = File.ReadLines(file).Select(value => value.Split(' ').Take(3).ToArray()).ToList();
                    YSize = Int32.Parse(sizes[0][0]);
                    XSize = Int32.Parse(sizes[0][1]);
                    NucleonAmount = Int32.Parse(sizes[0][2]);
                    createGrainArrays(XSize, YSize);
                    clearGrainValue(XSize, YSize);
                    checkpoint = new Bitmap(YSize, XSize);
                    pictureBox.Size = new Size(YSize, XSize);
                    random = setGrainColor(NucleonAmount, XSize, YSize);
                    List<String[]> line = File.ReadLines(file).Select(value => value.Split(' ').Take(4).ToArray()).ToList();
                    for (int i = 1; i < line.Count; i++)
                    {
                        grainCointainer[Int32.Parse(line[i][0]), Int32.Parse(line[i][1])].GrainId = Int32.Parse(line[i][2]);
                        grainCointainer[Int32.Parse(line[i][0]), Int32.Parse(line[i][1])].Value = Int32.Parse(line[i][3]);
                        //Console.WriteLine(Int32.Parse(line[i][0]) + " " + Int32.Parse(line[i][1]) + " " + grainCointainer[Int32.Parse(line[i][0]), Int32.Parse(line[i][1])].GrainId +
                        //    " " + grainCointainer[Int32.Parse(line[i][0]), Int32.Parse(line[i][1])].Value);

                    }
                    isGrainActive = true;
                    copyGrainArray(XSize, YSize, isGrainActive);
                    drawGrain(grainCointainer, colorArray, checkpoint);

                    //test_box.Text = line.Count.ToString();

                }
                catch (IOException)
                {
                    
                }
            }


        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

           // FileStream fileStream = new FileStream("result.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter streamWriter = new StreamWriter("result2.txt");
           
            streamWriter.WriteLine(YSize + " " + XSize  + " " + NucleonAmount);
            
            for (int y = 1; y < YSize-1; y++)
            {
                for (int x = 1; x < XSize-1; x++)
                {
                    streamWriter.WriteLine(y + " " + x + " " + grainCointainer[y, x].GrainId + " " + grainCointainer[y, x].Value);
                
                }
            }
            
            streamWriter.Flush();
            streamWriter.Close();
        }
        private void setGrainID()
        {

        }

        private void RedrawSpace()
        {
            random = setGrainColor(NucleonAmount, XSize, YSize);
            checkpoint = new Bitmap( YSize, XSize);
            pictureBox.Size = new Size(YSize, XSize);
            createGrainArrays(XSize, YSize);
            clearGrainValue(XSize, YSize);
        }

        private void XSizeBox_TextChanged(object sender, EventArgs e)
        {
            var result = 0;
            var success = Int32.TryParse(XSizeBox.Text, out result);
            if(success)
            {
                XSize = result;
            }
            inclusionsSize.SetRange(2, XSize);
            RedrawSpace();
        }

        private void NucleonAmountBox_ValueChanged(object sender, EventArgs e)
        {
            NucleonAmount = (int) NucleonAmountBox.Value;
            RedrawSpace();
        }

        private void YSizeBox_TextChanged(object sender, EventArgs e)
        {
            var result = 0;
            var success = Int32.TryParse(YSizeBox.Text, out result);
            if (success)
            {
                YSize = result;
            }
            RedrawSpace();
        }

        private void inclusions_Click(object sender, EventArgs e)
        {
            InclusionAmount = Int32.Parse(string.IsNullOrEmpty(inclusionsInput.Text) ? "0" : inclusionsInput.Text);
            randomInclusionAfter(InclusionAmount, inclusionsSize.Value);
        }


        private void clearButton_Click(object sender, EventArgs e)
        {

            SolidBrush brush = new SolidBrush(Color.White);

            if (isGrainClick == false)
            {


                for (int i = 0; i < borderCoordinates.Count; i++)
                {
                    for (int y = 1; y < YSize - 1; y++)
                    {
                        for (int x = 1; x < XSize - 1; x++)
                        {

                            // int temp[,] = new int [1,2]{ { grainCointainer, x } };

                            if (borderCoordinates[i][0, 0] != y && borderCoordinates[i][0, 1] != x)
                            {
                                graphic.FillRectangle(brush, y, x , 1, 1);


                            }


                        }

                    }
                }
                pictureBox.Image = checkpoint;
                pictureBox.Refresh();


                boundaries_Click(sender, e);
            }
            else
            {
                Console.WriteLine("isGrainClick TRUE");

                for (int y = 1; y < YSize-1; y++)
                {
                    for (int x = 1; x < XSize-1; x++)
                    {
                        //int[,] temp = new int[1, 2] { { y, x } };
                        graphic.FillRectangle(brush, y, x, 1, 1);
                        
                        //for (int i = 0; i < globalBorder.Count; i++)
                       // {
                           // graphic.FillRectangle(brush, y, x, 1, 1);


                           /* if (globalBorder[i][0,0] == y && globalBorder[i][0,1] == x)
                            {
                                graphic.FillRectangle(brush, y, x, 1, 1);
                            }
                            else
                            {
                               // graphic.FillRectangle(brush, y, x, 1, 1);
                            }
                            */
                       // }
                        


                    }
                }

                pictureBox.Image = checkpoint;
                pictureBox.Refresh();
                for (int i = 0; i < globalBorder.Count; i++)
                {
                    SolidBrush brush2 = new SolidBrush(Color.Black);
                    graphic.FillRectangle(brush2, globalBorder[i][0,0], globalBorder[i][0,1], 1, 1);
                    
                   
                }
                pictureBox.Image = checkpoint;
                pictureBox.Refresh();

            }

        }

        private void boundaries_Click(object sender, EventArgs e)
        {
            borderCoordinates = new List<int[,]>();

            for (int y = 2; y < YSize - 2; y++)
            {
                for (int x = 2; x < XSize - 2; x++)
                {
                    int[,] temp = new int[1, 2];
                    if (grainCointainer[y, x].GrainId != grainCointainer[y - 1, x].GrainId
                        || grainCointainer[y, x].GrainId != grainCointainer[y, x - 1].GrainId)/*/ ||
                        grainCointainer[y, x].GrainId != grainCointainer[y + 1, x].GrainId ||
                        grainCointainer[y, x].GrainId != grainCointainer[y, x + 1].GrainId)*/
                    {
                        temp[0, 0] = y;
                        temp[0, 1] = x;
                        borderCoordinates.Add(temp);

                    }

                }
            }
            //borders rows and columns
            //left
            Console.WriteLine("XSize: ", XSize);
            for (int x = 1; x < XSize - 2; x++)
            {
                int[,] temp = new int[1, 2];
                if (grainCointainer[1, x].GrainId != grainCointainer[2, x].GrainId || grainCointainer[1, x].GrainId != grainCointainer[1, x + 1].GrainId)
                {
                    temp[0, 0] = 1;
                    temp[0, 1] = x;
                    borderCoordinates.Add(temp);
                }
            }
            //up
            for (int y = 1; y < YSize - 2; y++)
            {
                int[,] temp = new int[1, 2];
                if (grainCointainer[y, 1].GrainId != grainCointainer[y + 1, 1].GrainId || grainCointainer[y, 1].GrainId != grainCointainer[y, 2].GrainId)
                {
                    temp[0, 0] = y;
                    temp[0, 1] = 1;
                    borderCoordinates.Add(temp);
                }
            }
            //right
            for (int x = 1; x < XSize - 2; x++)
            {
                int[,] temp = new int[1, 2];
                if (grainCointainer[YSize - 2, x].GrainId != grainCointainer[YSize - 2, x + 1].GrainId || grainCointainer[YSize-2, x].GrainId != grainCointainer[YSize-3, x].GrainId)
                {
                    temp[0, 0] = YSize - 2;
                    temp[0, 1] = x;
                    borderCoordinates.Add(temp);
                }
            }
            //down

            for (int y = 1; y < YSize - 2; y++)
            {
                int[,] temp = new int[1, 2];
                if (grainCointainer[y, XSize - 2].GrainId != grainCointainer[y + 1, XSize - 2].GrainId)// || grainCointainer[YSize-2, x].GrainId != grainCointainer[YSize-1, x].GrainId)
                {
                    temp[0, 0] = y;
                    temp[0, 1] = XSize - 2;
                    borderCoordinates.Add(temp);
                }
            }
            SolidBrush brush = new SolidBrush(Color.Black);
            for (int i = 0; i < borderCoordinates.Count; i++)
            {
                graphic.FillRectangle(brush, borderCoordinates[i][0, 0], borderCoordinates[i][0, 1], 1, 1);
            }


            pictureBox.Image = checkpoint;
            pictureBox.Refresh();
            for (int i = 0; i < borderCoordinates.Count; i++)
            {
                //Console.WriteLine(borderCoordinates[i][0, 0] + " " + borderCoordinates[i][0, 1]);
            }
            isGrainClick = false;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {


            this.Cursor = new Cursor(Cursor.Current.Handle);
            var mouseEventArgs = e as MouseEventArgs;
            int xCoordinate = (mouseEventArgs.Y);
            int yCoordinate = (mouseEventArgs.X);
            Console.WriteLine("X: " + xCoordinate + " Y: " + yCoordinate);
            //test_box.Text = MousePosition.Y.ToString();
            isGrainClick = true;
            boundaries_Click(xCoordinate, yCoordinate);

        }

        private void drawFromFile(int YSize, int XSize, int NucleonAmount)
        {

        }

        private void Neighbornhood_SelectedIndexChanged(object sender, EventArgs e)
        {
            NeighbornhoodType = Neighbornhood.Text;
        }

        public string NeighbornhoodType { get; set; }

        private void boundaries_Click(int X, int Y)

        {
            int tempId = grainCointainer[Y, X].GrainId;
            Console.WriteLine("id: " + tempId);
            borderCoordinates = new List<int[,]>();

            for (int y = 2; y < YSize - 2; y++)
            {
                for (int x = 2; x < XSize - 2; x++)
                {
                    int[,] temp = new int[1, 2];
                    if (grainCointainer[y,x].GrainId == tempId)
                    {
                        if (!(tempId == grainCointainer[y,x-1].GrainId && tempId == grainCointainer[y+1, x-1].GrainId
                            && tempId==grainCointainer[y+1,x].GrainId && tempId == grainCointainer[y+1,x+1].GrainId
                            && tempId == grainCointainer[y,x+1].GrainId && tempId== grainCointainer[y-1,x+1].GrainId
                            && tempId == grainCointainer[y-1,x].GrainId && tempId == grainCointainer[y-1,x-1].GrainId))
                        {
                            temp[0, 0] = y;
                            temp[0, 1] = x;
                            borderCoordinates.Add(temp);

                        }

                    }
                  

                }
            }
            
            //left
            for (int x = 1; x < XSize - 2; x++)
            {
                int[,] temp = new int[1, 2];
                if (grainCointainer[1, x].GrainId == tempId)
                {
                    if (tempId != grainCointainer[2, x].GrainId || tempId != grainCointainer[1, x + 1].GrainId  )
                    {
                        temp[0, 0] = 1;
                        temp[0, 1] = x;
                        borderCoordinates.Add(temp);
                    }
                    else if (((x-1) != 0 )&&  tempId != grainCointainer[1, x - 1].GrainId)
                    {
                        temp[0, 0] = 1;
                        temp[0, 1] = x;
                        borderCoordinates.Add(temp);

                    }
                }
               
            }
            //up
            for (int y = 1; y < YSize - 2; y++)
            {
                int[,] temp = new int[1, 2];
                if (grainCointainer[y, 1].GrainId==tempId)
                {
                    if (tempId != grainCointainer[y + 1, 1].GrainId || tempId != grainCointainer[y, 2].GrainId)
                    {
                        temp[0, 0] = y;
                        temp[0, 1] = 1;
                        borderCoordinates.Add(temp);
                    }
                    else if (((y-1)!=0) && tempId != grainCointainer[y-1,1].GrainId)
                    {
                        temp[0, 0] = y;
                        temp[0, 1] = 1;
                        borderCoordinates.Add(temp);

                    }
                }
              
            }
            //right
            for (int x = 1; x < XSize - 2; x++)
            {
                int[,] temp = new int[1, 2];
                if (grainCointainer[YSize - 2, x].GrainId == tempId)
                {
                    if (tempId != grainCointainer[YSize - 2, x + 1].GrainId || tempId != grainCointainer[YSize - 3, x].GrainId )//|| tempId != grainCointainer[YSize -2, x-1].GrainId)
                    {
                        temp[0, 0] = YSize - 2;
                        temp[0, 1] = x;
                        borderCoordinates.Add(temp);
                    }
                    else if(((x-1) != 0)  && tempId != grainCointainer[YSize - 2, x - 1].GrainId)
                    {
                        temp[0, 0] = YSize - 2;
                        temp[0, 1] = x;
                        borderCoordinates.Add(temp);
                    }
                }
             
            }
            //down

            for (int y = 1; y < YSize - 2; y++)
            {
                int[,] temp = new int[1, 2];
                if (grainCointainer[y, XSize - 2].GrainId == tempId)
                {
                    if (tempId != grainCointainer[y + 1, XSize - 2].GrainId )//|| tempId != grainCointainer[y-1, XSize-2].GrainId)
                    {
                        temp[0, 0] = y;
                        temp[0, 1] = XSize - 2;
                        borderCoordinates.Add(temp);
                    }
                    else if (((y-1)!=0) && tempId !=grainCointainer[y-1,XSize-2].GrainId)
                    {
                        temp[0, 0] = y;
                        temp[0, 1] = XSize - 2;
                        borderCoordinates.Add(temp);
                    }

                }
              
            }
            
            SolidBrush brush = new SolidBrush(Color.Black);
            for (int i = 0; i < borderCoordinates.Count; i++)
            {
                graphic.FillRectangle(brush, borderCoordinates[i][0, 0], borderCoordinates[i][0, 1], 1, 1);
            }


            pictureBox.Image = checkpoint;
            pictureBox.Refresh();
            foreach (var item in borderCoordinates)
            {
                globalBorder.Add(item);
            }
            isGrainClick = true;
        }


    }

}
